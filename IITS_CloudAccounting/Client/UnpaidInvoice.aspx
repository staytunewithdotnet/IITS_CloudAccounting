<%@ Page Title="Unpaid Invoices" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="UnpaidInvoice.aspx.cs" Inherits="IITS_CloudAccounting.Client.UnpaidInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
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
                    <a href="#">Invoice
                    </a>
                </li>
                <li>
                    <a href="AllInvoice.aspx">All Invoice
                    </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black">
        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="col-lg-2">&nbsp;</div>
            <div class="col-lg-7 notification-page notification-search">
                <h3 style="color: #7f5711; font-family: Arial,Helvetica,sans-serif; font-size: 18px; line-height: 24px; margin: 0 0 7px; padding: 0;">Search Criteria:
                </h3>
                <ul>
                    <li>Only unpaid invoices</li>
                </ul>
            </div>
            <div class="col-lg-2">&nbsp;</div>
            <div class="clearfix"></div>

            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Search Result for Unpaid Invoices
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvInvoice" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="InvoiceID" DataSourceID="objdsInvoice" OnRowDataBound="gvInvoice_OnRowDataBound"
                        AllowSorting="True" OnSorting="gvInvoice_Sorting" OnPageIndexChanging="gvInvoice_PageIndexChanging" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("InvoiceID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice" SortExpression="InvoiceNumber">
                                <ItemTemplate>
                                    <a href='<%# "AllInvoice.aspx?cmd=view&ID=" + Eval("InvoiceID")%>'>
                                        <%# Eval("InvoiceNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate"></asp:BoundField>
                            <asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField HeaderText="Outstanding">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBalancePending" Text='<%# decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString()) - decimal.Parse(Eval("PaidToDate").ToString()),2) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblInvStatus" Text='<%# SetStatus(Eval("InvoiceStatus").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="InvoiceStatus" HeaderText="Status" SortExpression="InvoiceStatus" />--%>
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
                    <asp:ObjectDataSource runat="server" ID="objdsInvoice" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByClientIDActiveUnpaid" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfClientID" PropertyName="Value" DefaultValue="0" Name="ClientID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <div class="totals ta_right">
                        <strong>Invoice Totals:&nbsp;</strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;
                            <asp:Label runat="server" ID="lblCurCode"></asp:Label>
                        </span><br />
                    </div>

                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                </div>
            </div>
        </asp:Panel>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfInvoiceID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
