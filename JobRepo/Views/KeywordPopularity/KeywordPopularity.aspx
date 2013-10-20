<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	KeywordPopularity
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Services/KeywordService.svc/js" type="text/javascript"></script>
    <script src="../../Scripts/KeywordPopularity.js" type="text/javascript"></script>

    <h2>KeywordPopularity</h2>

    Please select a keyword to view its Popularity:
    <select id="SelectKeyword" >
        <option></option>
    </select>
    
    <br />
    <% Response.WriteSubstitution(ctx => DateTime.Now.ToLongTimeString()); %>
    <br />

    <div id ="KeywordPopularityCount">
    </div>
</asp:Content>
