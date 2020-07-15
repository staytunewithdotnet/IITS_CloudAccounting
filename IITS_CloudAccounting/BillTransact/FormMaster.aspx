<%@ Page Title="Form Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="FormMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.FormMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Form Management
                    </a>
                </li>
                <li>
                    <a href="FormMaster.aspx">Form Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Form Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Form Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFormName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvFormName" ControlToValidate="txtFormName" ValidationGroup="FormMaster" SetFocusOnError="True" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="2" CssClass="btn btn-primary" ValidationGroup="FormMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="3" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="FormMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="6" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="4" CssClass="btn btn-info" OnClick="btnListAll_Click" />
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
                            Form Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFormName"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="7" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="8" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="9" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="10" CssClass="btn btn-primary" OnClick="btnAddForm_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvForm" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="FormID"
                        DataSourceID="objdsForm" OnSelectedIndexChanged="gvForm_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvForm_PageIndexChanging" CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="FormID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="FormID" />
                            <asp:BoundField DataField="FormName" HeaderText="Name" SortExpression="FormName" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddForm" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddForm_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfForm" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:ObjectDataSource runat="server" ID="objdsForm" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.FormMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
