<%@ Page Title="Company Package Info" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyPackageInfo.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyPackageInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">Company Admin Management
                    </a>
                </li>
                <li>
                    <a href="CompanyPackageInfo.aspx">Company Package Info</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Company Package Info</h1>
            </div>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company:
                        </div>
                        <div class="col-lg-8">
                            <asp:DropDownList runat="server" ID="ddlCompany" CssClass="form-control text" Enabled="False" DataSourceID="sqldsCompany" DataTextField="CompanyName" DataValueField="CompanyID" />
                            <asp:SqlDataSource runat="server" ID="sqldsCompany" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [CompanyID], [CompanyName] FROM [CompanyMaster]"></asp:SqlDataSource>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upPayment">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    New Package:
                                </div>
                                <div class="col-lg-8">
                                    <asp:DropDownList runat="server" ID="ddlPackage" CssClass="form-control text" AutoPostBack="True" DataSourceID="sqldsCloudPackage" DataTextField="CloudPackageName" DataValueField="CloudPackageID" OnSelectedIndexChanged="ddlPackage_OnSelectedIndexChanged" />
                                    <asp:SqlDataSource runat="server" ID="sqldsCloudPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CloudPackageID, '[choose one]' AS CloudPackageName UNION SELECT [CloudPackageID], [CloudPackageName] FROM [CloudPackageMaster]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Type:
                                </div>
                                <div class="col-lg-8">
                                    <asp:RadioButtonList runat="server" ID="rblType" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="Monthly">Monthly</asp:ListItem>
                                        <asp:ListItem Value="Yearly">Yearly</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Amount:
                                </div>
                                <div class="col-lg-8">
                                    <asp:Label runat="server" ID="lblPriceMonth" Visible="True" Text="0.00"></asp:Label>
                                    <asp:Label runat="server" ID="lblPriceYear" Visible="False" Text="0.00"></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Trans Detail:
                        </div>
                        <div class="col-lg-8">
                            <span>Upgrade by Bill Transact Support
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Trans Date:
                        </div>
                        <div class="col-lg-8">
                            <span>
                                <%= DateTime.Now.ToShortDateString() %>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Assign Date:
                        </div>
                        <div class="col-lg-8">
                            <span>
                                <%= DateTime.Now.ToShortDateString() %>
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Active Package:
                        </div>
                        <div class="col-lg-8">
                            <span>TRUE</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button runat="server" ID="btnSubmit" Text="Upgrade" CssClass="btn btn-warning" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="17" CssClass="btn btn-info" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <asp:DataList runat="server" ID="dlCompanyPackage" Width="100%" RepeatColumns="1" RepeatDirection="Horizontal" DataKeyField="CompanyPackageID"
                DataSourceID="objdsCompanyPackage" CssClass="table table-bordered table-striped">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("CompanyPackageID") %>' runat="server" ID="CompanyPackageIDLabel" Visible="False" />
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Name:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# GetPackageName(Eval("CloudPackageID").ToString()) %>' runat="server" ID="CloudPackageIDLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Start Date:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# DateTime.Parse(Eval("PackageStartDate").ToString()).ToShortDateString() %>' runat="server" ID="PackageStartDateLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package End Date:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# DateTime.Parse(Eval("PackageEndDate").ToString()).ToShortDateString() %>' runat="server" ID="PackageEndDateLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Type:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# Eval("PackageType") %>' runat="server" ID="PackageTypeLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Amount:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# Eval("PackageAmount") %>' runat="server" ID="PackageAmountLabel" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Payment Trans Detail:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# Eval("PackagePaymentTransDetail") %>' runat="server" ID="PackagePaymentTransDetailLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Payment Trans Date:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# !string.IsNullOrEmpty(Eval("PackagePaymentTransDate").ToString())? DateTime.Parse(Eval("PackagePaymentTransDate").ToString()).ToShortDateString():"" %>' runat="server" ID="PackagePaymentTransDateLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Assign Date:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# DateTime.Parse(Eval("PackageAssignDate").ToString()).ToShortDateString() %>' runat="server" ID="PackageAssignDateLabel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Active Package:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:Label Text='<%# Eval("ActivePackage") %>' runat="server" ID="ActivePackageLabel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:DataList>
            <asp:ObjectDataSource runat="server" ID="objdsCompanyPackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyPackageMasterTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button runat="server" ID="btnUpgrade" Text="Upgrade Package" CssClass="btn btn-primary" OnClick="btnUpgrade_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="17" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header" style="margin-top: 0;">
                        <h3 style="margin-top: 0;">Company Register In Free Package</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyPackageFree" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" PageSize="50"
                        CssClass="table table-bordered table-hover" DataSourceID="sqldsCompanyPackageFree" DataKeyNames="CompanyPackageID" OnRowDataBound="gvCompanyPackage_OnRowDataBound"
                        OnSelectedIndexChanged="gvCompanyPackageFree_SelectedIndexChanged" OnPageIndexChanging="gvCompanyPackageFree_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackageID" HeaderText="Package" SortExpression="CloudPackageID"></asp:BoundField>
                            <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" SortExpression="PackageStartDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" SortExpression="PackageEndDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="PackageType" HeaderText="Package Type" SortExpression="PackageType"></asp:BoundField>
                            <asp:BoundField DataField="PackageAmount" HeaderText="Package Amount" SortExpression="PackageAmount"></asp:BoundField>
                            <asp:BoundField DataField="ActivePackage" HeaderText="Package Active?" SortExpression="ActivePackage"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Company Package Information Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsCompanyPackageFree" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM CompanyPackageMaster WHERE ActivePackage = 1 AND CloudPackageID = 0"></asp:SqlDataSource>
                </div>
                <div class="col-lg-12" style="overflow-x: auto">
                    <div class="page-header" style="margin-top: 0;">
                        <h3 style="margin-top: 0;">Company Register In Non-Free Package</h3>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyPackage" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" PageSize="50"
                        CssClass="table table-bordered table-hover" DataSourceID="sqldsCompanyPackage" DataKeyNames="CompanyPackageID" OnRowDataBound="gvCompanyPackage_OnRowDataBound"
                        OnSelectedIndexChanged="gvCompanyPackage_SelectedIndexChanged" OnPageIndexChanging="gvCompanyPackage_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CompanyID" HeaderText="ID" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackageID" HeaderText="Package" SortExpression="CloudPackageID"></asp:BoundField>
                            <asp:BoundField DataField="PackageStartDate" HeaderText="Package Start Date" SortExpression="PackageStartDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="PackageEndDate" HeaderText="Package End Date" SortExpression="PackageEndDate" DataFormatString="{0:dd/MMM/yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="PackageType" HeaderText="Package Type" SortExpression="PackageType"></asp:BoundField>
                            <asp:BoundField DataField="PackageAmount" HeaderText="Package Amount" SortExpression="PackageAmount"></asp:BoundField>
                            <asp:BoundField DataField="ActivePackage" HeaderText="Package Active?" SortExpression="ActivePackage"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Company Package Information Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sqldsCompanyPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM CompanyPackageMaster WHERE ActivePackage = 1 AND CloudPackageID != 0"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:HiddenField runat="server" ID="hfCompanyAdmin" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfUserName" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
</asp:Content>
