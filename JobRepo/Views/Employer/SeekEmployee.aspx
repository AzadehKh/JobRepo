<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<JobRepo.Model.Employee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../../Scripts/jquery.validate.js" type="text/javascript"></script>
	<script src="../../Scripts/JobSeeker-Profile-ClientValidator.js" type="text/javascript"></script>

	<div class="error-container">
	<ul>
	</ul>
	</div>   
     <div class="create">
	<% using (Html.BeginForm()) 
	   {%>
		<fieldset>
			<legend>Fields</legend>

			Keywords:
			<br />

			<div class="editor-field">
				<asp:Literal ID="Literal1" runat="server"></asp:Literal>
				<%: Html.TextBox("Keyword")%>
				use semicolon (;) to separate keywords
			</div>

			<p>
				<input type="submit" value="Seek" />

			</p>
			<p><%: ViewData["Message"]%></p>
		</fieldset>
	<% } %>
    </div>   
	<table>
		<tr>
			<th></th>
			<th>
				FirstName
			</th>
			<th>
				LastName
			</th>
			<th>
				JobTitle
			</th>
		</tr>
		<tr>

	<% if (Model !=null )  foreach (var item in Model) { %>
<%--    
		<tr>
			<td><%: Html.ActionLink("See Details", "EmployeeDetails", "JobSeeker", new { id = item.EmployeeID }) %></td>
			<td>
				<%: item.FirstName %>
			</td>
			<td>
				<%: item.LastName %>
			</td>
			<td>
				<%: item.JobTitle %>
			</td>
		</tr>--%>

		<%--Using PartialView rather than HTML raw table(above) :--%>
		<% Html.RenderPartial("EmployeeDetailPartial",  item); %>
	<% } %>

	</table>

	<br /> 
	<%= Html.ActionLink("See Selected Employee(s)", "List", "SelectedEmployee")%>

</asp:Content>
