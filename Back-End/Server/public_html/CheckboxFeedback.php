<?php
include("settings.php");

mysql_connect($loginURL,$username,$password);

mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');

@mysql_select_db($database) or die( "9");

$username = getUsername();
$isChild = getField("isChild");
$deviceID = getField("deviceID");
$screenName = getField("screenName");
$customFeedback = getField("customFeedback");
$checkboxFeedback = getField("checkboxFeedback");
$totalCheckboxes = getField("totalCheckboxes");


echo "Screen: " . $screenName;
echo "\n" . $checkboxFeedback;

$checkboxes = "";
for ($i = 1; $i <= $totalCheckboxes; $i++)
{
	$checkboxes = $checkboxes . "cb" . $i . ",";
}

if (strlen($checkboxes) > 0)
{
	echo $checkboxes . "\n";
	$checkboxes = rtrim($checkboxes, ",");

	echo $checkboxes . "\n";

	$query= "INSERT INTO Checkbox_Feedback (deviceID, username, isChild, screenName, customFeedback, $checkboxes) VALUES('$deviceID', '$username', $isChild, '$screenName', '$customFeedback', $checkboxFeedback)";
}
else
{
	$query= "INSERT INTO Checkbox_Feedback (deviceID, username, isChild, screenName, customFeedback) VALUES('$deviceID', '$username', $isChild, '$screenName', '$customFeedback')";
}

echo $query . "\n";


$result=mysql_query($query);

//echo mysql_errno($query) . ": " . mysql_error($query) . "\n";


mysql_close();

?>