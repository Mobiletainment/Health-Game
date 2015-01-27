<?php
/*
 * Author: mikew
 * 
 * Version: 0.8.1
 *
 * Project home: http://code.google.com/p/dwi
 */

require("analysis-constants.php");

class Column {
	public $name = '';
	public $type = '';
	public $isNullable = false;
	public $isPartOfPrimaryKey = false;

	public function hasStringValue() {
		return contains($this->type, 'char') || ($this->type == 'text') || ($this->type == 'set') || startsWith($this->type, 'enum');
	}
	
	public function hasDateTimeValue() {
		return contains($this->type, 'date') || contains($this->type, 'time');
	}
	
	public function hasNumericValue() {
		return contains($this->type, 'int') || contains($this->type, 'dec') || contains($this->type, 'double') || ($this->type == 'numeric') || ($this->type == 'float') || ($this->type == 'real');
	}
	
	public function isEnum() {
		return (substr($this->type, 0, 4) == 'enum');
	}

	public function isLengthy() {
		if (!$this->hasStringValue()) {
			return false;
		}
	
		if ($this->type == 'text') {
			return true;
		}
	
		preg_match_all('/([\d]+)/', $this->type, $match);
		$len = $match[0][0];
		return ($len > 75);
	}
	
	private function defaultNonNullValue() {
		if ($this->hasNumericValue()) {
			return '0';
		} elseif (contains($this->type, 'date') || ($this->type == 'timestamp')) {
			return "'1970-01-01'";
		} elseif ($this->type == 'time') {
			return "'00:00:00'";
		} elseif ($this->type == 'year') {
			return "'1970'";
		} else {
			return "''";
		}
	}
	
	public function valueForInsertingOrUpdating($userInputString, $nullOk) {
		if ($userInputString == '') {
			if ($nullOk) {
				$userInputString = 'null';
			} else {
				$userInputString = $this->defaultNonNullValue();
			}
		} else {
			if (!$this->hasNumericValue()) {
				$userInputString = "'" . mysql_real_escape_string($userInputString) . "'";
			}
		}
	
		return $userInputString;
	}
	
	function renderType() {
		$columnType = $this->type;
		if ($this->isEnum()) {
			$columnType = 'enum';
		}
		$pri = ($this->isPartOfPrimaryKey) ? '<br>(primary key)' : '';
		return "<font size='-1'><i>$columnType$pri</i></font>";
	}
	
	function renderEnumDropDown($currentValue) {
		$startPos = 0;
		$isFirst = true;
		if ($this->isEnum()) {
			while (true) {
				$startPos = strpos($this->type, "'", $startPos);
				if (!$startPos || $startPos == -1) {
					break;
				}
				$endPos = strpos($this->type, "'", $startPos + 1);
				if ($endPos == -1) {
					break;
				}
				$startPos++;
				$value = substr($this->type, $startPos, $endPos - $startPos);
				$startPos = $endPos + 1;
	
				$isSelected = ($value == $currentValue) || ($isFirst && ($value == '__DWI__SELECT__FIRST__'));
				$selected = $isSelected ? "selected='selected'" : "";
				$escapedValue = escapeSingleQuotes($value);
				$html .= "<option $selected value='$escapedValue'>$value</option>";
	
				$isFirst = false;
			}
		}
	
		return $html;
	}
}

function startsWith($bigString, $smallString) {
	return (substr($bigString, 0, strlen($smallString)) == $smallString);
}

function endsWith($bigString, $smallString) {
	$bigStringLen = strlen($bigString);
	$smallStringLen = strlen($smallString);
	$sizeDiff = $bigStringLen - $smallStringLen;
	return ($sizeDiff > 0) && (substr($bigString, $sizeDiff) == $smallString);
}

function contains($bigString, $smallString){
	return !(strpos(strtolower($bigString), strtolower($smallString)) === false);
}

function removeFromEnd($bigString, $smallString) {
	if (endsWith($bigString, $smallString)) {
		$bigString = substr($bigString, 0, strlen($bigString) - strlen($smallString));
	}
	return $bigString;
}

function containsAlphabeticCharacters($s) {
	return preg_match('[:alpha:]', $s);
}

function escapeSingleQuotes($s) {
	return str_replace("'", "&apos;", $s);
}

function makeLocalUrlArgs($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search) {
	$descArg = $desc ? '&desc=1' : '';
	$encodedTable = urlencode($table);
	$encodedOrderByColumn = urlencode($orderByColumn);
	$encodedSearch = urlencode($search);
	return "table=$encodedTable&sort=$encodedOrderByColumn$descArg&page=$pageNum&rowsPerPage=$rowsPerPage&search=$encodedSearch";
}

