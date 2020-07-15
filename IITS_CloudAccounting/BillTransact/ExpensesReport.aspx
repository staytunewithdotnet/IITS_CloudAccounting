<%@ Page Title="Expenses Report" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="ExpensesReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ExpensesReport" %>

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
                    <a href="ExpensesReport.aspx">Expenses</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Expenses</h1>
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
                <span class="control-label">Category:</span>
                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control text" DataSourceID="sqldsCategory" DataTextField="SubCategoryName" DataValueField="SubCategoryID" />
                <asp:SqlDataSource runat="server" ID="sqldsCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT a.SubCategoryID,SubCategoryName FROM SubCategoryMaster a INNER JOIN ExpenseMaster b ON a.SubCategoryID = b.SubCategoryID WHERE CompanyID = @CompanyID UNION SELECT NULL,'All'">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-2">
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
                <h1 style="margin-bottom: 0;">Expenses
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 20px;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
            </div>
            <div class="clearfix"></div>
            <asp:GridView runat="server" ID="gvExpense" CssClass="reportTable table table-responsive" Width="100%" GridLines="None" AutoGenerateColumns="False" DataSourceID="objdsExpense">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date"></asp:BoundField>
                    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category"></asp:BoundField>
                    <asp:BoundField DataField="Vendor" HeaderText="Vendor" SortExpression="Vendor"></asp:BoundField>
                    <asp:BoundField DataField="Client" HeaderText="Client" SortExpression="Client"></asp:BoundField>
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                </Columns>
                <HeaderStyle BackColor="#0083E0" ForeColor="White"></HeaderStyle>
                <EmptyDataTemplate>
                    No expense data found. Please adjust your filters.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="objdsExpense" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ReportExpensesTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="ddlCategory" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="SubCategoryID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" Name="FromDate" ConvertEmptyStringToNull="True" Type="DateTime"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" Name="ToDate" ConvertEmptyStringToNull="True" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
