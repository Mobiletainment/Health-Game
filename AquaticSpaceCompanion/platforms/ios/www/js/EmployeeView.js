var EmployeeView = function(adapter, template, employee) {
    this.initialize = function() {
	this.el = $('<div/>');
    };

    this.initialize();

    this.render = function()
    {
	this.el.html(template(employee));
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
	contact.name = {givenName: employee.firstName, familyName: employee.lastName};

	var phoneNumbers = [];
	phoneNumbers[0] = new ContactField('work', employee.officePhone, false);
	phoneNumbers[1] = new ContactField('mobile', employee.cellPhone, true);
	contact.phoneNumbers = phoneNumbers;
	contact.save();
	return false;
    };
}