<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantProfile1.aspx.cs" Inherits="IITS_CloudAccounting.Accountant.AccountantProfile1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Accountant Profile</title>
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

    <style>
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
            <div class="col-lg-6" style="border-bottom: 1px solid #ccc; margin-top: 31.5px; text-align: right; padding-bottom: 15px;">
                <p class="meta">
                    Need help? Call toll-free: 1-234-567-8910<br />
                    Monday to Friday, 9am–6pm NDT
                </p>
            </div>

            <div class="clearfix"></div>

            <asp:Panel runat="server" ID="pnlRegister">
                <h1 style="color: #0d83dd; font-size: 40px; font-weight: normal; line-height: 40px; margin-bottom: 20px; margin-top: 20px; text-align: left;">Edit Your Profile
                </h1>
                <h2 style="color: #888888; font-family: Arial, sans-serif; font-size: 18px; font-weight: normal; line-height: 27px; margin-bottom: 20px; text-align: center;">Account Information </h2>

                <div class="col-lg-1">&nbsp;</div>
                <div class="col-lg-10">
                    <div class="form-horizontal" style="margin-bottom: 15px;">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Your Name <span style="color: red">*</span>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvFirstName" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                                <span style="color: #888888">First Name</span>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvLastName" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                                <span style="color: #888888">Last Name</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Email Address <span style="color: red">*</span>
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="3" Enabled="False"></asp:TextBox>
                                <span style="color: #888888">Your email address is also used to log into your account.</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Phone <span style="color: red">*</span>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPhone" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Company Name
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Address
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control text" TabIndex="5"></asp:TextBox>
                                <span style="color: #888888">Street</span>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="upAddress">
                            <ContentTemplate>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="6" AutoPostBack="True" CssClass="form-control text"
                                            DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                            SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where (CountryStatus='True')"></asp:SqlDataSource>
                                        <span style="color: #888888">Country</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList runat="server" ID="ddlState" DataSourceID="sqldsState" TabIndex="7" CssClass="form-control text"
                                            DataTextField="StateName" DataValueField="StateID" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                            SelectCommand="SELECT - 1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE ([CountryID] = @CountryID AND StateStatus='True')">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlCountry" Name="CountryID" PropertyName="SelectedValue" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <span style="color: #888888">Province/State</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList runat="server" ID="ddlCity" DataSourceID="sqldsCity" TabIndex="8" CssClass="form-control text"
                                            DataTextField="CityName" DataValueField="CityID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                            SelectCommand="SELECT - 1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE ([StateID] = @StateID AND CityStatus='True')">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlState" Name="StateID" PropertyName="SelectedValue" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <span style="color: #888888">City</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                        <span style="color: #888888">Postal/Zip Code</span>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="col-lg-3 control-label">
                            Password
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                            <span style="color: #888888">New Password</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtConPassword" TextMode="Password" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword" ControlToCompare="txtPassword">*</asp:CompareValidator>
                            <span style="color: #888888">Confirm Password</span>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="form-horizontal" style="border-top: 4px solid #cccccc; border-bottom: 2px solid #cccccc; margin-top: 15px; margin-bottom: 15px;">
                        <h2 style="color: #000; font-family: Arial, sans-serif; font-size: 18px; font-weight: normal; line-height: 27px; margin-bottom: 20px; text-align: center;">Professional Information </h2>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Profession
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtProfession" PlaceHolder="E.g. Accountant, Bookkeeper" CssClass="form-control text" TabIndex="10"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Designation
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtDesignation" PlaceHolder="E.g. CPA, CA, CGA" CssClass="form-control text" TabIndex="11"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="text-align: center">
                            <div class="col-lg-12">
                                <asp:Button runat="server" ID="btnUpdate" Text="Save Changes" CssClass="btn-success" ValidationGroup="AccountRegister" TabIndex="12" OnClick="btnUpdate_Click" />
                                or 
                                <a href="AccountantClients.aspx" class="permission">cancel</a>
                            </div>
                        </div>
                        <div class="form-group" style="text-align: center">
                            &nbsp;
                        </div>
                    </div>
                </div>
                <div class="col-lg-1">&nbsp;</div>
            </asp:Panel>

            <div class="clearfix"></div>

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
        <asp:HiddenField runat="server" ID="hfEmail"/>
        <asp:HiddenField runat="server" ID="hfAccountantID"/>
    </form>
</body>
</html>
