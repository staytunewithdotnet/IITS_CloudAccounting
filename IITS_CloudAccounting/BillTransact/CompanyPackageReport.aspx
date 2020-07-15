<%@ Page Title="Company Package Report" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyPackageReport.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyPackageReport" %>

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
                    <a href="CompanyPackageReport.aspx">Company Package Report </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-6">
                <asp:UpdatePanel runat="server" ID="upDropDown">
                    <ContentTemplate>
                        <div class="col-lg-3 control-label">
                            Select Package
                        </div>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlPackage" CssClass="form-control text" AutoPostBack="True" OnSelectedIndexChanged="ddlPackage_OnSelectedIndexChanged" DataSourceID="sqldsPackage" DataTextField="CloudPackageName" DataValueField="CloudPackageID" />
                            <asp:SqlDataSource runat="server" ID="sqldsPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT CloudPackageID,CloudPackageName FROM CloudPackageMaster UNION SELECT 0,'FREE' UNION SELECT NULL,'All'"></asp:SqlDataSource>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-6">
                <a id="dlPdf" style="float: right; text-decoration: none; cursor: pointer;" class="btn btn-warning">Generate PDF</a>
            </div>
        </div>
    </div>
    <div id="printDiv" class="panel-body panel-box">
        <div class="row">
            <div class="col-lg-12" style="overflow-x: auto">
                <div class="page-header" style="margin-top: 0;text-align: center;">
                    <h3 style="margin-top: 0;">Company's Package(s)</h3>
                </div>
                <asp:UpdatePanel runat="server" ID="upGrid">
                    <ContentTemplate>
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
                        
                        <asp:SqlDataSource runat="server" ID="sqldsCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>'></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-12">
                <div style="color: white; text-align: center;">
                    <asp:Button ID="btnExportCompany" runat="server" Text="Export Active" CssClass="btn btn-primary" OnClick="btnExportCompany_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
