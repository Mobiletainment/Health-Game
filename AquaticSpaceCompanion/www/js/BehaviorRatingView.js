var BehaviorRatingView = function(adapter, data)
{
    this.initialize = function()
    {
        var url = $.url().attr("anchor");
        var page = 0;

        var behaviors = [$.url(url).param("q1"), $.url(url).param("q2"), $.url(url).param("q3")];
        var dict = {};

        function setupContent()
        {
            $("#behaviorProblem").text(behaviors[page]);
            $("#pageIndexBehavior").text(page+1);
            if (page > 0)
                $("#slider").val(5).slider("refresh");
        }

        setupContent();
        
        $("#behaviorInputBack").click(function()
        {
           if (page === 0)
           {
               window.history.back();
           }
           else
           {
               --page;
                setupContent();
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
                $.fn.dpToast('Bewertungen gespeichert', 4000);
                window.location.href = currentPage + "#daily-tasks-input-intro";

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });
        }

        $("#sendBehaviorRatingInput").click(function()
        {
            if (page === 3)
            {
                saveData();
            }
            else
            {
                dict[behaviors[page]] = $("#slider").val();
                setupContent();
            }
            
            page++;
            return false;

        });


        return this;
    };

    this.initialize();
};