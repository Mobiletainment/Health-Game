<?
header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json');

$user = $_GET['username'];
$action = $_GET['action'];
$date = $_GET['date'];
$returnCode = 200;
$returnData;
$query;
$returnMessage;
$result;
$debugInfo;
$waitingTime;
$dailyInputs = 0;

include ("settings.php");

mysql_connect($loginURL,$username,$password);
mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

$timestamp = strtotime("$date");

function loadProgress()
{
	global $user, $action, $returnCode, $returnData, $query, $returnMessage, $result, $debugInfo, $waitingTime, $dailyInputs, $timestamp;

	$query="SELECT t1, t2, t3, t4, t5, t6 FROM Training WHERE username = '$user'";
	$result=mysql_query($query);

	if(mysql_numrows($result) != 1)
	{
		$returnCode = 404;
		$returnData = "No User named " . $user . " found in DB. User created.";
		$query="INSERT INTO Training(username) VALUES('$user')";
		$result=mysql_query($query);
	}
	else
	{
		$row = mysql_fetch_array($result);
		$returnData = array(
			"t1" => getBoolFromField($row['t1']),
			"t2" => getBoolFromField($row['t2']),
			"t3" => getBoolFromField($row['t3']),
			"t4" => getBoolFromField($row['t4']),
			"t5" => getBoolFromField($row['t5']),
			"t6" => getBoolFromField($row['t6'])
			);

		$query = "SELECT DATE FROM Training_Timestamps WHERE username = '$user' AND action = 'C' ORDER BY uid DESC LIMIT 1";
		$result=mysql_query($query);
		$row = mysql_fetch_array($result);
		$timeStamp = strtoTime($row['DATE']);
		$dt = new DateTime($row['DATE']);
		$nextDay = date('Y-m-d', strtotime('+1 day', $timeStamp));
		$notBeforeMidnight = new DateTime($nextDay);
		$current = new DateTime();
		$waitingTime = round($notBeforeMidnight->format('U') - $current->format('U')); //the seconds the user has to wait
		$debugInfo .= "Timestamp: " . $timeStamp . "Current: " . $current->format('M j Y g:i A') . "; Not Before: " . $notBeforeMidnight->format('M j Y g:i A') . "; Original: " . $dt->format('M j Y g:i A') . "Wait: " . $waitingTime;
		
		//Update daily input progress
		$query = "SELECT dailyDuties, benchmark, selfControl from DailyInputs_Check WHERE username = '$user' AND date = DATE(FROM_UNIXTIME($timestamp))";
		$debugInfo .= "; Query: " . $query;
		$result=mysql_query($query);
		$row = mysql_fetch_array($result);

		$totalInputs = 0;
		$totalInputs += $row["dailyDuties"];
		$totalInputs += $row["benchmark"];
		$totalInputs += $row["selfControl"];

		$dailyInputs = array(
			'totalInputs' => $totalInputs,
			'dailyDuties' => $row["dailyDuties"],
			'benchmark'   => $row["benchmark"],
			'selfControl' => $row["selfControl"]			
			);
	}
}

if ($action == "GetProgress")
{
	loadProgress();
}
else if ($action == "SaveProgress")
{
	$chapter = $_GET['chapter'];

	$query="SELECT * FROM Training WHERE username = '$user'";
	$result=mysql_query($query);

	if(mysql_numrows($result) == 0)
	{
		$query="INSERT INTO Training(username) VALUES('$user')";
		$result=mysql_query($query);
	}
	
	//Log action to Training_Timestamps
	$row = mysql_fetch_array($result);

	if (getBoolFromField($row[$chapter]) == false) //user has completed a new training course
	{
		$query = "INSERT INTO Training_Timestamps(username, action) VALUES ('$user', 'C')";
		$result = mysql_query($query);
		$debugInfo .= "\nUser has completed a new training course";
	}
	else //user has re-completed a training course he/she has already done
	{
		$query = "INSERT INTO Training_Timestamps(username, action) VALUES ('$user', 'U')";
		$result = mysql_query($query);
		$debugInfo .= "\nuser has re-completed a training course";
	}

	$query = "UPDATE Training SET $chapter=true WHERE username = '$user'";
	$result=mysql_query($query);

	//$returnData .= "Chapter " . $chapter . " saved";
	loadProgress();
}

$data = array(
		'returnCode' => $returnCode,
		'returnMessage' => "Successful: " . $action,
		'returnData' => $returnData,
		'debugInfo' => $debugInfo,
		'waitingTime' => $waitingTime,
		'dailyInputs' => $dailyInputs
		);

echo json_encode($data);


function getBoolFromField($field)
{
	return $field == 1 ? true : false;
}

?>