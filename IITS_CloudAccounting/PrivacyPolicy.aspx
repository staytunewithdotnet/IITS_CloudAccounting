<%@ Page Title="Bill Transact - Privacy Policy" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="PrivacyPolicy.aspx.cs" Inherits="IITS_CloudAccounting.PrivacyPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- about-banner -->
    <section class="about-banner features-bg">
        <div class="container">
            <div class="banner-text">
                <h1 id="banner">Privacy Policy</h1>
            </div>
        </div>
    </section>
    <!-- /about-banner -->

    <div class="project-ul-list">
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-4 menu-list-project">
                    <ul class="nav nav-tabs">
                        <li class="active" id="terms"><a data-toggle="tab" href="#menu0" onclick="changeHeading();">Terms of Service</a></li>
                        <li id="privacy"><a data-toggle="tab" href="#menu2" onclick="changeHeading();">Privacy Policy</a></li>
                    </ul>
                </div>
                <div class="col-md-8 col-sm-8 menu-content-project pull-right">
                    <div id="menu0" class="tab-pane fade active">
                        <h3>Terms of Service</h3>
                        <h6>Last Updated: September 29th, 2017</h6>
                        <%--<p>2NDSITE Inc. (“FreshBooks”, “we”, “us” and terms of similar meaning) provides this web site [www.FreshBooks.com] and the services provided by or through this web site to you subject to these terms and conditions of use. These terms and conditions of use together with the FreshBooks Privacy Policy (collectively, the “Terms”) govern your use of this web site and the services provided.</p>

                        <p>In these Terms, we call this web site, any successor web sites (together, the “Site”) and the software we provide the “Application”. The Application includes your use of the FreshBooks API, and the use of the FreshBooks API by third parties authorized through your FreshBooks account to use your User Content (as defined below) through the FreshBooks API.</p>--%>
                        <asp:Label runat="server" ID="lblTermsOfService"></asp:Label>

                    </div>
                    <%--<div id="menu1" class="tab-pane fade">
                        <h3>Connected Bank Account</h3>
                        <p>We refer to the services provided by or through the Application as the “Services”, and for users of the FreshBooks Card Reader, “Services” includes the services provided by or through the Card Reader. Users of the FreshBooks Card Reader also agree to and are bound by our FreshBooks Card Reader and Card Transactions Terms of Use, which are available here.</p>

                        <p>Please read these Terms carefully before using the Services. By accessing or using the Services you acknowledge that you have read and understood these Terms and agree to be legally bound by these Terms and all policies and guidelines incorporated by reference in these Terms. If you do not agree to be bound by these Terms in their entirety, you may not use the Services.</p>

                        <p>FreshBooks reserves the right, in its sole discretion, to change, modify or otherwise alter these Terms, or any policy or guideline applicable to the Services, at any time. If we do so, we will make reasonable efforts to communicate these changes to you via email at the email address you provide in your registration information, if any, or we will post a notice in the Application.</p>

                        <p>Unless otherwise specified, any changes or modifications will be effective immediately upon posting of the revised Terms on this Site, and your continued use of the Services after such time will constitute your agreement to be bound by such modified Terms. You should from time to time review the Terms and any policies and documents incorporated in them to understand the terms and conditions that apply to your use of the Services. The Terms will always show the 'last updated' date at the top.</p>

                        <p>If you do not agree to the modified Terms, you must stop using the Services. You can cancel your account with us without further obligation, except for the amount due for the balance of the billing period in which you cancel your account (if your billing period is monthly, we will prorate your account to the nearest month-end after cancellation). If you have any questions about the Terms, please email us at support@FreshBooks.com.</p>

                        <p>
                            Unless otherwise specified, any changes or modifications will be effective immediately upon posting of the revised Terms on this Site, and your continued use of the Services after such time will constitute your agreement to be bound by such modified Terms. You should from time to time review the Terms and any policies and documents incorporated in them to understand the terms and conditions that apply to your use of the Services. The Terms will always show the 'last updated' date at the top.
                        </p>

                    </div>--%>
                    <div id="menu2" class="tab-pane fade">
                        <h3>Privacy Policy</h3>
                        <%--<p>We refer to the services provided by or through the Application as the “Services”, and for users of the FreshBooks Card Reader, “Services” includes the services provided by or through the Card Reader. Users of the FreshBooks Card Reader also agree to and are bound by our FreshBooks Card Reader and Card Transactions Terms of Use, which are available here.</p>

                        <p>Please read these Terms carefully before using the Services. By accessing or using the Services you acknowledge that you have read and understood these Terms and agree to be legally bound by these Terms and all policies and guidelines incorporated by reference in these Terms. If you do not agree to be bound by these Terms in their entirety, you may not use the Services.</p>

                        <p>FreshBooks reserves the right, in its sole discretion, to change, modify or otherwise alter these Terms, or any policy or guideline applicable to the Services, at any time. If we do so, we will make reasonable efforts to communicate these changes to you via email at the email address you provide in your registration information, if any, or we will post a notice in the Application.</p>


                        <p>Unless otherwise specified, any changes or modifications will be effective immediately upon posting of the revised Terms on this Site, and your continued use of the Services after such time will constitute your agreement to be bound by such modified Terms. You should from time to time review the Terms and any policies and documents incorporated in them to understand the terms and conditions that apply to your use of the Services. The Terms will always show the 'last updated' date at the top.</p>                        --%>
                        <asp:Label runat="server" ID="lblPrivacy"></asp:Label>
                    </div>

                    <%--<div id="menu3" class="tab-pane fade">
                        <h3>Privacy Policy</h3>
                        <p>We refer to the services provided by or through the Application as the “Services”, and for users of the FreshBooks Card Reader, “Services” includes the services provided by or through the Card Reader. Users of the FreshBooks Card Reader also agree to and are bound by our FreshBooks Card Reader and Card Transactions Terms of Use, which are available here.</p>

                        <p>Please read these Terms carefully before using the Services. By accessing or using the Services you acknowledge that you have read and understood these Terms and agree to be legally bound by these Terms and all policies and guidelines incorporated by reference in these Terms. If you do not agree to be bound by these Terms in their entirety, you may not use the Services.</p>

                        <p>FreshBooks reserves the right, in its sole discretion, to change, modify or otherwise alter these Terms, or any policy or guideline applicable to the Services, at any time. If we do so, we will make reasonable efforts to communicate these changes to you via email at the email address you provide in your registration information, if any, or we will post a notice in the Application.</p>


                        <p>Unless otherwise specified, any changes or modifications will be effective immediately upon posting of the revised Terms on this Site, and your continued use of the Services after such time will constitute your agreement to be bound by such modified Terms. You should from time to time review the Terms and any policies and documents incorporated in them to understand the terms and conditions that apply to your use of the Services. The Terms will always show the 'last updated' date at the top.</p>
                        
                    </div>--%>
                </div>
            </div>
        </div>
    </div>

    <section id="intro" class="section mainSection scrollAnchor lightSection  intro">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div class="vc_col-sm-12 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row vc_row-fluid">
                            <div class="vc_col-sm-12 wpb_column vc_column_container">
                                <div class="wpb_wrapper">
                                    <div class="col-md-12 sectionTitle">
                                        <h2 class="sectionHeader">Privacy Policy Of Bill Transact<span class="generalBorder"></span></h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sectionWrapper" style="padding-top: 0;">
            <div class="container">
                <div class="vc_col-sm-12 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row vc_row-fluid">
                            <%--<asp:Label runat="server" ID="lblPrivacy"></asp:Label>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script type="text/javascript">
        $(document).ready(function () {
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('=');
            if (url.length > 1 && url[1] == "pr") {
                $("#menu2").addClass("active");
                $("#menu0").removeClass("active");
                $("#terms").removeClass("active");
                $("#privacy").addClass("active");
                $("#banner").text("Privacy Policy");
            }
            else {
                $("#menu0").addClass("active");
                $("#menu2").removeClass("active");
                $("#terms").addClass("active");
                $("#privacy").removeClass("active");
                $("#banner").text("Terms Of Service");
            }
        });
        function changeHeading() {
            if ($("#terms").hasClass("active")) {
                $("#banner").text("Privacy Policy");
            }
            else {
                $("#banner").text("Terms Of Service");
            }
        };
    </script>
</asp:Content>
