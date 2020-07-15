<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpgradePackage.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpgradePackage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="google-translate-customization" content="4981f505e60c2197-95c79325fe4110dd-gd155cbc1471967c4-1e" />
    <title>Bill Transact - Upgrade Package</title>
    <link rel="stylesheet" href="../App_Themes/Blue/css/language-selector.css?v=3.1.8.3" type="text/css" media="all" />
    <link rel='stylesheet' id='switcherstylecss' href='../App_Themes/Blue/css/switcher-style.css' type='text/css' media='all' />
    <link rel='stylesheet' id='fontawesomecss' href='../App_Themes/Blue/css/font-awesome.css' type='text/css' media='all' />
    <link rel='stylesheet' id='bootstrapcss' href='../App_Themes/Blue/css/bootstrap.min.css' type='text/css' media='all' />
    <link rel='stylesheet' id='css3animationscss' href='../App_Themes/Blue/css/css3-animations.css' type='text/css' media='all' />
    <link href="../App_Themes/Blue/css/css.css" rel="stylesheet" />
    <link href="../App_Themes/Blue/css/style.css" rel="stylesheet" />
    <link href="../App_Themes/Blue/css/bootstrap.min.css" rel="stylesheet" />
    <link rel='stylesheet' id='stylecss' href='../App_Themes/Blue/css/style.css' type='text/css' media='all' />
    <style id='style-inline-css' type='text/css'>
        </style>
    <link rel='stylesheet' id='skinscss' href='../App_Themes/Blue/css/blue.css' type='text/css' media='all' />
    <link rel='stylesheet' id='responsivecss' href='../App_Themes/Blue/css/responsive.css' type='text/css' media='all' />
    <link rel='stylesheet' id='js_composer_front_css' href='../App_Themes/Blue/css/js_composer.css' type='text/css' media='all' />
    <link rel='stylesheet' id='js_composer_custom_css_css' href='../App_Themes/Blue/css/custom.css' type='text/css' media='screen' />
    <link href="../App_Themes/Blue/css/css1.css" rel="stylesheet" />
    <script type='text/javascript' src='../App_Themes/Blue/js/jquery.js'></script>
    <script type='text/javascript' src='../App_Themes/Blue/js/jquery-migrate.min.js'></script>

    <style>
        .goog-te-gadget-simple {
            display: block;
            width: 25px;
            height: 25px;
            line-height: 25px;
            font-size: 17px;
            position: relative;
            color: #fff;
            background-color: #ffffff !important;
            background-color: rgba(255, 255, 255, 0.2) !important;
            border: 1px solid #ffffff !important;
            border: 1px solid rgba(255, 255, 255, 0.2) !important;
            border-radius: 2px 2px 2px 2px;
            overflow: hidden;
        }

        .sub-menu table > tbody > tr > td {
            padding: 0 !important;
            line-height: 0 !important;
        }

        .footer .table {
            margin-bottom: 0 !important;
        }

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

        .permission {
            color: blue;
            text-decoration: underline;
        }

            .permission:visited {
                color: blue;
                text-decoration: underline;
            }

            .permission:hover {
                color: white;
                background-color: blue;
                text-decoration: none;
            }

        .ajax__tab_xp .ajax__tab_body {
            padding: 0 0 0 0;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            height: 40px;
            padding: 4px;
            margin: 0;
            font-size: 13px;
            font-family: Verdana;
        }

        .ajax__tab_header {
            height: 40px;
        }

        .ajax__tab_tab {
            height: 40px;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-size: 12px;
            height: 30px;
        }

        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-color: black;
            border-style: solid;
            border-width: 3px;
            height: 370px;
            padding-left: 10px;
            padding-top: 10px;
            width: 575px;
        }
    </style>
    <script type="text/javascript">
        function googleTranslateElementInit() {
            new google.translate.TranslateElement({ pageLanguage: 'en', includedLanguages: 'en,fr', layout: google.translate.TranslateElement.InlineLayout.SIMPLE, multilanguagePage: true }, 'google_translate_element');
        }
    </script>
    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
