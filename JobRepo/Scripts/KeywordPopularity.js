/// <reference path="jquery-1.4.1-vsdoc.js" />
/// <reference path="jquery.validate-vsdoc.js" />

$().ready(function () {

    $.getJSON("/KeywordPopularity/Keywords", "", function (data) {
        $(data).each(function () {
            $('<option>').val(this.ID).text(this.Name)
                    .appendTo('#SelectKeyword');
        });

    });


    $("#SelectKeyword").change(function () {

        var val = $("#SelectKeyword").val();
        //if (parseInt(val)) {
        if (val != "") {
            //Approach #1:
            //$.getJSON("/KeywordPopularity/KeywordCount/", { Keyword: val }, function (data) {

            //Approach #2:
//            var service = new tempuri.org.IKeywordService();
//            service.KeywordCount(val, function (data) 
//            {
//                var list = $("<ul></ul>");
//                $(data).each(function () {
//                    $("<li>" + this.Keyword + " <br /> Popularity : " + this.Count + "</li> <br /> ").appendTo(list);
//                });

//                $("#KeywordPopularityCount").html(list);
//            });

            //Approach #3:
            $.post("/KeywordPopularity/KeywordCount/", { Keyword: val }, function (data) {
                $("#KeywordPopularityCount").html(data);
            });

        }

    });

});