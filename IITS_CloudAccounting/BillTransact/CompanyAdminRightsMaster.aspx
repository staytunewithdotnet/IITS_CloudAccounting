<%@ Page Title="Company Admin Rights Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyAdminRightsMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyAdminRightsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <script type="text/javascript">
        function OnClientClick() {
            var checking = false;
            debugger;
            var inputs = document.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked == true) {
                    checking = true;
                    break;
                }
            }
            if (!checking) {
                alert("Atleast one need to be selected");
                return false;
            }
            return true;
        }


        function UncheckAll() {
            var w = document.getElementsByTagName('input');
            for (var i = 0; i < w.length; i++) {
                if (w[i].type == 'checkbox') {
                    w[i].checked = false;
                }
            }
        }

    </script>
    <style>
        td span {
            float: none !important;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">Company Admin Management
                    </a>
                </li>
                <li>
                    <a href="CompanyAdminRightsMaster.aspx">Company Admin Rights Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Company Admin Rights Master</h1>
            </div>
        </div>
    </div>
    <asp:Panel ID="gridPanel" runat="server">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvCompanyAdminUserRights" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="True" PageSize="50" AllowSorting="True" OnSorting="gvCompanyAdminUserRights_Sorting"
                        OnSelectedIndexChanged="gvCompanyAdminUserRights_SelectedIndexChanged" OnRowDataBound="gvCompanyAdminUserRights_RowDataBound"
                        OnPageIndexChanged="gvCompanyAdminUserRights_PageIndexChanged" CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" SortExpression="RowNumber" ReadOnly="True" />
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID" />
                            <asp:BoundField DataField="CompanyAdminID" HeaderText="Company Admin" SortExpression="CompanyAdminID" />
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCompanyAdminID" Text='<%# Eval("CompanyAdminID") %>' Visible="False"></asp:Label>
                                    <asp:Label runat="server" ID="lblCompanyID" Text='<%# Eval("CompanyID") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="color: white; text-align: center;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="addPanel">
        <asp:UpdatePanel runat="server" ID="upMainGrid" ChildrenAsTriggers="True">
            <ContentTemplate>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Company:
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList runat="server" ID="ddlCompanyAdmin" DataSourceID="sqldsCompanyAdmin" CssClass="form-control text"
                                            DataTextField="CompanyName" DataValueField="CompanyID" OnSelectedIndexChanged="ddlCompanyAdmin_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Company Admin:
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList runat="server" ID="ddlCompanyLogin" CssClass="form-control text" DataSourceID="sqldsCompanyLogin"
                                            DataTextField="CompanyUserName" DataValueField="CompanyLoginID" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyAdmin_SelectedIndexChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Module:
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList runat="server" ID="ddlModule" DataSourceID="sqldsModule" DataTextField="ModuleName" AutoPostBack="True"
                                            CssClass="form-control text" DataValueField="ModuleID" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:GridView runat="server" ID="gvForm" Width="100%" AllowPaging="True" AutoGenerateColumns="False" PageSize="50"
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
                                    <asp:TemplateField HeaderText="Sr No." SortExpression="Number">
                                        <ItemTemplate>
                                            <%# Container.DisplayIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UesrRightsID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUesrRightsID" runat="server" Text='<%#Eval("CompanyAdminRightsID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FormID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFormID" runat="server" Text='<%#Eval("FormID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ModuleID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleID" runat="server" Text='<%#Eval("ModuleID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Form Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFormName" runat="server" Text='<%#Eval("ModuleFormName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Add">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkAdd" Checked='<%#Eval("AddMode").ToString() != "False" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkEdit" Checked='<%#Eval("EditMode").ToString() != "False" %>'
                                                OnCheckedChanged="chkEdit_CheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkDelete" Checked='<%#Eval("DeleteMode").ToString() != "False" %>'
                                                OnCheckedChanged="chkDelete_CheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkView" Checked='<%#Eval("ViewMode").ToString() != "False" %>'
                                                OnCheckedChanged="chkView_CheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-lg-12" style="color: white; text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClientClick=" return OnClientClick() " OnClick="btnSubmit_Click" />
                        <input id="btnReset" runat="server" class="btn btn-default" type="button" value="Reset" onclick="UncheckAll();" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-info" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="hfCompanyAdminRightsID" runat="server" />
    <asp:HiddenField ID="hfCompanyID" runat="server" />
    <asp:HiddenField ID="hfCompanyAdminID" runat="server" />
    <asp:HiddenField runat="server" ID="hfPackageID" />

    <asp:SqlDataSource ID="sqldscmpRights" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="select row_number() OVER (ORDER BY CompanyAdminID) AS RowNumber, CompanyID, CompanyAdminID from CompanyAdminRightsMaster group by CompanyAdminID,CompanyID"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sqldsOnlyCompanyRights" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="select row_number() OVER (ORDER BY CompanyAdminID) AS RowNumber, CompanyID, CompanyAdminID from CompanyAdminRightsMaster where CompanyID = @CompanyID group by CompanyAdminID,CompanyID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" Name="CompanyID" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sqldsCompanyAdmin" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT - 1 AS CompanyID, '--Select Company--' AS CompanyName UNION SELECT CompanyID, CompanyName FROM CompanyMaster"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCompanyLogin" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CompanyLoginID, '--Select Company Admin--' AS CompanyUserName UNION SELECT [CompanyLoginID], [CompanyUserName] FROM [CompanyLoginMaster] WHERE ([CompanyID] = @CompanyID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCompanyAdmin" PropertyName="SelectedValue" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsModule" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT 0 AS ModuleID, '--Select Module--' AS ModuleName UNION SELECT b.ModuleID,b.ModuleName FROM PackageDetails a INNER JOIN ModuleMaster b ON a.ModuleID = b.ModuleID WHERE PackageID = @PackageID AND a.ModuleStatus = 1">
        <SelectParameters>
            <asp:SessionParameter SessionField="PackageID" DefaultValue="0" Name="PackageID" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sqldsForm" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT ModuleFormMaster.ModuleID, ModuleFormMaster.ModuleFormName, CompanyAdminRightsMaster.CompanyAdminRightsID,ModuleFormMaster.FormID,
 CompanyAdminRightsMaster.AddMode, CompanyAdminRightsMaster.EditMode, 
 CompanyAdminRightsMaster.DeleteMode, CompanyAdminRightsMaster.ViewMode 
 FROM ModuleFormMaster LEFT OUTER JOIN CompanyAdminRightsMaster 
 ON ModuleFormMaster.ModuleID = CompanyAdminRightsMaster.ModuleID WHERE (ModuleFormMaster.ModuleID = @ModuleID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlModule" DefaultValue="0" Name="ModuleID" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
