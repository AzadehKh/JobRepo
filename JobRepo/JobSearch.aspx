<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
EnableSessionState="True" CodeBehind="JobSearch.aspx.cs" Inherits="JobRepo.JobSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 298px;
        }
        .style2
        {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="KeyWords"></asp:Label>&nbsp;
                <asp:TextBox ID="txtKeyword" runat="server" Height="19px" Width="406px" ValidationGroup="Group1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKeyword"
                    ErrorMessage="keyword is not valid" ForeColor="Red" ValidationGroup="Group1">keyword is not valid</asp:RequiredFieldValidator>
                <br />
                &nbsp; use semicolon (;) to separate keywords<br />
                <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <AjaxControlToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    CompletionInterval="100" CompletionSetCount="10" DelimiterCharacters=";" EnableCaching="false"
                    FirstRowSelected="false" MinimumPrefixLength="2" ServiceMethod="SearchLocations"
                    TargetControlID="txtLocation">
                </AjaxControlToolkit:AutoCompleteExtender>
                <asp:TextBox ID="txtLocation" runat="server" Width="406px" Height="19px"></asp:TextBox>
                &nbsp;<br />
                &nbsp; use semicolon (;) to separate locations<br />
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    ValidationGroup="Group1" />
               <%-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/JobAdv.aspx">Advance Search</asp:HyperLink>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="100">
            <ProgressTemplate>
                <asp:Label ID="Label3" runat="server" Text="Please wait ..." Font-Bold="True" Font-Size="12" ForeColor="Red"></asp:Label>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <asp:ListView ID="lwSearchResult" runat="server" DataSourceID="objDSJob">
                    <EmptyDataTemplate>
                        <span>No Job found.</span>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div style="border-style: solid; border-width: medium; width: 600px;">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="style1">
                                        <asp:HyperLink ID="TitleLabel" runat="server" CssClass="bold" ForeColor="#0000CC" Target="_blank"
                                            NavigateUrl='<%# "~/JobReviewer.aspx?JJ=" + Eval("JobID") %>'><%# Eval("Title") %></asp:HyperLink>
                                        &nbsp;
                                    </td>
                                    <td class="style2">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: hidden; width: 300px; height: 80px">
                                            <asp:Label ID="Label2" runat="server" Height="80px" Text='<%# Eval("ShortDescription") %>'
                                                Width="300px"></asp:Label>
                                        </div>
                                        <br />
                                        <br />
                                    </td>
                                    <td class="style2">
                                        &nbsp;
                                    </td>
                                    <td style="color: #FF0066; vertical-align: top;">
                                        Valid
                                        <asp:Label ID="ValidationRangeLabel" runat="server" ForeColor="#FF0066" Text='<%# Eval("ValidationRange") %>' />
                                        <br />
                                        <asp:Label ID="SalaryRangeLabel" runat="server" ForeColor="#33CC33" Text='<%# Eval("SalaryRange") %>' />
                                        <br />
                                        <asp:Label ID="JobAdvTypeLabel" runat="server" ForeColor="#996633" Text='<%# Eval("JobAdvType") %>' />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                &nbsp;<asp:ObjectDataSource ID="objDSJob" runat="server" OldValuesParameterFormatString="original_{0}"
                    OnSelecting="objDSJob_Selecting" SelectMethod="GetJobs" TypeName="JobRepo.Model.JobObject">
                    <SelectParameters>
                        <asp:Parameter Name="WhereClause" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
