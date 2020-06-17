<%@ Page Title="" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="AfterRegister.aspx.cs" Inherits="IITS_CloudAccounting.AfterRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .but_hand_right {
            padding: 10px 22px 10px 22px;
            margin: 0;
            background: #2E9A9C;
            border-bottom: 1px solid #909090;
            font-family: 'Open Sans', sans-serif;
            font-size: 14px;
            color: #fff;
            font-weight: 600;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }

            .but_hand_right:hover {
                background-color: #2E9A9C;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Account Verification</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Account Verification</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <section id="pricing" class="section mainSection graySection  pricing">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div class="wpb_row row">
                    <div class="vc_col-sm-12 wpb_column vc_column_container" style="text-align: center;">
                        <div id="verifiedEmailDiv" runat="server">
                            <span style="color: Green; font-family: serif; font-size: x-large;">Thank You! Your email has been SuccessFully Verified!</span>
                            <br />
                            <br />
                            <br />
                            <div style="text-align: center;">
                                <asp:Button ID="btnMakePayment" runat="server" CssClass="but_hand_right" Text="Make Payment" />&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnLoginwithtrial" runat="server" CssClass="but_hand_right" Text="Login with Trial" OnClick="BtnLoginwithtrialClick" />
                            </div>
                        </div>
                        <div id="unverifiedEmailDiv" runat="server">
                            <br />
                            <span style="color: red; font-family: serif; font-size: x-large;" visible="False">Email address doesn't exists!</span>
                            <br />
                            <br />
                            <br />
                            <div style="text-align: center;">
                                <asp:Button ID="btnRegister" runat="server" CssClass="but_hand_right" Text="Sign Up for New Account" OnClick="BtnRegisterClick" />
                            </div>
                        </div>
                        <div id="noEmailDiv" runat="server">
                            <br />
                            <span style="color: red; font-family: serif; font-size: x-large;" visible="False">Oops! Something Wrong!!! Please visit again!!!</span>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
