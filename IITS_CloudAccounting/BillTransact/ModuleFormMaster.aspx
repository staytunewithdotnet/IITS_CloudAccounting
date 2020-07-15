<%@ Page Title="Module Form Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ModuleFormMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ModuleFormMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .aspNetDisabled {
            float: none !important;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Form Management
                    </a>
                </li>
                <li>
                    <a href="ModuleFormMaster.aspx">Module Form Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Module Form Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Select Module:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlModule" CssClass="form-control text" TabIndex="1" DataSourceID="sqldsModule" DataTextField="ModuleName" DataValueField="ModuleID" />
                            <asp:SqlDataSource runat="server" ID="sqldsModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS ModuleID, '--Select Module--' AS ModuleName UNION SELECT [ModuleID], [ModuleName] FROM [ModuleMaster] WHERE ([ModuleStatus] = @ModuleStatus)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="ModuleStatus" Type="Boolean"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator runat="server" ID="rfvModule" ControlToValidate="ddlModule" ValidationGroup="ModuleForm" InitialValue="-1" SetFocusOnError="True" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <asp:GridView runat="server" ID="gvFormAdd" Width="100%" Font-Size="Small" AutoGenerateColumns="False"
                    CssClass="table table-bordered table-hover" DataKeyNames="FormID" DataSourceID="objdsForm">
                    <Columns>
                        <asp:BoundField DataField="FormID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="FormID"></asp:BoundField>
                        <asp:BoundField DataField="FormName" HeaderText="Form Name" SortExpression="FormName"></asp:BoundField>
                        <asp:TemplateField HeaderText="Add to Module">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkModuleForm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Records Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="objdsForm" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.FormMasterTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="2" CssClass="btn btn-primary" ValidationGroup="ModuleForm" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="3" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="ModuleForm" OnClick="btnUpdate_Click" />
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
                            Select Module:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblModule" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <asp:GridView runat="server" ID="gvFormView" Width="100%" Font-Size="Small" AutoGenerateColumns="False"
                    CssClass="table table-bordered table-hover" DataKeyNames="ModuleFormID" DataSourceID="objdsFormView">
                    <Columns>
                        <asp:BoundField DataField="ModuleFormID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ModuleFormID"></asp:BoundField>
                        <asp:BoundField DataField="ModuleFormName" HeaderText="Form Name" SortExpression="ModuleFormName"></asp:BoundField>
                        <asp:CheckBoxField DataField="ModuleFormStatus" HeaderText="Status" SortExpression="ModuleFormStatus"></asp:CheckBoxField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Records Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="objdsFormView" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByModuleID" TypeName="DABL.DAL.CloudAccountDATableAdapters.ModuleFormMasterTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfModuleID" PropertyName="Value" DefaultValue="0" Name="ModuleID" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="7" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="8" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="9" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="10" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvModuleForm" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="ModuleFormID" DataSourceID="sqldsModuleForm" PageSize="50" CssClass="table table-bordered table-hover"
                        OnSelectedIndexChanged="gvModuleForm_SelectedIndexChanged" OnPageIndexChanging="gvModuleForm_PageIndexChanging">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ModuleFormID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ModuleFormID" />
                            <asp:BoundField DataField="ModuleName" HeaderText="Name" SortExpression="ModuleName" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsModuleForm" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT MAX(mf.ModuleFormID) AS ModuleFormID,m.ModuleName FROM ModuleFormMaster mf INNER JOIN ModuleMaster m ON mf.ModuleID = m.ModuleID GROUP BY ModuleName ORDER BY ModuleFormID"></asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddModuleForm" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%--<asp:ObjectDataSource runat="server" ID="objdsModuleForm" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ModuleFormMasterTableAdapter"></asp:ObjectDataSource>--%>
    <asp:HiddenField runat="server" ID="hfModuleFormID" />
    <asp:HiddenField runat="server" ID="hfFormID" />
    <asp:HiddenField runat="server" ID="hfModuleID" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
</asp:Content>
