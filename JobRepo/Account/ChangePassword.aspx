<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/SiteUnauthenticated.Master"
    AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="JobRepo.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-blink.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer1").keyup(function () {

                //Using custom attribute for textbox 
                /*
                Please notice that using so many custom att(s) is not recommended 
                as it causes memory leak issues
                */
                $(this).attr("isvalid", function () { return false; });


                var answer = $(this).val();


                $("#ValidationInfo1").html("Checking Security Question ....");
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    url: "../Services/SecurityCheckService.asmx/IsValidAnswerToQuestion1",
                    data: "{'Answer1': '" + answer + "'}",
                    success: function (data) {
                        $("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer1").attr("isvalid", function () { return data.d; })
                        $("#ValidationInfo1").html("");
                    },
                    error: function () {
                        $("#ValidationInfo1").html("");
                        alert("Error calling the web service for quesiton1.");
                    }
                });
            });

            $("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer2").keyup(function () {

                //Using custom attribute for textbox 
                /*
                Please notice that using so many custom att(s) is not recommended 
                as it causes memory leak issues
                */
                $(this).attr("isvalid", function () { return false; });


                var answer = $(this).val();


                $("#ValidationInfo2").html("Checking Security Question ....");
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    url: "../Services/SecurityCheckService.asmx/IsValidAnswerToQuestion2",
                    data: "{'Answer2': '" + answer + "'}",
                    success: function (data) {
                        $("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer2").attr("isvalid", function () { return data.d; })
                        $("#ValidationInfo2").html("");
                    },
                    error: function () {
                        $("#ValidationInfo2").html("");
                        alert("Error calling the web service for quesiton2.");
                    }
                });
            });

        });

    </script>
    <script language="javascript" type="text/javascript">
        function CheckSecurity1(source, arguments) {

            var data = arguments.Value.split('');
            arguments.IsValid = false;

            if ($("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer1").attr("isvalid") == "false")
                return;

            arguments.IsValid = true;

        }
        function CheckSecurity2(source, arguments) {

            var data = arguments.Value.split('');
            arguments.IsValid = false;

            if ($("#MainContent_ChangeUserPassword_ChangePasswordContainerID_txtAnswer2").attr("isvalid") == "false")
                return;

            arguments.IsValid = true;

        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Change Password
    </h2>
    <p>
        Use the form below to change your password.
    </p>
    <p>
        New passwords are required to be a minimum of
        <%= Membership.MinRequiredPasswordLength %>
        characters in length.
    </p>
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/"
        EnableViewState="false" RenderOuterTable="false" SuccessPageUrl="ChangePasswordSuccess.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="ChangeUserPasswordValidationGroup" />
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                            ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                    </p>
                    <p>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtAnswer1">
                        <%= ProfileCommon.GetProfile().SecurityQuestions.Question1%></asp:Label>
                        <asp:TextBox ID="txtAnswer1" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer1"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Security question should be answered."
                            ToolTip="The Security question should be answered." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckSecurity1"
                            ControlToValidate="txtAnswer1" ErrorMessage="One or both answers are not correct"
                            ForeColor="Red" ValidationGroup="ChangeUserPasswordValidationGroup">!</asp:CustomValidator>
                        <br />
                        <span id="ValidationInfo1"></span>
                    </p>
                    <p>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtAnswer2">
                        <%= ProfileCommon.GetProfile().SecurityQuestions.Question2%></asp:Label>
                        <asp:TextBox ID="txtAnswer2" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAnswer2"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Security question should be answered."
                            ToolTip="The Security question should be answered." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="CheckSecurity2"
                            ControlToValidate="txtAnswer2" ErrorMessage="One or both answers are not correct"
                            ForeColor="Red" ValidationGroup="ChangeUserPasswordValidationGroup">!</asp:CustomValidator>
                        <br />
                        <span id="ValidationInfo2"></span>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" />
                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                        Text="Change Password" ValidationGroup="ChangeUserPasswordValidationGroup" />
                </p>
            </div>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
