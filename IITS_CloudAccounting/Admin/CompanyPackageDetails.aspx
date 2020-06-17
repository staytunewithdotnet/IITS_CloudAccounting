<%@ Page Title="Company Package Details" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyPackageDetails.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyPackageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Company Management
                    </a>
                </li>
                <li>
                    <a href="CompanyPackageDetails.aspx">Company Package Details</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Company Package Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlCompanyName" CssClass="form-control" TabIndex="1" DataSourceID="SqlCompanyMaster" DataTextField="CompanyName" DataValueField="CompanyID">
                            </asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlCompanyMaster" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT 0 AS CompanyID, '--Select Company--' AS CompanyName UNION SELECT [CompanyID], [CompanyName] FROM [CompanyMaster]"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Company Name Reqiured" InitialValue="0" ControlToValidate="ddlCompanyName" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Name*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlPackageName" CssClass="form-control" TabIndex="2" DataSourceID="SqlPackageMaster" DataTextField="PackageName" DataValueField="PackageID"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlPackageMaster" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="select 0 AS PackageID,'--Select Package--' as PackageName UNION  SELECT [PackageID], [PackageName] FROM [PackageMaster]"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvPackageName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Name Reqiured" InitialValue="0" ControlToValidate="ddlPackageName" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Start Date*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" TabIndex="3"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="cStartDate" TargetControlID="txtStartDate" Format="MM/dd/yyyy" />
                            <asp:RequiredFieldValidator ID="rfvStartDate" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Start Date Reqiured" ControlToValidate="txtStartDate" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            End Date*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" TabIndex="4"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="cEndDate" TargetControlID="txtEndDate" Format="MM/dd/yyyy" />
                            <asp:RequiredFieldValidator ID="rfvEndDate" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="End Date Reqiured" ControlToValidate="txtEndDate" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Monthly Amount*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackageMonthlyAmount" CssClass="form-control" TabIndex="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPackageMonthlyAmount" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Monthly Amount Reqiured" ControlToValidate="txtPackageMonthlyAmount" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Yearly Amount*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackageYearlyAmount" CssClass="form-control" TabIndex="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPackageYearlyAmount" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Yearly Amount Reqiured" ControlToValidate="txtPackageYearlyAmount" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Paid:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkPackagePaid" TabIndex="6" CssClass="checkbox" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Amount Paid:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackageAmountPaid" CssClass="form-control" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Transaction:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackagePaymentTransaction" CssClass="form-control" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Date*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackagePaymentDate" CssClass="form-control" TabIndex="8"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="CPackageAmountDate" TargetControlID="txtPackagePaymentDate" Format="MM/dd/yyyy" />
                            <asp:RequiredFieldValidator ID="rfvPackageAmountDate" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Amount Date Reqiured" ControlToValidate="txtPackagePaymentDate" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Assign Date*:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPackageAssignDate" CssClass="form-control" TabIndex="9"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="CPackageAssignDate" TargetControlID="txtPackageAssignDate" Format="MM/dd/yyyy" />
                            <asp:RequiredFieldValidator ID="rfvPackageAssignDate" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Package Assign Date Reqiured" ControlToValidate="txtPackageAssignDate" ValidationGroup="CompanyPackageDetails">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="10" CssClass="checkbox" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" TabIndex="11" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="CompanyPackageDetails" />
                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" TabIndex="12" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="8" CssClass="btn btn-success" ValidationGroup="CompanyPackageDetails" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="9" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="10" CssClass="btn btn-primary" OnClick="btnCancel_Click" />
            </div>
        </div>
        <br />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageName"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Start Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStartDate"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            End Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblEndDate"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Monthly Amount:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageMonthlyAmount"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Yearly Amount:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageYearlyAmount"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Paid:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackagePaid"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Amount Paid:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageAmountPaid"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Transaction:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackagePaymentTransaction"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Payment Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackagePaymentDate"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Package Assign Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPackageAssignDate"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnUpgrade" runat="server" Text="Upgrade" CssClass="btn btn-success" Visible="False" TabIndex="14" OnClick="btnUpgrade_Click" />
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="10" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="11" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="12" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddCompanyPackage_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12" style="overflow-x: auto">
                    <asp:GridView runat="server" ID="gvCompanyPackage" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CompanyPackageID"
                        PageSize="15" OnSelectedIndexChanged="gvCompanyPackage_SelectedIndexChanged" OnPageIndexChanging="gvCompanyPackage_PageIndexChanging"
                        OnRowDataBound="gvCompanyPackage_RowDataBound" CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CompanyPackageID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="CompanyPackageID" />
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID" />
                            <asp:BoundField DataField="PackageID" HeaderText="Package" SortExpression="PackageID" />
                            <asp:BoundField DataField="PackageStartDate" HeaderText="Start Date" SortExpression="PackageStartDate" DataFormatString="{00:dd/MM/yyyy}" />
                            <asp:BoundField DataField="PackageEndDate" HeaderText="End Date" SortExpression="PackageEndDate" DataFormatString="{00:dd/MM/yyyy}" />
                            <asp:BoundField DataField="ActivePackage" HeaderText="Status" SortExpression="ActivePackage" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddCompanyPackage" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddCompanyPackage_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:ObjectDataSource ID="objdsCompanyPackage" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyPackageDetailsTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="objdsOnlyCompanyPackage" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyPackageDetailsTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" Name="CompanyID" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyPackage" />
</asp:Content>
