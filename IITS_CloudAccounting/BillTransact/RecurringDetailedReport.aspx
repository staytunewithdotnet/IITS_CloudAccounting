<%@ Page Title="Recurring Detailed Report" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="RecurringDetailedReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.RecurringDetailedReport" %>

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
                    <a href="RecurringDetailedReport.aspx">Recurring Detailed</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Recurring Revenue - Detailed</h1>
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
            <div class="col-lg-2">
                <span class="control-label">Clients:</span>
                <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text" DataSourceID="sqldsClient" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS ID,'All Client' AS Name UNION SELECT CompanyClientID,OrganizationName AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-3">
                <span class="control-label">&nbsp;</span>
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
                <h1 style="margin-bottom: 0;">Recurring Revenue - Detailed
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
                <h5 style="font-weight: normal;margin-bottom: 20px">
                    This report shows forecasted recurring revenue for each client and recurring profile for every date of recurrence over the specified date range.
                </h5>
            </div>
            <div class="clearfix"></div>
            <asp:GridView runat="server" ID="gvRecurringDetail" Width="100%" CssClass="reportTable table table-responsive" GridLines="None" DataSourceID="objdsRecurringDetail"
                OnRowDataBound="gvRecurringDetail_OnRowDataBound">
                <HeaderStyle BackColor="#0083E0" ForeColor="White"></HeaderStyle>
                <EmptyDataTemplate>
                    <div style="width: 100%; text-align: center">
                        No payments were found.
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="objdsRecurringDetail" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ReportRecurringDetailedTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="ComapnyID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="ClientID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