function makeLocalUrl($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search) {
	$baseUrl = $_SERVER['PHP_SELF'];
	return "$baseUrl?" . makeLocalUrlArgs($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search);
}

function makeLocalLink($linkText, $isActiveLink, $table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search) {
	$url = makeLocalUrl($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search);
	return $isActiveLink ? ("<a href='$url'>$linkText</a>") :
		("<span style='color: lightgrey;'>$linkText</span>");
}

function rowsPerPageOptionLine($numRows, $curRowsPerPage, $table, $orderByColumn, $search) {
	$url = makeLocalUrl($table, $orderByColumn, $desc, 1, $numRows, $search);
	$selected = ($numRows == $curRowsPerPage) ? "selected='selected'" : "";
	return "<option $selected value='$url'>$numRows</option>\n";
}

function makeCellId($rowNum, $colNum) {
	return 'r' . $rowNum . 'c' . $colNum;
}

function getTableList($dbName) {
	// inputs (variables that are read but not modified)
	global $connection;

	$tables = null;

	$results = mysql_query("show tables from " . $dbName, $connection);
	while ($row = mysql_fetch_row($results)) {
		$tables[] = $row[0];
	} 

	return $tables;
}

function generateTableSelector($selectedTable) {
	// inputs (variables that are read but not modified)
	global $tableList;

	$tableSelector = "<select onchange='location = this.options[this.selectedIndex].value;'>\n";
	for ($i = 0; $i < count($tableList); $i++) {
		$table = $tableList[$i];
		$url = "$baseUrl?table=$table";
		$selected = ($table == $selectedTable) ? ' selected="selected"' : '';
		$tableSelector .= "<option value='$url'$selected>$table</option>\n";
	} 
	$tableSelector .= "</select>\n";

	return $tableSelector;
}

function loadTableFieldData() {
	// inputs (variables that are read but not modified)
	global $connection, $table;

	// outputs (variables that are modified)
	global $columns, $numColumns;

	$results = mysql_query("show fields from $table", $connection);
	while ($row = mysql_fetch_row($results)) {
		$column = new Column();
		$column->name = $row[0];
		$column->type = $row[1];
		$column->isNullable = ($row[2] == 'YES');
		$column->isPartOfPrimaryKey = ($row[3] == 'PRI');
		$columns[$numColumns] = $column;
		$numColumns++;
	}
}

function getTotalNumRows($debug) {
	// inputs (variables that are read but not modified)
	global $connection, $table;

	// outputs (variables that are modified)
	global $totalNumRows;

	$whereClause = generateWhereClauseForSearch();
	$sql = "select count(1) from $table $whereClause";
	$results = mysql_query($sql, $connection);
	if ($row = mysql_fetch_row($results)) {
		$totalNumRows = $row[0];
	}

	if ($debug) {
		echo "$sql<br>";
	}
}

function loadTableData($debug) {
	// inputs (variables that are read but not modified)
	global $columns, $pageNum, $rowsPerPage, $connection, $table, $orderByColumn, $desc, $numColumns;

	// outputs (variables that are modified)
	global $data, $numRows;

	$columnListForDataQuery = '';
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$columnListForDataQuery .= $columns[$colNum]->name;
		if ($colNum < $numColumns - 1) {
			$columnListForDataQuery .= ", ";
		}
	}

	$whereClause = generateWhereClauseForSearch();
	$firstRowToGet = ($pageNum - 1) * $rowsPerPage;
	$descWord = $desc ? 'desc' : '';
	$sql = "select $columnListForDataQuery from $table $whereClause order by $orderByColumn $descWord limit $firstRowToGet, $rowsPerPage";

	if ($debug) {
		echo "$sql<br>";
	}

	$results = mysql_query($sql, $connection);
	$rowNum = 0;
	while ($dbRow = mysql_fetch_row($results)) {
		for ($colNum = 0; $colNum < $numColumns; $colNum++) {
			$cellId = makeCellId($rowNum, $colNum);
			$valueFromDb = $dbRow[$colNum];
			$data[$cellId] = $valueFromDb;
		}
		$rowNum++;
	}
	$numRows = $rowNum;
}

