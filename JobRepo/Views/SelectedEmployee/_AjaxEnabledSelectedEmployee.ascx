<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<JobRepo.Model.Employee>>" %>

    <table>
        <tr>
            <th/>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td><%: Html.ActionLink("See Details", "EmployeeDetails", "JobSeeker", new { id = item.EmployeeID }, null)%></td>
            <td>
                <%: Html.Encode(item.FirstName) %>
            </td>
            <td>
                <%: Html.Encode(item.LastName) %>
            </td>
        </tr>
    
    <% } %>

    </table>



