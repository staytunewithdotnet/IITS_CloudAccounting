<%@ Page Title="Timesheet Report" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="TimesheetReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TimesheetReport" %>

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
                    <a href="ProjectUserReport.aspx">Timesheets</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1 style="display: inline-block">Timesheets</h1>
            <a id="dlPdf" style="padding: 7px; text-decoration: none; cursor: pointer; float: right" class="btn-info">Generate PDF</a>
        </div>
        <div class="panel-body" style="background-color: #f1f1f1; margin-bottom: 20px;">
            <div class="col-lg-4">
                <span class="control-label">Select Month/year:</span>
                <br />
                <div class="col-lg-5" style="padding: 0">
                    <asp:DropDownList runat="server" ID="ddlMonth" CssClass="form-control text">
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1" style="padding: 8px 0 0 4px">to</div>
                <div class="col-lg-5" style="padding: 0">
                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control text" />
                </div>
            </div>
            <div class="col-lg-3">
                <span class="control-label">Team members:</span>
                <asp:DropDownList runat="server" ID="ddlTeam" CssClass="form-control text" DataSourceID="sqldsTeam" DataTextField="CompanyContactPerson" DataValueField="EntryFor" />
                <asp:SqlDataSource runat="server" ID="sqldsTeam" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DISTINCT EntryFor,b.CompanyContactPerson FROM TimesheetMaster a INNER JOIN CompanyMaster b ON a.EntryFor = b.CompanyEmail WHERE a.CompanyID = @CompanyID UNION SELECT DISTINCT EntryFor,b.FirstName+' '+b.LastName FROM TimesheetMaster a INNER JOIN StaffMaster b ON a.EntryFor = b.UserName WHERE a.CompanyID = @CompanyID UNION SELECT NULL,'Entire Team'">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-2">
                <span class="control-label">&nbsp;</span>
            </div>
            <div class="col-lg-3">
                <span class="control-label">&nbsp;</span><br />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdateClick" Style="width: 50% !important;" />
            </div>
        </div>
        <div id="printDiv" class="panel-body rounded-container peel-shadows" style="background-color: #fff !important; color: #000 !important;">
            <div class="col-lg-12" style="text-align: right">
                <asp:Image runat="server" ID="imgLogo" ImageUrl="../App_Themes/Doyingo/images/logo.jpg" style="height: 85px;width: 15%;" />
            </div>
            <div class="clearfix"></div>
            <div class="col-lg-12" style="text-align: center">
                <h1 style="margin-bottom: 0;">Timesheets
                </h1>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                </h4>
                <h4 style="font-weight: normal; margin-bottom: 0;">
                    <asp:Label runat="server" ID="lblInfo"></asp:Label>
                </h4>
                <h5 style="font-weight: normal; margin-bottom: 20px; margin-top: 20px;">This report shows all of the team timesheet entries in a calendar format
                </h5>
            </div>
            <div class="clearfix"></div>
            <div runat="server" id="divGrids"></div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
