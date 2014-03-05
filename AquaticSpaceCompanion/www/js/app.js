// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{

    window.username = "Johnny";
    window.customData = { data: "", referral: ""};

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
	    window.alert = function(message)
	    {
		navigator.notification.alert(
			message, // message
			null, // callback
			"Workshop", // title
			'OK'        // buttonName
			);
	    };
	}

    }, false);

    $(document).ready(function()
    {
	console.log("Changing Hash to Training");
	document.location.hash = "#training";
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
	    document.location.hash = u.hash;
	  
	    if (u.hash.search(/^#train-content/) !== -1)
	    {
		console.log("We'd like to navigate to training content");
		showTrainingContent(u, data.options);

		e.preventDefault();
	    }
	    else if (u.hash.search(/^#training$/) !== -1)
	    {
		console.log("We'd like to navigate to training");
		showTrainingOverview();

	    }

	}

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
		rewardMessage: "Bitte geben Sie eine Belohnungs-Nachricht ein"
	    },
	    
	    submitHandler: sendReward
	});

	function sendReward() {
	    //  event.preventDefault();
	    //$( "#rewardingame").find('[data-role="main"]').trigger("create");
	    alert("Submit");
	    console.log("sending reward");

	    $.mobile.loading('show', {
		text: 'Sende Belohnung<br>Bitte warten...'
	    });

	    $.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
		    {
			username: window.username,
			action: "life"
		    },
	    function(data)
	    {
		console.log("Server responded");

		
		$.mobile.loading("hide");
		$.fn.dpToast('Belohnung gesendet', 4000);
		
document.location.hash = "#training";

	    });

	    return false; //prevent event propagation
	};

    });
    /*
     $( "#training" ).on( "pagecontainerbeforeshow", function( event, ui )
     {
     console.log("pagecontainerbeforeshow: Training");
     $('#training-list').listview().listview('refresh');
     });*/
    /*
     $('#training').on('pagebeforeshow', function(event)
     {
     console.log("PagebeforeShow: Training");
     console.log($('#training-list').listview());
     $('#training-list').listview().listview('refresh');
     //$("#uniqueButtonId").hide();
     });
     */
    /*
     $(document).bind("pagebeforeshow", function(e, data)
     {
     console.log("pagebeforeshow: e= " + e + "; data.ToPage = " + data.toPage);
     //$("#training-list").trigger("refresh");
     //$('#training-list').listview('refresh');
     
     });
     */

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
	    var trainingContentView = new ContentView(adapter, item);
	    trainingContentView.loadContent("showTrainingContent");

	    // Pages are lazily enhanced. We call page() on the page
	    // element to make sure it is always enhanced before we
	    // attempt to enhance the listview markup we just injected.
	    // Subsequent calls to page() are ignored since a page/widget
	    // can only be enhanced once.
	    $page.page();

	    //$page.trigger("refresh");
	    $page.find(":jqmData(role=main)").trigger("create");


	    $page.find(":jqmData(role=listview)").listview().listview("refresh");
	    //$("#training-content-main").trigger("create");
	    $page.find(":jqmData(role=footer)").trigger("create");
	    $page.trigger('pagecreate');

	    // We don't want the data-url of the page we just modified
	    // to be the url that shows up in the browser's location field,
	    // so set the dataUrl option to the URL for the category
	    // we just loaded.
	    console.log("UrlObjHref = " + urlObj.href + ", hash = " + urlObj.hash);
	    options.dataUrl = urlObj.href;
	    //document.location.hash = urlObj.hash;

	    // Now call changePage() and tell it to switch to
	    // the page we just modified.
	    $.mobile.changePage($page, options);
	});
    }
    ;

    //function saveToServer()



}());