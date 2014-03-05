var trainingContentPageTpl = Handlebars.compile($("#training-content-page-tpl").html());
var trainingContentMainTpl = Handlebars.compile($("#training-content-main-tpl").html());
var trainingContentFooterTpl = Handlebars.compile($("#training-content-footer-tpl").html());


var ContentView = function(adapter, chapter)
{
    var currentPage = 0;
    var pages = chapter.items;
    var pageCount = pages.length;
    var firstLoad = true;
    this.el = $('<div />');

    this.initialize = function()
    {
	
	$("#train-content").html(trainingContentPageTpl(chapter));
	
	return this;
    };

    this.initialize();


    this.loadContent = function(key)
    {
	console.log("Loading Content for " + key);
	var page = {"page": currentPage + 1, "pageCount": pageCount, "text": pages[currentPage]};
	
	$('#training-content-main').html(trainingContentMainTpl(page));
	$('#training-content-footer').html(trainingContentFooterTpl(page));

	if (firstLoad === false)
	    $('#training-content-listview').listview("refresh");
	    
	$("#training-content-main").find(":jqmData(role=collapsible)").collapsible();
	$("#training-content-main").find(":jqmData(role=button)").button();
	$("#training-content-main").find(":jqmData(role=listview)").listview().listview("refresh");

	$('#training-content-footer').find("#next-page").button().click($.proxy(function() {
	    //use original 'this'
	    console.log(currentPage);
	    currentPage++;
	    this.loadContent("next");
	}, this));

	$('#training-content-footer').find("#prev-page").button().click($.proxy(function() {
	    //use original 'this'
	    currentPage--;
	    this.loadContent("prev");
	}, this));

	$('#training-content-footer').find("#training-end").button().click($.proxy(function() {
	    //use original 'this'
	    this.saveTrainingProgress("1");
	}, this));

	//) on('click', '#next-page', this.loadContent);
	//console.log("Button text: " + $("#next-page").attr('id'));
	//this.el.on('click', '#training-end', this.saveTrainingProgress);
	//this.el.on('click', '#next-page', this.loadContent(currentPage));


	firstLoad = false;
    };

    this.saveTrainingProgress = function(event)
    {
	$.mobile.loading('show', {
	    text: 'Speichere Fortschritt'
	});

	console.log("Saving progress for chapter: " + chapter.id);

	$.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
		{
		    username: window.username,
		    action: "SaveProgress",
		    chapter: chapter.id
		},
	function(data)
	{

	    console.log("Server responded");
	    //alert(data.returnData);
	    $.mobile.loading("hide");
	    var currentPage = window.location.href.split('#')[0];
	    window.location.href = currentPage + "#training";
	}
	);
    };
}