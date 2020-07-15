<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpgradePackage.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpgradePackage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="google-translate-customization" content="4981f505e60c2197-95c79325fe4110dd-gd155cbc1471967c4-1e" />
    <link rel="icon" href="../App_Themes/sky/uploads/favIcon_billtransct.ico" />
    <title>Bill Transact</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900" rel="stylesheet" />
    <link rel="stylesheet" href="../App_Themes/sky/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../App_Themes/sky/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../App_Themes/sky/css/style.css" />
    <link rel="stylesheet" href="../App_Themes/sky/css/slick.css" />
    <link rel="stylesheet" href="../App_Themes/sky/css/responsive.css" />
    <link href="../App_Themes/sky/css/mycustom.css" rel="stylesheet" />
    <link href="../App_Themes/Blue/css/slick.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../App_Themes/sky/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
        <header>
            <div class="top-header hidden-xs">
                <div class="container">
                    <div class="short-links">
                        <ul class="clearfix">
                            <asp:Label runat="server" ID="lblContact"></asp:Label>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- Static navbar -->
            <nav class="navbar navbar-default navbar-static-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx">
                            <asp:Image ID="img1" alt="logo" src="../App_Themes/sky/uploads/logo.png" runat="server" /></a>
                        <a href="tel:18002345678" class="mob-phone hidden-lg hidden-md hidden-sm"><i class="fa fa-phone" aria-hidden="true"></i></a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav pull-right" id="menu-main-menu">
                            <li>
                                <asp:Label runat="server" ID="lblBack">
                                    <a href="DefaultDoyingo.aspx" class="permission">
                                        <i class="fa fa-arrow-left"></i>&nbsp;
                                        My Bill Transact Account
                                    </a>
                                </asp:Label>
                            </li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </nav>
        </header>
        <%-- ReSharper disable UnknownCssClass --%>
        <!-- about-banner -->
        <section class="about-banner features-bg">
            <div class="container">
                <div class="banner-text">
                    <h1>Our Pricing</h1>
                </div>
            </div>
        </section>
        <!-- /about-banner -->

        <section class="plans-sec">
            <div class="container">
                <div class="col-sm-12">
                    <div class="plans-inner">
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                        <div class="skp-scroll">
                            <div class="plans-list">
                                <h1>Bill Transact plan that best fits your needs:</h1>
                                <asp:SqlDataSource runat="server" ID="sqldsPackageModuleOuter" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT B.PackageModuleID,B.PackageModuleName FROM CloudPackageDetails A INNER JOIN PackageModuleMaster B ON A.PackageModuleID = B.PackageModuleID"></asp:SqlDataSource>
                                <asp:DataList runat="server" ID="DataList1" Width="100%" DataKeyField="PackageModuleID" DataSourceID="sqldsPackageModuleOuter">
                                    <ItemTemplate>
                                        <ul>
                                            <asp:Label Text='<%# Eval("PackageModuleID") %>' runat="server" ID="PackageModuleIDLabel" Visible="False" />

                                            <li>
                                                <h5><%# Eval("PackageModuleName") %></h5>
                                            </li>

                                            <asp:DataList runat="server" ID="dlPackageFeactureInner" Width="100%" DataSourceID="sqldsPackageFeactureInner">
                                                <ItemTemplate>

                                                    <asp:Label Text='<%# Eval("PackageFeatureID") %>' runat="server" ID="PackageFeatureIDLabel" Visible="False" />


                                                    <li>
                                                        <%# Eval("PackageFeatureName") %>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <asp:SqlDataSource runat="server" ID="sqldsPackageFeactureInner" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT C.PackageFeatureID,C.PackageFeatureName,C.PackageFeatureDesc FROM CloudPackageDetails A LEFT JOIN PackageFeatureMaster C ON A.PackageFeatureID = C.PackageFeatureID WHERE A.PackageModuleID = @PackageModuleID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="PackageModuleIDLabel" PropertyName="Text" DefaultValue="0" Name="PackageModuleID"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </ul>
                                    </ItemTemplate>

                                </asp:DataList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT B.PackageModuleID,B.PackageModuleName FROM CloudPackageDetails A INNER JOIN PackageModuleMaster B ON A.PackageModuleID = B.PackageModuleID"></asp:SqlDataSource>
                            </div>

                            <asp:Repeater runat="server" ID="Repeater1" DataSourceID="sqldsPackage" OnItemCommand="rpPackage_OnItemCommand">
                                <ItemTemplate>
                                    <div class="plans-rates">


                                        <asp:Label Text='<%# Eval("CloudPackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                        <%-- <header class="pricingHeader clearfix" style="background-color: #21242e !important; border-color: #21242e;">--%>
                                        <h6 class="<%# (Container.ItemIndex==0? "l-blue" : (Container.ItemIndex==1 ? "l-green" :"l-black"))%>">
                                            <%# Eval("CloudPackageName") %>
                                        </h6>
                                        <div class="skp-rate <%# (Container.ItemIndex==0? "d-blue" : (Container.ItemIndex==1 ? "d-green" :"d-black"))%>">
                                            <h1><%# GetCurrency(Eval("CloudPackageCurrency").ToString()) %>
                                                <%# String.Format("{0:0.00}",Eval("CloudPackagePriceMonthly")) %></h1>
                                            <p>/Per Month</p>
                                        </div>


                                        <asp:DataList runat="server" ID="dlPackageModule" Width="100%" DataKeyField="PackageModuleID" DataSourceID="sqldsPackageModule">
                                            <ItemTemplate>
                                                <ul style="padding-top: 47px;">
                                                    <asp:Label Text='<%# Eval("CloudPackageID") %>' runat="server" ID="CloudPackageIDLabel" Visible="False" />
                                                    <asp:Label Text='<%# Eval("PackageModuleID") %>' runat="server" ID="PackageModuleIDLabel" Visible="False" />
                                                    <asp:Label Text='<%# Eval("PackageModuleName") %>' runat="server" ID="PackageModuleNameLabel" Visible="False" />
                                                    <asp:DataList runat="server" ID="dlPackageFeacture" Width="100%" DataSourceID="sqldsPackageFeacture" CssClass="xyz">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%# Eval("PackageFeatureID") %>' runat="server" ID="PackageFeatureIDLabel" Visible="False" />
                                                            <asp:Label Text='<%# Eval("PackageFeatureName") %>' runat="server" ID="PackageFeatureNameLabel" Visible="False" />
                                                            <li>
                                                                <%# SetIconValue(Eval("CloudPackageDetailValue").ToString()) %>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:SqlDataSource runat="server" ID="sqldsPackageFeacture" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT A.CloudPackageID,C.PackageFeatureID,C.PackageFeatureName,A.CloudPackageDetailValue FROM CloudPackageDetails A LEFT JOIN PackageFeatureMaster C ON A.PackageFeatureID = C.PackageFeatureID WHERE CloudPackageID = @CloudPackageID AND A.PackageModuleID = @PackageModuleID">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="CloudPackageIDLabel" PropertyName="Text" DefaultValue="0" Name="CloudPackageID"></asp:ControlParameter>
                                                            <asp:ControlParameter ControlID="PackageModuleIDLabel" PropertyName="Text" DefaultValue="0" Name="PackageModuleID"></asp:ControlParameter>
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </ul>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:SqlDataSource runat="server" ID="sqldsPackageModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT A.CloudPackageID,B.PackageModuleID,B.PackageModuleName FROM CloudPackageDetails A INNER JOIN PackageModuleMaster B ON A.PackageModuleID = B.PackageModuleID WHERE CloudPackageID = @CloudPackageID">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="PackageIDLabel" PropertyName="Text" DefaultValue="0" Name="CloudPackageID"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <div class="skp-btns">

                                            <%--<asp:Label runat="server" ID="lblopen"></asp:Label>--%>
                                            <%--<asp:Button runat="server" ID="btnClick" Text="Sign Up" CommandName="openPopup"  CommandArgument='<%# Eval("CloudPackageID") %>' ToolTip='<%# Eval("CloudPackageName") %>' />--%>
                                            <%--<asp:LinkButton runat="server" ID="btnClick" Text="Sign Up" CssClass='<%# (Container.ItemIndex==0? "d-blue" : (Container.ItemIndex==1 ? "d-green" :"d-black"))%>' CommandName="openPopup" CommandArgument='<%# Eval("CloudPackageID") %>' ToolTip='<%# Eval("CloudPackageName") %>' />--%>
                                            <a href='<%# String.Format("PackagePaymentMode.aspx?id={0}&type={1}", Eval("CloudPackageID"),"M") %>'
                                                class='<%# (Container.ItemIndex==0? "d-blue" : (Container.ItemIndex==1 ? "d-green" :"d-black"))%>' title='<%# Eval("CloudPackageName") %>'>Sign Up</a>
                                        </div>


                                        <%-- <ajaxToolkit:ModalPopupExtender runat="server" ID="mpPackage" PopupControlID="pnlPackage" CancelControlID="lnkbtnClose" TargetControlID="lblopen" BackgroundCssClass="Background">
                                        </ajaxToolkit:ModalPopupExtender>--%>
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
        </section>



        <section class="get-started-sec">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 padd-0">
                        <span class="people">
                            <img src="../App_Themes/sky/uploads/footer-banner.png" alt="" />

                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 GetStarted">
                        <h2>Get started for free today </h2>
                        <br />
                        <a href="CompanySignUp.aspx" class="cta-btn">Free absolutely nothing to pay</a>
                        <p class="hidden">Email : <a href="mailto:sales@billtransact.com">sales@billtransact.com</a></p>
                    </div>
                    <div class="col-md-6 GetStartedUsers">
                        <span>
                            <img src="../App_Themes/sky/i/cloud.png" alt="cloud-icon" />
                        </span>
                        <div class="user-number">
                            <h2>4000+</h2>
                            <h6>users already used our software</h6>
                        </div>
                    </div>
                </div>

            </div>
        </section>

        <footer class="padd-60">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-12">
                        <div class="ft-logo">
                            <a href="Default.aspx">
                                <asp:Image ID="img2" alt="logo" src="../App_Themes/sky/uploads/logo.png" runat="server" /></a>
                        </div>
                    </div>
                    <div class="col-lg-9 col-md-12">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="ft-links pad5">
                                    <h5>COMPANY</h5>
                                    <ul>
                                        <li><a href="AboutUs.aspx">About Us</a></li>
                                        <li><a href="AboutUs.aspx">Our Story</a></li>
                                        <li><a href="AboutUs.aspx">We're Hiring</a></li>
                                        <li><a href="AboutUs.aspx">Press Center</a></li>
                                        <li><a href="AboutUs.aspx">Contact</a></li>
                                        <li><a href="AboutUs.aspx">Blog</a></li>
                                        <li><a href="AboutUs.aspx">Our Story</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="ft-links pad5">
                                    <h5>PRODUCTS</h5>
                                    <ul>
                                        <li><a href="Features.aspx">Invoice Software</a></li>
                                        <li><a href="Features.aspx">Expenses and Receipts</a></li>
                                        <li><a href="Features.aspx">Time Tracking</a></li>
                                        <li><a href="Features.aspx">Managing Projects</a></li>
                                        <li><a href="Features.aspx">Estimating Software</a></li>
                                        <li><a href="Features.aspx">Online Payments</a></li>
                                        <li><a href="Features.aspx">AI FreshBooks Features</a></li>
                                        <li><a href="Features.aspx">Financial Reports</a></li>
                                        <li><a href="Features.aspx">Mobile Apps</a></li>
                                        <li><a href="Features.aspx">Pricing</a></li>
                                        <li><a href="Features.aspx">High Volume Billing</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="ft-links pad5">
                                    <h5>GENERAL</h5>
                                    <ul>
                                        <li><a href="AboutUs.aspx">My Account</a></li>
                                        <li><a href="MemberArea.aspx">Login</a></li>
                                        <li><a href="CompanySignUp.aspx">Sign Up</a></li>
                                        <li><a href="AboutUs.aspx">Help Center</a></li>
                                        <li><a href="AboutUs.aspx">Contact</a></li>
                                        <li><a href="AboutUs.aspx">Blog</a></li>
                                        <li><a href="PrivacyPolicy.aspx?qs=pr">Privacy Policy</a></li>
                                        <li><a href="PrivacyPolicy.aspx?qs=trs">Terms of use</a></li>
                                        <li><a href="AboutUs.aspx">Others</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="ft-links pad5">
                                    <h5>PARTNERS</h5>
                                    <ul>
                                        <li><a href="AboutUs.aspx">My Account</a></li>
                                        <li><a href="MemberArea.aspx">Login</a></li>
                                        <li><a href="CompanySignUp.aspx">Sign Up</a></li>
                                        <li><a href="AboutUs.aspx">Help Center</a></li>
                                        <li><a href="AboutUs.aspx">Contact</a></li>
                                        <li><a href="AboutUs.aspx">Blog</a></li>
                                        <li><a href="PrivacyPolicy.aspx?qs=pr">Privacy Policy</a></li>
                                        <li><a href="PrivacyPolicy.aspx?qs=trs">Terms of use</a></li>
                                        <li><a href="AboutUs.aspx">Others</a></li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="container" id="copyrights">
                <div class="row">
                    <div class="col-sm-8">
                        <asp:DataList runat="server" ID="dlFooter" Width="100%" RepeatColumns="1" DataKeyField="FooterContentID" DataSourceID="sqldsFooter">
                            <ItemTemplate>
                                <p>
                                    <asp:Label Text='<%# Eval("FooterContent") %>' runat="server" ID="FooterContentLabel" />
                                </p>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource runat="server" ID="sqldsFooter" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [FooterContent]"></asp:SqlDataSource>
                    </div>
                    <div class="col-sm-4">
                        <ul class="ft-social clearfix pull-right">
                            <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                            <li><a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                            <li><a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
                            <li><a href="#"><i class="fa fa-youtube-play" aria-hidden="true"></i></a></li>
                            <li><a href="#"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>

        <asp:Panel ID="pnlPackage" runat="server" Height="30%" Width="25%" align="center" Style="display: none; background-color: white; padding: 22px 30px 25px; border: 5px solid lightgrey; border-radius: 15px;">
            <%--<table style="width: 100%; height: 100px;">
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
            </div>--%>
            <div class="panel-body" style="border-color: #e9edf2; padding-top: 0;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-horizontal" id="paymentOption">
                            <div class="form-group">
                                <div class="col-lg-12 control-label" style="text-align: left; padding-left: 0; padding-right: 0; color: black; font-size: 14px;">
                                    The service is free for 185 days thanks
                                </div>
                            </div>
                            <div class="form-group">
                                <div style="color: #e9edf2; text-align: center">
                                    <asp:LinkButton runat="server" ID="lnkbtnClose" CssClass="permission" Text="cancel"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--./col-lg-12--%>
                </div>
                <%--./row--%>
            </div>
            <%--./panel-body--%>
        </asp:Panel>
        <asp:HiddenField runat="server" ID="hfCompanyID" />
        <script src="../App_Themes/sky/js/slick.js"></script>
        <script>
            $(window).scroll(function () {
                if ($(this).scrollTop() > 1) {
                    $('header').addClass("sticky");
                }
                else {
                    $('header').removeClass("sticky");
                }
            });
        </script>
        <script>
            $(".regular").slick({
                dots: true,
                infinite: true,
                slidesToShow: 4,
                autoplay: 9000,
                speed: 1200,
                prevArrow: $(".pp2"),
                nextArrow: $(".nn2"),
                slidesToScroll: 4,

                // the magic
                responsive: [{

                    breakpoint: 992,
                    settings: {
                        slidesToShow: 3,
                        infinite: true,
                        slidesToScroll: 1,
                    }

                }, {

                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                    }

                }, {

                    breakpoint: 481,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                    }


                }]
            });




        </script>

    </form>
</body>
</html>
