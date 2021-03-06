﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackagePaymentMode.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PackagePaymentMode" %>

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
        <header>

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

        <section class="plans-sec">
            <div class="container">
                <div class="col-sm-12">
                    <div class="plans-inner">
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                        <div class="skp-scroll">
                            <div class="plans-list">
                                <h1>Please select payment mode</h1>
                                <div class="col-lg-12 peel-shadows rounded-container">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <asp:RadioButtonList runat="server" ID="rdButton" AutoPostBack="true" OnSelectedIndexChanged="rdButton_CheckedChanged">
                                                    <asp:ListItem Value="0"> &nbsp;IO Payment </asp:ListItem>
                                                    <asp:ListItem Value="1"> &nbsp;Pay Pal Payment</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
