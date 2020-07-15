<%@ Page Title="New Client Email Template" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewClientEmailTemplate.aspx.cs" Inherits="IITS_CloudAccounting.Admin.NewClientEmailTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: -45px;">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-cogs"></i>
                    <a href="UpdateCompanyDetail.aspx">Settings
                    </a>
                </li>
                <li>
                    <a href="CustomizeEmails.aspx">Emails</a>
                </li>
                <li>
                    <a href="NewClientEmailTemplate.aspx">New Client Email Template</a>
                </li>
            </ol>
        </div>
    </div>
    <script type="text/javascript">
        function writeInTextBox(text) {
            var textBox = document.getElementById('<%=txtBody.ClientID%>');
            textBox.innerHTML += " " + text;
        }
    </script>
    <style>
        input[type=text], textarea {
            font-family: Verdana,sans-serif;
            font-size: 12px;
            line-height: normal;
            padding: 3px;
            margin: 0;
        }
    </style>
    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>New Client Email</h1>
        </div>
        <div class="panel-body" style="padding: 15px 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-2 control-label">
                            Subject
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtSubject" Text="New Client ::ClientNum:: from ::companyName:: , sent using Bill Transact" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">
                            Body
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtBody" TextMode="MultiLine" Height="160px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <div class="btn-group" role="group">
                                <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #999; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                    Insert Email Variable<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <a onclick="writeInTextBox('##loginLink##')">Login Link</a>
                                        <a onclick="writeInTextBox('##company##')">Company Name</a>
                                        <a onclick="writeInTextBox('##clientOrgName##')">Client Organization</a>
                                        <a onclick="writeInTextBox('##firstName##')">Client First Name</a>
                                        <a onclick="writeInTextBox('##lastName##')">Client Last Name</a>
                                        <a onclick="writeInTextBox('##username##')">Username</a>
                                        <a onclick="writeInTextBox('##password##')">Password</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                            <asp:Button runat="server" ID="btnDefault" Text="Default" CssClass="btn btn-primary" OnClick="btnRestore_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfEmailID" />
</asp:Content>
