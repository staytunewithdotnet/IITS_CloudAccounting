<%@ Page Title="Master Admin Rights Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MasterAdminRightsMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.MasterAdminRightsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <script type="text/javascript" language="javascript">
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
                    <a href="#">Master Admin Management
                    </a>
                </li>
                <li>
                    <a href="MasterAdminRightsMaster.aspx">Master Admin Rights Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Master Admin Rights Master</h1>
            </div>
        </div>
    </div>
    <asp:Panel ID="gridPanel" runat="server">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvMasterAdminUserRights" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="True" DataSourceID="SqdsEmprights" PageSize="50" AllowSorting="True" OnSorting="gvMasterAdminUserRights_Sorting"
                        OnSelectedIndexChanged="gvMasterAdminUserRights_SelectedIndexChanged" OnRowDataBound="gvMasterAdminUserRights_RowDataBound"
                        OnPageIndexChanged="gvMasterAdminUserRights_PageIndexChanged" CssClass="table table-bordered table-hover">
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
                            <asp:BoundField DataField="MasterAdminID" HeaderText="MasterAdmin" SortExpression="MasterAdminID" />
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblMasterAdminID" Text='<%# Eval("MasterAdminID") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="color: white; text-align: center;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="addPanel">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                MasterAdmin:
                            </div>
                            <div class="col-lg-9">
                                <asp:DropDownList runat="server" ID="ddlMasterAdmin" DataSourceID="sqldsMasterAdmin" CssClass="form-control text"
                                    DataTextField="UserName" DataValueField="MasterAdminUserID" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
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
                                <asp:DropDownList runat="server" ID="ddlModule" DataSourceID="sqldsModule" DataTextField="ModuleName"
                                    CssClass="form-control text" DataValueField="ModuleID" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" AutoPostBack="True" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:UpdatePanel runat="server" ID="upMainGrid" ChildrenAsTriggers="True">
                        <ContentTemplate>
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
                                            <asp:Label ID="lblUesrRightsID" runat="server" Text='<%#Eval("MasterAdminRightsID") %>'></asp:Label>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnReset" />
                        </Triggers>
                    </asp:UpdatePanel>
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
    </asp:Panel>
    <asp:HiddenField ID="hfMasterAdminRightsID" runat="server" />
    <asp:HiddenField ID="hfCompanyID" runat="server" />
    <asp:HiddenField ID="hfMasterAdminID" runat="server" />
    <asp:HiddenField runat="server" ID="hfDealerID" />

    <asp:SqlDataSource ID="SqdsEmprights" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="select row_number() OVER (ORDER BY MasterAdminID) AS RowNumber, MasterAdminID from MasterAdminRightsMaster group by MasterAdminID "></asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sqldsMasterAdmin" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT -1 AS MasterAdminUserID,'--Select MasterAdmin--' AS UserName UNION SELECT [MasterAdminUserID], [UserName] FROM [MasterAdminLoginMaster]"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsModule" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
        SelectCommand="SELECT 0 AS ModuleID, '--Select Module--' AS ModuleName UNION SELECT [ModuleID], [ModuleName] FROM [ModuleMaster]"></asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="sqldsForm" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT ModuleFormMaster.ModuleID, ModuleFormMaster.ModuleFormName, MasterAdminRightsMaster.MasterAdminRightsID,ModuleFormMaster.FormID,
 MasterAdminRightsMaster.AddMode, MasterAdminRightsMaster.EditMode, 
 MasterAdminRightsMaster.DeleteMode, MasterAdminRightsMaster.ViewMode 
 FROM ModuleFormMaster LEFT OUTER JOIN MasterAdminRightsMaster 
 ON ModuleFormMaster.ModuleID = MasterAdminRightsMaster.ModuleID WHERE (ModuleFormMaster.ModuleID = @ModuleID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlModule" DefaultValue="0" Name="ModuleID" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
