<%@ Page Title="Assign Staff To Client" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="AssignStaffClient.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AssignStaffClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .gridTable.table > tbody > tr > th:nth-child(2), .gridTable.table > tbody > tr > td:nth-child(2) {
            float: right;
            padding-left: 0 !important;
            padding-right: 0 !important;
        }

        .gridTable.table > tbody > tr > th {
            background-color: #0D83DE;
            color: #ffffff;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
            border: none;
        }

        .gridTable.table > tbody > tr > td {
            text-align: left;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
        }

        .gridTable.table > tbody > tr {
            border-bottom: 1px solid #ddd;
        }

        .leftTh {
            float: right;
            padding-left: 0 !important;
            padding-right: 0 !important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("peopleDiv");
            p.style.display = 'block';
        });

    </script>
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-users"></i>
                    <a href="#">People
                    </a>
                </li>
                <li>
                    <a href="AssignStaffClient.aspx">Assign Staff To Client</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your assignments have been saved.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlStaffToClient">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block;">Assign Staff To Client</h1>
                <span style="margin-left: 15px; font-size: 18px; font-family: monospace;">(</span>
                <a href="AssignStaffClient.aspx?staff_to_client=1" class="permission" style="font-size: 18px; font-family: monospace;">Assign Client To Staff</a>
                <span style="font-size: 18px; font-family: monospace;">)</span>
            </div>
            <div class="col-lg-8" style="padding-left: 0; padding-right: 0;">
                <asp:UpdatePanel runat="server" ID="upSTC">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-2" style="padding-right: 0; padding-top: 7px; font-weight: bold; color: black;">
                                    Clients:
                                </div>
                                <div class="col-lg-4" style="padding-left: 0; padding-right: 0;">
                                    <asp:DropDownList runat="server" ID="ddlClients" CssClass="form-control text" DataSourceID="sqldsClientDropdown"
                                        DataTextField="OrganizationName" DataValueField="CompanyClientID" AutoPostBack="True" OnSelectedIndexChanged="ddlClients_OnSelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="col-lg-11" style="padding-left: 0; padding-right: 0;">
                                <asp:GridView runat="server" ID="gvStaff" Width="100%" CssClass="table table-striped gridTable" DataSourceID="sqldsStaffGrid"
                                    AutoGenerateColumns="False" DataKeyNames="ID" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Assigned"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkAllStaff" Enabled="False" AutoPostBack="True" OnCheckedChanged="chkAllStaff_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkStaffID" Enabled="False" ToolTip='<%#Eval("ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center; width: 100%;">
                                            No Records Found
                                        </div>
                                    </EmptyDataTemplate>
                                    <RowStyle HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#0D83DE" Font-Names="Verdana" HorizontalAlign="Left" />
                                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="panel-body">
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:Button runat="server" ID="btnSaveStaff" CssClass="btn btn-success" Text="Save" OnClick="btnSaveStaff_OnClick" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlClientToStaff">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">Assign Client To Staff </h1>
                <span style="margin-left: 15px; font-size: 18px; font-family: monospace;">(</span>
                <a href="AssignStaffClient.aspx" class="permission" style="font-size: 18px; font-family: monospace;">Assign Staff To Client</a>
                <span style="font-size: 18px; font-family: monospace;">)</span>
            </div>
            <div class="col-lg-8" style="padding-left: 0; padding-right: 0;">
                <asp:UpdatePanel runat="server" ID="upCTS">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3" style="padding-right: 0; padding-top: 7px; font-weight: bold; color: black;">
                                    Staff Member:
                                </div>
                                <div class="col-lg-4" style="padding-left: 0; padding-right: 0;">
                                    <asp:DropDownList runat="server" ID="ddlStaff" CssClass="form-control text" DataSourceID="sqldsStaffDropDown" DataTextField="Name"
                                        DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlStaff_OnSelectedIndexChanged" />
                                </div>
                            </div>
                            <div class="col-lg-11" style="padding-left: 0; padding-right: 0;">
                                <asp:GridView runat="server" ID="gvClients" Width="100%" CssClass="table table-striped gridTable" DataSourceID="sqldsClientGrid"
                                    AutoGenerateColumns="False" DataKeyNames="CompanyClientID" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="OrganizationName" HeaderText="Clients" ReadOnly="True" SortExpression="OrganizationName"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Assigned"></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkAllClients" Enabled="False" AutoPostBack="True" OnCheckedChanged="chkAllClients_OnCheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkCompanyClientID" Enabled="False" ToolTip='<%#Eval("CompanyClientID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="text-align: center; width: 100%;">
                                            No Records Found
                                        </div>
                                    </EmptyDataTemplate>
                                    <RowStyle HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#0D83DE" Font-Names="Verdana" HorizontalAlign="Left" />
                                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="panel-body">
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:Button runat="server" ID="btnSaveClient" CssClass="btn btn-success" Text="Save" OnClick="btnSaveClient_OnClick" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="col-lg-4" style="border: 1px solid; border-radius: 10px;">
            <div class="panel-transparent">
                <h4>How Do Permissions Work?</h4>
                <p>Assigning a client to a staff member enables the staff member to:</p>
                <ul>
                    <li>View and edit client information</li>
                    <li>Create/update/view invoices for the client</li>
                    <li>Create projects specific to the client (depending on <a href="CompanyUserPermissions.aspx" class="permission">project access permissions</a>)</li>
                    <li>Create/update/view tickets for the client (depending on department restrictions)</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:SqlDataSource runat="server" ID="sqldsClientDropdown" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CompanyClientID,'- select a client -' AS OrganizationName UNION SELECT [CompanyClientID], (OrganizationName +'('+ LastName +','+ FirstName +')') AS OrganizationName FROM [CompanyClientMaster] WHERE CompanyID = @CompanyID AND (Active = 1 OR Archived = 1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsStaffGrid" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT (StaffID) AS ID,(LastName+','+FirstName) AS Name FROM StaffMaster WHERE CompanyID = @CompanyID AND (Active = 1 OR Archived = 1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsClientGrid" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [CompanyClientID], (OrganizationName +'('+ LastName +','+ FirstName +')') AS OrganizationName FROM [CompanyClientMaster] WHERE CompanyID = @CompanyID AND (Active = 1 OR Archived = 1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsStaffDropDown" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS ID,'- select a staff -' AS Name UNION SELECT (StaffID) AS ID,(LastName+','+FirstName) AS Name FROM StaffMaster WHERE CompanyID = @CompanyID AND (Active = 1 OR Archived = 1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
