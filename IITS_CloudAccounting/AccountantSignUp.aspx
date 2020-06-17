<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantSignUp.aspx.cs" Inherits="IITS_CloudAccounting.AccountantSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Bill Transact - Accountant Area</title>
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
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
        <div class="contact-section">
            <div class="container">
                <asp:Panel runat="server" ID="pnlRegister">
                    <div class="contact-heading">
                        <a href="Default.aspx">
                            <img src="App_Themes/sky/uploads/login-logo.png" alt="logo" /></a>
                        <h1>Accountant SignUp</h1>
                        <p>
                            Create Your Free Accountant Center.
                        </p>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upEmail">
                        <ContentTemplate>
                            <div class="contact-form">

                                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="input-field" placeholder="Email Address" AutoPostBack="True" OnTextChanged="TxtEmailAddressTextChanged" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailAddress" Display="Dynamic" ForeColor="Red" ValidationGroup="Register" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" SetFocusOnError="True" ValidationGroup="Register" ControlToValidate="txtEmailAddress" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                <asp:TextBox runat="server" CssClass="input-field" TextMode="Password" ID="txtPassword" placeholder="Password" TabIndex="2"></asp:TextBox>

                                <asp:RequiredFieldValidator runat="server" ID="rfvPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="contact-form">
                                <asp:TextBox runat="server" ID="txtConPassword" TextMode="Password" CssClass="input-field" placeholder="Confirm Password" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ID="cvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword" ControlToCompare="txtPassword">*</asp:CompareValidator>
                                <asp:Button runat="server" ID="btnCreate" CssClass="banner-btn contact-btn" Text="Create My Account" ValidationGroup="Register" OnClick="BtnCreateClick" />
                                <div class="signup">
                                    <h6>Already have an account? 
                                        <asp:LinkButton runat="server" ID="lnkBtnLogin" Text="Log in" OnClick="lnkBtnLogin_OnClick"></asp:LinkButton>

                                    </h6>
                                    <br />
                                    <h6>For Company/Client/Staff Login Access area, please<a href="MemberArea.aspx"> Click Here</a></h6>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlLogin">
                    <div class="contact-heading">
                        <a href="Default.aspx">
                            <img src="App_Themes/sky/uploads/login-logo.png" alt="logo" /></a>
                        <h1>Accountant Login</h1>
                        <p>
                            Log In To Your Accountant Center.
                        </p>
                    </div>
                    <asp:Login runat="server" ID="Login1" Width="100%">
                        <LayoutTemplate>
                            <div class="contact-form">

                                <asp:TextBox runat="server" ID="UserName" CssClass="input-field" placeholder="Email Address" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="Dynamic" ForeColor="red" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" CssClass="input-field" TextMode="Password" ID="Password" placeholder="Password" TabIndex="2"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="Password" ForeColor="red" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                <div style="color: red">
                                    <asp:Label runat="server" ForeColor="Red" ID="errorLabel"></asp:Label>
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </div>
                                <asp:Button runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton" CssClass="banner-btn contact-btn" OnClick="LoginButtonClick"></asp:Button>
                                <div class="forgot-password">
                                    <asp:LinkButton runat="server" ID="lnkBtnPassword" Text="Forget Your Password?" OnClick="lnkBtnPassword_OnClick"></asp:LinkButton>
                                </div>
                                <div class="signup">
                                    <h6>Don't have an account ?
                                        <asp:LinkButton runat="server" ID="lnkBtnRegister" Text="Sign Up" OnClick="lnkBtnRegister_OnClick"></asp:LinkButton></h6>
                                    <br />
                                    <h6>For Company/Client/Staff Login Access area, please<a href="MemberArea.aspx"> Click Here</a></h6>
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
                                        <asp:Button runat="server" CssClass="banner-btn contact-btn" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" ID="SubmitButton"></asp:Button>
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Button ID="CancelButton" CssClass="banner-btn contact-btn" runat="server" Text="Cancel" OnClick="BtnContClick" />
                                    </div>
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