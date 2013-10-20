<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<JobRepo.Model.Employee>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UpdateProfile
    
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>UpdateProfile</h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FirstName) %>
                <%: Html.ValidationMessageFor( model => model.FirstName ,"*") %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastName) %>
                <%: Html.ValidationMessage("LastName", "*")%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Phone, "*") %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email, "*") %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JobTitle) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.JobTitle) %>
                <%: Html.ValidationMessageFor(model => model.JobTitle, "*") %>
            </div>
            <p>
                <%= Html.ActionLink("Manage Resumes", "ManageResumes" )%>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

         <%: Html.ValidationSummary(false) %>


    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

