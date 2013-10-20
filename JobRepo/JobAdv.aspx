<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="JobAdv.aspx.cs" Inherits="JobRepo.JobAdv" %>

<%@ Register Src="User_Controls/DesignGuide.ascx" TagName="DesignGuide" TagPrefix="DG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-blink.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.blink').blink();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <input type="button" value="&lt; Back to Previous Page"
onclick="javascript: history.go(-1)"/>
   <br />
    <table style="width: 100%;">
        <tr>
            <td>
                <br />
                <span>We have the following types of job sdvertisements: </span>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="rptAdv" runat="server">
                    <ItemTemplate>
                        <br />
                        <br />
                        Type:<asp:LinkButton ID="LinkButton1" runat="server"><%# Eval("Type") %></asp:LinkButton>
                        <span class="blink">
                            <%# Eval("Offer") %></span>
                        <br />
                        Price:
                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("Price") %>'>
                        </asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>'>></asp:Label>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <DG:DesignGuide ID="desgingd" runat="server" HTMLPageName="JobAdv.html" />
                &nbsp;
            </td>
        </tr>
    </table>
    <input type="button" value="&lt; Back to Previous Page"
onclick="javascript: history.go(-1)"/>

</asp:Content>
