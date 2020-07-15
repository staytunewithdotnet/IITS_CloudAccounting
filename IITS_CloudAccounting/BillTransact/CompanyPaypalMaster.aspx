<%@ Page Title="Company Paypal Setting Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="CompanyPaypalMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyPaypalMaster" %>

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
                    <a href="CompanyPaypalMaster.aspx">Company Paypal Setting Master</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Company Paypal Setting Master</h1>
        </div>
        <div class="panel-body" style="padding: 15px 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            PayPal Email
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtPaypal" MaxLength="50"></asp:TextBox>
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
    <asp:HiddenField runat="server" ID="hfPaypalID" />
</asp:Content>

