<%@ Page Title="Accounts Aging Report" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="AccountsAgingReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AccountsAgingReport" %>

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
                    <a href="AccountsAgingReport.aspx">Accounts Aging</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Accounts Aging</h1>
            <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; float: right" class="btn-info">Generate PDF</a>
        </div>
        <div class="panel-body" style="background-color: #f1f1f1; margin-bottom: 20px;">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Period Ending
                        </div>
                        <div class="col-lg-7">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control text"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="ceDate" TargetControlID="txtDate" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6" style="text-align: right;">
                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdateClick" />
            </div>
        </div>
        <div id="printDiv" class="panel-body rounded-container peel-shadows" style="background-color: #fff !important; color: #000 !important;">
            <div class="col-lg-12" style="text-align: right">
                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/logo.jpg" style="height: 85px;width: 15%;" />
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center">
                <h1 style="margin-bottom: 0;">Accounts Aging
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal;">As Of&nbsp;
                    <asp:Label runat="server" ID="lblDate"></asp:Label>
                </h4>
            </div>
            <div class="clearfix"></div>
            <asp:GridView runat="server" ID="gvAccount" Width="100%" DataSourceID="sqldsAccount" CssClass="reportTable table table-responsive" GridLines="None">
                <HeaderStyle BackColor="#0083E0" ForeColor="White"></HeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="sqldsAccount" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="PR_Report_AccountsAging" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="hfDate" PropertyName="Value" Name="EndDate" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfDate" />
</asp:Content>
