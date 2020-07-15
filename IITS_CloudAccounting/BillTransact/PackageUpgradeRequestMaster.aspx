<%@ Page Title="Package Upgrade Request Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="PackageUpgradeRequestMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PackageUpgradeRequestMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="PackageUpgradeRequestMaster.aspx">Package Upgrade Request Master
                    </a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Package Upgrade Request Master</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvPackageUpgrade" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" 
                        DataKeyNames="PackageUpgradeRequestID" DataSourceID="objdsPackageUpgrade" PageSize="50" CssClass="table table-bordered table-hover"
                        OnSelectedIndexChanged="gvPackageUpgrade_SelectedIndexChanged" OnPageIndexChanging="gvPackageUpgrade_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="PackageUpgradeRequestID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="PackageUpgradeRequestID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="OldPackageID" HeaderText="Old Package" SortExpression="OldPackageID"></asp:BoundField>
                            <asp:BoundField DataField="NewPackageID" HeaderText="New Package" SortExpression="NewPackageID"></asp:BoundField>
                            <asp:BoundField DataField="PackageUpgradeRequest" HeaderText="Upgrade Request" SortExpression="PackageUpgradeRequest"></asp:BoundField>
                            <asp:BoundField DataField="PackageUpgradeRequestDate" HeaderText="Upgrade Request Date" SortExpression="PackageUpgradeRequestDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="PackageUpgradeCompletion" HeaderText="Upgrade Completion" SortExpression="PackageUpgradeCompletion"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ObjectDataSource runat="server" ID="objdsPackageUpgrade" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByRequestAndCompletion" TypeName="DABL.DAL.CloudAccountDATableAdapters.PackageUpgradeRequestMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
