<%@ Page Title="Company Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Company Management
                    </a>
                </li>
                <li>
                    <a href="CompanyMaster.aspx">Company Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Company Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="upCompany">
                <ContentTemplate>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Company User Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtCompanyUserName" CssClass="form-control text" TabIndex="1" AutoPostBack="True" OnTextChanged="txtCompanyUserName_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCompanyUserName" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtCompanyUserName" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Company Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="2" AutoPostBack="True" OnTextChanged="txtCompanyName_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Contact Person Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtContactPersonName" CssClass="form-control text" TabIndex="14"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactPersonName" runat="server" ControlToValidate="txtContactPersonName" ForeColor="red"
                                        SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Contact Person Number:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtContactPersonNumber" CssClass="form-control text" TabIndex="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactPersonNumber" runat="server" ControlToValidate="txtContactPersonNumber" ForeColor="red"
                                        SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Billing Rate:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtBillingRate" CssClass="form-control text"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Bussiness:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlBussiness" TabIndex="3" CssClass="form-control text" DataSourceID="sqldsBussiness" DataTextField="BussinessName" DataValueField="BussinessID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Industry
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlIndustry" TabIndex="4" CssClass="form-control text" DataSourceID="sqldsIndustry" DataTextField="IndustryName" DataValueField="IndustryID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Current Accounting:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCurrentAccount" TabIndex="4" CssClass="form-control text" DataSourceID="sqldsCurrentAccount" DataTextField="CurrentAccountName" DataValueField="CurrentAccountID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Running For:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlRunningFor" TabIndex="3" CssClass="form-control text" DataSourceID="sqldsRunningFrom" DataTextField="RunningFrom" DataValueField="RunningFromID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Currency:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control text" TabIndex="5" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID" />
                                    <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Phone Number:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control text" TabIndex="5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Fax Number:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtFaxNumber" CssClass="form-control text" TabIndex="6"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Email Address:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="7" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="CompanyMaster" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revtxtEmailAddress" runat="server" ErrorMessage="Not Valid Email-Address" Text="*" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CompanyMaster"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Address Street1:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text" TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Address Street2:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Select Country:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="10" AutoPostBack="True" CssClass="form-control text"
                                        DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where (CountryStatus='True')"></asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvCountryMaster" runat="server" ControlToValidate="ddlCountry" ForeColor="red"
                                        ErrorMessage="Select Country" InitialValue="-1" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Select State:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlState" DataSourceID="sqldsState" TabIndex="11" CssClass="form-control text"
                                        DataTextField="StateName" DataValueField="StateID" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE ([CountryID] = @CountryID AND StateStatus='True')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCountry" Name="CountryID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvState1Master" runat="server" ControlToValidate="ddlState" ForeColor="red"
                                        ErrorMessage="Select State" InitialValue="-1" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Select City:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCity" DataSourceID="sqldsCity" TabIndex="12" CssClass="form-control text"
                                        DataTextField="CityName" DataValueField="CityID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE ([StateID] = @StateID AND CityStatus='True')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlState" Name="StateID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvCityMaster" runat="server" ControlToValidate="ddlCity" ForeColor="red"
                                        ErrorMessage="Select City" InitialValue="-1" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Zip Code:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="13"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Company Logo:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:FileUpload runat="server" ID="fuLogo" CssClass="form-control fileupload" TabIndex="16" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Notes:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control text" TabIndex="17" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="page-header">
            <h1>Company Login Details</h1>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4  control-label">
                                    User Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtLoginUserName" AutoPostBack="true" runat="server" Placeholder="UserName" CssClass="form-control" TabIndex="18" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLogiUserName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="User Name Reqiured" ControlToValidate="txtLoginUserName" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4  control-label">
                                    Password:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" Placeholder="Password" TabIndex="19"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLoginPassword" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Login Password Name Reqiured" ControlToValidate="txtLoginPassword" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4  control-label">
                                    Email:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control" Placeholder="Email" Enabled="false" TabIndex="20"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Sequrity Question:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtSecurityQue" runat="server" CssClass="form-control" Text="Whate is your User Name?" Enabled="false" TabIndex="21"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4  control-label">
                                    Sequrity Answer:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtSecurityAns" runat="server" CssClass="form-control" Placeholder="Sequrity Answer" TabIndex="22" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" id="chkkIsLockedOut" runat="server" visible="false">
                                <div class="col-lg-4  control-label">
                                    Locked:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:CheckBox ID="chkIsLockedOut" runat="server" CssClass="checkbox" TabIndex="24" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4  control-label">
                                    Can Login?:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:CheckBox ID="chkIsApproved" runat="server" CssClass="checkbox" TabIndex="24" />
                                </div>
                            </div>
                            <div id="IsLockedOut" class="form-group" visible="False" runat="server">
                                <div class="col-lg-4  control-label">
                                    Account:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" TabIndex="25" Text="Submit" ValidationGroup="CompanyMaster" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" TabIndex="26" />
                <asp:Button ID="btnUnlock" runat="server" Text="Unlock Member" CssClass="btn btn-sm btn-primary" TabIndex="27" Visible="false" OnClick="btnUnlock_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="28" CssClass="btn btn-success" ValidationGroup="CompanyMaster" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="29" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="30" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Username:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCompanyUserName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Contact Person:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCompanyPersonName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Contact Person Number:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCompanyPersonNumber"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Billing Rate:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblBillingRate"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Bussiness:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblBussiness"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Industry:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblIndustry"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Current Accounting:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCurrentAccounting"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Running For:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblRunningFor"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Currency:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCurrency"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Phone Number:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPhoneNumber"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Fax Number:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFaxNumber"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblEmailID"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address Street1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddressStreet1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address Street2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddressStreet2"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Country:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCountry"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblState"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            City:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCity"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Zip Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblZipCode"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Logo:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblCompanyLogo" runat="server" Text="Label" Visible="False"></asp:Label>
                            <asp:Image ID="imgDatabase" runat="server" Height="120px" Visible="False" Width="120px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Notes:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblNotes"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-header">
            <h1>Company Login Details</h1>
        </div>
        <div class="panel-body">
            <div class="col-md-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            User Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblUserNameLogin" runat="server"></asp:Label>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Password:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblPassword" runat="server"></asp:Label>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Sequrity Question:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblSecurityQue" runat="server"></asp:Label>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Sequrity Answer:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblSecurityAns" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Email:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblLoginEmail" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-md-6">
                <div class="form-horizontal">
                    <div class="form-group" id="Div1" runat="server" visible="false">
                        <div class="col-lg-4  control-label">
                            Locked:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkLocked" runat="server" CssClass="checkbox" TabIndex="25" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Can Login?:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox ID="chkApproved" runat="server" CssClass="checkbox" TabIndex="26" />
                            <asp:Label ID="lblCanLogin" runat="server" ForeColor="black"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Create Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Password Change Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblLastPasswordChangeDate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4  control-label">
                            Last Login date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblLastLoginDate" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="22" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="23" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="24" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="25" CssClass="btn btn-primary" OnClick="btnAddCompany_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header" style="margin-top: 0;">
                        <h3 style="margin-top: 0;">Active Companies</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompany" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CompanyID"
                        PageSize="15" OnPageIndexChanging="gvCompany_PageIndexChanging" OnSelectedIndexChanged="gvCompany_SelectedIndexChanged"
                        CssClass="table table-bordered table-hover" DataSourceID="objdsCompanyActive">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Active Companies Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="CompanyID" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                            <asp:BoundField DataField="CompanyUserName" HeaderText="User Name" SortExpression="CompanyUserName" />
                            <asp:BoundField DataField="CompanyPhone" HeaderText="Phone No" SortExpression="CompanyPhone" />
                            <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header">
                        <h3>Deactive Companies</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyDeactive" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" CssClass="table table-bordered table-hover" DataSourceID="objdsCompanyDeactive" DataKeyNames="CompanyID"
                        OnPageIndexChanging="gvCompanyDeactive_PageIndexChanging" OnSelectedIndexChanged="gvCompanyDeactive_SelectedIndexChanged">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Deactive Companies Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="CompanyID" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                            <asp:BoundField DataField="CompanyUserName" HeaderText="User Name" SortExpression="CompanyUserName" />
                            <asp:BoundField DataField="CompanyPhone" HeaderText="Phone No" SortExpression="CompanyPhone" />
                            <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center;">
                        <asp:Button ID="btnAddCompany" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddCompany_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ObjectDataSource ID="objdsCompanyActive" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByActiveCompany" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyMasterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objdsCompanyDeactive" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBydeactiveCompany" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyMasterTableAdapter"></asp:ObjectDataSource>
    <%--<asp:ObjectDataSource ID="objdsCompany" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyMasterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objdsOnlyCompany" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyMasterTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompany" Name="CompanyID" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
    <asp:SqlDataSource runat="server" ID="sqldsBussiness" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS BussinessID, '[choose one]' AS BussinessName UNION SELECT [BussinessID], [BussinessName] FROM [BussinessMaster] WHERE ([BussinessStatus] = @BussinessStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="BussinessStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsRunningFrom" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS RunningFromID, '[choose one]' AS RunningFrom UNION SELECT [RunningFromID], [RunningFrom] FROM [RunningFromMaster] WHERE ([RunningFromStatus] = @RunningFromStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="RunningFromStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsIndustry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT - 1 AS IndustryID, '[choose one]' AS IndustryName UNION SELECT IndustryID, IndustryName FROM IndustryMaster WHERE (IndustryStatus = @IndustryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="IndustryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCurrentAccount" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrentAccountID, '[choose one]' AS CurrentAccountName UNION SELECT [CurrentAccountID], [CurrentAccountName] FROM [CurrentAccountMaster] WHERE ([CurrentAccountStatus] = @CurrentAccountStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CurrentAccountStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfCompany" />
</asp:Content>
