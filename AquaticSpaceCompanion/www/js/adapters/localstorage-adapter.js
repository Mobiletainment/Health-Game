var LocalStorageAdapter = function () {

    this.initialize = function() {
        var deferred = $.Deferred();
        // Store sample data in Local Storage
	
        window.localStorage.setItem("items", JSON.stringify(
            [
                {"id": 1, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 2, "text": "<p>Versuchen Sie ca. 15 Minuten pro Tag Ihre ungeteilte Aufmerksamkeit ihrem Kind zu schenken.</p><p>Kündigen Sie die Zeit zu Zweit an und lassen Sie das Kind die Beschäftigung aussuchen.</p><p>Zeigen Sie Interesse an der Beschäf- tigung des Kindes, indem Sie wie ein Sportsmoderator nacherzählen was das Kind tut.</p>"},
                {"id": 2, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 3, "text": "Laleleu."},
		{"id": 3, "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 0, "pageCount": 4, "next": 3, "text": "Laleleu."}
                
	]
        ));
        deferred.resolve();
        return deferred.promise();
    }

    this.findById = function (id) {

        var deferred = $.Deferred(),
            items = JSON.parse(window.localStorage.getItem("items")),
            item = null,
            l = items.length;

        for (var i = 0; i < l; i++)
	{
	    //console.log("item " + i + ": " + items[i].text);
            if (items[i].id == id) {
                item = items[i];
                break;
            }
        }

        deferred.resolve(item);
        return deferred.promise();
    }

}