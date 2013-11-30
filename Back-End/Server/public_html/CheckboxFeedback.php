<?php
include("settings.php");

mysql_connect($loginURL,$username,$password);

@mysql_select_db($database) or die( "9");

$username = strip_tags($_POST["username"]);
$isChild = strtolower(strip_tags($_POST["isChild"]));
$deviceID = strip_tags($_POST["deviceID"]);
$screenName = strip_tags($_POST["screenName"]);
$customFeedback = strip_tags($_POST["customFeedback"]);
$checkboxFeedback = strip_tags($_POST["checkboxFeedback"]);
$totalCheckboxes = strip_tags($_POST["totalCheckboxes"]);

$checkboxes = "";
for ($i = 1; $i <= $totalCheckboxes; $i++)
{
	$checkboxes = $checkboxes . "cb" . $i . ",";
}

rtrim($checkboxes, ",");


//check if they have already registered
$query="INSERT INTO Checkbox_Feedback (deviceID, username, isChild, screenName, customFeedback, '$checkboxes' VALUES('$deviceID', '$username', '$isChild', '$screenName', '$customFeedback', '$checkboxFeedback')";
$result=mysql_query($query);

echo $result;

mysql_close();

?>