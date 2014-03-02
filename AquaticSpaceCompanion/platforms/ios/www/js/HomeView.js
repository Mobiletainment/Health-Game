var HomeView = function(adapter, template, item)
{
    this.initialize = function()
    {
	// Define a div wrapper for the view. The div wrapper is used to attach events.
	this.el = $('<div/>');
	console.log(item);
    };

    this.initialize();

    this.render = function()
    {
	this.el.html(template(item));
	this.el.on('click', '#training-end', this.saveTrainingProgress);
	return this;
    };

    this.loadContent = function(key)
    {
	console.log("Loading Content with key " + key);
	adapter.findById(key).done(function(items) {
	    console.log(items.subTitle);
	    $('.item-list').html(template(items));
	});
    };

    this.saveTrainingProgress = function(event)
    {
	$.mobile.loading('show', {
	    text: 'Speichere Fortschritt'
	});

	$.getJSON("http://tnix.eu/~aspace/SubmitTrainingProgress.php",
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