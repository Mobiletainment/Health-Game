// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{



    window.username = $.cookie("username");
    

    window.customData = {data: "", referral: ""};

    Handlebars.registerHelper("inc", function(value, options)
    {
	return parseInt(value) + 1;
    });

    Handlebars.registerHelper('ifCond', function(v1, operator, v2, options) {

	switch (operator) {
	    case '==':
		return (v1 == v2) ? options.fn(this) : options.inverse(this);
	    case '===':
		return (v1 === v2) ? options.fn(this) : options.inverse(this);
	    case '<':
		return (v1 < v2) ? options.fn(this) : options.inverse(this);
	    case '<=':
		return (v1 <= v2) ? options.fn(this) : options.inverse(this);
	    case '>':
		return (v1 > v2) ? options.fn(this) : options.inverse(this);
	    case '>=':
		return (v1 >= v2) ? options.fn(this) : options.inverse(this);
	    case '&&':
		return (v1 && v2) ? options.fn(this) : options.inverse(this);
	    case '||':
		return (v1 || v2) ? options.fn(this) : options.inverse(this);
	    default:
		return options.inverse(this);
	}
    });



    /* ---------------------------------- Local Variables ---------------------------------- */

    var adapter = new LocalStorageAdapter();
    adapter.initialize().done(function() {
	console.log("Data adapter initialized");
	//route();

    });

    /* --------------------------------- Event Registration -------------------------------- */
    document.addEventListener('deviceready', function() {
	FastClick.attach(document.body);

	if (navigator.notification)
	{ // OverÏride default HTML alert with native dialog
	    window.alert = function(message, callback)
	    {
		navigator.notification.alert(
			message, // message
			callback, // callback
			"Fehler", // title
			'OK'        // buttonName
			);
	    };
	}

	successFunction = function()
	{
	    console.log("Testflight started successfully");
	}

	failedFunction = function()
	{
	    console.log("Testflight failed to start");
	}

	var tf = new TestFlight();
	tf.takeOff(successFunction, failedFunction, "029ece91-ccbf-4e5e-8ed0-3b012f5fb854");

	

    }, false);

    $(document).ready(function()
    {
	console.log("Changing Hash to Training");
	//document.location.hash = "#welcome";
    });

    $(document).bind("pagebeforechange", function(e, data)
    {
	console.log("Intercepting pagebeforechange");
	if (typeof data.toPage === "string") {

	    // We are being asked to load a page by URL, but we only
	    // want to handle URLs that request the data for a specific
	    // category.
	    console.log("Checking if training is navigated");
	    var u = $.mobile.path.parseUrl(data.toPage);
	    //document.location.hash = u.hash;

	    if (u.hash.search(/^#train-content/) !== -1)
	    {
		console.log("We'd like to navigate to training content");
		showTrainingContent(u, data.options);

		//e.preventDefault();
	    }
	    else if (u.hash.search(/^#training$/) !== -1)
	    {
		console.log("We'd like to navigate to training");
		showTrainingOverview();

	    }

	}

    });

    $(document).on("pagebeforeshow", "#timeout", function(e, data)
    {
	$("#sendTimeOut").parent().hide();
	$.mobile.loading('show', {
	    text: 'Auszeit-Ort wird geladen...'
	});
	$.getJSON("http://tnix.eu/~aspace/Timeout.php",
		{
		    username: window.username,
		    action: "LoadTimeout",
		},
		function(data)
		{
		    console.log("Data for Timeout received: " + data.returnData);
		    if (data.returnCode == 200)
			$("#timeOutLocation").val(data.returnData);

		    $.mobile.loading("hide");
		});

	$("#sendTimeOutForm").validate({
	    rules: {
		timeOutLocation: {
		    required: true,
		    minlength: 2
		}
	    },
	    messages: {
		timeOutLocation: "Geben Sie einen Auszeit-Ort an"
	    },
	    submitHandler: sendTimeOut
	});

	$("#timeOutSaveAndEnd").click(function()
	{
	    $("#sendTimeOut").trigger("click");
	    return false;
	});

	function sendTimeOut() {
	    var func = this;
	    console.log("sending timeout");

	    $.mobile.loading('show', {
		text: 'Auszeit-Ort wird gespeichert...'
	    });

	    $.getJSON("http://tnix.eu/~aspace/Timeout.php",
		    {
			username: window.username,
			action: "SaveTimeout",
			data: $("#timeOutLocation").val()
		    },
	    function(data)
	    {
		console.log("Server responded");

		saveTrainingProgress("t6");
	    }).fail(function()
	    {
		alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
	    }).always(function() {
		$.mobile.loading("hide");
	    });
	    ;

	    return false; //prevent event propagation
	}
	;

    });

    //Super important: enhancing the layout that got dynamically added. Only way I found working
    $(document).on("pagebeforeshow", "#training", function(event)
    {
	$("#training").find(":jqmData(role=listview)").listview().listview("refresh");
    });

    $(document).on("pagebeforeshow", "#rewardingame", function(e, data)
    {
	//var parameters = data("url").split("?")[1];;
	// parameter = parameters.replace("parameter=","");  
	//  document.location.hash = u.hash;

	$("#rewardImage").attr("src", "img/reward/" + customData.data + ".png");
	$("#rewardBackNavigation").attr("href", "index.html" + customData.referral);
	$("#sendInGameForm").validate({
	    rules: {
		rewardMessage: {
		    required: true,
		    minlength: 2
		}
	    },
	    messages: {
		rewardMessage: "Sie haben keine Belohnungs-Nachricht eingegeben"
	    },
	    submitHandler: sendReward
	});

	function sendReward() {
	    //  event.preventDefault();
	    //$( "#rewardingame").find('[data-role="main"]').trigger("create");
	    //alert("Submit");
	    console.log("sending reward");
	    var that = sendReward;

	    $.mobile.loading('show', {
		text: 'Belohnung wird gesendet...'
	    });

	    $.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
		    {
			username: window.username,
			action: "life"
		    },
	    function(data)
	    {
		console.log("Server responded");

		//$.mobile.loading("hide");
		$.fn.dpToast('Belohnung gesendet', 4000);

		document.location.hash = "#training";

	    }).fail(function()
	    {
		alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", that);
	    }).always(function() {
		$.mobile.loading("hide");
	    });
	    ;

	    return false; //prevent event propagation
	}
	;

    });


    function showTrainingOverview()
    {
	//Training Templates


	hash = "training";
	console.log("Redirecting to training");
	adapter.findById(hash).done(function(item)
	{
	    console.log("Training Items found: " + item);
	    var trainingView = new TrainingView(adapter, item);

	});
    }
    ;

    function showTrainingContent(urlObj, options)
    {
	//Content Templates

	var chapter = urlObj.hash.replace(/.*chapter=/, "")
	var pageSelector = urlObj.hash.replace(/\?.*$/, "");
	var $page = $(pageSelector);

	console.log("Loading training chapter: " + chapter);
	adapter.findById(chapter).done(function(item) {
	    console.log("Loading Chapter: " + item.id);
	    var trainingContentView = new TrainingContentView(adapter, item);
	    trainingContentView.loadContent("showTrainingContent");

	    // Pages are lazily enhanced. We call page() on the page
	    // element to make sure it is always enhanced before we
	    // attempt to enhance the listview markup we just injected.
	    // Subsequent calls to page() are ignored since a page/widget
	    // can only be enhanced once.
	    $page.page();

	    //$page.trigger("refresh");
	    $page.find(":jqmData(role=main)").trigger("create");


	    //$page.find(":jqmData(role=listview)").listview().listview("refresh");
	    //$("#training-content-main").trigger("create");
	    $page.find(":jqmData(role=footer)").trigger("create");
	    $page.trigger('pagecreate');

	    // We don't want the data-url of the page we just modified
	    // to be the url that shows up in the browser's location field,
	    // so set the dataUrl option to the URL for the category
	    // we just loaded.
	    console.log("UrlObjHref = " + urlObj.href + ", hash = " + urlObj.hash);
	    options.dataUrl = urlObj.href;
	    document.location.hash = urlObj.hash;

	    // Now call changePage() and tell it to switch to
	    // the page we just modified.
	    $.mobile.changePage($page, options);
	});
    }
    ;

    saveTrainingProgress = function(chapterId)
    {
	var func = this;
	$.mobile.loading('show', {
	    text: 'Speichere Fortschritt'
	});

	console.log("Saving progress for chapter: " + chapterId);

	$.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
		{
		    username: window.username,
		    action: "SaveProgress",
		    chapter: chapterId
		},
	function(data)
	{

	    console.log("Server responded");
	    //alert(data.returnData);
	    //$.mobile.loading("hide");
	    var currentPage = window.location.href.split('#')[0];
	    window.location.href = currentPage + "#training";
	}
	).fail(function()
	{
	    alert("Die Internetverbindung ist unterbrochen. Fortschritt kann nicht gespeichert werden. Erneut versuchen?", func);
	}).always(function() {
	    $.mobile.loading("hide");
	});

    };


}());