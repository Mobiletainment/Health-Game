var trainingContentPageTpl = Handlebars.compile($("#training-content-page-tpl").html());
var trainingContentMainTpl = Handlebars.compile($("#training-content-main-tpl").html());
var trainingContentFooterTpl = Handlebars.compile($("#training-content-footer-tpl").html());


var TrainingContentView = function(adapter, chapter)
{
    var currentPage = 0;
    var pages = chapter.items;
    var pageCount = pages.length;
    var firstLoad = true;
    this.el = $('<div />');

    this.initialize = function()
    {
	$("#train-content").html(trainingContentPageTpl(chapter));
        
        var progressLabel = $("#progressLabelPages");
        var progressbar = $("#progressbarPages");
        
        progressbar.progressbar({
	    value: false,
	    change: function() {
		progressLabel.text("Seite " + (currentPage+1) + " von " + pageCount);

	    }
	});
        
        //progressbar.progressbar("value", 1);
        progressbar.height("10");
	
	return this;
    };

    this.initialize();


    this.loadContent = function(key)
    {
	console.log("Loading Content for " + key);
	
        
	var item = pages[currentPage];
	$("#progressbarPages").progressbar("value", (currentPage+1) * 100 / pageCount);
        
	if (typeof(item) == "object")
	{
	    var link = item.href;
	    console.log("Link: " + link);
	    if (link)
	    {
		document.location.hash = link;
		return;
	    }
	}
	
	console.log("Item = " + typeof(item) + ", " + item);
	
	var page = {"page": currentPage + 1, "pageCount": pageCount, "text": pages[currentPage]};
	
	$('#training-content-main').html(trainingContentMainTpl(page));
	$('#training-content-footer').html(trainingContentFooterTpl(page));

	if (firstLoad === false)
	    $('#training-content-listview').listview("refresh");
	    
	$("#training-content-main").find(":jqmData(role=collapsible)").collapsible();
	$("#training-content-main").find(":jqmData(role=button)").button();
	$("#training-content-main").find(":jqmData(role=listview)").listview().listview("refresh");

	// var the_height = ($(window).height() - $("#train-content").find('[data-role="header"]').height() - $("#train-content").find('[data-role="footer"]').height());
	//$("#train-content").find('[data-role="main"]').height(the_height);


	$('#training-content-footer').find("#next-page").button().click($.proxy(function() {
	    //use original 'this'
	    console.log(currentPage);
	    currentPage++;
	    this.loadContent("next");
	}, this));

	$('#training-content-footer').find("#prev-page").button().click($.proxy(function() {
	    //use original 'this'
	    
            if (currentPage === 0)
            {
                window.location.href = "#training";
            }
            else 
            {
                currentPage--;
                this.loadContent("prev");
            }
	}, this));

	$('#training-content-footer').find("#training-end").button().click($.proxy(function() {
	    //use original 'this'
	    saveTrainingProgress(chapter.id);
	}, this));

	//) on('click', '#next-page', this.loadContent);
	//console.log("Button text: " + $("#next-page").attr('id'));
	//this.el.on('click', '#training-end', this.saveTrainingProgress);
	//this.el.on('click', '#next-page', this.loadContent(currentPage));


	firstLoad = false;
    };
}