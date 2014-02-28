// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
    
    var homeTpl = Handlebars.compile($("#home-tpl").html());
   
    /* ---------------------------------- Local Variables ---------------------------------- */
    var slider = new PageSlider($('body'));
    
    var adapter = new LocalStorageAdapter();
    adapter.initialize().done(function() {
	console.log("Data adapter initialized");
	route();
    });

    var detailsURL = /^#employees\/(\d{1,})/;

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
	    console.log("No hash found, starting with page 1");
	    hash = 1;
	}
	else
	{
	    if (hash.charAt(0) === '#')
		hash = hash.substr(1);
	    console.log("Hash: " + hash);
	}
	
	adapter.findById(hash).done(function(employee) {
	    console.log("Employee found: " + employee.id);
	    slider.slidePage(new HomeView(adapter, homeTpl, employee).render().el);});
	return;
	
    }



}());