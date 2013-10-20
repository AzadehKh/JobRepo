<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectJob.ascx.cs" Inherits="JobRepo.User_Controls.SelectJob" %>
<%--This control cannot be cached as it will be used by a generic web part--%>
<%--  <%@ OutputCache Duration="15" VaryByParam="none" VaryByControl="txtSearch" %>--%>
  <style type="text/css">
    .style1
    {
        color: #FF0000;
        font-size: small;
    }
</style>
<p>
    What kind of job are you looking for?</p>
<asp:TextBox ID="txtJob" runat="server" Width="327px"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
    Text="Search" />
<p>
    <span class="style1">Please notice that the search engine is using &quot;Exact Match&quot; option&nbsp;</span>
</p>

