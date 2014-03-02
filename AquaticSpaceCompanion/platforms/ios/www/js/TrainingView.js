var TrainingView = function(adapter, template, listTemplate, item)
{
    this.initialize = function() {
	this.el = $('<div/>');
    };

    this.initialize();

    this.render = function()
    {
	this.el.html(template());
	return this;
    };
    
    this.configure = function()
    {
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
	  
    };
    
    this.loadContent = function()
    {
	console.log("Filling Training-Menu");
	console.log("Item: " + item);
	$('.training-list').html(listTemplate(item));
	
    };

};