function generateWhereClauseForSearch() {
	// inputs (variables that are read but not modified)
	global $search, $numColumns, $columns;

	$clause = '';

	if ($search != '') {
		$isNumeric = is_numeric($search);
		$clause = 'where ';
		for ($colNum = 0; $colNum < $numColumns; $colNum++) {
			$column = $columns[$colNum];
			$columnName = $column->name;

			if ($column->hasNumericValue()) {
				if ($isNumeric) {
					$clause .= "$columnName = $search or ";
				}
			} else if ($column->hasStringValue() || ($column->hasDateTimeValue() && !containsAlphabeticCharacters($search))) {
				$clause .= "lower($columnName) like '%$search%' or ";
			}
		}
		$clause = removeFromEnd($clause, " or ");
	}

	return $clause;
}

function generateWhereClauseOnPrimaryKey($rowNum) {
	// inputs (variables that are read but not modified)
	global $numColumns, $columns, $data;

	$clause = "where ";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		if ($column->isPartOfPrimaryKey) {
			$cellId = makeCellId($rowNum, $colNum);
			$comparisonValue = $column->valueForInsertingOrUpdating($data[$cellId], false);
			$columnName = $column->name;
			$clause .= "$columnName = $comparisonValue and ";
		}
	}
	$clause = removeFromEnd($clause, " and ");

	return $clause;
}

function generateUrlArgsForPrimaryKey($rowNum) {
	// inputs (variables that are read but not modified)
	global $numColumns, $columns, $data;

	$args = "";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		if ($column->isPartOfPrimaryKey) {
			$cellId = makeCellId($rowNum, $colNum);
			$comparisonValue = $column->valueForInsertingOrUpdating($data[$cellId], false);
			$comparisonValue = urlencode($comparisonValue);
			$columnName = $column->name;
			$args .= "&pk_$columnName=$comparisonValue";
		}
	}

	return $args;
}

function handleZoomedRowUpdate($debug) {
	// inputs (variables that are read but not modified)
	global $connection, $table, $numColumns, $columns;

	// outputs (variables that are modified)
	global $numRowsUpdated, $errorMessages;

	$sql = "update $table set ";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$columnName = $column->name;
		$postedValue = $_REQUEST["field_$columnName"];
		$valueToSet = $column->valueForInsertingOrUpdating($postedValue, $column->isNullable);
		$sql .= "$columnName = $valueToSet, ";
	}
	$sql = removeFromEnd($sql, ", ");
	$sql .= " where ";
	foreach ($_REQUEST as $key => $value) {
		if (startsWith($key, 'pk_')) {
			$columnName = substr($key, 3);
			$sql .= "$columnName = $value and ";
		}
	}
	$sql = removeFromEnd($sql, " and ");

	if ($debug) {
		echo "$sql<br>";
	}

	if (mysql_query($sql, $connection)) {
		$numRowsUpdated++;
	} else {
		$errorMessages .= mysql_error() . '<br>';
	}
}

function generateUpdateCommand($rowNum) {
	// inputs (variables that are read but not modified)
	global $table, $numColumns, $data, $columns;

	$sql = "update $table set ";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$cellId = makeCellId($rowNum, $colNum);
		$valueInDb = $data[$cellId];
		$postedValue = $_POST[$cellId];
		if ($valueInDb != $postedValue) {
			$column = $columns[$colNum];
			$valueToSet = $column->valueForInsertingOrUpdating($postedValue, $column->isNullable);
			$columnName = $column->name;
			$sql .= "$columnName = $valueToSet, ";
		}
	}
	$sql = removeFromEnd($sql, ", ");
	$whereClause = generateWhereClauseOnPrimaryKey($rowNum);
	$sql .= " $whereClause";

	return $sql;
}

function handleUpdates($debug) {
	// inputs (variables that are read but not modified)
	global $numRows, $numColumns, $connection;

	// outputs (variables that are modified)
	global $numRowsUpdated, $data, $errorMessages;

	for ($rowNum = 0; $rowNum < $numRows; $rowNum++) {
		$changed = false;

		for ($colNum = 0; $colNum < $numColumns; $colNum++) {
			$cellId = makeCellId($rowNum, $colNum);
			$valueInDb = $data[$cellId];
			$postedValue = $_POST[$cellId];
			if ($valueInDb != $postedValue) {
				$changed = true;
				break;
			}
		}

		if ($changed) {
			$sql = generateUpdateCommand($rowNum);

			if ($debug) {
				echo "$sql<br>";
			}

			if (mysql_query($sql, $connection)) {
				$numRowsUpdated++;
			} else {
				$errorMessages .= mysql_error() . '<br>';
			}
		}
	}
}

