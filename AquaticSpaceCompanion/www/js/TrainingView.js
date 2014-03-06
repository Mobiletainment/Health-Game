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

	var progressLabel = $(".progress-label");
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
	    } else {
		$(selector).css({'background': 'LightGreen'});
	    }
	});

	progressbar.progressbar("value", 0);


	$(document).ready(function() //Load Training progress
	{
	    loadTrainingProgress = function()
	    {
		console.log("this.loadTrainingProgress");
		$.mobile.loading('show', {
		    text: 'Lade Fortschritt'
		});

		$.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
			{
			    username: window.username,
			    action: "GetProgress"
			},
		function(data)
		{
		    console.log("Server responded");

		    var imgId = '#imgDone_';
		    var total = 0;
		    var completed = 0;

		    $.each(data.returnData, function(key, val)
		    {
			++total;

			if (val === true)
			{
			    ++completed;
			    $(imgId + key).attr("src", "img/checkbox_done.png");
			}
		    });
		    console.log("Total: " + total);
		    console.log("Progressbar : " + $("#progressbar").progressbar("value"));

		    if (completed > 0 && total > 0)
			$("#progressbar").progressbar('value', Math.round(completed * 100 / total));




		}).fail(function()
		{
		    alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", loadTrainingProgress);
		}).always(function() {
		    $.mobile.loading("hide");
		});
	    }

	    loadTrainingProgress();


	}
	);

    };

    this.initialize();



};