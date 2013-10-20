<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
   CodeBehind="JobEditor.aspx.cs" Inherits="JobRepo.JobEditor" %>

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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
        <td width="30px">
            <asp:DetailsView ID="dvJob" runat="server" AutoGenerateRows="False" DataSourceID="objDSJob"
                DefaultMode="Insert" Height="50px" Width="125px">
                <Fields>
                    <asp:TemplateField HeaderText="Title:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" runat="server" Height="23px" Text='<%# Bind("Title") %>'
                                Width="490px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="Please enter a valid title" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valid:">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txtValidFrom" runat="server" Text='<%# Bind("ValidFrom", "{0:MM/dd/yyyy}")%>'
                                Width="117px" Height="23px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtValidFrom"
                                PopupButtonID="btnValidFrom">
                            </ajaxToolkit:CalendarExtender>
                            <asp:Button ID="btnValidFrom" runat="server" Height="24px" Text="..." Width="25px" />
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValidFrom"
                                ErrorMessage="Please enter a valid date" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtValidFrom" ErrorMessage="please enter a valid date" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"
                                ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txtValidTo" runat="server" Text='<%# Bind("ValidTo", "{0:MM/dd/yyyy}")%>'
                                Width="117px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtValidTo"
                                PopupButtonID="btnValidTo">
                            </ajaxToolkit:CalendarExtender>
                            <asp:Button ID="btnValidTo" runat="server" Text="..." Width="25px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidTo"
                                ErrorMessage="Please enter a valid date" ValidationGroup="Group1">*</asp:RequiredFieldValidator>&nbsp;
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtValidTo" ErrorMessage="please enter a valid date" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"
                                ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                            &nbsp;
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Salary:">
                        <EditItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="From"></asp:Label>
                            <asp:TextBox ID="txtSalaryFrom" runat="server" Text='<%# Bind("SalaryFrom") %>' Width="117"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSalaryFrom"
                                ErrorMessage="Please enter a valid salary" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="To"></asp:Label>
                            <asp:TextBox ID="txtSalaryTo" runat="server" Text='<%# Bind("SalaryTo") %>' Width="117"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type:">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlType" runat="server" DataSourceID="EDSJobType" DataTextField="Description"
                                DataValueField="JobTypeID" SelectedValue='<%# Bind("JobTypeID") %>' Width="200px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlType"
                                ErrorMessage="Please select a valid job type" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location:">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="objDSLocation" DataTextField="Description"
                                DataValueField="LocationID" SelectedValue='<%# Bind("LocationID") %>' Width="490">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlLocation"
                                ErrorMessage="a valid location" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                TextMode="MultiLine" Height="500px" Width="400px"></asp:TextBox>
                            <ajaxToolkit:HtmlEditorExtender ID="htmlEditor" runat="server" 
                                TargetControlID="txtDescription" DisplaySourceTab="True" 
                                ViewStateMode="Enabled">
                            </ajaxToolkit:HtmlEditorExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDescription"
                                ErrorMessage="Please enter a valid description" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Adv Type:">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlJobAdv" runat="server" DataSourceID="objDsJobAdv" DataTextField="Type"
                                DataValueField="ID" SelectedValue='<%# Bind("JobAdvTypeID") %>' Width="200px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please select a valid Job advertisement"
                                ValidationGroup="Group1" ControlToValidate="ddlJobAdv">*</asp:RequiredFieldValidator>
<%--                            <asp:LinkButton ID="lnkBtnJobAdv" runat="server" CausesValidation="False" 
                                onclick="lnkBtnJobAdv_Click">See more details</asp:LinkButton>--%>
                                <a href="JobAdv.aspx" target="_blank">See more details</a>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PostedDate" Visible="false">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPostedDate" runat="server" Text='<%# Bind("PostedDate", "{0:MM/dd/yyyy}")%>'
                                Width="117px" Height="23px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <table style="width: 100%;">
                <tr>
                <td class="style2">
                </td>
                    <td class="style1">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Group1"
                            Width="85px" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Width="85px" Text="Cancel" CausesValidation="false"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ValidationGroup="Group1" />
            <asp:ObjectDataSource ID="objDSJob" runat="server" DataObjectTypeName="JobRepo.Model.JobDto"
                InsertMethod="InsertJob" OldValuesParameterFormatString="original_{0}" SelectMethod="GetJobByID"
                TypeName="JobRepo.Model.JobObject" UpdateMethod="UpdateJob" OnInserted="objDSJob_Inserted"
                OnUpdated="objDSJob_Updated" OnUpdating="objDSJob_Updating" DeleteMethod="DeleteJob"
                OnInserting="objDSJob_Inserting">
                <SelectParameters>
                    <asp:SessionParameter Name="JobID" SessionField="JobID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:EntityDataSource ID="EDSJobType" runat="server" ConnectionString="name=JobRepoDataContext"
                DefaultContainerName="JobRepoDataContext" EnableFlattening="False" EntitySetName="JobTypes">
            </asp:EntityDataSource>
            <asp:ObjectDataSource ID="objDSLocation" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetLocations" TypeName="JobRepo.Model.LocationObject"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="objDsJobAdv" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAllActiveAdvs" TypeName="JobRepo.Model.JobAdvTypeObject"></asp:ObjectDataSource>
    </div>
</asp:Content>
