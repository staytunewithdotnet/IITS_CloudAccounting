<%@ Page Title="FAQ Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="FAQMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.FAQMaster" %>

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
                    <a href="FAQMaster.aspx">FAQ Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit FAQ Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            FAQ  Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:DropDownList ID="ddlFAQCategory" runat="server" CssClass="form-control text" TabIndex="1" DataSourceID="sqldsFAQCategory" DataTextField="FAQCategoryName" DataValueField="FAQCategoryID"></asp:DropDownList>
                            <asp:SqlDataSource ID="sqldsFAQCategory" runat="server" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>" SelectCommand="SELECT -1 AS FAQCategoryID, '--Select Category Name--' AS FAQCategoryName UNION SELECT [FAQCategoryID], [FAQCategoryName] FROM [FAQCategoryMaster] WHERE ([FAQCategoryStatus] = @FAQCategoryStatus)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="FAQCategoryStatus" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:RequiredFieldValidator ID="rfvFAQName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="FAQName Reqiured" InitialValue="0" ControlToValidate="ddlFAQCategory" ValidationGroup="FAQMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            FAQ Question:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFAQQuestion" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFAQQuestion" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="FAQ Question Reqiured" ControlToValidate="txtFAQQuestion" ValidationGroup="FAQMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            FAQ Answer:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFAQAnswer" CssClass="form-control text" TabIndex="3" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="4" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="FAQMaster" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="6" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="8" CssClass="btn btn-primary" ValidationGroup="FAQMaster" OnClick="btnUpdate_Click" />
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
                            FAQ  Category:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblFAQCategory" runat="server">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            FAQ Question:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFAQQuestion"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            FAQ Answer:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFAQAnswer"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" />
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
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddFAQ_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvFAQ" AutoGenerateColumns="False" DataKeyNames="FAQID" DataSourceID="objdsFAQ" Width="100%"
                        CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15" OnRowDataBound="gvFAQ_RowDataBound"
                        OnSelectedIndexChanged="gvFAQ_SelectedIndexChanged" OnPageIndexChanging="gvFAQ_PageIndexChanging">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="FAQID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="FAQID" />
                            <asp:BoundField DataField="FAQCategoryID" HeaderText="FAQ Category" SortExpression="FAQCategoryID" />
                            <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                            <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddFAQ_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsFAQ" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.FAQMasterTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfFAQ" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
