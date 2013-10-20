<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top10Job.ascx.cs" 
Inherits="JobRepo.User_Controls.Top10Job" %>
<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-blink.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $(document).ajaxError(function (e, xhr, settings, exception) {
            alert('Response code: ' + xhr.status + ' \n Status: ' + xhr.statusText + ' \n ' + 'Exception: ' + exception + '\n Response text : \n' + xhr.responseText);
        }); 
        var selectedjob = '<%= HttpContext.Current.Session == null ? "" : HttpContext.Current.Session["SelectedJob"].ToString() %>';

        $.ajax({
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            url: "Services/TopTenWcfDataService.svc/Get10TopJobs?selectedjob='" + selectedjob + "'",
            success: function (data) {



                $.each(data.d.results, function (i, item) {

                    /* 
                    There is another way to loop through the items:
                    jQuery.each(data.d.results, function () {
                    alert(this.Title);
                    });
                    */

                    $("<a Target='_blank' href=JobReviewer.aspx?JJ=" + item.JobID + "/>")
                        .html(item.Title).appendTo("#lstContainer");

                    /* instead of using .html() , you can use the following code: */
                    /*
                    $("<a Target='_blank' href=JobReviewer.aspx?JJ=" + item.JobID + ">" + item.Title + "</a>")
                    .appendTo("#lstContainer");
                    */
                    $("</br>").appendTo("#lstContainer");

                });
            },
            error: function () {
                alert("Error calling the WCF Data Service.");
            }
        });

    });
 
</script>
<div id="lstContainer"></div>
