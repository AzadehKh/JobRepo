<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <%: ViewData["Message"] %>
    <br />
    <br />
    <asp:HyperLink NavigateUrl="../../Account/Login.aspx" runat="server">Log In</asp:HyperLink>
</asp:Content>
