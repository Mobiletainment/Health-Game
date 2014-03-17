var BehaviorRatingView = function(adapter, data)
{

    var page = 0;
    var that = this;
    var data = {};

    this.setupContent = function()
    {
        var stringPage = page+1;
        
        $("#behaviorProblem").text(window.dict["q" + stringPage]);
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
                window.dict = {};
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
                        data: data
                    },
            function(data)
            {
                console.log("Server responded: "+ data.debugInfo);
                var currentPage = window.location.href.split('#')[0];
                showToast('Verhaltensweisen gespeichert');
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
            page++;
            data[window.dict["q" + page]] = $("#slider").val();
            if (page === 3)
            {
                saveData();
            }
            else
            {
                
                that.setupContent();
            }


            return false;

        });


        return this;
    };

    this.initialize();
};