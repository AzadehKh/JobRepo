<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JobRepo.Model.Employee>" %>

<tr>
    <td><%: Html.ActionLink("See Details", "EmployeeDetails", "JobSeeker", new { id = Model.EmployeeID } , null)%></td>
    <td>
        <%: Model.FirstName%>
    </td>
    <td>
        <%: Model.LastName%>
    </td>
    <td>
        <%: Model.JobTitle%>
    </td>
</tr>
