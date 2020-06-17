<%@ Page Title="Uh Oh!" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="NoPermission.aspx.cs" Inherits="IITS_CloudAccounting.Admin.NoPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: -45px;">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-home"></i>
                    <a href="#">Dashboard
                    </a>
                </li>
                <li>
                    <a href="NoPermission.aspx">No Permission</a>
                </li>
            </ol>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Uh Oh</h1>
        </div>
        <div class="panel-body" style="padding: 15px 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: justify;">
                            <span style="font-size: 12px;">Looks like you don't have permission to access what you're looking for. Try contacting the account Administrator to change the account permissions settings. If you're in a bigger pickle, you can reach out to Bill Transact Support at 514-447-7064 or <a href="mailto:support@billtransact.com" class="permission">support@billtransact.com</a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
