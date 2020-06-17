<%@ Page Title="Basecamp Classic" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="BasecampClassic.aspx.cs" Inherits="IITS_CloudAccounting.Admin.BasecampClassic" %>

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
                    <a href="BasecampClassic.aspx">Basecamp Classic</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Basecamp Classic</h1>
        </div>
        <div class="col-lg-8" style="padding-left: 0">
            <h5>Basecamp is a web-based project management application made by Chicago-based 37signals. Basecamp is the smarter, easier way to collaborate on your projects.</h5>

            <h5><b>Note: </b>The Basecamp integration only works with Basecamp Classic. Those using the current version of Basecamp will not be able to use this feature in Bill Transact.</h5>
        </div>
        <div class="col-lg-4">
            <a href="#" target="_blank">
                <img src="../App_Themes/Doyingo/images/header-basecamp.gif" width="140" height="100" alt="Basecamp" />
            </a>
        </div>


        <div class="clearfix"></div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
</asp:Content>
