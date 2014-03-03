var ContentView = function(adapter, template, subContent, chapter)
{
    var currentPage = 0;
    var pages = chapter.items;
    var pageCount = pages.length;
    
    
    this.initialize = function()
    {
	// Define a div wrapper for the view. The div wrapper is used to attach events.
	this.el = $('<div/>');
    };

    this.initialize();

    this.render = function()
    {
	this.el.html(template(chapter));
	//$(this.el).find('#sub-content').html(subContent());
	this.loadContent("1");
	
	return this;
    };

    this.loadContent = function(key)
    {
	console.log("Loading Content");
	var page = { "page": currentPage, "pageCount": pageCount, "text": pages[currentPage] };
	console.log("Page: " + page.text);
	$(this.el).find('#sub-content').html(subContent(page));
	
	$(this.el).find("#next-page").click($.proxy(function () {
     //use original 'this'
	    console.log(currentPage);
	    this.loadContent(3);
 },this));
	    
	//) on('click', '#next-page', this.loadContent);
	//console.log("Button text: " + $("#next-page").attr('id'));
	//this.el.on('click', '#training-end', this.saveTrainingProgress);
	//this.el.on('click', '#next-page', this.loadContent(currentPage));
	
	
	currentPage++;
	/*
	
	console.log("Loading Content with key " + key);
	adapter.findById(key).done(function(items) {
	    console.log(items.subTitle);
	    $('.item-list').html(template(items));
	    
	});
	*/
    };

    this.saveTrainingProgress = function(event)
    {
	$.mobile.loading('show', {
	    text: 'Speichere Fortschritt'
	});

	$.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
		{
		    username: "david",
		    chapter: "1"
		},
	function(json)
	{

	    console.log("Server responded");
	    alert(json);
	    $.mobile.loading("hide");
	    var currentPage = window.location.href.split('#')[0];
	    window.location.href = currentPage + "#training";
	}
	);
    };
}