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

    //Content Templates
    var contentTpl = Handlebars.compile($("#content-tpl").html());
    var subContentTpl = Handlebars.compile($("#sub-content-tpl").html());

    //Training Templates
    var trainingTpl = Handlebars.compile($("#training-tpl").html());
    var trainingListTpl = Handlebars.compile($("#training-li-tpl").html());

    /* ---------------------------------- Local Variables ---------------------------------- */
    var slider = new PageSlider($('body'));

    var adapter = new LocalStorageAdapter();
    adapter.initialize().done(function() {
	console.log("Data adapter initialized");
	route();
	
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

    $(window).on('hashchange', route);

    /* ---------------------------------- Local Functions ---------------------------------- */
    function route() {
	
	var hash = window.location.hash;
	console.log("Location Hash: " + hash);
	if (!hash || hash == "#" || hash == "#training")
	{
	    hash = "training";
	    console.log("Redirecting to training");
	    adapter.findById(hash).done(function(item)
	    {
		console.log("Training Items found: " + item);
		var trainingView = new TrainingView(adapter, trainingTpl, trainingListTpl, item);
		slider.slidePage(trainingView.render().el);
		trainingView.configure();
		trainingView.loadContent();
		
	    });

	}
	else
	{
	    if (hash.charAt(0) === '#')
		hash = hash.substr(1);
	    console.log("Hash: " + hash);
	    adapter.findById(hash).done(function(item) {
		console.log("Loading Chapter: " + item.id);
		slider.slidePage(new ContentView(adapter, contentTpl, subContentTpl, item).render().el);
		
		
	    });
	    return;
	}



    }
    
    //function saveToServer()



}());