<?
header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json; charset=UTF-8');

$user = $_GET['username'];
$action = $_GET['action'];
$data = $_GET['data'];
$date = $_GET['date'];

$returnCode = 200;
$debugInfo = "";
$extraInfo = "";

include ("settings.php");

mysql_connect($loginURL,$username,$password);
mysql_query('SET names=utf8');
mysql_query('SET character_set_results=utf8');

mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");


function decodeParam($wert)
{
	$wert = str_replace("\u00fc","�",$wert);
$wert = str_replace("\u00e4","�",$wert);
$wert = str_replace("\u00f6","�",$wert);
$wert = str_replace("\u00dc","�",$wert);
$wert = str_replace("\u00d6","�",$wert);
$wert = str_replace("\u00c4","�",$wert);
$wert = str_replace("\u00df","�",$wert);
return $wert;
}

if ($action == "SavePersonData")
{
	$gender = $data["gender"];
	$mail = $data["mail"];
	$birthdate = $data["date"];

	
	$query= "INSERT INTO User_Info(username, gender, mail, birthdate) VALUES('$user', '$gender', '$mail', '$birthdate')";
	$debugInfo .= $query;
	$result=mysql_query($query);
	
	$returnData = "Inserted " . $result . " rows";
}
else if ($action == "SaveBehaviorData")
{
	$query = "INSERT INTO Behavior_Feedback(username, behavior1, rating1, behavior2, rating2, behavior3, rating3) VALUES('$user', ";
	$custom = "";

	foreach($data as $key => $value)
	{
		$custom .= "'$key', '$value', "; 
	}

	$custom = substr($custom, 0, -2);
	$query .= $custom . ")";
	$debugInfo .= $query;
	$result=mysql_query($query);
	
	$returnData = "Inserted " . $result . " rows";

}
else if ($action == "SaveDailyTasksData")
{
	$length = count($data);
	$debugInfo .= "Length: " . $length;
	
	$fields = "";
	$values = "";	

	$i = 1;
	foreach($data as $item)
	{
		$fields .= "item" . $i . ",";
		$values .= "'" . $item . "',";
		$i++;
	}

	$fields = rtrim($fields, ",");
	$values = rtrim($values, ",");


	$debugInfo .= "Fields: " . $fields;
	$debugInfo .= "Values: " . $values;
	$query= "INSERT INTO Tasks_Data (username, $fields) VALUES('$user', $values)";
	$debugInfo .= $query;
	$result=mysql_query($query);
	$returnData = "Inserted " . $result . " rows";

}
else if ($action == "SaveInputTasksData")
{
	$length = count($data);
	$debugInfo .= "Length: " . $length;
	
	$fields = "";
	$values = "";	

	$i = 1;


	foreach($data as $key => $value)
	{
		$fields .= "item" . $i . ", rating" . $i . ",";
		$values .= "'" . $key . "', '" . $value . "',";
		$i++;
	}

	$fields = rtrim($fields, ",");
	$values = rtrim($values, ",");


	$debugInfo .= "Fields: " . $fields;
	$debugInfo .= "Values: " . $values;
	$query= "INSERT INTO Tasks_Feedback (username, $fields) VALUES('$user', $values)";
	$debugInfo .= $query;
	$result=mysql_query($query);
	$returnData = "Inserted " . $result . " rows";

	handleDailyInputsCheck("dailyDuties");
	
}

