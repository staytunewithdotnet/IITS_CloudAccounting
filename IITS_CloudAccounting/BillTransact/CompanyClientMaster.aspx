<%@ Page Title="Company Client Master" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" Async="true"
    AutoEventWireup="true" CodeBehind="CompanyClientMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyClientMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("peopleDiv");
            p.style.display = 'block';
        });

        function showAddressDiv() {
            var showA = document.getElementById("showAtag");
            var hideA = document.getElementById("hideAtag");
            var mainDiv = document.getElementById("secondaryAddress");
            showA.style.display = 'none';
            hideA.style.display = 'block';
            mainDiv.style.display = 'block';
        }

        function hideAddressDiv() {
            var showA = document.getElementById("showAtag");
            var hideA = document.getElementById("hideAtag");
            var mainDiv = document.getElementById("secondaryAddress");
            showA.style.display = 'block';
            hideA.style.display = 'none';
            mainDiv.style.display = 'none';
        }
    </script>
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-users"></i>
                    <a href="#">People
                    </a>
                </li>
                <li>
                    <a href="CompanyClientMaster.aspx">Client Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divImport" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3 style="color: #4c8700;">Congrats! We successfully imported 
                    <asp:Label runat="server" ID="lblImported"></asp:Label>
                    contacts!</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your client has been saved.</h3>
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>
                        <a href="InvoiceMasterNew.aspx" class="permission">Create an invoice</a> for this client.
                    </li>
                    <li>
                        <a href="RecurringInvoice.aspx" class="permission">Create a recurring profile</a> for this client.
                    </li>
                    <li>
                        <a href="EstimateMaster.aspx" class="permission">Create an estimate</a> for this client.
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="True">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your client has been updated.</h3>
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>
                        <a href="InvoiceMasterNew.aspx" class="permission">Create an invoice</a> for this client.
                    </li>
                    <li>
                        <a href="RecurringInvoice.aspx" class="permission">Create a recurring profile</a> for this client.
                    </li>
                    <li>
                        <a href="EstimateMaster.aspx" class="permission">Create an estimate</a> for this client.
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0;">
                <h1>New Client </h1>
            </div>
            <asp:UpdatePanel runat="server" ID="upCompanyClient">
                <ContentTemplate>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3 style="margin: 0">Organization</h3>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Organization Name <span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtClientName" CssClass="form-control text" TabIndex="1" MaxLength="50" Style="text-transform: capitalize;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvClientName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtClientName" ValidationGroup="CompanyClientMaster">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Currency <span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control text" DataSourceID="sqldsCurrency" DataTextField="CurrencyName" DataValueField="CurrencyID" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvCurrency" ControlToValidate="ddlCurrency" SetFocusOnError="True" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientMaster" InitialValue="-1">*</asp:RequiredFieldValidator>
                                        <asp:SqlDataSource runat="server" ID="sqldsCurrency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrencyID, '[choose one]' AS CurrencyName UNION SELECT [CurrencyID], [CurrencyName] + ' (' + [CurrencySymbol] + ')' AS CurrencyName FROM [CurrencyMaster] WHERE ([CurrencyStatus] = @CurrencyStatus)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="CurrencyStatus" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Send Invoices By
                                    </div>
                                    <div class="col-lg-9" style="padding-top: 8px;">
                                        <asp:CheckBox runat="server" ID="chkEmail" Text="Email" Checked="True" />
                                        <asp:CheckBox runat="server" ID="chkSnailMail" Text="Snail Mail" Visible="False" />
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
                                        <h3>Contacts</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Email <span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control text" Style="width: 96% !important;" MaxLength="50" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="CompanyClientMaster" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="CompanyClientMaster" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Contact Name
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-6" style="padding: 0;">
                                            <asp:TextBox runat="server" ID="txtFirstName" PlaceHolder="First Name" onkeypress="return isLetter(event)" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6" style="padding-left: 0">
                                            <asp:TextBox runat="server" ID="txtLastName" PlaceHolder="Last Name" onkeypress="return isLetter(event)" CssClass="form-control text" Style="text-transform: capitalize;"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">Home Phone</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtHomePhone" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">Mobile</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 control-label">
                            Login Credentials
                        </div>
                        <div class="col-lg-9" style="margin-bottom: 15px;">
                            <asp:CheckBox runat="server" ID="chkAssignUsername" Text="Assign Username and Password" AutoPostBack="True" OnCheckedChanged="chkAssignUsername_OnCheckedChanged" />
                            <br />
                            <br />
                            <div id="usernameDiv" runat="server" visible="False">
                                <div class="col-lg-4" style="padding-left: 0;">
                                    <asp:TextBox runat="server" ID="txtUsername" PlaceHolder="User Name" AutoPostBack="True" OnTextChanged="txtUsername_OnTextChanged" CssClass="form-control text"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblUsernameAdd" Visible="False"></asp:Label>
                                </div>
                                <div class="col-lg-4" style="padding-left: 0;">
                                    <asp:TextBox runat="server" ID="txtPassword" PlaceHolder="New Password" CssClass="form-control text"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblPasswordAdd" Visible="False"></asp:Label>
                                </div>
                                <div class="col-lg-4" style="padding-left: 0;">
                                    <asp:TextBox runat="server" ID="txtConfPassword" PlaceHolder="Confirm Password" CssClass="form-control text"></asp:TextBox>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-12" style="padding-left: 0;">
                                    <div style="background-color: #fff4d6; padding: 10px 20px 10px 10px;">
                                        <asp:CheckBox runat="server" ID="chkSend" Text="Send login information" />

                                        <asp:Label runat="server" ID="lblInvitation"></asp:Label>
                                        <br />
                                        If no password is entered, a random password will be created and sent with each invitation.
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <style>
                            .gridTable.table > tbody > tr > th:last-child, .gridTable.table > tbody > tr > td:last-child {
                                background-color: white;
                                border: none;
                            }

                            .gridTable.table > tbody > tr > th {
                                background-color: #0D83DE;
                                border: none;
                                color: #ffffff;
                                font-weight: normal;
                                line-height: 18px;
                                padding: 5px 5px !important;
                            }

                            .gridTable.table > tbody > tr > td {
                                font-weight: normal;
                                line-height: 18px;
                                padding: 5px 5px !important;
                                text-align: left;
                            }

                            .gridTable > button, input, select, textarea, input[type="text"] {
                                font-family: Verdana;
                                font-size: 12px;
                                padding: 2px 6px 2px 0;
                            }

                            a.aTag:hover {
                                background-color: #D4FFFF;
                            }
                        </style>
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-3">
                            <asp:LinkButton runat="server" CssClass="aTag" Style="cursor: pointer; display: block; text-decoration: underline;" ID="lnkAddContact" OnClick="lnkAddContact_Click"><i class="fa fa-plus-circle">&nbsp;</i>Add another contact</asp:LinkButton>
                            <br />
                        </div>
                        <div class="clearfix"></div>
                        <div id="extraContact" runat="server" visible="False" style="margin-bottom: 20px; text-align: center;">
                            <asp:GridView runat="server" ID="gvCompanyClientContact" CssClass="table table-striped gridTable" Width="100%"
                                AutoGenerateColumns="False" GridLines="None" OnRowDeleting="gvCompanyClientContact_OnRowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridEmail" PlaceHolder="Email" AutoPostBack="True" OnTextChanged="txtGridEmail_OnTextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvGridEmail" ControlToValidate="txtGridEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="ClientDetail" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revGridEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="ClientDetail" ControlToValidate="txtGridEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridFirstName" PlaceHolder="First Name" onkeypress="return isLetter(event)"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridLastName" PlaceHolder="Last Name" onkeypress="return isLetter(event)"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Home Phone">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridPhone" PlaceHolder="Home Phone" onkeypress="return isNumber(event)"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridMobile" PlaceHolder="Mobile" onkeypress="return isNumber(event)"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Login">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkGridLogin" AutoPostBack="True" OnCheckedChanged="chkGridLogin_OnCheckedChanged"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridUsername" Placeholder="Username" Enabled="False" AutoPostBack="True" OnTextChanged="txtGridUsername_OnTextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtGridPassword" Placeholder="Password" Enabled="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="../App_Themes/Doyingo/images/delete.png" />
                                </Columns>
                            </asp:GridView>
                            <asp:Button runat="server" ID="btnAddGridRow" Text="Add another contact" Style="padding: 5px 10px;" CssClass="btn-primary" ValidationGroup="ClientDetail" OnClick="btnAddGridRow_Click" />
                        </div>

                        <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>

                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3>Details</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Country
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control text" DataSourceID="sqldsCountry" DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Address
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control text"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control text"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control text" DataSourceID="sqldsState" DataTextField="StateName" DataValueField="StateID" AutoPostBack="True" />
                                            Province/State 
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control text" DataSourceID="sqldsCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control text"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-6" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label"></div>
                                    <div class="col-lg-9">
                                        <a onclick=" showAddressDiv() " id="showAtag" style="display: block;">Show Secondary address</a>
                                        <a onclick=" hideAddressDiv() " id="hideAtag" style="display: none;">Hide Secondary address</a>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal" id="secondaryAddress" style="display: none">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Secondary Country
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList runat="server" ID="ddlCountrySecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryCountry" DataTextField="CountryName" DataValueField="CountryID" AutoPostBack="True" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        SecondaryAddress
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress1Secondary" CssClass="form-control text"></asp:TextBox>
                                        Street 1
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <asp:TextBox runat="server" ID="txtAddress2Secondary" CssClass="form-control text"></asp:TextBox>
                                        Street 2
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-6" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlStateSecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryState" DataTextField="StateName" DataValueField="StateID" AutoPostBack="True" />
                                            Province/State
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:DropDownList runat="server" ID="ddlCitySecondary" CssClass="form-control text" DataSourceID="sqldsSecondaryCity" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
                                            City
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtZipCodeSecondary" CssClass="form-control text"></asp:TextBox>
                                            Postal / Zip Code
                                        </div>
                                    </div>
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <div class="col-lg-3" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-6" style="padding-left: 0;">
                                        </div>
                                        <div class="col-lg-3" style="padding-left: 0;">
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
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Industry
                                </div>
                                <div class="col-lg-5">
                                    <asp:DropDownList runat="server" ID="ddlIndustry" CssClass="form-control text" DataSourceID="sqldsIndustry" DataTextField="IndustryName" DataValueField="IndustryID" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Company Size
                                </div>
                                <div class="col-lg-5">
                                    <asp:DropDownList runat="server" ID="ddlCompanySize" CssClass="form-control text">
                                        <asp:ListItem Value="-1">[choose one]</asp:ListItem>
                                        <asp:ListItem Value="1">1-10 employees</asp:ListItem>
                                        <asp:ListItem Value="2">11-100 employees</asp:ListItem>
                                        <asp:ListItem Value="3">101-500 employees</asp:ListItem>
                                        <asp:ListItem Value="4">Over 500 employees</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Business Phone
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="txtBussinessPhone" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Fax
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="txtFax" CssClass="form-control text"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Internal Notes
                                </div>
                                <div class="col-lg-7">
                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtInternalNote" CssClass="form-control text" Height="110px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="CompanyClientMaster" />
                        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" Text="Save" OnClick="btnUpdate_Click" ValidationGroup="CompanyClientMaster" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView" Style="color: black">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">
                    <asp:Label runat="server" ID="lblClientName"></asp:Label>
                </h1>
                <div style="float: right; margin-bottom: 10px; margin-top: 20px;">
                    <asp:Button runat="server" ID="btnEdit" CssClass="btn-primary" Text="Edit Client" Style="padding: 10px;" OnClick="btnEdit_Click" />
                    <div class="btn-group" role="group">
                        <button type="button" class="btn-success dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #999; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                            Create New<span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="InvoiceMasterNew.aspx?cmd=add">New Invoice</a></li>
                            <li><a href="RecurringInvoice.aspx?cmd=add">New Recurring</a></li>
                            <li><a href="CreditNoteMaster.aspx?cmd=add">New Credit</a></li>
                            <li><a href="EstimateMaster.aspx?cmd=add">New Estimate</a></li>
                            <li><a href="ProjectMaster.aspx?cmd=add">New Project</a></li>
                            <li><a href="#">New Ticket</a></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="panel-body">
                <div class="col-lg-8 ">
                    <div class="col-lg-12 rounded-container peel-shadows bg_systemcolor1" style="padding: 15px 0;">
                        <span class="col-lg-12" style="font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;">Account Standing</span>
                        <div class="col-lg-6">
                            <asp:Label runat="server" ID="lblOutstandingAmt" CssClass="promo-amount prepend-top-half" Text="0.00"></asp:Label>
                            <asp:GridView runat="server" ID="gvInvoiceRemaing" Visible="False" DataSourceID="sqldsInvoiceRemaing" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID"></asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsInvoiceRemaing" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT ClientID,SUM(InvoiceTotal-PaidToDate) AS Total FROM InvoiceMaster WHERE ClientID = @ClientID AND CompanyID = @CompanyID GROUP BY ClientID">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyClientID" PropertyName="Value" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div class="fs_11">
                                Outstanding (NGN)
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <asp:Label runat="server" ID="lblCreditAmt" CssClass="promo-amount prepend-top-half" Text="0.00"></asp:Label>
                            <asp:GridView runat="server" ID="gvCredit" Visible="False" AutoGenerateColumns="False" DataSourceID="sqldsCredit">
                                <Columns>
                                    <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID"></asp:BoundField>
                                    <asp:BoundField DataField="CreditRemaingTotal" HeaderText="CreditRemaingTotal" ReadOnly="True" SortExpression="CreditRemaingTotal"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="sqldsCredit" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT ClientID,SUM(CreditRemaingTotal) AS CreditRemaingTotal FROM CreditMaster WHERE ClientID = @ClientID AND CompanyID = @CompanyID GROUP BY ClientID ">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyClientID" PropertyName="Value" DefaultValue="0" Name="ClientID"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div class="fs_11">
                                Credit (NGN)
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-lg-12 rounded-container peel-shadows" style="padding-top: 25px;">
                        <div class="form-group col-lg-2" style="padding-left: 0;">
                            <div class="client-icon-large bg-system-light" style="margin-left: 5px;"></div>
                        </div>

                        <div class="col-lg-9">
                            <div class="col-lg-12 form-horizontal">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblClientName1" Style="font-family: Arial, Helvetica, sans-serif; font-weight: bold;"></asp:Label>
                                    <br />
                                    <div class="col-lg-1">
                                        <i class="fa fa-map-marker" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblAddress1"></asp:Label>
                                        <asp:Label runat="server" ID="lblAddress2"></asp:Label>
                                        <asp:Label runat="server" ID="lblCity"></asp:Label>
                                        <asp:Label runat="server" ID="lblState" />
                                        <asp:Label runat="server" ID="lblZipCode"></asp:Label>
                                        <asp:Label runat="server" ID="lblCountry" />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group col-lg-2" style="padding-left: 0;">
                                <div class="client-icon-medium bg-system-light" style="margin-left: 5px;"></div>
                            </div>
                            <div class="col-lg-9">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                        <asp:Label runat="server" ID="lblLastName"></asp:Label>
                                        <br />
                                        <div class="col-lg-1">
                                            <i class="fa fa-envelope" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                        </div>
                                        <div class="col-lg-10">
                                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-1">
                                            <i class="fa fa-mobile" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                        </div>
                                        <div class="col-lg-10">
                                            <asp:Label runat="server" ID="lblMobile"></asp:Label>&nbsp;
                                            <span style="color: #888; font-size: 11px; line-height: 16px;">mobile</span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-1">
                                            <i class="fa fa-phone-square" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                        </div>
                                        <div class="col-lg-10">
                                            <asp:Label runat="server" ID="lblHomePhone"></asp:Label>&nbsp;
                                            <span style="color: #888; font-size: 11px; line-height: 16px;">home</span>
                                        </div>
                                    </div>
                                    <div class="form-group"></div>
                                </div>
                            </div>

                            <asp:DataList runat="server" ID="dlClientContacts" Width="100%" RepeatColumns="1" RepeatDirection="Horizontal" DataKeyField="CompanyClientContactID" DataSourceID="sqldsClientContacts">
                                <ItemTemplate>
                                    <div class="clearfix"></div>
                                    <div class="form-group col-lg-2" style="padding-left: 0;">
                                        <div class="client-icon-medium bg-system-light" style="margin-left: 5px;"></div>
                                    </div>
                                    <div class="col-lg-9">
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <asp:Label Text='<%# Eval("FirstName") + " " + Eval("LastName") %>' runat="server" ID="FirstNameLabel" />
                                                <br />
                                                <div class="col-lg-1">
                                                    <i class="fa fa-envelope" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                                </div>
                                                <div class="col-lg-10">
                                                    <asp:Label Text='<%# Eval("Email") %>' runat="server" ID="EmailLabel" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-1">
                                                    <i class="fa fa-mobile" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                                </div>
                                                <div class="col-lg-10">
                                                    <asp:Label Text='<%# Eval("Mobile") %>' runat="server" ID="MobileLabel" />&nbsp;
                                                    <span style="color: #888; font-size: 11px; line-height: 16px;">mobile</span><br />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-lg-1">
                                                    <i class="fa fa-phone-square" style="color: gray; font-size: 15px; margin: 0 10px 0 3px;"></i>
                                                </div>
                                                <div class="col-lg-10">
                                                    <asp:Label Text='<%# Eval("HomePhone") %>' runat="server" ID="HomePhoneLabel" />&nbsp;
                                                    <span style="color: #888; font-size: 11px; line-height: 16px;">home</span><br />
                                                </div>
                                            </div>
                                            <div class="form-group"></div>
                                        </div>
                                    </div>
                                    <asp:Label Text='<%# Eval("CompanyClientContactID") %>' runat="server" ID="CompanyClientContactIDLabel" Visible="False" />
                                    <br />

                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource runat="server" ID="sqldsClientContacts" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [CompanyClientContactDetail] WHERE (([CompanyClientID] = @CompanyClientID) AND ([CompanyID] = @CompanyID))">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfCompanyClientID" PropertyName="Value" DefaultValue="0" Name="CompanyClientID" Type="Int32"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="clearfix"></div>
                        <div style="color: #888; margin-bottom: 15px;">
                            <asp:Label runat="server" ID="lblEmailMail" Text="Invoices sent by email." />
                        </div>
                    </div>
                </div>

                <div class="col-lg-4">
                    <div class="col-lg-12 rounded-container" style="margin-bottom: 0; padding: 15px;">
                        <span>This client typically pays in</span>
                        <br />
                        <span class="promo-amount" style="color: #0D83DD;">0 Days</span>
                        <br />
                        <a href="#" class="permission">Make this smarter</a>
                    </div>
                    <div class="col-lg-12 rounded-container peel-shadows" style="padding: 15px;">
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Quick Links</h4>
                        <ul style="list-style: none; padding: 0;">
                            <li style="margin: 5px 0;"><a href="#" class="permission">Account Statment</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Sent Email</a></li>
                        </ul>
                        <br />
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Reports</h4>
                        <ul style="list-style: none; padding: 0;">
                            <li style="margin: 5px 0;"><a href="#" class="permission">Accounts Aging</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Hours Logged</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Estimated Billing</a></li>
                        </ul>
                        <br />
                        <h4 style="font-family: Arial, Helvetica, sans-serif;">Quick Search</h4>
                        <ul style="list-style: none; padding: 0;">
                            <li style="margin: 5px 0;"><a href="#" class="permission">Invoices</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Recurring Profiles</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Estimates</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Expenses</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Projects</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Tickets</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewNo" Visible="False">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0;">
                <h1>View Client </h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <h3 style="margin: 0">Organization</h3>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Organization Name
                            </div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label"></div>
                            <div class="col-lg-9"></div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Send Invoices By
                            </div>
                            <div class="col-lg-9">

                                <asp:Label runat="server" ID="lblSnailMail" Text="Snail Mail" Visible="False" />
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
                                <h3>Contacts</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Email <span style="color: red">*</span>
                            </div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Contact Name
                            </div>
                            <div class="col-lg-9">
                                <div class="col-lg-6" style="padding: 0;">
                                </div>
                                <div class="col-lg-6" style="padding-left: 0">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">Home Phone</div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">Mobile</div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Login Credentials
                            </div>
                            <div class="col-lg-9">
                                <asp:Label runat="server" ID="lblAssignUsername" Text="Assign Username and Password" />
                                <br />
                                <br />
                                <div id="Div1" style="display: none">
                                    <div class="col-lg-4" style="padding-left: 0;">
                                        <asp:Label runat="server" ID="lblUsername" PlaceHolder="User Name"></asp:Label>
                                    </div>
                                    <div class="col-lg-4" style="padding-left: 0;">
                                        <asp:Label runat="server" ID="lblPassword" PlaceHolder="New Password"></asp:Label>
                                    </div>
                                    <div class="col-lg-4" style="padding-left: 0;">
                                        <asp:Label runat="server" ID="lblConfPassword" PlaceHolder="Confirm Password"></asp:Label>
                                    </div>

                                </div>
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
                                <h3>Details</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Country
                            </div>
                            <div class="col-lg-6">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Address
                            </div>
                            <div class="col-lg-9">
                                Street 1
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                Street 2
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <div class="col-lg-6" style="padding-left: 0;">
                                    Province/State
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                    City
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                    Postal / Zip Code
                                </div>
                            </div>
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <div class="col-lg-3" style="padding-left: 0;">
                                </div>
                                <div class="col-lg-6" style="padding-left: 0;">
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label"></div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Secondary Country
                            </div>
                            <div class="col-lg-6">
                                <asp:Label runat="server" ID="lblCountrySecondary" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                SecondaryAddress
                            </div>
                            <div class="col-lg-9">
                                <asp:Label runat="server" ID="lblAddress1Secondary"></asp:Label>
                                Street 1
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <asp:Label runat="server" ID="lblAddress2Secondary"></asp:Label>
                                Street 2
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <div class="col-lg-6" style="padding-left: 0;">
                                    <asp:Label runat="server" ID="lblStateSecondary" />
                                    Province/State
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                    <asp:Label runat="server" ID="lblCitySecondary"></asp:Label>
                                    City
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                    <asp:Label runat="server" ID="lblZipCodeSecondary"></asp:Label>
                                    Postal / Zip Code
                                </div>
                            </div>
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <div class="col-lg-6" style="padding-left: 0;">
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
                                </div>
                                <div class="col-lg-3" style="padding-left: 0;">
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
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Industry
                        </div>
                        <div class="col-lg-5">
                            <asp:Label runat="server" ID="lblIndustry" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Company Size
                        </div>
                        <div class="col-lg-5">
                            <asp:Label runat="server" ID="lblCompanySize"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Business Phone
                        </div>
                        <div class="col-lg-3">
                            <asp:Label runat="server" ID="lblBussinessPhone"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Fax
                        </div>
                        <div class="col-lg-3">
                            <asp:Label runat="server" ID="lblFax"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3 control-label">
                            Internal Notes
                        </div>
                        <div class="col-lg-7">
                            <asp:Label runat="server" ID="lblInternalNote"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="col-lg-12" style="text-align: center;">
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; display: inline-block; margin: 0; padding: 2%; width: 100%;">
                <h1 style="display: inline-block; margin: 0; width: 25%;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <div style="float: right; width: 75%; text-align: right;">
                    <ul id="footerPackageDiv" style="display: inline-block; padding: 0; ">
                        <li class="open" style="list-style: none;">Want to <a href="ImportCompanyClients.aspx?format=csv" class="permission">import clients?</a></li>
                    </ul>
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Client" OnClick="btnAdd_Click" />
                </div>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div class="col-lg-12" id="divSearch" style="padding: 10px; display: none; background-color: #f6f6f6; margin-bottom: 10px;">
                        <div id="closeSearch" class="close-button" style="cursor: pointer; background-color: blanchedalmond; padding: 10px; border-radius: 10px; overflow: visible;"></div>
                        <h3 style="margin: 10px auto 20px; text-align: center;">Search Box</h3>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Organization
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtOrganizationSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        First Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtFirstNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Last Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtLastNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Address
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtAddressSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12 control-label">&nbsp;</div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Email
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtEmailSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Phone
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtPhoneSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Internal Note
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtNotesSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn-default" Style="padding: 5px; width: 100px" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button runat="server" ID="btnReset" CssClass="btn-default" Text="Reset" Style="padding: 5px; width: 100px" OnClientClick="ClearAllControls(); return false;" />
                        </div>
                    </div>
                    <div style="background-color: lightgray; padding: 10px;">
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button runat="server" ID="btnEmail" Text="Email" CssClass="btn-danger" Style="padding: 5px;" OnClick="btnEmail_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvCompanyClient" GridLines="None" Width="100%" Font-Size="Small" AllowPaging="True"
                        AutoGenerateColumns="False" CssClass="table table-hover" DataKeyNames="CompanyClientID"
                        AllowSorting="True" OnSorting="gvCompanyClient_Sorting" OnPageIndexChanging="gvCompanyClient_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("CompanyClientID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Organization">
                                <ItemTemplate>
                                    <a href='<%# "CompanyClientMaster.aspx?cmd=view&ID=" + Eval("CompanyClientID") %>'>
                                        <%#Eval("OrganizationName") %>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="OrganizationName" HeaderText="Organization" SortExpression="OrganizationName"></asp:BoundField>--%>
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                            <asp:TemplateField HeaderText="Contact" SortExpression="FirstName">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblName" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BussinessPhone" HeaderText="Bussiness Phone" SortExpression="BussinessPhone"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="edit" Visible='<%# !bool.Parse(Eval("Deleted").ToString()) %>' CommandArgument='<%# Eval("CompanyClientID") %>' OnClick="lnkEdit_OnClick"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#0DB9B7" Font-Names="Verdana" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <div style="background-color: white; border-bottom: 1px solid lightgray; text-align: right;">
                        <a id="activeTag" runat="server" href="CompanyClientMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a href="CompanyClientMaster.aspx?ar=true&ac=false" id="archivedTag" runat="server">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="CompanyClientMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsCompanyClient" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyClientMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtOrganizationSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Organization" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtFirstNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FirstName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtLastNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="LastName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAddressSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Address" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEmailSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Email" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtPhoneSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Phone" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InternalNotes" Type="String"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource runat="server" ID="objdsCompanyClientStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyStaffIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyClientMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtOrganizationSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Organization" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtFirstNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FirstName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtLastNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="LastName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAddressSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Address" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEmailSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Email" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtPhoneSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Phone" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InternalNotes" Type="String"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:HiddenField runat="server" ID="hfCompanyClientID" />
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
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryCountry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CountryID, '[choose one]' AS CountryName UNION SELECT [CountryID], [CountryName] FROM [CountryMaster] WHERE ([CountryStatus] = @CountryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CountryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryState" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS StateID, '[choose one]' AS StateName UNION SELECT [StateID], [StateName] FROM [StateMaster] WHERE (([StateStatus] = @StateStatus) AND ([CountryID] = @CountryID))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="StateStatus" Type="Boolean"></asp:Parameter>
            <asp:ControlParameter ControlID="ddlCountrySecondary" PropertyName="SelectedValue" DefaultValue="0" Name="CountryID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsSecondaryCity" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CityID, '[choose one]' AS CityName UNION SELECT [CityID], [CityName] FROM [CityMaster] WHERE (([StateID] = @StateID) AND ([CityStatus] = @CityStatus))">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlStateSecondary" PropertyName="SelectedValue" DefaultValue="0" Name="StateID" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="True" Name="CityStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsIndustry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS IndustryID, '[choose one]' AS IndustryName UNION SELECT [IndustryID], [IndustryName] FROM [IndustryMaster] WHERE ([IndustryStatus] = @IndustryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="IndustryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
