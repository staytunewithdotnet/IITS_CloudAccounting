<%@ Page Title="Company Paypal Setting Master" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true"
    CodeBehind="CompanyIOPayerMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyIOPayerMaster" %>

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
                    <a href="CompanyIOMaster.aspx">Company IO Player Setting Master</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Company IO Setting Master</h1>
        </div>
        <div class="panel-body" style="padding: 15px 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Product ID
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtProductID" MaxLength="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Merchant ID
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtMerchantID" MaxLength="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            MerchantAuth key
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtMerchantAuthkey" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            TransactionType ID
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTransactionTypeID" MaxLength="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            TransactionAuth key
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtTransactionAuthkey" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>

