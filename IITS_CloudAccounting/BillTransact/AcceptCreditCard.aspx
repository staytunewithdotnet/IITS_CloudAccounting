<%@ Page Title="Accept Credit Card" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="AcceptCreditCard.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AcceptCreditCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="AcceptCreditCard.aspx">Accept Credit Card</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: none">
            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <h1>Accept Credit Cards As Payment</h1>
                <h6>Get paid faster by letting clients pay you by credit card. Learn more.</h6>
            </div>
            <div class="col-lg-4">
                <h6>&nbsp;</h6>
                <img src="../App_Themes/Doyingo/images/header-onlinepayment.png" alt="Online Payment" width="234" height="46" />
            </div>
        </div>

        <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
