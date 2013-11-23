<?php
include("settings.php");

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
$unityID = strip_tags($_POST["user"]);
$OS = strip_tags($_POST["OS"]);

// Register user-regID in DB
// check if unity ID is already in the database. 
// If so, delete it and store it again (useful in situations where you may have different unityIDs linked to the same device
$query="SELECT * FROM $tablename WHERE unityID='$unityID'";
$params = array();
$options = array("Scrollable" => SQLSRV_CURSOR_KEYSET);
$result=sqlsrv_query($conn, $query, $params, $options);
if(sqlsrv_num_rows($result) > 0) {
	$query="DELETE FROM $tablename WHERE unityID='$unityID'";
	$stmt = sqlsrv_query($conn, $query);
    if( $stmt === false ) {
     die( print_r( sqlsrv_errors(), true));
    }

	store_user($conn,$tablename,$unityID,$regID,$OS);
} else {
	store_user($conn,$tablename,$unityID,$regID,$OS);
}
echo "0";

function store_user($connection,$table,$user,$regID,$OS) {
    $query = "INSERT INTO $table (deviceID,unityID,os) VALUES ('$regID','$user','$OS')";
	$stmt = sqlsrv_query($connection, $query);
    
    if( $stmt === false ) {
     die( print_r( sqlsrv_errors(), true));
    }
}

sqlsrv_close( $conn );
?>