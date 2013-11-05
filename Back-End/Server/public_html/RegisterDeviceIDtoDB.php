<?
include ("settings.php");

mysql_connect($loginURL,$username,$password);

@mysql_select_db($database) or die( "9");

$regID = strip_tags($_POST["regID"]);
$unityID = strip_tags($_POST["user"]);
$OS = strip_tags($_POST["OS"]);
$username = strip_tags($_POST["username"]);

// Register user-regID in DB
// check if unity ID is already in the database. 
// If so, delete it and store it again (useful in situations where you may have different unityIDs linked to the same device
$query="SELECT * FROM ECPN_table WHERE unityID = '$unityID'";

$result=mysql_query($query);
if(mysql_numrows($result) > 0) {
	$query="DELETE FROM ECPN_table WHERE unityID ='$unityID'";
	mysql_query($query);
	store_user($unityID,$regID,$OS, $username);
} else {
	store_user($unityID,$regID,$OS, $username);
}
echo "0";

function store_user($user,$regID,$OS, $username) {
    $query 		= "INSERT INTO ECPN_table (deviceID, unityID, os, username) VALUES ('$regID','$user','$OS', '$username')";

	mysql_query($query);
}

mysql_close();
?>