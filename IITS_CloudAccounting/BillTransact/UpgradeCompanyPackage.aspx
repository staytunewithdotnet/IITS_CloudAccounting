<%@ Page Title="Upgrade Company Package Details" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="UpgradeCompanyPackage.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpgradeCompanyPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Company Management
                    </a>
                </li>
                <li>
                    <a href="UpgradeCompanyPackage.aspx">Upgrade Company Package Details</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Upgrade Company Package Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlUpgrade">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlCompanyName" CssClass="form-control" TabIndex="1" DataSourceID="SqlCompanyMaster" DataTextField="CompanyName" DataValueField="CompanyID">
                            </asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlCompanyMaster" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT 0 AS CompanyID, '--Select Company--' AS CompanyName UNION SELECT [CompanyID], [CompanyName] FROM [CompanyMaster]"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Company Name Reqiured" InitialValue="0" ControlToValidate="ddlCompanyName" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Current Package:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageName"></asp:Label>
                            <asp:HiddenField runat="server" ID="hfPackageID" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="upPackage">
            <ContentTemplate>
                <div id="finalHide" runat="server">
                    <div class="page-header">
                        <h1>New Package Details</h1>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-2">&nbsp;</div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Select Package:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:DropDownList runat="server" ID="ddlPackageName" CssClass="form-control" TabIndex="2" DataSourceID="SqlPackageMaster" DataTextField="PackageName" DataValueField="PackageID" AutoPostBack="True" OnSelectedIndexChanged="ddlPackageName_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlPackageMaster" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="select 0 AS PackageID,'--Select Package--' as PackageName UNION  SELECT [PackageID], [PackageName] FROM [PackageMaster]"></asp:SqlDataSource>
                                        <asp:RequiredFieldValidator ID="rfvPackageName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Name Reqiured" InitialValue="0" ControlToValidate="ddlPackageName" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4">&nbsp;</div>
                    </div>
                </div>
                <div id="viewPackage" runat="server" visible="False">
                    <div class="panel-body">
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Free Trial Package:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label runat="server" ID="lblTrial"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group" id="NoOfTrialDaysView" runat="server">
                                    <div class="col-lg-4 control-label">
                                        No Of Trial Days:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label runat="server" ID="lblNoTrialDays"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        No Of Admin Users Login:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label Text="1" ID="lblAdminUsersMin" runat="server"></asp:Label>
                                        &nbsp;&nbsp;to&nbsp;&nbsp;
                                        <asp:Label Text="1" ID="lblAdminUsersMax" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        No Of Staff Users Login:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label Text="1" ID="lblStaffUsersMin" runat="server"></asp:Label>
                                        &nbsp;&nbsp;to&nbsp;&nbsp;
                                        <asp:Label Text="1" ID="lblStaffUsersMax" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Price Per Month:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label ID="lblMonthCurrency" runat="server"></asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblPricePerMonth" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Price Per Year:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label ID="lblYearlyCurrency" runat="server"></asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblPricePerYear" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Description:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12" style="text-align: center;">
                                <asp:Button ID="btnUpgrade" runat="server" Text="Request To Upgrade" CssClass="btn btn-orange" OnClick="btnUpgrade_Click" />
                                <asp:Button ID="btnList" runat="server" Text="List All" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="info" runat="server" visible="False">
                    <div class="page-header">
                        <h1>Information</h1>
                    </div>
                    <div class="col-lg-2">&nbsp;</div>
                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        <asp:Label runat="server" ID="lblInfo" Style="color: #0DB9B7; font-family: monospace; font-size: x-large; text-align: center;" Text="Your Request Of Upgradation Is Successfully Sent to MasterAdmin..! He/She Will Contact You As Soon As Possible."></asp:Label>
                    </div>
                    <div class="col-lg-2">&nbsp;</div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
