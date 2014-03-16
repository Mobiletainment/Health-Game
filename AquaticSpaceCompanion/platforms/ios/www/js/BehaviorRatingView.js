var BehaviorRatingView = function(adapter, data)
{

    var page = 0;
    var dict = {};
    var that = this;

    var behaviors = [];


    this.setupContent = function()
    {
        var url = $.url().attr("anchor");
        behaviors = [$.url(url).param("q1"), $.url(url).param("q2"), $.url(url).param("q3")];


        $("#behaviorProblem").text(behaviors[page]);
        $("#pageIndexBehavior").text(page + 1);
        if (page > 0)
            $("#slider").val(5).slider("refresh");
    };


    this.initialize = function()
    {

        $("#behaviorInputBack").click(function()
        {
            if (page === 0)
            {
                dict = {};
                window.history.back();
            }
            else
            {
                //delete dict[behaviors[page]];
                --page;
                that.setupContent();
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
                        action: "SaveBehaviorData",
                        data: dict
                    },
            function(data)
            {
                console.log("Server responded");
                var currentPage = window.location.href.split('#')[0];
                window.location.href = currentPage + "#daily-tasks-input-intro";
                $.fn.dpToast('Bewertungen gespeichert', 4000);

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });
        }

        $("#sendBehaviorRatingInput").click(function()
        {
            page++;
            if (page === 3)
            {
                saveData();
            }
            else
            {
                dict[behaviors[page]] = $("#slider").val();
                that.setupContent();
            }


            return false;

        });


        return this;
    };

    this.initialize();
};