var LocalStorageAdapter = function () {

    this.initialize = function() {
        var deferred = $.Deferred();
        // Store sample data in Local Storage
	
        window.localStorage.setItem("employees", JSON.stringify(
            [
                {"id": 1, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 2, "text": "Versuchen Sie ca. 15 Minuten pro Tag Ihre ungeteilte Aufmerksamkeit ihrem Kind zu schenken.\n\nKündigen Sie die Zeit zu Zweit an und lassen Sie das Kind die Beschäf- tigung aussuchen.<br><br>Zeigen Sie Interesse an der Beschäf- tigung des Kindes, indem Sie wie ein Sportsmoderator nacherzählen was das Kind tut."},
                {"id": 2, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 3, "text": "Laleleu."},
		{"id": 3, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 3, "text": "Laleleu."}
                
	]
        ));
        deferred.resolve();
        return deferred.promise();
    }

    this.findById = function (id) {

        var deferred = $.Deferred(),
            employees = JSON.parse(window.localStorage.getItem("employees")),
            employee = null,
            l = employees.length;

        for (var i = 0; i < l; i++)
	{
	    //console.log("Employee " + i + ": " + employees[i].text);
            if (employees[i].id == id) {
                employee = employees[i];
                break;
            }
        }

        deferred.resolve(employee);
        return deferred.promise();
    }

}