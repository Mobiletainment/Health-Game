(function()
{
    $(document).bind("mobileinit", function () {
    $.mobile.ajaxEnabled = false;
    $.mobile.linkBindingEnabled = false;
    $.mobile.hashListeningEnabled = false;
    $.mobile.pushStateEnabled = false;
    
    $.mobile.loader.prototype.options.text = "Lade";
	$.mobile.loader.prototype.options.textVisible = true;
	$.mobile.loader.prototype.options.theme = "b";
	$.mobile.loader.prototype.options.html = "";
	
	$.ajaxSetup ({
	    cache: false
	});
    
    });
}());