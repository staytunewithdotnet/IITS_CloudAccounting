<%@ Page Title="" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IITS_CloudAccounting.Client.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <a href="#">Dashboard
                    </a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Dashboard [<asp:Label runat="server" ID="lblClientInfo"></asp:Label>] </h1>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif; min-height: 110px;">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6 notification-page notification-info" id="welcomeDiv" runat="server" style="min-height: 100px">
            <asp:Label runat="server" ID="lblClientWelcomeMsg"></asp:Label>
        </div>
        <div class="col-lg-3">&nbsp;</div>
        <div class="clearfix"></div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
