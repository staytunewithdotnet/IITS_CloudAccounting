<%@ Page Title="Miscellaneous" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="Miscellaneous.aspx.cs" Inherits="IITS_CloudAccounting.Admin.Miscellaneous" %>

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
                    <a href="Miscellaneous.aspx">Miscellaneous</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your preferences have been updated.</h3>
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>Click to <a href="InvoiceMasterNew.aspx" class="permission">create an invoice</a>.
                    </li>
                    <li>Click to <a href="EstimateMaster.aspx" class="permission">create an estimate</a>.
                    </li>
                    <li>Click to <a href="ProjectMaster.aspx" class="permission">create a project</a>.
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0;">
            <h1>Miscellaneous</h1>
            Random tweaks, dials and knobs.
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee; padding-top: 0;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3>General</h3>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Lines Per Page
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox runat="server" ID="txtLines" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Number of invoices, clients, etc. shown on "List of" pages.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Date Format
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlDateFormat" runat="server" CssClass="form-control text">
                                <asp:ListItem Value="MM/dd/yy">MM/dd/yy</asp:ListItem>
                                <asp:ListItem Value="MM/dd/yyyy" Selected="True">MM/dd/yyyy</asp:ListItem>
                                <asp:ListItem Value="dd/MM/yy">dd/MM/yy</asp:ListItem>
                                <asp:ListItem Value="dd/MM/yyyy">dd/MM/yyyy</asp:ListItem>
                                <asp:ListItem Value="yy-MM-dd">yy-MM-dd</asp:ListItem>
                                <asp:ListItem Value="yyyy-MM-dd">yyyy-MM-dd</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            The date format used throughout your account.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Direct Links
                        </div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkDirectLink" Text="Enabled" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Allows your client to view invoices, estimates and credits by clicking a link in their email.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Bill Transact Branding
                        </div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkBranding" Text="Enabled" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Show Bill Transact branding on invoices/estimates and <a href="ReferralInformation.aspx" class="permission">earn referrals</a>.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Request reviews from clients
                        </div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkRequestReview" Text="Prompts for Review Requests" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Prompts you to request a review from your client when you send a new invoice (with online payment enabled) or add a new payment yourself. You will not be prompted to request a review from the same client more than once in a 6-month period.
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3>Invoices & Estimates</h3>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Text Below Your Logo
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox runat="server" ID="txtLogoText" CssClass="form-control text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            This text appears below your logo on invoices and estimates.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Recurring Invoices
                        </div>
                        <div class="col-lg-5">
                            <asp:CheckBox runat="server" ID="chkSendAutomatically" Text="Send Automatically" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Recurring invoices are sent immediately to your client when they get created. Disabling this feature will not prevent credit card charges when auto-billing is enabled.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-5">
                            <asp:CheckBox runat="server" ID="chkCreditAutomatically" Text="Apply Credit Automatically" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Recurring invoices automatically apply client credit as payment.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Default Column Headings
                        </div>
                        <div class="col-lg-5">
                            <asp:DropDownList ID="ddlLineType" runat="server" CssClass="form-control text">
                                <asp:ListItem Value="items">Item</asp:ListItem>
                                <asp:ListItem Value="time">Time</asp:ListItem>
                                <asp:ListItem Value="Both" Selected="True">Both Items and Time</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            This controls the default column headings that are displayed when editing an invoice, estimate, or recurring profile.
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label"></div>
                        <div class="col-lg-9"></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3>Welcome Messages</h3>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Clients
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtWelcomeClient" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            This text will appear on your client home page. Preview client home page
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Staff
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtWelcomeStaff" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            This text will appear on your staff home page. Preview staff home page
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3>Documents</h3>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Default Client Access
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlDefaultClient" CssClass="form-control text">
                                <asp:ListItem Value="None" Selected="True">None</asp:ListItem>
                                <asp:ListItem Value="Read">Read</asp:ListItem>
                                <asp:ListItem Value="Read/write">Read/write</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            You must manually give clients access to folders.
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label">
                            Default Staff Access
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlDefaultStaff" CssClass="form-control text">
                                <asp:ListItem Value="None">None  </asp:ListItem>
                                <asp:ListItem Value="Read">Read </asp:ListItem>
                                <asp:ListItem Value="Read/write" Selected="True">Read/write </asp:ListItem>
                                <asp:ListItem Value="Admin">Admin </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            New staff have read/write access to all document folders.
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3>Support</h3>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0">
                        <div class="col-lg-3 control-label">
                            Time Increments
                        </div>
                        <div class="col-lg-2" style="padding-right: 0;">
                            <asp:TextBox runat="server" ID="txtTimeMinutes" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                        <div class="col-lg-3" style="padding-right: 0; padding-left: 0;">
                            minute increments up to
                        </div>
                        <div class="col-lg-2" style="padding-right: 0; padding-left: 0;">
                            <asp:TextBox runat="server" ID="txtTimeHours" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                        <div class="col-lg-1" style="padding-right: 0; padding-left: 0;">Hours.</div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Time tracking increments to display when logging time on support tickets.
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <%--<div class="col-lg-3 control-label">&nbsp;</div>--%>
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnRestore" runat="server" Text="Restore Defaults" CssClass="btn btn-primary" OnClick="btnRestore_Click" Style="width: 35%;" />
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfMiscellaneousID" />
</asp:Content>
