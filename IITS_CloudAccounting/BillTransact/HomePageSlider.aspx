<%@ Page Title="Home Page Slider" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="HomePageSlider.aspx.cs" Inherits="IITS_CloudAccounting.Admin.HomePageSlider" %>

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
                    <a href="HomePageSlider.aspx">Home Page Slider</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Home Page Slider</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:FileUpload ID="flUploadSlider1" runat="server" TabIndex="1" />
                            <asp:RequiredFieldValidator ID="rfvflUploadSlider1" runat="server" ControlToValidate="flUploadSlider1" ForeColor="red" Display="Dynamic" ErrorMessage="Select Slider 1" SetFocusOnError="True" ValidationGroup="HomePageSliderChange">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 1 Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <ajaxToolkit:Editor runat="server" ID="edContent1" Width="100%" Height="150px" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <%--<div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 3:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:FileUpload ID="flUploadSlider3" runat="server" TabIndex="3" />
                            <asp:RequiredFieldValidator ID="rfvflUploadSlider3" runat="server" ControlToValidate="flUploadSlider3" ForeColor="red" Display="Dynamic" ErrorMessage="Select Slider3" SetFocusOnError="True" ValidationGroup="HomePageSliderChange">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 4:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:FileUpload ID="flUploadSlider4" runat="server" TabIndex="4" />
                            <asp:RequiredFieldValidator ID="rfvflUploadSlider4" runat="server" ControlToValidate="flUploadSlider4" ForeColor="red" Display="Dynamic" ErrorMessage="Select Slider3" SetFocusOnError="True" ValidationGroup="HomePageSliderChange">*</asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:FileUpload ID="flUploadSlider2" runat="server" TabIndex="2" />
                            <asp:RequiredFieldValidator ID="rfvflUploadSlider2" runat="server" ControlToValidate="flUploadSlider2" ForeColor="red" Display="Dynamic" ErrorMessage="Select Slider2" SetFocusOnError="True" ValidationGroup="HomePageSliderChange">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 2 Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <ajaxToolkit:Editor runat="server" ID="edContent2" Width="100%" Height="150px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="HomePageSliderChange" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="6" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="8" CssClass="btn btn-primary" ValidationGroup="HomePageSliderChange" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="9" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                <%--<asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="7" CssClass="btn btn-info" OnClick="btnListAll_Click" />--%>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Image ID="imgSlider1" runat="server" Height="150px" Width="150px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 1 Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblContent1" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Image ID="imgSlider2" runat="server" Height="150px" Width="150px" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Slider 2 Content:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblContent2" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="10" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
<%--                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="11" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="12" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddHomePageSlider_Click" />--%>
            </div>
        </div>
    </asp:Panel>
    <%--<asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvHomePageSlider" AutoGenerateColumns="False" DataKeyNames="HomePageSliderID" DataSourceID="objdsHomePageSlider" Width="100%"
                        CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15"
                        OnSelectedIndexChanged="gvHomePageSlider_SelectedIndexChanged" OnPageIndexChanging="gvHomePageSlider_PageIndexChanging">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="HomePageSliderID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="HomePageSliderID" />
                            <asp:BoundField DataField="SliderContent1" HeaderText="Slider Content 1" SortExpression="SliderContent1" />
                            <asp:BoundField DataField="SliderContent2" HeaderText="Slider Content 2" SortExpression="SliderContent2" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" TabIndex="13" CssClass="btn btn-primary" OnClick="btnAddHomePageSlider_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsHomePageSlider" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.HomePageSliderTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>--%>
    <asp:HiddenField runat="server" ID="hfHome" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID"/>
    <asp:HiddenField runat="server" ID="hfCompanyID"/>
    <asp:HiddenField runat="server" ID="hfCompanyLoginID"/>
</asp:Content>
