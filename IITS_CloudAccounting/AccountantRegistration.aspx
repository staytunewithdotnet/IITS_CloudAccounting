<%@ Page Title="Bill Transact Accountant - Registration" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="AccountantRegistration.aspx.cs" Inherits="IITS_CloudAccounting.AccountantRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Accountant Center - Sign Up</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Accountant - Registration</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8 allWrapper">

        <asp:Panel runat="server" ID="pnlRegister">
            <h1 style="font-size: 40px; line-height: 40px; color: #0d83dd; font-weight: normal; margin-top: 20px; margin-bottom: 20px; text-align: center;">Set Up Your Account
            </h1>
            <h2 style="font-size: 18px; font-family: Arial, sans-serif; font-weight: normal; color: #888888; line-height: 27px; margin-bottom: 20px; text-align: center;">Your client's reports are only a minute away</h2>

            <div class="col-lg-1">&nbsp;</div>
            <div class="col-lg-10">
                <div class="form-horizontal" style="border-bottom: 4px solid #cccccc; margin-bottom: 15px;">
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
                </div>
                <div class="form-horizontal" style="border-bottom: 2px solid #cccccc; margin-bottom: 15px;">
                    <h2 style="font-size: 18px; font-family: Arial, sans-serif; font-weight: normal; color: #000; line-height: 27px; margin-bottom: 20px; text-align: center;">Tell Us More About Your Practice</h2>
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
                            <asp:Button runat="server" ID="btnFinish" Text="Get Started" CssClass="btn-success" OnClick="btnFinish_OnClick" ValidationGroup="AccountRegister" TabIndex="12" />
                        </div>
                    </div>
                    <div class="form-group" style="text-align: center">
                        <div class="col-lg-12">
                            By clicking on the button above, you aggree the <a href="#" target="_blank" class="permission">terms of service</a> and <a href="#" class="permission" target="_blank">privacy policy</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-1">&nbsp;</div>
        </asp:Panel>

    </div>
    <div class="col-lg-2">&nbsp;</div>

    <div class="clearfix"></div>
    <asp:HiddenField runat="server" ID="hfEmail" />
</asp:Content>
