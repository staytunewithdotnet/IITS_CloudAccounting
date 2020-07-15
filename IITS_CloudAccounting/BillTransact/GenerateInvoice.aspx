<%@ Page Title="Generate Invoice" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="GenerateInvoice.aspx.cs" Inherits="IITS_CloudAccounting.Admin.GenerateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var tt = document.getElementById("timeTrackingDiv");
            tt.style.display = 'block';
        });
    </script>
    <style>
        .invbody-items {
            width: 100%;
            margin-bottom: 12px;
        }

            .invbody-items thead {
                font-weight: bold;
                page-break-after: avoid;
            }

            .invbody-items th.first {
                border-left: solid 1px #c7c7c7;
                width: 25%;
            }

            .invbody-items th {
                background-color: #e3e3e3;
                line-height: normal;
                border-top: solid 1px #c7c7c7;
                border-bottom: solid 1px #c7c7c7;
                vertical-align: top;
            }

            .invbody-items thead .item {
                border-left: solid 1px #f1f1f1;
                border-top: solid 1px #f1f1f1;
                padding-left: 5px;
                text-align: left;
            }

            .invbody-items th div {
                padding: 5px 0;
            }

            .invbody-items thead .description {
                border-top: solid 1px #f1f1f1;
                text-align: left;
            }

            .invbody-items tbody {
                page-break-before: avoid;
                vertical-align: top;
            }

            .invbody-items td {
                vertical-align: top;
                padding: 3px 0 3px 2px;
            }

        .form-horizontal .radio {
            padding-top: 3px;
        }

        input[type=checkbox], input[type=radio] {
            margin: 10px 6px 6px 0;
        }

        .activeRadio {
            background-color: #f2f2f2;
            font-family: Verdana, sans-serif;
        }

        .boldmenow {
            font-weight: bold;
        }

            .boldmenow > label {
                font-family: Verdana, sans-serif;
                font-weight: bold;
                font-size: 14px;
                margin-top: 5px;
            }
    </style>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoices
                    </a>
                </li>
                <li>
                    <a href="GenerateInvoice.aspx">Generate Invoice</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="padding: 0;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>Generate Invoice</h1>
            </div>
            <div class="panel-body" style="padding: 15px 0;">

                <asp:UpdatePanel runat="server" ID="upInvoice" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div class="form-horizontal" style="color: black;">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Date Rnage(optional)
                                </div>
                                <div class="col-lg-5">
                                    <div class="col-lg-6" style="padding-left: 0; padding-right: 3px;">
                                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control text" OnTextChanged="txtStartDate_OnTextChanged" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceStartDate" TargetControlID="txtStartDate" Format="MMM/dd/yyyy" />
                                    </div>
                                    <div class="col-lg-6" style="padding-left: 3px; padding-right: 0;">
                                        <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control text" AutoPostBack="True" OnTextChanged="txtEndDate_OnTextChanged"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceEndDate" TargetControlID="txtEndDate" Format="MMM/dd/yyyy" />
                                    </div>
                                </div>
                                <div class="col-lg-4">&nbsp;</div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Client</div>
                                <div class="col-lg-5">
                                    <asp:DropDownList runat="server" ID="ddlClient" AutoPostBack="True" CssClass="form-control text" DataSourceID="sqldsClient" DataTextField="OrganizationName" DataValueField="CompanyClientID" />
                                    <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT 0 AS CompanyClientID,'-internal-' AS OrganizationName FROM ProjectMaster WHERE ClientID = (SELECT TOP 1 ClientID FROM ProjectMaster WHERE CompanyID = @CompanyID AND ClientID = 0) UNION SELECT CompanyClientID,OrganizationName FROM CompanyClientMaster WHERE CompanyID = @CompanyID AND CompanyClientID IN (SELECT ClientID FROM ProjectMaster WHERE CompanyID = @CompanyID)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-lg-4">&nbsp;</div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Add Unbilled Time</div>
                                <div class="col-lg-5">
                                    <asp:CheckBoxList runat="server" ID="cblProjects" AutoPostBack="True" OnSelectedIndexChanged="cblProjects_OnSelectedIndexChanged" RepeatColumns="1" DataSourceID="sqldsProjects" DataTextField="ProjectName" DataValueField="ProjectID" />
                                    <%--<asp:SqlDataSource runat="server" ID="sqldsProjects" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT ProjectID,ProjectName FROM ProjectMaster WHERE CompanyID = @CompanyID AND ClientID = @ClientID">SELECT -1 AS ProjectID,'All Projects' AS ProjectName UNION --%>
                                    <asp:SqlDataSource runat="server" ID="sqldsProjects" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT p.ProjectID,ProjectName + ' (Unbilled hours: '+ CONVERT(nvarchar(10),Sum(Hours)) + ' )' AS ProjectName FROM ProjectMaster p INNER JOIN TimesheetMaster t ON p.ProjectID = t.ProjectID WHERE p.CompanyID = @CompanyID AND ClientID = @ClientID and Unbilled = 1 GROUP BY p.ProjectID,ProjectName">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            <asp:ControlParameter ControlID="ddlClient" PropertyName="SelectedValue" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div class="col-lg-4">&nbsp;</div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Format Time Entries</div>
                                <div class="col-lg-9" style="padding-right: 0;">
                                    <div class="col-lg-4 activeRadio" id="radioDetailed" runat="server">
                                        <asp:RadioButton runat="server" ID="rbDetailed" CssClass="boldmenow" AutoPostBack="True" OnCheckedChanged="rbDetailed_OnCheckedChanged" GroupName="TimeEntries" Text="Detailed" Checked="True"></asp:RadioButton>
                                        <label for='<%=rbDetailed.ClientID%>' style="padding-left: 20px; text-align: justify;">
                                            <span>Make each time entry appear as a single line item.</span>
                                        </label>
                                    </div>
                                    <div class="col-lg-4" id="radioGrouped" runat="server">
                                        <asp:RadioButton runat="server" ID="rbGroupped" CssClass="boldmenow" AutoPostBack="True" OnCheckedChanged="rbDetailed_OnCheckedChanged" GroupName="TimeEntries" Text="Groupped" />
                                        <label for='<%=rbGroupped.ClientID%>' style="padding-left: 20px; text-align: justify;">
                                            <span>Group time entries by team member, task, or both.</span>
                                        </label>
                                    </div>
                                    <div class="col-lg-4" id="radioSingleLine" runat="server">
                                        <asp:RadioButton runat="server" ID="rbSingleLine" CssClass="boldmenow" AutoPostBack="True" OnCheckedChanged="rbDetailed_OnCheckedChanged" GroupName="TimeEntries" Text="Single Line" />
                                        <label for='<%=rbSingleLine.ClientID%>' style="padding-left: 20px; text-align: justify;">
                                            <span>Merge all time entries into one single line item.</span>
                                        </label>
                                    </div>

                                    <div class="col-lg-12 activeRadio" style="padding: 18px 0 18px 20px;" id="divDetailed" runat="server" visible="True">
                                        <div class="col-lg-9" style="border-radius: 10px; border: 1px solid #c7c7c7; background: #fff; padding: 10px 0 10px 10px; float: left;">
                                            <h5 style="margin: .25em 0 .75em; color: #999; font: 14px normal Helvetica,helv,arial,Verdana,sans-serif;">Preview</h5>
                                            <table class="invbody-items">
                                                <tr>
                                                    <th class="first">
                                                        <div class="item">Task</div>
                                                    </th>
                                                    <th colspan="2">
                                                        <div class="description">Time Entry Notes</div>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblTaskDetail" Text="Design"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblProjectDetailed" Text="[Bill Transact Website Concept]" Visible="True"></asp:Label>
                                                        <asp:Label runat="server" ID="lblEntryDateDetailed" Visible="True"><%= "[" + DateTime.Now.ToString("MM/dd/yyyy") + "]"%></asp:Label>
                                                        <asp:Label runat="server" ID="lblTeamMemberDetailed" Text="John Smithington" Visible="True"></asp:Label>
                                                        <asp:Label runat="server" ID="lblNotesDetailed" Text=": homepage revisions" Visible="True"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-lg-3" style="padding-right: 0;">
                                            <b>Include:</b><br />
                                            <asp:CheckBox runat="server" ID="chkProjectDetailed" Text="Project" Checked="True" AutoPostBack="True" OnCheckedChanged="chkProjectDetailed_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkTaskNameDetailed" Text="Task Name" Checked="True" AutoPostBack="True" OnCheckedChanged="chkTaskNameDetailed_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkTeamMemberDetailed" Text="Team Member" Checked="True" AutoPostBack="True" OnCheckedChanged="chkTeamMemberDetailed_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkEntryDateDetailed" Text="Entry Date" Checked="True" AutoPostBack="True" OnCheckedChanged="chkEntryDateDetailed_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkNotesDetailed" Text="Notes" Checked="True" AutoPostBack="True" OnCheckedChanged="chkNotesDetailed_OnCheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 activeRadio" style="padding: 18px 0 18px 20px;" id="divGrouped" runat="server" visible="False">
                                        <div class="col-lg-9" style="border-radius: 10px; border: 1px solid #c7c7c7; background: #fff; padding: 10px 0 10px 10px; float: left;">
                                            <h5 style="margin: .25em 0 .75em; color: #999; font: 14px normal Helvetica,helv,arial,Verdana,sans-serif;">Preview</h5>
                                            <table class="invbody-items">
                                                <tr>
                                                    <th class="first">
                                                        <div class="item">Task</div>
                                                    </th>
                                                    <th colspan="2">
                                                        <div class="description">Time Entry Notes</div>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblTaskGrouped" Text="Design"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblProjectGrouped" Text="[Bill Transact Website Concept]" Visible="True"></asp:Label>
                                                        <asp:Label runat="server" ID="lblDateRange" Visible="True">
                                                            <%= "[" + DateTime.Now.ToString("MM/dd/yyyy") + " to " + DateTime.Now.AddDays(7).ToString("MM/dd/yyyy") + "]" %>
                                                        </asp:Label>
                                                        <asp:Label runat="server" ID="lblTeamMemberGrouped" Text="John Smithington" Visible="True"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-lg-3" style="padding-right: 0;">
                                            <b>Include:</b><br />
                                            <asp:CheckBox runat="server" ID="chkProjectGrouped" Text="Project" Checked="True" AutoPostBack="True" OnCheckedChanged="chkProjectGrouped_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkTaskNameGrouped" Text="Task Name" Checked="True" AutoPostBack="True" OnCheckedChanged="chkTaskNameGrouped_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkTeamMemberGrouped" Text="Team Member" Checked="True" AutoPostBack="True" OnCheckedChanged="chkTeamMemberGrouped_OnCheckedChanged" />
                                            <br />
                                            <asp:CheckBox runat="server" ID="chkDateRangeGrouped" Text="Date Range" Checked="True" AutoPostBack="True" OnCheckedChanged="chkDateRangeGrouped_OnCheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 activeRadio" style="padding: 18px 0 18px 20px;" id="divSingleLine" runat="server" visible="False">
                                        <div class="col-lg-9" style="border-radius: 10px; border: 1px solid #c7c7c7; background: #fff; padding: 10px 0 10px 10px; float: left;">
                                            <h5 style="margin: .25em 0 .75em; color: #999; font: 14px normal Helvetica,helv,arial,Verdana,sans-serif;">Preview</h5>
                                            <table class="invbody-items">
                                                <tr>
                                                    <th class="first">
                                                        <div class="item">Task</div>
                                                    </th>
                                                    <th colspan="2">
                                                        <div class="description">Time Entry Notes</div>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblSingleLine">
                                                            [Bill Transact Website Concept <%= DateTime.Now.ToString("MM/dd/yyyy") + " to " + DateTime.Now.AddDays(7).ToString("MM/dd/yyyy") + "]" %>
                                                        </asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-lg-3" style="padding-right: 0;">&nbsp;</div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Add Expenses</div>
                                <div class="col-lg-5">
                                    <asp:RadioButtonList runat="server" ID="rblAddExpense">
                                        <asp:ListItem Value="all" Selected="True">All unbilled expenses for this client</asp:ListItem>
                                        <asp:ListItem Value="projects" Enabled="False">Only expenses for selected projects</asp:ListItem>
                                        <asp:ListItem Value="none">No expenses</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-lg-4">&nbsp;</div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button runat="server" ID="btnSave" Text="Create Invoice" CssClass="btn-success btn-lg" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>
