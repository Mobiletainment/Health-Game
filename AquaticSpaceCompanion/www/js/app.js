// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
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
    var menuTpl = Handlebars.compile($("#menu-tpl").html());
   
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
	    hash = 1;
	    
	    slider.slidePage(new MenuView(adapter, menuTpl).render().el);
	    
	    
	    var progressLabel = $( ".progress-label" );
	    var progressbar = $("#progressbar");
	    
	    progressbar.progressbar({
		value: false,
		change: function() {
		    var value = progressbar.progressbar("value");
		    
		    progressLabel.text("Fortschritt: " + value + "%" );
		    
		}
	    });
	    
	    var selector = "#progressbar";
            $(selector).bind('progressbarchange', function(event, ui) {
                var selector = "#progressbar > div";
                var value = this.getAttribute( "aria-valuenow" );
                if (value < 10){
                    $(selector).css({ 'background': 'Red' });
                } else if (value < 30){
                    $(selector).css({ 'background': 'Orange' });
                } else if (value < 50){
                    $(selector).css({ 'background': 'Yellow' });
                } else{
                    $(selector).css({ 'background': 'LightGreen' });
                }
            });
	    
	    progressbar.progressbar( "value", 33);
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