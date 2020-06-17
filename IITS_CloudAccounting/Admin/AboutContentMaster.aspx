<%@ Page Title="About Content Master" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AboutContentMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.AboutContentMaster" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit.HTMLEditor" Assembly="AjaxControlToolkit, Version=4.5.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-ul"></i>
                    <a href="#">CMS Masters
                    </a>
                </li>
                <li>
                    <a href="AboutContentMaster.aspx">About Content Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit About Content Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            About Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList ID="ddlAboutCategory" runat="server" CssClass="form-control text" TabIndex="1" DataSourceID="sqldsAboutCategory" DataTextField="AboutCategoryName" DataValueField="AboutCategoryID"></asp:DropDownList>
                            <asp:SqlDataSource ID="sqldsAboutCategory" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT -1 AS AboutCategoryID, '--Select Category Name--' AS AboutCategoryName UNION SELECT [AboutCategoryID], [AboutCategoryName] FROM [AboutCategoryMaster] WHERE ([AboutCategoryStatus] = @AboutCategoryStatus)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="AboutCategoryStatus" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvAboutCategory" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="AboutCategoryName Reqiured" InitialValue="-1" ControlToValidate="ddlAboutCategory" ValidationGroup="AboutContent">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="2" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Content Image:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:FileUpload ID="fuAboutContentImage" runat="server" CssClass="form-control text" TabIndex="3" ValidationGroup="AboutContent" />
                            <%--<asp:RequiredFieldValidator ID="rfvfuAboutContentImage" runat="server" ForeColor="red" ControlToValidate="fuAboutContentImage" ErrorMessage="Please Upload File" Text="*" Display="Dynamic" EnableClientScript="true" ValidationGroup="AboutContent"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            About Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <ajaxToolkit:Editor runat="server" ID="edContent" Height="250px" Width="102%" TabIndex="4" ValidationGroup="AboutContent" />
                            <asp:RequiredFieldValidator ID="rfvAboutContent" runat="server" ControlToValidate="edContent" ForeColor="red" ErrorMessage="Please Enter Content Details" Text="*" Display="Dynamic" EnableClientScript="true" ValidationGroup="AboutContent"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-1">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="AboutContent" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="6" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="8" CssClass="btn btn-primary" ValidationGroup="AboutContent" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="9" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="7" CssClass="btn btn-info" OnClick="btnListAll_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            About Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblAboutCategory" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" TabIndex="2" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Content Image:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Image ID="imgAboutContentImage" runat="server" Width="150px" Height="150px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            About Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblContent" />
                        </div>
                        <div class="col-lg-1">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="10" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="11" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="12" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddAboutContent_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvAboutContent" AutoGenerateColumns="False" DataKeyNames="AboutContentID" DataSourceID="objdsAboutContent" Width="100%"
                        OnSelectedIndexChanged="gvAboutContent_SelectedIndexChanged" OnPageIndexChanging="gvAboutContent_PageIndexChanging"
                        OnRowDataBound="gvAboutContent_RowDataBound" CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15">
                        <EmptyDataTemplate>
                                <div style="text-align: center; width: 100%;">
                                    No Records Found
                                </div>
                            </EmptyDataTemplate>
                            <RowStyle HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="AboutContentID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="AboutContentID" />
                            <asp:BoundField DataField="AboutCategoryID" HeaderText="About Category" SortExpression="AboutCategoryID" />
                            <asp:BoundField DataField="AboutContent" HeaderText="AboutContent" SortExpression="AboutContent" />
                            <asp:BoundField DataField="AboutContentStatus" HeaderText="Status" SortExpression="AboutContentStatus" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddAboutContent_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsAboutContent" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.AboutContentMasterTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfAboutContent" />
<asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
