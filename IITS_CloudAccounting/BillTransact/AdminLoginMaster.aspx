<%@ Page Title="Admin Login Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLoginMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AdminLoginMaster" %>

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
                    <a href="AdminLoginMaster.aspx">Admin Login Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Admin Login Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">

        <div class="panel-body">
            <div id="companyDropDownDiv" runat="server" class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlCompanyName" CssClass="form-control text" TabIndex="1">
                                <asp:ListItem Value="0" Text="--Select Company--"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            First Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtFirstName" runat="server" Placeholder="FirstName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="First Name Reqiured" ControlToValidate="txtFirstName" ValidationGroup="AdminLoginMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Last Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtLastName" runat="server" Placeholder="LastName" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Last Name Reqiured" ControlToValidate="txtLastName" ValidationGroup="AdminLoginMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            User Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtLoginUserName" runat="server" Placeholder="UserName" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLogiUserName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="User Name Reqiured" ControlToValidate="txtLoginUserName" ValidationGroup="AdminLoginMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control text" Placeholder="Email" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Role:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control text" DataSourceID="sdsRole" DataTextField="RoleName" DataValueField="RoleId" Enabled="false" TabIndex="6"></asp:DropDownList>
                        </div>
                        <asp:SqlDataSource ID="sdsRole" runat="server" ConnectionString="<%$  ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT [RoleName], [RoleId] FROM [vw_aspnet_Roles] where [RoleName]='Admin'"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Password:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control text" Placeholder="Password" TabIndex="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLoginPassword" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Login Password Name Reqiured" ControlToValidate="txtLoginPassword" ValidationGroup="AdminLoginMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Sequrity Question:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtSecurityQue" runat="server" CssClass="form-control text" Text="Whate is your First Name?" Enabled="false" TabIndex="8"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Sequrity Answer:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtSecurityAns" runat="server" CssClass="form-control text" Placeholder="Sequrity Answer" TabIndex="9" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="chkkIsLockedOut" runat="server" visible="false">
                        <div class="col-lg-4 control-label">
                            Locked:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkIsLockedOut" runat="server" TabIndex="10" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Can Login?:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkIsApproved" runat="server" TabIndex="11" />

                        </div>
                    </div>
                    <div id="IsLockedOut" class="form-group" visible="False" runat="server">
                        <div class="col-lg-4 control-label">
                            Account:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="12" CssClass="btn btn-primary" ValidationGroup="AdminLoginMaster" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="13" CssClass="btn btn-default" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="15" CssClass="btn btn-primary" ValidationGroup="AdminLoginMaster" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="16" CssClass="btn btn-default" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="14" CssClass="btn btn-info" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
