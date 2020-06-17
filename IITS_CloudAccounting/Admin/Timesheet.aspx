<%@ Page Title="Timesheet" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="IITS_CloudAccounting.Admin.Timesheet" %>

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
    <asp:UpdatePanel runat="server" ID="upButton">
        <ContentTemplate>
            <div class="col-lg-8" style="padding: 0;">
                <asp:Button runat="server" ID="btnMonthly" Text="Monthly" CssClass="btn-success" Style="padding: 7px;" OnClick="btnMonthly_OnClick" />
                <asp:Button runat="server" ID="btnWeekly" Text="Weekly" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnWeekly_OnClick" />
                <asp:Button runat="server" ID="btnDaily" Text="Daily" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnDaily_OnClick" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-lg-2">&nbsp;</div>
    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="background-color: #f1f1f1; border: 1px solid #ccc; border-radius: 0 5px 5px 5px; padding: 15px;">
        <asp:UpdatePanel runat="server" ID="upCalander" ChildrenAsTriggers="True">
            <ContentTemplate>
                <%--<div class="col-lg-12" style="padding: 10px; background-color: #fff; margin-bottom: 10px; margin-top: -15px;">
                    <asp:Button runat="server" ID="btnMonthly" Text="Monthly" CssClass="btn-success" Style="padding: 7px;" OnClick="btnMonthly_OnClick" />
                    <asp:Button runat="server" ID="btnWeekly" Text="Weekly" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnWeekly_OnClick" />
                    <asp:Button runat="server" ID="btnDaily" Text="Daily" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnDaily_OnClick" />
                </div>--%>
                <asp:Panel runat="server" ID="pnlMonthly" Visible="True">
                    <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                        <div class="form-horizontal" style="padding-left: 0; padding-right: 0;">
                            <div class="col-lg-8" style="padding: 0">
                                <div style="display: inline-block; margin-bottom: 15px; width: 14%;">
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
                                    SelectedDate="<%# DateTime.Today %>" ShowTitle="False" OnDayRender="Calendar1_DayRender" Style="margin-bottom: 0">
                                    <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                    <SelectedDayStyle BackColor="#0D83DD" BorderColor="#000000" BorderWidth="1px" ForeColor="#ffffff"></SelectedDayStyle>
                                </asp:Calendar>
                                <span style="background-color: #f1f1f1; color: #777; font-size: 11px;">* Select a day from the calendar to view more details.</span>
                            </div>
                            <div class="col-lg-4">
                                <h3 style="color: black; margin-top: 5px;">Log Hours:
                                <asp:Label runat="server" ID="lblDate"></asp:Label>
                                    <asp:Label runat="server" ID="lblTime" Visible="False"></asp:Label>
                                </h3>
                                <div class="panel-body">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Project:
                                            <span style="color: red">*</span>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvProject" Display="Dynamic" ForeColor="red" ControlToValidate="ddlProject" InitialValue="-1" SetFocusOnError="True" ValidationGroup="Timesheet"></asp:RequiredFieldValidator>
                                            </span>
                                            <br />
                                            <asp:DropDownList runat="server" ID="ddlProject" CssClass="form-control text" OnSelectedIndexChanged="ddlProject_OnSelectedIndexChanged" DataTextField="ProjectName" DataValueField="ProjectID" AutoPostBack="True" />
                                            <asp:SqlDataSource runat="server" ID="sqldsProject" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT '    › ' + ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND (Active = 1 OR Archived = 1) AND Deleted = 0) UNION SELECT '-internal-',-1,0 UNION SELECT OrganizationName,-1,CompanyClientMaster.CompanyClientID FROM CompanyClientMaster inner join ProjectMaster on CompanyClientMaster.CompanyClientID = ProjectMaster.ClientID WHERE CompanyClientMaster.CompanyID = @CompanyID ORDER BY ClientID,ProjectID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:SqlDataSource runat="server" ID="sqldsProjectStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT '    › ' + ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND [ProjectID] IN (SELECT ProjectID FROM StaffProjectDetail WHERE StaffID = @StaffID) AND (Active = 1 OR Archived = 1) AND Deleted = 0) UNION SELECT '-internal-',-1,0 UNION SELECT OrganizationName,-1,CompanyClientMaster.CompanyClientID FROM CompanyClientMaster inner join ProjectMaster on CompanyClientMaster.CompanyClientID = ProjectMaster.ClientID WHERE CompanyClientMaster.CompanyID = @CompanyID AND [ProjectID] IN (SELECT ProjectID FROM StaffProjectDetail WHERE StaffID = @StaffID) ORDER BY ClientID,ProjectID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                        <div class="form-group">
                                            <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Task:
                                            <span style="color: red">*</span>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvTask" Display="Dynamic" ForeColor="red" ControlToValidate="ddlTask" InitialValue="-1" SetFocusOnError="True" ValidationGroup="Timesheet"></asp:RequiredFieldValidator>
                                            </span>
                                            <br />
                                            <asp:DropDownList runat="server" ID="ddlTask" CssClass="form-control text" DataSourceID="sqldsTask" DataTextField="TaskName" DataValueField="TaskID" />
                                            <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID, '' AS TaskName UNION SELECT TaskMaster.TaskID, TaskMaster.TaskName FROM ProjectTaskDetails INNER JOIN TaskMaster ON ProjectTaskDetails.TaskID = TaskMaster.TaskID WHERE (ProjectTaskDetails.ProjectID = @ProjectID) AND (ProjectTaskDetails.CompanyID = @CompanyID)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlProject" PropertyName="SelectedValue" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                        <div class="form-group">
                                            <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Hours:</span>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtHours" CssClass="form-control text" onkeypress="return decimalValue(this,event);" />
                                        </div>
                                        <div class="form-group">
                                            <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Notes:</span>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" CssClass="form-control text" MaxLength="500" />
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-body" style="text-align: center" id="btnsa" runat="server">
                                    <asp:Button runat="server" ID="btnSave" Text="Log Hours" CssClass="btn btn-success" OnClick="btnSave_Click" Style="padding: 10px; width: 80%;" ValidationGroup="Timesheet" />
                                </div>
                                <div class="panel-body" style="text-align: center" id="btnup" runat="server" visible="False">
                                    <asp:Button runat="server" ID="btnUpdate" Text="Save Changes" CssClass="btn btn-success" OnClick="btnUpdate_Click" Style="padding: 10px; width: 100%;" ValidationGroup="Timesheet" />
                                    or
                                <asp:LinkButton runat="server" ID="lnkCancel" Text="cancel" CssClass="permission" OnClick="lnkCancel_OnClick"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlWeekly" Visible="False">
                    <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                        <div class="form-horizontal" style="padding-left: 0; padding-right: 0;">
                            <div class="col-lg-12" style="padding: 0">
                                <div style="display: inline-block; margin-bottom: 15px; width: 22%;">
                                    <asp:LinkButton runat="server" ID="lnkPrevYear1" Text="◄◄" CssClass="linkbutton" ToolTip="Prevoius Year" OnClick="lnkPrevYear1_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkPrevMonth1" Text="◄" CssClass="linkbutton" ToolTip="Prevoius Month" OnClick="lnkPrevMonth1_Click"></asp:LinkButton>
                                </div>
                                <div style="display: inline-block; margin-bottom: 15px; text-align: center; width: 55%;">
                                    <asp:Label runat="server" ID="lblTitle1" Style="color: #000000; font-size: 18px; font-weight: 600;"></asp:Label>
                                </div>
                                <div style="display: inline-block; margin-bottom: 15px; text-align: right; width: 22%;">
                                    <asp:LinkButton runat="server" ID="lnkNextMonth1" Text="►" CssClass="linkbutton" ToolTip="Next Month" OnClick="lnkNextMonth1_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkNextYear1" Text="►►" CssClass="linkbutton" ToolTip="Next Year" OnClick="lnkNextYear1_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <asp:GridView runat="server" ID="gvWeeklyTime" CssClass="gridTableNew table" Width="100%" OnRowDataBound="gvWeeklyTime_OnRowDataBound"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Project">
                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlProject1" DataTextField="ProjectName" DataValueField="ProjectID" AutoPostBack="True" />
                                                <asp:SqlDataSource runat="server" ID="sqldsProject1" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND (Active = 1 OR Archived = 1) AND Deleted = 0)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:SqlDataSource runat="server" ID="sqldsProjectStaff1" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND [ProjectID] IN (SELECT ProjectID FROM StaffProjectDetail WHERE StaffID = @StaffID) AND (Active = 1 OR Archived = 1) AND Deleted = 0)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                        <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task">
                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlTask1" DataSourceID="sqldsTask1" DataTextField="TaskName" DataValueField="TaskID" />
                                                <asp:SqlDataSource runat="server" ID="sqldsTask1" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID, '' AS TaskName UNION SELECT TaskMaster.TaskID, TaskMaster.TaskName FROM ProjectTaskDetails INNER JOIN TaskMaster ON ProjectTaskDetails.TaskID = TaskMaster.TaskID WHERE (ProjectTaskDetails.ProjectID = @ProjectID) AND (ProjectTaskDetails.CompanyID = @CompanyID)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlProject1" PropertyName="SelectedValue" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt1" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt2" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt3" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt4" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt5" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt6" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt7" onkeypress="return decimalValue(this,event);" Text="0" Style="text-align: right;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Button runat="server" ID="btnAdd" Text="Add line" CssClass="btn-warning" Style="padding: 7px;" OnClick="btnAdd_OnClick" />
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="panel-body" style="text-align: center">
                                        <asp:Button runat="server" ID="btnSave3" Text="Log Hours" CssClass="btn btn-success" Style="padding: 10px;" OnClick="btnSave3_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlDaily" Visible="False">
                    <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                        <div class="form-horizontal" style="padding-left: 0; padding-right: 0;">
                            <div class="col-lg-4" style="padding: 0">
                                <div style="display: inline-block; margin-bottom: 15px; width: 22%;">
                                    <asp:LinkButton runat="server" ID="lnkPrevYear2" Text="◄◄" CssClass="linkbutton" ToolTip="Prevoius Year" OnClick="lnkPrevYear2_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkPrevMonth2" Text="◄" CssClass="linkbutton" ToolTip="Prevoius Month" OnClick="lnkPrevMonth2_Click"></asp:LinkButton>
                                </div>
                                <div style="display: inline-block; margin-bottom: 15px; text-align: center; width: 53%;">
                                    <asp:Label runat="server" ID="lblTitle2" Style="color: #000000; font-size: 18px; font-weight: 600;"></asp:Label>
                                </div>
                                <div style="display: inline-block; margin-bottom: 15px; text-align: right; width: 22%;">
                                    <asp:LinkButton runat="server" ID="lnkNextMonth2" Text="►" CssClass="linkbutton" ToolTip="Next Month" OnClick="lnkNextMonth2_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkNextYear2" Text="►►" CssClass="linkbutton" ToolTip="Next Year" OnClick="lnkNextYear2_Click"></asp:LinkButton>
                                </div>
                                <asp:Calendar runat="server" ID="Calendar2" FirstDayOfWeek="Sunday" Width="100%" CssClass="gridTableNew table" BackColor="White"
                                    BorderWidth="0" CellPadding="1" DayNameFormat="Short" Font-Names="Verdana" Font-Size="12px" ForeColor="#003399" Height="210px"
                                    OnSelectionChanged="Calendar2_OnSelectionChanged" ShowTitle="False" Style="margin-bottom: 0" OnDayRender="Calendar2_DayRender">
                                    <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                    <SelectedDayStyle BackColor="#0D83DD" BorderColor="#000000" BorderWidth="1px" ForeColor="#ffffff"></SelectedDayStyle>
                                </asp:Calendar>
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <h3 style="color: black; margin-top: 5px;">Log Hours:
                                <asp:Label runat="server" ID="lblDate2"></asp:Label>
                                </h3>
                                <div class="panel-body">
                                    <div class="col-lg-6">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Project:
                                            <span style="color: red">*</span>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvProject2" Display="Dynamic" ForeColor="red" ControlToValidate="ddlProject2" InitialValue="-1" SetFocusOnError="True" ValidationGroup="Timesheet2"></asp:RequiredFieldValidator>
                                                </span>
                                                <br />
                                                <asp:DropDownList runat="server" ID="ddlProject2" CssClass="form-control text" OnSelectedIndexChanged="ddlProject_OnSelectedIndexChanged" DataTextField="ProjectName" DataValueField="ProjectID" AutoPostBack="True" />
                                                <asp:SqlDataSource runat="server" ID="sqldsProject2" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT '    › ' + ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND (Active = 1 OR Archived = 1) AND Deleted = 0) UNION SELECT '-internal-',-1,0 UNION SELECT OrganizationName,-1,CompanyClientMaster.CompanyClientID FROM CompanyClientMaster inner join ProjectMaster on CompanyClientMaster.CompanyClientID = ProjectMaster.ClientID WHERE CompanyClientMaster.CompanyID = @CompanyID ORDER BY ClientID,ProjectID">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:SqlDataSource runat="server" ID="sqldsProjectStaff2" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS ProjectName,-2 AS ProjectID,-2 AS ClientID UNION SELECT '    › ' + ProjectName,ProjectID,ClientID FROM ProjectMaster WHERE ([CompanyID] = @CompanyID AND [ProjectID] IN (SELECT ProjectID FROM StaffProjectDetail WHERE StaffID = @StaffID) AND (Active = 1 OR Archived = 1) AND Deleted = 0) UNION SELECT '-internal-',-1,0 UNION SELECT OrganizationName,-1,CompanyClientMaster.CompanyClientID FROM CompanyClientMaster inner join ProjectMaster on CompanyClientMaster.CompanyClientID = ProjectMaster.ClientID WHERE CompanyClientMaster.CompanyID = @CompanyID AND [ProjectID] IN (SELECT ProjectID FROM StaffProjectDetail WHERE StaffID = @StaffID) ORDER BY ClientID,ProjectID">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                        <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                            <div class="form-group">
                                                <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Task:
                                            <span style="color: red">*</span>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvTask2" Display="Dynamic" ForeColor="red" ControlToValidate="ddlTask2" InitialValue="-1" SetFocusOnError="True" ValidationGroup="Timesheet2"></asp:RequiredFieldValidator>
                                                </span>
                                                <br />
                                                <asp:DropDownList runat="server" ID="ddlTask2" CssClass="form-control text" DataSourceID="sqldsTask2" DataTextField="TaskName" DataValueField="TaskID" />
                                                <asp:SqlDataSource runat="server" ID="sqldsTask2" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID, '' AS TaskName UNION SELECT TaskMaster.TaskID, TaskMaster.TaskName FROM ProjectTaskDetails INNER JOIN TaskMaster ON ProjectTaskDetails.TaskID = TaskMaster.TaskID WHERE (ProjectTaskDetails.ProjectID = @ProjectID) AND (ProjectTaskDetails.CompanyID = @CompanyID)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlProject2" PropertyName="SelectedValue" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </div>
                                            <div class="form-group">
                                                <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Hours:</span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtHours2" CssClass="form-control text" onkeypress="return decimalValue(this,event);" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <span style="color: black; font-family: Verdana, sans-serif; font-size: 12px; font-weight: 600;">Notes:</span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtNotes2" TextMode="MultiLine" CssClass="form-control text" MaxLength="500" />
                                            </div>
                                            <div class="form-group">
                                                <div class="panel-body" style="text-align: center">
                                                    <asp:Button runat="server" ID="btnSave2" Text="Log Hours" CssClass="btn btn-success" OnClick="btnSave2_OnClick" Style="padding: 10px; width: 80%;" ValidationGroup="Timesheet2" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div class="clearfix"></div>
                <br />
                <hr style="border-color: #CCCCCC; margin: 5px 0 10px; padding: 0; width: 101.5%;">
                <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                    <div class="form-horizontal" style="padding-left: 0; padding-right: 0;">
                        <div class="col-lg-12" style="margin-bottom: 15px; padding-left: 0; padding-right: 0;">
                            <asp:Button runat="server" ID="btnDelete" Text="Delete Forever" OnClientClick="return confirm('Are you sure you want to delete these hours?');" OnClick="btnDelete_Click" Style="background-color: #a1a1a1; color: #ffffff; font-size: 13px; font-weight: normal; height: 22px; padding: 2px 9px;" />
                            <asp:Button runat="server" ID="btnMarkBill" Text="Mark as Billed" OnClick="btnMarkBill_Click" Style="background-color: #a1a1a1; color: #ffffff; font-size: 13px; font-weight: normal; height: 22px; padding: 2px 9px;" />
                            <asp:Button runat="server" ID="btnMarkUnBill" Text="Mark as UnBilled" OnClick="btnMarkUnBill_Click" Style="background-color: #a1a1a1; color: #ffffff; font-size: 13px; font-weight: normal; height: 22px; padding: 2px 9px;" />
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                            <asp:GridView runat="server" ID="gvTimeSheet" CssClass="myGridTable table table-striped table-responsive" GridLines="None"
                                Width="100%" AutoGenerateColumns="False" DataKeyNames="TimesheetID" OnRowDataBound="gvTimeSheet_OnRowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkID" ToolTip='<%# Eval("TimesheetID") %>' CssClass='<%# bool.Parse(Eval("Billed").ToString())?"billed":"unbilled" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                    <div class="col-lg-10" style="margin-bottom: 5px;">
                                        Billed:
                                    </div>
                                    <div class="col-lg-2" style="text-align: left;">
                                        <asp:Label runat="server" ID="lblBilledHours"></asp:Label>
                                    </div>
                                    <div class="col-lg-10" style="margin-bottom: 5px;">
                                        Unbilled:
                                    </div>
                                    <div class="col-lg-2" style="text-align: left;">
                                        <asp:Label runat="server" ID="lblUnbilledHours"></asp:Label>
                                    </div>
                                    <div class="col-lg-10" style="font-size: 13px; font-weight: 600; border-top: 1px solid #e2e2e2;">
                                        Total for
                                        <asp:Label runat="server" ID="lblDivDate"></asp:Label>
                                        <asp:Label runat="server" ID="lblDivDate1"></asp:Label>
                                        :
                                    </div>
                                    <div class="col-lg-2" style="text-align: left; font-size: 13px; font-weight: 600; border-top: 1px solid #e2e2e2;">
                                        <asp:Label runat="server" ID="lblTotalHours"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <asp:ObjectDataSource runat="server" ID="objdsTimesheet" OldValuesParameterFormatString="original_{0}" TypeName="DABL.DAL.CloudAccountDATableAdapters.TimesheetMasterTableAdapter"></asp:ObjectDataSource>
                            <asp:ObjectDataSource runat="server" ID="objdsTimesheetRange" OldValuesParameterFormatString="original_{0}" TypeName="DABL.DAL.CloudAccountDATableAdapters.TimesheetMasterTableAdapter"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>
                <asp:HiddenField runat="server" ID="hfTimesheetID" />
                <asp:GridView runat="server" ID="gvTemp" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsTemp">
                    <Columns>
                        <asp:BoundField DataField="Hours" HeaderText="Hours" ReadOnly="True" SortExpression="Hours"></asp:BoundField>
                        <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" ReadOnly="True" SortExpression="EntryDate"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsTemp" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(Hours) AS Hours,CAST(TimesheetDate AS DATE) AS EntryDate FROM TimesheetMaster where CompanyID = @CompanyID AND EntryFor = @EntryFor GROUP BY CAST(TimesheetDate AS DATE)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="hfEntryFor" PropertyName="Value" DefaultValue="0" Name="EntryFor"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:HiddenField runat="server" ID="hfEntryFor" />

</asp:Content>
