<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JobRepo.Model.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    function OnSuccessCallback() {
        //Both work
       // $('#lblSelectList').hide();
        $(this).hide();
    }
</script>
    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">JobTitle</div>
        <div class="display-field"><%: Model.JobTitle %></div>

        <div class="display-label">FirstName</div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field"><%: Model.LastName %></div>
        
        <div class="display-label">Phone</div>
        <div class="display-field"><%: Model.Phone %></div>
        
        <div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
    </fieldset>

    <div id ="BusyIndicator" style="display:none" >
        <img alt="Please wait..." src="../../Content/busyindicator.gif" />      
    </div>
    <p id="lblSelectList">
    <%= Ajax.ActionLink("Add to the selected list", "SelectEmployee", "JobSeeker" 
    , new {employeeID =Model.EmployeeID} ,
    new AjaxOptions {
        LoadingElementId ="BusyIndicator",
        Confirm="Are you sure you want to select this employee?",
        HttpMethod="GET",
        UpdateTargetId = "lblConfirmed",
        OnSuccess = "OnSuccessCallback"
        })
    %>
    </p>
    <p id="lblConfirmed"></p>
    <%: Html.ActionLink("Back to List", "SeekEmployee" , "Employer")%>
    <br /> 
    <%= Html.ActionLink("See Selected Employee(s)", "List", "SelectedEmployee")%>


</asp:Content>

