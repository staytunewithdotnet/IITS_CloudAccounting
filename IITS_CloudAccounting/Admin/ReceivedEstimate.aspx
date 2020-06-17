<%@ Page Title="Received Estimate" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ReceivedEstimate.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ReceivedEstimate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var i = document.getElementById("estimateDiv");
            i.style.display = 'block';
        });
    </script>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Estimates
                    </a>
                </li>
                <li>
                    <a href="ReceivedEstimate.aspx">Received Estimate</a>
                </li>
            </ol>
        </div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        
        <script type="text/javascript">
            function printDiv() {
                var lblInvoiceNum = document.getElementById('<%=lblEstimateNum.ClientID%>').innerText;
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
                <asp:Label runat="server" ID="lblEstimateNumHead" CssClass="printNone" Style="float: left; margin-bottom: 20px; font-family: Arial,Helvetica,sans-serif; font-size: 24px; color: #000; line-height: normal;"></asp:Label>
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
                                <%--<img src="../App_Themes/Doyingo/images/blank.gif" alt="" width="150" height="55" is_custom="" />--%>
                                <br />
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
                                    <th>Estimate #
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblEstimateNum"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Estimate Date
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblEstimateDate"></asp:Label></td>
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
                                            <asp:Label runat="server" ID="lblEstimateAmount"></asp:Label>
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
                        AutoGenerateColumns="False" DataKeyNames="EstimateTaskDetailID" DataSourceID="objdsTaskView" OnRowDataBound="gvTaskView_OnRowDataBound">
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
                            <asp:BoundField DataField="EstimateTaskDetailID" HeaderText="EstimateTaskDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="EstimateTaskDetailID"></asp:BoundField>
                            <asp:BoundField DataField="EstimateID" HeaderText="EstimateID" SortExpression="EstimateID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView runat="server" ID="gvItemView" CssClass="table table-hover gridTableView" Width="100%" GridLines="Horizontal"
                        AutoGenerateColumns="False" DataKeyNames="EstimateItemDetailID" DataSourceID="objdsItemView" OnRowDataBound="gvItemView_OnRowDataBound">
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
                            <asp:BoundField DataField="EstimateItemDetailID" HeaderText="EstimateItemDetailID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="EstimateItemDetailID"></asp:BoundField>
                            <asp:BoundField DataField="EstimateID" HeaderText="EstimateID" SortExpression="EstimateID" Visible="False"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                    <asp:ObjectDataSource runat="server" ID="objdsItemView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByEstimateID" TypeName="DABL.DAL.CloudAccountDATableAdapters.EstimateItemDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfEstimateID" PropertyName="Value" DefaultValue="1" Name="EstimateID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsTaskView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByEstimateID" TypeName="DABL.DAL.CloudAccountDATableAdapters.EstimateTaskDetailTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfEstimateID" PropertyName="Value" DefaultValue="1" Name="EstimateID" Type="Int32"></asp:ControlParameter>
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
                                <asp:Label runat="server" ID="lblEstimateTotalView"></asp:Label>
                            </strong></td>
                        </tr>
                        <tr class="invbody-summary-paid" style="display: none;">
                            <td class="invbody-summary-clean">&nbsp;</td>
                            <th style="width: 150px;">Amount Paid
                            </th>
                            <td style="width: 120px;">-<asp:Label runat="server" ID="lblPaidToDateView" Text="0.00"></asp:Label></td>
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
                    <div style="margin-bottom: 18px; width: 80%;">
                        <h4>Terms</h4>
                        <asp:Label runat="server" ID="lblTerms"></asp:Label>
                    </div>
                    <div style="margin-bottom: 18px; width: 80%;">
                        <h4>Notes</h4>
                        <asp:Label runat="server" ID="lblNotes"></asp:Label>
                    </div>
                    <div class="invoice-brand" id="brandingDiv" runat="server">
                        This Estimate was sent using <a href="#" target="_blank" class="none">
                            <img style="height: 23px; margin-bottom: -1px; width: 56px;" alt="Bill Transact" src="../App_Themes/Doyingo/images/logo.jpg" />
                        </a>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
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
                                        Sender
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtClientNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Status
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlStatusSearch" CssClass="searchText">
                                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="draft">draft</asp:ListItem>
                                            <asp:ListItem Value="sent">sent</asp:ListItem>
                                            <asp:ListItem Value="viewed">viewed</asp:ListItem>
                                            <asp:ListItem Value="replied">replied</asp:ListItem>
                                            <asp:ListItem Value="accepted">accepted</asp:ListItem>
                                            <asp:ListItem Value="invoiced">invoiced</asp:ListItem>
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
                                        <asp:TextBox runat="server" ID="txtEstimateDateFrom" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtEstimateDateFrom" Format="MM/dd/yyyy" />
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtEstimateDateTo" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtEstimateDateTo" Format="MM/dd/yyyy" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Estimate Total
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtEstimateTotalFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtEstimateTotalTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
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
                        <%--<asp:Button runat="server" ID="btnConvert" CssClass="btn-warning" Text="Convert To Expenses" />--%>
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvEstimate" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="EstimateID" DataSourceID="objdsEstimate"
                        AllowSorting="True" OnSorting="gvEstimate_Sorting" OnSelectedIndexChanged="gvEstimate_SelectedIndexChanged"
                        OnPageIndexChanging="gvEstimate_PageIndexChanging" GridLines="None" OnRowDataBound="gvEstimate_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("EstimateID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimate" SortExpression="EstimateNumber">
                                <ItemTemplate>
                                    <a href='<%# "ReceivedEstimate.aspx?cmd=view&ID=" + Eval("EstimateID")%>'>
                                        <%# Eval("EstimateNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CompanyID" HeaderText="From" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="EstimateDate" HeaderText="Date" SortExpression="EstimateDate" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEstimateTotal" Text='<%# GetCurrency(Eval("CurrencyID").ToString()) + " " + Eval("EstimateTotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblInvStatus" Text='<%# SetStatus(Eval("EstimateStatus").ToString()) %>'></asp:Label>
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
                        <a id="activeTag" runat="server" href="ReceivedEstimate.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="ReceivedEstimate.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="ReceivedEstimate.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>

                    <div class="totals ta_right">
                        <asp:GridView runat="server" ID="gvEstimateTotal" CssClass="gridTableView table table-responsive" DataSourceID="sqldsEstimateTotalCompany" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Estimate Totals:">
                                    <ItemTemplate>
                                        <%# Eval("EstimateTotal") + " (" + Eval("CurrencyCode") + ")" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="sqldsEstimateTotalCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(EstimateTotal) EstimateTotal,CurrencyCode FROM EstimateMaster i INNER JOIN CurrencyMaster c ON i.CurrencyID = c.CurrencyID WHERE [CompanyID] IN (SELECT DISTINCT CompanyID FROM CompanyClientMaster where Email = @Email) AND ClientID IN (SELECT DISTINCT CompanyClientID FROM CompanyClientMaster where Email = @Email) AND [ReceivedActive] = @Active AND [ReceivedArchived] = @Archived AND [ReceivedDeleted] = @Deleted GROUP BY CurrencyCode">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyEmail" PropertyName="Value" DefaultValue="0" Name="Email" Type="String"></asp:ControlParameter>
                                <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                                <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                                <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsEstimate" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByReceivedEstimate" TypeName="DABL.DAL.CloudAccountDATableAdapters.EstimateMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyEmail" PropertyName="Value" DefaultValue="0" Name="Email" Type="String"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="ReceivedActive" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="ReceivedArchived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="ReceivedDeleted" />
                            <asp:ControlParameter ControlID="ddlStatusSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Status" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEstimateDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEstimateDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEstimateTotalFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="EstimateTotalFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEstimateTotalTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="EstimateTotalTo" Type="Decimal"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfCompanyEmail"/>
    <asp:HiddenField runat="server" ID="hfEstimateID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
</asp:Content>
