<%@ Page Title="Online Payment Of Invoice" Language="C#" MasterPageFile="~/Client/ClientManagement.Master"
    AutoEventWireup="true" CodeBehind="InvoicePaymentMode.aspx.cs" Inherits="IITS_CloudAccounting.Client.InvoicePaymentMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoice
                    </a>
                </li>
                <li>
                    <a href="InvoicePayment.aspx">Select Payment Mode
                    </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <h1>Select Payment Mode
        </h1>
        <asp:Panel runat="server" ID="pnlPayment">
            <div class="col-lg-12 peel-shadows rounded-container">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:RadioButton ID="rdIOPayment" runat="server" Text="IO Payment" AutoPostBack="true" OnCheckedChanged="rdIOPayment_CheckedChanged" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:RadioButton ID="rdPayPal" runat="server" Text="Pay Pal Payment" AutoPostBack="true" OnCheckedChanged="rdPayPal_CheckedChanged" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

</asp:Content>
