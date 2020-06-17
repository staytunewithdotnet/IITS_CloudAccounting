<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InviteCompanyByAccountant.aspx.cs" Inherits="IITS_CloudAccounting.InviteCompanyByAccountant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Bill Transact Company - SignUp</title>
    <link rel="stylesheet" href="App_Themes/Blue/css/language-selector.css?v=3.1.8.3" type="text/css" media="all" />
    <link rel='stylesheet' href='App_Themes/Blue/css/switcher-style.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/font-awesome.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/bootstrap.min.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/css3-animations.css' type='text/css' media='all' />
    <link href="App_Themes/Blue/css/css.css" rel="stylesheet" />
    <link href="App_Themes/Blue/css/style.css" rel="stylesheet" />
    <link href="App_Themes/Blue/css/bootstrap.min.css" rel="stylesheet" />
    <link rel='stylesheet' id='stylecss' href='App_Themes/Blue/css/style.css' type='text/css' media='all' />
    <style id='style-inline-css' type='text/css'>
        </style>
    <link rel='stylesheet' href='App_Themes/Blue/css/blue.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/responsive.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/js_composer.css' type='text/css' media='all' />
    <link rel='stylesheet' href='App_Themes/Blue/css/custom.css' type='text/css' media='screen' />
    <link href="App_Themes/Blue/css/css1.css" rel="stylesheet" />
    <script type='text/javascript' src='App_Themes/Blue/js/jquery.js'></script>
    <script type='text/javascript' src='App_Themes/Blue/js/jquery-migrate.min.js'></script>
    <link href="App_Themes/DoyinGo/css/otherstyles.css" rel="stylesheet" media="all" />

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

        .footer .table, .footer p {
            margin: 0 !important;
        }

        .textbox {
            width: 55%;
            font-size: 18px !important;
            font-weight: normal !important;
        }

        @media (max-width: 450px) {
            .textbox {
                width: 68%;
            }
        }

        .btn-success {
            background-color: #8ed221 !important;
        }

            .btn-success:hover {
                background-color: #5cb85c !important;
            }

        .checklist:last-child {
            margin-bottom: 0;
        }

        .checklist {
            padding-left: 25px;
            margin-bottom: 20px;
        }

        ol, ul {
            list-style: none;
        }

        .checklist-vertical .checklist-item {
            margin-bottom: 20px;
        }

        .checklist-item {
            padding-left: 25px;
            margin-left: -25px;
            background: url(App_Themes/DoyinGo/images/checkmark.png) no-repeat top left;
        }

        .heading-basest {
            margin: 0;
            font-weight: bold;
            font-size: 13px;
            color: black;
        }

            .heading-basest + p {
                margin-top: 0;
                line-height: normal;
                font-size: 12px;
            }

        p {
            margin: 18px 0;
        }

        input[type="text"], input[type="password"], textarea, select {
            display: inline-block;
            width: 96% !important;
            padding: 10px;
            font-weight: 400;
        }
    </style>

</head>

