<%@ Page Title="Update Admin Profile" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="UpdateAdminProfile.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpdateAdminProfile" %>

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
                    <a href="UpdateAdminProfile.aspx">Update Admin Profile</a>
                </li>
            </ol>
        </div>
    </div>
    
    <div id="divUpdate" runat="server" Visible="False">
    <div class="col-lg-3">&nbsp;</div>
    <div class="col-lg-6">
        <div class="notification-page notification-success">
            <h3>Your profile has been updated.</h3>
            <p class="hide"></p>
        </div>
    </div>
    <div class="col-lg-3">&nbsp;</div></div>
    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Administrator Profile</h1>
            This is the user account you log in with.
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-3 control-label" style="margin-bottom: 0;">
                            Email<span style="color: red">*</span>
                        </div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            This is the email address we use to contact you.
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label" style="margin-bottom: 0;">
                            Name<span style="color: red">*</span>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            First Name
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                            Last Name
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">Billing Rate</div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtBillingRate" CssClass="form-control text" TabIndex="4" Text="0.00" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                            Rate per hour
                        </div>
                        <div class="col-lg-3"></div>
                    </div>

                    <div class="form-group" style="padding-left: 0;">
                        <div class="col-lg-3 control-label">Home Phone</div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control text" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" style="padding-left: 0;">
                        <div class="col-lg-3 control-label">Username</div>
                        <div class="col-lg-6">
                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control text" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" style="padding-left: 0; margin-bottom: 0;">
                        <div class="col-lg-3 control-label">Change Password</div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCurrentPassword" CssClass="form-control text" TabIndex="6"></asp:TextBox>
                            Current Password
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control text" TabIndex="7"></asp:TextBox>
                            New Password
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtConfPassword" CssClass="form-control text" TabIndex="8"></asp:TextBox>
                            Confirm Password
                        </div>
                    </div>
                    <div class="form-group" style="padding-left: 0;">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-3"></div>
                        <div class="col-lg-3"></div>
                        <div class="col-lg-3"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-3 control-label">&nbsp;</div>
                    <div class="col-lg-6" style="text-align: center">
                        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" Text="Save" TabIndex="9" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
