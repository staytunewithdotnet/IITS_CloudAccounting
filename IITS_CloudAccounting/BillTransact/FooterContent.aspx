<%@ Page Title="Footer Content" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="FooterContent.aspx.cs" Inherits="IITS_CloudAccounting.Admin.FooterContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">CMS Masters
                    </a>
                </li>
                <li>
                    <a href="FooterContent.aspx">Footer Content</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Footer Content Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Footer Content:
                        </div>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtFooterContent" TabIndex="1" TextMode="MultiLine" CssClass="form-control text" runat="server" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="2" CssClass="btn btn-primary" ValidationGroup="HomeMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="3" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="4" CssClass="btn btn-primary" ValidationGroup="HomeMaster" OnClick="btnUpdate_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%--<asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Short Description:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblAShortDescription" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="10" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="11" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="12" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddHome_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvHome" AutoGenerateColumns="False" DataKeyNames="HomeID" DataSourceID="objdsHome" Width="100%"
                        OnSelectedIndexChanged="gvHome_SelectedIndexChanged" OnPageIndexChanging="gvHome_PageIndexChanging"
                        CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="HomeID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="HomeID" />
                            <asp:BoundField DataField="HomeDesc" HeaderText="Desc" SortExpression="HomeDesc" />
                            <asp:BoundField DataField="HomeContent" HeaderText="Content" SortExpression="HomeContent" />
                            <asp:BoundField DataField="HomeStatus" HeaderText="Status" SortExpression="HomeStatus" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddHome_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsHome" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.HomeMasterTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>--%>
    <asp:HiddenField runat="server" ID="hfFooter" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
