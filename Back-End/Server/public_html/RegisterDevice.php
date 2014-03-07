<?
include ("settings.php");

$user = $_GET['user'];
$action = $_GET['action'];

$returnCode = 200;
$debugInfo = "";
$returnData = "";


mysql_connect($loginURL,$username,$password);

mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

$regID = $_GET['data'];
$OS = $_GET['os'];


if (empty($user))
{
	$returnMessage = "Error: No username specified";
	$returnCode = 404;
}
else if (empty($OS))
{
	$returnMessage = "Error: No Operating System specified";
	$returnCode = 404;
}
else
{
	// Register user-regID in DB
	// check if user is already in the database. 
	// If so, delete it and store it again (useful in situations where you may have different unityIDs linked to the same device
	$query= "SELECT * FROM ECPN_table WHERE username = '$user' AND isChild = 0";
	$debugInfo .= "\n" . $query;
	$result=mysql_query($query);
	
	if(mysql_numrows($result) > 0)
	{
		$debugInfo .= "User already exists, deleting " . $user;
		$query= "DELETE FROM ECPN_table WHERE username ='$user' AND isChild = 0";
		mysql_query($query);
	}

	$debugInfo .= "\nTrying to store User";
	//registration request from the parent
	
	//check if the child has already registered
	$query="SELECT * FROM ECPN_table WHERE username = '$user' AND isChild = 1";
	
	$result=mysql_query($query);

	if(mysql_numrows($result) == 0)
	{
		$debugInfo .= "\n No child found";
		$returnCode = 401;
		$returnMessage = "Error: You either have a spelling mistake with your username or your child hasn't registered yet. Please tell your child to register first and tell you your username";
	}
	else
	{
		$parentName = get_parent_name($user);
		$query 		= "INSERT INTO ECPN_table (deviceID, os, username, isChild) VALUES ('$regID','$OS', '$parentName', 0)";
	
		mysql_query($query);
	
		$returnMessage = "Successfully registered user";
	}
}

mysql_close();

$data = array(
	'returnCode' => $returnCode,
	'returnMessage' => $returnMessage,
	'debugInfo' => $debugInfo
	);

echo json_encode($data);

?>