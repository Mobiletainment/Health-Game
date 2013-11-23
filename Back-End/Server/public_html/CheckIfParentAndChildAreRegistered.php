<?php
include("settings.php");

mysql_connect($loginURL,$username,$password);

@mysql_select_db($database) or die( "9");

$username = strip_tags($_POST["username"]);
$isChild = strtolower(strip_tags($_POST["isChild"]));


//check if they have already registered
$query="SELECT * FROM Child_Parent WHERE username = '$username'";
$result=mysql_query($query);

	if(mysql_numrows($result) == 0)
	{
		echo "No Registration so far.";
	}
	else if(mysql_numrows($result) == 1)
	{
		echo "Waiting for other player";
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