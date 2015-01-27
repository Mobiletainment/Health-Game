<?
header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json');

$user = $_GET['username'];
$action = $_GET['action'];
$returnCode = 200;
$debugInfo = "";

include ("settings.php");

mysql_connect($loginURL,$username,$password);
mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

if ($action == "LoadTimeout")
{
	$query="SELECT timeout FROM Training WHERE username = '$user'";
	$debugInfo = $query;
	$result=mysql_query($query);

	if(mysql_numrows($result) != 1)
	{
		$returnCode = 404;
		$returnData = "User " . $user . " does not exist";
	}
	else
	{
		$row = mysql_fetch_array($result);
		
		if (is_null($row['timeout']))
		{
			$returnCode = 404;
			$returnData = "No Timeout for " . $user . " specified";
		} 
		else
		{
			$returnData = $row['timeout'];
		}
	}
}
else if ($action == "SaveTimeout")
{
	$data = $_GET['data'];

	$query = "UPDATE Training SET timeout = '$data' WHERE username = '$user'";
	$debugInfo = $query;
	$result=mysql_query($query);

	$returnData = "Timeout " . $data . " for User " . $user . " saved";
}

$data = array(
		'returnCode' => $returnCode,
		'returnMessage' => "Successful: " . $action,
		'returnData' => $returnData,
		'debugInfo' => $debugInfo
		);

echo json_encode($data);


function getBoolFromField($field)
{
	return $field == 1 ? true : false;
}

?>