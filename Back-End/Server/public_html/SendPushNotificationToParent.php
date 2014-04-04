<?php
include("settings.php");
$user = $_GET['username'];
$action = $_GET['action'];
$message ="";
$hash = "";

$returnCode = 200;
$debugInfo = "";
$returnData = "";

mysql_connect($loginURL, $username, $password);
mysql_query('SET character_set_results=utf8');
mysql_query('SET names=utf8');
mysql_query('SET character_set_client=utf8');
mysql_query('SET character_set_connection=utf8');
mysql_query('SET character_set_results=utf8');
mysql_query('SET collation_connection=utf8_general_ci');
@mysql_select_db($database) or die("9");

$androidIDs = array();
$iosIDs = array();

$debugInfo .= "SendPushNotificationToParent.php";

// For each deviceID, add to either android or iOS bucket
$query = "SELECT * FROM ECPN_table WHERE username = '$user' AND isChild = 0";
$debugInfo = $debugInfo . "Query: " .$query;
$result = mysql_query($query);

if (mysql_numrows($result) > 0)
{
	$os = mysql_result($result, 0, "os");
	$regId = mysql_result($result, 0, "deviceID");
	$user = mysql_result($result, 0, "username");

	if ($os == "android") $androidIDs[] = $regId;
	else $iosIDs[] = $regId;
}

$debugInfo .= "Before payload";
setPayload($action);
$debugInfo .= "After payload";

			// sending notifications to android and ios users (if any)
if (count($androidIDs) > 0)
{
	$debugInfo = $debugInfo . '\nSending Android Messages<br>';
	send_android_notification($androidIDs);
}
else
{
	$debugInfo .= '\nNo Android Messages to send<br>';
}
if (count($iosIDs) > 0)
{
	$debugInfo .= '\nSending iOS Messages';
	send_ios_notification($iosIDs);
}
else
{
	$debugInfo .= 'No Android Messages to send<br>';
}

$debugInfo .= "Messages delivered: " .count($androidIDs) . " android / " .count($iosIDs) ." iOS";



function send_android_notification($deviceIDs)
{
	$debugInfo .= 'CURL INIT BEFORE';
	$message = "TODO";
	$message = array("price" => $message);
	// Set POST variables
	$url = 'https://android.googleapis.com/gcm/send';
	$fields = array(
		'registration_ids' => $deviceIDs,
		'data' => $message,
		);
	$headers = array(
		'Authorization: key='.GOOGLE_API_KEY,
		'Content-Type: application/json'
		);
	// Open connection

	$debugInfo .= 'CURL BEFORE TRY';
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
		
		$debugInfo .= 'Before executing';
		// Execute post
		$result = curl_exec($ch);
		if ($result === FALSE) 
		{
			die('Curl failed: '.curl_error($ch));
		}

		$returnMessage = $result;
		// Close connection
		curl_close($ch);
	}
	catch (Exception $e)
	{
		$strResponse = "";
		$strErrorCode = $e -> getCode();
		$strErrorMessage = $e -> getMessage();
		print_r($arrCurlInfo, $strErrorCode, $strErrorMessage);
		die;
	}  //end catch
}

function setPayload($action)
{
	global $debugInfo, $message, $hash;
	$debugInfo .= "Setting Payload for ";
	if ($action == "TrainingReminder")
	{
		
		$message = "Es ist eine neue Trainingseinheit verfügbar";
		$hash = "#training";
	}
}

function send_ios_notification($deviceIDs)
{
	global $debugInfo, $action, $message, $hash;
	
	

	

	$debugInfo .= "send_ios_notification with message: " . $message;
	$ctx = stream_context_create();
	stream_context_set_option($ctx, 'ssl', 'local_cert', 'cp.pem');
	stream_context_set_option($ctx, 'ssl', 'passphrase', 'npc4gl3'); // Add your own ck.pem passphrase here

	foreach($deviceIDs as $deviceToken)
	{
		$debugInfo .= "DeviceToken: " . $deviceToken;
		try
		{
			// Open a connection to the APNS server
			$fp = stream_socket_client(
				'ssl://gateway.sandbox.push.apple.com:2195', $err,
				$errstr, 60, STREAM_CLIENT_CONNECT | STREAM_CLIENT_PERSISTENT, $ctx);

			if (!$fp)
			{
			$debugInfo .= "Failed to connect!";
			 exit("Failed to connect: $err $errstr".PHP_EOL);
			}

			$debugInfo .= 'Connected to APNS'.PHP_EOL;

			// Create the payload body
			$body['aps'] = array(
				'alert' => $message,
				'badge' => 1,
				'sound' => 'default'
				);

			$body['payload'] = array(
				'hash' => $hash
				);

			$payload = json_encode($body);
			
			$debugInfo .= "\nPayload: ".$payload;
			// Build & send notification
			$msg = chr(0).pack('n', 32);
			$msg = $msg.pack('H*', trim($deviceToken));
			$msg = $msg.pack('n', strlen($payload));
			$msg = $msg.$payload;

			$result = fwrite($fp, $msg, strlen($msg));
			
			if (!$result)
				$debugInfo .= 'Message not delivered'.PHP_EOL;
			else
				$debugInfo .= 'Message successfully delivered'.PHP_EOL;
		}
		catch (Exception $e)
		{
			$strResponse = "";
			$strErrorCode = $e -> getCode();
			$strErrorMessage = $e -> getMessage();
			print_r($arrCurlInfo, $strErrorCode, $strErrorMessage);
			die;
		}  //end catch
	}
	
	// Close the connection to the server
	fclose($fp);
}

mysql_close();

$data = array(
	'returnCode' => $returnCode,
	'returnMessage' => "Successful: ".$action,
	'returnData' => $returnData,
	'debugInfo' => $debugInfo
	);

echo json_encode($data);
?>