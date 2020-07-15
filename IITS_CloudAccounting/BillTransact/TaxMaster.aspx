<%@ Page Title="Tax Master" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="TaxMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TaxMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="TaxMaster.aspx">Taxes</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your tax has been created.</h3>
                <ul style="color: black; font-size: 13px; font-family: Verdana;">
                    <li>
                        <a href="InvoiceMasterNew.aspx" class="permission">Create an invoice</a> for this client.
                    </li>
                    <li>
                        <a href="EstimateMaster.aspx" class="permission">Create an estimate</a> for this client.
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your tax has been updated.</h3>
                <ul style="color: black; font-size: 13px; font-family: Verdana;">
                    <li>
                        <a href="InvoiceMasterNew.aspx" class="permission">Create an invoice </a>for this client.
                    </li>
                    <li>
                        <a href="EstimateMaster.aspx" class="permission">Create an estimate </a>for this client.
                    </li>
                </ul>
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
                <h1>Taxes</h1>
                Need to charge your clients tax? Customize your taxes here and reuse them on your future invoices and expenses.
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="col-lg-12">
                        <div class="col-lg-4">
                            Name<span style="color: red">*</span>
                        </div>
                        <div class="col-lg-2">
                            Rate
                        </div>
                        <div class="col-lg-1">&nbsp;</div>
                        <div class="col-lg-5">
                            Number/ID
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-group">
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtTaxName" CssClass="form-control text" TabIndex="1" MaxLength="50" Style="width: 94.7% !important;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTaxName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtTaxName" ValidationGroup="TaxMaster">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-2" style="padding-right: 0;">
                            <asp:TextBox runat="server" ID="txtTaxRate" CssClass="form-control text" TabIndex="2" MaxLength="50" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                        </div>
                        <div class="col-lg-1" style="padding-left: 0; font-size: 18px; font-family: Verdana; color: black;">
                            %
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox runat="server" ID="txtTaxNumber" CssClass="form-control text" TabIndex="3" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--<div class="col-lg-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Name<span style="color: red">*</span>
                            </div>
                            <div class="col-lg-6">
                                
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Rate
                            </div>
                            <div class="col-lg-4">
                                &nbsp; %
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Number/ID
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" TabIndex="4" Text="Save" ValidationGroup="TaxMaster" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" TabIndex="5" Text="Save" ValidationGroup="TaxMaster" OnClick="btnUpdate_Click" />
                    <asp:Button runat="server" ID="btnSaveAdd" CssClass="btn btn-red" TabIndex="6" Text="Add Another Tax" ValidationGroup="TaxMaster" Style="width: 30%" OnClick="btnSaveAdd_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>View Taxes</h1>
                Need to charge your clients tax? Customize your taxes here and reuse them on your future invoices and expenses.
            </div>
            <div class="panel-body">
                <div class="col-lg-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Name
                            </div>
                            <div class="col-lg-4">
                                <asp:Label runat="server" ID="lblTaxName"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Rate
                            </div>
                            <div class="col-lg-2">
                                <asp:Label runat="server" ID="lblTaxRate"></asp:Label>&nbsp; %
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-4 control-label">
                                Number/ID
                            </div>
                            <div class="col-lg-6">
                                <asp:Label runat="server" ID="lblTaxNumber"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Taxes</h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Tax" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvTax" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-hover" DataSourceID="objdsTax" DataKeyNames="TaxID"
                        AllowSorting="True" OnSorting="gvTax_Sorting" GridLines="None" OnSelectedIndexChanged="gvTax_SelectedIndexChanged"
                        OnPageIndexChanging="gvTax_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="TaxID" HeaderText="ID" SortExpression="TaxID" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="TaxName" HeaderText="Name" SortExpression="TaxName"></asp:BoundField>
                            <asp:BoundField DataField="TaxRate" HeaderText="Rate" SortExpression="TaxRate"></asp:BoundField>
                            <asp:BoundField DataField="TaxNumber" HeaderText="Number/ID" SortExpression="TaxNumber"></asp:BoundField>
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
                    <asp:ObjectDataSource runat="server" ID="objdsTax" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.TaxMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfTaxID" />

</asp:Content>
