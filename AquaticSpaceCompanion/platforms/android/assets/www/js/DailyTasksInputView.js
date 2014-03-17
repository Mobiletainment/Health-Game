var dailyTasksContentTpl = Handlebars.compile($("#daily-tasks-tpl").html());

var DailyTasksInputView = function(adapter, data)
{
    var dict;
    var that = this;
    
    this.initialize = function()
    {
        var container = "#dailyTasksContent";

        $(container).html(dailyTasksContentTpl(data));

        $(container).find(".customCheckbox").bind("change", function(event, ui)
        {
            if (this.checked)
                $(this).next().find("textArea").removeClass('ui-body-c').addClass('ui-body-d');
            else
                $(this).next().find("textArea").removeClass('ui-body-d').addClass('ui-body-c');
        });


        $(container).find("textarea").blur(function()
        {
            if (!$.trim($(this).val()))
            {
                $(this).parentsUntil(".ui-checkbox").prev().prop("checked", false).checkboxradio("refresh");
            }
        });

        function saveData()
        {
            var func = this;

            $.mobile.loading('show', {
                text: 'Daten werden gespeichert...'
            });

            $.getJSON("http://tnix.eu/~aspace/SaveData.php",
                    {
                        username: window.username,
                        action: "SaveDailyTasksData",
                        data: dict
                    },
            function(data)
            {
                console.log("Server responded");
                var currentPage = window.location.href.split('#')[0];
                showToast('Aufgaben gespeichert');
                window.location.href = currentPage + "#first-aid-bag";
                

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });
        }

        //Click
        $("#daily-tasks-input").find("#sendDailyTasks").click(function()
        {
            dict = new Array();
            var totalChecks = 0;
            //TODO: very database-bound structure, declouping needed

            //gather the values of the standard checkboxes
           
            //gather the values of the custom checkboxes
           

            //Custom Check Boxes
            var index = 1;
            $(container).find("textarea").each(function()
            {
                var textArea = $(this);

                if ($(this).parentsUntil(".ui-checkbox").prev().prop("checked") === true)
                {
                    dict.push(textArea.val());
                    totalChecks++;
                }

                index++;
            });


            $(container).find('.customListSeparator').each(function()
            {
                if (this.checked)
                {
                    totalChecks++;
                    dict.push($(this).next().find(".ui-btn-text").text());
                }

            });

            if (totalChecks < 1)
            {
                alert("Bitte wählen Sie zumindest eine Aufgabe aus");
            }
            else if (totalChecks > 10)
            {
                alert("Bitte wählen Sie nicht mehr als 10 Aufgaben aus");
            }
            else
            {
                saveData();
            }
        });
        return this;
    };

    this.initialize();
};