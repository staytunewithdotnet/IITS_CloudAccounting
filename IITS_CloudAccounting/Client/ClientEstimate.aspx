<%@ Page Title="Client Estimate" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="ClientEstimate.aspx.cs" Inherits="IITS_CloudAccounting.Client.ClientEstimate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var es = document.getElementById("estimateDiv");
            es.style.display = 'block';
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
                    <i class="fa fa-file-excel-o"></i>
                    <a href="#">Estimates
                    </a>
                </li>
                <li>
                    <a href="ClientEstimate.aspx">Estimate Master</a>
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
                    <asp:Button runat="server" ID="btnDispute" Text="Request Changes" CssClass="btn-danger" Style="padding: 7px;" OnClick="btnDispute_OnClick" />
                    <asp:Button runat="server" ID="btnAccept" Text="Accept" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnAccept_Click"/>
                    <a id="dlPdf" style="padding: 7px;text-decoration: none;cursor: pointer;" class="btn-danger">Generate PDF</a>
                    <input type="button" value="Print" id="btnPrint" style="padding: 7px;display: inline-block;" class="btn-warning printNone" onclick=" printDiv(); " />
                </div>
            </div>
            
            <div class="clearfix"></div>

            <div runat="server" id="disputeDiv" visible="True">
                <div class="col-lg-2">&nbsp;</div>
                <div class="col-lg-8 rounded-container peel-shadows" style="padding-left: 0;padding-right: 0;">
                    <div class="form-horizontal" id="disputeDivLabel" runat="server">
                        <h3 style="padding-left: 15px;padding-right: 15px;">Conversation History</h3>
                        <asp:DataList runat="server" ID="dlHistory" Width="100%" DataKeyField="EstimateDisputeHistoryID" DataSourceID="sqldsHistory" RepeatColumns="1" RepeatDirection="Vertical">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("EstimateDisputeHistoryID") %>' runat="server" ID="EstimateDisputeHistoryIDLabel" Visible="False" />
                                <asp:Label Text='<%# Eval("EstimateID") %>' runat="server" ID="EstimateIDLabel" Visible="False" />
                                <div class="col-lg-12 clearfix">
                                    <div class='<%# Eval("EstimateDisputeCreatedBy").ToString() != "Company"?"col-lg-2 float_left":"col-lg-2 float_right" %>' style="float: <%#Eval("EstimateDisputeCreatedBy").ToString() != "Company"?"left":"right"%>">
                                        <div id="Div1" class="client-icon-medium bg-system-light" runat="server" visible='<%# Eval("EstimateDisputeCreatedBy").ToString() != "Company" %>'></div>
                                        <div id="Div2" class="staff-icon-medium bg-system-light" runat="server" visible='<%# Eval("EstimateDisputeCreatedBy").ToString() == "Company" %>'></div>
                                    </div>
                                    <div class='<%# Eval("EstimateDisputeCreatedBy").ToString() != "Company"?"col-lg-10 float_left ta_left":"col-lg-10 float_right ta_right" %>'>
                                        <span class="dispute-bubble">
                                            <%# Eval("EstimateDisputeComments") %>
                                            <span class='<%# Eval("EstimateDisputeCreatedBy").ToString() != "Company"?"dispute-nib left":"dispute-nib right" %>'></span>
                                        </span>
                                        <div class="example">
                                            <asp:Label Text='<%# SetName(Eval("EstimateDisputeCreatedID").ToString(),Eval("EstimateDisputeCreatedBy").ToString()) %>' runat="server" ID="EstimateDisputeCreatedIDLabel" />,
                                            <asp:Label Text='<%# Eval("EstimateDisputeCommentDate","{0:"+dateFormat+"}") %>' runat="server" ID="EstimateDisputeCommentDateLabel" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:Label Visible='<%# dlHistory.Items.Count == 0 %>' Text="No Dispute History Found" CssClass="dispute-bubble" runat="server" ID="LabelFooter" />
                            </FooterTemplate>--%>
                        </asp:DataList>
                        <asp:SqlDataSource runat="server" ID="sqldsHistory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [EstimateDisputeHistory] WHERE ([EstimateID] = @EstimateID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfEstimateID" PropertyName="Value" DefaultValue="0" Name="EstimateID" Type="Int32"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <hr />
                    <div class="form-horizontal cutline-top" id="disputeDivText" runat="server" visible="False">
                        <h4 style="padding-left: 15px;padding-right: 15px;">Your Requested Changes</h4>
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
                                        <asp:Label runat="server" ID="lblEstimateTitle" Text="Estimate #"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblEstimateNum"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:Label runat="server" ID="lblEstimateTitleDate" Text="Estimate Date"></asp:Label>
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
                <div class="clearfix"></div>
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
                            <img style="height: 23px; margin-bottom: -1px; width: 56px;" alt="DoyinGo" src="../App_Themes/Doyingo/images/logo.jpg" />
                        </a>
                    </div>
                </div>

                <div class="clearfix"></div>

            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; display: inline-block; margin: 0; padding: 2%; width: 100%;">
                <h1 style="display: inline-block; margin: 0;">
                    Estimates
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvEstimate" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="EstimateID" DataSourceID="objdsEstimate"
                        AllowSorting="True" OnSorting="gvEstimate_Sorting" OnSelectedIndexChanged="gvEstimate_SelectedIndexChanged"
                        OnPageIndexChanging="gvEstimate_PageIndexChanging" GridLines="None" OnRowDataBound="gvEstimate_OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("EstimateID") %>' CssClass='<%#Eval("EstimateStatus") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estimate" SortExpression="EstimateNumber">
                                <ItemTemplate>
                                    <a href='<%# "ClientEstimate.aspx?cmd=view&ID=" + Eval("EstimateID") %>'>
                                        <%# Eval("EstimateNumber") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EstimateDate" HeaderText="Date" SortExpression="EstimateDate"></asp:BoundField>
                            <asp:BoundField DataField="EstimateTotal" HeaderText="Total" SortExpression="EstimateTotal" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblInvStatus" Text='<%# SetStatus(Eval("EstimateStatus").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="EstimateStatus" HeaderText="Status" SortExpression="EstimateStatus" />--%>
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
                        <strong>Estimate Totals:&nbsp;</strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;
                            <asp:Label runat="server" ID="lblCurCode"></asp:Label>
                        </span><br />
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsEstimate" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByClientID" TypeName="DABL.DAL.CloudAccountDATableAdapters.EstimateMasterTableAdapter">
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
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfEstimateID" />
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
</asp:Content>
