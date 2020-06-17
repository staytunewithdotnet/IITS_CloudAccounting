<%@ Page Title="Invoice & Estimate Template" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="InvoiceTemplate.aspx.cs" Inherits="IITS_CloudAccounting.Admin.InvoiceTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });

        function showHideDiv() {
            var ddl = document.getElementById("<%= ddlInvoiceTemplate.ClientID%>");
            var div = document.getElementById("hideDiv");
            if (ddl.value == "clean-grouped") {
                div.style.display = 'block';
            } else if (ddl.value == "classic-grouped") {
                div.style.display = 'none';
            }
        }
    </script>
    <style>
        a.no-hover:hover {
            background: transparent;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="InvoiceTemplate.aspx">Invoice & Estimate Template</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your invoice template preferences have been saved.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0;">
            <h1>Invoice & Estimate Template</h1>
            Select a template and customize what appears on it.
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-4">
                            <%--<a class="no-hover" href="../App_Themes/Doyingo/images/invoice-clean.pdf" target="_blank">--%>
                                <img src="../App_Themes/Doyingo/images/template_clean.gif" alt="" width="250" height="315" />
                            <%--</a>--%>
                        </div>
                        <div class="col-lg-1">&nbsp;</div>
                        <div class="col-lg-4">
                            <%--<a class="no-hover" href="../App_Themes/Doyingo/images/invoice-classic.pdf" target="_blank">
                                <img src="../App_Themes/Doyingo/images/template_classic.gif" alt="" width="250" height="315" />
                            </a>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">&nbsp;</div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3">
                            Choose Your Template
                        </div>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlInvoiceTemplate" runat="server" onchange="showHideDiv()" CssClass="form-control text">
                                <asp:ListItem Value="clean-grouped" Selected="True">Clean Template</asp:ListItem>
                                <%--<asp:ListItem Value="classic-grouped">Classic Template</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-9">
                            Changes to your invoice template do not affect existing invoices.
                        </div>
                    </div>
                    <div id="hideDiv" style="display: block;">
                        <div class="form-group" style="margin-bottom: 0;">
                            <div class="col-lg-3">
                                Invoice Title
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtInvoiceTitle" CssClass="form-control text" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3">&nbsp;</div>
                            <div class="col-lg-9">
                                Changes the title of all your new and existing invoices.
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom: 0;">
                            <div class="col-lg-3">
                                Estimate Title
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtEstimateTitle" CssClass="form-control text" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3">&nbsp;</div>
                            <div class="col-lg-9">
                                Changes the title of all your new and existing estimates.
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom: 0;">
                            <div class="col-lg-3">
                                Credit Title
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtCreditTitle" CssClass="form-control text" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3">&nbsp;</div>
                            <div class="col-lg-9">
                                Changes the title of all your new and existing credits.
                            </div>
                        </div>
                        <div class="form-group" style="margin-bottom: 0;">
                            <div class="col-lg-3">
                                Payment Stub
                            </div>
                            <div class="col-lg-9">
                                <asp:CheckBox runat="server" ID="chkPaymentStub" Text="Show Payment Stub" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3">&nbsp;</div>
                            <div class="col-lg-9">
                                Adds a tear-off stub to the end of PDFs.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <%--<div class="col-lg-3 control-label">&nbsp;</div>--%>
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfTempalteID" />
</asp:Content>
