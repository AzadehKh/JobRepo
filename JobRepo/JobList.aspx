<%@ Page Title="" Language="C#" MasterPageFile="~/SiteUnauthenticated.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="JobRepo.JobList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="objDsJob" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetJobsByEmployerID" TypeName="JobRepo.Model.JobObject" 
        DataObjectTypeName="JobRepo.Model.JobDto" DeleteMethod="DeleteJob">
        <SelectParameters>
            <asp:SessionParameter Name="EmployerID" SessionField="EmployerID" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="JobID" DataSourceID="objDsJob" 
        onrowcommand="grdJob_RowCommand">
        <EmptyDataTemplate>
        <br />
        Please make sure you have already created a <a href="EmployerProfile.aspx"> Profile </a> &nbsp;
        <br />
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField ShowHeader="true">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                        CommandName="EditJob" CommandArgument='<%# Eval("JobID")%>' Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" 
                    Visible='<%# Eval("Status") == "Unpaid" %>'
                        CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Status" HeaderText="Status" 
                SortExpression="Status" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="PostedDate" HeaderText="Posted Date" 
                SortExpression="PostedDate" />
            <asp:BoundField DataField="SalaryRange" HeaderText="Salary" 
                SortExpression="SalaryRange" />
            <asp:BoundField DataField="ValidationRange" HeaderText="Valid" 
                SortExpression="ValidationRange" />
            <asp:BoundField DataField="JobAdvType" HeaderText="JobAdvType" 
                SortExpression="JobAdvType" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
        Text="Add New Job" />
</asp:Content>
