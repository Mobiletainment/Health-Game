<?php
include ("settings.php");

$connectionInfo = array( "Database"=>$database, "UID"=>$username, "PWD"=>$password);
$conn = sqlsrv_connect( $loginURL, $connectionInfo);

if( $conn ) {
     //echo "Connection established.";
}else{
     //echo "Connection could not be established.";
     //die( print_r( sqlsrv_errors(), true));
     die("9");
}

$regID = strip_tags($_POST["regID"]);

// Remove deviceID from DB
$query="SELECT * FROM $tablename WHERE deviceID='$regID'";
$params = array();
$options = array("Scrollable" => SQLSRV_CURSOR_KEYSET);
$result=sqlsrv_query($conn, $query, $params, $options);
if( $result === false) {
    die( print_r( sqlsrv_errors(), true) );
}
if(sqlsrv_num_rows($result) > 0) {
	$query="DELETE FROM $tablename WHERE deviceID='$regID'";
	$stmt = sqlsrv_query($conn, $query);
    if( $stmt === false ) {
     die( print_r( sqlsrv_errors(), true));
    }
}
echo "0";

sqlsrv_close( $conn );
?>