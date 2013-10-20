<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PopularityViewer.aspx.cs" Inherits="JobRepo.PopularityViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-blink.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            font-family: "Times New Roman" , Times, serif;
            font-size: x-large;
            color: #0066CC;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function GetKeywordsPopularity() {
            
            var keyword ="";
            if ($('#txtSearch').val() == '')
                return;
            else {

                keyword = $('#txtSearch').val();
                /*
                Sending a keyword contains "." like ".NET" causes to fail the call
                There were some suggestions to replace invalid characters in the URL 
                explained below but none of the following approaches cannot fix the problem
                As . they do not recognized as invalid character :

                1- If you wish to keep the symbols in the URI, but encode them:
                keyword = encodeURIComponent(keyword);
                2- If you wish to build 'friendly' URIs such as those on blogs:
                keyword = keyword.replace(/[^a-zA-Z0-9-_]/g, '');
                3- keyword =  escape(keyword) and on the server side use
                System.Uri.UnescapeDataString(msg);
                to get the original keyword

                So the only solution is replace "." with a unique word but both [
                and ] are invalid characters so we need encodeURIComponent as well

                */
                keyword = encodeURIComponent(keyword.replace('.', '[keyword]'));
            }

            $.ajax({
                type: "GET",
                url: "Services/KeywordsPopularityRESTServiceHost.svc/" +
                 "KeywordsPopularity/" + keyword,
                dataType: "json",
                contentType: "application/json",
                processdata: false,
                success: function (data) {
                    $("#MainContent_MainContent_lblResult").html("Popularity is " + (data != null ? data.Count : "0"));
                },
                error: function () {
                    alert("Error calling the REST service.");
                }
            });
        }
        /*
        In ASP.NET, it is default nature that if you press the Enter key 
        on any text box, the page wil post back. To stop this
        http://www.codeproject.com/Tips/269388/How-prevent-Textbox-postback-when-hit-enter-key-in
        */
        /* notice that it is NOT necessary to put this function 
          inside the page load event e.g. $(document).ready(function () {});
          and it can be a standalone function
        */
        $(function () {
            $(':text').bind('keydown', function (e) {
                //on keydown for all textboxes
                if (e.keyCode == 13) {
                    //if this is enter key
                    e.preventDefault();
                    return false;
                }
                else
                    return true;

            });
        });
        /*
        function btnSearch_onclick() {
        var service = new JobRepo.Services.KeywordsPopularityRESTService();
        service.GetKeywordsPopularity(document.getElementById("txtSearch").value , 
        onSuccess, onFail, null);
        }
        function onSuccess(result) {
        document.getElementById("lblResult").innerText = result;
        }
        function onFail(result) {
        alert(result);
        }
        */

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
            <h3>
            <strong style="font-weight: 700; color: #336699">Tracking Popularity of Keywords used in JobRepo Search</strong><br />
        <br />
            </h3>
    </div>
    Are you looking for a specific word?
    <br />
    Enter your word:<input id="txtSearch" type="text"/><input id="btnSearch" type="button"
        value ="Give me Popularity" onclick="GetKeywordsPopularity()"  />
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
     <div style="text-align: center;" >
    <asp:Label ID="lblContainer" runat="server" BorderStyle="Solid" 
        BorderWidth="1px"></asp:Label>
        </div>
</asp:Content>
