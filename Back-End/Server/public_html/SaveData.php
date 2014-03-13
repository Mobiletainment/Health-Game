<?
header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json');

$user = $_GET['username'];
$action = $_GET['action'];
$data = $_GET['data'];

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

if ($action == "SavePersonData")
{
	$gender = $data["gender"];
	$mail = $data["mail"];
	$birthdate = $data["date"];

	
	$query= "INSERT INTO User_Info(username, gender, mail, birthdate) VALUES('$user', '$gender', '$mail', '$birthdate')";
	$debugInfo = $query;
	$result=mysql_query($query);
	
	$returnData = "Inserted " . $result . " rows";
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