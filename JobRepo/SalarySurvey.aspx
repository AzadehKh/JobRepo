<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SalarySurvey.aspx.cs" Inherits="JobRepo.SalarySurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p id="Header" >
Salary-Guide-<script type="text/javascript">document.write(new Date().getFullYear());</script>
</p>
    <asp:GridView ID="grdGuide" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        style="text-align: left">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Role" SortExpression="Role">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Role") %>' Width="400px"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="200px" />
                <FooterStyle Width="200px" />
                <HeaderStyle Width="200px" />
                <ItemStyle Width="400px" />
            </asp:TemplateField>
            <asp:BoundField DataField="MinSalary" HeaderText="Min Salary" SortExpression="MinSalary" 
            ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="MaxSalary" HeaderText="Max Salary" SortExpression="MaxSalary"
            ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
            
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="AverageSalary" HeaderText="Average Salary" SortExpression="AverageSalary"
            ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
            
                <ItemStyle Width="100px" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        <br />
        <input type="button" value="&lt; Back to Previous Page"
onClick="javascript: history.go(-1)">
</asp:Content>
