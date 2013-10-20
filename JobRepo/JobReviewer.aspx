<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="JobReviewer.aspx.cs" Inherits="JobRepo.JobReviewer" %>

<%--    instead of setting durtion for cache e.g.  Duration="31536000" , we can use 
        a generic cache profile defined in the web.config file
        Notice that for user control , we cannot use CacheProfile attribute --%>
<%@ OutputCache CacheProfile="OneDayCacheProfile" VaryByParam="none" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 92px;
        }
        .style2
        {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DetailsView ID="dvJob" runat="server" AutoGenerateRows="False" DataSourceID="objDSJob"
            Height="50px" Width="100%" DataKeyNames="JobID" BorderStyle="None" BorderWidth="0px"
            GridLines="None">
            <Fields>
                <asp:TemplateField SortExpression="Title">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="font-weight: 700; font-size: large">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align: justify; width: 60%;">
                                    <asp:Literal ID="litContent" runat="server" Text='<%# Bind("Description") %>'></asp:Literal>
                                </td>
                                <td style="width: 10%">
                                </td>
                                <td style="width: 30%">
                                    <asp:Label ID="Label7" runat="server" Style="color: #660066; text-align: left;" Text='<%# Bind("JobAdvType") %>'></asp:Label>
                                    <br></br>
                                    <asp:Label ID="Label6" runat="server" Style="color: #CC0000; text-align: left" Text='<%# Bind("JobType") %>'></asp:Label>
                                    <br></br>
                                    <asp:Label ID="Label4" runat="server" Style="color: #006600; text-align: left" Text='<%# Bind("SalaryRange") %>'></asp:Label>
                                    <br></br>
                                    <div style="color: #663300; text-align: left">
                                        Valid&nbsp;
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ValidationRange") %>'></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="objDSJob" runat="server" DataObjectTypeName="JobRepo.Model.JobDto"
            InsertMethod="InsertJob" OldValuesParameterFormatString="original_{0}" SelectMethod="GetJobByID"
            TypeName="JobRepo.Model.JobObject" UpdateMethod="UpdateJob" DeleteMethod="DeleteJob">
            <SelectParameters>
                <asp:QueryStringParameter Name="JobID" QueryStringField="JJ" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
