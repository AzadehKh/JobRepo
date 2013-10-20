<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EmployerProfile.aspx.cs" Inherits="JobRepo.EmployerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-blink.js" type="text/javascript"></script>
    <script src="Scripts/PasswordValidator.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_MainContent_txtUsername").keyup(function () {
         
                //Using custom attribute for textbox 
                /*
                Please notice that using so many custom att(s) is not recommended 
                as it causes memory leak issues
                */
                $(this).attr("isvalid", function () { return false; });

                $("#ValidationInfo").html("");
                var username = $(this).val();
                var minlen = 5; //parseInt("<%= Membership.MinRequiredPasswordLength %>");
                if (username.length < parseInt("<%= Membership.MinRequiredPasswordLength %>")) return;

                $("#ValidationInfo").html("Checking Username Availability ....");
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    url: "Services/UserNameValidationService.asmx/IsValidUserName",
                    data: "{'username': '" + username + "'}",
                    success: function (data) {


                        $("#MainContent_MainContent_txtUsername").attr("isvalid", function () { return data.d; })

                        if (data.d == true) {

                            $("#ValidationInfo").css("color", "Green");
                            $("#ValidationInfo").html("Username is available");
                        }
                        else {

                            $("#ValidationInfo").css("color", "Red");
                            $("#ValidationInfo").html("Username is not available");
                        }
                    },
                    error: function () {
                        alert("Error calling the web service.");
                    }
                });
            }
             );

            $("#MainContent_MainContent_txtPassword").keyup(function () {


                var validator = new JobRepo.PasswordStrengthValidationComponent();
                //var pass = document.getElementById("MainContent_MainContent_txtPassword").value;
                var pass = $(this).val();
                var strength = validator.CheckPasswordStrength(pass);
                //document.getElementById("MainContent_MainContent_lblPasswordStrength").innerText = strength;
                // either MainContent_lblPasswordStrength or <%=lblPasswordStrength.ClientID%> can be used
                $("#<%=lblPasswordStrength.ClientID%>").html(strength);



                if (strength == "Weak") {
                    $("#<%=lblPasswordStrength.ClientID%>").css("color", "Red");
                    $("#MainContent_MainContent_txtPassword").addClass("Password_Weak");
                }
                else
                    if (strength == "Medium") {
                        $("#<%=lblPasswordStrength.ClientID%>").css("color", "Blue");
                        $("#MainContent_MainContent_txtPassword").addClass("Password_Medium");
                    }
                    else {
                        $("#<%=lblPasswordStrength.ClientID%>").css("color", "Green");
                        $("#MainContent_MainContent_txtPassword").addClass("Password_Strong");
                    }
            });

            $("#MainContent_MainContent_dvwEmployer_btnShowLogo").click(function () {


                if ($(this).attr("value") == "Show the saved logo") {
                    $("#gd").show("slow");
                    $(this).attr("value", "Close");
                }
                else {
                    $(this).attr("value", "Show the saved logo");
                    $("#gd").hide("slow");

                }
            });

        });

    </script>
    <script language="javascript" type="text/javascript">
        function Check4UserNameAvailability(source, arguments) {

            var data = arguments.Value.split('');
            arguments.IsValid = false;

            if (data.length < parseInt("<%= Membership.MinRequiredPasswordLength %>")) return;

            if ($("#MainContent_MainContent_txtUsername").attr("isvalid") == "false")
                return;

            arguments.IsValid = true;

        }
    </script>

    <style type="text/css">
        .style3
        {
            width: 191px;
        }
        .style5
        {
            width: 9px;
        }
        .style6
        {
            width: 191px;
            height: 31px;
        }
        .style7
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/PasswordStrengthValidationComponent.js" />
        </Scripts>
    </asp:ScriptManager>
    <br />
    <span>If you are a new user , Please complete the following information otherwise click
        <asp:LinkButton ID="LinkButton1" runat="server" 
        PostBackUrl="~/Account/Login.aspx?ReturnUrl=%2fEmployerProfile.aspx"> here</asp:LinkButton>
        &nbsp; to login in order to post your job advertisements<br />
        &nbsp;</span><br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="vwAccountDetails" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label13" runat="server" Style="font-weight: 700" Text="Account Details:"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="Label14" runat="server" Text="User Name:"></asp:Label>
                        <br />
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="txtUsername" runat="server" Width="431px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUsername"
                            ErrorMessage="Please enter a valid user name" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                           &nbsp;&nbsp;
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ClientValidationFunction="Check4UserNameAvailability" 
                            ControlToValidate="txtUsername" 
                            ErrorMessage="Username must be at least <%= Membership.MinRequiredPasswordLength %> characters and available " 
                            ForeColor="Red" ValidationGroup="Group1">!</asp:CustomValidator>
                        <br />
                        <span id="ValidationInfo"></span>
                    </td>
                    <td class="style7">
                        &nbsp;
                    </td>
                    <td class="style7">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label15" runat="server" Text="Password:"></asp:Label>
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="10" Width="185px" 
                            TextMode="Password"></asp:TextBox>
 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorpassword" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="Please enter a valid password" ForeColor="Red" Style="direction: rtl"
                                    ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;
                                <asp:CustomValidator ID="CustomValidatorpassword" runat="server" 
                                    ClientValidationFunction="ValidatePassword" ControlToValidate="txtPassword" 
                                    ErrorMessage="Password must be between 6-10 characters and it should contain at least 1 capital letter, 1 lowercase letter, and 1 number" 
                                    ForeColor="Red" 
                                    ToolTip="Password must be between 6-10 characters and it should contain at least 1 capital letter, 1 lowercase letter, and 1 number" 
                                    ValidationGroup="Group1">!</asp:CustomValidator>
                        <br />
                        <asp:Label ID="lblPasswordStrength" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label16" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecoveryEmail" runat="server" MaxLength="100" Width="431px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRecoveryEmail"
                            ErrorMessage="Please enter a valid email" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRecoveryEmail"
                            ErrorMessage="Please enter a valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label17" runat="server" Text="Security Question 1:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuestion1" runat="server" MaxLength="200" Width="431px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtQuestion1"
                            ErrorMessage="Please enter a valid question" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label18" runat="server" Text="Security Answer 1:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer1" runat="server" MaxLength="200" Width="431px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAnswer1"
                            ErrorMessage="Please enter a valid answer" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label19" runat="server" Text="Security Question 2:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuestion2" runat="server" MaxLength="200" Width="431px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtQuestion2"
                            ErrorMessage="Please enter a valid question" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label20" runat="server" Text="Security Answer 2:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer2" runat="server" MaxLength="200" Width="431px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAnswer2"
                            ErrorMessage="Please enter a valid answer" ForeColor="Red" Style="direction: rtl"
                            ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vwCompanyDetails" runat="server">
            <asp:Label ID="Label12" runat="server" Style="font-weight: 700" Text="Company Details:"></asp:Label>
            <asp:DetailsView ID="dvwEmployer" runat="server" Height="50px" Width="900px" AutoGenerateRows="False"
                DataSourceID="objDsEmployer" DefaultMode="Insert" 
                DataKeyNames="EmployerID" >
                <Fields>
                    <asp:TemplateField HeaderText="Title:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="30" Width="518px" Text='<%# Bind("Title") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="Please enter a valid title" ForeColor="Red" Style="direction: rtl"
                                ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" Text='<%# Bind("Phone") %>'
                                Width="210px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone"
                                ErrorMessage="Please enter a valid phone number" ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fax:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFax" runat="server" MaxLength="15" Text='<%# Bind("Fax") %>'
                                Width="210px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Height="23px" MaxLength="100" Text='<%# Bind("Email") %>'
                                Width="271px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Please enter a valid email " ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Please enter a valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="WebSite:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWebsite" runat="server" MaxLength="100" Text='<%# Bind("WebSite") %>'
                                Width="268px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtWebsite"
                                ErrorMessage="Please enter a valid website" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Full Address:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="1000" Text='<%# Bind("Address") %>'
                                Width="518px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="Please enter a valid address" ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Details:">
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FullName:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContactName" runat="server" MaxLength="100" Text='<%# Bind("ContactName") %>'
                                Width="518px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactName"
                                ErrorMessage="Please enter a valid contact name" ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="15" Text='<%# Bind("ContactPhone") %>'
                                Width="210px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContactPhone"
                                ErrorMessage="Please enter a valid contact phone number" ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContactMobile" runat="server" MaxLength="15" Text='<%# Bind("ContactMobile") %>'
                                Width="210px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email:">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContactEmail" runat="server" MaxLength="100" Text='<%# Bind("ContactEmail") %>'
                                Width="268px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtContactEmail"
                                ErrorMessage="Please enter a valid contact email" ForeColor="Red" ValidationGroup="Group1">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactEmail"
                                ErrorMessage="Please enter a valid contact email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="Group1">Invalid format!</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Logo">
                        <EditItemTemplate>
                            <asp:FileUpload ID="logoUploader" runat="server" Height="22px" Width="537px" />
                            &nbsp;
                            <input type="button" id="btnShowLogo" runat="server" value="Show the saved logo" />
                            <div id="gd" style="display: none">
                            Please notice that if you have modified the logo , it will not be applied until you click on Submit button
                             &nbsp; &nbsp;
                                <asp:Image ID="imgLogo" runat="server" ImageUrl='<%# "Handlers/ImageHandler.ashx?dt=" + DateTime.Now.Ticks.ToString() + "&employerid=" + Eval("EmployerID") %>'
                                    OnDataBinding="imgLogo_DataBinding" Width="500" Height="300" />
                            </div>
                            
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UserID" ShowHeader="False" Visible="False" />
                    <asp:BoundField DataField="Logo" ShowHeader="False" Visible="False" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objDsEmployer" runat="server" DataObjectTypeName="JobRepo.Model.Employer"
                InsertMethod="InsertEmployer" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetProfile"
                TypeName="JobRepo.Model.EmployerProfileObject" UpdateMethod="UpdateEmployer"
                OnInserting="objDsEmployer_Inserting" OnUpdating="objDsEmployer_Updating" 
                OnSelected="objDsEmployer_Selected" oninserted="objDsEmployer_Inserted" 
                onupdated="objDsEmployer_Updated">
                <SelectParameters>
                    <asp:SessionParameter Name="UserID" SessionField="UserID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <table>
                <tr>
                    <td class="style3">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Style="margin-left: 146px" Text="Submit"
                            ValidationGroup="Group1" OnClick="btnRegister_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <table style="width: 100%;">
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Group1" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="style3">
            </td>
            <td>
                <asp:Button ID="btnPrevious" runat="server" Style="margin-left: 146px" Text="Previous"
                    CommandName="AccountDetails" OnCommand="Button_Command" UseSubmitBehavior="False"
                    Width="70px" />
            </td>
            <td>
                &nbsp;
                <asp:Button ID="btnNext" runat="server" Style="margin-left: 146px" Text="Next" CommandName="CompanyDetails"
                    OnCommand="Button_Command" Width="70px" ValidationGroup="Group1" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
