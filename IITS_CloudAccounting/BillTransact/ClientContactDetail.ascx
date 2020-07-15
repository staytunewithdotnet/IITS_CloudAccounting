<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientContactDetail.ascx.cs" Inherits="IITS_CloudAccounting.Admin.ClientContactDetail" %>

<div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-lg-3 control-label">
                Email <span style="color: red">*</span>
            </div>
            <div class="col-lg-9">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" MaxLength="50" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientMaster" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="CompanyClientMaster" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-3 control-label">
                Contact Name
            </div>
            <div class="col-lg-9">
                <div class="col-lg-6" style="padding: 0;">
                    <asp:TextBox runat="server" ID="txtFirstName" PlaceHolder="First Name" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
                </div>
                <div class="col-lg-6" style="padding-left: 0">
                    <asp:TextBox runat="server" ID="txtLastName" PlaceHolder="Last Name" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="col-lg-4">
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-lg-3 control-label">Home Phone</div>
            <div class="col-lg-9">
                <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control text"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-3 control-label">Mobile</div>
            <div class="col-lg-9">
                <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control text"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div class="col-lg-3 control-label">
    Login Credentials
</div>
<div class="col-lg-9" style="margin-bottom: 15px;">
    <asp:CheckBox runat="server" ID="chkAssignUsername" Text="Assign Username and Password" onchange="showUserDiv()" />
    <br />
    <br />
    <div id="usernameDiv" style="display: none">
        <div class="col-lg-4" style="padding-left: 0;">
            <asp:TextBox runat="server" ID="txtUsername" PlaceHolder="User Name" AutoPostBack="True" OnTextChanged="txtUsername_OnTextChanged" CssClass="form-control text"></asp:TextBox>
        </div>
        <div class="col-lg-4" style="padding-left: 0;">
            <asp:TextBox runat="server" ID="txtPassword" PlaceHolder="New Password" CssClass="form-control text"></asp:TextBox>
        </div>
        <div class="col-lg-4" style="padding-left: 0;">
            <asp:TextBox runat="server" ID="txtConfPassword" PlaceHolder="Confirm Password" CssClass="form-control text"></asp:TextBox>
        </div>
        <br />
        <br />
        <br />
        <div class="col-lg-12" style="padding-left: 0;">
            <div style="padding: 10px 20px 10px 10px; background-color: #fff4d6;">
                <asp:CheckBox runat="server" ID="chkSend" Text="Send login information" />

                <asp:Label runat="server" ID="lblInvitation"></asp:Label>
                <br />
                If no password is entered, a random password will be created and sent with each invitation.
            </div>
        </div>
    </div>
</div>
<asp:LinkButton runat="server" ID="lnkAddContact" Text="Add another contact" OnClick="lnkAddContact_Click"></asp:LinkButton>
<asp:LinkButton runat="server" ID="lnkRemoveContact" Text="Remove this contact"></asp:LinkButton>
<div id="extraContact" runat="server">
                            
                        </div>
<asp:HiddenField runat="server" ID="hfCompanyID"/>