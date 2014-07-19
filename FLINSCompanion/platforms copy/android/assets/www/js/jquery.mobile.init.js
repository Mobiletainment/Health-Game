(function()
{
    $(document).bind("mobileinit", function()
    {
        $.mobile.allowCrossDomainPages = true;

        $.mobile.loader.prototype.options.text = "Lade";
        $.mobile.loader.prototype.options.textVisible = true;
        $.mobile.loader.prototype.options.theme = "b";
        $.mobile.loader.prototype.options.html = "";

        $.ajaxSetup({
            cache: false
        });

        //$.mobile.activeBtnClass = '.ui-btn-up-b';
        //$.mobile.activeBtnClass = 'unused';

        $('.btn').on('touchend click', function() {
            var self = this;
            setTimeout(function() {
                $(self).removeClass("ui-btn-active");
            },
                    100);
        });
    });
}());