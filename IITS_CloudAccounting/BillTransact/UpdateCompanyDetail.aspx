<%@ Page Title="Update Company Detail" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="UpdateCompanyDetail.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpdateCompanyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="UpdateCompanyDetail.aspx">Update Company Detail</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divInfo" runat="server" Visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-info">
                <h3 style="text-transform: capitalize;">For creation of Invoice, Estimate OR Credit you need your Base Currency to be set and also your company address.
                </h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your company profile has been updated.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="panel-body">
                <div class="page-header" style="border-bottom: 5px solid #eee;">
                    <h1>Company Profile</h1>
                    This information is used for invoicing, emails, and more. Make sure it's correct!
                </div>
                <asp:UpdatePanel runat="server" ID="upCompany">
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Company Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="1" AutoPostBack="True" OnTextChanged="txtCompanyName_TextChanged"></asp:TextBox><%----%>
                                        <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Company User Name:
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtCompanyUserName" CssClass="form-control text" TabIndex="2" AutoPostBack="True" OnTextChanged="txtCompanyUserName_TextChanged"></asp:TextBox><%----%>
                                        <asp:RequiredFieldValidator ID="rfvCompanyUserName" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtCompanyUserName" SetFocusOnError="True" ValidationGroup="CompanyMaster">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Company Type
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList runat="server" ID="ddlBussiness" TabIndex="3" CssClass="form-control text" DataSourceID="sqldsBussiness" DataTextField="BussinessName" DataValueField="BussinessID">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Industry
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList runat="server" ID="ddlIndustry" TabIndex="4" CssClass="form-control text" DataSourceID="sqldsIndustry" DataTextField="IndustryName" DataValueField="IndustryID">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Base Currency
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control text" TabIndex="5" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID" />
                                        <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Country
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="6" AutoPostBack="True" CssClass="form-control text"
                                            DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Address
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text" TabIndex="6"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text" TabIndex="7"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlState" DataSourceID="sqldsState" TabIndex="9" CssClass="form-control text"
                                                DataTextField="StateName" DataValueField="StateID" AutoPostBack="True">
                                            </asp:DropDownList>
                                            Province/State
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCity" DataSourceID="sqldsCity" TabIndex="8" CssClass="form-control text"
                                                DataTextField="CityName" DataValueField="CityID">
                                            </asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="10"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                    <div class="col-lg-3 control-label">&nbsp;</div>
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
                                    <div class="col-lg-3 control-label">
                                        Email Address:
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="11" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox><%----%>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="CompanyMaster" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revtxtEmailAddress" runat="server" ErrorMessage="Not Valid Email-Address" Display="Dynamic" Text="*" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CompanyMaster"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-lg-3">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <span style="">This is the reply address for emails sent by Bill Transact to your customers.</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Business Phone
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control text" TabIndex="12"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Fax
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtFaxNumber" CssClass="form-control text" TabIndex="15"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Notes:
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control text" TabIndex="16" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="col-lg-3 control-label">&nbsp;</div>
                <div class="col-lg-9" style="text-align: center;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Save" TabIndex="17" CssClass="btn btn-success" ValidationGroup="CompanyMaster" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="18" CssClass="btn btn-primary" Visible="False" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where (CountryStatus='True')"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT - 1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE ([CountryID] = @CountryID AND StateStatus='True')">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCountry" Name="CountryID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT - 1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE ([StateID] = @StateID AND CityStatus='True')">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlState" Name="StateID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:SqlDataSource runat="server" ID="sqldsBussiness" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS BussinessID, '[choose one]' AS BussinessName UNION SELECT [BussinessID], [BussinessName] FROM [BussinessMaster] WHERE ([BussinessStatus] = @BussinessStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="BussinessStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsIndustry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT - 1 AS IndustryID, '[choose one]' AS IndustryName UNION SELECT IndustryID, IndustryName FROM IndustryMaster WHERE (IndustryStatus = @IndustryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="IndustryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="clearfix"></div>
</asp:Content>
