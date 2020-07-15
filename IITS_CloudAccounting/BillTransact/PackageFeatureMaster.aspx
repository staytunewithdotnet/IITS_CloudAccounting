<%@ Page Title="Package Feature Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="PackageFeatureMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PackageFeatureMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">Package Management
                    </a>
                </li>
                <li>
                    <a href="PackageFeatureMaster.aspx">Package Feature Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Package Feature Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Select Package Module:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlPackageModule" TabIndex="2" CssClass="form-control text"
                                DataSourceID="sqldsPackageModule" DataTextField="PackageModuleName" DataValueField="PackageModuleID" />
                            <asp:SqlDataSource runat="server" ID="sqldsPackageModule"
                                ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                SelectCommand="SELECT - 1 AS PackageModuleID, '--Select PackageModule--' AS PackageModuleName UNION SELECT [PackageModuleID], [PackageModuleName] FROM [PackageModuleMaster] where(PackageModuleStatus='True')"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvPackageModuleName" runat="server" SetFocusOnError="True" ControlToValidate="ddlPackageModule" ForeColor="red"
                                ErrorMessage="Select PackageModule" InitialValue="-1" ValidationGroup="PackageFeatureMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Feature Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtName" TabIndex="3" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="PackageFeature Name Reqiured" ControlToValidate="txtName" ValidationGroup="PackageFeatureMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Feature Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDesc" TabIndex="4" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Feature Status:
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="6" CssClass="btn btn-primary" ValidationGroup="PackageFeatureMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="7" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="9" CssClass="btn btn-primary" ValidationGroup="PackageFeatureMaster" OnClick="btnUpdate_Click" />
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
                            Select Package Module:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageModule"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Feature Name:
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
                            Package Feature Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblDesc"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Feature Status:
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
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="14" CssClass="btn btn-primary" OnClick="btnAddPackageFeature_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvPackageFeature" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="PackageFeatureID"
                        DataSourceID="objdsPackageFeature" OnSelectedIndexChanged="gvPackageFeature_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvPackageFeature_PageIndexChanging" OnRowDataBound="gvPackageFeature_RowDataBound" CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="PackageFeatureID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="PackageFeatureID" />
                            <asp:BoundField DataField="PackageModuleID" HeaderText="Package Module" SortExpression="PackageModuleID" />
                            <asp:BoundField DataField="PackageFeatureName" HeaderText="Name" SortExpression="PackageFeatureName" />
                            <asp:BoundField DataField="PackageFeatureDesc" HeaderText="Description" SortExpression="PackageFeatureDesc" />
                            <asp:BoundField DataField="PackageFeatureStatus" HeaderText="Status" SortExpression="PackageFeatureStatus" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddPackageFeature" runat="server" TabIndex="1" Text="Add" CssClass="btn btn-primary" OnClick="btnAddPackageFeature_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfPackageFeature" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
    <asp:ObjectDataSource runat="server" ID="objdsPackageFeature" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.PackageFeatureMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
