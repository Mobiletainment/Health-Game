<?php
	include("settings.php");
	$user = getUsername();
	$action = getField("action");
	

	$returnCode = 200;
	$GIFT_ENERGY_BOOST = 0;
	$GIFT_RESURRECTION = 0;
	$GIFT_SLOW_MOTION = 0;
	$GIFT_FREE_SIGHT = 0;
	$returnData = "OK";

	mysql_connect($loginURL, $username, $password);
	mysql_query('SET character_set_results=utf8');
	mysql_query('SET names=utf8');
	mysql_query('SET character_set_client=utf8');
	mysql_query('SET character_set_connection=utf8');
	mysql_query('SET character_set_results=utf8');
	mysql_query('SET collation_connection=utf8_general_ci');
	mysql_select_db($database) or die("9");

	if ($action == "GET")
	{
		$query = "SELECT salad, life, snail, sight FROM Items WHERE username = '$user' ORDER BY uid DESC LIMIT 1;";
		$debugInfo = $debugInfo."\nQuery: ".$query;
		$result = mysql_query($query);


		if (mysql_numrows($result) == 0)
		{
			$returnCode = 413;
			$returnData = "Error: No In-Game Items found for user: " . $user;
		}
		else
		{
			$row = mysql_fetch_row($result);
			$GIFT_ENERGY_BOOST = $row[0];
			$GIFT_RESURRECTION = $row[1];
			$GIFT_SLOW_MOTION = $row[2];
			$GIFT_FREE_SIGHT = $row[3];
			$data = array(
			'GIFT_ENERGY_BOOST' => $GIFT_ENERGY_BOOST,
			'GIFT_RESURRECTION' => $GIFT_RESURRECTION,
			'GIFT_SLOW_MOTION' => $GIFT_SLOW_MOTION,
			'GIFT_FREE_SIGHT' => $GIFT_FREE_SIGHT,
			'RETURN_DATA' => $returnData
			);

			echo json_encode($data);
		}
	}
	else if ($action == "DELETE")
	{
		$query = "UPDATE Items SET salad = 0, life = 0, snail = 0, sight = 0 WHERE username = '$user'";
		$debugInfo = $debugInfo."\nQuery: ".$query;
		$result = mysql_query($query);
	}
	mysql_close();

	
?>