<%@ Page Title="Online Payment Of Invoice" Language="C#"
    AutoEventWireup="true" CodeBehind="InvoiceNoPayment.aspx.cs" Inherits="IITS_CloudAccounting.Client.InvoiceNoPayment" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Client Panel</title>
    <link href="../App_Themes/Doyingo/css/css.css" rel="stylesheet" type="text/css" />

    <link href="../App_Themes/Doyingo/css/uniform.default.min.css" rel="stylesheet" />

    <link href="../App_Themes/Doyingo/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/simple-line-icons.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/menu_cornerbox.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/waves.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/switchery.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/component.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/weather-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/MetroJs.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/toastr.min.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/modern.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/white.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Doyingo/css/select2.min.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script src="../App_Themes/Doyingo/js/modernizr.js"> </script>
    <script src="../App_Themes/Doyingo/js/snap.svg-min.js"> </script>

    <link href="../App_Themes/Doyingo/css/otherstyles.css" rel="stylesheet" media="all" />
    <style>
        .page-header {
            margin: 0 0 20px;
        }
    </style>
</head>

<body class="page-header-fixed  pace-done page-horizontal-bar page-sidebar-fixed compact-menu">

    <div class="overlay"></div>

    <div id="main" class="content-wrap container">
        <div class="navbar">
            <div class="navbar-inner">
                <ul class="nav navbar-nav navbar-right hideMobile" style="background-color: #EEEEEE;">
                    <li id="clientProfile" runat="server">
                        <a href="ClientProfile.aspx" style="padding: 0 15px;">Profile</a>
                    </li>
                </ul>
            </div>
            <div class="clearfix"></div>
            <div class="navbar-inner">
                <div class="sidebar-pusher">
                    <a href="javascript:void(0);" class="waves-effect waves-button waves-classic push-sidebar">
                        <i class="fa fa-bars"></i>
                    </a>
                </div>
                <div class="logo-box" style="margin-top: -18px;">
                    <a href="Default.aspx" class="logo-text">
                        <asp:Image runat="server" ID="imgLogo" Style="height: 78px; width: 104px;" alt="DoyinGo" />
                    </a>
                </div>
                <!-- Logo Box -->
                <div class="topmenu-outer">
                    <div class="top-menu">
                    </div>
                </div>
            </div>
        </div>

        <div class="sidebar horizontal-bar">
            <div class="slimScrollDiv" style="height: 100%; overflow: hidden; position: relative; width: auto;">
                <div class="page-sidebar-inner slimscroll" style="height: 100%; overflow: hidden; width: auto;">
                    <div class="sidebar-header">
                        <div class="sidebar-profile">
                        </div>
                    </div>

                    <div id="mainUl" runat="server">
                        <ul id="ulScroll" class="menu accordion-menu" style="background: #0DB9B7;">
                            <li id="home" runat="server" class="">
                                <a href="Default.aspx"><i class="menu-icon glyphicon glyphicon-home"></i>
                                    <span class="title">Home </span><span class="selected"></span>
                                </a>
                            </li>

                            <li id="invoice" runat="server" class="">
                                <a href="AllInvoice.aspx"><i class="menu-icon fa fa-file"></i>
                                    <span class="title">Invoices </span><span class="selected"></span>
                                </a>
                            </li>

                            <li id="Estimate" runat="server" class="">
                                <a href="ClientEstimate.aspx"><i class="menu-icon fa fa-file-excel-o"></i>
                                    <span class="title">Estimates </span><span class="selected"></span>
                                </a>
                            </li>

                            <li id="timeTracking" runat="server" class="">
                                <a href="Projects.aspx"><i class="menu-icon fa fa-clock-o"></i>
                                    <span class="title">Projects</span><span class="selected"></span>
                                </a>
                            </li>

                            <li id="moreMenu" runat="server" class="">
                                <a href="#"><i class="menu-icon fa fa-expand"></i>
                                    <span class="title">More </span><span class="selected"></span>
                                </a>
                            </li>

                        </ul>

                    </div>
                </div>
            </div>
            <div class="slimScrollBar" style="background: rgb(204, 204, 204); border-radius: 0; display: none; height: 50px; opacity: 0.3; position: absolute; right: 0; top: 0; width: 7px; z-index: 99;"></div>
            <div class="slimScrollRail" style="background: rgb(51, 51, 51); border-radius: 0; display: none; height: 100%; opacity: 0.2; position: absolute; right: 0; top: 0; width: 7px; z-index: 90;"></div>
            <!-- Page Sidebar Inner -->
        </div>
        <div class="page-inner" style="">
            <div id="editor" class="bypass" style="display: none;"></div>
            <div style="text-align: center;">
                <br />
                <br />
                <p style="font-size: 16pt; font-weight: bold;">
                    We're sorry, Payment information not found.
                </p>
                <p style="font-size: 14pt;">
                    No IO Payment Information Found For Company. Contact Company Admin to Add IO Payment Information
                </p>

            </div>
            <div class="col-lg-12" style="margin: 25px 0;"></div>

        </div>
    </div>


</body>
</html>


