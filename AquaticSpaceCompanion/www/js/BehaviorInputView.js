var behaviorContentTpl = Handlebars.compile($("#checkbox-tpl").html());

var BehaviorInputView = function(adapter, data)
{
    this.initialize = function()
    {
	$("#checkBoxContent").html(behaviorContentTpl(data));

	$("#checkBoxContent").find(".customCheckbox").bind("change", function(event, ui)
	{
	    if (this.checked)
		$(this).next().find("textArea").removeClass('ui-body-c').addClass('ui-body-d');
	    else
		$(this).next().find("textArea").removeClass('ui-body-d').addClass('ui-body-c');
	});


	$("#checkBoxContent").find("textarea").blur(function()
	{
	    if (!$.trim($(this).val()))
	    {
		$(this).parentsUntil(".ui-checkbox").prev().prop("checked", false).checkboxradio("refresh");
	    }
	});

	$("#data-input-behavior").find("#sendBehaviorInput").click(function()
	{
            var totalChecks = 0;
	    //TODO: very database-bound structure, declouping needed

	    //gather the values of the standard checkboxes
	    var checkboxFeedback = "";
	    var attributes = "";

	    $("#checkBoxContent").find('.customListSeparator').each(function()
	    {
		if (this.checked)
		{
		    checkboxFeedback += "true,";
		    totalChecks++;
		    //attributes += "q" + totalChecks + "=" + $(this).next().find(".ui-btn-text").text() + "&";
                    window.dict["q" + totalChecks] = $(this).next().find(".ui-btn-text").text();
		}
		else
		{
		    checkboxFeedback += "false,";
		}

	    });

	    if (checkboxFeedback.length > 0)
	    {
		checkboxFeedback = checkboxFeedback.substring(0, checkboxFeedback.length - 1);
	    }


	    //gather the values of the custom checkboxes
	    var customFeedbackValues = "";
	    var customFeedbackColumns = "";

	    var index = 1;
	    $("#checkBoxContent").find("textarea").each(function()
	    {
                var textArea = $(this);
                
		if ($(this).parentsUntil(".ui-checkbox").prev().prop("checked") === true)
		{
		    customFeedbackColumns += "customFeedback" + index + ",";
		    customFeedbackValues += "'" + $(this).val() + "',";
		    totalChecks++;
                    //attributes += "q" + totalChecks + "=" + textArea.val() + "&";
                    window.dict["q" + totalChecks] = textArea.val();
		}

		index++;
	    });

	    if (totalChecks !== 3)
	    {
		alert("Bitte wählen Sie 3 unerwünschte Verhaltensweisen aus.");
	    }
	    else
	    {
		if (customFeedbackColumns.length > 0)
		    customFeedbackColumns = customFeedbackColumns.substring(0, customFeedbackColumns.length - 1);

		if (customFeedbackValues.length > 0)
		    customFeedbackValues = customFeedbackValues.substring(0, customFeedbackValues.length - 1);
                
                if (attributes.length > 0)
                    attributes = attributes.substring(0, attributes.length - 1);

		window.location.hash = "#data-input-behavior-rating?p=0";
                
	    }
            
            return false;
	});
	return this;
    };

    this.initialize();
};