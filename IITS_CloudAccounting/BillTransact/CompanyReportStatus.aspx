<%@ Page Title="Company Report Status" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyReportStatus.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyReportStatus" %>

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
                    <a href="CompanyReportStatus.aspx">Company Report Status</a>
                </li>
            </ol>
        </div>
    </div>
    <script type="text/javascript">
        function dropChange() {
            var v = document.getElementById('<%= ddlPackage.ClientID%>');
            var val = v.options[v.selectedIndex].value;
            var divActive = document.getElementById("divActive");
            var divDeactive = document.getElementById("divDeactive");
            var btnActive = document.getElementById('<%= btnExportCompany.ClientID%>');
            var btnDeactive = document.getElementById('<%= btnExportCompanyDeactive.ClientID%>');
            if (val == 0) {
                divActive.style.display = 'block';
                btnActive.style.display = '';
                divDeactive.style.display = 'none';
                btnDeactive.style.display = 'none';
            }
            else if (val == 1) {
                divActive.style.display = 'none';
                btnActive.style.display = 'none';
                divDeactive.style.display = 'block';
                btnDeactive.style.display = '';
            }
        }
    </script>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row" style="text-align: right">
                <div class="col-lg-6">
                    <div class="col-lg-4">
                        Company Package
                    </div>
                    <div class="col-lg-8">
                        <asp:DropDownList runat="server" ID="ddlPackage" CssClass="form-control text" onchange="dropChange(this)">
                            <asp:ListItem Value="0" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="1">Deactive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <a id="dlPdf" style="float: right; text-decoration: none; cursor: pointer;" class="btn btn-warning">Generate PDF</a>
                </div>
            </div>
        </div>
        <div id="printDiv" class="panel-body panel-box">
            <div class="row" id="divActive" style="display: block">
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header" style="margin-top: 0;text-align: center;">
                        <h3 style="margin-top: 0;">Active Companies Till (<%= DateTime.Now.ToShortDateString() %>)</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompany" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" CssClass="table table-bordered table-hover" DataSourceID="sqldsCompany" DataKeyNames="CompanyID">
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPersonNumber" HeaderText="Contact Number" SortExpression="CompanyContactPersonNumber"></asp:BoundField>
                            <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail"></asp:BoundField>
                            <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" DataFormatString="{0:dd-MM-yyyy}" ReadOnly="True" SortExpression="PackageEndDate"></asp:BoundField>
                            <asp:BoundField DataField="Package Name" HeaderText="Package Name" ReadOnly="True" SortExpression="Package Name"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Active Companies Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE CONVERT(date,PackageEndDate) >= CONVERT(date,GETDATE()) AND ActivePackage = 1"></asp:SqlDataSource>
                </div>
            </div>

            <div class="row" id="divDeactive" style="display: none">
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header" style="margin-top: 0;text-align: center;">
                        <h3>Deactive Companies Till (<%= DateTime.Now.ToShortDateString() %>)</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyDeactive" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" CssClass="table table-bordered table-hover" DataSourceID="sqldsCompanyDeactive" DataKeyNames="CompanyID">
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPerson" HeaderText="Contact Person" SortExpression="CompanyContactPerson"></asp:BoundField>
                            <asp:BoundField DataField="CompanyContactPersonNumber" HeaderText="Contact Number" SortExpression="CompanyContactPersonNumber"></asp:BoundField>
                            <asp:BoundField DataField="CompanyEmail" HeaderText="Email" SortExpression="CompanyEmail"></asp:BoundField>
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
                    <asp:SqlDataSource runat="server" ID="sqldsCompanyDeactive" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE CONVERT(date,PackageEndDate) < CONVERT(date,GETDATE()) AND ActivePackage = 1"></asp:SqlDataSource>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center;">
                        <asp:Button ID="btnExportCompany" runat="server" Text="Export Active" Style="" CssClass="btn btn-primary" OnClick="btnExportCompany_Click" />
                        <asp:Button ID="btnExportCompanyDeactive" runat="server" Text="Export Deactive" Style="display: none;" CssClass="btn btn-primary" OnClick="btnExportCompanyDeactive_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
