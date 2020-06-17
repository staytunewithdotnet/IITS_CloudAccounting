<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantClients1.aspx.cs" Inherits="IITS_CloudAccounting.Accountant.AccountantClients1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Accountant Clients</title>
    <link rel="stylesheet" href="../App_Themes/Blue/css/language-selector.css?v=3.1.8.3" type="text/css" media="all" />
    <link rel='stylesheet' href='../App_Themes/Blue/css/switcher-style.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/font-awesome.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/bootstrap.min.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/css3-animations.css' type='text/css' media='all' />
    <link href="../App_Themes/Blue/css/css.css" rel="stylesheet" />
    <link href="../App_Themes/Blue/css/style.css" rel="stylesheet" />
    <link href="../App_Themes/Blue/css/bootstrap.min.css" rel="stylesheet" />
    <link rel='stylesheet' href='../App_Themes/Blue/css/style.css' type='text/css' media='all' />
    <style id='style-inline-css' type='text/css'>
            
        </style>
    <link rel='stylesheet' href='../App_Themes/Blue/css/blue.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/responsive.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/js_composer.css' type='text/css' media='all' />
    <link rel='stylesheet' href='../App_Themes/Blue/css/custom.css' type='text/css' media='screen' />
    <link href="../App_Themes/Blue/css/css1.css" rel="stylesheet" />
    <script type='text/javascript' src='../App_Themes/Blue/js/jquery.js'> </script>
    <script type='text/javascript' src='../App_Themes/Blue/js/jquery-migrate.min.js'> </script>
    <link href="../App_Themes/Doyingo/css/otherstyles.css" rel="stylesheet" media="all" />
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" media="all" />

    <style type="text/css">
        .ajax__tab_xp .ajax__tab_body {
            padding: 0 0 0 0;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            font-family: Verdana;
            font-size: 13px;
            height: 40px;
            margin: 0;
            padding: 4px;
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

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }

        .sub-menu table > tbody > tr > td {
            line-height: 0 !important;
            padding: 0 !important;
        }

        .footer .table, .footer p {
            margin: 0 !important;
        }

        .textbox {
            font-size: 18px !important;
            font-weight: normal !important;
            width: 55%;
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
            margin-bottom: 20px;
            padding-left: 25px;
        }

        ol, ul {
            list-style: none;
        }

        .checklist-vertical .checklist-item {
            margin-bottom: 20px;
        }

        .checklist-item {
            background: url(../App_Themes/Doyingo/images/checkmark.png) no-repeat top left;
            margin-left: -25px;
            padding-left: 25px;
        }

        .heading-basest {
            color: black;
            font-size: 13px;
            font-weight: bold;
            margin: 0;
        }

            .heading-basest + p {
                font-size: 12px;
                line-height: normal;
                margin-top: 0;
            }

        p {
            margin: 18px 0;
        }

        input[type="text"], input[type="password"], textarea, select {
            display: inline-block;
            font-weight: 400;
            padding: 10px;
            width: 96% !important;
        }
    </style>
