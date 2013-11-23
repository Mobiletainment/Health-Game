<?
include ("settings.php");

mysql_connect($loginURL,$username,$password);
@mysql_select_db($database) or die( "9");

$regID = strip_tags($_POST["regID"]);

// Remove deviceID from DB
$query="SELECT * FROM ECPN_table WHERE deviceID = '$regID'";
$result=mysql_query($query);
if(mysql_numrows($result) > 0) {
	$query="DELETE FROM ECPN_table WHERE deviceID ='$regID'";
	mysql_query($query);
}

echo "0";

mysql_close();
?>