<%@ Page Title="Company Status Date Report" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyStatusDateReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyStatusDateReport" %>

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
                    <a href="CompanyStatusDateReport.aspx">Company Status Date Report</a>
                </li>
            </ol>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row" style="text-align: right">
                <asp:UpdatePanel runat="server" ID="upText">
                    <ContentTemplate>
                        <div class="col-lg-6">
                            <div class="col-lg-5" style="padding: 7px 10px 0;">
                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control text" OnTextChanged="txtDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="ceFromDate" TargetControlID="txtFromDate" Format="dd/MMM/yyyy" />
                            </div>
                            <div class="col-lg-1" style="padding: 15px 0 0; width: 2%;">to</div>
                            <div class="col-lg-5" style="padding: 7px 10px 0;">
                                <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control text" OnTextChanged="txtDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="ceToDate" TargetControlID="txtToDate" Format="dd/MMM/yyyy" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-lg-6">
                    <a id="dlPdf" style="float: right; text-decoration: none; cursor: pointer;" class="btn btn-warning">Generate PDF</a>
                </div>
            </div>
        </div>
        <div id="printDiv" class="panel-body panel-box">
            <div class="row" id="divActive">
                <div class="col-lg-12" style="overflow-x: auto">
                    <asp:UpdatePanel runat="server" ID="upGrid">
                        <ContentTemplate>
                            <div class="page-header" style="margin-top: 0; text-align: center; border: 0;">
                                <h3 style="margin-top: 0;">Company Active/Deactive Packages</h3>
                                <asp:Label runat="server" ID="lblDates" Style="font-weight: normal; margin-bottom: 20px; text-align: center; width: 100%; font-size: 18px; border-bottom: 1px solid #eee;"></asp:Label>
                            </div>
                            <asp:GridView runat="server" ID="gvCompany" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15" CssClass="table table-bordered table-hover" DataSourceID="sqldsCompany" DataKeyNames="CompanyID">
                                <Columns>
                                    <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                                    <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail"></asp:BoundField>
                                    <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                                    <asp:BoundField DataField="CompanyContactPersonNumber" HeaderText="Contact Number" SortExpression="CompanyContactPersonNumber"></asp:BoundField>
                                    <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                                    <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                                    <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center; width: 100%;">
                                        No Packages Found For Companies In This Date Range
                                    </div>
                                </EmptyDataTemplate>
                                <RowStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                                <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name',(CASE WHEN (DATEDIFF(dd,CONVERT(date,GETDATE()),CONVERT(date,PackageEndDate)))>0 THEN 'Active' ELSE 'Deactive' END) AS 'Status' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND PackageStartDate >= @FromDate AND PackageStartDate <= @ToDate">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtFromDate" PropertyName="Text" Name="FromDate"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="txtToDate" PropertyName="Text" Name="ToDate"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <%--<div class="row" id="divDeactive" style="display: none">
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header">
                        <h3>Deactive Companies</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyDeactive" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" CssClass="table table-bordered table-hover" DataSourceID="sqldsCompanyDeactive" DataKeyNames="CompanyID">
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                            <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPersonNumber" HeaderText="Contact Number" SortExpression="CompanyContactPersonNumber"></asp:BoundField>
                            <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" DataFormatString="{0:dd-MM-yyyy}" ReadOnly="True" SortExpression="PackageStartDate"></asp:BoundField>
                            <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                            <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Deactive Companies Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsCompanyDeactive" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE CONVERT(date,PackageEndDate) < CONVERT(date,GETDATE()) AND ActivePackage = 1 AND PackageStartDate >= @FromDate AND PackageStartDate <= @ToDate">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtFromDate" PropertyName="Text" Name="FromDate"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtToDate" PropertyName="Text" Name="ToDate"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>--%>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center;">
                        <asp:Button ID="btnExportCompany" runat="server" Text="Export Active" Style="" CssClass="btn btn-primary" OnClick="btnExportCompany_Click" />
                        <%--<asp:Button ID="btnExportCompanyDeactive" runat="server" Text="Export Deactive" Style="display: none;" CssClass="btn btn-primary" OnClick="btnExportCompanyDeactive_Click" />--%>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>

