<%@ Page Title="Update Company Logo" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="UpdateCompanyLogo.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpdateCompanyLogo" %>

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
                    <a href="UpdateCompanyLogo.aspx">Update Company Logo</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your logo has been saved.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Colors and Logos</h1>
            Make your account look snazzy with custom colors and logos.
        </div>
        <div class="panel-body">
            <div class="col-lg-9">
                <div class="form-horizontal">
                    <%--<div class="form-group">
                        <div class="col-lg-3 control-label">Menu Color</div>
                        <div class="col-lg-9">
                            <input type="text" id="cp1" class="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            Brand the pages with your Company color. What you see will also be visible to your clients when you send them invoices.
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Company Logo</div>
                        <div class="col-lg-9">
                            <asp:FileUpload runat="server" ID="fuLogo" CssClass="form-control text" TabIndex="1" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            We recommend a logo size of 150 x 100 pixels. Logos wider than 150 x 100 pixels will be resized to scale.
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-body">
            <div class="col-lg-9" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="2" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Style="width: 40% !important;" Text="Restore Default Logo" TabIndex="3" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
            </div>
            <div class="col-lg-3 control-label">&nbsp;</div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
