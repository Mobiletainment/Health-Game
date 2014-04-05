<?
include ("settings.php");

mysql_connect($loginURL,$username,$password);

mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

$regID = getField("regID");
$unityID = getField("deviceID");
$OS = getField("OS");
$username = getUsername();

if (empty($username))
{
	echo "Error: No username specified";
}
else
{

// Register user-regID in DB
// check if unity ID is already in the database. 
// If so, delete it and store it again (useful in situations where you may have different unityIDs linked to the same device
	$query="SELECT * FROM ECPN_table WHERE unityID = '$unityID'";

	$result=mysql_query($query);
	if(mysql_numrows($result) > 0) {
		$query="DELETE FROM ECPN_table WHERE unityID ='$unityID'";
		mysql_query($query);
	}
	
	$success = store_user($unityID,$regID,$OS, $username);

	echo $success;
}

function store_user($user,$regID,$OS, $username)
{
	//check if User already exists
	$query="SELECT * FROM ECPN_table WHERE username = '$username' AND isChild = TRUE";

	$result=mysql_query($query);

	if(mysql_numrows($result) > 0)
	{
		return "Error: Benutzername existiert bereits";
	}

	$query 		= "INSERT INTO ECPN_table (deviceID, unityID, os, username, isChild) VALUES ('$regID','$user','$OS', '$username', TRUE)";
	

	mysql_query($query);
	
	
	//if the child is registering, create a username for the parent, store the child<->parent relationship and return the parent's username
	
	$parentName = get_parent_name($username);
	$query = "INSERT INTO Child_Parent(child, parent) VALUES('$username', '$parentName')";
	mysql_query("$query");


	//also create an item table for the child where all the items are stored
	$query = "INSERT INTO Items(username) VALUES('$username')";
	mysql_query("$query");

	return "Success! Parent Teamname = " . $parentName;
	

	return "Success!";
}

mysql_close();
?>