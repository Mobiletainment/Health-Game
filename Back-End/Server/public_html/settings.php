<?
// This is the url your database is located at.
// Consult webhost if you don't know it (should be of the form mysqlXXXXX.XXX:PORT)

$loginURL		= "localhost:3306";
// Username with access to read / write database
$username		= "pertille_HealthG";
// The password associated with $username

$password		= ",yX3KP+Il5wk";
//the name of the database that contains your data

$database		= "pertille_aquaSpace";
/*
 * Google API Key
 */
define("GOOGLE_API_KEY", "AIzaSyC8zLJhriExUCvJL1jZRfaCfHfB-4UAA4Q"); // Place your Google API Key

function get_parent_name($username)
{
	return $username;
}

?>