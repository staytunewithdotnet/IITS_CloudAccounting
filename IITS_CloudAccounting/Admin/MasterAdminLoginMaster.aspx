<%@ Page Title="Master Admin Login Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MasterAdminLoginMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.MasterAdminLoginMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">Master Admin Management
                    </a>
                </li>
                <li>
                    <a href="MasterAdminLoginMaster.aspx">Master Admin Login Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Master Admin Login Master</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <asp:UpdatePanel runat="server" ID="upName">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    First Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control text" TabIndex="1"></asp:TextBox><%--AutoPostBack="True" OnTextChanged="txtFirstName_TextChanged"--%>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="First Name Reqiured" ControlToValidate="txtFirstName" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Last Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Last Name Reqiured" ControlToValidate="txtLastName" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    User Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control text" TabIndex="3" AutoPostBack="True" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="User Name Reqiured" ControlToValidate="txtUserName" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Email Reqiured" ControlToValidate="txtEmail" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="refEmail" runat="server" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Input valid email address!" ValidationGroup="LoginMaster">*</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Role:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlRole" Enabled="False" TabIndex="5" CssClass="form-control text" DataSourceID="sqldsRole" DataTextField="RoleName" DataValueField="RoleName" />
                            <asp:SqlDataSource runat="server" ID="sqldsRole" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [RoleName] FROM [vw_aspnet_Roles] WHERE ([LoweredRoleName] = @LoweredRoleName)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="masteradmin" Name="LoweredRoleName" Type="String"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
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
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control text" TabIndex="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Password Reqiured" ControlToValidate="txtPassword" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upQuestionAnswer">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Security Question:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlQuestion" CssClass="form-control text" TabIndex="7" DataSourceID="sqldsQuestion"
                                        DataTextField="Question" DataValueField="SecurityQuestionID" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestion_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsQuestion" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS SecurityQuestionID, '--Select Question--' AS Question UNION SELECT [SecurityQuestionID], [Question] FROM [SecurityQuestionMaster] WHERE ([Status] = @Status)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvQuestion" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Security Question Reqiured" ControlToValidate="ddlQuestion" InitialValue="-1" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Security Answer:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtAnswer" CssClass="form-control text" TabIndex="8"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAnswer" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Security Answer Reqiured" ControlToValidate="txtAnswer" ValidationGroup="LoginMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Can Login:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="9" />
                        </div>
                    </div>
                    <div class="form-group" id="chkkIsLockedOut" runat="server" visible="False">
                        <div class="col-lg-4 control-label">
                            Is Locked:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkIsLockedOut" runat="server" TabIndex="10" />
                        </div>
                    </div>
                    <div id="IsLockedOut" runat="server" visible="False" class="form-group">
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
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="10" CssClass="btn btn-primary" ValidationGroup="LoginMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="12" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUnlock" runat="server" class="btn btn-primary" Text="Unlock" TabIndex="13" Visible="false" OnClick="BtnUnlockClick" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="13" CssClass="btn btn-primary" ValidationGroup="LoginMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="14" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="11" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            First Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Last Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblLastName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            User Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblUserName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Role:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblRole" Text="MasterAdmin" />
                        </div>
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
                            <asp:Label runat="server" ID="lblPassword"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Create Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Can Login:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Locked:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkLocked" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Last Login Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblLastLoginDate" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="15" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="16" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="17" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="18" CssClass="btn btn-primary" OnClick="btnAddMasterAdmin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvMasterAdmin" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="MasterAdminUserID" DataSourceID="sqldsMasterAdmin" OnSelectedIndexChanged="gvMasterAdmin_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvMasterAdmin_PageIndexChanging" CssClass="table table-bordered table-hover">
                        <Columns>
                            <asp:BoundField DataField="MasterAdminUserID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="MasterAdminUserID"></asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"></asp:BoundField>
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"></asp:BoundField>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName"></asp:BoundField>
                            <%--<asp:BoundField DataField="EmailID" HeaderText="EmailID" SortExpression="EmailID"></asp:BoundField>--%>
                            <asp:BoundField DataField="IsApproved" HeaderText="Can Login" SortExpression="IsApproved"></asp:BoundField>
                            <asp:BoundField DataField="IsLockedOut" HeaderText="Locked Out" SortExpression="IsLockedOut"></asp:BoundField>
                            <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login Date" SortExpression="LastLoginDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Logins Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddMasterAdmin" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddMasterAdmin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfMasterAdmin" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfUserName" />
    <asp:SqlDataSource runat="server" ID="sqldsMasterAdmin" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT MasterAdminLoginMaster.MasterAdminUserID, MasterAdminLoginMaster.FirstName, MasterAdminLoginMaster.LastName, MasterAdminLoginMaster.UserName, MasterAdminLoginMaster.EmailID, aspnet_Membership.IsApproved, aspnet_Membership.IsLockedOut, aspnet_Membership.CreateDate, aspnet_Membership.LastLoginDate FROM aspnet_Membership INNER JOIN aspnet_Users ON aspnet_Membership.UserId = aspnet_Users.UserId INNER JOIN MasterAdminLoginMaster ON aspnet_Users.UserName = MasterAdminLoginMaster.UserName ORDER BY MasterAdminUserID"></asp:SqlDataSource>
    <asp:ObjectDataSource runat="server" ID="objdsMasterAdmin" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.MasterAdminLoginMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
