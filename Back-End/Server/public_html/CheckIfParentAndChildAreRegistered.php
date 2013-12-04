<?php
include("settings.php");

mysql_connect($loginURL,$username,$password);

@mysql_select_db($database) or die( "9");

$username = getUsername();
$isChild = strtolower(strip_tags($_POST["isChild"]));


//check if they have already registered
$query="SELECT * FROM ECPN_table WHERE username = '$username'";
$result=mysql_query($query);

	if(mysql_numrows($result) == 0)
	{
		echo "Error: No Registration so far. Try again in a few minutes.";
	}
	else if(mysql_numrows($result) == 1)
	{
		echo "Error: Waiting for other player";
	}
	else if (mysql_numrows($result) == 2)
	{
		echo "Success: Registration completed!";
	}
	else
	{
		echo "Error: Too much registrations exist for this user";
	}
mysql_close();

?>