function generateInsertCommand($rowNum) {
	// inputs (variables that are read but not modified)
	global $table, $numColumns, $columns;

	$sql = "insert into $table(";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$columnName = $columns[$colNum]->name;
		$sql .= "$columnName, ";
	}
	$sql = removeFromEnd($sql, ", ");
	$sql .= ") values(";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$cellId = makeCellId($rowNum, $colNum);
		$postedValue = $_POST[$cellId];
		$valueToInsert = $column->valueForInsertingOrUpdating($postedValue, $column->isNullable);
		$sql .= "$valueToInsert, ";
	}
	$sql = removeFromEnd($sql, ", ");
	$sql .= ")";

	return $sql;
}

function handleInserts($debug) {
	// inputs (variables that are read but not modified)
	global $numRows, $numColumns, $connection;

	// outputs (variables that are modified)
	global $numRowsInserted, $data, $errorMessages;

	// look for up to 1000 new rows.  too bad if the user entered more than 1000 new rows.
	for ($rowNum = $numRows; $rowNum < $initialNumRows + 1000; $rowNum++) {
		$haveSomeData = false;
		for ($colNum = 0; $colNum < $numColumns; $colNum++) {
			$cellId = makeCellId($rowNum, $colNum);
			$postedValue = $_POST[$cellId];
			if ($postedValue) {
				$haveSomeData = true;
				break;
			}
		}

		if ($haveSomeData) {
			$sql = generateInsertCommand($rowNum);

			if ($debug) {
				echo "$sql<br>";
			}

			if (mysql_query($sql, $connection)) {
				$numRowsInserted++;
			} else {
				$errorMessages .= mysql_error() . '<br>';
			}
		}
	}
}

function generateDeleteCommand($rowNum) {
	// inputs (variables that are read but not modified)
	global $table;

	$whereClause = generateWhereClauseOnPrimaryKey($rowNum);
	$sql = "delete from $table $whereClause";

	return $sql;
}

function handleDeletes($debug) {
	// inputs (variables that are read but not modified)
	global $numRows, $numColumns, $connection;

	// outputs (variables that are modified)
	global $numRowsDeleted, $errorMessages;

	for ($rowNum = 0; $rowNum < $numRows; $rowNum++) {
		if ($_POST["del$rowNum"]) {
			$sql = generateDeleteCommand($rowNum);

			if ($debug) {
				echo "$sql<br>";
			}

			if (mysql_query($sql, $connection)) {
				$numRowsDeleted++;
			} else {
				$errorMessages .= mysql_error() . '<br>';
			}
		}
	}
}

function getHighestPageNumber() {
	// inputs (variables that are read but not modified)
	global $totalNumRows, $rowsPerPage;

	return ceil($totalNumRows / $rowsPerPage);
}

function renderPageLinks() {
	// inputs (variables that are read but not modified)
	global $pageNum, $table, $orderByColumn, $desc, $rowsPerPage, $search;

	$spaces = "&nbsp; &nbsp; &nbsp;";

	$highestPageNum = getHighestPageNumber();

	$isFirstPageLinkActive = ($pageNum > 1);
	$isPrevPageLinkActive = ($pageNum > 1);
	$isNextPageLinkActive = ($pageNum < $highestPageNum);
	$isLastPageLinkActive = ($pageNum < $highestPageNum);

	$firstPageLink = makeLocalLink('<-- Page 1', $isFirstPageLinkActive, $table, $orderByColumn, $desc, 1, $rowsPerPage, $search);
	$prevPageLink = makeLocalLink('<-- Previous Page', $isPrevPageLinkActive, $table, $orderByColumn, $desc, max($pageNum - 1, 1), $rowsPerPage, $search);
	$nextPageLink = makeLocalLink('Next Page -->', $isNextPageLinkActive, $table, $orderByColumn, $desc, $pageNum + 1, $rowsPerPage, $search);
	$lastPageLink = makeLocalLink("Page $highestPageNum -->", $isLastPageLinkActive, $table, $orderByColumn, $desc, $highestPageNum, $rowsPerPage, $search);

	return "<span>$firstPageLink</span>$spaces<span>$prevPageLink</span>$spaces<span>$nextPageLink</span>$spaces<span>$lastPageLink</span>";
}

