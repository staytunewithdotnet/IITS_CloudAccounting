<%@ Page Title="Billing Information" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="BillingInformation.aspx.cs" Inherits="IITS_CloudAccounting.Admin.BillingInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("accountDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">My Account
                    </a>
                </li>
                <li>
                    <a href="BillingInformation.aspx">Billing Information</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Billing Information</h1>
            <h6>Here you'll find your current package, account limits, and payment history.</h6>
        </div>
        <div class="panel-body">
            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9" style="padding-top: 7px;">
                            <asp:Label runat="server" ID="lblPackageName" Text="Free Trial" Style="color: #0D83DD !important; font-family: FranklinNarrow,Arial,sans-serif; display: block; font-size: 44px; line-height: 54px;"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label" style="padding-left: 0;">
                            Client Contacts
                        </div>
                        <div class="col-lg-6 control-label" style="text-align: center;">
                            <div class="progress">
                                <div id="clientPro" runat="server" class="progress-bar progress-bar-striped active"></div>
                            </div>
                            <asp:Label runat="server" ID="lblClientPackageCount" Style="width: 100%; text-align: center;"></asp:Label>
                        </div>
                        <div class="col-lg-3 control-label">
                            <asp:Label runat="server" ID="lblClientCount"></asp:Label>
                            used
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Staff</div>
                        <div class="col-lg-6 control-label" style="text-align: center;">
                            <div class="progress">
                                <div id="staffPro" runat="server" class="progress-bar progress-bar-success progress-bar-striped"></div>
                            </div>
                            <asp:Label runat="server" ID="lblStaffPackageCount" Style="width: 100%; text-align: center;"></asp:Label>
                        </div>
                        <div class="col-lg-3 control-label">
                            <asp:Label runat="server" ID="lblStaffCount"></asp:Label>
                            used
                        </div>
                    </div>
                    <%--<div class="form-group">
                        <div class="col-lg-3 control-label">Disk Space</div>
                        <div class="col-lg-6 control-label">
                            <div class="progress">
                                <div class="progress-bar" style="width: 0"></div>
                            </div>
                        </div>
                        <div class="col-lg-3 control-label">0 of 250 MB</div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Auto-bills</div>
                        <div class="col-lg-6 control-label">
                            <div class="progress">
                                <div class="progress-bar progress-bar-danger" style="width: 100%"></div>
                            </div>
                        </div>
                        <div class="col-lg-3 control-label">0 used</div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Stamps</div>
                        <div class="col-lg-6">
                            2
                        </div>
                        <div class="col-lg-3 control-label" style="padding-left: 0;padding-right: 0;">
                            <a href="#">Buy More Stamps</a>
                        </div>
                    </div>--%>
                </div>
            </div>

            <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Upgrades</div>
                        <div class="col-lg-9" style="padding-top: 7px;">
                            <asp:Label runat="server" ID="lblUpgrades" Text="None"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Payments</div>
                        <div class="col-lg-9" style="padding-top: 7px;">
                            <asp:Label runat="server" ID="lblPayments" Text="None"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            &nbsp;
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Read the Bill Transact <a href="../TermsOfService.aspx" class="permission">terms of service </a>and <a href="../PrivacyPolicy.aspx" class="permission">privacy policy</a>.
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
