// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
    var pushNotification;

    function s4() {
	return Math.floor((1 + Math.random()) * 0x10000)
		.toString(16)
		.substring(1);
    }
    ;

    function guid() {
	return s4() + s4() + s4() + s4();
    }


    window.deviceToken = $.cookie("deviceToken");

    function setDeviceToken(token)
    {
	$.cookie("deviceToken", token, {expires: 20 * 365, path: '/'});
	window.deviceToken = $.cookie("deviceToken");
    }

    $(document).on("pagebeforeshow", "#login", function(e, data)
    {
	$("#loginButton").parent().hide();
	$("#loginForm").validate({
	    rules: {
		loginPassword: {
		    required: true,
		    minlength: 2
		}
	    },
	    messages: {
		loginPassword: "Das Team-Passwort ist nicht korrekt. Überprüfen Sie bitte Ihre Eingabe"
	    },
	    submitHandler: validateLogin
	});


	function validateLogin() {
	    console.log("validating Login");

	    $.mobile.loading('show', {
		text: 'Team-Passwort wird überprüft...'
	    });

	    try
	    {
		pushNotification = window.plugins.pushNotification;
		if (device.platform == 'android' || device.platform == 'Android')
		{
		    $("#app-status-ul").append('<li>registering android</li>');
		    pushNotification.register(successHandler, errorHandler, {"senderID": "661780372179", "ecb": "onNotificationGCM"});		// required!
		}
		else
		{
		    $("#app-status-ul").append('<li>registering iOS</li>');
		    pushNotification.register(tokenHandler, errorHandler, {"badge": "true", "sound": "true", "alert": "true", "ecb": "onNotificationAPN"});	// required!
		}
	    }
	    catch (err)
	    {
		txt = "There was an error on this page.\n\n";
		txt += "Error description: " + err.message + "\n\n";
		alert(txt);
		$.mobile.loading("hide");

		//if ($("#loginPassword").val().toLowerCase() == "test")
		{
		    tokenHandler("browser-test");
		}
	    }

	    return false; //prevent event propagation
	}
	;

    });

    // handle APNS notifications for iOS
    function onNotificationAPN(e) {
	if (e.alert) {
	    alert("Push Notification: " + e.alert);
	    //$("#app-status-ul").append('<li>push-notification: ' + e.alert + '</li>');
	    navigator.notification.alert(e.alert);
	}

	if (e.sound) {
	    var snd = new Media(e.sound);
	    snd.play();
	}

	if (e.badge) {
	    pushNotification.setApplicationIconBadgeNumber(successHandler, e.badge);
	}
    }

    // handle GCM notifications for Android
    function onNotificationGCM(e) {
	$("#app-status-ul").append('<li>EVENT -> RECEIVED:' + e.event + '</li>');

	switch (e.event)
	{
	    case 'registered':
		if (e.regid.length > 0)
		{
		    setDeviceToken(e.regid);
		    storeDeviceToken();
		    //$("#app-status-ul").append('<li>REGISTERED -> REGID:' + e.regid + "</li>");
		    // Your GCM push server needs to know the regID before it can push to this device
		    // here is where you might want to send it the regID for later use.
		    console.log("regID = " + e.regid);
		}
		break;

	    case 'message':
		// if this flag is set, this notification happened while we were in the foreground.
		// you might want to play a sound to get the user's attention, throw up a dialog, etc.
		if (e.foreground)
		{
		    $("#app-status-ul").append('<li>--INLINE NOTIFICATION--' + '</li>');

		    // if the notification contains a soundname, play it.
		    var my_media = new Media("/android_asset/www/" + e.soundname);
		    my_media.play();
		}
		else
		{	// otherwise we were launched because the user touched a notification in the notification tray.
		    if (e.coldstart)
			$("#app-status-ul").append('<li>--COLDSTART NOTIFICATION--' + '</li>');
		    else
			$("#app-status-ul").append('<li>--BACKGROUND NOTIFICATION--' + '</li>');
		}

		$("#app-status-ul").append('<li>MESSAGE -> MSG: ' + e.payload.message + '</li>');
		$("#app-status-ul").append('<li>MESSAGE -> MSGCNT: ' + e.payload.msgcnt + '</li>');
		break;

	    case 'error':
		$("#app-status-ul").append('<li>ERROR -> MSG:' + e.msg + '</li>');
		break;

	    default:
		$("#app-status-ul").append('<li>EVENT -> Unknown, an event was received and we do not know what it is</li>');
		break;
	}
    }

    function tokenHandler(result) //Got iOS Token
    {
	alert("Got token: " + result);
	setDeviceToken(result);
	// Your iOS push server needs to know the token before it can push to this device
	// here is where you might want to send it the token for later use
	storeDeviceToken();

    }

    function storeDeviceToken()
    {
	console.log("Storing Device Token");
	
	var os;
	
	if (typeof device === "undefined" || typeof device.platform === "undefined")
	{
	    os = "browser";
	}
	else
	{
	    os = (device.platform == 'android' || device.platform == 'Android') ? "android" : "ios";
	}
	
	$.getJSON("http://tnix.eu/~aspace/RegisterDevice.php",
		{
		    user: $("#loginPassword").val(),
		    data: window.deviceToken,
		    os: os
		}, function(data)
	{
	    console.log("Server responded to RegisterDevice");
	    

	    if (data.returnCode === 200)
	    {
		$.cookie("username", $("#loginPassword").val(), {expires: 20 * 365, path: '/'});
		window.username = $("#loginPassword").val();
		$.fn.dpToast('Überprüfung erfolgreich', 4000);
		$("#loginButton").trigger("click");
	    }
	    else if (data.returnCode === 401)
	    {
		alert("Keine Übereinstimmung. Möglicherweise hat sich Ihr Kind noch nicht registriert oder Sie haben sich vertippt. Überprüfen Sie bitte das Passwort und versuchen Sie es nochmal.")
	    }
	    else
	    {
		alert(data.debugInfo);
	    }

	}
	).fail(function()
	{
	    alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", storeDeviceToken());
	}
	).always(function() {
	    $.mobile.loading("hide");
	});
    }


    function successHandler(result)
    {
	alert("Successfully registered Push Notifications");

    }

    function errorHandler(error)
    {
	alert("Registering Push Notifications failed");
    }

}());