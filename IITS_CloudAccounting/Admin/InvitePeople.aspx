<%@ Page Title="Invite People" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="InvitePeople.aspx.cs" Inherits="IITS_CloudAccounting.Admin.InvitePeople" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
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
                    <a href="InvitePeople.aspx">Invite People</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Invite People to Work With You</h1>
            <h6>Invite your professional network to use Bill Transact because it will save you time and hassle.</h6>
        </div>

        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-2 control-label" style="padding: 0;">Invitation Types</div>
                        <div class="col-lg-10">
                            <ul style="list-style-type: none;padding-left: 0;">
                                <li><a href="#" class="permission">Request an invoice</a> so you have your invoices in one format on one platform</li>
                                <li><a href="#" class="permission">Request an estimate</a> so you can keep your records straight</li>
                                <li><a href="ContractorMaster.aspx" class="permission">Invite someone to track time</a> so you can keep tabs on their hours</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
