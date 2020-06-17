<%@ Page Title="Company Registration" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="CompanyRegistration.aspx.cs" Inherits="IITS_CloudAccounting.CompanyRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <style>
        .form-horizontal .control-label {
            font-family: Verdana;
            font-size: 15px;
        }

        .col-lg-4 {
            padding-left: 0;
            padding-right: 0;
        }

        input[type="text"], input[type="password"], input[type="email"], input[type="url"], input[type="search"], textarea, select, .form-control {
            display: inline-block;
            width: 85%;
            font-weight: normal;
            font-size: 15px;
        }
    </style>
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Company Registration</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Company Registration</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="pricing" class="section mainSection graySection  pricing">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <asp:Panel runat="server" ID="pnlConfirmation" Visible="False">
                <div class="container">
                    <div class="vc_col-sm-2 wpb_column vc_column_container">&nbsp;</div>
                    <div class="vc_col-sm-8 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="wpb_row row">
                                <p style="font-family: Verdana; font-size: x-large; text-align: center; line-height: 1.5;">
                                    Mail is sent to your Email Address.Please verify your email account by, clicking validation link sent in mail.
                                </p>
                                <p style="font-family: Verdana; font-size: larger; text-align: center;">
                                    <a href="Default.aspx">Back To Site</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="vc_col-sm-2 wpb_column vc_column_container">&nbsp;</div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlRegistration">
                <div class="container">
                    <div class="vc_col-sm-6 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="wpb_row row">
                                <div class="form-horizontal">
                                    <asp:UpdatePanel runat="server" ID="upCaptcha">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Company Name*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="1" AutoPostBack="True" OnTextChanged="txtCompanyName_OnTextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCompanyName" ControlToValidate="txtCompanyName" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Contact Person Name*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtContactPerson" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvContactPerson" ControlToValidate="txtContactPerson" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Contact Person Number*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtContactPersonNumber" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvContactPersonNumber" ControlToValidate="txtContactPersonNumber" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Phone Number*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtPhoneNum" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPhoneNum" ControlToValidate="txtPhoneNum" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Country*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control text" TabIndex="5" DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" />
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCountry" SetFocusOnError="True" ControlToValidate="ddlCountry" InitialValue="-1" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Email Address*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" TabIndex="6" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revtxtEmailAddress" runat="server" ErrorMessage="Not Valid Email-Address" Text="*" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CompanyRegistration"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    User Name*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control text" TabIndex="7" AutoPostBack="True" OnTextChanged="txtUserName_OnTextChanged"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtUserName" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Password*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control text" TabIndex="8"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4">&nbsp;</div>
                                                <div class="col-lg-3">
                                                    <asp:Image ID="imgCaptcha" runat="server" Style="margin-bottom: 0; margin-right: 5px;" />
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="BtnRefreshClick" CssClass="btn btn-primary" Style="padding: 8px; font-size: 15px; font-weight: 500;" />
                                                </div>
                                                <div class="col-lg-3">&nbsp;</div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-4 control-label">
                                                    Enter Captcha*:
                                                </div>
                                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvCaptcha" ControlToValidate="txtCaptcha" SetFocusOnError="True" ValidationGroup="CompanyRegistration" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group">
                                        <div class="col-lg-12" style="text-align: center;">
                                            <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" TabIndex="10" ValidationGroup="CompanyRegistration" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="vc_col-sm-1 wpb_column vc_column_container">&nbsp;</div>
                    <div class="vc_col-sm-4 wpb_column vc_column_container">
                        <h6>You want to change the Package Name</h6>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Name :  
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlPackage" CssClass="form-control text" DataSourceID="sqldsPackageName" DataTextField="PackageName" DataValueField="PackageID" OnSelectedIndexChanged="ddlPackage_SelectedIndexChanged" AutoPostBack="True" />
                                    <asp:SqlDataSource runat="server" ID="sqldsPackageName" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [PackageID], [PackageName] FROM [PackageMaster] WHERE ([Status] = @Status)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="wpb_wrapper">
                            <div class="wpb_row row">
                                <div class="widget">
                                    <h3 class="widgetHeader">Package Details</h3>
                                    <ul class="list">
                                        <asp:Repeater runat="server" ID="rpPackageDetail" DataSourceID="sqldsPackage">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("PackageID") %>' runat="server" ID="PackageIDLabel" Visible="False" />
                                                <li>
                                                    <h5 style="display: inline-block;">Package Name : </h5>
                                                    <asp:Label Text='<%# Eval("PackageName") %>' runat="server" ID="PackageNameLabel" Style="font-size: 18px;" />
                                                </li>
                                                <li>
                                                    <h5 style="display: inline-block;">Admin Users : </h5>
                                                    <span>
                                                        <asp:Label Text='<%# Eval("NoOfAdminUsersMin") %>' runat="server" ID="NoOfAdminUsersMinLabel" Style="font-size: 18px;" />
                                                        to
                                                    <asp:Label Text='<%# Eval("NoOfAdminUsersMax") %>' runat="server" ID="NoOfAdminUsersMaxLabel" Style="font-size: 18px;" />
                                                    </span>
                                                </li>

                                                <li>
                                                    <h5 style="display: inline-block;">Staff Users : </h5>
                                                    <span>
                                                        <asp:Label Text='<%# Eval("NoOfStaffUsersMin") %>' runat="server" ID="NoOfStaffUsersMinLabel" Style="font-size: 18px;" />
                                                        to
                                                    <asp:Label Text='<%# Eval("NoOfStaffUsersMax") %>' runat="server" ID="NoOfStaffUsersMaxLabel" Style="font-size: 18px;" />
                                                    </span>
                                                </li>
                                                <li>
                                                    <h5 style="display: inline-block;">Price Per Month : </h5>
                                                    <span style="font-size: 18px;"><%# GetCurrency(Eval("MonthlyPriceCurrencyID").ToString()) %>&nbsp;<%# String.Format("{0:0.00}",Eval("PricePerMonth")) %>&nbsp;</span>
                                                </li>
                                                <li>
                                                    <h5 style="display: inline-block;">Price Per Year : </h5>
                                                    <span style="font-size: 18px;"><%# GetCurrency(Eval("YearlyPriceCurrencyID").ToString()) %>&nbsp;<%# String.Format("{0:0.00}",Eval("PricePerYear")) %>&nbsp;</span>
                                                </li>
                                                <li>
                                                    <h5 style="display: inline-block;">Free Trial Package : </h5>
                                                    <asp:Label Text='<%# bool.Parse(Eval("FreeTrialPackage").ToString())?"Yes":"No" %>' runat="server" ID="FreeTrialPackageLabel" Style="font-size: 18px;" />
                                                </li>
                                                <li id="Li1" runat="server" visible='<%# Eval("FreeTrialPackage") %>'>
                                                    <h5 style="display: inline-block;">No Of Trial Days : </h5>
                                                    <asp:Label Text='<%# Eval("NoOfTrialDays") %>' runat="server" ID="NoOfTrialDaysLabel" Style="font-size: 18px;" />
                                                </li>
                                                <li>
                                                    <h5 style="display: inline-block;">Description : </h5>
                                                    <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" Style="font-size: 15px;" />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="vc_col-sm-1 wpb_column vc_column_container">&nbsp;</div>
                </div>
        </asp:Panel>
        </div>
    </section>
    <asp:SqlDataSource runat="server" ID="sqldsPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT PackageID, PackageName, FreeTrialPackage, NoOfAdminUsersMin, NoOfAdminUsersMax , NoOfStaffUsersMin, NoOfStaffUsersMax, PricePerMonth, MonthlyPriceCurrencyID, PricePerYear, YearlyPriceCurrencyID, Description, NoOfTrialDays, Status FROM PackageMaster WHERE (Status = @Status) AND PackageID = @PackageID">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Status"></asp:Parameter>
            <asp:QueryStringParameter DefaultValue="0" Name="PackageID" Type="Int32" QueryStringField="pId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
