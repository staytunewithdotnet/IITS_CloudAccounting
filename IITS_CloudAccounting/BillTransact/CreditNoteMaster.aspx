<%@ Page Title="Credit Note" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="CreditNoteMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CreditNoteMaster" %>

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
                    <a href="#">Invoice Management
                    </a>
                </li>
                <li>
                    <a href="CreditNoteMaster.aspx">Credit Note Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Credit has been created.</h3>
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
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Credit has been updated.</h3>
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
                <h1>New Credit</h1>
            </div>
            <div class="panel-body">

                <asp:UpdatePanel runat="server" ID="upClient" ChildrenAsTriggers="True">
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
                                    <div class="col-lg-3 control-label">
                                        Client<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text dropdownFirst" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
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
                                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                            <asp:DropDownList runat="server" ID="ddlCurrency" Enabled="False" CssClass="form-control text" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged" />
                                            <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] + ' (' + [CurrencySymbol] + ')' AS CurrencyName FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">
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

                        <div class="col-lg-5" style="padding-left: 10px; padding-right: 0;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-4 control-label" style="padding-left: 0; padding-right: 0;">
                                        Credit Number<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtCreditNum" CssClass="form-control text" TabIndex="2"></asp:TextBox><%--onkeypress="return isNumber(event)"--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label" style="padding-left: 0; padding-right: 0;">
                                        Date Of Issue<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtDateOfIssue" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateOfIssue" TargetControlID="txtDateOfIssue" Animated="True" />
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
                                        <asp:Label runat="server" ID="lblSubTotal" Text="0.00"></asp:Label>
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
                                        Credit Total (<asp:Label runat="server" ID="lblCurrencyCode" Text="NGN"></asp:Label>)
                                    </div>
                                    <div class="col-lg-6" style="text-align: right; font-weight: bold; font-family: Verdana,sans-serif; font-size: 14px; color: #000; padding-left: 0; padding-right: 10px;">
                                        <asp:Label runat="server" ID="lblCurrencySymbol1" Text="₦" /><asp:Label runat="server" ID="lblCreditTotal" Text="0.00"></asp:Label>
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
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpCreditTerms" PopupControlID="pnlCreditTerms" TargetControlID="lnkSetTerms" CancelControlID="lnkClose" BackgroundCssClass="modelBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlCreditTerms" runat="server" Width="750px" align="center" Style="display: none; padding: 22px 30px 25px; border: 5px solid #CCCCCC; border-radius: 15px; position: fixed; z-index: 100001; background-color: white;">
                            <div class="panel-body" style="border-color: #CCCCCC;">
                                <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                                    <h2 style="margin-top: 0;">Set Default Credit Terms </h2>
                                    <p>
                                        The default terms you set here will be <span style="background-color: #ff9; text-transform: lowercase">re-used on future Credits</span>.
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
                    <div class="col-lg-2">&nbsp;</div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnSaveDraft" Text="Save as Draft" CssClass="btn-lg btn-info" OnClick="btnSaveDraft_Click" CommandArgument="created" />
                        <div class="example">
                            Save this credit without notifying your client. You can still notify them manually afterwards.
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnSendByMail" Text="Send by Mail" CssClass="btn-lg btn-success" OnClick="btnSaveDraft_Click" CommandArgument="sent" />
                        <div class="example" runat="server" id="saveMailDiv">
                            Email this credit to your client.
                        </div>
                    </div>
                    <div class="col-lg-2">&nbsp;</div>
                </div>
                <div style="margin-top: 15px; text-align: center;" id="updatebtn" runat="server">
                    <div class="col-lg-2">&nbsp;</div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnUpdateDraft" Text="Save" CssClass="btn-lg btn-info" OnClick="btnUpdateDraft_Click" CommandArgument="created" />
                        <div class="example">
                            Save this credit without notifying your client. You can still notify them manually afterwards.
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnUpdateByMail" Text="Send by Mail" CssClass="btn-lg btn-success" OnClick="btnUpdateDraft_Click" CommandArgument="sent" />
                        <div class="example" runat="server" id="updateMailDiv">
                            Email this credit to your client.
                        </div>
                    </div>
                    <div class="col-lg-2">&nbsp;</div>
                </div>
            </div>
        </asp:Panel>

        <script type="text/javascript">
            function printDiv() {
                var lblInvoiceNum = document.getElementById('<%=lblCreditNumHead.ClientID%>').innerText;
                var divToPrint = document.getElementById("printDiv");
                var popupWin = window.open('', '_blank', '');//width=800,height=800,location=no
                popupWin.document.open();
                var str = '<title>Invoice_' + lblInvoiceNum + '</title>';
                str += '<link type="text/css" rel="stylesheet" href="../App_Themes/Doyingo/freshbook_styles.css" /><link href="../App_Themes/Doyingo/freshbook_print.css" rel="stylesheet" media="print" /><link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" media="all" /><link href="../App_Themes/Doyingo/css/font-awesome.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/simple-line-icons.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/menu_cornerbox.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/waves.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/switchery.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/style.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/component.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/weather-icons.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/MetroJs.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/toastr.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/white.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/custom.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/select2.min.css" rel="stylesheet" type="text/css" media="all" /><link href="../App_Themes/Doyingo/css/otherstyles.css" rel="stylesheet" media="all" />';
                popupWin.document.write('<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head>' + str + '</head><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                popupWin.document.close();
            }
        </script>

        <asp:Panel runat="server" ID="pnlView">

            <div id="printNone" style="">
                <asp:Label runat="server" ID="lblCreditNumHead" CssClass="printNone" Style="float: left; margin-bottom: 20px; font-family: Arial,Helvetica,sans-serif; font-size: 24px; color: #000; line-height: normal;"></asp:Label>
                <div style="float: right; margin-bottom: 20px;">
                    <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer;" class="btn-danger">Generate PDF</a>
                    <input type="button" value="Print" id="btnPrint" style="padding: 7px; display: inline-block;" class="btn-warning printNone" onclick=" printDiv(); " />
                    <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="btn-info" Style="padding: 7px;" OnClick="btnEdit_Click" Visible="False" />
                    <asp:Button runat="server" ID="btnSendEmail" Text="Send Mail" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnSendEmail_Click" />
                </div>
            </div>

            <div id="printDiv" class="invoice-container rounded-container" style="background-color: #fff !important; color: #000 !important;">
                <div class="" id="divStatus" runat="server">
                </div>

                <div class="invheader">

                    <div class="invheader-upper">
                        <div class="invheader-address-account">
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label><br />
                            <asp:Label runat="server" ID="lblCompanyAddress"></asp:Label>
                        </div>

                        <div class="invheader-logo-container">
                            <div class="invheader-logo">
                                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/blank.gif" Style="height: 90%; width: 90%;" />
                                <br />
                                <asp:Label runat="server" ID="lblCompanyLogoText"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="invheader-lower">
                        <div class="invheader-address-client">
                            <asp:Label runat="server" ID="lblClientOrganizationName"></asp:Label><br />
                            <asp:Label runat="server" ID="lblClientFullName"></asp:Label><br />
                            <asp:Label runat="server" ID="lblClientAddress"></asp:Label>
                        </div>

                        <div class="invheader-invoicedetails">
                            <table cellspacing="0">

                                <tr>
                                    <th>
                                        <asp:Label runat="server" ID="lblCreditTitle" Text="Credit #"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblCreditNum"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:Label runat="server" ID="lblCreditTitleDate" Text="Credit Date"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblCreditDate"></asp:Label></td>
                                </tr>
                                <tr class="invheader-invoicedetails-balance">
                                    <th>
                                        <div>
                                            Credit Balance
                                        </div>
                                    </th>
                                    <td>
                                        <div>
                                            <asp:Label runat="server" ID="lblCurSymbolView1" Text="₦"></asp:Label>
                                            <asp:Label runat="server" ID="lblCreditAmount"></asp:Label>
                                            <asp:Label runat="server" ID="lblCurCodeView1" Text="NGN"></asp:Label>
                                        </div>
                                    </td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </div>

                <div class="invbody">

                    <asp:GridView runat="server" ID="gvTaskView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="CreditTaskDetailID" DataSourceID="objdsTaskView" OnRowDataBound="gvTaskView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="TaskID" HeaderText="Task" SortExpression="TaskID">
                                <ItemStyle Width="19%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="TaskDesc" HeaderText="Time Entry Notes" SortExpression="TaskDesc">
                                <ItemStyle Width="34%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" DataFormatString="{0:0.00}">
                                <ItemStyle Width="14%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" DataFormatString="{0:0.00}">
                                <ItemStyle Width="14%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax1" HeaderText="Tax1" SortExpression="Tax1">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax2" HeaderText="Tax2" SortExpression="Tax2">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Line Total" SortExpression="Total" DataFormatString="{0:0.00}">
                                <ItemStyle Width="34%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CreditTaskDetailID" HeaderText="CreditTaskDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="CreditTaskDetailID"></asp:BoundField>
                            <asp:BoundField DataField="CreditID" HeaderText="CreditID" SortExpression="CreditID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView runat="server" ID="gvItemView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="CreditItemDetailID" DataSourceID="objdsItemView" OnRowDataBound="gvItemView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ItemID" HeaderText="Item" SortExpression="ItemID">
                                <ItemStyle Width="19%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemDesc" HeaderText="Description" SortExpression="ItemDesc">
                                <ItemStyle Width="34%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" SortExpression="UnitCost" DataFormatString="{0:0.00}">
                                <ItemStyle Width="14%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" DataFormatString="{0:0.00}">
                                <ItemStyle Width="14%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax1" HeaderText="Tax1" SortExpression="Tax1">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax2" HeaderText="Tax2" SortExpression="Tax2">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Line Total" SortExpression="Total" DataFormatString="{0:0.00}">
                                <ItemStyle Width="34%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CreditItemDetailID" HeaderText="CreditItemDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="CreditItemDetailID"></asp:BoundField>
                            <asp:BoundField DataField="CreditID" HeaderText="CreditID" SortExpression="CreditID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:ObjectDataSource runat="server" ID="objdsItemView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCreditID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditItemDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCreditID" PropertyName="Value" DefaultValue="1" Name="CreditID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsTaskView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCreditID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditTaskDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCreditID" PropertyName="Value" DefaultValue="1" Name="CreditID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <table class="invbody-summary" cellspacing="0">

                        <tr>
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Subtotal</th>
                            <td style="width: 120px;">
                                <asp:Label runat="server" ID="lblSubTotalView" Text="0.00"></asp:Label></td>
                        </tr>

                        <tr style="display: none">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Added Tax Amount</th>
                            <td style="width: 120px;">+<asp:Label runat="server" ID="lblAddedTaxesView" Text="0.00"></asp:Label></td>
                        </tr>

                        <tr>
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">
                                <div id="divTaxView" runat="server"></div>
                            </th>
                            <td style="width: 120px;">
                                <div id="divTaxValueView" runat="server"></div>
                            </td>
                        </tr>

                        <tr class="invbody-summary-total">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">
                                <div>
                                    <strong>Credit Total
                                    </strong>
                                </div>
                            </th>
                            <td style="width: 120px;">
                                <div>
                                    <strong>
                                        <asp:Label runat="server" ID="lblCurSymbolView2" Text="₦"></asp:Label>
                                        <asp:Label runat="server" ID="lblCreditTotalView"></asp:Label>
                                        <asp:Label runat="server" ID="lblCurCodeView2" Text="NGN"></asp:Label>
                                    </strong>
                                </div>
                            </td>
                        </tr>

                    </table>

                    <div class="clearfix"></div>
                    <div style="width: 80%; margin-bottom: 18px;">
                        <h4>Terms</h4>
                        <asp:Label runat="server" ID="lblTerms"></asp:Label>
                    </div>
                    <div style="width: 80%; margin-bottom: 18px;">
                        <h4>Notes</h4>
                        <asp:Label runat="server" ID="lblNotes"></asp:Label>
                    </div>
                    <div class="invoice-brand" id="brandingDiv" runat="server">
                        This Credit was sent using <a href="#" target="_blank" class="none">
                            <img style="margin-bottom: -1px; width: 56px; height: 23px;" alt="Bill Transact" src="../App_Themes/Doyingo/images/logo.jpg" />
                        </a>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>

            <div class="rounded-container peel-shadows" style="color: black;">
                <h3 style="margin: 15px;">Credit Autobiography</h3>
                <asp:GridView runat="server" ID="gvCreditHistory" Width="100%" DataSourceID="objdsCreditHistory" AutoGenerateColumns="False"
                    DataKeyNames="CreditHistoryDetailID" CssClass="gridTableView hi table table-striped table-responsive" GridLines="None"
                    OnRowDataBound="gvCreditHistory_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="CreditHistoryDetailID" HeaderText="CreditHistoryDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="CreditHistoryDetailID"></asp:BoundField>
                        <%--<asp:BoundField DataField="CreditID" HeaderText="CreditID" SortExpression="CreditID"></asp:BoundField>--%>
                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice Number" SortExpression="InvoiceNo"></asp:BoundField>
                        <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" SortExpression="InvoiceDate"></asp:BoundField>
                        <asp:BoundField DataField="UsedAmount" HeaderText="Used Amount" SortExpression="UsedAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:BoundField DataField="UsedNotes" HeaderText="Notes" SortExpression="UsedNotes"></asp:BoundField>
                        <asp:BoundField DataField="UsedDate" HeaderText="Date" SortExpression="UsedDate"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="width: 100%; text-align: center;">
                            No Autobiography Found For This Credit
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="objdsCreditHistory" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCreditID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditHistoryDetailTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCreditID" PropertyName="Value" DefaultValue="0" Name="CreditID" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Credits</h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Credit" OnClick="btnAdd_Click" Style="float: right;" />
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
                                        Credit #
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtCreditNumberSearch" CssClass="searchText"></asp:TextBox>
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
                                        Status
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlStatusSearch" CssClass="searchText">
                                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="created">created</asp:ListItem>
                                            <asp:ListItem Value="sent">sent</asp:ListItem>
                                            <asp:ListItem Value="viewed">viewed</asp:ListItem>
                                            <asp:ListItem Value="commented">commented</asp:ListItem>
                                            <asp:ListItem Value="replied">replied</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Date Range
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtCreditDateFrom" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtCreditDateFrom" />
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtCreditDateTo" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtCreditDateTo" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Credit Total
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtCreditTotalFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtCreditTotalTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
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
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete Forever" OnClick="btnDelete_Click" />
                        <asp:Button runat="server" ID="btnCopy" CssClass="btn-warning" Text="Copy" OnClick="btnCopy_Click" />
                        <asp:Button runat="server" ID="btnEmail" Text="Email" CssClass="btn-danger" OnClick="btnEmail_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvCredit" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="CreditID"
                        AllowSorting="True" OnSorting="gvCredit_Sorting" OnSelectedIndexChanged="gvCredit_SelectedIndexChanged"
                        OnPageIndexChanging="gvCredit_PageIndexChanging" GridLines="None" OnRowDataBound="gvCredit_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("CreditID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit" SortExpression="CreditNumber">
                                <ItemTemplate>
                                    <a href='<%# "CreditNoteMaster.aspx?cmd=view&ID=" + Eval("CreditID")%>'>
                                        <%# Eval("CreditNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="CreditNumber" HeaderText="Credit" SortExpression="CreditNumber"></asp:BoundField>--%>
                            <asp:BoundField DataField="ClientID" HeaderText="Client Name" SortExpression="ClientID"></asp:BoundField>
                            <asp:BoundField DataField="CreditDate" HeaderText="Date" SortExpression="CreditDate"></asp:BoundField>
                            <asp:BoundField DataField="CreditRemaingTotal" HeaderText="Remaing" SortExpression="CreditRemaingTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <%--<asp:BoundField DataField="CreditTotal" HeaderText="Total" SortExpression="CreditTotal" DataFormatString="{0:0.00}"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCreditTotal" Text='<%# GetCurrency(Eval("CurrencyID").ToString()) + " " + Eval("CreditTotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreditStatus" HeaderText="Status" SortExpression="CreditStatus" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible='<%# (decimal.Parse(Eval("CreditTotal").ToString())) == (decimal.Parse(Eval("CreditRemaingTotal").ToString())) %>'>
                                    <a href='<%# "CreditNoteMaster.aspx?cmd=add&ID=" + Eval("CreditID") %>'>edit</a>
                                    </asp:Label>
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

                    <asp:ObjectDataSource runat="server" ID="objdsCredit" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCreditSearchCompany" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlStatusSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Status" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemDescSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemDesc" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditTotalFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditTotalFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditTotalTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditTotalTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsCreditStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCreditSearchCompanyStaff" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlStatusSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Status" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemDescSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemDesc" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditTotalFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditTotalFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtCreditTotalTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="CreditTotalTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfCreditID" />
</asp:Content>
