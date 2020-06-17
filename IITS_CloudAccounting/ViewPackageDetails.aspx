<%@ Page Title="View Package Details" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="ViewPackageDetails.aspx.cs" Inherits="IITS_CloudAccounting.ViewPackageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">View Package Details</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">View Package Details</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="pricing" class="section mainSection graySection  pricing">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div class="vc_col-sm-5 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row">
                            <asp:Repeater runat="server" ID="rpPackage" DataSourceID="sqldsPackage">
                                <ItemTemplate>
                                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                                        <div class="wpb_wrapper">
                                            <div class="pricingTable">
                                                <asp:Label Text='<%# Eval("PackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                                <asp:Label Text='<%# Eval("FreeTrialPackage") %>' runat="server" ID="FreeTrialPackageLabel" Visible="False" />
                                                <asp:Label Text='<%# Eval("NoOfTrialDays") %>' runat="server" ID="NoOfTrialDaysLabel" Visible="False" />
                                                <header class="pricingHeader clearfix">
                                                    <h3 class="pricingTitle planTitle">Package Modules
                                                        <br />
                                                    </h3>
                                                </header>

                                                <ul class="pricingBody planBody">
                                                    <asp:Repeater runat="server" ID="rpPackageModule" DataSourceID="sqldsPackageModule">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%# Eval("PackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                                            <asp:Label Text='<%# Eval("ModuleID") %>' runat="server" ID="ModuleIDLabel" Visible="False" />

                                                            <li>
                                                                <%# Eval("ModuleName") %>
                                                                <span>
                                                                    <%# SetIconTrueFalse(bool.Parse(Eval("ModuleStatus").ToString())) %>
                                                                </span>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="clearfix">
                                                        <p style="margin-bottom: 20px;">
                                                            <a class="generalLink" href="#" style="cursor: default;">
                                                                <%# String.Format("{0:0.00}",Eval("PricePerMonth")) %>&nbsp;<%# GetCurrency(Eval("MonthlyPriceCurrencyID").ToString()) %><br />
                                                                Month
                                                            </a>
                                                        </p>
                                                        <p style="margin-bottom: 20px;">
                                                            <a class="generalLink" href="#" style="cursor: default;">
                                                                <%# String.Format("{0:0.00}",Eval("PricePerYear")) %>&nbsp;<%# GetCurrency(Eval("YearlyPriceCurrencyID").ToString()) %><br />
                                                                Year
                                                            </a>
                                                        </p>
                                                        <p style="margin: 0 auto; float: none;">
                                                            <a class="generalLink orderNow" href='<%# "CompanyRegistration.aspx?pId=" + Eval("PackageID") %>'>
                                                                <i class="fa fa-hand-o-right"></i>&nbsp; Sign Up Now
                                                            </a>
                                                        </p>
                                                    </li>
                                                </ul>
                                                <asp:SqlDataSource runat="server" ID="sqldsPackageModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT A.PackageID,B.ModuleID,B.ModuleName,A.ModuleStatus FROM PackageDetails A LEFT JOIN ModuleMaster B ON A.ModuleID = B.ModuleID WHERE PackageID = @PackageID">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="PackageIDLabel" PropertyName="Text" DefaultValue="0" Name="PackageID"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="vc_col-sm-1 wpb_column vc_column_container">&nbsp;</div>
                <div class="vc_col-sm-5 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row">
                            <div class="widget">
                                <h3 class="widgetHeader">Package Details</h3>
                                <ul class="list">
                                    <asp:Repeater runat="server" ID="rpPackageDetail" DataSourceID="sqldsPackage">
                                        <ItemTemplate>
                                            <li>
                                                <h5 style="display: inline-block;">Package Name : </h5>
                                                <asp:Label Text='<%# Eval("PackageName") %>' runat="server" ID="PackageNameLabel" Style="font-size: 18px;" />
                                            </li>
                                            <li>
                                                <h5 style="display: inline-block;">Admin Users : </h5>
                                                <span>
                                                    <asp:Label Text='<%# Eval("NoOfAdminUsersMin") %>' runat="server" ID="NoOfAdminUsersMinLabel" Style="font-size: 18px;" />
                                                    to
                                                    <asp:Label Text='<%# Eval("NoOfAdminUsersMax") %>' runat="server" ID="NoOfAdminUsersMaxLabel" Style="font-size: 18px;" />
                                                </span>
                                            </li>

                                            <li>
                                                <h5 style="display: inline-block;">Staff Users : </h5>
                                                <span>
                                                    <asp:Label Text='<%# Eval("NoOfStaffUsersMin") %>' runat="server" ID="NoOfStaffUsersMinLabel" Style="font-size: 18px;" />
                                                    to
                                                    <asp:Label Text='<%# Eval("NoOfStaffUsersMax") %>' runat="server" ID="NoOfStaffUsersMaxLabel" Style="font-size: 18px;" />
                                                </span>
                                            </li>
                                            <li>
                                                <h5 style="display: inline-block;">Free Trial Package : </h5>
                                                <asp:Label Text='<%# bool.Parse(Eval("FreeTrialPackage").ToString())?"Yes":"No" %>' runat="server" ID="FreeTrialPackageLabel" Style="font-size: 18px;" />
                                            </li>
                                            <li runat="server" visible='<%# Eval("FreeTrialPackage") %>'>
                                                <h5 style="display: inline-block;">No Of Trial Days : </h5>
                                                <asp:Label Text='<%# Eval("NoOfTrialDays") %>' runat="server" ID="NoOfTrialDaysLabel" Style="font-size: 18px;" />
                                            </li>
                                            <li>
                                                <h5 style="display: inline-block;">Description : </h5>
                                                <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" Style="font-size: 15px;" />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="vc_col-sm-1 wpb_column vc_column_container">&nbsp;</div>
            </div>
        </div>
    </section>
    <asp:SqlDataSource runat="server" ID="sqldsPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT PackageID, PackageName, FreeTrialPackage, NoOfAdminUsersMin, NoOfAdminUsersMax , NoOfStaffUsersMin, NoOfStaffUsersMax, PricePerMonth, MonthlyPriceCurrencyID, PricePerYear, YearlyPriceCurrencyID, Description, NoOfTrialDays, Status FROM PackageMaster WHERE (Status = @Status) AND PackageID = @PackageID">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Status"></asp:Parameter>
            <asp:QueryStringParameter DefaultValue="0" Name="PackageID" Type="Int32" QueryStringField="pId" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
