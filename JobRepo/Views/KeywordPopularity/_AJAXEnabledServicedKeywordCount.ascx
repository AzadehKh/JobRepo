<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<JobRepo.MVC.Services.KeywordPopularityDTO>>" %>

    <% foreach (var item in Model) { %>
    <li>
                <%: item.Keyword %>
                <br /> 
                Popularity : 
                <%: item.Count %>
                <br /> 
    </li>    
    <% } %>



