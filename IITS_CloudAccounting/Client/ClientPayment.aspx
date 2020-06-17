<%@ Page Title="Client Payment" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="ClientPayment.aspx.cs" Inherits="IITS_CloudAccounting.Client.ClientPayment" %>

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
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Payments
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvPayment" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="PaymentID" GridLines="None" DataSourceID="sqldsPayment"
                        AllowSorting="True" OnRowDataBound="gvPayment_OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("PaymentID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment For" SortExpression="InvoiceNumber">
                                <ItemTemplate>
                                    <a href='<%# "AllInvoice.aspx?cmd=view&ID=" + Eval("InvoiceID")%>'>
                                        <%# GetInvoiceNumber(Eval("InvoiceID").ToString()) %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvoiceID" HeaderText="Client Name" SortExpression="InvoiceID"></asp:BoundField>
                            <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method"></asp:BoundField>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
                            <asp:BoundField DataField="PaymentAmount" HeaderText="Amount" SortExpression="PaymentAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
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
                        <strong>Total payments received:&nbsp;</strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;
                            <asp:Label runat="server" ID="lblCurCode"></asp:Label>
                        </span><br />
                    </div>
                    <asp:SqlDataSource runat="server" ID="sqldsPayment" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [PaymentID],[CompanyID],[InvoiceID],[PaymentAmount],[Method],[Date],[Notes] FROM PaymentMaster WHERE InvoiceID in (SELECT InvoiceID FROM InvoiceMaster WHERE ClientID = @ClientID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfClientID" PropertyName="Value" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;"></div>
            </div>
        </asp:Panel>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfInvoiceID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
