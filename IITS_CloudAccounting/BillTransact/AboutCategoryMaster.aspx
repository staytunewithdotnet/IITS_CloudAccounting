﻿<%@ Page Title="About Category Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="AboutCategoryMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AboutCategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">CMS Masters
                    </a>
                </li>
                <li>
                    <a href="AboutCategoryMaster.aspx">About Category Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit About Category Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Category Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAboutCategoryName" CssClass="form-control text" TabIndex="1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAboutCategoryName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="AboutCategoryName Reqiured" ControlToValidate="txtAboutCategoryName" ValidationGroup="AboutCategoryMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="2" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Description:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control text" TabIndex="3" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="4" CssClass="btn btn-primary" ValidationGroup="AboutCategoryMaster" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="5" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="7" CssClass="btn btn-primary" ValidationGroup="AboutCategoryMaster" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="8" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="6" CssClass="btn btn-info" OnClick="btnListAll_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Category Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAboutCategoryName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Description:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblDesc"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="10" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="11" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="12" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddAboutCategory_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvAboutCategory" AutoGenerateColumns="False" DataKeyNames="AboutCategoryID" DataSourceID="objdsAboutCategory" Width="100%"
                        OnSelectedIndexChanged="gvAboutCategory_SelectedIndexChanged" OnPageIndexChanging="gvAboutCategory_PageIndexChanging"
                        CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15">
                        <EmptyDataTemplate>
                                <div style="text-align: center; width: 100%;">
                                    No Records Found
                                </div>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="AboutCategoryID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="AboutCategoryID" />
                            <asp:BoundField DataField="AboutCategoryName" HeaderText="About Category" SortExpression="AboutCategoryID" />
                            <asp:BoundField DataField="AboutCategoryStatus" HeaderText="Status" SortExpression="AboutCategoryStatus" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddAboutCategory_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsAboutCategory" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.AboutCategoryMasterTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfAboutCategory" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
