var trainingListTpl = Handlebars.compile($("#training-li-tpl").html());

var TrainingView = function(adapter, item)
{
    this.initialize = function() {
	console.log("Filling Training-Menu");
	console.log("Item: " + item);

	//$('#training-list').listview();

	$('#training-listview').html(trainingListTpl(item)); //inflate template
	// Enhance the listview we just injected.
	//$('#training-list').find( ":jqmData(role=listview)" ).listview();

	var progressLabel = $("#progressLabel");
	var progressbar = $("#progressbar");

	progressbar.progressbar({
	    value: false,
	    change: function() {
		var value = progressbar.progressbar("value");

		progressLabel.text("Fortschritt: " + value + "%");

	    }
	});

	var selector = "#progressbar";
	$(selector).bind('progressbarchange', function(event, ui) {
	    var selector = "#progressbar > div";
	    var value = this.getAttribute("aria-valuenow");
	    if (value < 10) {
		$(selector).css({'background': 'Red'});
	    } else if (value < 30) {
		$(selector).css({'background': 'Orange'});
	    } else if (value < 50) {
		$(selector).css({'background': 'Yellow'});
            } else if (value < 80) {
                $(selector).css({'background': 'LightGreen'});
            } 
            else {
                $(selector).css({'background': '#33CC00'});
	    }
	});

	progressbar.progressbar("value", 0);

    };

    this.initialize();



};