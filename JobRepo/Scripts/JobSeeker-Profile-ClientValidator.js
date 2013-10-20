/// <reference path="jquery-1.4.1-vsdoc.js" />
/// <reference path="jquery.validate-vsdoc.js" />

$().ready(function () {

//    if ($('div.error-container').length == 0)
//        alert("no element found");
        if ($('.create > form').length == 0)
        alert("no element found");
    $(".create > form").validate({
        errorLabelContainer: $("ul", $('div.error-container')),
        wrapper: 'li',
        rules: {
            Keyword: {
                required: true,
                minLength: 2
            }
        },
        messages: {
            Keyword:
            {
            required: "Please enter keyword/keywords in the box provided",
            minLength: "Keyword must consist of at least 2 characters"
            }
        }
    });
});

