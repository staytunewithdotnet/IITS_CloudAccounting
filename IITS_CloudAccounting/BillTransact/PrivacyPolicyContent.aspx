<%@ Page Title="Privacy Policy Content" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="PrivacyPolicyContent.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PrivacyPolicyContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">CMS Masters
                    </a>
                </li>
                <li>
                    <a href="PrivacyPolicyContent.aspx">Privacy Policy Content</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Privacy Policy Content Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Privacy Policy Content:
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtPrivacyPolicyContent" TabIndex="1" TextMode="MultiLine" CssClass="form-control text" runat="server" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="2" CssClass="btn btn-primary" ValidationGroup="HomeMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="3" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="4" CssClass="btn btn-primary" ValidationGroup="HomeMaster" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfPrivacyPolicy" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>

