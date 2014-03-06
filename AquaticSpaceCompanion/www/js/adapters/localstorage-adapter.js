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
 "<p>Kinder mit Verhaltensproblemen bekommen Aufmerksamkeit meist erst dann, wenn sie sich unpassend benehmen. Sie lernen schnell, dass diese Art des Verhaltens ihnen elterliche Aufmerksamkeit bringt.</p><p>Um den Teufelskreis zu brechen und wünschenswerte Verhaltensweisen zu verstärken, versuchen Sie ihr Kind bei gutem Verhalten zu ‚erwischen‘.</p>",
 "<p>Loben Sie ihr Kind <b>sofort</b> und versuchen Sie das Verhalten dabei zu <b>benennen</b>, damit es ihrem Kind klar wird, wie es sich die Anerkennung verdient hat.</p><p>Loben Sie ihr Kind nicht nur wenn es ihre Anforderungen und Bitten nachkommt, sondern auch wenn wünschenswertes Verhalten <b>von alleine</b> kommt.</p><p>Sprechen Sie ihr Lob und Anerkennung im Rahmen des Spiels sowie im wirklichen Leben aus!</p>",
 "<p><b>Beispiele für ein richtig ausgesprochenes Lob:</b>\n\
<div><ul><li>Ich schätze es sehr, wenn du ...</li><li>Ich mag es, wenn du ...</li><li>Es ist wirklich nett von dir, wenn du ...</li><li>Danke, dass du ...</li><li>Schau, wie schön (schnell, ordentlich, usw.) du ...</li><li>Gut gemacht!</li></ul></div></p>"
]},
{"id": "t3", "title": "3. Strategie", "subTitle": "Belohnung", "items":
[
 "<p>Eine Belohnung, die Sie ihrem Kind geben, wenn es ein gewünschtes Verhalten zeigt, steigert die Chance, dass ihr Kind das Verhalten auch in der Zukunft zeigen wird.</p>",
 "<p>Bestimmen Sie gemeinsam mit ihrem Kind, welche Belohnungen in Frage kommen. Sie sollten für das Kind einen hohen Stellenwert haben um dessen Motivation zu fördern und gleichzeitig nicht zu groß sein und wenig oder überhaupt nichts kosten.</p><p>Konsistenz, Häufigkeit und Unmittelbarkeit der Belohnung sind viel wichtiger als der materielle Wert!</p>",
"<p>Nachfolgend sind Beispiele für motivierende Belohnungen angeführt. <b>Wählen Sie zuerst eine Kategorie aus und entscheiden Sie sich dann für eine Belohnung:</b><div>Wichtig: Belohnen Sie ihr Kind ausschließlich <b>nachdem</b> das gewünschte Verhalten gezeigt wurde.</div><div data-role='collapsible' data-content-theme='d' data-collapsed='true' data-collapsed-icon='carat-d' data-expanded-icon='carat-u'><h4>Im Spiel</h4>\n\
<a href='#rewardingame?reward=salad' onclick='customData.data=\"salad\"; customData.referral=window.location.hash' data-role='button' data-theme='b'>Salatblatt<br>Energieschub</a><a href='#rewardingame?reward=snail' onclick='customData.data=\"snail\"; customData.referral=window.location.hash' data-role='button' data-theme='b'>Schnecke<br>Kurzfristige Verlangsamung</a><a href='#rewardingame?reward=sight' onclick='customData.data=\"sight\"; customData.referral=window.location.hash' data-role='button' data-theme='b'>Brille<br>Kurzfristige freie Sicht</a><a href='#rewardingame?reward=life' onclick='customData.data=\"life\"; customData.referral=window.location.hash' data-role='button' data-theme='b'>+1 Leben<br>Ein extra Leben</a></div>\n\
<div data-role='collapsible' data-content-theme='d' data-collapsed='true' data-collapsed-icon='carat-d' data-expanded-icon='carat-u'><h4>Nähe / Zuneigung</h4><h5>Beispiele:</h5><ul><li>In den Arm nehmen</li><li>Über den Kopf oder die Schulter streichen</li><li>Liebevoll durchs Haar wuscheln</li><li>Den Arm um das Kind legen</li><li>Zuzwinkern / lächeln</li><li>Ein 'High Five' geben</li></ul></div>\n\
<div data-role='collapsible' data-content-theme='d' data-collapsed='true' data-collapsed-icon='carat-d' data-expanded-icon='carat-u'><h4>Immaterielle Belohnung</h4><h5>Beispiele:</h5><ul><li>Zeit-zu-Zweit-Verlängerung</li><li>Länger fernsehen</li><li>Länger wach bleiben</li><li>Länger schlafen</li><li>In den Park gehen</li><li>Desser oder Essen auswählen</li><li>Einen Film schauen</li><li>Freunde einladen</li><li>Gemeinsam kochen</li><li>Gemeinsam ein Spiel oder Videospiel spielen</li></ul></div>\n\
<div data-role='collapsible' data-content-theme='d' data-collapsed='true' data-collapsed-icon='carat-d' data-expanded-icon='carat-u'><h4>Materielle Belohnung</h4><h5>Beispiele:</h5><ul><li>Kaugummi / Süßigkeiten</li><li>Ins Kino gehen</li><li>Gemeinsam Sport betreiben</li><li>Kostengünstige Geschenke (Spielzeug, Buch, Aufkleber)</li><li>Eis essen gehen</li></ul></div>\n\
</p>"
]},

{"id": "t4", "title": "4. Strategie", "subTitle": "Effektive Anweisungen", "items":
[
 "<p>Kinder mit Verhaltensproblemen be- kommen meistens mehr Anweisun- gen als andere Kinder. Viel mehr. Sie sind mit den vielen Anweisungen überfordert und können sich nicht an sie halten.</p><p>Was kann ich dagegen tun?</p>",
 "<p>Es ist wichtig Anweisungen <b>sparsam</b> und nur für wichtige Aufgaben zu verwenden.</p><p>Die gegebenen Anweisungen sollten durchgesetzt und bis zu dessen Voll- endung beaufsichtigt werden.</p>",
 "<p>Auch die richtige Kommunikation von Aufgaben und Erwartungen soll- te beachtet werden.</p><p>Wenn Sie Anweisungen geben,</p><ul><li>nehmen Sie Augenkontakt mit Ihrem Kind auf,</li><li>reduzieren Sie die Ablenkungen (machen Sie z.B. das Radio aus) und</li><li>sprechen Sie die Anweisung in einem ruhigen Tonfall aus.</li></ul>",
 "<p>Für effektive Anweisungen verwenden Sie:</p><div><div class='dislike'>Keine Fragen</div><ul><li>Könntest du den Tisch abräumen?</li></ul></div><div><div class='like'>Besser</div><ul><li>Räume jetzt bitte den Tisch ab.</li></ul></div>",
 "<p>Für effektive Anweisungen verwenden Sie:</p><div><div class='dislike'>Keine \"Wir\" oder \"Lass uns\" Anweisungen</div><ul><li>Lass uns dein Zimmer aufräumen.</li></ul></div><div><div class='like'>Besser</div><ul><li>Räume bitte dein Zimmer auf.</li></ul></div>",
 "<p>Für effektive Anweisungen verwenden Sie:</p><div><div class='dislike'>Keine Liste von Aufgaben</div><ul><li>Hol die Zeitung, trag den Müll raus, räum den Tisch ab...</li></ul></div><div><div class='like'>Besser</div><ul><li>Hol mir bitte die Zeitung. [Erst nach Erfüllen der Aufgabe nächste Anweisung geben]</li></ul></div>"

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