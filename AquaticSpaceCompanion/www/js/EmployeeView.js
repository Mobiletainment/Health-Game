var itemView = function(adapter, template, item) {
    this.initialize = function() {
	this.el = $('<div/>');
    };

    this.initialize();

    this.render = function()
    {
	this.el.html(template(item));
	this.el.on('click', '.add-location-btn', this.addLocation);
	this.el.on('click', '.add-contact-btn', this.addToContacts);
	return this;
    };

    this.addLocation = function(event)
    {
	event.preventDefault();
	navigator.geolocation.getCurrentPosition(
		function(position) {
		    alert(position.coords.latitude + ',' + position.coords.longitude);
		},
		function() {
		    alert('Error getting location');
		});
	return false;
    };

    this.addToContacts = function(event)
    {
	event.preventDefault();
	console.log('addToContacts');
	if (!navigator.contacts)
	{
	    alert("Contacts API not supported", "Error");
	    return;
	}
	
	var contact = navigator.contacts.create();
	contact.name = {givenName: item.firstName, familyName: item.lastName};

	var phoneNumbers = [];
	phoneNumbers[0] = new ContactField('work', item.officePhone, false);
	phoneNumbers[1] = new ContactField('mobile', item.cellPhone, true);
	contact.phoneNumbers = phoneNumbers;
	contact.save();
	return false;
    };
}