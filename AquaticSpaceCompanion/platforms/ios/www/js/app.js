// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
    window.username = "Johnny";

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
    var slider = new PageSlider($('body'));

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


	    if (u.hash.search(/^#training-content/) !== -1)
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

    function showTrainingOverview()
    {
	//Training Templates
	var trainingListTpl = Handlebars.compile($("#training-li-tpl").html());

	hash = "training";
	console.log("Redirecting to training");
	adapter.findById(hash).done(function(item)
	{
	    console.log("Training Items found: " + item);
	    var trainingView = new TrainingView(adapter, trainingListTpl, item);


	});
    }
    ;

    function showTrainingContent(urlObj, options)
    {
	//Content Templates
	var contentTpl = Handlebars.compile($("#training-content-tpl").html());
	var subContentTpl = Handlebars.compile($("#training-sub-content-tpl").html());

	var chapter = urlObj.hash.replace(/.*chapter=/, "")
	var pageSelector = urlObj.hash.replace(/\?.*$/, "");
	var $page = $(pageSelector);

	console.log("Loading training chapter: " + chapter);
	adapter.findById(chapter).done(function(item) {
	    console.log("Loading Chapter: " + item.id);
	    var trainingContentView = new ContentView(adapter, contentTpl, subContentTpl, item);
	    trainingContentView.loadContent();

	    // Pages are lazily enhanced. We call page() on the page
	    // element to make sure it is always enhanced before we
	    // attempt to enhance the listview markup we just injected.
	    // Subsequent calls to page() are ignored since a page/widget
	    // can only be enhanced once.
	    $page.page();
	    // We don't want the data-url of the page we just modified
	    // to be the url that shows up in the browser's location field,
	    // so set the dataUrl option to the URL for the category
	    // we just loaded.
	    //options.dataUrl = urlObj.href;

	    // Now call changePage() and tell it to switch to
	    // the page we just modified.
	    $.mobile.changePage($page, options);
	});
    }
    ;

    //function saveToServer()



}());