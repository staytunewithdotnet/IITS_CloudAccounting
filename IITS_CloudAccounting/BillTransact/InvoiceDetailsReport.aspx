<%@ Page Title="Invoice Details Report" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="InvoiceDetailsReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.InvoiceDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <div class="row" style="margin-top: -45px;">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-download"></i>
                    <a href="AllReports.aspx">Reports
                    </a>
                </li>
                <li>
                    <a href="InvoiceDetailsReport.aspx">Invoice Details</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Invoice Details</h1>
            <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; float: right" class="btn-info">Generate PDF</a>
        </div>
        <div class="panel-body" style="background-color: #f1f1f1; margin-bottom: 20px;">
            <div class="col-lg-4">
                <span class="control-label">Date Range:</span>
                <br />
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtDateFrom" Format="dd/MMM/yyyy" />
                </div>
                <div class="col-lg-1" style="padding: 8px 0 0 4px">to</div>
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtDateTo" Format="dd/MMM/yyyy" />
                </div>
            </div>
            <div class="col-lg-3">
                <span class="control-label">Clients:</span>
                <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text" DataSourceID="sqldsClient" DataTextField="OrganizationName" DataValueField="CompanyClientID" />
                <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CompanyClientID,OrganizationName FROM CompanyClientMaster a WHERE a.CompanyID = @CompanyID UNION SELECT NULL,'All' ORDER BY CompanyClientID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-2">
                <span class="control-label">Invoice Status:</span>
                <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control text">
                    <asp:ListItem Value="" Selected="True">All</asp:ListItem>
                    <asp:ListItem Value="disputed">disputed</asp:ListItem>
                    <asp:ListItem Value="draft">draft</asp:ListItem>
                    <asp:ListItem Value="sent">sent</asp:ListItem>
                    <asp:ListItem Value="viewed">viewed</asp:ListItem>
                    <asp:ListItem Value="paid">paid</asp:ListItem>
                    <asp:ListItem Value="auto-paid">auto-paid</asp:ListItem>
                    <asp:ListItem Value="retry">retry</asp:ListItem>
                    <asp:ListItem Value="failed">failed</asp:ListItem>
                    <asp:ListItem Value="partial">partial</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3">
                <span class="control-label">&nbsp;</span><br />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdateClick" Style="width: 50% !important;" />
            </div>
        </div>
        <div id="printDiv" class="panel-body rounded-container peel-shadows" style="background-color: #fff !important; color: #000 !important;">
            <div class="col-lg-12" style="text-align: right">
                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/logo.jpg" style="height: 85px;width: 15%;" />
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center">
                <h1 style="margin-bottom: 0;">Invoice Details
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 20px;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
            </div>
            <div class="clearfix"></div>
            <%--<asp:GridView runat="server" ID="gvInvoice" CssClass="reportTable table table-responsive" Width="100%" GridLines="None">
                <HeaderStyle BackColor="#0083E0" ForeColor="White"></HeaderStyle>
                <EmptyDataTemplate>
                    No invoice available in this search values.
                </EmptyDataTemplate>
            </asp:GridView>--%>
            <br />
            <div runat="server" id="divGrids"></div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
