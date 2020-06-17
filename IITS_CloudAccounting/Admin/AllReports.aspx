<%@ Page Title="All Reports" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="AllReports.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AllReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            var sectionTabs = $('.sidebar-nav li'),
                sections = $('.reports-section');

            sectionTabs.click(function () {
                var elem = $(this);
                sectionTabs.removeClass('active custom-background-fixed-lightness-95');
                elem.addClass('active custom-background-fixed-lightness-95');
                sections.hide().eq(elem.index()).show();
                return false;
            }).first().click();
        });
    </script>
    <style>
        .custom-background-fixed-lightness-95-hover {
            font-size: 12px;
        }

        .reports-section {
            font-family: Verdana,sans-serif;
            font-size: 12px;
        }

        .light-grey {
            color: #888!important;
        }

        a, a:hover {
            text-decoration: none;
        }
    </style>
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
            </ol>
        </div>
    </div>

    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <div class="page-header">
            <h1>All Reports
            </h1>
        </div>
        <div class="panel-body" style="margin-bottom: 20px;">
            <div class="col-lg-12 rounded-container peel-shadows" style="padding-bottom: 20px;">
                <div class="col-lg-4 sidebar-nav-container">
                    <ul class="ta_right list-plain sidebar-nav" style="list-style-type: none; margin-top: 20px; line-height: 2.5;">
                        <li class="custom-background-fixed-lightness-95-hover active"><a class="no-hover" href="#">Most Popular Reports</a> <span class="sidebar-nib"></span></li>
                        <li class="custom-background-fixed-lightness-95-hover"><a class="no-hover" href="#">Accounting Reports</a> <span class="sidebar-nib"></span></li>
                        <li class="custom-background-fixed-lightness-95-hover"><a class="no-hover" href="#">Client Reports</a> <span class="sidebar-nib"></span></li>
                        <li class="custom-background-fixed-lightness-95-hover"><a class="no-hover" href="#">Invoice Reports</a> <span class="sidebar-nib"></span></li>
                        <li class="custom-background-fixed-lightness-95-hover"><a class="no-hover" href="#">Time-Tracking Reports</a> <span class="sidebar-nib"></span></li>
                        <li class="custom-background-fixed-lightness-95-hover"><a class="no-hover" href="#">Other Reports</a> <span class="sidebar-nib"></span></li>
                    </ul>
                </div>
                <div class="col-lg-8 prepend-1 content-with-sidebar-nav">
                    <div class="content">
                        <div class="reports-section" style="display: block;">
                            <div class="report-container">
                                <a href="AccountsAgingReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Accounts Aging</h3>
                                    <div class="light-grey">
                                        Find out which clients are taking a long time to pay.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="ExpensesReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Expense Report</h3>
                                    <div class="light-grey">
                                        See how much money you're spending, and where you're spending it.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="InvoiceDetailsReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Invoice Details</h3>
                                    <div class="light-grey">
                                        A detailed history of all invoices you've sent over any period of time.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Profit and Loss</h3>
                                    <div class="light-grey">
                                        Find out if you're making more money than you're spending.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TaxSummaryReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Tax Summary</h3>
                                    <div class="light-grey">
                                        See the details of taxes you've paid and collected between any period.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TimesheetDetailsReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Timesheet Details</h3>
                                    <div class="light-grey">
                                        Get the details on how much time you and/or your teammates tracked.
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="reports-section" style="display: none;">
                            <div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Balance Sheet</h3>
                                    <div class="light-grey">
                                        Capture a summary of your company's assets, liabilities and equity.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="ExpensesReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Expense Report</h3>
                                    <div class="light-grey">
                                        See how much money you're spending, and where you're spending it.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="PaymentsCollectedReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Payments Collected</h3>
                                    <div class="light-grey">
                                        See how much money you've collected over any period.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Profit and Loss</h3>
                                    <div class="light-grey">
                                        Find out if you're making more money than you're spending.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TaxSummaryReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Tax Summary</h3>
                                    <div class="light-grey">
                                        See the details of taxes you've paid and collected between any period.
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="reports-section" style="display: none;">
                            <div class="report-container">
                                <a href="AccountsAgingReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Accounts Aging</h3>
                                    <div class="light-grey">
                                        Find out which clients are taking a long time to pay.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="RevenueByClientReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Revenue by Client</h3>
                                    <div class="light-grey">
                                        See how much each client earns you.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TimeToPayReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Time to Pay</h3>
                                    <div class="light-grey">
                                        See how long it takes your clients to pay on average.
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="reports-section" style="display: none;">
                            <div class="report-container">
                                <a href="InvoiceDetailsReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Invoice Details</h3>
                                    <div class="light-grey">
                                        A detailed history of all invoices you've sent over any period of time.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="ItemSalesReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Item Sales</h3>
                                    <div class="light-grey">
                                        See how much money you're making from each item you sell.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="RecurringAnnualReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Recurring Revenue - Annual</h3>
                                    <div class="light-grey">
                                        Get a projection of how much you'll collect from recurring billing.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="RecurringDetailedReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Recurring Revenue - Detailed</h3>
                                    <div class="light-grey">
                                        Get a detailed breakdown of your projected recurring billing.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="RevenueByClientReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Revenue by Client</h3>
                                    <div class="light-grey">
                                        See how much each client earns you.
                                    </div>
                                </a>
                            </div>

                            <%--<div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Revenue by Staff</h3>
                                    <div class="light-grey">
                                        See how much each staff is billing.
                                    </div>
                                </a>
                            </div>--%>
                            
                            <div class="report-container">
                                <a href="TasksInvoicedReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Tasks Invoiced</h3>
                                    <div class="light-grey">
                                        Find out how much you're making by task.
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="reports-section" style="display: none;">
                            <div class="report-container">
                                <a href="EstimatedBillingReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Estimated Billing</h3>
                                    <div class="light-grey">
                                        An estimation of how much you would make if you were to bill for all your unbilled hours.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TasksInvoicedReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Tasks Invoiced</h3>
                                    <div class="light-grey">
                                        Find out how much you're making by task.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="ProjectTaskReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Task Summary</h3>
                                    <div class="light-grey">
                                        See how much time is spent on each task per project.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TimesheetReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Team Timesheets</h3>
                                    <div class="light-grey">
                                        Generate monthly timesheets for each member of your team.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="TimesheetDetailsReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Timesheet Details</h3>
                                    <div class="light-grey">
                                        Get the details on how much time you and/or your teammates tracked.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="ProjectUserReport.aspx" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">User Summary</h3>
                                    <div class="light-grey">
                                        See a summary of time spent on tasks for each staff member or contractor.
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="reports-section" style="display: none;">
                            <div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Document Usage</h3>
                                    <div class="light-grey">
                                        See the activity of staff and clients on shared documents.
                                    </div>
                                </a>
                            </div>

                            <div class="report-container">
                                <a href="#" class="append-half prepend-half append-bottom-half prepend-top-half">
                                    <h3 class="nomargin">Support Tickets</h3>
                                    <div class="light-grey">
                                        Get a summary of all support tickets.
                                    </div>
                                </a>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="clearb"></div>
        </div>
    </div>

</asp:Content>
