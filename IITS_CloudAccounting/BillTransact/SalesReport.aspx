<%@ Page Title="Sales Report" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-download-3"></i>
                    <a href="#">Report
                    </a>
                </li>
                <li>
                    <a href="SalesReport.aspx">Sales Report</a>
                </li>
            </ol>
        </div>
    </div>
    <script type="text/javascript">
        function divHideShow(val) {
            var divDaily = document.getElementById("divDaily");
            var divWeekly = document.getElementById("divWeekly");
            var divMonthly = document.getElementById("divMonthly");
            var divYearly = document.getElementById("divYearly");
            var aDaily = document.getElementById("aDaily");
            var aWeekly = document.getElementById("aWeekly");
            var aMonthly = document.getElementById("aMonthly");
            var aYearly = document.getElementById("aYearly");
            var btnDaily = document.getElementById('<%= btnExportDaily.ClientID%>');
            var btnWeekly = document.getElementById('<%= btnExportWeekly.ClientID%>');
            var btnMonthly = document.getElementById('<%= btnExportMonthly.ClientID%>');
            var btnYearly = document.getElementById('<%= btnExportYearly.ClientID%>');
            switch (val) {
                case "Daily":
                    btnDaily.style.display = '';
                    divDaily.style.display = 'block';
                    btnWeekly.style.display = divWeekly.style.display = 'none';
                    btnMonthly.style.display = divMonthly.style.display = 'none';
                    btnYearly.style.display = divYearly.style.display = 'none';
                    aDaily.className = "btn btn-success";
                    aWeekly.className = "btn btn-primary";
                    aMonthly.className = "btn btn-primary";
                    aYearly.className = "btn btn-primary";
                    break;
                case "Weekly":
                    btnDaily.style.display = divDaily.style.display = 'none';
                    btnWeekly.style.display = '';divWeekly.style.display = 'block';
                    btnMonthly.style.display = divMonthly.style.display = 'none';
                    btnYearly.style.display = divYearly.style.display = 'none';
                    aWeekly.className = "btn btn-success";
                    aDaily.className = "btn btn-primary";
                    aMonthly.className = "btn btn-primary";
                    aYearly.className = "btn btn-primary";
                    break;
                case "Monthly":
                    btnDaily.style.display = divDaily.style.display = 'none';
                    btnWeekly.style.display = divWeekly.style.display = 'none';
                    btnMonthly.style.display = '';
                    divMonthly.style.display = 'block';
                    btnYearly.style.display = divYearly.style.display = 'none';
                    aDaily.className = "btn btn-primary";
                    aWeekly.className = "btn btn-primary";
                    aMonthly.className = "btn btn-success";
                    aYearly.className = "btn btn-primary";
                    break;
                case "Yearly":
                    btnDaily.style.display = divDaily.style.display = 'none';
                    btnWeekly.style.display = divWeekly.style.display = 'none';
                    btnMonthly.style.display = divMonthly.style.display = 'none';
                    btnYearly.style.display = '';
                    divYearly.style.display = 'block';
                    aDaily.className = "btn btn-primary";
                    aWeekly.className = "btn btn-primary";
                    aMonthly.className = "btn btn-primary";
                    aYearly.className = "btn btn-success";
                    break;
            }
        }
    </script>
    <div class="panel-body">
        <div class="row" style="text-align: right; margin-bottom: 15px">
            <a id="dlPdf" style="text-decoration: none; cursor: pointer;" class="btn btn-warning">Generate PDF</a>
        </div>
        <div class="row" style="text-align: right">
            <a onclick="divHideShow('Daily')" id="aDaily" class="btn btn-success" style="text-decoration: none; cursor: pointer;">Daily</a>
            <a onclick="divHideShow('Weekly')" id="aWeekly" class="btn btn-primary" style="text-decoration: none; cursor: pointer;">Weekly</a>
            <a onclick="divHideShow('Monthly')" id="aMonthly" class="btn btn-primary" style="text-decoration: none; cursor: pointer;">Monthly</a>
            <a onclick="divHideShow('Yearly')" id="aYearly" class="btn btn-primary" style="text-decoration: none; cursor: pointer;">Yearly</a>
        </div>
    </div>
    <div id="printDiv" class="panel-body panel-box">
        <div class="row" id="divDaily" style="display: block">
            <div class="col-lg-12" style="overflow-x: auto">
                <div class="page-header" style="margin-top: 0; text-align: center;">
                    <h3 style="margin-top: 0;">Package's Daily Sales Report as On (<%= DateTime.Now.ToShortDateString() %>)</h3>
                </div>
                <asp:GridView runat="server" ID="gvDaily" Width="100%" AutoGenerateColumns="False" DataKeyNames="CompanyID" DataSourceID="sqldsDaily"
                    AllowPaging="False" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                        <asp:BoundField DataField="CompanyEmail" HeaderText="Company Email" SortExpression="CompanyEmail"></asp:BoundField>
                        <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                        <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                        <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Company Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsDaily" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND CONVERT(date,PackageStartDate) = CONVERT(date,GETDATE())"></asp:SqlDataSource>
                <div style="text-align: right">
                    <h3 class="page-header" style="margin: 0">Total:&nbsp;<%= GetDailyTotal() %></h3>
                </div>
            </div>
        </div>
        <div class="row" id="divWeekly" style="display: none">
            <div class="col-lg-12" style="overflow-x: auto">
                <div class="page-header" style="margin-top: 0; text-align: center;">
                    <h3 style="margin-top: 0;">Package's Weekly Sales Report as On (<%= GetWeekDate() %>)</h3>
                </div>
                <asp:GridView runat="server" ID="gvWeekly" Width="100%" AutoGenerateColumns="False" DataKeyNames="CompanyID" DataSourceID="sqldsWeekly"
                    AllowPaging="False" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                        <asp:BoundField DataField="CompanyEmail" HeaderText="Company Email" SortExpression="CompanyEmail"></asp:BoundField>
                        <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                        <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                        <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Company Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsWeekly" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND CONVERT(date,PackageStartDate) >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate())) AND CONVERT(date,PackageStartDate) <= dateadd(day, 7-datepart(dw, getdate()), CONVERT(date,getdate()))"></asp:SqlDataSource>
                <div style="text-align: right">
                    <h3 class="page-header" style="margin: 0">Total:&nbsp;<%= GetWeeklyTotal() %></h3>
                </div>
            </div>
        </div>
        <div class="row" id="divMonthly" style="display: none">
            <div class="col-lg-12" style="overflow-x: auto">
                <div class="page-header" style="margin-top: 0; text-align: center;">
                    <h3 style="margin-top: 0;">Package's Monthly Sales Report Of (<%= DateTime.Now.ToString("MMMM") %>)</h3>
                </div>
                <asp:GridView runat="server" ID="gvMonthly" Width="100%" AutoGenerateColumns="False" DataKeyNames="CompanyID" DataSourceID="sqldsMonthly"
                    AllowPaging="False" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                        <asp:BoundField DataField="CompanyEmail" HeaderText="Company Email" SortExpression="CompanyEmail"></asp:BoundField>
                        <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                        <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                        <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Company Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsMonthly" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND MONTH(PackageStartDate) = MONTH(GETDATE())"></asp:SqlDataSource>
                <div style="text-align: right">
                    <h3 class="page-header" style="margin: 0">Total:&nbsp;<%= GetMonthlyTotal() %></h3>
                </div>
            </div>
        </div>
        <div class="row" id="divYearly" style="display: none">
            <div class="col-lg-12" style="overflow-x: auto">
                <div class="page-header" style="margin-top: 0; text-align: center;">
                    <h3 style="margin-top: 0;">Package's Yearly Sales Report Of (<%= DateTime.Now.ToString("yyyy") %>)</h3>
                </div>
                <asp:GridView runat="server" ID="gvYearly" Width="100%" AutoGenerateColumns="False" DataKeyNames="CompanyID" DataSourceID="sqldsYearly"
                    AllowPaging="False" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                        <asp:BoundField DataField="CompanyEmail" HeaderText="Company Email" SortExpression="CompanyEmail"></asp:BoundField>
                        <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                        <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                        <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MMM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Company Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sqldsYearly" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND YEAR(PackageStartDate) = YEAR(GETDATE())"></asp:SqlDataSource>
                <div style="text-align: right">
                    <h3 class="page-header" style="margin: 0">Total:&nbsp;<%= GetYearlyTotal() %></h3>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-12">
                <div style="color: white; text-align: center;">
                    <asp:Button ID="btnExportDaily" runat="server" Text="Export" Style="" CssClass="btn btn-primary" OnClick="btnExportDaily_Click" />
                    <asp:Button ID="btnExportWeekly" runat="server" Text="Export" Style="display: none;" CssClass="btn btn-primary" OnClick="btnExportWeekly_Click" />
                    <asp:Button ID="btnExportMonthly" runat="server" Text="Export" Style="display: none;" CssClass="btn btn-primary" OnClick="btnExportMonthly_Click" />
                    <asp:Button ID="btnExportYearly" runat="server" Text="Export" Style="display: none;" CssClass="btn btn-primary" OnClick="btnExportYearly_Click" />
                </div>
            </div>
        </div>
    </div>
    <div style="display: none;">
        <asp:GridView runat="server" ID="gvCurrentWeek" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsCurrentWeek">
            <Columns>
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" ReadOnly="True" SortExpression="StartDate"></asp:BoundField>
                <asp:BoundField DataField="EnddDate" HeaderText="EnddDate" ReadOnly="True" SortExpression="EnddDate"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sqldsCurrentWeek" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT DATEADD(week, DATEDIFF(day, 0, getDate())/7, -1) AS StartDate,DATEADD(week, DATEDIFF(day, 0, getDate())/7, 5) AS EnddDate"></asp:SqlDataSource>
    </div>
</asp:Content>
