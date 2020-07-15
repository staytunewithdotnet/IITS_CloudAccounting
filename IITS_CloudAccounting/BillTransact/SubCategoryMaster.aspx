<%@ Page Title="Sub Category Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="SubCategoryMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.SubCategoryMaster" %>

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
                    <a href="SubCategoryMaster.aspx">SubCategory Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit SubCategory Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Select Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlCategory" TabIndex="1" CssClass="form-control text"
                                DataSourceID="sqldsCategory" DataTextField="CategoryName" DataValueField="CategoryID" />
                            <asp:SqlDataSource runat="server" ID="sqldsCategory"
                                ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                SelectCommand="SELECT - 1 AS CategoryID, '[choose one]' AS CategoryName UNION SELECT [CategoryID], [CategoryName] FROM [CategoryMaster] where(CategoryStatus='True')"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" SetFocusOnError="True" ControlToValidate="ddlCategory" ForeColor="red"
                                ErrorMessage="Select Category" InitialValue="-1" ValidationGroup="SubCategoryMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtCode" TabIndex="2" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="SubCategory Code Reqiured" ControlToValidate="txtCode" ValidationGroup="SubCategoryMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtName" TabIndex="3" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="SubCategory Name Reqiured" ControlToValidate="txtName" ValidationGroup="SubCategoryMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDesc" TabIndex="4" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="5" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="6" CssClass="btn btn-primary" ValidationGroup="SubCategoryMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="7" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="9" CssClass="btn btn-primary" ValidationGroup="SubCategoryMaster" OnClick="btnUpdate_Click" />
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
                            Select Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCategory"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCode"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblName"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblDesc"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            SubCategory Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="14" CssClass="btn btn-primary" OnClick="btnAddSubCategory_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                        <asp:GridView runat="server" ID="gvSubCategory" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="SubCategoryID"
                            DataSourceID="objdsSubCategory" OnSelectedIndexChanged="gvSubCategory_SelectedIndexChanged" PageSize="50"
                            OnPageIndexChanging="gvSubCategory_PageIndexChanging" OnRowDataBound="gvSubCategory_RowDataBound" CssClass="table table-bordered table-hover">
                            <EmptyDataTemplate>
                                <div style="text-align: center; width: 100%;">
                                    No Records Found
                                </div>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="SubCategoryID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="SubCategoryID" />
                                <asp:BoundField DataField="CategoryID" HeaderText="Category" SortExpression="CategoryID" />
                                <asp:BoundField DataField="SubCategoryCode" HeaderText="Code" SortExpression="SubCategoryCode" />
                                <asp:BoundField DataField="SubCategoryName" HeaderText="Name" SortExpression="SubCategoryName" />
                                <asp:BoundField DataField="SubCategoryDesc" HeaderText="Description" SortExpression="SubCategoryDesc" />
                                <asp:BoundField DataField="SubCategoryStatus" HeaderText="Status" SortExpression="SubCategoryStatus" />
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddSubCategory" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddSubCategory_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfSubCategory" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
    <asp:ObjectDataSource runat="server" ID="objdsSubCategory" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.SubCategoryMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
