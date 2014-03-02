var HomeView = function (adapter, template, item)
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
	return this;
    }
    
    this.loadContent = function(key)
    {
	console.log("Loading Content with key " + key);
	adapter.findById(key).done(function(items) {
	    console.log(items.subTitle);
	    $('.item-list').html(template(items));	
	});
    }
}