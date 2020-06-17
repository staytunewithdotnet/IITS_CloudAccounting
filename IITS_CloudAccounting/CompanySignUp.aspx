<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySignUp.aspx.cs" Inherits="IITS_CloudAccounting.CompanySignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="google-translate-customization" content="4981f505e60c2197-95c79325fe4110dd-gd155cbc1471967c4-1e" />
    <title>Bill Transact - SignUp</title>
    <link rel="icon" href="App_Themes/sky/uploads/favIcon_billtransct.ico" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900" rel="stylesheet" />
    <link rel="stylesheet" href="App_Themes/sky/css/bootstrap.min.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/font-awesome.min.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/style.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/slick.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/responsive.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="App_Themes/sky/js/bootstrap.min.js"></script>

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
    </style>
    <%-- ReSharper disable UseOfImplicitGlobalInFunctionScope --%>
    <%-- ReSharper disable WrongExpressionStatement --%>
    <script type="text/javascript">
        function googleTranslateElementInit() {
            new google.translate.TranslateElement({ pageLanguage: 'en', includedLanguages: 'en,fr', layout: google.translate.TranslateElement.InlineLayout.SIMPLE, multilanguagePage: true }, 'google_translate_element');
        }
    </script>
    <%-- ReSharper restore WrongExpressionStatement --%>
    <%-- ReSharper restore UseOfImplicitGlobalInFunctionScope --%>
    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
</head>
<%-- ReSharper disable UnknownCssClass --%>
<body class="bg-color">
    <form id="form1" runat="server">
        <div class="contact-section">
            <div class="container">
                <div class="white-bg">
                    <div class="contact-heading sinuptxt">
                        <a href="Default.aspx"><img src="App_Themes/sky/uploads/sinup-logo.png" alt="logo" /></a>
                        <h1>Try BillTransact Free</h1>
                        <p>No credit card required. Cancel anytime.</p>
                    </div>
                    <div class="contact-form sinuppage">
                        <asp:TextBox runat="server" ID="txtCompanyName" CssClass="input-field" PlaceHolder="Company Name" AutoPostBack="True" OnTextChanged="txtCompanyName_OnTextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCompanyName" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="input-field" PlaceHolder="Email Address" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailAddress" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revtxtEmailAddress" runat="server" ErrorMessage="Not Valid Email-Address" Display="Dynamic" Text="*" ControlToValidate="txtEmailAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CompanyRegistration"></asp:RegularExpressionValidator>

                        <asp:Button runat="server" ID="btnSubmit" Text="Try it Free for 30 Days" CssClass="banner-btn contact-btn" ValidationGroup="CompanyRegistration" OnClick="BtnSubmitClick" />
                        <div class="signup page">
                            <h6>Already have an Account ?<a href="MemberArea.aspx">Login</a></h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="App_Themes/sky/js/slick.js"></script>
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
</body>
</html>
