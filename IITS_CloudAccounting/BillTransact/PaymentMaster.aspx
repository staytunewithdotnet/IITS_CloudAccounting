<%@ Page Title="Payment Master" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" 
    Async="true" CodeBehind="PaymentMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PaymentMaster" %>

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

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoices
                    </a>
                </li>
                <li>
                    <a href="PaymentMaster.aspx">Payment Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Payment has been saved.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Payment has been updated.</h3>
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
                <h1>Enter Payment</h1>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server" ID="upClient" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group" style="text-align: center;">
                                    <h1 style="color: black; margin-top: 0;">
                                        <asp:Label runat="server" ID="lblPaymentInfo"></asp:Label>
                                    </h1>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel runat="server" ID="upPayAll">
                            <ContentTemplate>
                                <div class="col-lg-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-lg-5 control-label">
                                                Payment (<asp:Label runat="server" ID="lblCurrencyCode" Text="NGN"></asp:Label>)<span style="color: red">*</span>
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:TextBox runat="server" ID="txtPayment" CssClass="form-control text" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                                <asp:CheckBox runat="server" ID="chkPayAll" Text="Pay in full" AutoPostBack="True" OnCheckedChanged="chkPayAll_OnCheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-5 control-label">
                                                Invoice Amount
                                            </div>
                                            <div class="col-lg-6">
                                                <h3 style="margin-top: 8px; color: black;">
                                                    <asp:Label runat="server" ID="lblInvoiceAmt" onkeypress="return decimalValue(this,event);"></asp:Label>
                                                </h3>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5 control-label">
                                        Method
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlMethod" CssClass="form-control text">
                                            <asp:ListItem Value="Check">Check</asp:ListItem>
                                            <asp:ListItem Value="Bank Transfer">Bank Transfer</asp:ListItem>
                                            <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                            <asp:ListItem Value="Cash" Selected="True">Cash</asp:ListItem>
                                            <asp:ListItem Value="Debit">Debit</asp:ListItem>
                                            <asp:ListItem Value="ACH">ACH</asp:ListItem>
                                            <asp:ListItem Value="VISA">VISA</asp:ListItem>
                                            <asp:ListItem Value="MASTERCARD">MASTERCARD</asp:ListItem>
                                            <asp:ListItem Value="AMEX">AMEX</asp:ListItem>
                                            <asp:ListItem Value="DISCOVER">DISCOVER</asp:ListItem>
                                            <asp:ListItem Value="DINERS">DINERS</asp:ListItem>
                                            <asp:ListItem Value="JCB">JCB</asp:ListItem>
                                            <asp:ListItem Value="NOVA">NOVA</asp:ListItem>
                                            <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                            <asp:ListItem Value="PayPal">PayPal</asp:ListItem>
                                            <asp:ListItem Value="2Checkout">2Checkout</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5 control-label">
                                        Date
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtPaymentDate" CssClass="form-control text"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="cePaymentDate" TargetControlID="txtPaymentDate" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5 control-label">
                                        Notes
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtPaymentNote" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divOldData" runat="server" visible="False">
                            <div class="col-lg-3">&nbsp;</div>
                            <div class="col-lg-9" style="padding-right: 0;">
                                <div class="form-horizontal">
                                    <asp:GridView runat="server" ID="gvPaymentOld" Width="100%" CssClass="table gridTableView" AutoGenerateColumns="False" DataKeyNames="PaymentID" DataSourceID="objdsPaymentOld">
                                        <Columns>
                                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
                                            <asp:BoundField DataField="Method" HeaderText="Type" SortExpression="Method"></asp:BoundField>
                                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
                                            <asp:BoundField DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:ObjectDataSource runat="server" ID="objdsPaymentOld" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByInvoiceID" TypeName="DABL.DAL.CloudAccountDATableAdapters.PaymentMasterTableAdapter">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="0" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </div>
                                <div class="form-horizontal" style="float: right">
                                    <div class="form-group">
                                        <div class="col-lg-7">
                                            Total Paid:
                                        </div>
                                        <div class="col-lg-4" style="float: right;">
                                            <asp:Label runat="server" ID="lblTotalPaid" Text="0.00"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group" style="color: black; font-weight: bold; font-size: 15px;">
                                        <div class="col-lg-7 control-label">
                                            Balance:
                                        </div>
                                        <div class="col-lg-4" style="padding-top: 7px; float: right;">
                                            <asp:Label runat="server" ID="lblBalance"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group" style="text-align: center;">
                                    <asp:CheckBox runat="server" ID="chkEmail" Text="Send company a payment notification email" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnUpdate" Text="Save" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlView"></asp:Panel>
        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Payments
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="Enter Payment" Style="float: right;" />
            </div>
            <style>
                .mytable > tbody > tr > td, .mytable td,.mytable > tbody > tr > th, .mytable th {
                    padding: 15px 4px !important;
                }
            </style>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div class="col-lg-12" id="divSearch" style="padding: 10px; display: none; background-color: #f6f6f6; margin-bottom: 10px;">
                        <div id="closeSearch" class="close-button" style="cursor: pointer; background-color: blanchedalmond; padding: 10px; border-radius: 10px; overflow: visible;"></div>
                        <h3 style="margin: 10px auto 20px; text-align: center;">Search Box</h3>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Invoice #
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtInvoiceNumberSearch" CssClass="searchText"></asp:TextBox>
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
                                        Notes
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtNotesSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Payment Method
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlMethodSearch" CssClass="searchText">
                                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="Check">Check</asp:ListItem>
                                            <asp:ListItem Value="Bank Transfer">Bank Transfer</asp:ListItem>
                                            <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            <asp:ListItem Value="Debit">Debit</asp:ListItem>
                                            <asp:ListItem Value="ACH">ACH</asp:ListItem>
                                            <asp:ListItem Value="VISA">VISA</asp:ListItem>
                                            <asp:ListItem Value="MASTERCARD">MASTERCARD</asp:ListItem>
                                            <asp:ListItem Value="AMEX">AMEX</asp:ListItem>
                                            <asp:ListItem Value="DISCOVER">DISCOVER</asp:ListItem>
                                            <asp:ListItem Value="DINERS">DINERS</asp:ListItem>
                                            <asp:ListItem Value="JCB">JCB</asp:ListItem>
                                            <asp:ListItem Value="NOVA">NOVA</asp:ListItem>
                                            <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                            <asp:ListItem Value="PayPal">PayPal</asp:ListItem>
                                            <asp:ListItem Value="2Checkout">2Checkout</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Date Range
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtDateFrom" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtDateFrom" />
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtDateTo" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtDateTo" />
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
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete Forever" OnClick="btnDelete_Click" />
                        <asp:Button runat="server" ID="btnEmail" Text="Email" CssClass="btn-danger" OnClick="btnEmail_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvPayment" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="mytable table table-striped table-hover" DataKeyNames="PaymentID" GridLines="None"
                        AllowSorting="True" OnRowDataBound="gvPayment_OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="2%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("PaymentID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment For" SortExpression="InvoiceNumber">
                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                <ItemTemplate>
                                    <a href='<%# "InvoiceMasterNew.aspx?cmd=view&ID=" + Eval("InvoiceID")%>'>
                                        <%# GetInvoiceNumber(Eval("InvoiceID").ToString()) %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvoiceID" HeaderText="Client Name" SortExpression="InvoiceID">
                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method">
                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPaymentTotal" Text='<%# GetCurrency(Eval("InvoiceID").ToString()) + " " + Decimal.Round(Decimal.Parse(Eval("PaymentAmount").ToString()),2) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes">
                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                            </asp:BoundField>
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

                    <div class="totals ta_right">
                        <asp:GridView runat="server" ID="gvPaymentTotal" CssClass="gridTableView table table-responsive" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Total payments received:">
                                    <ItemTemplate>
                                        <%# Decimal.Round(Decimal.Parse(Eval("PaymentAmount").ToString()),2) + " (" + Eval("CurrencyCode") + ")" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="sqldsPaymentTotalCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(PaymentAmount) PaymentAmount,CurrencyCode FROM PaymentMaster p INNER JOIN InvoiceMaster i ON i.InvoiceID = p.InvoiceID INNER JOIN CurrencyMaster c ON i.CurrencyID = c.CurrencyID WHERE p.CompanyID = @CompanyID GROUP BY CurrencyCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource runat="server" ID="sqldsPaymentTotalCompanyStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(PaymentAmount) PaymentAmount,CurrencyCode FROM PaymentMaster p INNER JOIN InvoiceMaster i ON i.InvoiceID = p.InvoiceID INNER JOIN CurrencyMaster c ON i.CurrencyID = c.CurrencyID WHERE p.CompanyID = @CompanyID AND [ClientID] IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1) GROUP BY CurrencyCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsPayment" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPaymentSearch" TypeName="DABL.DAL.CloudAccountDATableAdapters.PaymentMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtInvoiceNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InvoiceNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlMethodSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="PaymentMethod" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsPaymentStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPaymentSearchStaff" TypeName="DABL.DAL.CloudAccountDATableAdapters.PaymentMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtInvoiceNumberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InvoiceNumber" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlMethodSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="PaymentMethod" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlCurrencySearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Currency" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;"></div>
            </div>
        </asp:Panel>

    </div>
    <div class="col-lg-2">
        <asp:HiddenField runat="server" ID="hfInvoiceID" />
        <asp:HiddenField runat="server" ID="hfCompanyID" />
        <asp:HiddenField runat="server" ID="hfStaffID" />
        <asp:HiddenField runat="server" ID="hfPaymentID" />
    </div>
    <style type="text/css">
        .ajax__tab_xp .ajax__tab_body {
            padding: 0 0 0 0;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            height: 40px;
            padding: 4px;
            margin: 0;
            font-size: 13px;
            font-family: Verdana;
        }

        .ajax__tab_header {
            height: 40px;
        }

        .ajax__tab_tab {
            height: 40px;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-size: 12px;
            height: 30px;
        }

        .modelBackground {
            background-color: Black;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .Popup {
            background-color: #FFFFFF;
            border-color: black;
            border-style: solid;
            border-width: 3px;
            height: 370px;
            padding-left: 10px;
            padding-top: 10px;
            width: 575px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }

        .mygridTable.table > tbody > tr > th:last-child, .gridTable.table > tbody > tr > td:last-child {
            border: none;
        }

        .mygridTable.table > tbody > tr > th {
            background-color: #0D83DE;
            color: #ffffff;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
            border: none;
        }

        .mygridTable.table > tbody > tr > td {
            text-align: left;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
            border-bottom: 1px solid #ddd;
        }

        .panel-body .x_button {
            background-image: url('../App_Themes/Doyingo/images/close-grey.png');
        }

        .x_button {
            background: url('../App_Themes/Doyingo/images/close-blue.png') no-repeat left top;
            width: 51px;
            height: 46px;
            position: absolute;
            right: 0;
            top: 0;
            z-index: 5;
        }

        .panel-body .close-button-blue {
            background-image: url('../App_Themes/Doyingo/images/allIcon.png');
            background-position: -59px -19px;
        }

        .panel-body .close-button-blue:hover {
            background-position: -78px -19px;
        }

        .close-button-blue {
            display: block;
            width: 19px;
            padding-top: 19px;
            overflow: hidden;
            height: 0;
            float: right;
            background: url('../App_Themes/Doyingo/images/close-button-blue.png') no-repeat left top;
            margin: 1px;
            cursor: pointer;
        }

        a {
            outline: 0;
        }
    </style>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInvoicePayment" PopupControlID="pnlInvoicePayment" TargetControlID="btnAdd" CancelControlID="lnkClose" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlInvoicePayment" runat="server" Width="750px" align="center" Style="display: none; padding: 22px 30px 25px; border: 5px solid #CCCCCC; border-radius: 15px; position: fixed; z-index: 100001; background-color: white;">
        <div class="panel-body" style="border-color: #CCCCCC;">
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                <h3 style="margin-top: 0;">Which invoices have you received payment for?</h3>
                <h5 style="margin: 20px 0;">Select one invoice from the list below to apply payment.</h5>
            </div>
            <div class="x_button" role="button">
                <asp:LinkButton runat="server" ID="lnkClose" CssClass="close-button-blue" title="close dialog">close dialog</asp:LinkButton>
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:GridView runat="server" ID="gvInvoice" CssClass="mygridTable table table-responsive" Width="100%" GridLines="None"
                                AutoGenerateColumns="False" DataKeyNames="InvoiceID" OnRowDataBound="gvInvoice_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%--<asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("InvoiceID") %>' />--%>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice" SortExpression="InvoiceNumber"></asp:BoundField>
                                    <asp:BoundField DataField="ClientID" HeaderText="Client Name" SortExpression="ClientID"></asp:BoundField>
                                    <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate"></asp:BoundField>
                                    <asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                                    <asp:BoundField DataField="InvoiceStatus" HeaderText="Status" SortExpression="InvoiceStatus" />
                                    <asp:TemplateField HeaderText="Payment">
                                        <ItemTemplate>
                                            <a href='<%# "PaymentMaster.aspx?cmd=add&InvoiceID=" + Eval("InvoiceID") %>'>Make Payment</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsInvoice" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM InvoiceMaster WHERE CompanyID = @CompanyID AND InvoiceTotal > PaidToDate AND (Active = 1 OR Archived = 1)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource runat="server" ID="sqldsInvoiceStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM InvoiceMaster WHERE CompanyID = @CompanyID AND ClientID IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1) AND InvoiceTotal > PaidToDate AND (Active = 1 OR Archived = 1)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
