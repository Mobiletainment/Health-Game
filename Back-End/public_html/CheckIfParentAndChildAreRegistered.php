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
		echo "Error: Ihr Kind muss sich zuerst bei FLINS (Spiel) anmelden und Ihnen den Benutzernamen mitteilen.";
	}
	else if(mysql_numrows($result) == 1)
	{
		echo "Error: Deine Eltern haben sich noch nicht in der FLINS Companion App angemeldet. Teile ihnen jetzt deinen Benutzernamen mit um starten zu können!";
	}
	else if (mysql_numrows($result) == 2)
	{
		echo "Success: Registrierung erfolgreich!";
	}
	else
	{
		echo "Error: Too much registrations exist for this user";
	}
mysql_close();

?>