else if ($action == "LoadDailyTasksData")
{
	$query="SELECT item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, DATE FROM Tasks_Data WHERE username = '$user' ORDER BY DATE DESC LIMIT 1";
	$debugInfo .= $query;
	$result=mysql_query($query);

	if(mysql_numrows($result) != 1)
	{
		$returnCode = 404;
		$returnData = "No fitting Record for " . $user . " found in DB";
	}
	else
	{
		$row = mysql_fetch_array($result);
		$returnData = array(
			"1" => $row['item1'],
			"2" => $row['item2'],
			"3" => $row['item3'],
			"4" => $row['item4'],
			"5" => $row['item5'],
			"6" => $row['item6'],
			"7" => $row['item7'],
			"8" => $row['item8'],
			"9" => $row['item9'],
			"10" => $row['item10']
			);
	}
}
else if ($action == "SaveInputBenchmarkData")
{
	$query= "INSERT INTO Benchmark_Feedback(username, rating) VALUES('$user', '$data')";
	$debugInfo .= $query;
	$result=mysql_query($query);
	
	$returnData = "Inserted " . $result . " rows";
	handleDailyInputsCheck("benchmark");
}

else if ($action == "SaveSelfControlData")
{
	$near = $data["near"];
	$immaterial = $data["immaterial"];
	$material = $data["material"];
	$ignoring = $data["ignoring"];
	$timeout = $data["timeout"];
	
	$query= "INSERT INTO SelfControl_Feedback(username, near, immaterial, material, ignoring, timeout) VALUES('$user', '$near', '$immaterial', '$material', '$ignoring', '$timeout')";
	$debugInfo .= $query;
	$result=mysql_query($query);
	
	$returnData = "Inserted " . $result . " rows";
	handleDailyInputsCheck("selfControl");
}

else
{
	$returnCode = 404;
}

$data = array(
		'returnCode' => $returnCode,
		'returnMessage' => "Successful: " . $action,
		'returnData' => $returnData,
		'debugInfo' => $debugInfo,
		'extraInfo' => $extraInfo
		);

echo json_encode($data);

function handleDailyInputsCheck($field)
{
	global $debugInfo, $user, $date, $extraInfo;
	$debugInfo .= "Handling DailyInputs_Check for field: " . $field;
	$timestamp = strtotime("$date");

	//check if a new record must be inserted or if it has to be updated
	$query = "SELECT * from DailyInputs_Check where username = '$user' AND date = DATE(FROM_UNIXTIME($timestamp))";
	$debugInfo .= "; Query: " . $query;
	$result=mysql_query($query);
	$debugInfo .= "Found " . mysql_numrows($result) . " entries in DailyInputs_Check";
	

	if(mysql_numrows($result) == 0)
	{
		$debugInfo .= "No record for today's Daily Inputs exists. Inserting.";
		$query = "INSERT INTO DailyInputs_Check (DATE, username, $field) VALUES (FROM_UNIXTIME($timestamp), '$user', 1)";
		$debugInfo .= "; Query: " . $query;
		$result=mysql_query($query);
		$debugInfo .= "Inserted " . $result . " rows into DailyInputs_Check";
	}
	else
	{
		//record can be updated
		$debugInfo .= "Updating record for today's Daily Inputs.";
		

		$query = "UPDATE DailyInputs_Check SET $field = 1 WHERE username = '$user' AND date = DATE(FROM_UNIXTIME($timestamp))";
		$debugInfo .= "; Query: " . $query;
		$result=mysql_query($query);
		$debugInfo .= "Updated " . $result . " rows in DailyInputs_Check";
	}

	$query = "UPDATE User_Info SET badges = badges+1 WHERE username = '$user'";
	$debugInfo .= "; Query: " . $query;
	$result=mysql_query($query);
	$debugInfo .= "Updated " . $result . " rows in User_info";

	$query = "SELECT * from User_Info WHERE username = '$user'";
	$result=mysql_query($query);
	$debugInfo .= "Selected " . $result . " rows in User_info";
	if(mysql_numrows($result) >= 1)
	{
		$row = mysql_fetch_array($result);
		$debugInfo .= "User has badges " . $row['badges'];
		if (!is_null($row['badges']))
		{
			$extraInfo = $row['badges'];
			$debugInfo .= "Badges " . $extraInfo . " in User_info";
		}
	}
}

function getBoolFromField($field)
{
	return $field == 1 ? true : false;
}

?>