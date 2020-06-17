<%@ Page Title="Bill Transact - Pricing Table" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="NewPricingTable.aspx.cs" Inherits="IITS_CloudAccounting.NewPricingTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .xyz > tbody > tr > td {
            text-align: center;
        }

        .xyz > tbody > tr:nth-child(2n) td {
            background: #fafafa;
        }

        .upgrade-table tr:nth-child(2n) td {
            background: #fafafa;
        }

        [data-tooltip] {
            position: relative;
            z-index: 2;
            cursor: pointer;
        }

            [data-tooltip]:before,
            [data-tooltip]:after {
                visibility: hidden;
                -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=0)";
                filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=0);
                opacity: 0;
                pointer-events: none;
            }

            [data-tooltip]:before {
                position: absolute;
                bottom: 0;
                left: -215px;
                margin-bottom: 5px;
                margin-left: 0;
                padding: 7px;
                width: 260px;
                border-radius: 3px;
                background-color: #000;
                background-color: hsla(0, 0%, 20%, 0.9);
                color: #fff;
                content: attr(data-tooltip);
                text-align: center;
                font-size: 14px;
                line-height: 1.2;
            }

            [data-tooltip]:after {
                position: absolute;
                bottom: 0;
                left: -10px;
                margin-left: 0;
                width: 0;
                border-top: 5px solid #000;
                border-top: 5px solid hsla(0, 0%, 20%, 0.9);
                border-right: 5px solid transparent;
                border-left: 5px solid transparent;
                content: " ";
                font-size: 0;
                line-height: 0;
            }

            [data-tooltip]:hover:before,
            [data-tooltip]:hover:after {
                visibility: visible;
                -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
                filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=100);
                opacity: 1;
            }
    </style>
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
                <div class="vc_col-sm-12 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row">
                            <div class="vc_col-sm-12 wpb_column vc_column_container">
                                <div class="wpb_wrapper">
                                    <div class="col-md-12 sectionTitle">
                                        <h2 class="sectionHeader">Great Plans, Different Packages And Incredible Prices :)<span class="generalBorder"></span></h2>
                                        <asp:Button runat="server" ID="btnClick" Text="Click Me" CssClass="btn btn-primary" OnClick="btnClick_Click" Visible="False" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="wpb_row row">
                            <div class="vc_col-sm-6 wpb_column vc_column_container">
                                <div class="wpb_wrapper">
                                    <div class="pricingTable">
                                        <header class="pricingHeader clearfix">
                                            <h4 class="pricingTitle">Choose the Bill Transact plan that best fits your needs:</h4>
                                            <br />
                                            <br />
                                            <h6 class="pricingTitle" style="font-size: 14px; margin: 10px;">&nbsp;</h6>
                                        </header>

                                        <ul class="pricingBody">
                                            <asp:DataList runat="server" ID="dlPackageModuleOuter" Width="100%" DataKeyField="PackageModuleID" DataSourceID="sqldsPackageModuleOuter">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("PackageModuleID") %>' runat="server" ID="PackageModuleIDLabel" Visible="False" />
                                                    <asp:Label Text='<%# Eval("PackageModuleName") %>' runat="server" ID="PackageModuleNameLabel" Style="font-weight: bold" />
                                                    <br />
                                                    <asp:DataList runat="server" ID="dlPackageFeactureInner" CssClass="upgrade-table" Width="100%" DataSourceID="sqldsPackageFeactureInner">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%# Eval("PackageFeatureID") %>' runat="server" ID="PackageFeatureIDLabel" Visible="False" />
                                                            <table style="margin: 0; padding: 0;">
                                                                <tr>
                                                                    <td style="width: 95%; margin: 0; padding: 0;">
                                                                        <asp:Label Text='<%# Eval("PackageFeatureName") %>' runat="server" ID="PackageFeatureNameLabel" />
                                                                    </td>
                                                                    <td style="width: 5%; margin: 0; padding: 0;">
                                                                        <span data-tooltip='<%# Eval("PackageFeatureDesc") %>'>
                                                                            <i class="fa fa-question-circle" style="color: #e2e2e2; float: right; font-size: 19px;"></i>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:SqlDataSource runat="server" ID="sqldsPackageFeactureInner" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT C.PackageFeatureID,C.PackageFeatureName,C.PackageFeatureDesc FROM CloudPackageDetails A LEFT JOIN PackageFeatureMaster C ON A.PackageFeatureID = C.PackageFeatureID WHERE A.PackageModuleID = @PackageModuleID">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="PackageModuleIDLabel" PropertyName="Text" DefaultValue="0" Name="PackageModuleID"></asp:ControlParameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>

                                                </ItemTemplate>
                                            </asp:DataList>
                                            <asp:SqlDataSource runat="server" ID="sqldsPackageModuleOuter" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT B.PackageModuleID,B.PackageModuleName FROM CloudPackageDetails A INNER JOIN PackageModuleMaster B ON A.PackageModuleID = B.PackageModuleID"></asp:SqlDataSource>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <asp:Repeater runat="server" ID="rpPackage" DataSourceID="sqldsPackage">
                                <ItemTemplate>
                                    <div class="vc_col-sm-2 wpb_column vc_column_container">
                                        <div class="wpb_wrapper">
                                            <div class="pricingTable">
                                                <asp:Label Text='<%# Eval("CloudPackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                                <header class="pricingHeader clearfix" style="background-color: #21242e !important; border-color: #21242e;">
                                                    <h3 class="pricingTitle">
                                                        <%# Eval("CloudPackageName") %>
                                                    </h3>
                                                    <h3 class="pricingTitle">
                                                        <%# String.Format("{0:0.00}",Eval("CloudPackagePriceMonthly")) %>&nbsp;<%# GetCurrency(Eval("CloudPackageCurrency").ToString()) %><br />
                                                        Month
                                                    </h3>

                                                </header>

                                                <ul class="pricingBody">
                                                    <asp:DataList runat="server" ID="dlPackageModule" Width="100%" DataKeyField="PackageModuleID" DataSourceID="sqldsPackageModule">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%# Eval("CloudPackageID") %>' runat="server" ID="CloudPackageIDLabel" Visible="False" />
                                                            <asp:Label Text='<%# Eval("PackageModuleID") %>' runat="server" ID="PackageModuleIDLabel" Visible="False" />
                                                            <asp:Label Text='<%# Eval("PackageModuleName") %>' runat="server" ID="PackageModuleNameLabel" Visible="False" />
                                                            <br />
                                                            <asp:DataList runat="server" ID="dlPackageFeacture" Width="100%" DataSourceID="sqldsPackageFeacture" CssClass="xyz">
                                                                <ItemTemplate>
                                                                    <asp:Label Text='<%# Eval("PackageFeatureID") %>' runat="server" ID="PackageFeatureIDLabel" Visible="False" />
                                                                    <asp:Label Text='<%# Eval("PackageFeatureName") %>' runat="server" ID="PackageFeatureNameLabel" Visible="False" />
                                                                    <span style="color: #2E9A9C;">
                                                                        <asp:Label Text='<%# SetIconValue(Eval("CloudPackageDetailValue").ToString()) %>' runat="server" ID="CloudPackageDetailValueLabel" />
                                                                    </span>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <asp:SqlDataSource runat="server" ID="sqldsPackageFeacture" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT A.CloudPackageID,C.PackageFeatureID,C.PackageFeatureName,A.CloudPackageDetailValue FROM CloudPackageDetails A LEFT JOIN PackageFeatureMaster C ON A.PackageFeatureID = C.PackageFeatureID WHERE CloudPackageID = @CloudPackageID AND A.PackageModuleID = @PackageModuleID">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="CloudPackageIDLabel" PropertyName="Text" DefaultValue="0" Name="CloudPackageID"></asp:ControlParameter>
                                                                    <asp:ControlParameter ControlID="PackageModuleIDLabel" PropertyName="Text" DefaultValue="0" Name="PackageModuleID"></asp:ControlParameter>
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>

                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:SqlDataSource runat="server" ID="sqldsPackageModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT A.CloudPackageID,B.PackageModuleID,B.PackageModuleName FROM CloudPackageDetails A INNER JOIN PackageModuleMaster B ON A.PackageModuleID = B.PackageModuleID WHERE CloudPackageID = @CloudPackageID">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="PackageIDLabel" PropertyName="Text" DefaultValue="0" Name="CloudPackageID"></asp:ControlParameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <li class="clearfix">
                                                        <p style="padding: 0; width: 100%;">
                                                            <a class="generalLink orderNow" href="CompanySignUp.aspx">
                                                                <i class="fa fa-hand-o-right"></i>&nbsp; Sign Up Now
                                                            </a>
                                                        </p>
                                                    </li>
                                                </ul>

                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:SqlDataSource runat="server" ID="sqldsPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CloudPackageID, CloudPackageName, CloudPackageCurrency, CloudPackagePriceMonthly FROM CloudPackageMaster WHERE (CloudPackageStatus = @CloudPackageStatus)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="CloudPackageStatus"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
