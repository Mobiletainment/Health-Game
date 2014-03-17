// We use an "Immediate Function" to initialize the application to avoid leaving anything behind in the global scope
(function()
{
    window.username = $.cookie("username");

    window.customData = {data: "", referral: ""};

    window.currentView;
    window.dict = {};

    Handlebars.registerHelper("inc", function(value, options)
    {
        return parseInt(value) + 1;
    });

    Handlebars.registerHelper('ifCond', function(v1, operator, v2, options) {

        switch (operator) {
            case '==':
                return (v1 == v2) ? options.fn(this) : options.inverse(this);
            case '===':
                return (v1 === v2) ? options.fn(this) : options.inverse(this);
            case '<':
                return (v1 < v2) ? options.fn(this) : options.inverse(this);
            case '<=':
                return (v1 <= v2) ? options.fn(this) : options.inverse(this);
            case '>':
                return (v1 > v2) ? options.fn(this) : options.inverse(this);
            case '>=':
                return (v1 >= v2) ? options.fn(this) : options.inverse(this);
            case '&&':
                return (v1 && v2) ? options.fn(this) : options.inverse(this);
            case '||':
                return (v1 || v2) ? options.fn(this) : options.inverse(this);
            default:
                return options.inverse(this);
        }
    });

    var toastStack =  {"dir1": "right", "dir2": "up", "push": "top"};

    /* ---------------------------------- Local Variables ---------------------------------- */

    var adapter = new LocalStorageAdapter();
    adapter.initialize().done(function() {
        console.log("Data adapter initialized");
        //route();

    });

    /* --------------------------------- Event Registration -------------------------------- */
    document.addEventListener('deviceready', function() {
        FastClick.attach(document.body);

        if (navigator.notification)
        { // OverÏride default HTML alert with native dialog
            window.alert = function(message, callback)
            {
                navigator.notification.alert(
                        message, // message
                        callback, // callback
                        "Fehler", // title
                        'OK'        // buttonName
                        );
            };
        }

        successFunction = function()
        {
            console.log("Testflight started successfully");
        }

        failedFunction = function()
        {
            console.log("Testflight failed to start");
        }

        var tf = new TestFlight();
        tf.takeOff(successFunction, failedFunction, "029ece91-ccbf-4e5e-8ed0-3b012f5fb854");



    }, false);

    $(document).ready(function()
    {
        console.log("Document ready");
        $.pnotify.defaults.styling = "jqueryui";
        $.pnotify.defaults.history = false;
        //document.location.hash = "#welcome";

    });

    $(document).bind("pagebeforechange", function(e, data)
    {
        console.log("Intercepting pagebeforechange");
        if (typeof data.toPage === "string") {

            // We are being asked to load a page by URL, but we only
            // want to handle URLs that request the data for a specific
            // category.
            console.log("Checking if training is navigated");
            var u = $.mobile.path.parseUrl(data.toPage);
            //document.location.hash = u.hash;

            if (u.hash.search(/^#train-content/) !== -1)
            {
                console.log("We'd like to navigate to training content");
                showTrainingContent(u, data.options);

                //e.preventDefault();
            }
            else if (u.hash.search(/^#training$/) !== -1)
            {
                console.log("We'd like to navigate to training");
                //showTrainingOverview();
            }
        }
    });

    // Start: Main Menu
    $("#main-menu").on("pagebeforecreate", function(event)
    {
        showTrainingOverview();

        var progressLabel = $("#progressLabelMain");
        var selector = "#progressbarMain";
        var progressbar = $(selector);

        progressbar.progressbar({
            value: false,
            change: function() {
                var value = progressbar.progressbar("value");

                progressLabel.text("Fortschritt: " + value + "%");
            }
        });

        progressbar.height("20");


        $(selector).bind('progressbarchange', function(event, ui) {
            var subSelector = selector + " > div";
            var value = this.getAttribute("aria-valuenow");
            if (value < 10) {
                $(subSelector).css({'background': 'Red'});
            } else if (value < 30) {
                $(subSelector).css({'background': 'Orange'});
            } else if (value < 50) {
                $(subSelector).css({'background': 'Yellow'});
            } else if (value < 80) {
                $(subSelector).css({'background': 'LightGreen'});
            }
            else {
                $(subSelector).css({'background': '#33CC00'});
            }
        });

        progressbar.progressbar("value", 0);
        loadTrainingProgress();
    });

    $("#main-menu").on("pagebeforeshow", function(event)
    {
       
    });
    // End: Main Menu

    // Start: Daily Inputs: Tasks
    $("#daily-inputs-tasks").on("pagebeforecreate", function(event)
    {
        hash = "daily-inputs-tasks";
        window.currentView = new DailyInputsTasksView();
    });

    $("#daily-inputs-tasks").on("pagebeforeshow", function(event)
    {
        window.currentView.loadData();
    });
    // END: Daily Inputs: Taks


    // Start: Daily Tasks Input
    $("#daily-tasks-input").on("pagebeforecreate", function(event)
    {
        hash = "daily-tasks-input";
        console.log("Redirecting to Daily Tasks Input");
        adapter.findById(hash).done(function(item)
        {
            console.log("Daily Tasks Input Items found: " + item);
            window.currentView = new DailyTasksInputView(adapter, item);
        });
    });

    // End: Daily Tasks Input

    // Start: Data Input Behavior
    $("#data-input-behavior-rating").on("pagebeforecreate", function(event)
    {
        showBehaviorInputRatingView();
    });

    $("#data-input-behavior-rating").on("pagebeforeshow", function(event)
    {
        window.currentView.setupContent();
    });
    // End: Data Input Behavior


    // Start: Daily Inputs: Benchmark
    $("#daily-inputs-benchmark").on("pagebeforecreate", function(event)
    {
        function saveData()
        {
            var func = this;

            $.mobile.loading('show', {
                text: 'Bewertung wird gespeichert...'
            });

            $.getJSON("http://tnix.eu/~aspace/SaveData.php",
                    {
                        username: window.username,
                        action: "SaveInputBenchmarkData",
                        data: $("#daily-inputs-benchmark").find("#sliderBenchmark").val()
                    },
            function(data)
            {
                console.log("Server responded: " + data.returnCode + "; " + data.returnMessage);
                var currentPage = window.location.href.split('#')[0];
                window.location.href = currentPage + "#daily-inputs-menu";
                showToast('Verhaltensmaßstab gespeichert');

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });
        }

        //Click
        $("#daily-inputs-benchmark").find("#sendDailyInputsBenchmark").click(function()
        {
            saveData();
        });
    });
    
    // Start: Data Input Behavior
    $("#daily-inputs-selfcontrol").on("pagebeforecreate", function(event)
    {
        $("#daily-inputs-selfcontrol").find("#sendSelfcontrolData").click(function()
        {
            alert("Noch nicht implementiert");
        });
    });


    $("#data-input-behavior").on("pagebeforecreate", function(event)
    {
        //alert( "This page was just inserted into the dom!" );
        showBehaviorInputView();
    });

    $(document).on("pagebeforeshow", "#timeout", function(e, data)
    {
        $("#sendTimeOut").parent().hide();
        $.mobile.loading('show', {
            text: 'Auszeit-Ort wird geladen...'
        });
        $.getJSON("http://tnix.eu/~aspace/Timeout.php",
                {
                    username: window.username,
                    action: "LoadTimeout",
                },
                function(data)
                {
                    console.log("Data for Timeout received " + data.returnCode + ": " + data.returnData);
                    if (data.returnCode == 200)
                        $("#timeOutLocation").val(data.returnData);

                    $.mobile.loading("hide");
                });

        $("#sendTimeOutForm").validate({
            rules: {
                timeOutLocation: {
                    required: true,
                    minlength: 2
                }
            },
            messages: {
                timeOutLocation: "Geben Sie einen Auszeit-Ort an"
            },
            submitHandler: sendTimeOut
        });

        $("#timeout").find("#timeOutSaveAndEnd").click(function()
        {
            $("#sendTimeOut").trigger("click");
            return false;
        });

        function sendTimeOut() {
            var func = this;
            console.log("sending timeout");

            $.mobile.loading('show', {
                text: 'Auszeit-Ort wird gespeichert...'
            });

            $.getJSON("http://tnix.eu/~aspace/Timeout.php",
                    {
                        username: window.username,
                        action: "SaveTimeout",
                        data: $("#timeOutLocation").val()
                    },
            function(data)
            {
                console.log("Server responded");
                showToast("Auszeit-Ort gespeichert");
                saveTrainingProgress("t6");
            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });


            return false; //prevent event propagation
        }
        ;
    });

    $(document).on("pagebeforeshow", "#data-input-person", function(e, data)
    {
        $("#submitPerson").parent().hide();

        $("#personForm").validate({
            rules: {
                radioGender: {
                    required: true
                },
                personMail: {
                    required: true
                },
                personBirthDateChild: {
                    required: true
                }
            },
            messages: {
                personMail: "Geben Sie eine gültige E-Mail Adresse an",
                personBirthDateChild: "Geben Sie das Geburtsdatum an",
                radioGender: ""
            },
            submitHandler: sendPersonData
        });

        $("#sendPersonDataButton").click(function()
        {
            console.log("Person submit");
            $("#submitPerson").trigger("click");
            return false;
        });

        function sendPersonData() {
            console.log("sending person data");

            var func = this;

            $.mobile.loading('show', {
                text: 'Daten werden gespeichert...'
            });


            $.getJSON("http://tnix.eu/~aspace/SaveData.php",
                    {
                        username: window.username,
                        action: "SavePersonData",
                        data: {gender: $("#gender :radio:checked").val(), mail: $("#personMail").val(), date: $("#personBirthDateChild").val()}
                    },
            function(data)
            {
                console.log("Server responded");
                var currentPage = window.location.href.split('#')[0];
                showToast("Daten wurden gespeichert");
                window.location.href = currentPage + "#data-input-behavior-intro";

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", func);
            }).always(function() {
                $.mobile.loading("hide");
            });


            return false; //prevent event propagation
        }
        ;

    });



    //Super important: enhancing the layout that got dynamically added. Only way I found working
    $(document).on("pagebeforeshow", "#training", function(event)
    {
        $("#training").find(":jqmData(role=listview)").listview().listview("refresh");
    });

    $(document).on("pagebeforeshow", "#rewardingame", function(e, data)
    {
        //var parameters = data("url").split("?")[1];;
        // parameter = parameters.replace("parameter=","");  
        //  document.location.hash = u.hash;

        $("#rewardImage").attr("src", "img/reward/" + customData.data + ".png");
        $("#rewardBackNavigation").attr("href", "index.html" + customData.referral);
        $("#sendInGameForm").validate({
            rules: {
                rewardMessage: {
                    required: true,
                    minlength: 2
                }
            },
            messages: {
                rewardMessage: "Sie haben keine Belohnungs-Nachricht eingegeben"
            },
            submitHandler: sendReward
        });

        function sendReward() {
            //  event.preventDefault();
            //$( "#rewardingame").find('[data-role="main"]').trigger("create");
            //alert("Submit");
            console.log("sending reward");
            var that = sendReward;

            $.mobile.loading('show', {
                text: 'Belohnung wird gesendet...'
            });

            $.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
                    {
                        username: window.username,
                        action: "life"
                    },
            function(data)
            {
                console.log("Server responded");

                //$.mobile.loading("hide");
                showToast('Belohnung gesendet');

                document.location.hash = "#training";

            }).fail(function()
            {
                alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", that);
            }).always(function() {
                $.mobile.loading("hide");
            });
            ;

            return false; //prevent event propagation
        }
        ;

    });


    function showTrainingOverview()
    {
        hash = "training";
        console.log("Redirecting to training");
        adapter.findById(hash).done(function(item)
        {
            console.log("Training Items found: " + item);
            var trainingView = new TrainingView(adapter, item);

        });
    }
    ;

    function showBehaviorInputView()
    {
        hash = "data-input-behavior";
        console.log("Redirecting to Input Behavior");
        adapter.findById(hash).done(function(item)
        {
            console.log("Behavior Input Items found: " + item);
            var behaviorView = new BehaviorInputView(adapter, item);
            $("#data-input-behavior").find(":jqmData(role=main)").trigger("create");
        });
    }
    ;

    function showBehaviorInputRatingView()
    {
        hash = "data-input-behavior";
        console.log("Redirecting to Input Rating Behavior");
        adapter.findById(hash).done(function(item)
        {
            console.log("Behavior Input Items found: " + item);
            window.currentView = new BehaviorRatingView(adapter, item);
            //$("#data-input-behavior-rating").find(":jqmData(role=main)").trigger("create");
        });
    }
    ;
    function showTrainingContent(urlObj, options)
    {
        //Content Templates

        var chapter = urlObj.hash.replace(/.*chapter=/, "")
        var pageSelector = urlObj.hash.replace(/\?.*$/, "");
        var $page = $(pageSelector);

        console.log("Loading training chapter: " + chapter);
        adapter.findById(chapter).done(function(item) {
            console.log("Loading Chapter: " + item.id);
            var trainingContentView = new TrainingContentView(adapter, item);
            trainingContentView.loadContent("showTrainingContent");

            // Pages are lazily enhanced. We call page() on the page
            // element to make sure it is always enhanced before we
            // attempt to enhance the listview markup we just injected.
            // Subsequent calls to page() are ignored since a page/widget
            // can only be enhanced once.
            $page.page();

            //$page.trigger("refresh");
            $page.find(":jqmData(role=main)").trigger("create");


            //$page.find(":jqmData(role=listview)").listview().listview("refresh");
            //$("#training-content-main").trigger("create");
            $page.find(":jqmData(role=footer)").trigger("create");
            $page.trigger('pagecreate');

            // We don't want the data-url of the page we just modified
            // to be the url that shows up in the browser's location field,
            // so set the dataUrl option to the URL for the category
            // we just loaded.
            console.log("UrlObjHref = " + urlObj.href + ", hash = " + urlObj.hash);
            options.dataUrl = urlObj.href;
            document.location.hash = urlObj.hash;

            // Now call changePage() and tell it to switch to
            // the page we just modified.
            $.mobile.changePage($page, options);
        });
    }
    ;

    saveTrainingProgress = function(chapterId)
    {
        var func = this;
        $.mobile.loading('show', {
            text: 'Speichere Fortschritt'
        });

        console.log("Saving progress for chapter: " + chapterId);

        $.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
                {
                    username: window.username,
                    action: "SaveProgress",
                    chapter: chapterId
                },
        function(data)
        {
            updateTrainingProgress(data);

            console.log("Server responded");
            //alert(data.returnData);
            //$.mobile.loading("hide");
            var currentPage = window.location.href.split('#')[0];

            window.location.href = currentPage + "#training";
        }
        ).fail(function()
        {
            alert("Die Internetverbindung ist unterbrochen. Fortschritt kann nicht gespeichert werden. Erneut versuchen?", func);
        }).always(function() {
            $.mobile.loading("hide");
        });

    };

    loadTrainingProgress = function()
    {
        console.log("this.loadTrainingProgress");
        $.mobile.loading('show', {
            text: 'Lade Fortschritt'
        });

        $.getJSON("http://tnix.eu/~aspace/TrainingProgress.php",
                {
                    username: window.username,
                    action: "GetProgress"
                },
        function(data)
        {
            updateTrainingProgress(data);



        }).fail(function()
        {
            alert("Die Internetverbindung ist unterbrochen. Erneut versuchen?", loadTrainingProgress);
        }).always(function() {
            $.mobile.loading("hide");
        });
        
        
    };

    updateTrainingProgress = function(data)
    {
        console.log("Server responded");

        var imgId = '#imgDone_';
        var total = 0;
        var completed = 0;

        $.each(data.returnData, function(key, val)
        {
            ++total;

            if (val === true)
            {
                ++completed;
                $(imgId + key).attr("src", "img/checkbox_done.png");
            }
        });
        console.log("Total: " + total);
        console.log("Progressbar : " + $("#progressbar").progressbar("value"));

        if (completed > 0 && total > 0)
        {
            $("#progressbar").progressbar('value', Math.round(completed * 100 / total));
            $("#progressbarMain").progressbar('value', Math.round(completed * 100 / total));
        }
        else
        {
            $("#progressbar").progressbar('value', 0);
            $("#progressbarMain").progressbar('value', 0);
        }
        
        showToast("Trainingsfortschritt aktualisiert");
    };

    showToast = function(message)
    {
        var opts = {
            title: message,
          //  text: message,
            type: "success",
            stack: toastStack,
            addclass: "stack-bottomleft ui-icon-alt"
        };
        
        $.pnotify(opts);
           
    };
}());