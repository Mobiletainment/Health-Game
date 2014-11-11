<?
// This is the url your database is located at.
// Consult webhost if you don't know it (should be of the form mysqlXXXXX.XXX:PORT)

$loginURL		= "127.0.0.1";
// Username with access to read / write database
$username		= "aspace";
// The password associated with $username

$password		= "mdb\$AspaceGame";
//the name of the database that contains your data

$database		= "aspace";
/*
 * Google API Key
 */
define("GOOGLE_API_KEY", "AIzaSyC8zLJhriExUCvJL1jZRfaCfHfB-4UAA4Q"); // Place your Google API Key
//define("GOOGLE_API_KEY_PARENT", "AIzaSyCtmr8pdT-naocMXPcfJPUf19Pc0frmJOI"); // Place your Google API Key
define("GOOGLE_API_KEY_PARENT", "AIzaSyDfmUWgl3dk87N33hA5_-S28rUGjEUK24w"); // Place your Google API Key

header("Access-Control-Allow-Origin: *");
header('Access-Control-Allow-Methods: GET, POST');
header('Content-Type: application/json');

function get_parent_name($username)
{
	return $username;
}

function getUsername()
{
	return base64_decode(strip_tags($_POST["username"]));
}

function getField($field)
{
	return base64_decode(strip_tags($_POST["$field"]));
}

?>