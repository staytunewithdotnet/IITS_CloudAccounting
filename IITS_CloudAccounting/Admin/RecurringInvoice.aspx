﻿<%@ Page Title="Recurring Invoice" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="RecurringInvoice.aspx.cs" Inherits="IITS_CloudAccounting.Admin.RecurringInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var i = document.getElementById("invoiceDiv");
            i.style.display = 'block';
        });
    </script>
    <style>
        .dropdownFirst > option:nth-child(2) {
            background-color: #ff9;
        }
    </style>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoice
                    </a>
                </li>
                <li>
                    <a href="RecurringInvoice.aspx">Recurring Invoice</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Recurring Profile has been created.</h3>
                
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>Click to <a href="InvoiceMasterNew.aspx" class="permission">create an invoice</a>.
                    </li>
                    <li>Click to <a href="EstimateMaster.aspx" class="permission">create an estimate</a>.
                    </li>
                    <li>Click to <a href="RecurringInvoice.aspx" class="permission">create a recurring profile</a>.
                    </li>
                    <li>Click to <a href="CreditNoteMaster.aspx" class="permission">create a credit</a>.
                    </li>
                    <li>Click to <a href="ProjectMaster.aspx" class="permission">create a project</a>.
                    </li>
                </ul><p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Recurring Profile has been updated.</h3>
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>Click to <a href="InvoiceMasterNew.aspx" class="permission">create an invoice</a>.
                    </li>
                    <li>Click to <a href="EstimateMaster.aspx" class="permission">create an estimate</a>.
                    </li>
                    <li>Click to <a href="RecurringInvoice.aspx" class="permission">create a recurring profile</a>.
                    </li>
                    <li>Click to <a href="CreditNoteMaster.aspx" class="permission">create a credit</a>.
                    </li>
                    <li>Click to <a href="ProjectMaster.aspx" class="permission">create a project</a>.
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>
                    <asp:Label runat="server" ID="lblAddUpdate"></asp:Label>
                </h1>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server" ID="upRecuuring">
                    <ContentTemplate>

                        <div class="col-lg-7 bookcase" id="clienDetails" runat="server" visible="False">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:Label runat="server" ID="lblBoxClientFor" Text="" Style="font-family: Arial,Helvetica,sans-serif; font-size: 18px; color: #000; line-height: 24px; font-weight: bold;"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6">
                                        Email<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        Contact Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtBoxClientEmail" AutoPostBack="True" OnTextChanged="txtBoxClientEmail_OnTextChanged" CssClass="form-control text boxTextbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtBoxClientEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientBox" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="CompanyClientBox" ControlToValidate="txtBoxClientEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <asp:TextBox runat="server" ID="txtBoxClientFirstName" CssClass="form-control text boxTextbox" onkeypress="return isLetter(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <asp:TextBox runat="server" ID="txtBoxClientLastName" CssClass="form-control text boxTextbox" onkeypress="return isLetter(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">&nbsp;</div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">First Name</span>
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">Last Name</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6">
                                        Organization Name
                                        <asp:TextBox runat="server" ID="txtBoxClientOrganization" CssClass="form-control text boxTextbox"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">
                                        Country
                                        <asp:DropDownList runat="server" ID="ddlBoxClientCountry" CssClass="form-control text boxTextbox" AutoPostBack="True" DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        Address
                                        <asp:TextBox runat="server" ID="txtBoxClientAddress1" CssClass="form-control text boxTextbox"></asp:TextBox>
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">Street 1</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" ID="txtBoxClientAddress2" CssClass="form-control text boxTextbox"></asp:TextBox>
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">Street 2</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="padding-right: 0;">
                                        <asp:DropDownList runat="server" ID="ddlBoxClientState" CssClass="form-control text boxTextbox" AutoPostBack="True" DataSourceID="sqldsState" DataTextField="StateName" DataValueField="StateID" />
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <asp:DropDownList runat="server" ID="ddlBoxClientCity" CssClass="form-control text boxTextbox" DataSourceID="sqldsCity" DataTextField="CityName" DataValueField="CityID" />
                                    </div>
                                    <div class="col-lg-4" style="padding-left: 0;">
                                        <asp:TextBox runat="server" ID="txtBoxClientZipcode" CssClass="form-control text boxTextbox"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-5" style="padding-right: 0;">
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">Province/State</span>
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">City</span>
                                    </div>
                                    <div class="col-lg-4" style="padding-left: 0;">
                                        <span style="color: #74885f; font-size: 11px; line-height: 16px; margin-top: 5px;">Postal/Zip Code</span>
                                    </div>
                                    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE (([StateStatus] = @StateStatus) AND ([CountryID] = @CountryID))">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="StateStatus" Type="Boolean"></asp:Parameter>
                                            <asp:ControlParameter ControlID="ddlBoxClientCountry" PropertyName="SelectedValue" DefaultValue="0" Name="CountryID" Type="Int32"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([StateID] = @StateID) AND ([CityStatus] = @CityStatus))">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlBoxClientState" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
                                            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:CheckBox runat="server" ID="chkBoxClientChange" Checked="True" Enabled="False" Text="Apply these changes to client's profile." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6">
                                        Industry
                                        <asp:DropDownList runat="server" ID="ddlIndustry" CssClass="form-control text boxTextbox" DataSourceID="sqldsIndustry" DataTextField="IndustryName" DataValueField="IndustryID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsIndustry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS IndustryID, '[choose one]' AS IndustryName UNION SELECT [IndustryID], [IndustryName] FROM [IndustryMaster] WHERE ([IndustryStatus] = @IndustryStatus)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="IndustryStatus" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                    <div class="col-lg-6">
                                        Company Size
                                        <asp:DropDownList runat="server" ID="ddlCompanySize" CssClass="form-control text boxTextbox">
                                            <asp:ListItem Value="-1">[choose one]</asp:ListItem>
                                            <asp:ListItem Value="1">1-10 employees</asp:ListItem>
                                            <asp:ListItem Value="2">11-100 employees</asp:ListItem>
                                            <asp:ListItem Value="3">101-500 employees</asp:ListItem>
                                            <asp:ListItem Value="4">Over 500 employees</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="holder">
                                    <div class="col-lg-7" style="padding-right: 0;">
                                        <asp:Label runat="server" ID="lblBoxClientInfo" Text="" Style="font-size: 12px; font-family: Verdana,sans-serif; color: black;"></asp:Label>
                                    </div>
                                    <div class="col-lg-5" style="padding-left: 0;">
                                        <asp:Button runat="server" ID="btnBoxSave" CssClass="btn-sm btn-success" Text="Save Client" OnClick="btnBoxSave_OnClick" ValidationGroup="CompanyClientBox" />
                                        <asp:Button runat="server" ID="btnBoxUpdate" CssClass="btn-sm btn-success" Text="Update" OnClick="btnBoxUpdate_OnClick" ValidationGroup="CompanyClientBox" />
                                        or
                                        <asp:LinkButton runat="server" ID="lnkBoxClose" Text="cancel" CssClass="permission" OnClick="lnkBoxClose_OnClick"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-7" id="normalDetails" runat="server">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtSchedule" PlaceHolder="Schedule" CssClass="form-control text"></asp:TextBox>
                                        Start Date
                                        <asp:RequiredFieldValidator runat="server" ID="rfvSchedule" ForeColor="red" Display="Dynamic" ControlToValidate="txtSchedule" ValidationGroup="RecurringInvoice" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceSchedule" TargetControlID="txtSchedule" Animated="True" />
                                    </div>
                                    <div class="col-lg-4">
                                        <%--Style="display: none;" CssClass="js-states --%>
                                        <asp:DropDownList runat="server" ID="ddlHowOften" CssClass="form-control text" DataSourceID="sqldsFrequency" DataTextField="FrequencyName" DataValueField="FrequencyID">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsFrequency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS FrequencyID, ' ' AS FrequencyName UNION SELECT [FrequencyID], [FrequencyName] FROM [FrequencyMaster]"></asp:SqlDataSource>
                                        How Often
                                        <asp:RequiredFieldValidator runat="server" ID="rfvHowoften" InitialValue="-" ForeColor="red" Display="Dynamic" ControlToValidate="ddlHowOften" ValidationGroup="RecurringInvoice" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtHowMany" PlaceHolder="How Many" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                        How Many
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-2 control-label">
                                        Client<span style="color: red">*</span>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvClient" InitialValue="-2" ForeColor="red" Display="Dynamic" ControlToValidate="ddlClient" ValidationGroup="RecurringInvoice" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text dropdownFirst" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-2' AS ID,'- select a client -' AS Name UNION SELECT '-1' AS ID,'[new client]' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource runat="server" ID="sqldsClientStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-2' AS ID,'- select a client -' AS Name UNION SELECT '-1' AS ID,'[new client]' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID AND [CompanyClientID] IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                                <div id="clientAddress" runat="server" visible="False">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">
                                            Currency
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:DropDownList runat="server" ID="ddlCurrency" Enabled="False" CssClass="form-control text" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged" />
                                            <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] + ' (' + [CurrencySymbol] + ')' AS CurrencyName FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding-top: 0;">
                                            Send By
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:CheckBox runat="server" ID="chkEmail" Text="Email" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkSnailMail" Text="Snail Mail" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding-top: 0;">
                                            Address
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 control-label" style="padding-top: 0;">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:LinkButton runat="server" ID="lblEditAddress" Text="Edit Address" CssClass="permission" OnClick="lblEditAddress_OnClick"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-5">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        PO Number:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtPONumber" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-lg-4 control-label">
                                        Discount:
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control text" Text="0.00" TabIndex="5" OnTextChanged="txtDiscount_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12" style="padding-left: 0; padding-right: 0">
                            <asp:GridView runat="server" ID="gvTask" Width="100%" GridLines="None" CssClass="gridTable table table-striped table-responsive"
                                AutoGenerateColumns="False" OnRowDeleting="gvTask_OnRowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Task">
                                        <ItemStyle Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlTask" DataSourceID="sqldsTask" AutoPostBack="True" OnSelectedIndexChanged="ddlTask_OnSelectedIndexChanged" DataTextField="TaskName" DataValueField="TaskID" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time Entry Notes">
                                        <ItemStyle Width="30%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesc" /><%-- TextMode="MultiLine"--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtRate" Text="0.00" AutoPostBack="True" OnTextChanged="txtRate_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hours">
                                        <ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtHours" Text="0" AutoPostBack="True" OnTextChanged="txtHours_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlTaskTax1" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" AutoPostBack="True" OnSelectedIndexChanged="ddlTaskTax1_OnSelectedIndexChanged" />
                                            <asp:Label runat="server" ID="lblTaskTax1" Style="display: none;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlTaskTax2" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" AutoPostBack="True" OnSelectedIndexChanged="ddlTaskTax2_OnSelectedIndexChanged" />
                                            <asp:Label runat="server" ID="lblTaskTax2" Style="display: none;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line Total">
                                        <ItemStyle Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTaskLineTotal" Style="text-align: right" Text="0.00"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="../App_Themes/Doyingo/images/delete.png" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="panel-danger" style="text-align: center; width: 100%;">
                                        No Records Found
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>

                            <asp:GridView runat="server" ID="gvItem" Width="100%" GridLines="None" CssClass="gridTable table table-striped table-responsive"
                                AutoGenerateColumns="False" OnRowDeleting="gvItem_OnRowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemStyle Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlItem" DataSourceID="sqldsItem" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_OnSelectedIndexChanged" DataTextField="ItemName" DataValueField="ItemID" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemStyle Width="29%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtItemDesc"></asp:TextBox><%-- TextMode="MultiLine"--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Cost">
                                        <ItemStyle Width="11%" HorizontalAlign="Right"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtUnitCost" Text="0.00" AutoPostBack="True" OnTextChanged="txtUnitCost_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemStyle Width="10%" HorizontalAlign="Right"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtQty" Text="0" AutoPostBack="True" OnTextChanged="txtQty_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlItemTax1" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" AutoPostBack="True" OnSelectedIndexChanged="ddlItemTax1_OnSelectedIndexChanged" />
                                            <asp:Label runat="server" ID="lblItemTax1" Style="display: none;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlItemTax2" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" AutoPostBack="True" OnSelectedIndexChanged="ddlItemTax2_OnSelectedIndexChanged" />
                                            <asp:Label runat="server" ID="lblItemTax2" Style="display: none;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line Total">
                                        <ItemStyle Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblItemLineTotal" Style="text-align: right" Text="0.00"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="../App_Themes/Doyingo/images/delete.png" />
                                </Columns>
                            </asp:GridView>

                            <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID,'' AS TaskName UNION SELECT TaskID,TaskName FROM TaskMaster WHERE CompanyID = @CompanyID AND Active = 1">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource runat="server" ID="sqldsItem" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS ItemID, '' AS ItemName UNION SELECT ItemID, ItemName FROM ItemMaster WHERE CompanyID = @CompanyID AND Active = 1">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource runat="server" ID="sqldsTax" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaxID, '' AS TaxName UNION SELECT TaxID, TaxName FROM TaxMaster WHERE (CompanyID = @CompanyID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>

                        <div class="col-lg-7">
                            <div class="btn-group" role="group">
                                <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #999; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                    Add Line<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <asp:LinkButton runat="server" ID="lnkAddTask" Text="Add Time Entry" OnClick="lnkAddTask_OnClick" />
                                    </li>
                                    <li>
                                        <asp:LinkButton runat="server" ID="lnkAddItem" Text="Add Item" OnClick="lnkAddItem_OnClick" />
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div class="col-lg-5" style="padding-right: 0; padding-left: 0;">
                            <div class="form-horizontal" style="border: 1px solid lightgray; padding: 05px 10px 0 15px;">
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Subtotal
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Label runat="server" ID="lblCurrencySymbol2" Text="₦" /><asp:Label runat="server" ID="lblSubTotal" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Discount
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        &nbsp;-&nbsp;<asp:Label runat="server" ID="lblDiscount" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        <%--Added Tax Amount--%>
                                        <div runat="server" id="divTax"></div>
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <%--&nbsp;+&nbsp;--%><asp:Label runat="server" ID="lblAddedTaxes" Text="0.00" Visible="False"></asp:Label>
                                        <div runat="server" id="divTaxValue"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal" style="border: 1px solid lightgray; padding: 5px 10px 0 15px; font-weight: bold; background-color: lightblue;">
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 15px; line-height: 18px; color: #000;">
                                        Recurring Total (<asp:Label runat="server" ID="lblCurrencyCode" Text="NGN"></asp:Label>)
                                    </div>
                                    <div class="col-lg-6" style="text-align: right; font-weight: bold; font-family: Verdana,sans-serif; font-size: 14px; color: #000; padding-left: 0; padding-right: 10px;">
                                        <asp:Label runat="server" ID="lblCurrencySymbol1" Text="₦" /><asp:Label runat="server" ID="lblBalance" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group" style="margin: 15px -15px;">
                                    <div class="col-lg-12">
                                        <asp:CheckBox runat="server" ID="chkProrate" Text="Prorate first invoice for" />
                                        <asp:TextBox runat="server" ID="txtProrateDay" CssClass="form-control text" Style="width: 20% !important" onkeypress="return isNumber(event)"></asp:TextBox>days.
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-7" style="margin-top: 15px;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        Terms (<asp:LinkButton runat="server" ID="lnkSetTerms" CssClass="permission">Set Default Terms</asp:LinkButton>)
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" ID="txtTerms" CssClass="form-control text" TabIndex="6" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5" style="margin-top: 15px;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        Notes Visible to Client
                                    </div>
                                    <div class="col-lg-12">
                                        <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control text" TabIndex="6" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInvoiceTerms" PopupControlID="pnlInvoiceTerms" TargetControlID="lnkSetTerms" CancelControlID="lnkClose" BackgroundCssClass="modelBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlInvoiceTerms" runat="server" Width="750px" align="center" Style="display: none; padding: 22px 30px 25px; border: 5px solid #CCCCCC; border-radius: 15px; position: fixed; z-index: 100001; background-color: white;">
                            <div class="panel-body" style="border-color: #CCCCCC;">
                                <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                                    <h2 style="margin-top: 0;">Set Default Invoice Terms </h2>
                                    <p>
                                        The default terms you set here will be <span style="background-color: #ff9; text-transform: lowercase">re-used on future Invoices</span>.
                                    </p>
                                </div>
                                <div class="x_button" role="button">
                                    <asp:LinkButton runat="server" ID="lnkClose" CssClass="close-button-blue" title="close dialog">close dialog</asp:LinkButton>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-lg-2 control-label" style="padding: 0; color: black; font-family: Verdana,sans-serif; font-size: 12px;">
                                                Default Terms
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:TextBox runat="server" ID="txtDefaultTerms" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body" style="padding: 0 15px;">
                                <div class="col-lg-12" style="text-align: center">
                                    <asp:Button runat="server" ID="btnSaveTerms" CssClass="btn-success" Text="save" OnClick="btnSaveTerms_Click" Style="padding: 5px 10px;" />
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div style="margin-top: 15px; text-align: center;" id="savebtn" runat="server">
                    <div class="col-lg-12" style="text-align: center">
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn-lg btn-info" OnClick="btnSave_Click" ValidationGroup="RecurringInvoice" />
                    </div>
                </div>
                <div style="margin-top: 15px; text-align: center;" id="updatebtn" runat="server">
                    <div class="col-lg-2">&nbsp;</div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnUpdate" Text="Save" CssClass="btn-lg btn-success" OnClick="btnUpdate_Click" ValidationGroup="RecurringInvoice" />
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnStopRecurring" Text="Stop Recurring" CssClass="btn-lg btn-success" />
                    </div>
                    <div class="col-lg-2">&nbsp;</div>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn-lg btn-success" Text="New Recurring Profile" OnClick="btnAdd_Click" Style="float: right; margin-bottom: 0;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div class="col-lg-12" id="divSearch" style="padding: 10px; display: none; background-color: #f6f6f6; margin-bottom: 10px;">
                        <div id="closeSearch" class="close-button" style="cursor: pointer; background-color: blanchedalmond; padding: 10px; border-radius: 10px; overflow: visible;"></div>
                        <h3 style="margin: 10px auto 20px; text-align: center;">Search Box</h3>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Profile #
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtProfileNumberSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Client Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtClientNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Item Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtItemNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Item Desc
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtItemDescSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        PO Number
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtPONumberSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Notes
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtNotesSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Frequency
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlFrequencySearch" CssClass="searchText" DataSourceID="sqldsFrequencySearch" DataTextField="FrequencyName" DataValueField="FrequencyID" />
                                        <asp:SqlDataSource runat="server" ID="sqldsFrequencySearch" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS FrequencyID, ' ' AS FrequencyName UNION SELECT [FrequencyID], [FrequencyName] FROM [FrequencyMaster]"></asp:SqlDataSource>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Amount
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtAmountFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtAmountTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Currency
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlCurrencySearch" CssClass="searchText" DataSourceID="sqldsCurrencySearch" DataTextField="CurrencyName" DataValueField="CurrencyID" />
                                        <asp:SqlDataSource runat="server" ID="sqldsCurrencySearch" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] + ' (' + [CurrencySymbol] + ')' AS CurrencyName FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn-default" Style="padding: 5px; width: 100px" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button runat="server" ID="btnReset" CssClass="btn-default" Text="Reset" Style="padding: 5px; width: 100px" OnClientClick="ClearAllControls(); return false;" />
                        </div>
                    </div>
                    <div style="background-color: lightgray; padding: 10px;">
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button runat="server" ID="btnCopy" CssClass="btn-warning" Text="Copy" OnClick="btnCopy_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvRecurring" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="RecurringID"
                        AllowSorting="True" OnSorting="gvRecurring_Sorting" OnSelectedIndexChanged="gvRecurring_SelectedIndexChanged"
                        OnPageIndexChanging="gvRecurring_PageIndexChanging" GridLines="None" OnRowDataBound="gvRecurring_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("RecurringID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RecurringNumber" HeaderText="Profile ID" SortExpression="RecurringNumber"></asp:BoundField>
                            <asp:BoundField DataField="ClientID" HeaderText="Client Name" SortExpression="ClientID"></asp:BoundField>
                            <asp:BoundField DataField="NextDate" HeaderText="Last Sent" SortExpression="NextDate"></asp:BoundField>
                            <asp:BoundField DataField="HowOften" HeaderText="Frequency" SortExpression="HowOften"></asp:BoundField>
                            <asp:BoundField DataField="RecurringTotal" HeaderText="Amount" SortExpression="RecurringTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField HeaderText="Remaining">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblRemaining" Text='<%# Eval("RemainingInvoice") + " of " + Eval("HowManyInvoice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='<%# "RecurringInvoice.aspx?cmd=add&ID=" + Eval("RecurringID") %>'>edit</a>
                                    <asp:Label runat="server" ID="lbl" CssClass='<%# SetTrueFalse(Eval("RemainingInvoice").ToString(),Eval("HowManyInvoice").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#0DB9B7" Font-Names="Verdana" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <div style="background-color: white; border-bottom: 1px solid lightgray; text-align: right;">
                        <a id="activeTag" runat="server" href="RecurringInvoice.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="RecurringInvoice.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="RecurringInvoice.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>

                    <asp:ObjectDataSource runat="server" ID="objdsRecurring" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.RecurringMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtProfileNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="RecurringNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtPONumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="PONumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemDescSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemDesc" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TotalFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TotalTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlFrequencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Frequency" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsRecurringStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyStaffIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.RecurringMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtProfileNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="RecurringNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtPONumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="PONumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemDescSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemDesc" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TotalFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TotalTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlFrequencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Frequency" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:HiddenField runat="server" ID="hfCompanyClientID" />
    <asp:HiddenField runat="server" ID="hfRecurringID" />
    <asp:HiddenField runat="server" ID="hfRecurringNum" />
</asp:Content>