</head>
<body id="top" class="home page page-id-14 page-template page-template-templates page-template-homepage page-template-templateshomepage-php style-1  wpb-js-composer js-comp-ver-4.3.5 vc_responsive" data-image="">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
        <div class="col-lg-12" style="background: #0d83dd none repeat scroll 0 0; color: #c3e0f7; font: 14px/40px Arial,sans-serif; margin-bottom: 20px;">
            <div class="col-lg-2">&nbsp;</div>
            <div class="col-lg-8">
                <span>
                    <a href="AccountantClients.aspx" style="color: #c3e0f7;">Accountant Center</a>
                </span>
                <span style="float: right; margin-top: 10px;">
                    <a href="AccountantProfile.aspx" style="color: #c3e0f7; margin-right: 15px;">Edit Profile</a>
                    <asp:LoginStatus runat="server" ID="LoginStatus1" Style="color: #c3e0f7;" LogoutText="Log Out" LogoutAction="Redirect" LogoutPageUrl="../AccountantSignUp.aspx" />
                </span>
            </div>
            <div class="col-lg-2">&nbsp;</div>
        </div>

        <div class="clearfix"></div>

        <div class="col-lg-2">&nbsp;</div>
        <div class="col-lg-8 allWrapper">
            <div class="col-lg-6" style="border-bottom: 1px solid #ccc; padding-bottom: 15px;">
                <img alt="DoyinGo" class="testmonialthumb" src="../App_Themes/Blue/images/logo.jpg" style="height: 90px;" />
                <h2 style="border-left: 1px solid #ccc; color: #0d83dd; display: inline-block; font-family: 'Franklin-light', 'Arial Narrow', 'Calibri', Helvetica, Arial, sans-serif; font-size: 24px; line-height: 25px; margin: 30px 0 0 5px; padding-left: 10px; width: 50px;">Accountant Center
                </h2>
            </div>
            <div class="col-lg-6" style="border-bottom: 1px solid #ccc; margin-top: 32px; text-align: right; padding-bottom: 15px;">
                <p class="meta">
                    Need help? Call toll-free: 1-234-567-8910<br />
                    Monday to Friday, 9am–6pm NDT
                </p>
            </div>

            <div class="clearfix"></div>
            <h2 style="color: #888888; font-family: Arial, sans-serif; font-size: 18px; font-weight: normal; line-height: 27px; margin-bottom: 20px; text-align: center;">Accountant Dashboard</h2>
            <h2 style="color: #000; font-size: 30px; font-weight: normal; line-height: 30px; margin-bottom: 40px; text-align: left; display: inline-block">Your DoyinGo Clients</h2>
            <span style="float: right">
                <asp:Button runat="server" ID="btnClient" Text="Invite Client" CssClass="btn-success" />
            </span>

            <div class="clearfix"></div>

            <div class="col-lg-1" style="width: 4%"></div>
            <div class="col-lg-5 rounded-container peel-shadows" style="width: 45%; padding-bottom: 0; padding-top: 15px;">
                <strong>Invited Client by You</strong>
                <asp:DataList runat="server" ID="dlClientByYou" Width="100%" DataKeyField="AccountantClientDetailID" DataSourceID="sqldsClientByYou" Style="margin-bottom: 0;">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AccountantClientDetailID") %>' runat="server" ID="AccountantClientDetailIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("AccountantID") %>' runat="server" ID="AccountantIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("CompanyID") %>' runat="server" ID="CompanyIDLabel" Visible="False" />
                        <h3 style="margin: 0;">
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" /></h3>
                        <h5 style="margin: 0;">
                            <asp:Label Text='<%# Eval("CompanyContactPerson") %>' runat="server" ID="CompanyContactPersonLabel" />
                        </h5>
                        <i class="fa fa-envelope" style="font-size: 15px;"></i>
                        <a href='<%# "mailto:"+ Eval("CompanyEmail") %>' class="permission">
                            <asp:Label Text='<%# Eval("CompanyEmail") %>' runat="server" ID="CompanyEmailLabel" />
                        </a>
                        <br />
                        <asp:LinkButton runat="server" ID="lnkRemoveFromClient" Text="Remove client" CssClass="permission" OnClick="lnkRemoveFromClient_OnClick"
                            ToolTip='<%# Eval("AccountantClientDetailID") %>' ></asp:LinkButton>
                        <br />
                        <br />
                        <hr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblClientEmpty" Text="No Company Invited By You" Visible='<%# bool.Parse((dlClientByYou.Items.Count==0).ToString()) %>'></asp:Label>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="sqldsClientByYou" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT AccountantClientDetailID,AccountantID,a.CompanyID,b.CompanyContactPerson,b.CompanyName,b.CompanyEmail FROM AccountantClientDetail a inner join CompanyMaster b on a.CompanyID = b.CompanyID WHERE RequestToClient = 1 AND AccountantID = @AccountantID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfAccountantID" PropertyName="Value" DefaultValue="0" Name="AccountantID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
            <div class="col-lg-1" style="width: 2%"></div>
            <div class="col-lg-5 rounded-container peel-shadows" style="width: 45%; padding-bottom: 0; padding-top: 15px;">
                <strong>You Invited by Client </strong>
                <asp:DataList runat="server" ID="dlYouByClient" Width="100%" DataKeyField="AccountantClientDetailID" DataSourceID="sqldsYouByClient" Style="margin-bottom: 0;">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AccountantClientDetailID") %>' runat="server" ID="AccountantClientDetailIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("AccountantID") %>' runat="server" ID="AccountantIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("CompanyID") %>' runat="server" ID="CompanyIDLabel" Visible="False" />
                        <h3 style="margin: 0">
                            <asp:Label Text='<%# Eval("CompanyContactPerson") %>' runat="server" ID="CompanyContactPersonLabel" />
                        </h3>
                        <h5 style="margin: 0">
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" />
                        </h5>
                        <i class="fa fa-envelope" style="font-size: 15px;"></i>
                        <a href='<%# "mailto:"+ Eval("CompanyEmail") %>' class="permission">
                            <asp:Label Text='<%# Eval("CompanyEmail") %>' runat="server" ID="CompanyEmailLabel" />
                        </a>
                        <br />
                        <asp:LinkButton runat="server" ID="lnkRemoveByClient" Text="Remove client" CssClass="permission" OnClick="lnkRemoveByClient_OnClick"
                            ToolTip='<%# Eval("AccountantClientDetailID") %>' ></asp:LinkButton>
                        <%-- OnClientClick='<%# Eval("return confirm('Are you sure you want to disconnect this client from your Accountant Center?')") %>' --%>
                        <br />
                        <br />
                        <hr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblYouEmpty" Text="No Company Invited You As Accountant" Visible='<%# bool.Parse((dlYouByClient.Items.Count==0).ToString()) %>'></asp:Label>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="sqldsYouByClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT AccountantClientDetailID,AccountantID,a.CompanyID,b.CompanyContactPerson,b.CompanyName,b.CompanyEmail FROM AccountantClientDetail a inner join CompanyMaster b on a.CompanyID = b.CompanyID WHERE RequestFromClient = 1 AND AccountantID = @AccountantID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfAccountantID" PropertyName="Value" DefaultValue="0" Name="AccountantID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
            <div class="col-lg-1" style="width: 4%"></div>

            <div class="clearfix"></div>

            <footer class="footer" id="footer" style="margin-top: 15px;">
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
                                <div class="footerSocialWrapper" style="margin-right: 15px; padding-top: 25px;">
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

            <script type='text/javascript' src='../App_Themes/Blue/js/switcher.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/comment-reply.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/owl-carousel.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/smooth-scroll.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/modernizr.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/retina.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/fancy-select.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/ms-drop-down.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/ticker.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/rrssb-share-btn.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/mix-it-up.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/easy-tabs.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/flip-clock.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/nice-scroll.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/touch-effect.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/jquery.easing.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/html5shiv-printshiv.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/respond.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/isotope.pkgd.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/imagesloaded.pkgd.min.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/scripts.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/bootstrap.js'> </script>
            <script type='text/javascript' src='../App_Themes/Blue/js/js_composer_front.js'> </script>
        </div>
        <div class="col-lg-2">&nbsp;</div>
        <asp:HiddenField runat="server" ID="hfAccountantID" />

        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInviteAcc2" PopupControlID="pnlInviteAcc2" TargetControlID="btnClient" CancelControlID="lnkSecondClose" BackgroundCssClass="modelBackground">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="pnlInviteAcc2" runat="server" Height="580px" Width="600px" align="left" Style="background-color: white; border: 5px solid rgb(211, 211, 211); border-radius: 15px; display: none; position: fixed; z-index: 100001;">
            <div class="panel-body" style="border-color: #e9edf2; background-color: #F1F1F1; color: black; border-radius: 9px 9px 0 0;">
                <div class="x_button" role="button"></div>
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-12">
                                <h3 style="margin-left: 0;">Compose Your Invitation</h3>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Client's Email <span style="color: red">*</span>
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control text" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailAddress" Display="Dynamic" ForeColor="Red" ValidationGroup="Invitation" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" SetFocusOnError="True" ValidationGroup="Invitation" ControlToValidate="txtEmailAddress" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Subject
                            </div>
                            <div class="col-lg-8">
                                <asp:Label runat="server" ID="lblSubject"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="background-color: #FFF; color: lightgray; text-align: center">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <h3 style="margin: 0; font-weight: normal; color: #888888; font-size: 18px">
                                    <asp:Label runat="server" ID="lblAccountant" Style="font-weight: bold; color: black;" Text="Person Name"></asp:Label>
                                    from
                                <asp:Label runat="server" ID="lblAccountantCompany" Style="font-weight: bold; color: black;" Text="Company Name"></asp:Label>
                                    has invited you to connect using DoyinGo to painlessly send invoices, track time, and capture expenses. Accept this invitation to make collaborating with your Accountant easy by giving them access to your DoyinGo Reports. 
                                </h3>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-1">&nbsp;</div>
                            <div class="col-lg-10" style="text-align: center">
                                <asp:TextBox runat="server" ID="txtDesc" Text="DoyinGo allows you to easily capture your business transactions and provides me with the information I need, reducing the stress of tax time." TextMode="MultiLine" Style="font-size: large; font-weight: bold;"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">&nbsp;</div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="background-color: #F1F1F1; color: black; text-align: center; border-radius: 0 0 9px 9px;">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button runat="server" ID="btnSend" CssClass="btn btn-success" Text="Send" ValidationGroup="Invitation" OnClick="BtnSendClick" />
                                or
                            <asp:LinkButton runat="server" ID="lnkSecondClose" Text="cancle" CssClass="permission"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>
    </form>
</body>
</html>
