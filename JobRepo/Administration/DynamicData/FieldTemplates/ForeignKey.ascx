<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="JobRepo.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

