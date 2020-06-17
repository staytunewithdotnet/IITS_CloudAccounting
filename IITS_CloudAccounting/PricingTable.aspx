<%@ Page Title="Bill Transact - Pricing Tables" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="PricingTable.aspx.cs" Inherits="IITS_CloudAccounting.PricingTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Pricing Tables</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Pricing Tables</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="pricing" class="section mainSection graySection  pricing">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div>
                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="wpb_row row">
                                <div class="vc_col-sm-12 wpb_column vc_column_container">
                                    <div class="wpb_wrapper">
                                        <div class="col-md-12 sectionTitle">
                                            <h2 class="sectionHeader">Great Plans, Different Packages And Incredible Prices :)<span class="generalBorder"></span></h2>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="wpb_row row">
                                <asp:Repeater runat="server" ID="rpPackage" DataSourceID="sqldsPackage">
                                    <ItemTemplate>
                                        <div class="vc_col-sm-4 wpb_column vc_column_container">
                                            <div class="wpb_wrapper">
                                                <div class="pricingTable">
                                                    <asp:Label Text='<%# Eval("PackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                                    <asp:Label Text='<%# Eval("FreeTrialPackage") %>' runat="server" ID="FreeTrialPackageLabel" Visible="False" />
                                                    <asp:Label Text='<%# Eval("NoOfTrialDays") %>' runat="server" ID="NoOfTrialDaysLabel" Visible="False" />
                                                    <header class="pricingHeader clearfix">
                                                        <h3 class="pricingTitle">
                                                            <%# Eval("PackageName") %>
                                                            <br />
                                                        </h3>
                                                    </header>

                                                    <ul class="pricingBody">
                                                        <li>Minimum # of Admin Users<span><asp:Label Text='<%# Eval("NoOfAdminUsersMin") %>' runat="server" ID="NoOfAdminUsersMinLabel" /></span>      </li>
                                                        <li>Maximum # of Admin Users<span><asp:Label Text='<%# Eval("NoOfAdminUsersMax") %>' runat="server" ID="NoOfAdminUsersMaxLabel" /></span>      </li>
                                                        <li>Minimum # of Staff Users<span><asp:Label Text='<%# Eval("NoOfStaffUsersMin") %>' runat="server" ID="NoOfStaffUsersMinLabel" /></span>      </li>
                                                        <li>Maximum # of Staff Users<span><asp:Label Text='<%# Eval("NoOfStaffUsersMax") %>' runat="server" ID="NoOfStaffUsersMaxLabel" /></span>      </li>
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
                                                                <%--<a class="generalLink orderNow" href='<%# "CompanyRegistration.aspx?pId=" + Eval("PackageID") %>'>--%>
                                                                <a class="generalLink orderNow" href="CompanySignUp.aspx">
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
                                <asp:SqlDataSource runat="server" ID="sqldsPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT PackageID, PackageName, FreeTrialPackage, NoOfAdminUsersMin, NoOfAdminUsersMax , NoOfStaffUsersMin, NoOfStaffUsersMax, PricePerMonth, MonthlyPriceCurrencyID, PricePerYear, YearlyPriceCurrencyID, Description, NoOfTrialDays, Status FROM PackageMaster WHERE (Status = @Status)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="Status"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
