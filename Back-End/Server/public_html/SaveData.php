<?
header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json');

$user = $_GET['username'];
$action = $_GET['action'];
$data = json_decode($_GET['data']);
echo $data . PHP_EOL;
$returnCode = 200;

include ("settings.php");

mysql_connect($loginURL,$username,$password);
mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

if ($action == "GetProgress")
{
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
	}
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

	$query = "UPDATE Training SET $chapter=true WHERE username = '$user'";
	$result=mysql_query($query);

	$returnData = "Chapter " . $chapter . " saved";
}

$data = array(
		'returnCode' => $returnCode,
		'returnMessage' => "Successful: " . $action,
		'returnData' => $returnData
		);

echo json_encode($data);


function getBoolFromField($field)
{
	return $field == 1 ? true : false;
}

?>