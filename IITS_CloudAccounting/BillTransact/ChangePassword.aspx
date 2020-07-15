<%@ Page Title="Change Password" Language="C#"  AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-user-2"></i>
                    <a href="#">Change Password
                    </a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Change Password</h1>
            </div>
        </div>
    </div>
    <asp:ChangePassword ID="ChangePassword1" runat="server" Width="100%">
        <ChangePasswordTemplate>
            <div class="col-lg-1">&nbsp;</div>
            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <div class="form-horizontal">
                    <div class="col-lg-5 control-label">
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Password:</asp:Label>
                        <asp:RequiredFieldValidator ForeColor="red" SetFocusOnError="True" ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-7 form-group">
                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-5 control-label">
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ChangePassword1" ForeColor="red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-7 form-group">
                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-5 control-label">
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ForeColor="red" SetFocusOnError="True" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-7 form-group">
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:CompareValidator ID="NewPasswordCompare" ForeColor="red" SetFocusOnError="True" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangePassword1"></asp:CompareValidator>
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-lg-12" style="text-align: center; color: white;">
                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" CssClass="btn btn-primary" Text="Change Password" ValidationGroup="ChangePassword1" />
                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CssClass="btn btn-warning" CommandName="Cancel" Text="Cancel" OnClick="CancelPushButtonClick" />
                    </div>
                </div>
            </div>
            <div class="col-lg-3">&nbsp;</div>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <div class="col-lg-12 control-label" style="text-align: center; font-size: 20px; font-family: monospace; margin-bottom: 15px;">
                Your password has been changed!
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center; color: white;">
                <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CssClass="btn btn-success" CommandName="Continue" Text="Continue" OnClick="CancelPushButtonClick" />
            </div>
        </SuccessTemplate>
    </asp:ChangePassword>
</asp:Content>
