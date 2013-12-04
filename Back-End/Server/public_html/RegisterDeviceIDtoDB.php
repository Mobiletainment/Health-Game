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
$unityID = getField("user");
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
	$isChild = strtolower(getField("isChild"));
	
	if ($isChild == "false") //registration request from the parent
	{
		//check if the child has already registered
		$query="SELECT * FROM Child_Parent WHERE child = '$username'";
		$result=mysql_query($query);

		if(mysql_numrows($result) == 0)
		{
			return "Error: You either have a spelling mistake with your username or your child hasn't registered yet. Please tell your child to register first and tell you your username";
		}
	}

    	if ($isChild == "true")
	{
		//check if User already exists
		$query="SELECT * FROM ECPN_table WHERE username = '$username'";
		$result=mysql_query($query);

		if(mysql_numrows($result) > 0)
		{
			return "Error: Username already exists";
		}
		
    		$query 		= "INSERT INTO ECPN_table (deviceID, unityID, os, username, isChild) VALUES ('$regID','$user','$OS', '$username', TRUE)";
	}
	else
	{
		$parentName = get_parent_name($username);
		$query 		= "INSERT INTO ECPN_table (deviceID, unityID, os, username, isChild) VALUES ('$regID','$user','$OS', '$parentName', FALSE)";
	}

	mysql_query($query);
	
	
	
	//if the child is registering, create a username for the parent, store the child<->parent relationship and return the parent's username
	if ($isChild == "true")
	{
		$parentName = get_parent_name($username);
		$query = "INSERT INTO Child_Parent(child, parent) VALUES('$username', '$parentName')";
		mysql_query("$query");
		return "Success! Parent Teamname = " . $parentName;
	}

	return "Success!";
}

mysql_close();
?>