<%@ Page Title="Payments Collected Report" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="PaymentsCollectedReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PaymentsCollectedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <div class="row" style="margin-top: -45px;">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-download"></i>
                    <a href="AllReports.aspx">Reports
                    </a>
                </li>
                <li>
                    <a href="PaymentsCollectedReport.aspx">Payments Collected</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Payments Collected</h1>
            <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; float: right" class="btn-info">Generate PDF</a>
        </div>
        <div class="panel-body" style="background-color: #f1f1f1; margin-bottom: 20px;">
            <div class="col-lg-3">
                <span class="control-label">Date Range:</span>
                <br />
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtDateFrom" Format="dd/MMM/yyyy" />
                </div>
                <div class="col-lg-1" style="padding: 8px 0 0 4px">to</div>
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtDateTo" Format="dd/MMM/yyyy" />
                </div>
            </div>
            <div class="col-lg-3">
                <span class="control-label">Clients:</span>
                <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text" DataSourceID="sqldsClient" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS ID,'All Client' AS Name UNION SELECT CompanyClientID,OrganizationName AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-3">
                <span class="control-label">Method:</span>
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
            <div class="col-lg-3">
                <span class="control-label">&nbsp;</span><br />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdateClick" Style="width: 50% !important;" />
            </div>
        </div>
        <div id="printDiv" class="panel-body rounded-container peel-shadows" style="background-color: #fff !important; color: #000 !important;">
            <div class="col-lg-12" style="text-align: right">
                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/logo.jpg" style="height: 85px;width: 15%;" />
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center">
                <h1 style="margin-bottom: 0;">All Payments Collected
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 20px;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
            </div>
            <div class="clearfix"></div>
            <asp:GridView runat="server" ID="gvPayments" Width="100%" CssClass="reportTable table table-responsive" GridLines="None" DataSourceID="objdsPayments"
                AutoGenerateColumns="False" DataKeyNames="PaymentID" ShowHeader="True" AllowSorting="True" OnSorting="gvPayments_OnSorting"
                OnRowDataBound="gvPayment_OnRowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Payment For" SortExpression="InvoiceNumber">
                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
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
                    <asp:BoundField DataField="Notes" HeaderText="Notes">
                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Total" SortExpression="PaymentAmount">
                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPaymentTotal" Text='<%# GetCurrency(Eval("InvoiceID").ToString()) + " " + Decimal.Round(Decimal.Parse(Eval("PaymentAmount").ToString()),2) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#0083E0" ForeColor="White"></HeaderStyle>
                <EmptyDataTemplate>
                    <div style="width: 100%; text-align: center">
                        No payments were found.
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="objdsPayments" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ReportPaymentsCollectedTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="ClientID" Type="Int32"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="ddlMethod" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="PaymentMethod" Type="String"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                    <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfDate" />
</asp:Content>
