<?php
include("settings.php");

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



function sendNotification($notifyUser, $never)
{
	$requestURL = "http://localhost/~aspace/SendPushNotificationToParent.php?action=CommunicationReminder";
	if ($never == true)
		$requestURL .= "Never";

	$requestURL .=	"&username=";
	
	echo PHP_EOL . "Request To User: " . $notifyUser . PHP_EOL;
	$ch = curl_init();

	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
	curl_setopt($ch, CURLOPT_POST, false);
	curl_setopt($ch, CURLOPT_URL, $requestURL . $notifyUser);
	curl_setopt($ch, CURLOPT_HEADER, false);
	curl_setopt ($ch, CURLOPT_RETURNTRANSFER, true);

	$contents = curl_exec ($ch);

	$status = curl_getinfo($ch, CURLINFO_HTTP_CODE);
	echo $status;

	if ($contents === FALSE) 
	{
		die('Curl failed: '.curl_error($ch));
	}

	curl_close ($ch);

	echo PHP_EOL . $contents;
	
}

$query = "SELECT * FROM ECPN_table WHERE isChild = 0";
$result = mysql_query($query);

if (mysql_numrows($result) > 0)
{
	while ($row = mysql_fetch_array($result))
	{
		$users[] = $row['username'];
	}


	foreach($users as $user) 
	{
		//1. check if new training is available and send push notification accordingly
		$query = "SELECT DATE FROM PushNotificationsToChild WHERE username = '$user' ORDER BY uid DESC LIMIT 1";
		$result=mysql_query($query);

		if(mysql_numrows($result) == 0)
		{
			echo "User never sent a notification: " . $user . PHP_EOL;
			sendNotification($user, true);
		}
		else
		{
			//check when the last message was sent
			$row = mysql_fetch_array($result);
			$timeStamp = strtoTime($row['DATE']);
			$dt = new DateTime($row['DATE']);
			$nextDay = date('Y-m-d', strtotime('+1 day', $timeStamp));
			$dueTo = new DateTime($nextDay);
			$current = new DateTime();
			$waitingTime = round($dueTo->format('U') - $current->format('U')); //the seconds the user has to wait
			echo "Waiting Time for user " . $user . ": " . $waitingTime;
			if($waitingTime <= 0)
			{
				echo "User to Notify: " . $user . PHP_EOL;
				sendNotification($user, false);
			}
	}
}

mysql_close();


}

$data = array(
	'returnCode' => $returnCode,
	'returnMessage' => "Successful: ".$action,
	'returnData' => $returnData,
	);

echo json_encode($data);
?>