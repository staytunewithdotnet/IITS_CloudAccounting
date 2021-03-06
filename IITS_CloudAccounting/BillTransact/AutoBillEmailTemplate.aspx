﻿<%@ Page Title="Auto Bill Email Template" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="AutoBillEmailTemplate.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AutoBillEmailTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
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
                    <a href="AutoBillEmailTemplate.aspx">Auto Bill Email</a>
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
            <h1>Auto Bill Email</h1>
        </div>
        <div class="panel-body" style="padding: 15px 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <asp:UpdatePanel runat="server" ID="upAutoEmail">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-2 control-label">
                                    Template For
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlTemplateFor" AutoPostBack="True" OnSelectedIndexChanged="ddlTemplateFor_OnSelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="Auto-bill">Auto-bill</asp:ListItem>
                                        <asp:ListItem Value="Auto-paid">Auto-paid</asp:ListItem>
                                        <asp:ListItem Value="Card Expired">Card Expired</asp:ListItem>
                                        <asp:ListItem Value="Card Failed">Card Failed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group" id="checkboxEnable" runat="server" Visible="False">
                                <div class="col-lg-2 control-label">
                                    Enable
                                </div>
                                <div class="col-lg-10">
                                    <asp:CheckBox runat="server" ID="chkEnable" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-2 control-label">
                                    Subject
                                </div>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="txtSubject" Enabled="False"></asp:TextBox>
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
                            <div class="form-group" id="divAuto" runat="server">
                                <div class="col-lg-2 control-label">&nbsp;</div>
                                <div class="col-lg-10">
                                    <div class="btn-group" role="group">
                                        <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #999; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                            Insert Email Variable<span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li>
                                                <a onclick="writeInTextBox('##invoiceNumber##')">Invoice Number</a>
                                                <a onclick="writeInTextBox('##someLink##')">Invoice Link</a>
                                                <a onclick="writeInTextBox('##companyName##')">Company Name</a>
                                                <a onclick="writeInTextBox('##invoiceAmt##')">Payment Amount</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group" id="divCard" runat="server" visible="False">
                                <div class="col-lg-2 control-label">&nbsp;</div>
                                <div class="col-lg-10">
                                    <div class="btn-group" role="group">
                                        <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #999; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                            Insert Email Variable<span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li>
                                                <a onclick="writeInTextBox('##clientHome##')">Client Home Link</a>
                                                <a onclick="writeInTextBox('##companyName##')">Company Name</a>
                                                <a onclick="writeInTextBox('##clientOrgName##')">Client Organization</a>
                                                <a onclick="writeInTextBox('##firstName##')">Client First Name</a>
                                                <a onclick="writeInTextBox('##lastName##')">Client Last Name</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" />
                            <asp:Button runat="server" ID="btnDefault" Text="Default" CssClass="btn btn-primary" />
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
