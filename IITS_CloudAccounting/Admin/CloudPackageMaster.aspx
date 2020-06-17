<%@ Page Title="Cloud Package Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CloudPackageMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CloudPackageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input[type=radio], input[type=checkbox] {
            margin: 0 5px;
        }

        .leftText {
            text-align: left;
        }
    </style>
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">Package Management
                    </a>
                </li>
                <li>
                    <a href="CloudPackageMaster.aspx">Package Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Package Master</h1>
            </div>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Name Reqiured" ControlToValidate="txtName" ValidationGroup="PackageMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Price Currency:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList ID="ddlMonthCurrency" TabIndex="2" CssClass="form-control text" runat="server" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Price Monthly:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtPricePerMonth" TabIndex="3" class="form-control text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Price Yearly:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtPricePerYear" TabIndex="4" class="form-control text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Description:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" TabIndex="5" CssClass="form-control text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="6" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-header">
            <h1>Package Details</h1>
        </div>
        <asp:UpdatePanel runat="server" ID="upModuleGrid">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvAddModule" Width="100%" Font-Size="Small" AutoGenerateColumns="False"
                    CssClass="table table-bordered" DataKeyNames="PackageFeatureID" DataSourceID="sqldsAddModule">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No." SortExpression="Number">
                            <ItemTemplate>
                                <%# Container.DisplayIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PackageModuleName" HeaderText="Package Module" SortExpression="PackageModuleName"></asp:BoundField>
                        <asp:BoundField DataField="PackageFeatureName" HeaderText="Package Feature" SortExpression="PackageFeatureName" ItemStyle-CssClass="leftText"></asp:BoundField>
                        <asp:TemplateField HeaderText="Value">
                            <ItemTemplate>
                                <asp:RadioButtonList runat="server" ID="rblInput" OnSelectedIndexChanged="rblInput_SelectedIndexChanged" AutoPostBack="True" RepeatColumns="2" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Text Value</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">Active Value</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox runat="server" ID="txtValue" CssClass="form-control text" Visible="False"></asp:TextBox>
                                <asp:CheckBox runat="server" ID="chkValue" Checked="True"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPackageFeatureID" Text='<%# Eval("PackageFeatureID") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblPackageModuleID" Text='<%# Eval("PackageModuleID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PackageFeatureID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="PackageFeatureID" Visible="False"></asp:BoundField>
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
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="7" CssClass="btn btn-primary" ValidationGroup="PackageMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="8" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="10" CssClass="btn btn-primary" ValidationGroup="PackageMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="11" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="9" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Price Currency:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblMonthCurrency" runat="server">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Price Monthly:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblPricePerMonth" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Price Yearly:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblPricePerYear" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Description:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-header">
            <h1>Package Details</h1>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <asp:GridView runat="server" ID="gvViewModule" Width="100%" Font-Size="Small" AutoGenerateColumns="False"
                    DataKeyNames="CloudPackageDetailID" CssClass="table table-bordered" DataSourceID="sqldsViewPackage">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No." SortExpression="Number">
                            <ItemTemplate>
                                <%# Container.DisplayIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PackageModuleName" HeaderText="Package Module" SortExpression="PackageModuleName"></asp:BoundField>
                        <asp:BoundField DataField="PackageFeatureName" HeaderText="Package Feature" SortExpression="PackageFeatureName" ItemStyle-CssClass="leftText"></asp:BoundField>
                        <asp:BoundField DataField="CloudPackageDetailValue" HeaderText="Value" SortExpression="CloudPackageDetailValue"></asp:BoundField>
                        <asp:BoundField DataField="CloudPackageDetailID" HeaderText="CloudPackageDetailID" ReadOnly="True" InsertVisible="False" SortExpression="CloudPackageDetailID" Visible="False"></asp:BoundField>
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
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="11" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="12" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="13" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="14" CssClass="btn btn-primary" OnClick="btnAddPackage_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvPackage" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="CloudPackageID" DataSourceID="objdsPackage" OnSelectedIndexChanged="gvPackage_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvPackage_PageIndexChanging" CssClass="table table-bordered table-hover" OnRowDataBound="gvPackage_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="CloudPackageID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="CloudPackageID"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackageName" HeaderText="Package Name" SortExpression="CloudPackageName"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackageCurrency" HeaderText="Package Currency" SortExpression="CloudPackageCurrency"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackagePriceMonthly" HeaderText="Price Per Month" SortExpression="CloudPackagePriceMonthly" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackagePriceYearly" HeaderText="Price Per Year" SortExpression="CloudPackagePriceYearly" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="CloudPackageStatus" HeaderText="Status" SortExpression="CloudPackageStatus"></asp:BoundField>
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
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddPackage" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddPackage_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ObjectDataSource runat="server" ID="objdsPackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.CloudPackageMasterTableAdapter"></asp:ObjectDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsAddModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT PackageFeatureID,pmm.PackageModuleID,PackageModuleName,PackageFeatureName,PackageFeatureDesc,PackageFeatureStatus FROM PackageFeatureMaster pfm INNER JOIN PackageModuleMaster pmm ON pfm.PackageModuleID = pmm.PackageModuleID WHERE PackageFeatureStatus = 1"></asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsViewPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.CloudPackageDetailID,b.PackageModuleName,c.PackageFeatureName,a.CloudPackageDetailValue FROM CloudPackageDetails a INNER JOIN PackageModuleMaster b ON a.PackageModuleID = b.PackageModuleID INNER JOIN PackageFeatureMaster c on a.PackageFeatureID = c.PackageFeatureID WHERE a.CloudPackageID = @CloudPackageID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfPackage" PropertyName="Value" DefaultValue="0" Name="CloudPackageID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfPackage" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
</asp:Content>
