<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="IITS_CloudAccounting.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <meta charset="utf-8" />

    <link rel="stylesheet" href="App_Themes/Admin/css/bootstrap.min.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/font-awesome.min.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/style.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/main.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/main-responsive.css" />
    <!--<link rel="stylesheet" href="App_Themes/Admin/css/all.css" />-->
    <link rel="stylesheet" href="App_Themes/Admin/css/bootstrap-colorpalette.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/perfect-scrollbar.css" />
    <link rel="stylesheet" href="App_Themes/Admin/css/theme_light.css" type="text/css" id="skin_color" />
    <link rel="stylesheet" href="App_Themes/Admin/css/print.css" type="text/css" media="print" />
    <style>
        .form-control {
            width: 100% !important;
        }
    </style>
</head>
<body class="login example2">
    <form id="form1" runat="server">
        <div class="main-login col-sm-4 col-sm-offset-4">
            <div class="logo">
                Cloud <i class="clip-cloud"></i>Accounting
            </div>
            <!-- start: LOGIN BOX -->
            <div class="box-login">
                <asp:Login runat="server" ID="Login1" Width="100%">
                    <LayoutTemplate>
                        <h3>Sign in to your account</h3>
                        <p>
                            Please enter your name and password to log in.
                        </p>
                        <div class="form-group">
                            <span class="input-icon">
                                <asp:TextBox ID="UserName" runat="server" placeholder="Username" Style="width: 100% !important;" CssClass="form-control"></asp:TextBox>
                                <i class="fa fa-user"></i>
                            </span>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ForeColor="red" ValidationGroup="Login1" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-actions">
                            <span class="input-icon">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control password" placeholder="Password" Style="width: 100% !important;"></asp:TextBox>
                                <i class="fa fa-lock"></i>
                                <a class="forgot" href="#">I forgot my password
                                </a>
                            </span>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ForeColor="red" ValidationGroup="Login1" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                        <%--<tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>--%>
<%-- ReSharper disable UnknownCssClass --%>
                        <div class="errorHandler alert alert-danger">
<%-- ReSharper restore UnknownCssClass --%>
                            <asp:Label runat="server" ID="errorLabel"></asp:Label>
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-bricky pull-right" CommandName="Login" Text="Log In" ValidationGroup="Login1" OnClick="LoginButtonClick" />
                        </div>
                        <div class="new-account">
                        </div>
                    </LayoutTemplate>
                </asp:Login>
            </div>
            <%--<div class="box-login">
                <h3>Sign in to your account</h3>
                <p>
                    Please enter your name and password to log in.
                </p>
                <div class="form-login">
                    <div class="form-group">
                        <span class="input-icon">
                            <input type="text" class="form-control" name="username" placeholder="Username" style="width: 100% !important;" />
                            <i class="fa fa-user"></i></span>
                    </div>
                    <div class="form-group form-actions">
                        <span class="input-icon">
                            <input type="password" class="form-control password" name="password" placeholder="Password" style="width: 100% !important;" />
                            <i class="fa fa-lock"></i>
                            <a class="forgot" href="#">I forgot my password
                            </a></span>
                    </div>
                    <div class="form-actions">
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-bricky pull-right" Text="Login" PostBackUrl="Admin/Default.aspx" />
                    </div>
                    <div class="new-account">
                    </div>
                    <div class="errorHandler alert alert-danger">
                        You have some form errors. Please check below.
                    </div>
                </div>
            </div>--%>
            <div class="logo">
                <a href="Default.aspx">Back To Website</a>
            </div>
            <!-- start: FORGOT BOX -->
            <%--<div class="box-forgot">
                <h3>Forget Password?</h3>
                <p>
                    Enter your e-mail address below to reset your password.
                </p>
                <div class="form-forgot">
                    <div class="errorHandler alert alert-danger no-display">
                        <i class="fa fa-remove-sign"></i>You have some form errors. Please check below.
                    </div>
                    <fieldset>
                        <div class="form-group">
                            <span class="input-icon">
                                <input type="email" class="form-control" name="email" placeholder="Email">
                                <i class="fa fa-envelope"></i></span>
                        </div>
                        <div class="form-actions">
                            <a class="btn btn-light-grey go-back">
                                <i class="fa fa-circle-arrow-left"></i>Back
                            </a>
                            <button type="submit" class="btn btn-bricky pull-right">
                                Submit <i class="fa fa-arrow-circle-right"></i>
                            </button>
                        </div>
                    </fieldset>
                </div>
            </div>--%>
            <!-- end: FORGOT BOX -->

            <div class="copyright">
            </div>

        </div>
        <script src="App_Themes/Admin/js/jquery.min.js"></script>
        <script src="App_Themes/Admin/js/jquery-ui-1.10.2.custom.min.js"></script>
        <script src="App_Themes/Admin/js/bootstrap.min.js"></script>
        <script src="App_Themes/Admin/js/bootstrap-hover-dropdown.min.js"></script>
        <script src="App_Themes/Admin/js/jquery.blockUI.js"></script>
        <script src="App_Themes/Admin/js/jquery.icheck.min.js"></script>
        <script src="App_Themes/Admin/js/jquery.mousewheel.js"></script>
        <script src="App_Themes/Admin/js/perfect-scrollbar.js"></script>
        <script src="App_Themes/Admin/js/less-1.5.0.min.js"></script>
        <script src="App_Themes/Admin/js/jquery.cookie.js"></script>
        <script src="App_Themes/Admin/js/bootstrap-colorpalette.js"></script>
        <script src="App_Themes/Admin/js/main.js"></script>

        <script src="App_Themes/Admin/js/jquery.validate.min.js"></script>
        <script src="App_Themes/Admin/js/login.js"></script>
        <script>
            jQuery(document).ready(function () {
                Main.init();
                Login.init();
            });
        </script>
    </form>
</body>
</html>