<body id="top" class="home page page-id-14 page-template page-template-templates page-template-homepage page-template-templateshomepage-php style-1  wpb-js-composer js-comp-ver-4.3.5 vc_responsive" data-image="">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
        <div class="col-lg-6" style="border-bottom: 1px solid #ccc;">
            <img alt="DoyinGo" class="testmonialthumb" src="App_Themes/Blue/images/logo.jpg" style="height: 90px;" />
        </div>
        <div class="col-lg-6" style="text-align: right; margin-top: 31.5px; border-bottom: 1px solid #ccc;">
            <p class="meta">
                Need help? Call toll-free: 514-447-7064<br />
                Monday to Friday, 9am–6pm NDT
            </p>
        </div>
        <div class="clearfix"></div>
        <div class="col-lg-2">&nbsp;</div>
        <div class="col-lg-8 allWrapper">

            <asp:Panel runat="server" ID="pnlRegister">
                <h1 style="font-size: 40px; line-height: 40px; color: #0d83dd; font-weight: normal; margin-top: 20px; margin-bottom: 20px; text-align: center;">Accept Your Accountant’s Invitation
                </h1>
                <h2 style="font-size: 18px; font-family: Arial, sans-serif; font-weight: normal; color: #888888; line-height: 27px; margin-bottom: 40px; text-align: center;">
                    Accountant suggests creating a free Bill Transact account. You’ll painlessly send invoices, capture expenses and give your Accountant access to the reports they need.
                </h2>

                <div class="col-lg-2">&nbsp;</div>
                <div class="col-lg-8 panel-blue" style="background-color: #e4f4fe; padding: 27px 30px 15px 30px; text-align: center; margin-bottom: 44px; border-radius: 10px;">
                    <div class="form-horizontal">
                        <asp:UpdatePanel runat="server" ID="upEmail">
                            <ContentTemplate>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Company Name
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" PlaceHolder="Company Name" AutoPostBack="True" OnTextChanged="txtCompanyName_OnTextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvCompanyName" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="Register" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Email Address
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control text" PlaceHolder="Email Address" Text="" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailAddress" Display="Dynamic" ForeColor="Red" ValidationGroup="Register" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" SetFocusOnError="True" ValidationGroup="Register" ControlToValidate="txtEmailAddress" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button runat="server" ID="btnCreate" CssClass="btn-success" Text="Accept Invitation" ValidationGroup="Register" OnClick="BtnCreateClick" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <small style="font-size: 100%">Already have an account? 
                                    <asp:LinkButton runat="server" ID="lnkBtnLogin" Text="Log in" CssClass="permission" OnClick="lnkBtnLogin_OnClick"></asp:LinkButton>
                                </small>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2">&nbsp;</div>
            </asp:Panel>

            <div class="clearfix"></div>

            <asp:Panel runat="server" ID="pnlLogin">
                <h1 style="font-size: 40px; line-height: 40px; color: #0d83dd; font-weight: normal; margin-top: 20px; margin-bottom: 40px; text-align: center;">Log In To Your Bill Transact Account
                </h1>
                <div class="col-lg-2">&nbsp;</div>
                <div class="col-lg-8 panel-blue" style="background-color: #e4f4fe; padding: 27px 30px 15px 30px; text-align: center; margin-bottom: 90px; border-radius: 10px;">
                    <asp:Login runat="server" ID="Login1" Width="100%">
                        <LayoutTemplate>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Email Address
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control text"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="Dynamic" ForeColor="red" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Password
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" TextMode="Password" ID="Password" CssClass="form-control text"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="Password" ForeColor="red" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center;">
                                        <%--<asp:LinkButton runat="server" ID="lnkBtnPassword" Text="Forget Your Password?" CssClass="permission" OnClick="lnkBtnPassword_OnClick"></asp:LinkButton>--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                        <asp:Label runat="server" ID="errorLabel" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center;">
                                        <asp:Button runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton" CssClass="btn-success" OnClick="LoginButtonClick"></asp:Button>
                                    </div>
                                    <div class="col-lg-12" style="text-align: center;">
                                        Don't have an account? 
                                        <asp:LinkButton runat="server" ID="lnkBtnRegister" Text="Sign Up" CssClass="permission" OnClick="lnkBtnRegister_OnClick"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
                <div class="col-lg-2">&nbsp;</div>
            </asp:Panel>

            <div class="clearfix"></div>

            <footer class="footer" id="footer">
                <p style="font-weight: normal; font-size: 15px; text-align: center; background-color: #21242e; margin-bottom: 0;">
                    Already have system account? <a href="MemberArea.aspx">Log in</a>
                </p>
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
                            <div class="col-md-2 footerSocial">
                                <div class="footerSocialWrapper" style="padding-top: 25px; margin-right: 15px;">
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

            <script type='text/javascript' src='App_Themes/Blue/js/switcher.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/comment-reply.min.js'></script>
            <script type='text/javascript' src='//maps.google.com/maps/api/js?sensor=false&#038;ver=4.1.1'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/owl-carousel.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/smooth-scroll.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/modernizr.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/retina.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/fancy-select.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/ms-drop-down.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/ticker.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/rrssb-share-btn.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/mix-it-up.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/easy-tabs.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/flip-clock.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/nice-scroll.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/touch-effect.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/jquery.easing.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/html5shiv-printshiv.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/respond.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/isotope.pkgd.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/imagesloaded.pkgd.min.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/scripts.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/bootstrap.js'></script>
            <script type='text/javascript' src='App_Themes/Blue/js/js_composer_front.js'></script>
        </div>
        <div class="col-lg-2">&nbsp;</div>
    </form>
</body>
</html>
