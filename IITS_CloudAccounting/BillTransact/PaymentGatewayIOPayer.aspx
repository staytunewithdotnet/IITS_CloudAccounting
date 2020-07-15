<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PaymentGatewayIOPayer.aspx.cs"
    Inherits="IITS_CloudAccounting.Admin.PaymentGatewayIOPayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">General Master
                    </a>
                </li>
                <li>
                    <a href="PaymentGatewayIOPayer.aspx">Payment Gateway IO Payer</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Payment Gateway  IO Payer Details</h1>
            </div>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Product ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtProductID" CssClass="form-control text" TabIndex="1" MaxLength="1000"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Product Code Reqiured" ControlToValidate="txtProductID" ValidationGroup="PaymentGatewayMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Merchant ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtMerchantID" CssClass="form-control text" TabIndex="2" MaxLength="1000"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Merchant Code Reqiured" ControlToValidate="txtMerchantID" ValidationGroup="PaymentGatewayMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Merchant Auth Key:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtMerchantAuthkey" CssClass="form-control text" MaxLength="1000" TabIndex="3" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Merchant Auth Reqiured" ControlToValidate="txtMerchantAuthkey" ValidationGroup="PaymentGatewayMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Transaction Type ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtTransactionTypeID" CssClass="form-control text" MaxLength="5" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Transaction Type Reqiured" ControlToValidate="txtTransactionTypeID" ValidationGroup="PaymentGatewayMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Transaction Auth key:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtTransactionAuthkey" CssClass="form-control text" MaxLength="1000" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Transaction Auth Name Reqiured" ControlToValidate="txtTransactionAuthkey" ValidationGroup="PaymentGatewayMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="6" CssClass="btn btn-primary" ValidationGroup="PaymentGatewayMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="7" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="9" CssClass="btn btn-primary" ValidationGroup="PaymentGatewayMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="10" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="8" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Product ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblProductID" Text="Code"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Merchant ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblMerchantID" Text="Code"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Merchant Auth key:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblMerchantAuthkey" Text="Name"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Transaction Type ID:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblTransactionTypeID" CssClass="text" Text="TransactionTypeID"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Transaction Auth key:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblTransactionAuthkey" Text="TransactionAuthkey" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="11" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="12" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="13" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="14" CssClass="btn btn-primary" OnClick="btnAddPaymentGateway_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvPaymentGateway" Width="100%" Font-Size="Small" AllowPaging="True"
                        AutoGenerateColumns="False" DataKeyNames="PaymentGatewayID"
                         OnSelectedIndexChanged="gvPaymentGateway_SelectedIndexChanged"
                        CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="PaymentGatewayID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="PaymentGatewayID" />
                            <asp:BoundField DataField="MerchantID" HeaderText="Merchant ID" SortExpression="MerchantID" />
                            <asp:BoundField DataField="MerchantAuthkey" HeaderText="Merchant Auth key" SortExpression="MerchantAuthkey" />
                            <asp:BoundField DataField="TransactionTypeID" HeaderText="Transaction Type ID" SortExpression="TransactionTypeID" />
                            <asp:BoundField DataField="TransactionAuthkey" HeaderText="Transaction Auth key" SortExpression="TransactionAuthkey" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddPaymentGateway" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddPaymentGateway_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:HiddenField runat="server" ID="hfPaymentGateway" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
</asp:Content>

