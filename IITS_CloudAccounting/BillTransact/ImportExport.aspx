<%@ Page Title="Import & Export" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ImportExport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ImportExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("accountDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">My Account
                    </a>
                </li>
                <li>
                    <a href="ImportExport.aspx">Import & Export</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Import & Export</h1>
            <h6>Have a lot of clients? Don't enter them all manually, import them.</h6>
        </div>

        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label" style="padding-top: 0;">
                            Import Clients
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <a href="ImportCompanyClients.aspx?format=csv" class="permission">CSV (Outlook or Bill Transact compatible)</a><br />
                            <a href="ImportCompanyClients.aspx?format=vcard" class="permission">vCard (e.g. Mac OS X Address Book)</a><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label" style="padding-top: 0;">
                            Import Expenses
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <a href="ImportExpense.aspx" class="permission">From a CSV or QBO file</a><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label" style="padding-top: 0;">
                            Export Clients, Invoices, Staff and Timesheets
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <a href="ExportToCSV.aspx" class="permission">Comma Separated File (CSV)</a>
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <div class="col-lg-4 control-label" style="padding-top: 0;">
                            Export Clients
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <a href="#" class="permission">QuickBooks</a><br />
                            <a href="#" class="permission">Simply Accounting</a><br />
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
