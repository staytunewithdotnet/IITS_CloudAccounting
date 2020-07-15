<%@ Page Title="Contact Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="ContactMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ContactMaster" %>

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
                    <a href="ContactMaster.aspx">Contact Master</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Add/Edit Contact Details</h1>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Company Name:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control text" TabIndex="1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Company Name Reqiured" ControlToValidate="txtCompanyName" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Contact Person:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtContactPerson" CssClass="form-control text" TabIndex="2" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text" TabIndex="3" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Address1 Reqiured" ControlToValidate="txtAddress1" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text" TabIndex="4" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtAddress2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Address2 Reqiured" ControlToValidate="txtAddress2" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 3:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAddress3" CssClass="form-control text" TabIndex="5" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 4:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtAddress4" CssClass="form-control text" TabIndex="6" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Zip Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text" TabIndex="7" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="col-lg-1">
                            <asp:RequiredFieldValidator ID="rfvZipCode" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Zip Code Reqiured" ControlToValidate="txtZipCode" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server" ID="upCountry">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    Country:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCountry" TabIndex="8" AutoPostBack="True" CssClass="form-control text"
                                        DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCountry" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] where (CountryStatus='True')"></asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvCountryName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Current Country Reqiured" InitialValue="0" ControlToValidate="ddlCountry" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    State:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlState" DataSourceID="sqldsState" TabIndex="9" CssClass="form-control text"
                                        DataTextField="StateName" DataValueField="StateID" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsState" ConnectionString="<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>"
                                        SelectCommand="SELECT - 1 AS StateID, '[choose one]' AS Statename UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE ([CountryID] = @CountryID AND StateStatus='True')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlCountry" Name="CountryID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvCurrentState" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Current State Reqiured" InitialValue="0" ControlToValidate="ddlState" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4 control-label">
                                    City:
                                </div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control text" AutoPostBack="True" TabIndex="10" DataSourceID="sqldsCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT - 1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([CityStatus] = @CityStatus) AND ([StateID] = @StateID))">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
                                            <asp:ControlParameter ControlID="ddlState" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvCurrentCity" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Current City Reqiured" InitialValue="0" ControlToValidate="ddlCity" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Phone 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPhone1" CssClass="form-control text" TabIndex="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Phone Number Reqiured" ControlToValidate="txtPhone1" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Phone 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtPhone2" CssClass="form-control text" TabIndex="12"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Mobile 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtMobile1" CssClass="form-control text" TabIndex="13"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobile1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Mobile Number Reqiured" ControlToValidate="txtMobile1" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Mobile 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtMobile2" CssClass="form-control text" TabIndex="14"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEmail1" CssClass="form-control text" TabIndex="15"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="EMail Reqiured" ControlToValidate="txtEmail1" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEmail2" CssClass="form-control text" TabIndex="16"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Fax 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFax1" CssClass="form-control text" TabIndex="17"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFax1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Fax 1 Reqiured" ControlToValidate="txtFax1" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Fax 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtFax2" CssClass="form-control text" TabIndex="18"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Website:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control text" TabIndex="19" ValidationGroup="Contact"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtWebsite" runat="server" ControlToValidate="txtWebsite"
                                CssClass="form-control text" ErrorMessage="Please Enter WebSite" Text="*" Display="Dynamic" ForeColor="red"
                                EnableClientScript="true" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reftxtWebsite" runat="server" ErrorMessage="Not Valid WebSite" Display="Dynamic" ForeColor="red"
                                Text="*" ControlToValidate="txtWebsite" CssClass="form-control text" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                ValidationGroup="Contact"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Google Map Code:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtGoogleMapCode" CssClass="form-control text" TabIndex="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGoogleMapCode" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Fax 1 Reqiured" ControlToValidate="txtGoogleMapCode" ValidationGroup="ContactMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:CheckBox runat="server" ID="chkStatus" TabIndex="21" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="22" CssClass="btn btn-primary" ValidationGroup="ContactMaster" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" TabIndex="23" CssClass="btn btn-default" OnClick="btnReset_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="25" CssClass="btn btn-primary" ValidationGroup="ContactMaster" OnClick="btnUpdate_Click" />
                <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="26" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                <asp:Button ID="btnListAll" runat="server" Text="List All" TabIndex="24" CssClass="btn btn-info" OnClick="btnListAll_Click" />--%>
            </div>
        </div>
    </asp:Panel>
    <%--<asp:Panel runat="server" ID="pnlView">
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
                            Contact Person:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblContactPerson"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddress1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddress2"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 3:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddress3"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Address 4:                                
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblAddress4"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Zip Code:                                 
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblZipCode"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Country:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCountry"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            State:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblState"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            City:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblCity"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Phone 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPhone1"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Phone 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblPhone2"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Mobile 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblMobile1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Mobile 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblMobile2"></asp:Label>
                        </div>

                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblEmail1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Email 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblEmail2"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Fax 1:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFax1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Fax 2:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblFax2"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Website:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Google Map Code:
                        </div>
                        <div class="col-lg-8" style="overflow: auto">
                            <asp:Label runat="server" ID="lblGoogleMapCode"></asp:Label>
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
                <asp:Button ID="btnEdit" runat="server" Text="Edit" TabIndex="27" CssClass="btn btn-primary" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" TabIndex="28" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                <asp:Button ID="btnList" runat="server" Text="List All" TabIndex="29" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" TabIndex="30" CssClass="btn btn-primary" OnClick="btnAddContact_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvContact" AutoGenerateColumns="False" DataKeyNames="ContactID" DataSourceID="objdsContact" Width="100%"
                        CssClass="table table-bordered table-hover" AllowPaging="True" PageSize="15" OnSelectedIndexChanged="gvContact_SelectedIndexChanged"
                        OnPageIndexChanging="gvContact_PageIndexChanging">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ContactID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ContactID" />
                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" SortExpression="ContactPerson" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" />
                            <asp:BoundField DataField="Email1" HeaderText="Email" SortExpression="Email1" />
                            <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnAddNew" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddContact_Click" />
            </div>
        </div>
        <asp:ObjectDataSource ID="objdsContact" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.ContactMasterTableAdapter"></asp:ObjectDataSource>
    </asp:Panel>--%>
    <asp:HiddenField runat="server" ID="hfContact" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
</asp:Content>
