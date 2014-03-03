var LocalStorageAdapter = function() {

    this.initialize = function() {
	var deferred = $.Deferred();
	// Store sample data in Local Storage

	window.localStorage.setItem("items", JSON.stringify(
		[
		    {"id": "training", "items": [{"name": "Zeit-Zu-Zweit"}, {"name": "Lob"}, {"name": "Belohnung"}, {"name": "Anweisungen"}, {"name": "Aktives Ignorieren"}, {"name": "Auszeit"}, ]},
		    {"id": "t1", "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "items": ["<p>Versuchen Sie ca. 15 Minuten pro Tag Ihre ungeteilte Aufmerksamkeit ihrem Kind zu schenken.</p><p>Kündigen Sie die Zeit zu Zweit an und lassen Sie das Kind die Beschäftigung aussuchen.</p><p>Zeigen Sie Interesse an der Beschäftigung des Kindes, indem Sie wie ein Sportsmoderator nacherzählen was das Kind tut.<p>", "<p>Ihre Rolle ist es ihrem Kind zuzu- schauen und ihm Aufmerksamkeit zu schenken ohne zu kritisieren, dirigieren oder zu kontrollieren.</p><p>Sehen Sie die Interaktionen als eine Investition. Die positive Aufmerk- samkeit die Sie ihrem Kind schenken erhöht die Qualität eurer Beziehung und, in späteren Folge, auch die Mo- tivation ihres Kindes mit ihnen an einem Strang zu ziehen.</p>"]},
		    {"id": "t2", "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 2, "pageCount": 3, "next": 3, "text": "Laleleu."},
		    {"id": "t3", "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "page": 3, "pageCount": 3, "next": 3, "text": "Laleleu."}

		]
		));
	deferred.resolve();
	return deferred.promise();
    }

    this.findById = function(id) {

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