<%@ Page Title="Package Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="PackageMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.PackageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript">
        function minmax() {

            var minVal = parseInt($("#<%=txtAdminUsersMin.ClientID%>").val());
            var maxVal = parseInt($("#<%=txtAdminUsersMax.ClientID%>").val());
            if ($("#<%=txtAdminUsersMin.ClientID%>").val() == 0) {
                document.getElementById('<%=txtAdminUsersMin.ClientID%>').value = 1;
                return 1;
            }
            if ($("#<%=txtAdminUsersMax.ClientID%>").val() == 0) {
                document.getElementById('<%=txtAdminUsersMax.ClientID%>').value = 1;
                return 1;
            }
            else if (minVal > maxVal) {
                alert("Value should be less than maximum Value");
                document.getElementById('<%=txtAdminUsersMin.ClientID%>').value = 1;
                return 1;
            }
        return 1;
    }

    function minmax1() {

        var minVal1 = parseInt($("#<%=txtStaffUsersMin.ClientID%>").val());
        var maxVal1 = parseInt($("#<%=txtStaffUsersMax.ClientID%>").val());
        if ($("#<%=txtStaffUsersMin.ClientID%>").val() == 0) {
            document.getElementById('<%=txtStaffUsersMin.ClientID%>').value = 1;
            return 1;
        }
        if ($("#<%=txtStaffUsersMax.ClientID%>").val() == 0) {
            document.getElementById('<%=txtStaffUsersMax.ClientID%>').value = 1;
            return 1;
        }
        else if (minVal1 > maxVal1) {
            alert("Value should be less than maximum Value");
            document.getElementById('<%=txtStaffUsersMin.ClientID%>').value = 1;
            return 1;
        }
    return 1;
}

