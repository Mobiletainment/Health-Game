var MenuView = function(adapter, template)
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

};