function renderRowsPerPageDropDown() {
	// inputs (variables that are read but not modified)
	global $rowsPerPage, $table, $orderByColumn, $search;

	return "<select onchange='location = this.options[this.selectedIndex].value;'>\n" .
		rowsPerPageOptionLine(10, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(20, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(50, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(100, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(200, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(500, $rowsPerPage, $table, $orderByColumn, $search) . 
		rowsPerPageOptionLine(1000, $rowsPerPage, $table, $orderByColumn, $search) . 
		"</select>\n";
}

function renderTopOfPageControls() {
	// inputs (variables that are read but not modified)
	global $table, $search;

	$tableSelector = generateTableSelector($table);

	$rowsPerPageDropDown = renderRowsPerPageDropDown();
	$pageLinks = renderPageLinks();

	$searchBar = "<input type='text' name='search' value='$search' style='width: 200px'> <input type='submit' value='Search'>";

	$baseUrl = $_SERVER['PHP_SELF'];
	$spaces = "&nbsp; &nbsp; &nbsp;";
	$hiddenFormFields = renderHiddenFormFields();
	return "<form action='$baseUrl?action=search' method='post'>\n$hiddenFormFields\n<span>Table: $tableSelector</span>$spaces $spaces $spaces<span>Rows per page: $rowsPerPageDropDown</span>$spaces $spaces $spaces$searchBar<p>$pageLinks\n</form>\n";
}

function renderButtons($i) {
	// inputs (variables that are read but not modified)
	$spaces = "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;";
	return "<input id='deleteButton$i' type='button' value='Delete selected rows' disabled='disabled' onclick='deleteRows()' />$spaces<input type='button' value='Add new row' onclick='addNewRow()' />$spaces<input type='submit' value='Save changes'>";
}

function canModify() {
	// inputs (variables that are read but not modified)
	global $numColumns, $columns;

	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		if ($columns[$colNum]->isPartOfPrimaryKey) {
			return true;
		}
	}

	return false;
}

function renderTable() {
	// inputs (variables that are read but not modified)
	global $numColumns, $numRows, $columns, $table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search, $data;

	$canModify = canModify();

	$html = "<table id='dataTable'>\n";

	// render the header row
	$html .= "<tr>";
	if ($canModify) {
		$html .= "<td>Zoom</td>";
		$html .= "<td>Delete</td>";
	}
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$columnName = $column->name;

		$isSortColumn = ($columnName == $orderByColumn);
		$setDesc = $isSortColumn && !$desc;
		$link = makeLocalLink($columnName, 1, $table, $columnName, $setDesc, $pageNum, $rowsPerPage, $search);

		$sortArrow = '';
		if ($isSortColumn) {
			$sortArrow = $desc ? ' &darr; ' : ' &uarr; ';
		}

		$renderedColumnType = $column->renderType();
		$html .= "<td>$sortArrow$link$sortArrow<br>$renderedColumnType</td>";
	}
	$html .= "</tr>\n";

	// render the table's data
	$baseUrl = $_SERVER['PHP_SELF'];
	for ($rowNum = 0; $rowNum < $numRows; $rowNum++) {
		$bgColor = ($rowNum % 2 == 1) ? '#CCCCCC' : '#DDDDDD';
		$bgStyle = "style='background-color: $bgColor;'";
		$zoomArgs = generateUrlArgsForPrimaryKey($rowNum) . '&' . makeLocalUrlArgs($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search);

		$html .= "<tr $bgStyle>";
		if ($canModify) {
			$html .= "<td align='center'><a href='$baseUrl?action=zoom&table=$table$zoomArgs'><img border=0 src='dwi-zoom.png'></a></td>";
			$html .= "<td align='center'><input type='checkbox' id='del$rowNum' name='del$rowNum' onclick='document.getElementById(\"deleteButton1\").disabled = false; document.getElementById(\"deleteButton2\").disabled = false' /></td>";
		}

		$disabled = $canModify ? "" : "disabled='disabled'";
		for ($colNum = 0; $colNum < $numColumns; $colNum++) {
			$column = $columns[$colNum];
			$cellId = makeCellId($rowNum, $colNum);
			$value = escapeSingleQuotes($data[$cellId]);

			if ($columns[$colNum]->isEnum()) {
	 			$inputField = "<select id='$cellId' name='$cellId'>\n" . $column->renderEnumDropDown($value) . "</select>";
			} else {
				$inputField = "<input type='text' $disabled value='$value' id='$cellId' name='$cellId' onfocus='focusedCell = \"$cellId\"' onblur='focusedCell = null' $bgStyle>";
			}

			$html .= "<td>$inputField</td>";
		}
		$html .= "</tr>\n";
	}

	$html .= "</table>\n";

	return $html;
}

function renderHiddenFormFields() {
	// inputs (variables that are read but not modified)
	global $table, $orderByColumn, $pageNum, $rowsPerPage, $search;

	$html = "<input type='hidden' name='table' value='$table'>\n";
	$html .= "<input type='hidden' name='sort' value='$orderByColumn'>\n";
	$html .= "<input type='hidden' name='page' value='$pageNum'>\n";
	$html .= "<input type='hidden' name='rowsPerPage' value='$rowsPerPage'>\n";
	$html .= "<input type='hidden' name='search' value='$search'>\n";

	return $html;
}

function renderForm() {
	// inputs (variables that are read but not modified)
	global $pageNum;

	$hiddenFormFields = renderHiddenFormFields();
	$buttons1 = renderButtons(1);
	$buttons2 = renderButtons(2);
	$highestPageNum = getHighestPageNumber();

	$baseUrl = $_SERVER['PHP_SELF'];
	$html = "<form action='$baseUrl' method='post'>\n$hiddenFormFields";
	$html .= "$buttons1<p>\n";
	$html .= "Page $pageNum of $highestPageNum<br>\n";
	$html .= renderTable();
	$html .= "<p>$buttons2</form>\n";

	return $html;
}

function getSingleRowWithPrimaryKeyFromRequestParameters($debug) {
	// inputs (variables that are read but not modified)
	global $connection, $numColumns, $columns, $table;

	$sql = "select ";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$sql .= $column->name;
		if ($colNum < $numColumns - 1) {
			$sql .= ', ';
		}
	}
	$sql .= " from $table where ";
	foreach ($_REQUEST as $key => $value) {
		if (startsWith($key, 'pk_')) {
			$columnName = substr($key, 3);
			$sql .= "$columnName = $value and ";
		}
	}
	$sql = removeFromEnd($sql, " and ");

	if ($debug) {
		echo "$sql<br>";
	}

	$results = mysql_query($sql, $connection);
	return mysql_fetch_row($results);
}

function generateZoomPage($debug) {
	// inputs (variables that are read but not modified)
	global $programName, $numColumns, $columns, $table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search;

	$lineLength = 75;
	
$javascript = <<<EOD
<script language="javascript" type="text/javascript">
function resize(textarea) {
	var numLines = Math.ceil(textarea.value.length / $lineLength);
	if (numLines > textarea.rows) {
		textarea.rows = numLines;
	}
}
</script>
EOD;

	$row = getSingleRowWithPrimaryKeyFromRequestParameters($debug);
	
	$baseUrl = $_SERVER['PHP_SELF'];

	$html = "<html>\n<head><title>$programName - $table</title>\n$javascript\n</head>\n";
	$html .= "<body>\n<form action='$baseUrl' method='post'>\n";
	$html .= "<input type='hidden' name='table' value='$table'>\n";
	$html .= "<input type='hidden' name='sort' value='$orderByColumn'>\n";
	$html .= "<input type='hidden' name='page' value='$pageNum'>\n";
	$html .= "<input type='hidden' name='rowsPerPage' value='$rowsPerPage'>\n";
	$html .= "<input type='hidden' name='search' value='$search'>\n";
	$html .= "<input type='hidden' name='action' value='submitZoomedRow'>\n";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		if ($column->isPartOfPrimaryKey) {
			$value = $row[$colNum];
			$columnName = $column->name;
			$html .= "<input type='hidden' name='pk_$columnName' value='$value'>\n";
		}
	}
	$html .= "<table>\n";

	$style = "style='width: 600px;'";
	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$columnName = $column->name;

		$fieldName = "field_$columnName";
		$value = $row[$colNum];
		$renderedValue = escapeSingleQuotes($value);
		$renderedColumnType = $column->renderType();

		$html .= "<tr><td>$columnName:<br>$renderedColumnType</td><td>";

		if ($column->isEnum()) {
	 		$html .= "<select id='$fieldName' name='$fieldName'>\n" . $column->renderEnumDropDown($value) . "</select>";
		} else if ($column->isLengthy()) {
			$numLines = ceil(strlen($value) / $lineLength) + 1;
			$html .= "\n<textarea name='$fieldName' rows='$numLines' $style onkeyup='resize(this);'>$renderedValue</textarea>\n";
		} else {
			$html .= "<input type='text' name='$fieldName' value='$renderedValue' $style />";
		}

		$html .= "</td></tr>\n";
	}

	$spaces = "&nbsp; &nbsp; &nbsp;";
	$cancelUrl = makeLocalUrl($table, $orderByColumn, $desc, $pageNum, $rowsPerPage, $search) . '&cancel=1';
	$html .= "</table><p>\n<input type='submit' value='Save changes'>$spaces<input type='submit' value='Cancel' onclick='window.location=\"$cancelUrl\"'></form>\n</body></html>\n";

	return $html;
}

