<%@ Page Title="Export To CSV" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="ExportToCSV.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ExportToCSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <style>
        .hl, .highlight {
            background-color: #ff9;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="DefaultDoyingo.aspx">Dashboard
                    </a>
                </li>
                <li>
                    <a href="ExportToCSV.aspx">Export To CSV</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header">
            <h1>Export to Comma Separated Text File (CSV)</h1>
            <p><span class="hl">To export:</span> click on the appropriate link below and save to a local computer</p>
        </div>
        <table width="100%" cellpadding="5" cellspacing="0" class="index">
            <tr align="center">
                <th style="background-color: #0D83DD; color: #ffffff; width: 50%; padding: 7px;"><strong>Export</strong></th>
                <th style="background-color: #0D83DD; color: #ffffff; width: 50%; padding: 7px;"><strong>Version</strong></th>
            </tr>
            <tr align="center">
                <td style="padding: 7px 3px; vertical-align: top; width: 33%;">
                    <asp:LinkButton runat="server" ID="lnkClient" CssClass="permission" OnClick="lnkClient_OnClick">Clients</asp:LinkButton>
                    &nbsp; &nbsp;
					<asp:LinkButton runat="server" ID="lnkStaff" CssClass="permission" OnClick="lnkStaff_OnClick">Staff</asp:LinkButton>
                    &nbsp; &nbsp;
					<asp:LinkButton runat="server" ID="lnkInvoice" CssClass="permission" OnClick="lnkInvoice_OnClick">Invoices</asp:LinkButton>
                    &nbsp; &nbsp;
					<asp:LinkButton runat="server" ID="lnkTimesheet" CssClass="permission" OnClick="lnkTimesheet_OnClick">Timesheets</asp:LinkButton>
                    &nbsp; &nbsp;
                </td>
                <td style="padding: 7px 3px; vertical-align: top; width: 67%;">Comma Separated Text File (CSV)</td>
            </tr>
        </table>
        <h3>Notes:</h3>
        <ul>
            <li>All <span class="hl">active</span> clients, staff, invoices and timesheets are available for export to a comma separated text file</li>
            <li>This file is formatted with the column headings on the first line and the information on the lines that follow</li>
            <li>Each field is separated by a comma and can easily be manipulated with a spreadsheet application such as Excel</li>
            <li><span class="hl">Warning:</span> if any fields contain commas, the fields will be separated and will not align with the column headings</li>
            <li>It is recommended that all maintenance of client information be done in one system only</li>
        </ul>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyName" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
</asp:Content>
