<%@ Page Title="Free Package Settings" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="FreePackageSettings.aspx.cs" Inherits="IITS_CloudAccounting.Admin.FreePackageSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode == 9) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">General Masters
                    </a>
                </li>
                <li>
                    <a href="FreePackageSettings.aspx">Free Package Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Free Package Settings</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Free Days:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFreeDays" CssClass="form-control text" TabIndex="1" onkeypress="return isNumber(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFreeDays" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Days Reqiured" ControlToValidate="txtFreeDays" ValidationGroup="FreePackageSettings">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="22" CssClass="btn btn-primary" ValidationGroup="FreePackageSettings" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="23" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="25" CssClass="btn btn-primary" ValidationGroup="FreePackageSettings" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfFreePackageSettingID" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
</asp:Content>

