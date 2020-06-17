<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberArea.aspx.cs" Inherits="IITS_CloudAccounting.MemberArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Bill Transact - Member Area</title>
    <link rel="icon" href="App_Themes/sky/uploads/favIcon_billtransct.ico" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900" rel="stylesheet" />
    <link rel="stylesheet" href="App_Themes/sky/css/bootstrap.min.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/font-awesome.min.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/style.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/slick.css" />
    <link rel="stylesheet" href="App_Themes/sky/css/responsive.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="App_Themes/sky/js/bootstrap.min.js"></script>
</head>
<body class="bg-color">
    <form id="form1" runat="server">
        <div class="contact-section">
            <div class="container">
                <asp:Panel runat="server" ID="pnlLogin">
                    <div class="contact-heading">
                        <a href="Default.aspx">
                            <img src="App_Themes/sky/uploads/login-logo.png" alt="logo" /></a>
                        <h1>Login</h1>
                        <p>
                            You must login to access this page.
                        </p>
                    </div>
                    <asp:Login runat="server" ID="Login1" Width="100%">
                        <LayoutTemplate>
                            <div class="contact-form">
                                <asp:TextBox runat="server" ID="UserName" CssClass="input-field" placeholder="Email Address" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="Email Address is required." ID="UserNameRequired" Display="Dynamic" ForeColor="red">*</asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" CssClass="input-field" TextMode="Password" ID="Password" placeholder="Password" TabIndex="2"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired" Display="Dynamic" ForeColor="red">*</asp:RequiredFieldValidator>
                                <div style="color: red">
                                    <asp:Label runat="server" ForeColor="Red" ID="errorLabel"></asp:Label>
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </div>
                                <asp:Button runat="server" CssClass="banner-btn contact-btn" CommandName="Login" Text="LogIn" ValidationGroup="Login1" ID="LoginButton" OnClick="LoginButtonClick"></asp:Button>
                                <div class="forgot-password">
                                    <a href="MemberArea.aspx?cmd=pr">Forgot My Password?</a>
                                </div>
                                <div class="signup">
                                    <h6>Dont have account yet ?<a href="CompanySignUp.aspx"> Signup</a></h6>
                                    <br />
                                    <h6>Want To Login AS Cloud Bill Transact - Accountant,<a href="AccountantSignUp.aspx"> Click Here</a></h6>
                                </div>
                            </div>

                        </LayoutTemplate>
                    </asp:Login>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlPassword">
                    <div class="contact-heading">
                        <a href="Default.aspx">
                            <img src="App_Themes/sky/uploads/login-logo.png" alt="logo" /></a>
                        <h1>Recover your password.</h1>

                    </div>
                    <div class="contact-form">
                        <asp:PasswordRecovery runat="server" ID="PasswordRecovery1">
                            <SuccessTemplate>
                                <div class="signup">
                                    <h6>Your password has been sent to you.</h6>
                                </div>
                                <asp:Button runat="server" ID="btnCont" Text="Continue" CssClass="banner-btn contact-btn" OnClick="BtnContClick" />
                            </SuccessTemplate>
                            <UserNameTemplate>
                                <div class="signup">
                                    <h6>Enter your Email Address to receive your password.</h6>
                                    <br />
                                </div>
                                <asp:TextBox runat="server" CssClass="input-field" ID="UserName" PlaceHolder="Email Address" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ForeColor="red" Display="Dynamic" ErrorMessage="Email Address is required." ValidationGroup="PasswordRecovery1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                <div style="color: red">
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button runat="server" CssClass="banner-btn contact-btn" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" ID="SubmitButton"></asp:Button></div>

                                    <div class="col-md-6">
                                        <asp:Button ID="CancelButton" CssClass="banner-btn contact-btn" runat="server" Text="Cancel" OnClick="BtnContClick" /></div>
                                </div>
                            </UserNameTemplate>
                        </asp:PasswordRecovery>
                    </div>
                </asp:Panel>
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
