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
	this.loadContent("init");

	return this;
    };

    this.loadContent = function(key)
    {
	console.log("Loading Content for " + key);
	var page = {"page": currentPage + 1, "pageCount": pageCount, "text": pages[currentPage]};
	$(this.el).find('#sub-content').html(subContent(page));

	$(this.el).find("#next-page").click($.proxy(function() {
	    //use original 'this'
	    console.log(currentPage);
	    currentPage++;
	    this.loadContent("next");
	}, this));

	$(this.el).find("#prev-page").click($.proxy(function() {
	    //use original 'this'
	    currentPage--;
	    this.loadContent("prev");
	}, this));

	$(this.el).find("#training-end").click($.proxy(function() {
	    //use original 'this'
	    this.saveTrainingProgress("1");
	}, this));

	//) on('click', '#next-page', this.loadContent);
	//console.log("Button text: " + $("#next-page").attr('id'));
	//this.el.on('click', '#training-end', this.saveTrainingProgress);
	//this.el.on('click', '#next-page', this.loadContent(currentPage));



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
	    alert(data.returnData);
	    $.mobile.loading("hide");
	    var currentPage = window.location.href.split('#')[0];
	    window.location.href = currentPage + "#training";
	}
	);
    };
}