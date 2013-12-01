<?php
include("settings.php");

mysql_connect($loginURL,$username,$password);

@mysql_select_db($database) or die( "9");

//$message = strip_tags($_POST["username"]) . " says hi to ";
$message = strip_tags($_POST["message"]);
$androidIDs = array();
$iosIDs = array();
$username = strip_tags($_POST["username"]);
$isChild = strtolower(strip_tags($_POST["isChild"]));

$query= "";


if ($isChild == "true")
{
	$query = "SELECT parent AS target FROM Child_Parent WHERE child = '$username'";
}
else
{
	$parentName = get_parent_name($username);
	$query = "SELECT child AS target from Child_Parent WHERE parent = '$parentName'";
}
$result=mysql_query($query);


echo $message;

if(mysql_numrows($result) == 0)
{
	echo "Error: No Co-Player was found";
}

while($row = mysql_fetch_array($result)) {
   $targets[] = $row['target'];
	echo $row['target'];
}

// For each deviceID, add to either android or iOS bucket
if(count($targets) > 0)
{
	foreach($targets as $contact) {
		$query="SELECT * FROM ECPN_table WHERE username = '$contact'";

		$result=mysql_query($query);

		echo $message;

		if(mysql_numrows($result) > 0) {
			$os = mysql_result($result,0,"os");
			$regId = mysql_result($result,0,"deviceID");
			$username = mysql_result($result,0,"username");
			if($os == "android") $androidIDs[] = $regId;
			else $iosIDs[] = $regId;
		}
	}
	
	echo '<br>Script Running...<br>';
	
	
	// sending notifications to android and ios users (if any)
	if(count($androidIDs) > 0)
	{
		echo 'Sending Android Messages<br>';
		send_android_notification($androidIDs,$message);
	}
	else
	{
		 echo 'No Android Messages to send<br>';
	}
	if(count($iosIDs) > 0)
	{
		echo 'Sending iOS Messages';
		send_ios_notification($iosIDs,$message);
	}
	else
	{
		echo 'No Android Messages to send<br>';
	}
	
	echo "Messages delivered: " . count($androidIDs) . " android / " . count($iosIDs) . " iOS";
} else {
	echo "No contacts found in DB -no messages sent";
}


function send_android_notification($deviceIDs,$message) {
 	echo 'CURL INIT BEFORE';
 	
	$message = array("price" => $message);
    
    
    // Set POST variables
    $url = 'https://android.googleapis.com/gcm/send';
 	
 	
 	
    $fields = array(
        'registration_ids' => $deviceIDs,
        'data' => $message,
    );
 	
    $headers = array(
        'Authorization: key=' . GOOGLE_API_KEY,
        'Content-Type: application/json'
    );
    // Open connection
    
	echo 'CURL BEFORE TRY';
    try
    {
    $ch = curl_init();

	
    // Set the url, number of POST vars, POST data
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_POST, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
 
    // Disabling SSL Certificate support temporarly
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($fields));
 
	echo 'Before executing';

    // Execute post
    $result = curl_exec($ch);
    if ($result === FALSE) {
        die('Curl failed: ' . curl_error($ch));
    }
    echo $result;
 
    // Close connection
    curl_close($ch);
    
    }
    catch( Exception $e)
    {
        $strResponse = "";
        $strErrorCode = $e->getCode();
        $strErrorMessage = $e->getMessage();
        print_r($arrCurlInfo, $strErrorCode, $strErrorMessage);
        die;
    }  //end catch
}

function send_ios_notification($deviceIDs,$message) {
	$ctx = stream_context_create();
	stream_context_set_option($ctx, 'ssl', 'local_cert', 'ck.pem');
	stream_context_set_option($ctx, 'ssl', 'passphrase', 'npc4gl3'); // Add your own ck.pem passphrase here
	
	foreach($deviceIDs as $deviceToken) {
		try
    	{
		// Open a connection to the APNS server
		$fp = stream_socket_client(
			'ssl://gateway.sandbox.push.apple.com:2195', $err,
			$errstr, 60, STREAM_CLIENT_CONNECT|STREAM_CLIENT_PERSISTENT, $ctx);
		if (!$fp) exit("Failed to connect: $err $errstr" . PHP_EOL);
		
		echo 'Connected to APNS' . PHP_EOL;
		
		// Create the payload body
		$body['aps'] = array(
			'alert' => $message,
			'sound' => 'default'
			);
		$payload = json_encode($body);
		
		// Build & send notification
		$msg = chr(0) . pack('n', 32) . pack('H*', $deviceToken) . pack('n', strlen($payload)) . $payload;
		$result = fwrite($fp, $msg, strlen($msg));
		
		if (!$result)
			echo 'Message not delivered' . PHP_EOL;
		else
			echo 'Message successfully delivered' . PHP_EOL;
		}	
    	catch( Exception $e)
    	{
        	$strResponse = "";
        	$strErrorCode = $e->getCode();
        	$strErrorMessage = $e->getMessage();
        	print_r($arrCurlInfo, $strErrorCode, $strErrorMessage);
        	die;
    	}  //end catch
	}	
	// Close the connection to the server
	fclose($fp);
}

mysql_close();