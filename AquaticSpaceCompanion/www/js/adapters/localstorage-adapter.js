var LocalStorageAdapter = function() {

    this.initialize = function() {
	var deferred = $.Deferred();
	// Store sample data in Local Storage

	window.localStorage.setItem("items", JSON.stringify(
		[
		    {"id": "training", "items": [{"name": "Zeit-Zu-Zweit"}, {"name": "Lob"}, {"name": "Belohnung"}, {"name": "Anweisungen"}, {"name": "Aktives Ignorieren"}, {"name": "Auszeit"}, ]},
		    
	    
{"id": "t1", "title": "1. Strategie", "subTitle": "Zeit-zu-zweit", "items":
["<p>Die Qualität der Beziehung zu ihrem Kind kann durch wertvolle, positive und regelmäßige Zeiten der Interaktion, <b>„Zeit zu Zweit“</b> genannt, verbessert werden.</p>",
 "<p>Versuchen Sie ca. 15 Minuten pro Tag Ihre ungeteilte Aufmerksamkeit ihrem Kind zu schenken.</p><p>Kündigen Sie die Zeit zu Zweit an und lassen Sie das Kind die Beschäftigung aussuchen.</p><p>Zeigen Sie Interesse an der Beschäftigung des Kindes, indem Sie wie ein Sportsmoderator nacherzählen was das Kind tut.<p>",
 "<p>Ihre Rolle ist es ihrem Kind zuzuschauen und ihm Aufmerksamkeit zu schenken ohne zu kritisieren, dirigieren oder zu kontrollieren.</p><p>Sehen Sie die Interaktionen als eine Investition. Die positive Aufmerksamkeit die Sie ihrem Kind schenken erhöht die Qualität eurer Beziehung und, in späteren Folge, auch die Motivation ihres Kindes mit ihnen an einem Strang zu ziehen.</p>",
 "<p>Die Zeit-zu-zweit wird auch im Rahmen dieses Spiels trainiert: Sie spielen gemeinsam mit ihrem Kind, loben es und kommentieren die Erfolge und Aktionen ihres Kindes!</p>"
]},
{"id": "t2", "title": "2. Strategie", "subTitle": "Lob", "items":
[
 "<p>Kinder mir Verhaltensproblemen bekommen Aufmerksamkeit meist erst dann, wenn sie sich unpassend benehmen. Sie lernen schnell, dass diese Art des Verhaltens ihnen elter- liche Aufmerksamkeit bringt.</p><p>Um den Teufelskreis zu brechen und wünschenswerte Verhaltensweisen zu verstärken, versuchen Sie ihr Kind bei gutem Verhalten zu ‚erwischen‘.</p>",
 "<p>Loben Sie ihr Kind <b>sofort</b> und versu- chen Sie das Verhalten dabei zu <b>benennen</b>, damit es ihrem Kind klar wird, wie es sich die Anerkennung verdient hat.</p><p>Loben Sie ihr Kind nicht nur wenn es ihre Anforderungen und Bitten nachkommt, sondern auch wenn wünschenswertes Verhalten <b>von al- leine</b> kommt.</p><p>Sprechen Sie ihr Lob und Anerken- nung im Rahmen des Spiels sowie im wirklichen Leben aus!</p>",
 "<p><b>Beispiele für ein richtig ausgesprochenes Lob:</b>\n\
<ul>\n\
<li>Ich schätze es sehr, wenn du ...</li>\n\
<li>Ich mag es, wenn du ...</li>\n\
<li>Es ist wirklich nett von dir, wenn du ...</li>\n\
<li>Danke, dass du ...</li>\n\
<li>Schau, wie schön (schnell, ordentlich, usw.) du ...</li>\n\
<li>Gut gemacht!</li>\n\</ul></p>"
]}
		]));
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