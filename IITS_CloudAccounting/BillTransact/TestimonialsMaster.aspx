<%@ Page Title="Testimonials Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="TestimonialsMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TestimonialsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"/>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">CMS Master
                    </a>
                </li>
                <li>
                    <a href="TestimonialsMaster.aspx">Testimonials Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Testimonials Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Testimonials Name Reqiured" ControlToValidate="txtName" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Company Name Reqiured" ControlToValidate="txtCompanyName" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Location:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Testimonial Location Reqiured" ControlToValidate="txtLocation" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Comment:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" CssClass="form-control text" TabIndex="4" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control text" TabIndex="5" />
                            <ajaxToolkit:CalendarExtender runat="server" ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtDate"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="6" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="7" CssClass="btn btn-primary" ValidationGroup="TestimonialsMaster" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="8" CssClass="btn btn-default" OnClick="btnReset_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="10" CssClass="btn btn-primary" ValidationGroup="TestimonialsMaster" OnClick="btnUpdate_Click" />
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
                            Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblName" Text="Name"></asp:Label>
                        </div>
                    </div>
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
                            Location:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblLocation"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Comment:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblComment" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Date:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblDate" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Testimonial Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblStatus" Text="Status" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="12" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="13" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="14" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="15" CssClass="btn btn-primary" OnClick="btnAddTestimonials_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvTestimonials" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="TestimonialID"
                        DataSourceID="objdsTestimonials" OnSelectedIndexChanged="gvTestimonials_SelectedIndexChanged" PageSize="50"
                        OnPageIndexChanging="gvTestimonials_PageIndexChanging" CssClass="table table-bordered table-hover">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TestimonialID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="TestimonialID" />
                            <asp:BoundField DataField="TestimonialName" HeaderText="Name" SortExpression="TestimonialName" />
                            <asp:BoundField DataField="TestimonialCompanyName" HeaderText="Company Name" SortExpression="TestimonialCompanyName" />
                            <asp:BoundField DataField="TestimonialLocation" HeaderText="Location" SortExpression="TestimonialLocation" />
                            <asp:BoundField DataField="TestimonialDate" HeaderText="Date" SortExpression="TestimonialDate" DataFormatString="{0:dd/MMM/yyyy}" />
                            <asp:BoundField DataField="TestimonialStatus" HeaderText="Status" SortExpression="TestimonialStatus" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button ID="btnAddTestimonials" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddTestimonials_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfTestimonials" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
    <asp:ObjectDataSource runat="server" ID="objdsTestimonials" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.TestimonialsMasterTableAdapter"></asp:ObjectDataSource>
</asp:Content>
