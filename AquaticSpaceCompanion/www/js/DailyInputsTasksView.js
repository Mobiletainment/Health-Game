var dailyInputsTasksContentTpl = Handlebars.compile($("#daily-inputs-tasks-tpl").html());

var DailyInputsTasksView = function()
{
    var that = this;
    var container = "#dailyInputsTasksContent";
    var data = {};
    var dict = {}

    this.initialize = function()
    {

        function saveData()
        {
            var func = this;

            $.mobile.loading('show', {
                text: 'Daten werden gespeichert...'
            });

            $.getJSON("http://tnix.eu/~aspace/SaveData.php",
                    {
                        username: window.username,
                        action: "SaveInputTasksData",
                        data: data
                    },
            function(data)
            {
                console.log("Server responded: " + data.returnCode + "; " + data.returnMessage);
                var currentPage = window.location.href.split('#')[0];
                window.location.href = currentPage + "#main-menu";
                $.fn.dpToast('Erledigte Aufgaben gespeichert', 4000);

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });
        }

        //Click
        $("#daily-inputs-tasks").find("#sendDailyInputsTasks").click(function()
        {
            window.dict = {};
            var totalChecks = 0;

            //Custom Check Boxes
            var index = 1;

            $(container).find('.customListSeparator').each(function()
            {
                totalChecks++;
                
                if (this.checked)
                {   
                    data[$(this).next().find(".ui-btn-text").text()] = 1;
                }
                else
                {   
                    data[$(this).next().find(".ui-btn-text").text()] = 0;
                }

            });

            saveData();

        });

        //loadData();
        return this;
    };

    this.loadData = function()
    {
        var func = this;

        $.mobile.loading('show', {
            text: 'Aufgaben werden geladen...'
        });

        $.getJSON("http://tnix.eu/~aspace/SaveData.php",
                {
                    username: window.username,
                    action: "LoadDailyTasksData",
                    data: dict
                },
        function(data)
        {
            console.log("Server responded for Input Tasks Data: " + data.returnCode);
            if (data.returnCode === 200)
            {
                var items = new Array();

                $.each(data.returnData, function(key, val)
                {
                    if (!val)
                        return false;

                    items.push(val);
                });

                $(container).html(dailyInputsTasksContentTpl(items));
                $(container).trigger("create");
            }
        }).fail(function()
        {
            alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
        }).always(function() {
            $.mobile.loading("hide");
        });
    };

    this.initialize();
};