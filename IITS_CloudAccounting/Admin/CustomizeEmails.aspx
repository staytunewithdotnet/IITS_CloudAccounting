<%@ Page Title="Customize Emails" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="CustomizeEmails.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CustomizeEmails" %>

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
                    <a href="CustomizeEmails.aspx">Customize Emails</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Emails for your clients & staff</h1>
            Brand the emails sent by Bill Transact on your behalf.
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
                            Emails
                        </div>
                        <div class="col-lg-9">
                            <div style="padding-bottom: 5px">
                                New invoice (<a href="NewInvoiceEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                Payment notifications (<a href="NewPaymentEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                Late payment reminders (<a href="LatePaymentReminderTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                Auto-bill (<a href="AutoBillEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                New estimate (<a href="NewEstimateEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                New credit (<a href="NewCreditEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                New client (<a href="NewClientEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                            <div style="padding-bottom: 5px">
                                New staff (<a href="NewStaffEmailTemplate.aspx" class="permission">edit</a>)
                            </div>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <div class="col-lg-3 control-label">
                            Email Signature
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtEmailSignature" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            &nbsp;
                        </div>
                        <div class="col-lg-9">&nbsp;
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Emails for you</h1>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkWeekAccount" Text="Weekly Account Summary" />
                            <br />
                            Contains interesting information on time tracked, invoices made, and payments collected. Keep up with the activity in your account.
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Send me an email when:</div>
                        <div class="col-lg-9">
                            <asp:CheckBox runat="server" ID="chkPayment" Text="A payment is received" /><br />
                            <asp:CheckBox runat="server" ID="chkPaymentReceive" Text="A late payment reminder is sent" /><br />
                            <asp:CheckBox runat="server" ID="chkInvoice" Text="An invoice is sent by email" /><br />
                            You will receive an email whenever any one of these actions is taken by either yourself, a staff member, the API, or automatically by a recurring invoice.
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-9" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            </div>
            <div class="col-lg-3 control-label">&nbsp;</div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
</asp:Content>
