<%@ Page Title="State Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StateMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.StateMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">General Master
                    </a>
                </li>
                <li>
                    <a href="StateMaster.aspx">State Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit State Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Select Country:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="1" CssClass="form-control text"
                                DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" />
                            <asp:SqlDataSource runat="server" ID="sqldsCountry"
                                ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where(CountryStatus='True')"></asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" SetFocusOnError="True" ControlToValidate="ddlCountry" ForeColor="red"
                                ErrorMessage="Select Country" InitialValue="-1" ValidationGroup="StateMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtCode" TabIndex="2" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic"
                                ErrorMessage="State Code Reqiured" ControlToValidate="txtCode" ValidationGroup="StateMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtName" TabIndex="3" CssClass="form-control text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="State Name Reqiured" ControlToValidate="txtName" ValidationGroup="StateMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDesc" TabIndex="4" CssClass="form-control text" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="5" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="6" CssClass="btn btn-primary" ValidationGroup="StateMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="7" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="9" CssClass="btn btn-primary" ValidationGroup="StateMaster" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="10" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="8" CssClass="btn btn-info" OnClick="btnListAll_Click" />
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
                            Select Country:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCountry"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCode"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblName"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Desc:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblDesc"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="11" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="12" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="13" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="14" CssClass="btn btn-primary" OnClick="btnAddState_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                        <asp:GridView runat="server" ID="gvState" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="StateID"
                            DataSourceID="objdsState" OnSelectedIndexChanged="gvState_SelectedIndexChanged" PageSize="50"
                            OnPageIndexChanging="gvState_PageIndexChanging" OnRowDataBound="gvState_RowDataBound" CssClass="table table-bordered table-hover">
                            <EmptyDataTemplate>
                                <div style="text-align: center; width: 100%;">
                                    No Records Found
                                </div>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="StateID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="StateID" />
                                <asp:BoundField DataField="CountryID" HeaderText="Country" SortExpression="CountryID" />
                                <asp:BoundField DataField="StateCode" HeaderText="Code" SortExpression="StateCode" />
                                <asp:BoundField DataField="StateName" HeaderText="Name" SortExpression="StateName" />
                                <asp:BoundField DataField="StateDesc" HeaderText="Description" SortExpression="StateDesc" />
                                <asp:BoundField DataField="StateStatus" HeaderText="Status" SortExpression="StateStatus" />
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddState" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddState_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfState" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
    <asp:ObjectDataSource runat="server" ID="objdsState" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.StateMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
