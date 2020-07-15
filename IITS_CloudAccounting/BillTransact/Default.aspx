<%@ Page Title="" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IITS_CloudAccounting.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- ReSharper disable UnknownCssClass --%>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Dashboard
                    </a>
                </li>
            </ol>
            <div class="page-header" id="dashboard" runat="server">
                <h1>Dashboard</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlMasterAdmin">
        <div class="col-sm-4">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Companies Register In Bill Transact
                            <div class="panel-tools">
                                <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                <a class="btn btn-xs btn-link panel-refresh" href="#">
                                    <i class="fa fa-refresh"></i>
                                </a>
                            </div>
                        </div>
                        <div class="panel-body" style="display: block;">
                            <asp:DataList runat="server" ID="dlTotalCompany" Width="100%" DataSourceID="sqldsTotalCompany">
                                <ItemTemplate>
                                    <h3 style="display: inline-block; margin: 10px 0 0 0;">Total Company:</h3>
                                    <asp:Label Text='<%# Eval("[Total Company]") %>' runat="server" ID="Total_CompanyLabel" Style="float: right" CssClass="circle-icon circle-green" />
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource runat="server" ID="sqldsTotalCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT COUNT(*) AS 'Total Company' FROM CompanyMaster"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Companies Package Expiration
                            <div class="panel-tools">
                                <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                <a class="btn btn-xs btn-link panel-refresh" href="#">
                                    <i class="fa fa-refresh"></i>
                                </a>
                            </div>
                        </div>
                        <div class="panel-body" style="display: block; height: 200px; overflow-y: auto;">
                            <asp:GridView runat="server" ID="gvCompanyPackageDate" AutoGenerateColumns="False" DataSourceID="sqldsCompanyPackageDate" Width="100%" CssClass="table table-bordered table-responsive">
                                <Columns>
                                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company"></asp:BoundField>
                                    <asp:BoundField DataField="Expiration Date" HeaderText="Expiration Date" SortExpression="Expiration Date" DataFormatString="{0:dd-MMM-yyyy}"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsCompanyPackageDate" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CompanyName AS 'Company',PackageEndDate AS 'Expiration Date' FROM CompanyPackageMaster a INNER JOIN CompanyMaster b ON a.CompanyID = b.CompanyID "></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Companies Current Package
                            <div class="panel-tools">
                                <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                <a class="btn btn-xs btn-link panel-refresh" href="#">
                                    <i class="fa fa-refresh"></i>
                                </a>
                            </div>
                        </div>
                        <div class="panel-body" style="display: block; height: 200px; overflow-y: auto;">
                            <asp:GridView runat="server" ID="gvCompanyPackage" AutoGenerateColumns="False" DataSourceID="sqldsCompanyPackage" Width="100%" CssClass="table table-bordered table-responsive">
                                <Columns>
                                    <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company"></asp:BoundField>
                                    <asp:BoundField DataField="Package Name" HeaderText="Package Name" SortExpression="Package Name" ReadOnly="True"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsCompanyPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CompanyName AS 'Company',ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyPackageMaster a INNER JOIN CompanyMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON a.CloudPackageID = c.CloudPackageID"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlCompanyAdmin">
        <div class="row" style="margin-top: 25px;" id="packageInfo" runat="server" visible="False">
            <div class="col-sm-3">&nbsp;</div>
            <div class="col-sm-6">
                <div class="panel panel-default" style="height: 270px">
                    <div class="panel-heading">
                        <i class="fa fa-warning"></i>
                        Package Information
                    </div>
                    <div class="panel-body panel-scroll ps-container" style="height: 250px">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="alert alert-danger fade in">
                                        <p style="font-size: 20px; text-align: center; margin: 20px auto;">
                                            Your Package Is Expired..! Please Upgrade Package To Work In Your Cloud Invoicing Portal.!!
                                        </p>
                                        <div style="color: white; text-align: center">
                                            <asp:Button ID="btnUpgrade" runat="server" Text="Upgrade" CssClass="btn btn-bricky" OnClick="BtnUpgradeClick" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">&nbsp;</div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlEmployee"></asp:Panel>
</asp:Content>
