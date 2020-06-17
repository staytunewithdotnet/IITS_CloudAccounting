<%@ Page Title="Online Payment Of Invoice" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="InvoicePayment.aspx.cs" Inherits="IITS_CloudAccounting.Client.InvoicePayment" %>

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
                    <a href="InvoicePayment.aspx">Secure Payment - PayPal
                    </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <h1>Secure Payment - PayPal
        </h1>
        <asp:Panel runat="server" ID="pnlPayment">
            <div class="col-lg-12 peel-shadows rounded-container" style="text-align: center;">
                <span style="font-family: FranklinNarrow,Arial,sans-serif; display: block; font-size: 44px; line-height: 54px; color: #0083E0;">
                    <asp:Label runat="server" ID="lblPaymentDue"></asp:Label>
                </span>
                <asp:GridView runat="server" ID="gvInvoice" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="InvoiceID" DataSourceID="objdsInvoice"
                    AllowSorting="True" GridLines="None" OnRowDataBound="gvInvoice_OnRowDataBound">
                    <Columns>
                        <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice #" SortExpression="InvoiceNumber"></asp:BoundField>
                        <asp:BoundField DataField="InvoiceDate" HeaderText="Date" SortExpression="InvoiceDate"></asp:BoundField>
                        <asp:BoundField DataField="InvoiceTotal" HeaderText="Total" SortExpression="InvoiceTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:TemplateField HeaderText="Outstanding">
                            <ItemTemplate>
                                <%--<asp:Label runat="server" ID="lblBalancePending" Text='<%# decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString()) - decimal.Parse(Eval("PaidToDate").ToString()),2) %>'></asp:Label>--%>
                                <asp:Label runat="server" ID="lblBalancePending" Text='<%# decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString())) %>'></asp:Label>
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
                <asp:ObjectDataSource runat="server" ID="objdsInvoice" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByInvoiceID" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceMasterTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="0" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <hr />
                <div class="form-horizontal" style="text-align: center">
                    <div class="form-group">
                        <div class="col-lg-4">&nbsp;</div>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtPaymentAmount"></asp:TextBox>
                            Payment Amount 
                        </div>
                        <div class="col-lg-4">&nbsp;</div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <div class="col-lg-3">&nbsp;</div>
                        <div class="col-lg-6">
                            Click to pay with PayPal:
                            <br />
                            <asp:ImageButton ID="btnPay" runat="server" AlternateText="Pay" ImageUrl="https://www.paypalobjects.com/en_GB/i/btn/btn_paynow_SM.gif" OnClick="btnPay_Click" />
                        </div>
                        <div class="col-lg-3">&nbsp;</div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlError">
            <div style="text-align: center">
                <span style="color: red; font-size: small">No Paypal Information Found For Company. Contact Company Admin to Add Paypal Information
                </span>
                <a id="aContact" runat="server">
                    <asp:Label runat="server" ID="lblContact"></asp:Label>
                </a>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfInvoiceID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
