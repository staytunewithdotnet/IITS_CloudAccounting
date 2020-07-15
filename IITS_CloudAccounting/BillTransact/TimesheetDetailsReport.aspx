<%@ Page Title="Timesheet Details Report" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="TimesheetDetailsReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TimesheetDetailsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <div class="row" style="margin-top: -45px;">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-download"></i>
                    <a href="AllReports.aspx">Reports
                    </a>
                </li>
                <li>
                    <a href="TimesheetDetailsReport.aspx">Timesheet Details</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Timesheet Details</h1>
            <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; float: right" class="btn-info">Generate PDF</a>
        </div>
        <div class="panel-body" style="background-color: #f1f1f1; margin-bottom: 20px;">
            <div class="col-lg-4" style="padding: 15px 0">
                <span class="control-label">Date Range:</span>
                <br />
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtDateFrom" Format="dd/MMM/yyyy" />
                </div>
                <div class="col-lg-1" style="padding: 8px 0 0 4px">to</div>
                <div class="col-lg-5" style="padding: 0">
                    <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control text"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtDateTo" Format="dd/MMM/yyyy" />
                </div>
            </div>
            <div class="col-lg-2" style="padding: 15px 0">
                <span class="control-label">Group By:</span>
                <asp:DropDownList runat="server" ID="ddlGroupBy" CssClass="form-control text">
                    <asp:ListItem Value="team" Selected="True">Team</asp:ListItem>
                    <asp:ListItem Value="client">Client</asp:ListItem>
                    <asp:ListItem Value="project">Project</asp:ListItem>
                    <asp:ListItem Value="task">Task</asp:ListItem>
                    <%--<asp:ListItem Value="week">Week</asp:ListItem>--%>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3" style="padding: 15px 0">
                <span class="control-label">Limit To:</span>
                <br />
                <div class="col-lg-6" style="padding: 0">
                    <asp:DropDownList runat="server" ID="ddlProject" CssClass="form-control text" DataSourceID="sqldsProject" DataTextField="ProjectName" DataValueField="ProjectID" />
                    <asp:SqlDataSource runat="server" ID="sqldsProject" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS ProjectID,'All' AS ProjectName UNION SELECT ProjectID,ProjectName From ProjectMaster WHERE CompanyID = @CompanyID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-lg-6" style="padding: 0">
                    <asp:DropDownList runat="server" ID="ddlTeam" CssClass="form-control text" DataSourceID="sqldsTeam" DataTextField="CompanyContactPerson" DataValueField="EntryFor" />
                    <asp:SqlDataSource runat="server" ID="sqldsTeam" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT EntryFor,b.CompanyContactPerson FROM TimesheetMaster a INNER JOIN CompanyMaster b ON a.EntryFor = b.CompanyEmail WHERE a.CompanyID = @CompanyID UNION SELECT DISTINCT EntryFor,b.FirstName+' '+b.LastName FROM TimesheetMaster a INNER JOIN StaffMaster b ON a.EntryFor = b.UserName WHERE a.CompanyID = @CompanyID UNION SELECT NULL,'Entire Team'">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <div class="col-lg-2" style="padding: 15px 0">
                <br />
                <asp:DropDownList runat="server" ID="ddlBilled" CssClass="form-control text">
                    <asp:ListItem Value="" Selected="True">All Hours</asp:ListItem>
                    <asp:ListItem Value="True">Billed Hours</asp:ListItem>
                    <asp:ListItem Value="False">Unbilled Hours</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-1" style="padding: 15px 0">
                <span class="control-label">&nbsp;</span><br />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" Style="width: 100% !important;" />
            </div>
        </div>
        <div id="printDiv" class="panel-body rounded-container peel-shadows" style="background-color: #fff !important; color: #000 !important;">
            <div class="col-lg-12" style="text-align: right">
                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/logo.jpg" style="height: 85px;width: 15%;" />
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center">
                <h1 style="margin-bottom: 0;">Timesheet Details
                    <asp:Label ID="lblGroup" runat="server"></asp:Label>
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 20px;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
            </div>
            <div class="clearfix"></div>
            <div runat="server" id="divGrids"></div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <div style="display: none">
        <asp:DropDownList runat="server" ID="ddlClient" DataSourceID="sqldsClient" DataTextField="OrganizationName" DataValueField="CompanyClientID" />
        <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CompanyClientID,OrganizationName FROM CompanyClientMaster a INNER JOIN ProjectMaster b ON a.CompanyClientID = b.ClientID WHERE a.CompanyID = @CompanyID UNION SELECT 0,'internal'">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList runat="server" ID="ddlTask" CssClass="form-control text" DataSourceID="sqldsTask" DataTextField="TaskName" DataValueField="TaskID" />
        <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT NULL AS TaskID,'All' AS TaskName UNION SELECT TaskID,TaskName From TaskMaster WHERE CompanyID = @CompanyID">
            <SelectParameters>
                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
