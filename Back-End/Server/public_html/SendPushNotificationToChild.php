<?php
	include("settings.php");
	$user = $_GET['username'];
	$action = $_GET['action'];
	$message = $_GET['data'];
	$payload = $_GET['payload'];

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

	$debugInfo = "user: " . $user . ", message: " . $message . ", payload: " . $payload;
	$query = "";
	$parentName = get_parent_name($user);
	$query = "SELECT child AS target from Child_Parent WHERE parent = '$parentName'";
	$debugInfo = $debugInfo."\nQuery: ".$query;
	$result = mysql_query($query);
	if (mysql_numrows($result) == 0)
	{
		$returnCode = 412;
		$returnData = "Error: No Co-Player was found for user: " . $parentName;
	}
	else
	{
		while ($row = mysql_fetch_array($result))
		{
			$targets[] = $row['target'];
			$debugInfo .= "Target found " . $row['target'];
		}

		// For each deviceID, add to either android or iOS bucket
		if (count($targets) > 0)
		{
			foreach($targets as $contact)
			{
				$query = "SELECT * FROM ECPN_table WHERE username = '$contact' AND isChild = 1";
				$debugInfo = $debugInfo . "Query: " .$query;
				$result = mysql_query($query);
				
				if (mysql_numrows($result) > 0)
				{
					$os = mysql_result($result, 0, "os");
					$regId = mysql_result($result, 0, "deviceID");
					$user = mysql_result($result, 0, "username");
					
					$debugInfo .= "User: " . $user . ", OS: " . $os . ", regID:" . $regId;

					if ($os == "android") $androidIDs[] = $regId;
					else $iosIDs[] = $regId;
				}
			}
		

			// sending notifications to android and ios users (if any)
			if (count($androidIDs) > 0)
			{
				$debugInfo = $debugInfo . '\nSending Android Messages<br>';
				send_android_notification($androidIDs, $message);
			}
			else
			{
				$debugInfo .= '\nNo Android Messages to send<br>';
			}
			if (count($iosIDs) > 0)
			{
				$debugInfo .= '\nSending iOS Messages';
				send_ios_notification($iosIDs, $message);
			}
			else
			{
				$debugInfo .= 'No Android Messages to send<br>';
			}

			$debugInfo .= "Messages delivered: " .count($androidIDs) . " android / " .count($iosIDs) ." iOS";

			//log message to server
			$query = "INSERT INTO PushNotificationsToChild(username, action, message) VALUES('$user', '$action', '$message')";
			$debugInfo = $debugInfo . "Query: " .$query;
			$result = mysql_query($query);
			$debugInfo .= "Logged Push notification: " . $result;

			if ($action = "reward_ingame") //increase the childs item count for the specified item
			{
				$query = "UPDATE Items SET $payload = $payload + 1 WHERE username = '$user'";
				$debugInfo = $debugInfo . "Query: " .$query;
				$result = mysql_query($query);
				$debugInfo .= "Updated Item Count: " . $result;
			}

		}
		else
		{
			$debugInfo .= "No contacts found in DB -no messages sent";
			$returnCode = 404;
		}
	}


function send_android_notification($deviceIDs, $message)
{
	$debugInfo .= 'CURL INIT BEFORE';
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

function send_ios_notification($deviceIDs, $message)
{
	$ctx = stream_context_create();
	stream_context_set_option($ctx, 'ssl', 'local_cert', 'ck.pem');
	stream_context_set_option($ctx, 'ssl', 'passphrase', 'npc4gl3'); // Add your own ck.pem passphrase here

	foreach($deviceIDs as $deviceToken)
	{
		try
		{
			// Open a connection to the APNS server
			$fp = stream_socket_client(
				'ssl://gateway.sandbox.push.apple.com:2195', $err,
				$errstr, 60, STREAM_CLIENT_CONNECT | STREAM_CLIENT_PERSISTENT, $ctx);
	
			if (!$fp) exit("Failed to connect: $err $errstr".PHP_EOL);
			$debugInfo .= 'Connected to APNS'.PHP_EOL;
	
			// Create the payload body
			$body['aps'] = array(
				'alert' => $message,
				'badge' => 1,
				'sound' => 'default'
			);


			//send an item to the child
			if ($payload)
			{
				$body['payload'] = array(
				'item' => $payload
				);
			}
	
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