function generateAddNewRowJavascript() {
	// inputs (variables that are read but not modified)
	global $numColumns, $columns;

	$js = <<<EOD
function addNewRow() {
	for (var rowNum = 0; rowNum < 99999; rowNum++) {
		var cellIdToFind = 'r' + rowNum + 'c0';
		if (!document.getElementById(cellIdToFind)) {
			break;
		}
	}

	var table = document.getElementById('dataTable');
	var tr = table.insertRow(rowNum + 1);

EOD;

	$initialColNum = 0;
	if (canModify()) {
		$js .= "\ttr.insertCell($initialColNum); // empty td for the magnifying glass column\n";
		$initialColNum++;

		$js .= "\ttr.insertCell($initialColNum); // empty td for the checkbox column\n";
		$initialColNum++;
	}

	for ($colNum = 0; $colNum < $numColumns; $colNum++) {
		$column = $columns[$colNum];
		$actualColNum = $colNum + $initialColNum;
		$js .= "\tvar td = tr.insertCell($actualColNum);\n";
		$js .= "\tvar cellId = 'r' + rowNum + 'c$colNum';\n";
		if ($column->isEnum()) {
			$js .= "\ttd.innerHTML = \"<select id='\" + cellId + \"' name='\" + cellId + \"'>" . $column->renderEnumDropDown('__DWI__SELECT__FIRST__') . "</select>\";\n";
		} else {
			$js .= "\ttd.innerHTML = \"<input type='text' id='\" + cellId + \"' name='\" + cellId + \"'></input>\";\n";
		}
	}
	$js .= "}\n";

	return $js;
}


// connect to the database
$connection = mysql_connect(DB_SERVER, DB_USER, DB_PASS) or die("Unable to connect to MySQL database \"" . DB_NAME . "\"");
mysql_select_db(DB_NAME, $connection) or die("Could not select database \"" . DB_NAME . "\" on\" \"" . DB_SERVER . "\"");

$programName = "DWI";

$tableList = getTableList(DB_NAME);

$action = $_REQUEST['action'];
$actionIsZoom = ($action == 'zoom');
$actionIsSearch = ($action == 'search');
$actionIsSubmitZoomedRow = ($action == 'submitZoomedRow') && !$_REQUEST['cancel'];

$table = $_REQUEST['table'];
if (($table == '') && !$actionIsZoom) {
	if (count($tableList) == 1) {
		// if no table specified and there is only 1 table, use it
		$table = $tableList[0];
	} else {
		// if no table specified, display table selector drop-down and exit
		$tableSelector = generateTableSelector(null);
		echo "<html>\n<head><title>$programName</title></head>\n";
		echo "<body>\nSelect a table to work on: $tableSelector<body></html>\n";
		mysql_close($connection);
		exit;
	}
}

// read in the table's column data
$numColumns = 0;
$columns = null;
loadTableFieldData();

$search = $_REQUEST['search'];

// determine the orderByColumn
$orderByColumn = $_REQUEST['sort'];
if ($orderByColumn == '') {
	$orderByColumn = $columns[0]->name;
}

// ascending/descending sort
$desc = ($_REQUEST['desc'] == '1') ? true : false;

// determine the page number
$pageNum = $_REQUEST['page'];
if (($pageNum == '') || ($pageNum < 1) || $actionIsSearch) {
	$pageNum = 1;
}

// determine the number of rows per page
$rowsPerPage = $_REQUEST['rowsPerPage'];
if (($rowsPerPage == '') || ($rowsPerPage < 10)) {
	$rowsPerPage = 10;
}

if ($actionIsZoom) {
	$html = generateZoomPage(DEBUG);
	echo $html;
	exit;
}

$errorMessages = '';
$numRowsDeleted = 0;
$numRowsUpdated = 0;
$numRowsInserted = 0;

if ($actionIsSubmitZoomedRow) {
	handleZoomedRowUpdate(DEBUG);
}

// get the total number of rows in the table
$totalNumRows = 0;
getTotalNumRows(DEBUG);

// fetch the table's data into $data
$numRows = 0;
$data = null;
loadTableData(DEBUG);

// handle updates, inserts and deletes
if (($_SERVER['REQUEST_METHOD'] == 'POST') && !$actionIsSearch && !$actionIsSubmitZoomedRow && !$actionIsCancelZoomedRow) {
	if ($_POST['deleteRows']) {
		handleDeletes(DEBUG);
	} else {
		handleUpdates(DEBUG);
		handleInserts(DEBUG);
	}

	$numRows = 0;
	$data = null;
	loadTableData(DEBUG);
}

$addNewRowJavascript = generateAddNewRowJavascript();

$baseUrl = $_SERVER['PHP_SELF'];
$javascript = <<<EOD
<script language="javascript" type="text/javascript">
$addNewRowJavascript

function deleteRows() {
	var form = document.createElement('form');
	form.setAttribute('method', 'post');
	form.setAttribute('action', '$baseUrl');

	var hiddenField = document.createElement('input');
	hiddenField.setAttribute('type', 'hidden');
	hiddenField.setAttribute('name', 'deleteRows');
	hiddenField.setAttribute('value', '1');
	form.appendChild(hiddenField);

	hiddenField = document.createElement('input');
	hiddenField.setAttribute('type', 'hidden');
	hiddenField.setAttribute('name', 'table');
	hiddenField.setAttribute('value', '$table');
	form.appendChild(hiddenField);

	hiddenField = document.createElement('input');
	hiddenField.setAttribute('type', 'hidden');
	hiddenField.setAttribute('name', 'sort');
	hiddenField.setAttribute('value', '$orderByColumn');
	form.appendChild(hiddenField);

	hiddenField = document.createElement('input');
	hiddenField.setAttribute('type', 'hidden');
	hiddenField.setAttribute('name', 'page');
	hiddenField.setAttribute('value', '$pageNum');
	form.appendChild(hiddenField);

	hiddenField = document.createElement('input');
	hiddenField.setAttribute('type', 'hidden');
	hiddenField.setAttribute('name', 'rowsPerPage');
	hiddenField.setAttribute('value', '$rowsPerPage');
	form.appendChild(hiddenField);

	for (var i = 0; i < $numRows; i++) {
		var id = 'del' + i;
		var checkbox = document.getElementById(id);
		if (checkbox && checkbox.checked) {
			hiddenField = document.createElement('input');
			hiddenField.setAttribute('type', 'hidden');
			hiddenField.setAttribute('name', id);
			hiddenField.setAttribute('value', '1');
			form.appendChild(hiddenField);
		}
	}

	document.body.appendChild(form);
	form.submit();
}

function clickHandler(e) {
	if (!focusedCell) {
		return;
	}

	var cPos = focusedCell.indexOf('c');
	var row = focusedCell.substring(1, cPos);
	var col = focusedCell.substring(cPos + 1);

	var KEY = { UP_ARROW: 38, DOWN_ARROW: 40 };
	
	var event = (e) ? e : window.event;
	switch (event.keyCode) {
		case KEY.UP_ARROW:
			row--;
			break;
		case KEY.DOWN_ARROW:
			row++;
			break;
	}

	var newCellId = 'r' + row + 'c' + col;
	var newCell = document.getElementById(newCellId);
	if (newCell) {
		newCell.focus();
	}
}

document.addEventListener('keydown', clickHandler, true);
</script>
EOD;

$html = "<html>\n<head><title>$programName - $table</title>\n$javascript\n</head>\n";

$html .= "<body>\n";

if ($numRowsDeleted) {
	$s = ($numRowsDeleted > 1) ? 's' : '';
	$html .= "<font color='green'>Deleted $numRowsDeleted row$s.</font><p>";
}
if ($numRowsUpdated) {
	$s = ($numRowsUpdated > 1) ? 's' : '';
	$html .= "<font color='green'>Updated $numRowsUpdated row$s.</font><p>";
}
if ($numRowsInserted) {
	$s = ($numRowsInserted > 1) ? 's' : '';
	$searchExplanation = ($search == '') ? '' : ' or because of the search filter';
	$html .= "<font color='green'>Inserted $numRowsInserted row$s.  The row$s might not be visible because of the way the rows are sorted$searchExplanation.</font><p>";
}

if ($errorMessages) {
	$html .= "<font color='red'>$errorMessages</font><p>";
}

$html .= renderTopOfPageControls();
$html .= "<p><hr style='color: lightgray;'><p>";
$html .= renderForm();

$html .= "\n</body>\n</html>\n";

echo $html;

mysql_close($connection);
?> 

