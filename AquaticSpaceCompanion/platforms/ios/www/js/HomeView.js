var HomeView = function (adapter, template, employee)
{
    this.initialize = function()
    {
	// Define a div wrapper for the view. The div wrapper is used to attach events.
        this.el = $('<div/>');
	console.log(employee);
    };
    
    this.initialize();
    
    this.render = function()
    {
	this.el.html(template(employee));
	return this;
    }
    
    this.loadContent = function(key)
    {
	console.log("Loading Content with key " + key);
	adapter.findById(key).done(function(employees) {
	    console.log(employees.subTitle);
	    $('.employee-list').html(template(employees));	
	});
    }
}