<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<JobRepo.Model.Employee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SelectedEmployees


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SelectedEmployees</h2>
        <script src="../../Scripts/SelectedEmployeeList.js" type="text/javascript"></script>

        <% using (Ajax.BeginForm("List", "SelectedEmployee",
                   new AjaxOptions
                   {
                       UpdateTargetId="SearchResult",
                       HttpMethod = "POST",
                       OnFailure = "searchFailed",
                   }))
           {%>
        <input id="SearchBox" type="text" name="keyword" />
        <input type="submit" value="Search" />
        <br/>
        Search is based on the keywords provided by the employee
    <% } %>
    
    <%= DateTime.Now %> 

    <div id="SearchResult" >
    <% Html.RenderPartial("_AjaxEnabledSelectedEmployee", Model); %>
    </div>
     <br />
    <%: Html.ActionLink("Back to Seek Employee", "SeekEmployee" , "Employer")%>

</asp:Content>

