<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="GmailInformation.aspx.cs" Inherits="IITS_CloudAccounting.Admin.GmailInformation" %>

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
                    <a href="GmailInformation.aspx">Buy Stamp</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="panel-blue rounded-container peel-shadows" style="background-color: #0d83dd; border: 0; color: white;">
            <div class="content cutline-bottom">
                <h2 class="banner-title nomargin ta_center">Real mail. Real easy.</h2>
            </div>
            <div class="content clearfix buy-stamps-message-content">
                <div class="prepend-1 append-1 prepend-top-1 clearfix">
                    <h4 class="white">Mail invoices without leaving your desk</h4>
                    <div class="col-lg-6" style="padding: 0;">
                        <p class="light-blue-text">Send invoices through the mail without trekking to the mailbox. With one click, your invoice is printed, packaged, addressed, and sent on its way—like magic.</p>
                        <p>
                            <a href="#" class="white" target="_blank">Learn more</a>
                            or <a class="white" href="#">mail yourself a free sample invoice</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
        <div class="page-header">
            <h1>Buy Stamp</h1>
        </div>
        <div class="col-lg-8" style="padding: 0 10px 0 0;">
            <div class="bg_systemcolor1 utility-text rounded-container peel-shadows" style="background-color: #0d83dd; border: 1px solid #0d83dd; color: white;">
                <div class="content clearfix">
                    <div class=" prepend-top-half append-bottom-half">
                        <div class="col-lg-7">
                            Add
                            <input type="text" class="ta_center" style="width: 40px !important; box-shadow: 0 2px 0 #e5deb8 inset,0 0 3px #ebb95b; background-color: #fff8d5; border: solid 1px #ebb95b; border-radius: 3px !important; border-width: 1px; border-style: solid; border-color: #bbb #ddd #ddd #bbb; padding: 4px 3px !important;"
                                name="stamps" id="buy-stamps-amount" maxlength="4" value="" />
                            <span id="stamp-or-stamps">stamps</span> to my account
                        </div>
                        <div class="col-lg-5 ta_right">
                            <strong>Subtotal:</strong> $<span id="buy-stamps-total">0.00</span><br />
                            <span class="low-contrast-text fs_11">Taxes may apply</span>
                        </div>
                        <div class="clearb"></div>
                        <div class="prepend-top-1 ta_center">
                            <button id="purchase-button" class="button large inline fixed-width green" type="submit" name="purchase" value="purchase">Purchase</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="rounded-container peel-shadows">
                <div class="content clearfix">
                    <div class="col-lg-6">
                        <div class="promo-amount primary-figure">2 stamps</div>
                        <div class="fs_11">remaining</div>
                    </div>
                    <div class="col-lg-6">
                        <h5>Bulk Discount Pricing</h5>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>1 – 99</td>
                                    <td class="ta_right">$2.29 ea.</td>
                                </tr>
                                <tr>
                                    <td>100 – 499</td>
                                    <td class="ta_right">$1.79 ea.</td>
                                </tr>
                                <tr>
                                    <td>500+</td>
                                    <td class="ta_right">$1.49 ea.</td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="prepend-top-half append-bottom-1">
                            <span class="hl">Return envelope included</span>
                        </div>

                        <h5>Mailing Rates</h5>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>To US &amp; Canada</td>
                                    <td class="ta_right">1 stamp</td>
                                </tr>
                                <tr>
                                    <td>To anywhere else</td>
                                    <td class="ta_right">2 stamps</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4" style="padding: 0 0 0 10px;">
            <div class="rounded-container peel-shadows">
                <div class="content cutline-bottom">
                    <h5>Need help? Have questions?</h5>
                    <p><a class="permission" href="#">Email Bill Transact</a> or call us on weekdays, 5:30pm–5:30am IST at one of the numbers below:</p>

                    <p>
                        <strong>Toll-free in North America</strong><br />
                        1-866-303-6061
                    </p>
                    <p class="nomargin">
                        <strong>Worldwide</strong><br />
                        +1-416-481-6946
                    </p>
                </div>
                <div class="content" style="padding: 15px 15px 18px;">
                    <h5>Quick Links</h5>
                    <ul class="sidebar-list">
                        <li><a class="permission" href="#" target="_blank">Learn more about snail mail</a></li>
                        <li><a class="permission" href="#" target="_blank">Preview a sample invoice</a></li>
                        <li><a class="permission" href="#">Upload your snail mail logo</a></li>
                        <li><a class="permission" href="#">Mail yourself a free sample invoice</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