$(document).ready(function () {
    $("#<%=txtAdminUsersMin.ClientID%>").keydown(function (e) {
        var a = $("#<%=txtAdminUsersMin.ClientID%>").val();
        if (a.length >= 1) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        } else {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 49 || e.keyCode > 57)) && (e.keyCode < 97 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }
    });
});
$(document).ready(function () {
    $("#<%=txtAdminUsersMax.ClientID%>").keydown(function (e) {
        var a = $("#<%=txtAdminUsersMax.ClientID%>").val();
        if (a.length >= 1) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        } else {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 49 || e.keyCode > 57)) && (e.keyCode < 97 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }
    });
});
$(document).ready(function () {
    $("#<%=txtStaffUsersMin.ClientID%>").keydown(function (e) {
        var a = $("#<%=txtStaffUsersMin.ClientID%>").val();
        if (a.length >= 1) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        } else {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 49 || e.keyCode > 57)) && (e.keyCode < 97 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }
    });
});
$(document).ready(function () {
    $("#<%=txtStaffUsersMax.ClientID%>").keydown(function (e) {
        var a = $("#<%=txtStaffUsersMax.ClientID%>").val();
        if (a.length >= 1) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        } else {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 190]) !== -1 || (e.keyCode == 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 49 || e.keyCode > 57)) && (e.keyCode < 97 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }
    });
});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <a href="PackageMaster.aspx">Package Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Package Master</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <asp:UpdatePanel runat="server" ID="upAdd">
                <ContentTemplate>
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
                                    Free Trial Package:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:CheckBox runat="server" ID="chkTrial" TabIndex="2" AutoPostBack="True" OnCheckedChanged="chkTrial_CheckedChanged"></asp:CheckBox>
                                </div>
                            </div>
                            <div id="NoOfTrialDays" runat="server" class="form-group" visible="False">
                                <div class="col-lg-4 control-label">
                                    No Of Trial Days:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox runat="server" ID="txtNoTrialDays" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    No Of Admin Users Login:
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox Text="1" ID="txtAdminUsersMin" TabIndex="4" class="form-control text" onkeyup="minmax()" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    to
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox Text="1" ID="txtAdminUsersMax" TabIndex="5" class="form-control text" onkeyup="minmax()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    No Of Staff Users Login:
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox Text="1" ID="txtStaffUsersMin" TabIndex="6" class="form-control text" onkeyup="minmax1()" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    to
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox Text="1" ID="txtStaffUsersMax" TabIndex="7" CssClass="form-control text" onkeyup="minmax1()" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Monthly Price Currency:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList ID="ddlMonthCurrency" TabIndex="8" CssClass="form-control text" runat="server" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Price Per Month:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtPricePerMonth" TabIndex="9" class="form-control text" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Yearly Price Currency:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList ID="ddlYearlyCurrency" TabIndex="10" CssClass="form-control text" runat="server" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Price Per Year:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtPricePerYear" TabIndex="11" class="form-control text" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Description:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" TabIndex="12" CssClass="form-control text" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Package Status:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:CheckBox runat="server" ID="chkStatus" TabIndex="13" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="page-header">
            <h1>Package Details</h1>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <%--<asp:GridView runat="server" ID="gvAddModule" Width="100%" Font-Size="Small" AutoGenerateColumns="False"
                    DataKeyNames="ModuleID" CssClass="table table-bordered table-hover" DataSourceID="sqldsModule">
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Records Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ModuleID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ModuleID" />
                        <asp:BoundField DataField="ModuleName" HeaderText="Name" SortExpression="ModuleName" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkModuleStatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
                <asp:GridView ID="gvPackageDetails" runat="server" Width="100%" Font-Size="Small" AutoGenerateColumns="False" DataKeyNames="ModuleID"
                    CssClass="table table-bordered table-hover" DataSourceID="objdsModule">
                    <EmptyDataTemplate>
                        <div style="text-align: center; width: 100%;">
                            No Records Found
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lnkModuleID" runat="server" Text='<%#Eval("ModuleID") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lnkModuleName" runat="server" Text='<%#Eval("ModuleName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkModuleStatus" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="14" CssClass="btn btn-primary" ValidationGroup="PackageMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="15" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="17" CssClass="btn btn-primary" ValidationGroup="PackageMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="18" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="16" CssClass="btn btn-info" OnClick="btnListAll_Click" />
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
                            Free Trial Package:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblTrial"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group" id="NoOfTrialDaysView" runat="server">
                        <div class="col-lg-4 control-label">
                            No Of Trial Days:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblNoTrialDays"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            No Of Admin Users Login:
                        </div>
                        <div class="col-lg-2">
                            <asp:Label Text="1" ID="lblAdminUsersMin" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            to
                        </div>
                        <div class="col-lg-2">
                            <asp:Label Text="1" ID="lblAdminUsersMax" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            No Of Staff Users Login:
                        </div>
                        <div class="col-lg-2">
                            <asp:Label Text="1" ID="lblStaffUsersMin" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            to
                        </div>
                        <div class="col-lg-2">
                            <asp:Label Text="1" ID="lblStaffUsersMax" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Monthly Price Currency:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblMonthCurrency" runat="server">
                            </asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Price Per Month:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblPricePerMonth" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Yearly Price Currency:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblYearlyCurrency" runat="server">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Price Per Year:
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
                    DataKeyNames="PackageDetailID" CssClass="table table-bordered table-hover" DataSourceID="sqldsViewPackage">
                    <Columns>
                        <asp:BoundField DataField="PackageDetailID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="PackageDetailID"></asp:BoundField>
                        <asp:BoundField DataField="ModuleName" HeaderText="Name" SortExpression="ModuleName"></asp:BoundField>
                        <asp:CheckBoxField DataField="ModuleStatus" HeaderText="Status" SortExpression="ModuleStatus"></asp:CheckBoxField>
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
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="19" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="20" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="21" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="22" CssClass="btn btn-primary" OnClick="btnAddPackage_Click" />
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
                        DataKeyNames="PackageID" DataSourceID="objdsPackage" OnSelectedIndexChanged="gvPackage_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvPackage_PageIndexChanging" CssClass="table table-bordered table-hover">
                        <Columns>
                            <asp:BoundField DataField="PackageID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="PackageID"></asp:BoundField>
                            <asp:BoundField DataField="PackageName" HeaderText="Package Name" SortExpression="PackageName"></asp:BoundField>
                            <asp:BoundField DataField="FreeTrialPackage" HeaderText="Trial Package" SortExpression="FreeTrialPackage"></asp:BoundField>
                            <asp:BoundField DataField="PricePerMonth" HeaderText="Price Per Month" SortExpression="PricePerMonth" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="PricePerYear" HeaderText="Price Per Year" SortExpression="PricePerYear" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>
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
    <asp:ObjectDataSource runat="server" ID="objdsPackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.PackageMasterTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="objdsModule" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ModuleMasterTableAdapter"></asp:ObjectDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsModule" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [ModuleMaster] WHERE ([ModuleStatus] = @ModuleStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ModuleStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsViewPackage" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT PackageDetailID,b.ModuleName,a.ModuleStatus FROM PackageDetails a INNER JOIN ModuleMaster b ON a.ModuleID = b.ModuleID WHERE PackageID = @PackageID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfPackage" PropertyName="Value" DefaultValue="0" Name="PackageID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfPackage" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
