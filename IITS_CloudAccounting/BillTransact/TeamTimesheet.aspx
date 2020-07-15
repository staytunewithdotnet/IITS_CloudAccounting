<%@ Page Title="Team Timesheets" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="TeamTimesheet.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TeamTimesheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var tt = document.getElementById("timeTrackingDiv");
            tt.style.display = 'block';
        });
    </script>
    <style>
        .gridTableNew.table > tbody > tr > th {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: center;
            vertical-align: middle;
        }

        .gridTableNew.table > tbody > tr :first-child > td > table.gridTableNew.table {
            margin: 0;
        }

        .gridTableNew.table > tbody > tr :first-child > td {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: center;
            vertical-align: middle;
        }

            .gridTableNew.table > tbody > tr:first-child > td:first-child {
                border: 0;
                padding: 0 !important;
            }

        .gridTableNew.table > tbody > tr > td:first-child {
            border-left: 1px solid #e5e5e5;
        }

        .gridTableNew.table > tbody > tr > td:hover {
            background-color: #0D83DD !important;
            color: #ffffff !important;
        }

        .gridTableNew.table > tbody > tr > td {
            border-bottom: 1px solid #e5e5e5;
            border-right: 1px solid #e5e5e5;
            font-weight: normal;
            line-height: 15px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: top;
        }

        .linkbutton {
            background-color: lightgray;
            border-radius: 5px;
            color: black;
            padding: 3px;
            text-decoration: none;
        }

            .linkbutton:hover {
                background-color: lightgray !important;
                color: black !important;
                text-decoration: none !important;
            }

        .myGridTable.table > tbody > tr > td {
            background-color: white;
            border: none;
        }

        .myGridTable.table > tbody > tr > th {
            background-color: #0D83DE;
            color: #ffffff;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
            border: none;
        }

        .myGridTable.table > tbody > tr:hover td {
            background-color: #e4f4fe!important;
        }

        .myGridTable.table > tbody > tr > td:nth-last-child(2), .myGridTable.table > tbody > tr > th:nth-last-child(2) {
            text-align: right;
        }

        .myGridTable.table > tbody > tr > td:last-child, .myGridTable.table > tbody > tr > th:last-child {
            text-align: center;
        }

        .myGridTable.table > tbody > tr > td {
            text-align: left;
            font-weight: normal;
            padding: 5px 5px !important;
            font-family: Verdana,sans-serif;
            font-size: 12px;
            line-height: 18px;
            color: #000;
            border-top: 1px solid #e2e2e2;
            word-wrap: break-word;
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
                    <a href="Timesheet.aspx">Timesheet</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:UpdatePanel runat="server" ID="upCalander">
            <ContentTemplate>
                <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                    <div class="form-horizontal" style="padding-left: 0; padding-right: 0;">
                        <div class="col-lg-8" style="background-color: #f1f1f1; border: 1px solid #ccc; border-radius: 5px; padding: 15px;">
                            <div class="col-lg-12" style="border-bottom: 1px solid #ccc; color: black; padding: 0 15px; margin-bottom: 15px;">
                                <h3>Hours Logged by
                                    <asp:Label runat="server" ID="lblTeamName"></asp:Label>
                                </h3>
                                <div class="col-lg-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">
                                                Team:
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:DropDownList runat="server" ID="ddlTeam" CssClass="form-control text" DataSourceID="sqldsTeam" DataTextField="Name" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_SelectedIndexChanged" />
                                                <asp:SqlDataSource runat="server" ID="sqldsTeam" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-1' AS ID,'- Whole Team -' AS Name UNION SELECT 'C' + CONVERT(varchar(5),CompanyID) AS ID, CompanyContactPerson AS Name FROM CompanyMaster WHERE CompanyID = @CompanyID UNION SELECT 'S' + CONVERT(varchar(5),StaffID) AS ID, LastName + ', ' + FirstName AS Name FROM StaffMaster WHERE CompanyID = @CompanyID ORDER BY Name">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">
                                                Project:
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:DropDownList runat="server" ID="ddlProject" CssClass="form-control text" DataSourceID="sqldsProject" OnSelectedIndexChanged="ddlProject_OnSelectedIndexChanged" DataTextField="ProjectName" DataValueField="ProjectID" AutoPostBack="True" />
                                                <asp:SqlDataSource runat="server" ID="sqldsProject" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '- All Projects -' AS ProjectName,-1 AS ProjectID UNION SELECT ProjectName,ProjectID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND (Active = 1 OR Archived = 1) AND Deleted = 0)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">&nbsp;</div>
                                            <div class="col-lg-9">
                                                <asp:TextBox runat="server" ID="t1" Style="visibility: hidden;" CssClass="form-control text"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">
                                                Task:
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:DropDownList runat="server" ID="ddlTask" CssClass="form-control text" AutoPostBack="True" OnSelectedIndexChanged="ddlTask_OnSelectedIndexChanged" DataSourceID="sqldsTask" DataTextField="TaskName" DataValueField="TaskID" />
                                                <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID, '- All Tasks -' AS TaskName UNION SELECT TaskMaster.TaskID, TaskMaster.TaskName FROM TaskMaster WHERE CompanyID = @CompanyID">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <span style="background-color: #f1f1f1; color: #777; font-size: 11px;">Select a team member, project and/or task to view logged hours below.</span>
                            </div>

                            <div style="display: inline-block; margin-bottom: 15px; width: 12%;">
                                <asp:LinkButton runat="server" ID="lnkPrevYear" Text="◄◄" CssClass="linkbutton" ToolTip="Prevoius Year" OnClick="lnkPrevYear_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkPrevMonth" Text="◄" CssClass="linkbutton" ToolTip="Prevoius Month" OnClick="lnkPrevMonth_Click"></asp:LinkButton>
                            </div>
                            <div style="display: inline-block; margin-bottom: 15px; text-align: center; width: 69%;">
                                <asp:Label runat="server" ID="lblTitle" Style="color: #000000; font-size: 18px; font-weight: 600;"></asp:Label>
                            </div>
                            <div style="display: inline-block; margin-bottom: 15px; text-align: right; width: 15%;">
                                <asp:LinkButton runat="server" ID="lnkNextMonth" Text="►" CssClass="linkbutton" ToolTip="Next Month" OnClick="lnkNextMonth_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkNextYear" Text="►►" CssClass="linkbutton" ToolTip="Next Year" OnClick="lnkNextYear_Click"></asp:LinkButton>
                            </div>
                            <asp:Calendar runat="server" ID="Calendar1" FirstDayOfWeek="Sunday" Width="100%" CssClass="gridTableNew table" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                                DayNameFormat="Short" Font-Names="Verdana" Font-Size="12px" ForeColor="#003399" Height="410px" OnSelectionChanged="Calendar1_OnSelectionChanged"
                                SelectedDate="<%# DateTime.Today %>" ShowTitle="False" Style="margin-bottom: 0" OnDayRender="Calendar1_OnDayRender">
                                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                <SelectedDayStyle BackColor="#0D83DD" BorderColor="#000000" BorderWidth="1px" ForeColor="#ffffff"></SelectedDayStyle>
                            </asp:Calendar>
                            <span style="background-color: #f1f1f1; color: #777; font-size: 11px;">* Select a day from the calendar to view more details.</span>

                            <div class="col-lg-12" style="border-top: 1px solid #ccc; color: black; padding: 15px 0 0; margin-top: 15px;">
                                <h3>
                                    <asp:Label runat="server" ID="lblInformation"></asp:Label>
                                </h3>
                                <asp:GridView runat="server" ID="gvTimeSheet" CssClass="myGridTable table table-striped table-responsive" GridLines="None"
                                    Width="100%" AutoGenerateColumns="False" DataKeyNames="TimesheetID" DataSourceID="objdsTimesheet"
                                    OnRowDataBound="gvTimeSheet_OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ProjectID" HeaderText="Project" SortExpression="ProjectID" ItemStyle-Width="15%"></asp:BoundField>
                                        <asp:BoundField DataField="TaskID" HeaderText="Task" SortExpression="TaskID" ItemStyle-Width="15%"></asp:BoundField>
                                        <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ItemStyle-Width="40%"></asp:BoundField>
                                        <asp:BoundField DataField="Hours" HeaderText="Hours" SortExpression="Hours" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="11%" HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkEdit" CssClass="permission" Text="edit" Visible='<%# bool.Parse(Eval("Unbilled").ToString()) %>' OnClick="lnkEdit_Click" CommandArgument='<%#Eval("TimesheetID") %>'></asp:LinkButton>
                                                <asp:Label runat="server" ID="lblBilled" Text="billed" Visible='<%# bool.Parse(Eval("Billed").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TimesheetID" HeaderText="TimesheetID" InsertVisible="False" ReadOnly="True" SortExpression="TimesheetID" Visible="False" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="panel-danger" style="text-align: center; width: 100%;">
                                            No hours logged on for selected date
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <div style="border-top: 2px solid #0D83DD; margin-top: -20px;" id="gridDiv" runat="server">
                                    <div class="col-lg-12" style="text-align: right; background-color: #fff; color: black; float: right; padding-bottom: 20px; padding-top: 10px; font-family: Verdana,sans-serif; font-size: 12px; line-height: 18px;">
                                        <div class="col-lg-10" style="font-size: 13px; font-weight: 600; border-top: 1px solid #e2e2e2;">
                                            Total for
                                        <asp:Label runat="server" ID="lblDivDate"></asp:Label>
                                            :
                                        </div>
                                        <div class="col-lg-2" style="text-align: left; font-size: 13px; font-weight: 600; border-top: 1px solid #e2e2e2;">
                                            <asp:Label runat="server" ID="lblTotalHours"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <asp:ObjectDataSource runat="server" ID="objdsTimesheet" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataBySearchParameter" TypeName="DABL.DAL.CloudAccountDATableAdapters.TimesheetMasterTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="hfTaskID" PropertyName="Value" ConvertEmptyStringToNull="True" Name="TaskID" Type="Int32"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="hfProjectID" PropertyName="Value" ConvertEmptyStringToNull="True" Name="ProjectID" Type="Int32"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="hfStaffID" ConvertEmptyStringToNull="True" PropertyName="Value" Name="EntryFor" Type="String"></asp:ControlParameter>
                                        <asp:ControlParameter ControlID="Calendar1" PropertyName="SelectedDate" DefaultValue="0" Name="TimesheetDate" Type="DateTime"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        <div class="col-lg-4 peel-shadows" style="color: black;padding: 0 0 0 5px;">
                            <div class="col-lg-12" style="border: 1px solid #ccc; border-bottom: 0; color: black; border-radius: 5px 5px 0 0; font-family: Verdana,sans-serif; font-size: 11px;">
                                <h5>Team Summary
                                </h5>
                                <div style="width: 45%; display: inline-block;">&nbsp;</div>
                                <div style="margin-bottom:7px;width: 25%; display: inline-block; word-break: normal; font-weight: bold;text-align: right;">Current Week</div>
                                <div style="width: 25%; display: inline-block; word-break: normal; font-weight: bold;text-align: right;">Current Month</div>
                                <div id="divName" runat="server" style="width: 45%; display: inline-block;"></div>
                                <div id="divHoursWeek" runat="server" style="width: 25%; display: inline-block;text-align: right;"></div>
                                <div id="divHoursMonth" runat="server" style="width: 25%; display: inline-block;text-align: right;"></div>
                                <br />
                                <br />
                                Current week:<br />
                                <asp:Label runat="server" ID="lblCurrentWeek"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <div class="col-lg-12" style="border: 1px solid #ccc; border-radius: 0 0 5px 5px;">
                                <h5>Reports</h5>
                                <ul style="list-style: none; padding: 0;">
                                    <li style="margin: 5px 0;">
                                        <a href="#" class="permission">Hours by team members</a>
                                    </li>
                                    <li style="margin: 5px 0;">
                                        <a href="#" class="permission">Project task summary</a>
                                    </li>
                                    <li style="margin: 5px 0;">
                                        <a href="#" class="permission">Timesheet details</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:GridView runat="server" ID="gvTemp" Visible="False" AutoGenerateColumns="False" DataSourceID="objdsTemp">
                    <Columns>
                        <asp:BoundField DataField="Hours" HeaderText="Hours" ReadOnly="True" SortExpression="Hours"></asp:BoundField>
                        <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" ReadOnly="True" SortExpression="EntryDate"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource runat="server" ID="objdsTemp" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.TimesheetGridMasterTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="hfTaskID" PropertyName="Value" ConvertEmptyStringToNull="True" Name="TaskID" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="hfProjectID" PropertyName="Value" ConvertEmptyStringToNull="True" Name="ProjectID" Type="Int32"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="hfStaffID" ConvertEmptyStringToNull="True" PropertyName="Value" Name="EntryFor" Type="String"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField runat="server" ID="hfCompanyID" />
                <asp:HiddenField runat="server" ID="hfProjectID" />
                <asp:HiddenField runat="server" ID="hfTaskID" />
                <asp:HiddenField runat="server" ID="hfStaffID" />
                <asp:GridView runat="server" ID="gvCurrentWeek" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsCurrentWeek">
                    <Columns>
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" ReadOnly="True" SortExpression="StartDate"></asp:BoundField>
                        <asp:BoundField DataField="EnddDate" HeaderText="EnddDate" ReadOnly="True" SortExpression="EnddDate"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsCurrentWeek" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DATEADD(week, DATEDIFF(day, 0, getDate())/7, -1) AS StartDate,DATEADD(week, DATEDIFF(day, 0, getDate())/7, 5) AS EnddDate
"></asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="col-lg-2">&nbsp;</div>

</asp:Content>
