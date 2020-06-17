<%@ Page Title="Client Profile" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="ClientProfile.aspx.cs" Inherits="IITS_CloudAccounting.Client.ClientProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: -100px;">
        <div class="col-sm-12">
            &nbsp;
        </div>
    </div>

    <div id="divUpdate" runat="server" visible="False" style="margin-top: 10px;">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your profile has been updated.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black;">

        <div class="panel-body" style="padding-bottom: 50px;">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>Update Your Profile</h1>
            </div>
            <asp:UpdatePanel runat="server" ID="upBoth">
                <ContentTemplate>
                    <div class="col-lg-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">&nbsp;</div>
                                <div class="col-lg-9">
                                    <h3>Personal Contact Information</h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label" style="text-align: left;">
                                    Email <span style="color: red">*</span>
                                </div>
                                <div class="col-lg-9">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" Style="width: 96% !important;" MaxLength="50" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientMaster" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="CompanyClientMaster" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label" style="text-align: left;">
                                    Contact Name
                                </div>
                                <div class="col-lg-9">
                                    <div class="col-lg-6" style="padding: 0;">
                                        <asp:TextBox runat="server" ID="txtFirstName" PlaceHolder="First Name" onkeypress="return isLetter(event)" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6" style="padding-left: 0">
                                        <asp:TextBox runat="server" ID="txtLastName" PlaceHolder="Last Name" onkeypress="return isLetter(event)" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
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
                                    <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Mobile</div>
                                <div class="col-lg-9">
                                    <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

                    <div class="col-lg-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">&nbsp;</div>
                                <div class="col-lg-9">
                                    <h3>Login Information</h3>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-horizontal form-group">
                        <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                            Username
                        </div>
                        <div class="col-lg-3" style="padding-left: 0;">
                            <asp:TextBox runat="server" ID="txtUsername" PlaceHolder="User Name" AutoPostBack="True" OnTextChanged="txtUsername_OnTextChanged" CssClass="form-control text"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUsernameAdd" Visible="False"></asp:Label>
                        </div>
                    </div>

                    <div class="clearfix" style="margin-bottom: 15px;"></div>

                    <div class="form-horizontal form-group">
                        <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                            Password
                        </div>
                        <div class="col-lg-3" style="padding-left: 0; margin-bottom: 25px;">
                            <asp:TextBox runat="server" ID="txtPassword" PlaceHolder="Current Password" CssClass="form-control text"></asp:TextBox>
                            Current Password
                            <asp:Label runat="server" ID="lblPasswordAdd" Visible="False"></asp:Label>
                        </div>
                        <div class="col-lg-3" style="padding-left: 0; margin-bottom: 25px;">
                            <asp:TextBox runat="server" ID="txtNewPassword" PlaceHolder="New Password" CssClass="form-control text"></asp:TextBox>
                            New Password
                        </div>
                        <div class="col-lg-3" style="padding-left: 0; margin-bottom: 25px;">
                            <asp:TextBox runat="server" ID="txtConfPassword" PlaceHolder="Confirm Password" CssClass="form-control text"></asp:TextBox>
                            Confirm Password
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:Panel runat="server" ID="pnlAddClient">
                <asp:UpdatePanel runat="server" ID="upCompany">
                    <ContentTemplate>
                        <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3>Organization Information</h3>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                                        Business Phone
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtBussinessPhone" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                                        Fax
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtFax" CssClass="form-control text"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                                        Country
                                    </div>
                                    <div class="col-lg-6" style="padding-left: 0;">
                                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control text" DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">
                                        Address
                                    </div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control text" DataSourceID="sqldsState" DataTextField="StateName" DataValueField="StateID" AutoPostBack="True" />
                                            Province/State 
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control text" DataSourceID="sqldsCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-6" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%; padding: 0;">
                                        Secondary Country
                                    </div>
                                    <div class="col-lg-6" style="padding-left: 0;">
                                        <asp:DropDownList runat="server" ID="ddlCountrySecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryCountry" DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%; padding: 0;">
                                        Secondary Address
                                    </div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtAddress1Secondary" CssClass="form-control text"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtAddress2Secondary" CssClass="form-control text"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9" style="padding-left: 0;">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlStateSecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryState" DataTextField="StateName" DataValueField="StateID" AutoPostBack="True" />
                                            Province/State
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCitySecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCodeSecondary" CssClass="form-control text"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                    <div class="col-lg-2 control-label" style="text-align: left; width: 19%;">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-6" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label"></div>
                                    <div class="col-lg-9">
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center">
                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" TabIndex="16" OnClick="btnSave_Click" />
            </div>
        </div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE (([StateStatus] = @StateStatus) AND ([CountryID] = @CountryID))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="StateStatus" Type="Boolean"></asp:Parameter>
            <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" DefaultValue="0" Name="CountryID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([StateID] = @StateID) AND ([CityStatus] = @CityStatus))">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlState" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryState" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE (([StateStatus] = @StateStatus) AND ([CountryID] = @CountryID))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="StateStatus" Type="Boolean"></asp:Parameter>
            <asp:ControlParameter ControlID="ddlCountrySecondary" PropertyName="SelectedValue" DefaultValue="0" Name="CountryID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([StateID] = @StateID) AND ([CityStatus] = @CityStatus))">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlStateSecondary" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
