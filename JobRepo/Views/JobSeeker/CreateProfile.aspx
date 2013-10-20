<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JobRepo.Model.EmployeeDTO>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CreateProfile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<script src="../../Scripts/jquery.validate-vsdoc.js" type="text/javascript"></script>
	<script src="../../Scripts/JobSeeker-Profile-ClientValidator.js" type="text/javascript"></script>

	<h2>CreateProfile</h2>
		<div class="error-container">
	<ul>
	</ul>
	</div>
    <div class="create">
	<% using (Html.BeginForm()) 
	   {%>
       <% = Html.AntiForgeryToken() %>
		<%: Html.ValidationSummary(false)%>

		<fieldset>
			<legend>Account Details: </legend>
			<div class="editor-label">
				<%: Html.LabelFor(model => model.UserName)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.UserName)%>
				<%: Html.ValidationMessageFor(model => model.UserName, "*")%>
			</div>


            <div class="editor-label">
				<%: Html.LabelFor(model => model.Password)%>
			</div>
			<div class="editor-field">
				<%: Html.PasswordFor(model => model.Password)%>
				<%: Html.ValidationMessageFor(model => model.Password, "*")%>
			</div>

			<div class="editor-label">
				<%: Html.LabelFor(model => model.Question1)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Question1)%>
				<%: Html.ValidationMessageFor(model => model.Question1, "*")%>
			</div>


            <div class="editor-label">
				<%: Html.LabelFor(model => model.Answer1)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Answer1)%>
				<%: Html.ValidationMessageFor(model => model.Answer1, "*")%>
			</div>

			<div class="editor-label">
				<%: Html.LabelFor(model => model.Question2)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Question2)%>
				<%: Html.ValidationMessageFor(model => model.Question2, "*")%>
			</div>


            <div class="editor-label">
				<%: Html.LabelFor(model => model.Answer2)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Answer2)%>
				<%: Html.ValidationMessageFor(model => model.Answer2, "*")%>
			</div>


			<legend>Other Details: </legend>
			<div class="editor-label">
				<%: Html.LabelFor(model => model.FirstName)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.FirstName)%>
				<%: Html.ValidationMessageFor(model => model.FirstName, "*")%>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.LastName)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.LastName)%>
				<%: Html.ValidationMessage("LastName", "*")%>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.Phone)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Phone)%>
				<%: Html.ValidationMessageFor(model => model.Phone, "*")%>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.Email)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.Email)%>
				<%: Html.ValidationMessageFor(model => model.Email, "*")%>
			</div>
			
			<div class="editor-label">
				<%: Html.LabelFor(model => model.JobTitle)%>
			</div>
			<div class="editor-field">
				<%: Html.TextBoxFor(model => model.JobTitle)%>
				<%: Html.ValidationMessageFor(model => model.JobTitle, "*")%>
			</div>
			
			<p>
				<input type="submit" value="Create" />
			</p>
		</fieldset>

	<% } %>
    </div>
	<div>
		<%: Html.ActionLink("Back to List", "Index") %>
	</div>

</asp:Content>

