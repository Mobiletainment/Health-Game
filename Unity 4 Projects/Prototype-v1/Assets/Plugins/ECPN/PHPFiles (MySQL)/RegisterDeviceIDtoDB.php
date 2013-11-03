<?
include ("settings.php");

mysql_connect($loginURL,$username,$password);
@mysql_select_db($database) or die( "9");

$regID = strip_tags($_POST["regID"]);
$unityID = strip_tags($_POST["user"]);
$OS = strip_tags($_POST["OS"]);

// Register user-regID in DB
// check if unity ID is already in the database. 
// If so, delete it and store it again (useful in situations where you may have different unityIDs linked to the same device
$query="SELECT * FROM ECPN_table WHERE unityID = '$unityID'";
$result=mysql_query($query);
if(mysql_numrows($result) > 0) {
	$query="DELETE FROM ECPN_table WHERE unityID ='$unityID'";
	mysql_query($query);
	store_user($unityID,$regID,$OS);
} else {
	store_user($unityID,$regID,$OS);
}
echo "0";

function store_user($user,$regID,$OS) {
    $query 		= "INSERT INTO ECPN_table (deviceID, unityID,os) VALUES ('$regID','$user','$OS')";
	mysql_query($query);
}

mysql_close();
?>