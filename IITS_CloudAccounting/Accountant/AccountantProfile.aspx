<%@ Page Title="Accountant Profile" Language="C#" MasterPageFile="~/Accountant/AccountantMaster.Master" AutoEventWireup="true" CodeBehind="AccountantProfile.aspx.cs" Inherits="IITS_CloudAccounting.Accountant.AccountantProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="AccountantClients.aspx">Dashboard
                    </a>
                </li>
                <li>
                    <a href="AccountantProfile.aspx">Accountant Profile
                    </a>
                </li>
            </ol>
            <div class="page-header">
                <h1 style="color: #0d83dd; font-size: 40px; font-weight: normal; line-height: 40px; text-align: left;">Edit Your Profile
                </h1>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black;">

        <div class="clearfix"></div>

        <asp:Panel runat="server" ID="pnlRegister">

            <h2 style="font-family: Arial, sans-serif; font-size: 18px; font-weight: normal; line-height: 27px; margin-bottom: 20px; text-align: center;">Account Information </h2>

            <div class="col-lg-1">&nbsp;</div>
            <div class="col-lg-10">
                <div class="form-horizontal" style="margin-bottom: 15px;">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Your Name <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvFirstName" ControlToValidate="txtFirstName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                            <span style="color: #888888">First Name</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLastName" ControlToValidate="txtLastName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                            <span style="color: #888888">Last Name</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Email Address <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="3" Enabled="False"></asp:TextBox>
                            <span style="color: #888888">Your email address is also used to log into your account.</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Phone <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPhone" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="AccountRegister">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Company Name
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Address
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control text" TabIndex="5"></asp:TextBox>
                            <span style="color: #888888">Street</span>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upAddress">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">&nbsp;</div>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="6" AutoPostBack="True" CssClass="form-control text"
                                        DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where (CountryStatus='True')"></asp:SqlDataSource>
                                    <span style="color: #888888">Country</span>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlState" DataSourceID="sqldsState" TabIndex="7" CssClass="form-control text"
                                        DataTextField="StateName" DataValueField="StateID" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE ([CountryID] = @CountryID AND StateStatus='True')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCountry" Name="CountryID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <span style="color: #888888">Province/State</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">&nbsp;</div>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlCity" DataSourceID="sqldsCity" TabIndex="8" CssClass="form-control text"
                                        DataTextField="CityName" DataValueField="CityID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE ([StateID] = @StateID AND CityStatus='True')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlState" Name="StateID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <span style="color: #888888">City</span>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                    <span style="color: #888888">Postal/Zip Code</span>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col-lg-3 control-label">
                        Password
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control text"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                        <span style="color: #888888">New Password</span>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox runat="server" ID="txtConPassword" TextMode="Password" CssClass="form-control text"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ID="cvConPassword" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="Register" ControlToValidate="txtConPassword" ControlToCompare="txtPassword">*</asp:CompareValidator>
                        <span style="color: #888888">Confirm Password</span>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-horizontal" style="border-top: 4px solid #cccccc; border-bottom: 2px solid #cccccc; margin-top: 15px; margin-bottom: 15px;">
                    <h2 style="color: #000; font-family: Arial, sans-serif; font-size: 18px; font-weight: normal; line-height: 27px; margin-bottom: 20px; text-align: center;">Professional Information </h2>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Profession
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtProfession" PlaceHolder="E.g. Accountant, Bookkeeper" CssClass="form-control text" TabIndex="10"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Designation
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDesignation" PlaceHolder="E.g. CPA, CA, CGA" CssClass="form-control text" TabIndex="11"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" style="text-align: center">
                        <div class="col-lg-12">
                            <asp:Button runat="server" ID="btnUpdate" Text="Save Changes" CssClass="btn btn-success" ValidationGroup="AccountRegister" TabIndex="12" OnClick="btnUpdate_Click" />
                            or 
                                <a href="AccountantClients.aspx" class="permission">cancel</a>
                        </div>
                    </div>
                    <div class="form-group" style="text-align: center">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div class="col-lg-1">&nbsp;</div>
        </asp:Panel>

        <div class="clearfix"></div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfEmail" />
    <asp:HiddenField runat="server" ID="hfAccountantID" />
</asp:Content>
