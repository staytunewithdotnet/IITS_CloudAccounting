<%@ Page Title="Update Staff Profile" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="UpdateStaffProfile.aspx.cs" Inherits="IITS_CloudAccounting.Admin.UpdateStaffProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <div class="row" style="margin-top: -100px;">
        <div class="col-sm-12">
            <%--<ol class="breadcrumb">
                <li>
                    <a href="#">Profile
                    </a>
                </li>
                <li>
                    <a href="UpdateCompanyDetail.aspx">Update Company Detail</a>
                </li>
            </ol>--%>
        </div>
    </div>

    <div id="divUpdate" runat="server" visible="False" style="margin-top: 50px;">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your profile has been updated.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div class="clearfix"></div>

    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="panel-body" style="padding-bottom: 50px;">
                <div class="page-header" style="border-bottom: 5px solid #eee;">
                    <h1>Update Your Profile</h1>
                </div>
                <asp:UpdatePanel runat="server" ID="upCompany">
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3>Account Details</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Email<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtStaffEmail" CssClass="form-control text" MaxLength="50" AutoPostBack="True"></asp:TextBox><%--OnTextChanged="txtEmail_OnTextChanged"--%>
                                        <asp:RequiredFieldValidator ID="rfvStaffEmail" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffEmail" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="StaffMaster" ControlToValidate="txtStaffEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Name<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtStaffFirstName" CssClass="form-control text" TabIndex="1" MaxLength="50" Style="text-transform: capitalize;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvStaffFirstName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffFirstName" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        First Name
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtStaffLastName" CssClass="form-control text" TabIndex="2" MaxLength="50" Style="text-transform: capitalize;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvStaffLastName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffLastName" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        Last Name
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Username<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control text" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvUsername" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtUsername" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Change Password
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtCurrentPassword" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                        Current Password
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control text" TabIndex="4" TextMode="Password"></asp:TextBox>
                                        New Password
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control text" TabIndex="5" TextMode="Password"></asp:TextBox>
                                        Confirm Password
                                        <asp:CompareValidator runat="server" ID="cvPassword" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="StaffMaster">*</asp:CompareValidator>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3>Contact Information</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="col-lg-1" style="width: 13.5%;">
                                    &nbsp;
                                </div>
                                <div class="col-lg-5">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">Home Phone</div>
                                        <div class="col-lg-9">
                                            <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control text" TabIndex="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">Mobile</div>
                                        <div class="col-lg-9">
                                            <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control text" TabIndex="7"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-5">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">Bussiness Phone</div>
                                        <div class="col-lg-9">
                                            <asp:TextBox runat="server" ID="txtBussinessPhone" CssClass="form-control text" TabIndex="8"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">Fax</div>
                                        <div class="col-lg-9">
                                            <asp:TextBox runat="server" ID="txtFax" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Country
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control text" TabIndex="10" DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Address
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text" TabIndex="11"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text" TabIndex="12"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control text" TabIndex="13" DataSourceID="sqldsState" DataTextField="StateName" DataValueField="StateID" AutoPostBack="True" />
                                            Province/State
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control text" TabIndex="14" DataSourceID="sqldsCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="15"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label"></div>
                                    <div class="col-lg-9">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" TabIndex="16" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE (([StateStatus] = @StateStatus) AND ([CountryID] = @CountryID))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="StateStatus" Type="Boolean"></asp:Parameter>
            <asp:ControlParameter ControlID="ddlCountry" PropertyName="SelectedValue" DefaultValue="0" Name="CountryID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([StateID] = @StateID) AND ([CityStatus] = @CityStatus))">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlState" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
