<%@ Page Title="All Invoice" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="AllInvoice.aspx.cs" Inherits="IITS_CloudAccounting.Client.AllInvoice" %>

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
                    <asp:Button runat="server" ID="btnDispute" Text="Dispute" CssClass="btn-danger" Style="padding: 7px;" OnClick="btnDispute_OnClick" />
                    <asp:Button runat="server" ID="btnForward" Text="Forward" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnForward_OnClick" />
                    <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; display: inline-block;" class="btn-danger">Generate PDF</a>
                    <input type="button" value="Print" id="btnPrint" style="padding: 7px; display: inline-block;" class="btn-warning printNone" onclick="printDiv();" />
                    <%--<asp:Button runat="server" ID="btnPayment" Text="Enter Payment" CssClass="btn-success" Style="padding: 7px;" OnClick="btnPayment_Click" />--%>
                    <asp:Button runat="server" ID="btnPayOnline" Text="Pay Online" CssClass="btn-success" Style="padding: 7px;" OnClick="btnPayOnline_Click" />
                </div>
            </div>

            <div class="clearfix"></div>

            <div id="forwardDiv" runat="server" visible="False">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                New Contact
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientMaster" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ToolTip="Please Enter Valid Email ID" ValidationGroup="CompanyClientMaster" SetFocusOnError="True" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control text" onkeypress="return isLetter(event)"></asp:TextBox>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control text" onkeypress="return isLetter(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Email Message
                            </div>
                            <div class="col-lg-8">
                                <asp:TextBox runat="server" ID="txtEmailBody" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center;">
                                <asp:Button runat="server" ID="btnForwardSend" Text="Forward" Style="padding: 5px;" CssClass="btn-success" OnClick="btnForwardSend_Click" ValidationGroup="CompanyClientMaster" />
                                or
                                <asp:LinkButton runat="server" ID="lnkCloseForward" Text="cancel" CssClass="permission" OnClick="lnkCloseForward_OnClick"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label"></div>
                            <div class="col-lg-9"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>

            <div runat="server" id="disputeDiv" visible="True">
                <div class="col-lg-2">&nbsp;</div>
                <div class="col-lg-8 rounded-container peel-shadows" style="padding-left: 0;padding-right: 0;">
                    <div class="form-horizontal" id="disputeDivLabel" runat="server">
                        <h3 style="padding-left: 15px;padding-right: 15px;">Dispute History</h3>
                        <asp:DataList runat="server" ID="dlHistory" Width="100%" DataKeyField="InvoiceDisputeHistoryID" DataSourceID="sqldsHistory" RepeatColumns="1" RepeatDirection="Vertical">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("InvoiceDisputeHistoryID") %>' runat="server" ID="InvoiceDisputeHistoryIDLabel" Visible="False" />
                                <asp:Label Text='<%# Eval("InvoiceID") %>' runat="server" ID="InvoiceIDLabel" Visible="False" />
                                <div class="col-lg-12 clearfix">
                                    <div class='<%# Eval("InvoiceDisputeCreatedBy").ToString() != "Company"?"col-lg-2 float_left":"col-lg-2 float_right" %>' style="float: <%#Eval("InvoiceDisputeCreatedBy").ToString() != "Company"?"left":"right"%>">
                                        <div class="client-icon-medium bg-system-light" runat="server" visible='<%# Eval("InvoiceDisputeCreatedBy").ToString() != "Company" %>'></div>
                                        <div class="staff-icon-medium bg-system-light" runat="server" visible='<%# Eval("InvoiceDisputeCreatedBy").ToString() == "Company" %>'></div>
                                    </div>
                                    <div class='<%# Eval("InvoiceDisputeCreatedBy").ToString() != "Company"?"col-lg-10 float_left ta_left":"col-lg-10 float_right ta_right" %>'>
                                        <span class="dispute-bubble">
                                            <%# Eval("InvoiceDisputeComments") %>
                                            <span class='<%# Eval("InvoiceDisputeCreatedBy").ToString() != "Company"?"dispute-nib left":"dispute-nib right" %>'></span>
                                        </span>
                                        <div class="example">
                                            <asp:Label Text='<%# SetName(Eval("InvoiceDisputeCreatedID").ToString(),Eval("InvoiceDisputeCreatedBy").ToString()) %>' runat="server" ID="InvoiceDisputeCreatedIDLabel" />,
                                            <asp:Label Text='<%# Eval("InvoiceDisputeCommentDate","{0:"+dateFormat+"}") %>' runat="server" ID="InvoiceDisputeCommentDateLabel" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:Label Visible='<%# dlHistory.Items.Count == 0 %>' Text="No Dispute History Found" CssClass="dispute-bubble" runat="server" ID="LabelFooter" />
                            </FooterTemplate>--%>
                        </asp:DataList>
                        <asp:SqlDataSource runat="server" ID="sqldsHistory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [InvoiceDisputeHistory] WHERE ([InvoiceID] = @InvoiceID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfInvoiceID" PropertyName="Value" DefaultValue="0" Name="InvoiceID" Type="Int32"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <hr />
                    <div class="form-horizontal cutline-top" id="disputeDivText" runat="server" visible="False">
                        <h3 style="padding-left: 15px;padding-right: 15px;">Reason For Dispute</h3>
                        <div class="form-group">
                            <div class="col-lg-2" style="padding-right: 0; padding-left: 35px;">
                                <div class="client-icon-medium bg-system-light"></div>
                            </div>
                            <div class="col-lg-10">
                                <asp:TextBox runat="server" ID="txtDisputeText" TextMode="MultiLine" CssClass="form-control text"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12" style="text-align: center">
                                <asp:Button runat="server" ID="btnDisputeSend" Text="Send" CssClass="btn btn-success" OnClick="btnDisputeSend_OnClick" />
                                or
                                <asp:LinkButton runat="server" ID="lnkCloseDispute" Text="cancle" CssClass="permission" OnClick="lnkCloseDispute_OnClick"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2">&nbsp;</div>
            </div>

            <div class="clearfix"></div>

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

                <div class="clearfix"></div>

                <div class="invbody">

                    <asp:GridView runat="server" ID="gvTaskView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="InvoiceTaskDetailID" DataSourceID="objdsTaskView" OnRowDataBound="gvTaskView_OnRowDataBound">
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
                            <asp:BoundField DataField="InvoiceTaskDetailID" HeaderText="InvoiceTaskDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="InvoiceTaskDetailID"></asp:BoundField>
                            <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" SortExpression="InvoiceID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView runat="server" ID="gvItemView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="InvoiceItemDetailID" DataSourceID="objdsItemView" OnRowDataBound="gvItemView_OnRowDataBound">
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
                            <asp:BoundField DataField="TaxID1" HeaderText="Tax1" SortExpression="TaxID1">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="TaxID2" HeaderText="Tax2" SortExpression="TaxID2">
                                <ItemStyle CssClass="tax1"></ItemStyle>
                                <HeaderStyle CssClass="tax1"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Line Total" SortExpression="Total" DataFormatString="{0:0.00}">
                                <ItemStyle Width="34%"></ItemStyle>
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
                            <img style="margin-bottom: -1px; width: 52px; height: 23px;" alt="DoyinGo" src="../App_Themes/Doyingo/images/logo.jpg" />
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
                        <asp:BoundField DataField="PaymentAmount" HeaderText="Payment Amount" SortExpression="PaymentAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                        <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method"></asp:BoundField>
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"></asp:BoundField>
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
                <h1 style="display: inline-block; margin: 0;">Invoices
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvInvoice" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="InvoiceID" DataSourceID="objdsInvoice"
                        AllowSorting="True" OnSorting="gvInvoice_Sorting" OnPageIndexChanging="gvInvoice_PageIndexChanging" GridLines="None"
                        OnRowDataBound="gvInvoice_OnRowDataBound">
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
                                    <%--<asp:Label runat="server" ID="lblBalancePending" Text='<%# decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString()) - decimal.Parse(Eval("PaidToDate").ToString()),2) %>'></asp:Label>--%>
                                    <asp:Label runat="server" ID="lblBalancePending" Text='<%# decimal.Round(decimal.Parse(Eval("InvoiceTotal").ToString()))%>'></asp:Label>
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
                    <asp:ObjectDataSource runat="server" ID="objdsInvoice" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByClientIDActive" TypeName="DABL.DAL.CloudAccountDATableAdapters.InvoiceMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfClientID" PropertyName="Value" DefaultValue="0" Name="ClientID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <div class="totals ta_right">
                        <strong>Invoice Totals:&nbsp;</strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;
                            <asp:Label runat="server" ID="lblCurCode"></asp:Label>
                        </span>
                        <br />
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
