<%@ Page Title="Invoice Master" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="InvoiceMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.InvoiceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/onlyInvoice.css" rel="stylesheet" />
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var i = document.getElementById("invoiceDiv");
            i.style.display = 'block';
        });
    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoices
                    </a>
                </li>
                <li>
                    <a href="InvoiceMaster.aspx">Invoice Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your invoice has been created.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your invoice has been updated.</h3>
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
                <h1>New Invoice</h1>
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
                                        Invoice Number<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtInvoiceNum" CssClass="form-control text" TabIndex="2"></asp:TextBox><%--onkeypress="return isNumber(event)"--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label" style="padding-left: 0; padding-right: 0;">
                                        Date Of Issue<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtDateOfIssue" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateOfIssue" TargetControlID="txtDateOfIssue" Animated="True" Format="MM/dd/yyyy" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label" style="padding-left: 0; padding-right: 0;">
                                        PO Number
                                    </div>
                                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                        <asp:TextBox runat="server" ID="txtPONumber" CssClass="form-control text" TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-4 control-label" style="padding-left: 0; padding-right: 0;">
                                        Discount
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtDiscount" Text="0.00" CssClass="form-control text" AutoPostBack="True" OnTextChanged="txtDiscount_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="width: 79% !important" TabIndex="5"></asp:TextBox>%
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12" style="padding-left: 0; padding-right: 0" id="clientInvoices" runat="server" visible="False">
                            <h3 style="margin: 10px auto; color: black;">Paid Invoice</h3>
                            <asp:GridView runat="server" ID="gvPaidInvoice" Width="100%" AutoGenerateColumns="False" DataKeyNames="InvoiceID"
                                DataSourceID="sqldsPaidInvoice" CssClass="gridTableView hi table table-striped table-responsive" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" ReadOnly="True" InsertVisible="False" SortExpression="InvoiceID" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" SortExpression="InvoiceNumber">
                                        <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate" DataFormatString="{0:MM/dd/yyyy}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceStatus" HeaderText="Status" SortExpression="InvoiceStatus">
                                        <ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Outstanding">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblOutstandingPaid" Text="0.00"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="PaidToDate" HeaderText="Outstanding" SortExpression="PaidToDate" DataFormatString="{0:0.00}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="panel-danger" style="text-align: center; width: 100%;">
                                        No Paid Invoice Found
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>

                            <h3 style="margin: 10px auto; color: black;">Due Invoice</h3>
                            <asp:GridView runat="server" ID="gvDueInvoice" Width="100%" AutoGenerateColumns="False" DataKeyNames="InvoiceID"
                                DataSourceID="sqldsDueInvoice" CssClass="gridTableView hi table table-striped table-responsive" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" ReadOnly="True" InsertVisible="False" SortExpression="InvoiceID" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" SortExpression="InvoiceNumber">
                                        <ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate" DataFormatString="{0:MM/dd/yyyy}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceStatus" HeaderText="Status" SortExpression="InvoiceStatus">
                                        <ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Outstanding">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblOutstandingDue" Text='<%# decimal.Parse(Eval("InvoiceTotal").ToString()) - decimal.Parse(Eval("PaidToDate").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="PaidToDate" HeaderText="Outstanding" SortExpression="PaidToDate" DataFormatString="{0:0.00}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}">
                                        <ItemStyle Width="10%" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="panel-danger" style="text-align: center; width: 100%;">
                                        No Due Invoice Found
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>

                            <asp:SqlDataSource runat="server" ID="sqldsPaidInvoice" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM InvoiceMaster WHERE CompanyID = @CompanyID AND ClientID = @ClientID AND InvoiceTotal = PaidToDate AND Active = 1 AND (Archived = 0 OR Deleted = 0)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource runat="server" ID="sqldsDueInvoice" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM InvoiceMaster WHERE CompanyID = @CompanyID AND ClientID = @ClientID AND InvoiceTotal > PaidToDate AND Active = 1 AND (Archived = 0 OR Deleted = 0)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
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
                                            <asp:TextBox runat="server" ID="txtRate" Text="0" AutoPostBack="True" OnTextChanged="txtRate_OnTextChanged" onkeypress="return decimalValue(this,event);" Style="text-align: right;"></asp:TextBox>
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
                                <div class="form-group" style="margin-bottom: 0;">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Subtotal
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Label runat="server" ID="lblSubTotal" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-bottom: 0;">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Discount
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        &nbsp;-&nbsp;<asp:Label runat="server" ID="lblDiscount" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Added Tax Amount
                                        <div runat="server" id="divTax"></div>
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        &nbsp;+&nbsp;<asp:Label runat="server" ID="lblAddedTaxes" Text="0.00"></asp:Label>
                                        <div runat="server" id="divTaxValue"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal" style="border: 1px solid lightgray; padding: 5px 10px 0 15px;">
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Invoice Total
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Label runat="server" ID="lblCurrencySymbol2" Text="₦" /><asp:Label runat="server" ID="lblInvoiceTotal" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 13px; line-height: 18px; color: #000;">
                                        Paid to Date
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Label runat="server" ID="lblPaidToDate" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal" style="border: 1px solid lightgray; padding: 5px 10px 0 15px; font-weight: bold; background-color: lightblue;">
                                <div class="form-group">
                                    <div class="col-lg-6" style="padding-right: 0; font-family: Verdana,sans-serif; font-size: 15px; line-height: 18px; color: #000;">
                                        Balance (<asp:Label runat="server" ID="lblCurrencyCode" Text="NGN"></asp:Label>)
                                    </div>
                                    <div class="col-lg-6" style="text-align: right; font-weight: bold; font-family: Verdana,sans-serif; font-size: 14px; color: #000; padding-left: 0; padding-right: 10px;">
                                        <asp:Label runat="server" ID="lblCurrencySymbol1" Text="₦" /><asp:Label runat="server" ID="lblBalance" Text="0.00"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal" id="creditInvoice" runat="server" visible="False">
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 15px;">
                                        <asp:CheckBox runat="server" ID="chkCreditInvoice" Text=" Apply credit of balance as payment" Style="background-color: #ff9;" />
                                        <br />
                                        (Balance Remaing in Credit:&nbsp;
                                        <asp:Label runat="server" ID="lblCreditRemaing"></asp:Label>)
                                        <asp:GridView runat="server" ID="gvCredit" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsCredit">
                                            <Columns>
                                                <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID"></asp:BoundField>
                                                <asp:BoundField DataField="CreditRemaingTotal" HeaderText="CreditRemaingTotal" ReadOnly="True" SortExpression="CreditRemaingTotal"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource runat="server" ID="sqldsCredit" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT ClientID,SUM(CreditRemaingTotal) AS CreditRemaingTotal FROM CreditMaster WHERE ClientID = @ClientID AND CompanyID = @CompanyID GROUP BY ClientID ">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
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
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnSaveDraft" Text="Save as Draft" CssClass="btn-lg btn-info" OnClick="btnSaveDraft_Click" CommandArgument="draft" />
                        <div class="example">
                            Save this invoice as a draft. Your client will not be able to view this invoice until it is sent.
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnSendByMail" Text="Send by Mail" CssClass="btn-lg btn-success" OnClick="btnSaveDraft_Click" CommandArgument="sent" />
                        <div class="example">
                            Email this invoice to your client.
                        </div>
                    </div>
                    <div class="col-lg-4" style="display: none">
                        <asp:Button runat="server" ID="btnSendBySnailMail" Text="Send by Snail Mail" CssClass="btn-lg btn-success" OnClick="btnSaveDraft_Click" CommandArgument="sent by snail mail" />
                        <div class="example">
                            Send a hard copy of this invoice to your client via <a href="#" target="_blank">snail mail</a>.
                            <br />
                            <br />
                            You have 2 stamps.
                        <a href="#" id="link-infoGmail">Buy stamps</a><br />
                            or <a href="#" id="link-sampleGroundMail">send a free sample</a>.
                        </div>
                    </div>
                </div>
                <div style="margin-top: 15px; text-align: center;" id="updatebtn" runat="server">
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnUpdateDraft" Text="Save" CssClass="btn-lg btn-info" OnClick="btnUpdateDraft_Click" CommandArgument="draft" />
                        <div class="example">
                            Save updates made to this invoice.
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <asp:Button runat="server" ID="btnUpdateByMail" Text="Send by Mail" CssClass="btn-lg btn-success" OnClick="btnUpdateDraft_Click" CommandArgument="sent" />
                        <div class="example">
                            Email this invoice to your client.
                        </div>
                    </div>
                    <div class="col-lg-4" style="display: none">
                        <asp:Button runat="server" ID="btnUpdateBySnailMail" Text="Send by Snail Mail" CssClass="btn-lg btn-success" OnClick="btnUpdateDraft_Click" CommandArgument="sent by snail mail" />
                        <div class="example">
                            Send a hard copy of this invoice to your client via <a href="#" target="_blank">snail mail</a>.
                            <br />
                            <br />
                            You have 2 stamps.
                        <a href="#" id="A1">Buy stamps</a><br />
                            or <a href="#" id="A2">send a free sample</a>.
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <%--<script type="text/javascript">

            function printDiv() {
                var divContents = $('#printDiv').html();
                var title = $('#<%= lblInvoiceNumHead.ClientID %>').text();
                console.log(title);
                var printWindow = window.print();
                printWindow.document.write('<html><head><title>');
                printWindow.document.write(title + '</title>');
                printWindow.document.write('</head><body >');
                printWindow.document.write(divContents);
                printWindow.document.write('</body></html>');
                printWindow.document.close();
                printWindow.print();
            }
        </script>--%>

        <script type="text/javascript">
            function printDiv() {
                var lblInvoiceNum = document.getElementById('<%=lblInvoiceNum.ClientID%>').innerText;
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
                <asp:Label runat="server" ID="lblInvoiceNumHead" CssClass="printNone" Style="float: left; margin-bottom: 20px; font-family: Arial,Helvetica,sans-serif; font-size: 24px; color: #000; line-height: normal;"></asp:Label>
                <div style="float: right; margin-bottom: 20px;">
                    <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer;" class="btn-danger">Generate PDF</a>
                    <input type="button" value="Print" id="btnPrint" style="padding: 7px;" class="btn-warning printNone" onclick="printDiv();" />
                    <asp:Button runat="server" ID="btnPayment" Text="Enter Payment" CssClass="btn-success" Style="padding: 7px;" OnClick="btnPayment_Click" />
                    <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="btn-info" Style="padding: 7px;" OnClick="btnEdit_Click" Visible="False" />
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
                                <img src="../App_Themes/Doyingo/images/blank.gif" alt="" width="150" height="55" is_custom="" /><br />
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
                                        <asp:Label runat="server" ID="lblInvoiceTitle" Text="Invoice #"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblInvoiceNum"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:Label runat="server" ID="lblInvoiceTitleDate" Text="Invoice Date"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblInvoiceDate"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>PO #
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblPONumber"></asp:Label></td>
                                </tr>
                                <tr class="invheader-invoicedetails-balance">
                                    <th>
                                        <div>
                                            Amount Due
                                        </div>
                                    </th>
                                    <td>
                                        <div>
                                            <asp:Label runat="server" ID="lblCurSymbolView1" Text="₦"></asp:Label>
                                            <asp:Label runat="server" ID="lblInvoiceAmount"></asp:Label>
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
                        AutoGenerateColumns="False" DataKeyNames="InvoiceTaskDetailID" DataSourceID="objdsTaskView" OnRowDataBound="gvTaskView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="TaskID" HeaderText="Task" SortExpression="TaskID">
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="TaskDesc" HeaderText="Time Entry Notes" SortExpression="TaskDesc">
                                <ItemStyle Width="30%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" DataFormatString="{0:0.00}">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" DataFormatString="{0:0.00}">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax1" HeaderText="Tax1" SortExpression="Tax1">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Tax2" HeaderText="Tax2" SortExpression="Tax2">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Line Total" SortExpression="Total" DataFormatString="{0:0.00}">
                                <ItemStyle Width="30%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="InvoiceTaskDetailID" HeaderText="InvoiceTaskDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="InvoiceTaskDetailID"></asp:BoundField>
                            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" SortExpression="InvoiceID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView runat="server" ID="gvItemView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="InvoiceItemDetailID" DataSourceID="objdsItemView" OnRowDataBound="gvItemView_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ItemID" HeaderText="Item" SortExpression="ItemID">
                                <ItemStyle Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemDesc" HeaderText="Description" SortExpression="ItemDesc">
                                <ItemStyle Width="30%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" SortExpression="UnitCost" DataFormatString="{0:0.00}">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" DataFormatString="{0:0.00}">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="TaxID1" HeaderText="Tax1" SortExpression="TaxID1">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="TaxID2" HeaderText="Tax2" SortExpression="TaxID2">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Line Total" SortExpression="Total" DataFormatString="{0:0.00}">
                                <ItemStyle Width="30%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="InvoiceItemDetailID" HeaderText="InvoiceItemDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="InvoiceItemDetailID"></asp:BoundField>
                            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" SortExpression="InvoiceID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:ObjectDataSource runat="server" ID="objdsItemView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByInvoiceID" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceItemDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="1" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsTaskView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByInvoiceID" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceTaskDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="1" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <table class="invbody-summary" cellspacing="0">

                        <tr class="invbody-summary-subtotal">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;"><strong>Subtotal
                            </strong></th>
                            <td style="width: 120px;"><strong>
                                <asp:Label runat="server" ID="lblSubTotalView"></asp:Label>
                            </strong></td>
                        </tr>

                        <tr>
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Discount -
                                    <asp:Label runat="server" ID="lblDiscout"></asp:Label>%
                            </th>
                            <td style="width: 120px;">-<asp:Label runat="server" ID="lblDiscountAmt"></asp:Label></td>
                        </tr>

                        <tr>
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Added Tax Amount</th>
                            <td style="width: 120px;">+<asp:Label runat="server" ID="lblAddedTaxesView" Text="0.00"></asp:Label></td>
                        </tr>

                        <tr>
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;" class="border"><strong>Total
                            </strong></th>
                            <td style="width: 120px;" class="border"><strong>
                                <asp:Label runat="server" ID="lblInvoiceTotalView"></asp:Label>
                            </strong></td>
                        </tr>
                        <tr class="invbody-summary-paid">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Amount Paid
                            </th>
                            <td style="width: 120px;">-<asp:Label runat="server" ID="lblPaidToDateView"></asp:Label></td>
                        </tr>

                        <tr class="invbody-summary-total">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">
                                <div>
                                    <strong>Amount Due
                                    </strong>
                                </div>
                            </th>
                            <td style="width: 120px;">
                                <div>
                                    <strong>
                                        <asp:Label runat="server" ID="lblCurSymbolView2" Text="₦"></asp:Label>
                                        <asp:Label runat="server" ID="lblAmountDue"></asp:Label>
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
                        This invoice was sent using <a href="#" target="_blank" class="none">
                            <img style="margin-bottom: -1px; width: 56px; height: 23px" alt="Bill Transact" src="../App_Themes/Doyingo/images/logo.jpg" />
                        </a>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>

            <div class="rounded-container peel-shadows" style="color: black;">
                <h3 style="margin: 15px;">Invoice Payment Autobiography</h3>
                <asp:GridView runat="server" ID="gvInvoiceHistory" Width="100%" AutoGenerateColumns="False"
                    CssClass="gridTableView hi table table-striped table-responsive" GridLines="None" DataSourceID="objdsPaymentHistory" DataKeyNames="PaymentID">
                    <Columns>
                        <asp:BoundField DataField="PaymentID" HeaderText="PaymentID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="PaymentID"></asp:BoundField>
                        <%--<asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID"></asp:BoundField>
                        <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" SortExpression="InvoiceID"></asp:BoundField>--%>
                        <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method"></asp:BoundField>
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                        <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="width: 100%; text-align: center;">
                            No Payment Autobiography Found For This Invoice
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="objdsPaymentHistory" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByInvoiceID" TypeName="DABL.DAL.CloudAccountDATableAdapters.PaymentMasterTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="0" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Invoice" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div style="background-color: lightgray; padding: 10px;">
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                    </div>
                    <asp:GridView runat="server" ID="gvInvoice" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="InvoiceID"
                        AllowSorting="True" OnSorting="gvInvoice_Sorting" OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged"
                        OnPageIndexChanging="gvInvoice_PageIndexChanging" GridLines="None" OnRowDataBound="gvInvoice_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("InvoiceID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice" SortExpression="InvoiceNumber">
                                <ItemTemplate>
                                    <a href='<%# "InvoiceMaster.aspx?cmd=view&ID=" + Eval("InvoiceID")%>'>
                                        <%# Eval("InvoiceNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice" SortExpression="InvoiceNumber"></asp:BoundField>--%>
                            <asp:BoundField DataField="ClientID" HeaderText="Client Name" SortExpression="ClientID"></asp:BoundField>
                            <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                            <%--<asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblInvoiceTotal" Text='<%# GetCurrency(Eval("CurrencyID").ToString()) + " " + Eval("InvoiceTotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Outstanding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBalancePending" Text='<%# GetCurrency(Eval("CurrencyID").ToString()) + " " + decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString()) - decimal.Parse(Eval("PaidToDate").ToString()),2) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvoiceStatus" HeaderText="Status" SortExpression="InvoiceStatus" />
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible='<%# decimal.Parse(Eval("PaidToDate").ToString()) == decimal.Parse("0.00") %>'>
                                    <a href='<%# "InvoiceMaster.aspx?cmd=add&ID=" + Eval("InvoiceID") %>'>edit</a>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
                        <a id="activeTag" runat="server" href="InvoiceMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="InvoiceMaster.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="InvoiceMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>

                    <div class="totals ta_right">
                        <asp:GridView runat="server" ID="gvInvoiceTotal" CssClass="gridTableView table table-responsive" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Invoice Totals:">
                                    <ItemTemplate>
                                        <%# Eval("InvoiceTotal") + " (" + Eval("CurrencyCode") + ")" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="sqldsInvoiceTotalCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(InvoiceTotal) InvoiceTotal,CurrencyCode FROM InvoiceMaster i INNER JOIN CurrencyMaster c ON i.CurrencyID = c.CurrencyID WHERE [CompanyID] = @CompanyID AND [Active] = @Active AND [Archived] = @Archived AND [Deleted] = @Deleted GROUP BY CurrencyCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                                <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                                <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="sqldsInvoiceTotalCompanyStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(InvoiceTotal) InvoiceTotal,CurrencyCode FROM InvoiceMaster i INNER JOIN CurrencyMaster c ON i.CurrencyID = c.CurrencyID WHERE [CompanyID] = @CompanyID AND [ClientID] IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1) AND [Active] = @Active AND [Archived] = @Archived AND [Deleted] = @Deleted GROUP BY CurrencyCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                                <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                                <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                                <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <%--<asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;NGN</span>--%><br />
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsInvoice" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsInvoiceStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyStaffIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
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
    <asp:HiddenField runat="server" ID="hfInvoiceID" />

</asp:Content>
