<%@ Page Title="SMTP Settings" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="SMTPSettings.aspx.cs" Inherits="IITS_CloudAccounting.Admin.SMTPSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });
    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="SMTPSettings.aspx">SMTP Settings</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>SMTP Settings for your clients & staff</h1>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            "Reply-To" Address
                        </div>
                        <div class="col-lg-9">
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                            (<asp:Label runat="server" ID="lblEmail"></asp:Label>) (<a href="UpdateCompanyDetail.aspx" class="permission">change</a>)<br />
                            "Reply-To" address for emails sent by Bill Transact to your clients.
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            SMTP From
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtSMTPFrom" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvsmtpFrom" ControlToValidate="txtSMTPFrom" ForeColor="red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="SmtpSetting">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Host
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtHost" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvHost" ControlToValidate="txtHost" ForeColor="red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="SmtpSetting">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Port
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtPort" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPort" ControlToValidate="txtPort" ForeColor="red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="SmtpSetting">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Enable SSL
                        </div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkEnableSSL" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Username
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvUsername" ControlToValidate="txtUsername" ForeColor="red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="SmtpSetting">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Password
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" ForeColor="red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="SmtpSetting">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Email Signature
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtEmailSignature" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label" style="padding-right: 0;">
                            Email To Check SMTP
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmailCheck" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailCheck" Display="Dynamic" ForeColor="Red" ValidationGroup="SmtpSetting" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="SmtpSetting" ControlToValidate="txtEmailCheck" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2 control-label">
                            <asp:Button runat="server" ID="btnCheck" Text="SMTP Check" CssClass="btn-primary" OnClick="btnCheck_Click" ValidationGroup="SmtpSetting" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="SmtpSetting" />
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
