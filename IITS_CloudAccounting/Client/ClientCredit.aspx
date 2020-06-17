<%@ Page Title="Client Credit" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="ClientCredit.aspx.cs" Inherits="IITS_CloudAccounting.Client.ClientCredit" %>

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
                <div class="clearfix"></div>
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
                            <img style="margin-bottom: -1px; width: 56px; height: 23px;" alt="DoyinGo" src="../App_Themes/Doyingo/images/logo.jpg" />
                        </a>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>

            <div class="rounded-container peel-shadows" style="color: black;">
                <h3 style="margin: 15px;">Credit Autobiography</h3>
                <asp:GridView runat="server" ID="gvCreditHistory" Width="100%" DataSourceID="objdsCreditHistory" AutoGenerateColumns="False"
                    DataKeyNames="CreditHistoryDetailID" CssClass="gridTableView hi table table-striped table-responsive" GridLines="None">
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
                        <div style="width: 100%;text-align: center;">
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
                <h1 style="display: inline-block; margin: 0;">Credits
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvCredit" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="CreditID" DataSourceID="objdsCredit"
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
                                    <a href='<%# "ClientCredit.aspx?cmd=view&ID=" + Eval("CreditID")%>'>
                                        <%# Eval("CreditNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClientID" HeaderText="Client Name" SortExpression="ClientID"></asp:BoundField>
                            <asp:BoundField DataField="CreditDate" HeaderText="Date" SortExpression="CreditDate"></asp:BoundField>
                            <asp:BoundField DataField="CreditRemaingTotal" HeaderText="Remaing" SortExpression="CreditRemaingTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="CreditTotal" HeaderText="Total" SortExpression="CreditTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblInvStatus" Text='<%# SetStatus(Eval("CreditStatus").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="CreditStatus" HeaderText="Status" SortExpression="CreditStatus" />--%>
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

                    <asp:ObjectDataSource runat="server" ID="objdsCredit" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByClientID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CreditMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfClientID" PropertyName="Value" DefaultValue="0" Name="ClientID" Type="Int32"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfCreditID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
