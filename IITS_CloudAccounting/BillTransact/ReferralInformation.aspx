<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ReferralInformation.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ReferralInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/referalStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("homeDiv");
            d.style.display = 'block';
        });
    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="DefaultDoyingo.aspx">Home
                    </a>
                </li>
                <li>
                    <a href="ReferralInformation.aspx">Refer Bill Transact</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Refer Bill Transact</h1>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="col-lg-8" style="padding: 0 10px 0 0;">
            <div class="rounded-container peel-shadows">
                <div class="content clearfix">
                    <%--<div class="col-lg-6 prepend-1 prepend-top-1 float_right">
                        <img src="../App_Themes/Doyingo/images/referrals.png" alt="" />
                    </div>--%>
                    <h2 class="append-bottom-half">Help a friend save time. Earn 25% for their first year.</h2>
                    <p style="text-align: justify;">Do you know someone who might be wasting time doing business the old-fashioned way? Introduce them to Bill Transact and if they upgrade, you'll receive 25% of their plan payments for an entire year.</p>
                    <div>
                        <a href="#" class="button large green  inline first" style="">Email a Friend
                        </a>


                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="padding: 0 0 0 10px;">
            <div class="rounded-container peel-shadows">
                <div class="content">
                    <h4>Personalized Referral Link</h4>
                    <div style="text-align: justify;">Share this link to your personalized sign-up page, and we'll count any sign-ups as referrals by you.</div>
                </div>
                <div class="content bg_grey95 content-bottom">
                    <div>
                        <strong>Referral link:</strong>
                        <a href="#" id="clip_button_1" class="fs_11 float_right" data-clipboard-text="#">copy</a>
                        <input id="clip_link_1" class="banner-link fs_10 clearb" type="text" value="#" readonly="readonly" />
                    </div>

                </div>
            </div>
            <div class="rounded-container peel-shadows">
                <div class="content">
                    <h4>Bill Transact Web Banners</h4>
                    <div class="append-bottom-half" style="text-align: justify;">We've got a bunch of cool banners that you can place on your web site to spread the word and even earn some more referrals.</div>
                    <div>
                        <a href="#">Get web banners</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
