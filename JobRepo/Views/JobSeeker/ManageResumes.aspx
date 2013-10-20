<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<JobRepo.Model.ResumeDTO>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<%@ Import Namespace="MvcContrib.UI.Grid.ActionSyntax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ManageResumes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/jscript">
    $(document).ready(function () {
        $('#grdResumes').dataTable({
            "iDisplayLength": 15,
            "aaSorting": [[2, "asc"]]
            //The following setting raises an error if the grid doesn't have any row
//           , "aoColumns": [{ "bSortable": false }, null,
//            null, null]
        });
    });
</script>
    <h2>ManageResumes</h2>
     
    <% Html.Grid(Model)
            .Columns(column =>
            {
                column.For(c =>  Html.ActionLink("Delete", "DeleteResume", new { id = c.resumeID } ,
                     new { onclick = "return confirm('Do you really want to delete this resume?')" })).Encode(false);
                column.For(c => c.Title);
                column.For(c => c.Keywords).Named("Skills").Attributes( width => "600px");
//                column.For(c => String.Format("{0:g}", c.PostedDate));
//                column.For(c => c.PostedDate).Format("{0:g}");
                column.For(c => c.PostedDate.Year);
            }).Attributes(@class => "display", @id => "jtable").Attributes(id => "grdResumes").Render();
       %>

    <%--Using MvcContrib.Grid rather than HTML raw table(above) :--%>
<%--    <table>
        <tr>
            <th></th>
            <th>
                Title
            </th>
            <th>
                Skills
            </th>
            <th>
                PostedDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ResumeID })%>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td  style="width: 600px">
                <%: item.Keywords %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.PostedDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>
--%>
    <p>
        <%: Html.ActionLink("Create New", "UploadResume")%>
    </p>

</asp:Content>

