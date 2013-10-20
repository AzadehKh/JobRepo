<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUnauthenticated.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="JobRepo.Error" %>
<%@ Register Src="~/User_Controls/DesignGuide.ascx" TagName="DesignGuide" TagPrefix="DG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style4
        {
            font-size: x-large;
        }
    </style>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-blink.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {


        $("#btnDetail").click(function () {
                $("#gd").show("slow");

            });

            $("#btnClose").click(function () {
                $("#gd").hide("slow");

            });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <strong><span class="style4">Your request cannot be processed

    </span></strong>

    <br />
    <br />

    Click <a id="btnDetail" 
        style="text-decoration: underline; color: #0000FF">here</a>  to see more details
    <div id="gd" style="display: none">
    <asp:Panel ID="Panel1" runat="server" BorderWidth="3" Wrap="true">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
        <br />
        <a id="btnClose" style="text-decoration: underline; color: #0000FF">Close</a>
    </asp:Panel>
    </div>
    <br />
    <br />
    Perhapse you would like to visit one of these pages?<br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
     <br /> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/JobSearch.aspx">Search Job</asp:HyperLink>
      <br /> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/JobList.aspx">My Jobs</asp:HyperLink>


        <p>
            &nbsp;<DG:DesignGuide ID="desgingd" runat="server" HTMLPageName="Custom Error Page.html" />
        <p>
        &nbsp;
        </p>


</asp:Content>

