<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="IITS_CloudAccounting.Client.Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("timeTrackingDiv");
            p.style.display = 'block';
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
                    <a href="#">Projects
                    </a>
                </li>
                <li>
                    <a href="Projects.aspx">Project
                    </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">

        <asp:Panel runat="server" ID="pnlView" Style="color: black;">
            <div class="page-header" style="border-bottom: 5px solid #eee; display: inline-block; margin: 0; padding: 2%; width: 100%;">
                <h1 style="display: inline-block; margin: 0;">Hours Logged To:
                    <asp:Label runat="server" ID="lblProject"></asp:Label>
                </h1>
            </div>

            <div class="col-lg-9" style="margin-top: 25px; padding-left: 0">
                <div class=" rounded-container peel-shadows" style="padding: 0 15px">
                    <h3>Tasks</h3>
                    <asp:GridView runat="server" ID="gvTask" Width="100%" CssClass="myGridTable table table-responsive" AutoGenerateColumns="False" DataSourceID="sqldsTask">
                        <Columns>
                            <asp:BoundField DataField="TaskName" HeaderText="Project Tasks" SortExpression="TaskName"></asp:BoundField>
                            <asp:BoundField DataField="Hours" HeaderText="Logged Hours" SortExpression="Hours"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="select TaskName,Hours from TimesheetMaster p inner join TaskMaster t on p.TaskID = t.TaskID where ProjectID = @ProjectID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfProjectID" PropertyName="Value" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>

                <asp:UpdatePanel runat="server" ID="upCalander" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div class=" rounded-container peel-shadows" style="padding: 15px 10px">
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
                                DayNameFormat="Short" Font-Names="Verdana" Font-Size="12px" ForeColor="#003399" Height="410px" Enabled="False"
                                ShowTitle="False" OnDayRender="Calendar1_DayRender" Style="margin-bottom: 0">
                                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                <SelectedDayStyle BackColor="#0D83DD" BorderColor="#000000" BorderWidth="1px" ForeColor="#ffffff"></SelectedDayStyle>
                            </asp:Calendar>
                        </div>
                        <asp:GridView runat="server" ID="gvTemp" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsTemp">
                            <Columns>
                                <asp:BoundField DataField="Hours" HeaderText="Hours" ReadOnly="True" SortExpression="Hours"></asp:BoundField>
                                <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" ReadOnly="True" SortExpression="EntryDate"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="sqldsTemp" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT SUM(Hours) AS Hours,CAST(TimesheetDate AS DATE) AS EntryDate FROM TimesheetMaster where ProjectID = @ProjectID GROUP BY CAST(TimesheetDate AS DATE)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfProjectID" PropertyName="Value" DefaultValue="0" Name="ProjectID"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-3 rounded-container peel-shadows" style="margin-top: 25px;">
                <h3>Project Manager
                </h3>
                <asp:Label runat="server" ID="lblProjectManager"></asp:Label>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; display: inline-block; margin: 0; padding: 2%; width: 100%;">
                <h1 style="display: inline-block; margin: 0;">Projects
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvProject" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="ProjectID" DataSourceID="objdsProject"
                        AllowSorting="True" GridLines="None" OnSorting="gvProject_OnSorting" OnPageIndexChanging="gvProject_OnPageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ProjectID" HeaderText="ID" ReadOnly="True" InsertVisible="False" Visible="False" SortExpression="ProjectID"></asp:BoundField>
                            <asp:TemplateField HeaderText="Project Name">
                                <ItemTemplate>
                                    <a href='<%# "Projects.aspx?cmd=view&ID=" + Eval("ProjectID")%>'>
                                        <%# Eval("ProjectName") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName"></asp:BoundField>--%>
                            <asp:BoundField DataField="BillingMethod" HeaderText="Billing Method" SortExpression="BillingMethod"></asp:BoundField>
                            <asp:BoundField DataField="TimeEstimate" HeaderText="Time Estimate" SortExpression="TimeEstimate"></asp:BoundField>
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

                    <asp:ObjectDataSource runat="server" ID="objdsProject" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByClientID" TypeName="DABL.DAL.CloudAccountDATableAdapters.ProjectMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfClientID" PropertyName="Value" DefaultValue="0" Name="ClientID" Type="Int32"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfClientID" />
    <asp:HiddenField runat="server" ID="hfProjectID" />
    <asp:HiddenField runat="server" ID="hfClientContactID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
</asp:Content>