</head>
<%-- ReSharper disable UnknownCssClass --%>
<body id="top" class="home page page-id-14 page-template page-template-templates page-template-homepage page-template-templateshomepage-php style-1  wpb-js-composer js-comp-ver-4.3.5 vc_responsive" data-image="">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
        <div class="allWrapper">
            <section class="slider section mainSection scrollAnchor darkSection" style="height: 40px" data-cover="rgba(33, 36, 46, 0.85)">
                <div class="topMenu navBar">
                    <div class="container">
                        <div class="row">
                            <ul class="topSocial socialNav col-md-6 col-sm-12">
                                <li class="facebook">
                                    <a href="#">
                                        <i class="fa fa-facebook animated"></i>
                                    </a>
                                </li>
                                <li class="twitter">
                                    <a href="#">
                                        <i class="fa fa-twitter animated"></i>
                                    </a>
                                </li>
                                <li class="googleplus">
                                    <a href="#">
                                        <i class="fa fa-google-plus animated"></i>
                                    </a>
                                </li>
                                <li>&nbsp;</li>
                                <li>
                                    <div id="google_translate_element" class="clearfix"></div>
                                </li>
                            </ul>
                            <div class="topContact col-md-6 col-sm-12">
                                <ul>
                                    <asp:Label runat="server" ID="lblContact"></asp:Label>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <div id="s" runat="server">
            </div>
            <header class="header headerStyle1 sticky" id="header">
                <div class="scrollHeaderWrapper">
                    <div class="container">
                        <div class="row">
                            <div class="logoWrapper" style="padding-left: 4%;">
                                <h1 class="logo" style="margin-top: 0">
                                    <%--<a class="clearfix" href="../Default.aspx" title="DoyinGo">--%>
                                    <img alt="testmonials user" class="testmonialthumb" src="../App_Themes/Blue/images/logo.jpg" style="height: 90px; width: 100%;" />
                                    <%--</a>--%>
                                </h1>

                            </div>
                            <nav class="mainMenu mainNav" id="mainNav">
                                <asp:Label runat="server" ID="lblBack">
                                    <a href="DefaultDoyingo.aspx" class="permission">
                                        <i class="fa fa-arrow-left"></i>&nbsp;
                                        My Bill Transact Account
                                    </a>
                                </asp:Label>
                                <%--<ul id="menu-main-menu" class="navTabs">
                                    <li id="home" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page page_item page-item-14 current_page_item current-menu-parent current_page_parent current_page_ancestor menu-item-has-children menu-item-1019"><a href="../Default.aspx">Home</a></li>
                                    <li id="aboutus" runat="server" class="">
                                        <a href="../AboutUs.aspx">About</a>
                                        <ul class="sub-menu dropDown">
                                            <asp:DataList runat="server" ID="dlAboutCategory" Width="100%" RepeatColumns="1" DataKeyField="AboutCategoryID"
                                                DataSourceID="sqldsAboutCategory" Style="margin-bottom: 0">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("AboutCategoryID") %>' runat="server" ID="AboutCategoryIDLabel" Visible="False" />
                                                    <li id='<%# Eval("AboutCategoryName") %>'>
                                                        <a href='<%# "AboutUs.aspx?aId=" + Eval("AboutCategoryID") %>'>
                                                            <asp:Label Text='<%# Eval("AboutCategoryName") %>' runat="server" ID="AboutCategoryNameLabel" />
                                                        </a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <asp:SqlDataSource runat="server" ID="sqldsAboutCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [AboutCategoryID], [AboutCategoryName] FROM [AboutCategoryMaster] WHERE ([AboutCategoryStatus] = @AboutCategoryStatus)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="True" Name="AboutCategoryStatus" Type="Boolean"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </ul>
                                    </li>
                                    <li id="features" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-1032"><a href="../Features.aspx">Features</a></li>
                                    <li id="pricing" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-1032">
                                        <a href="../NewPricingTable.aspx">Packages</a>
                                        <asp:SqlDataSource runat="server" ID="sqldsPackages" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [PackageID], [PackageName] FROM [PackageMaster] WHERE ([Status] = @Status)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </li>
                                    <li id="FAQs" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-1032"><a href="../FAQs.aspx">FAQs</a></li>
                                    <li id="Testimonial" runat="server" class=""><a href="../Testimonial.aspx">Testimonial</a></li>
                                    <li id="contactUs" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-1032"><a href="../ContactUs.aspx">Contacts</a></li>
                                    <li id="support" runat="server"><a href="#">Support</a></li>
                                    <li id="login" runat="server" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-1032"><a href="../MemberArea.aspx">Login</a></li>
                                    <li><a class="register_button" href="../CompanySignUp.aspx">Try it Free</a></li>
                                    <li>

                                        <br />
                                    </li>
                                    <li>
                                        <div class="clearfix"></div>
                                    </li>
                                </ul>--%>
                            </nav>
                            <a href="#" class="generalLink" id="responsiveMainNavToggler"><i class="fa fa-bars"></i></a>
                            <div class="clearfix"></div>
                            <div class="responsiveMainNav"></div>
                        </div>
                    </div>
                </div>
            </header>

            <div class="pageInfo" style="background-image: url(../App_Themes/Blue/images/page-info-bg.png);">
                <div class="cover"></div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                            <h2 class="pageTitle">Upgrade Your Package</h2>
                        </div>
                        <div class="col-md-6">
                            &nbsp;
                    <%--<ul class="breadcrumb">
                        <li><a href="../Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Pricing Tables</li>
                    </ul>--%>
                        </div>
                    </div>
                </div>
            </div>

            <section id="Section1" class="section mainSection graySection  pricing">
                <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
                    <div class="container">
                        <div class="vc_col-sm-12 wpb_column vc_column_container">
                            <div class="wpb_wrapper">
                                <div class="wpb_row row">
                                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                                        <div class="wpb_wrapper">
                                            <div class="col-md-12 sectionTitle">
                                                <h2 class="sectionHeader">Great Plans, Different Packages And Incredible Prices :)<span class="generalBorder"></span></h2>
                                                <asp:Label runat="server" ID="lblError"></asp:Label>
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

                                    <asp:Repeater runat="server" ID="rpPackage" DataSourceID="sqldsPackage" OnItemCommand="rpPackage_OnItemCommand">
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
                                                                    <asp:Label runat="server" ID="lblopen"></asp:Label>
                                                                    <asp:Button runat="server" ID="btnClick" Text="Start Risk Free" CommandName="openPopup" CssClass="generalLink orderNow" CommandArgument='<%# Eval("CloudPackageID") %>' ToolTip='<%# Eval("CloudPackageName") %>' />
                                                                </p>
                                                            </li>
                                                        </ul>
                                                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpPackage" PopupControlID="pnlPackage" CancelControlID="lnkbtnClose" TargetControlID="lblopen" BackgroundCssClass="Background">
                                                        </ajaxToolkit:ModalPopupExtender>
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


            <footer class="footer" id="footer">
                <div class="bottomFooter">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-6 copyrights">
                                <asp:DataList runat="server" ID="dlFooter" Width="100%" RepeatColumns="1" DataKeyField="FooterContentID" DataSourceID="sqldsFooter">
                                    <ItemTemplate>
                                        <p>
                                            <asp:Label Text='<%# Eval("FooterContent") %>' runat="server" ID="FooterContentLabel" />
                                        </p>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:SqlDataSource runat="server" ID="sqldsFooter" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [FooterContent]"></asp:SqlDataSource>
                            </div>
                            <div class="col-md-6 footerSocial">
                                <div class="footerSocialWrapper" style="padding-top: 15px; margin-right: 15px;">
                                    <ul class="bottomSocial socialNav">
                                        <li class="facebook">
                                            <a href="https://www.facebook.com/" target="_blank">
                                                <i class="fa fa-facebook animated"></i>
                                            </a>
                                        </li>
                                        <li class="twitter">
                                            <a href="https://twitter.com/" target="_blank">
                                                <i class="fa fa-twitter animated"></i>
                                            </a>
                                        </li>
                                        <li class="googleplus">
                                            <a href="https://plus.google.com/" target="_blank">
                                                <i class="fa fa-google-plus animated"></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
            <!-- SWITCHER -->
            <script type='text/javascript' src='../App_Themes/Blue/js/switcher.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/comment-reply.min.js'></script>
            <script type='text/javascript' src='//maps.google.com/maps/api/js?sensor=false&#038;ver=4.1.1'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/owl-carousel.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/smooth-scroll.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/modernizr.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/retina.min.js'></script>
            <%--<script type='text/javascript' src='App_Themes/Blue/js/way-point.min.js'></script>--%>
            <script type='text/javascript' src='../App_Themes/Blue/js/fancy-select.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/ms-drop-down.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/ticker.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/rrssb-share-btn.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/mix-it-up.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/easy-tabs.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/flip-clock.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/nice-scroll.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/touch-effect.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/jquery.easing.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/html5shiv-printshiv.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/respond.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/isotope.pkgd.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/imagesloaded.pkgd.min.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/scripts.js'></script>
            <script type='text/javascript' src='../App_Themes/Blue/js/bootstrap.js'></script>
            <%--<script type='text/javascript' src='App_Themes/Blue/js/sitepress.js'></script>--%>
            <script type='text/javascript' src='../App_Themes/Blue/js/js_composer_front.js'></script>
        </div>

        <script type="text/javascript">
            function showHideDiv(option) {
                var mobDiv = document.getElementById("mobileTraz");
                var payDiv = document.getElementById("paypal");
                if (option == "mobile") {
                    mobDiv.style.display = "block";
                    payDiv.style.display = "none";
                }
                else if (option == "paypal") {
                    mobDiv.style.display = "none";
                    payDiv.style.display = "block";
                }
            }
        </script>

        <asp:Panel ID="pnlPackage" runat="server" Height="625px" Width="535px" align="center" Style="display: none; background-color: white; padding: 22px 30px 25px; border: 5px solid lightgrey; border-radius: 15px;">
            <table style="width: 100%; height: 100px;">
                <tr style="background: #0D83DC; border: none;">
                    <td style="color: White; font-weight: bold; font-size: 25px; text-align: center; width: 60%; font-family: FranklinMedium,Arial,sans-serif; padding: 0 10px;">Make Payment
                    </td>
                </tr>
            </table>
            <div class="panel-body" style="border-color: #e9edf2; padding-bottom: 0;">
                <div class="col-lg-12">
                    <div class="form-horizontal" id="paymentOption">
                        <div class="form-group">
                            <div class="col-lg-12 control-label" style="text-align: left; padding-left: 0; padding-right: 0; color: black; font-size: 14px;">
                                <asp:RadioButton runat="server" ID="rbMobile" CssClass="text" GroupName="payment" Text="Pay by Mobiletranzact" Checked="True" onchange="showHideDiv('mobile')" />
                                <asp:RadioButton runat="server" ID="rbPaypal" CssClass="text" GroupName="payment" Text="Pay by Paypal" onchange="showHideDiv('paypal')" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal" id="paypal" style="display: none;">
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 0; color: black; font-size: 14px;">
                                Package Detail
                            </div>
                            <div class="col-lg-9" style="text-align: left; padding-top: 7px;">
                                <asp:Label runat="server" ID="lblPackageName1"></asp:Label>
                                <br />
                                <asp:RadioButton runat="server" CssClass="form-group text" Style="width: 30%; display: inline-block;" Checked="True" ID="rblMonth1" GroupName="Period1" Text="Monthly" />
                                (<asp:Label runat="server" ID="lblPriceMonth1" Text="0.00"></asp:Label>&nbsp;per Month)
                                <br />
                                <asp:RadioButton runat="server" CssClass="form-group text" Style="width: 30%; display: inline-block;" ID="rblYear1" GroupName="Period1" Text="Yearly" />
                                (<asp:Label runat="server" ID="lblPriceYear1" Text="0.00"></asp:Label>&nbsp;per Year)
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:ImageButton ID="btnPay" runat="server" AlternateText="Pay" ImageUrl="https://www.paypalobjects.com/en_GB/i/btn/btn_paynow_SM.gif" OnClick="btnPay_Click" />
                        </div>
                    </div>
                    <div class="form-horizontal" id="mobileTraz" style="display: block">
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 0; color: black; font-size: 14px;">
                                Package Detail
                            </div>
                            <div class="col-lg-9" style="text-align: left; padding-top: 7px;">
                                <asp:HiddenField runat="server" ID="hfPackageID" />
                                <asp:Label runat="server" ID="lblPackageName"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 15px; color: black; font-size: 14px;">
                                Card No.*:
                            </div>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtCardNo" CssClass="form-group text" MaxLength="14" Text="" Style="width: 100%;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtCardNo" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 15px; color: black; font-size: 14px;">
                                Merchant Order No.*:
                            </div>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtOrderNo" CssClass="form-group text" Text="" MaxLength="14" Style="width: 100%;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvOrderNo" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtOrderNo" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 15px; color: black; font-size: 14px;">
                                Pin No*:
                            </div>
                            <div class="col-lg-9">
                                <asp:TextBox runat="server" ID="txtPinNo" CssClass="form-group text" Text="" TextMode="Password" MaxLength="4" Style="width: 100%;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPinNo" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtPinNo" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 0; color: black; font-size: 14px;">
                                Subscription<br />
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:RadioButton runat="server" CssClass="form-group text" Checked="True" Style="width: 30%; display: inline-block;" ID="rblMonth" GroupName="Period" Text="Monthly" />
                                (<asp:Label runat="server" ID="lblPriceMonth" Text="0.00"></asp:Label>&nbsp;per Month)
                                <br />
                                <asp:RadioButton runat="server" CssClass="form-group text" Style="width: 30%; display: inline-block;" ID="rblYear" GroupName="Period" Text="Yearly" />
                                (<asp:Label runat="server" ID="lblPriceYear" Text="0.00"></asp:Label>&nbsp;per Year)
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="text-align: left; padding-left: 0; padding-right: 15px; color: black; font-size: 14px;"></div>
                            <div class="col-lg-9"></div>
                        </div>
                        <div class="form-group">
                            <div style="color: #e9edf2; text-align: center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Make Payment" TabIndex="7" CssClass="btn-primary"
                                    ValidationGroup="UserDataMaster" OnClick="btnSubmit_OnClick" Style="padding: 10px; font-size: 20px; font-family: Verdana;" />
                                <asp:LinkButton runat="server" ID="lnkbtnClose" CssClass="permission" Text="cancel"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="border-color: #e9edf2; padding-top: 0;">
                <div class="row">
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField runat="server" ID="hfCompanyID"/>
    </form>
    <%-- ReSharper restore UnknownCssClass --%>
</body>
</html>
