<%@ Page Title="Project Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ProjectMasters.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ProjectMasters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var tt = document.getElementById("timeTrackingDiv");
            tt.style.display = 'block';
        });
    </script>
    <style>
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

        .xtab {
            color: black;
            background-color: #fff;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-clock-o"></i>
                    <a href="#">Time Tracking
                    </a>
                </li>
                <li>
                    <a href="ProjectMasters.aspx">Project Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your project has been created.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your project information has been updated.</h3>
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
                <h1>New Project </h1>
            </div>
            <div class="col-lg-12">
                <asp:UpdatePanel ID="upProject" runat="server">
                    <ContentTemplate>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Project Name
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="txtProjectName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvProjectName" ControlToValidate="txtProjectName" ValidationGroup="ProjectManager" ForeColor="Red" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Description
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="txtProjectDesc" TextMode="MultiLine" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Client
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text" TabIndex="3" DataSourceID="sqldsClient" AutoPostBack="True" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                                    <asp:CheckBox runat="server" ID="chkCanClient" Text="Client can see summaries of dates worked and tasks logged." Visible="False" />
                                    <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '0' AS ID,'- internal -' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID AND [CompanyClientID] IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="form-group" style="margin-bottom: 0;">
                                <div class="col-lg-3 control-label">
                                    Project Manager
                                </div>
                                <div class="col-lg-6">
                                    <asp:DropDownList runat="server" ID="ddlManager" CssClass="form-control text" TabIndex="4" DataSourceID="sqldsStaff" DataTextField="Name" DataValueField="ID" />
                                    <asp:SqlDataSource runat="server" ID="sqldsStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CONVERT(varchar(5),StaffID) AS ID,'You' AS Name FROM StaffMaster WHERE CompanyID = @CompanyID AND StaffID = @StaffID AND (Active = 1 OR Archived = 1) UNION SELECT 'C'+CONVERT(varchar(5),CompanyID),CompanyContactPerson FROM CompanyMaster WHERE CompanyID = @CompanyID UNION SELECT 'S'+CONVERT(varchar(5),StaffID) AS ID,(LastName+', '+FirstName) AS Name FROM StaffMaster WHERE CompanyID = @CompanyID AND StaffID != @StaffID AND (Active = 1 OR Archived = 1)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label"></div>
                                <div class="col-lg-9">
                                    Project manager can generate invoices, view team timesheets, and edit project details.
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Billing Method
                                </div>
                                <div class="col-lg-6">
                                    <asp:DropDownList runat="server" ID="ddlMethod" CssClass="form-control text" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlMethod_SelectedIndexChanged">
                                        <asp:ListItem Value="Hourly Staff Rate">Hourly Staff Rate</asp:ListItem>
                                        <asp:ListItem Value="Hourly Task Rate">Hourly Task Rate</asp:ListItem>
                                        <asp:ListItem Value="Hourly Project Rate">Hourly Project Rate</asp:ListItem>
                                        <asp:ListItem Value="Flat Project Amount">Flat Project Amount</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="hourlyRate" runat="server" visible="False">
                                <div class="form-group" style="margin-bottom: 0;">
                                    <div class="col-lg-3 control-label">
                                        Project Rate
                                    </div>
                                    <div class="col-lg-5">
                                        <asp:TextBox runat="server" ID="txtProjectRate" CssClass="form-control text" TabIndex="6" Style="width: 50% !important;"></asp:TextBox>
                                        per hour
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        Your project rate will apply to all hours logged to this project.
                                    </div>
                                </div>
                            </div>
                            <div id="flatAmount" runat="server" visible="False">
                                <div class="form-group" style="margin-bottom: 0;">
                                    <div class="col-lg-3 control-label">
                                        Flat Amount
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtFlatAmount" CssClass="form-control text" TabIndex="6" Style="width: 50% !important;"></asp:TextBox>
                                        flat amount
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        This is the flat amount for the entire project.
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Time Estimate
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="txtTimeEstimate" Text="0.00" CssClass="form-control text" TabIndex="7" Style="width: 50% !important;"></asp:TextBox>
                                    hour
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="clearfix"></div>

            <asp:UpdatePanel runat="server" ID="upTaskStaff">
                <ContentTemplate>
                    <div class="page-header" style="border-bottom: 5px solid #eee;">
                        <h1>Assigned Task </h1>
                    </div>

                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-2">&nbsp;</div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:GridView runat="server" ID="gvTask" Width="100%" Font-Size="Small" AllowPaging="False" AutoGenerateColumns="False"
                                    CssClass="table table-striped gridTable" DataSourceID="sqldsTask" DataKeyNames="TaskID" AllowSorting="True" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkTaskAll" AutoPostBack="True" OnCheckedChanged="chkTaskAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkTaskID" ToolTip='<%#Eval("TaskID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TaskName" HeaderText="Task Name"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Billable?">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblBillToClient" Text='<%# bool.Parse(Eval("BillToClient").ToString())?"Yes":"No" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [TaskID], [TaskName], [BillToClient] FROM [TaskMaster] WHERE CompanyID = @CompanyID AND  (([Active] = @Active) OR ([Archived] = @Archived) AND ([Deleted] = @Deleted))">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                        <asp:Parameter DefaultValue="True" Name="Active"></asp:Parameter>
                                        <asp:Parameter DefaultValue="True" Name="Archived"></asp:Parameter>
                                        <asp:Parameter DefaultValue="False" Name="Deleted"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div class="col-lg-2">&nbsp;</div>
                        </div>
                    </div>

                    <div class="page-header" style="border-bottom: 5px solid #eee;">
                        <h1>Team Members </h1>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-2">&nbsp;</div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:GridView runat="server" ID="gvUsers" Width="100%" CssClass="table table-striped gridTable" AutoGenerateColumns="False"
                                    DataSourceID="sqldsUser" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkUserAll" AutoPostBack="True" OnCheckedChanged="chkUserAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkUserID" ToolTip='<%#Eval("ID") %>' CssClass='<%#Eval("Role") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name"></asp:BoundField>
                                        <asp:BoundField DataField="Role" HeaderText="Role" ReadOnly="True" SortExpression="Role"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblRate" Text='<%# "₦"+Eval("Rate") + "/hr" %>' Visible='<%# Eval("Role").ToString()!="Admin" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                <asp:SqlDataSource runat="server" ID="sqldsUser" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CONVERT(varchar(5),StaffID) AS ID,'You' AS Name,BillingRate AS Rate,'Staff' AS Role FROM StaffMaster WHERE CompanyID = @CompanyID AND StaffID = @StaffID UNION SELECT CONVERT(varchar(5),StaffID) AS ID,(LastName+', '+FirstName) AS Name,BillingRate AS Rate,'Staff' AS Role FROM StaffMaster WHERE CompanyID = @CompanyID AND StaffID != @StaffID UNION SELECT 'C'+CONVERT(varchar(5),CompanyID) AS ID,CompanyContactPerson AS Name,0 AS Rate,'Admin' AS Role FROM CompanyMaster Where CompanyID = @CompanyID UNION SELECT 'Con'+CONVERT(varchar(5),ContractorID) AS ID,(ContractorName) AS Name,RebillRate AS Rate,'Contractor' AS Role FROM ContractorMaster WHERE CompanyID = @CompanyID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div class="col-lg-2">&nbsp;</div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="panel-body">
                <div class="col-lg-3">&nbsp;</div>
                <div class="col-lg-9">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success" Text="Save" ValidationGroup="ProjectMaster" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" Text="Save" ValidationGroup="ProjectMaster" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">
                    <asp:Label runat="server" ID="lblProjectName"></asp:Label>
                </h1>
                <div style="float: right; margin-bottom: 10px; margin-top: 20px;">
                    <asp:Button runat="server" ID="btnEdit" CssClass="btn-success" Text="Edit" OnClick="btnEdit_Click" />
                    <asp:Button runat="server" ID="btnAddNew" CssClass="btn-warning" Text="Add New" OnClick="btnAdd_Click" />
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-8">
                <div class=" rounded-container peel-shadows bg_systemcolor1">
                    <br />
                    <span class="col-lg-12" style="font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;">Hours For Team</span>
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="gvPersonTime" Width="100%" CssClass="gridTableNew table xtab" GridLines="None" DataSourceID="sqldsPersonTime" AutoGenerateColumns="True">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#0D83DD" Font-Names="Verdana" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsPersonTime" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="PR_ProjectMaster_SelectPersonTime" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <span class="col-lg-12" style="font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;">Hours By Task</span>
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="gvTaskTime" Width="100%" CssClass="gridTableNew table xtab" GridLines="None" DataSourceID="sqldsTaskTime" AutoGenerateColumns="True">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#0D83DD" Font-Names="Verdana" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsTaskTime" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="PR_ProjectMaster_SelectTaskTime" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <%--<span class="col-lg-12" style="font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;">Expenses</span>--%>
                    <br />
                    <br />
                </div>
            </div>
            <div class="col-lg-4">
                <div class=" rounded-container peel-shadows form-horizontal" style="padding: 15px;">
                    <div class="header-title cutline-bottom" style="border-bottom: 1px solid #d3d3d3; padding-bottom: 15px;">
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Project Billing Method</h4>
                        <asp:Label runat="server" ID="lblMethod"></asp:Label>
                        (<a id="aMethod" runat="server" class="permission">change</a>)
                    </div>
                    <div class="header-title cutline-top" style="border-bottom: 1px solid #d3d3d3; padding-bottom: 15px;">
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Project Budget</h4>
                        <div class="progress">
                            <div class="progress-bar progress-bar-striped active" id="divPro" runat="server"></div>
                        </div>
                        <asp:Label runat="server" ID="lblProDetails"></asp:Label>
                    </div>
                    <div class="header-title cutline-top" style="border-bottom: 1px solid #d3d3d3; padding-bottom: 15px;">
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Project Manager</h4>
                        <asp:Label runat="server" ID="lblManager"></asp:Label>
                    </div>
                </div>
                <asp:GridView runat="server" ID="gvBudget" Visible="False" AutoGenerateColumns="False" DataKeyNames="ProjectID" DataSourceID="sqldsBudget">
                    <Columns>
                        <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" ReadOnly="True" InsertVisible="False" SortExpression="ProjectID"></asp:BoundField>
                        <asp:BoundField DataField="TimeEstimate" HeaderText="TimeEstimate" SortExpression="TimeEstimate"></asp:BoundField>
                        <asp:BoundField DataField="Hours" HeaderText="Hours" ReadOnly="True" SortExpression="Hours"></asp:BoundField>
                        <asp:BoundField DataField="Estimate" HeaderText="Estimate" ReadOnly="True" SortExpression="Estimate"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsBudget" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT p.ProjectID,TimeEstimate,SUM(Hours) AS Hours,CONVERT(decimal(5,2),(SUM(Hours)*100)/TimeEstimate) AS Estimate FROM ProjectMaster p INNER JOIN TimesheetMaster t ON p.ProjectID = t.ProjectID WHERE p.ProjectID = @ProjectID GROUP BY p.ProjectID,TimeEstimate">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfProjectID" PropertyName="Value" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Project" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div class="col-lg-12" id="divSearch" style="padding: 10px; display: none; background-color: #f6f6f6; margin-bottom: 10px;">
                        <div id="closeSearch" class="close-button" style="cursor: pointer; background-color: blanchedalmond; padding: 10px; border-radius: 10px; overflow: visible;"></div>
                        <h3 style="margin: 10px auto 20px; text-align: center;">Search Box</h3>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Project Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtProjectSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Client
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtClientNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Task
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtTaskSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Description
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtDescriptionSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Team Menber
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtTeamMenberSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" style="display: none">
                                    <div class="col-lg-5" style="text-align: right">
                                        Invoice Created
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtInvoiceDateFrom" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtInvoiceDateFrom" />
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtInvoiceDateTo" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtInvoiceDateTo" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn-default" Style="padding: 5px; width: 100px" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button runat="server" ID="btnReset" CssClass="btn-default" Text="Reset" Style="padding: 5px; width: 100px" OnClientClick="ClearAllControls(); return false;" />
                        </div>
                    </div>
                    <div style="background-color: lightgray; padding: 10px;">
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvProject" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-hover" DataKeyNames="ProjectID" AllowSorting="True" OnSorting="gvProject_Sorting"
                        GridLines="None" OnPageIndexChanging="gvProject_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("ProjectID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Name">
                                <ItemTemplate>
                                    <a href='<%# "ProjectMasters.aspx?cmd=view&ID=" + Eval("ProjectID") %>'>
                                        <%#Eval("ProjectName") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="ProjectName" HeaderText="Project Name" SortExpression="ProjectName"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Client" SortExpression="Description">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblClient" Text='<%# GetClientName(Eval("ClientID").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TimeEstimate" HeaderText="Estimate" SortExpression="TimeEstimate"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="edit" Visible='<%# !bool.Parse(Eval("Deleted").ToString()) %>' CommandArgument='<%# Eval("ProjectID") %>' OnClick="lnkEdit_OnClick"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                    <div style="background-color: white; border-bottom: 1px solid lightgray; text-align: right;">
                        <a id="activeTag" runat="server" href="ProjectMasters.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="ProjectMasters.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="ProjectMasters.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsProject" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByProjectSearch" TypeName="DABL.DAL.CloudAccountDATableAdapters.ProjectMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtProjectSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ProjectName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtTaskSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Task" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDescriptionSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Description" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtTeamMenberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TeamMember" Type="String"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsProjectStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByProjectSearchStaff" TypeName="DABL.DAL.CloudAccountDATableAdapters.ProjectMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtProjectSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ProjectName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtTaskSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Task" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDescriptionSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Description" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtTeamMenberSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="TeamMember" Type="String"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:HiddenField runat="server" ID="hfProjectID" />
</asp:Content>
