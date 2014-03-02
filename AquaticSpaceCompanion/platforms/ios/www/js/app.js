// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
Handlebars.registerHelper("inc", function(value, options)
{
    return parseInt(value) + 1;
});
    
    Handlebars.registerHelper('ifCond', function (v1, operator, v2, options) {
    
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
    
    var homeTpl = Handlebars.compile($("#home-tpl").html());
    var trainingTpl = Handlebars.compile($("#training-tpl").html());
    var trainingListTpl = Handlebars.compile($("#training-li-tpl").html());
   
    /* ---------------------------------- Local Variables ---------------------------------- */
    var slider = new PageSlider($('body'));
    
    var adapter = new LocalStorageAdapter();
    adapter.initialize().done(function() {
	console.log("Data adapter initialized");
	route();
    });

    var detailsURL = /^#items\/(\d{1,})/;

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
	if (!hash)
	{
	    console.log("No hash found, starting with menu");
	    adapter.findById("menu").done(function(item)
	    {
		console.log("Menu Items found: " + item);
		var menuView = new MenuView(adapter, trainingTpl, trainingListTpl, item);
		slider.slidePage(menuView.render().el);
		menuView.configure();
		menuView.loadContent();
	    });
	    
	}
	else
	{
	    if (hash.charAt(0) === '#')
		hash = hash.substr(1);
	    console.log("Hash: " + hash);
	    adapter.findById(hash).done(function(item) {
	    console.log("item found: " + item.id);
	    slider.slidePage(new HomeView(adapter, homeTpl, item).render().el);});
	return;
	}
	
	
	
    }



}());