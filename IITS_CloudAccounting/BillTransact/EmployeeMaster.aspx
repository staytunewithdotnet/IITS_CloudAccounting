<%@ Page Title="Employee Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" Async="true"
    CodeBehind="EmployeeMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.EmployeeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("peopleDiv");
            p.style.display = 'block';
        });
    </script>
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <style>
        a.aTag:hover {
            background-color: #D4FFFF;
        }

        @media (min-width: 768px) {
            .modal-dialog {
                width: 600px;
                margin-top: 184px !important;
                margin-bottom: 0 !important;
                margin-left: auto !important;
                margin-right: auto !important;
            }
        }

        .modal {
            z-index: 9999;
        }

        .modal-content {
            -webkit-box-shadow: 0 5px 5px -5px #000000;
            -webkit-box-shadow: 0 5px 5px -5px rgba(0,0,0,0.1);
            -moz-box-shadow: 0 5px 5px -5px #000000;
            -moz-box-shadow: 0 5px 5px -5px rgba(0,0,0,0.1);
            box-shadow: 0 5px 5px -5px #000000;
            box-shadow: 0 5px 5px -5px rgba(0,0,0,0.1);
            border: 0;
            border-radius: 0;
        }

        .modal-header {
            padding: 20px;
            overflow: hidden;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border: 0!important;
            height: 55px;
            font-size: 14px;
            font-weight: 600;
        }

        .modal-body {
            position: relative;
            padding: 20px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        .modal-footer {
            position: relative;
            padding: 20px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
            border: 0;
        }

        .modal-header + .modal-body {
            padding: 0 20px 20px;
        }

        .modal-body + .modal-footer {
            padding: 0 20px 20px;
        }

        .modal-open {
            overflow-y: auto!important;
            padding: 0!important;
        }

        .modal-backdrop {
            z-index: 999;
        }

        .client-notes {
            background-color: #fffbe1;
            border: 1px solid #e4dfbe;
            padding: 8px 10px 10px;
            -o-border-radius: 4px;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }
    </style>
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
                    <a href="EmployeeMaster.aspx">Employee Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your staff has member been created.</h3>
                <ul style="color: black; font-size: 13px; font-family: Verdana;">
                    <li>
                        <a href="EmployeeMaster.aspx?cmd=add" class="permission">Add another staff member</a>
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your staff member has been updated.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>New Staff</h1>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server" ID="upStaff">
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Email<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtStaffEmail" CssClass="form-control text" TabIndex="1" MaxLength="50" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvStaffEmail" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffEmail" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="StaffMaster" ControlToValidate="txtStaffEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Name<span style="color: red">*</span>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtStaffFirstName" CssClass="form-control text" onkeypress="return isLetter(event)" TabIndex="2" MaxLength="50" Style="text-transform: capitalize;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvStaffFirstName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffFirstName" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        First Name
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="txtStaffLastName" CssClass="form-control text" onkeypress="return isLetter(event)" TabIndex="3" MaxLength="50" Style="text-transform: capitalize;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvStaffLastName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtStaffLastName" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        Last Name
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Billing Rate
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtBillingRate" CssClass="form-control text" TabIndex="3" Text="0.00" onkeypress="return decimalValue(this,event);"></asp:TextBox>Rate per hour
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3">&nbsp;</div>
                                    <div class="col-lg-4">
                                        <asp:LinkButton runat="server" CssClass="aTag" ID="lnkshowAUser" Style="display: block; text-decoration: underline; cursor: pointer;" OnClick="lnkshowAUser_Click"><i class="fa fa-plus-circle">&nbsp;</i>Assign username and password</asp:LinkButton>
                                    </div>
                                </div>
                                <div id="usernameDiv" visible="False" runat="server">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding-left: 0;">
                                            Username<span style="color: red">*</span>
                                            <asp:RequiredFieldValidator ID="rfvUsername" Enabled="False" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtUsername" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:TextBox runat="server" ID="txtUsername" PlaceHolder="User Name" CssClass="form-control text" AutoPostBack="True" OnTextChanged="txtUsername_OnTextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4" style="display: none">
                                            <asp:Label runat="server" ID="lblUsernameAdd"></asp:Label>
                                            <asp:Label runat="server" ID="lblPasswordAdd"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding-left: 0;">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:TextBox runat="server" ID="txtPassword" PlaceHolder="New Password" CssClass="form-control text"></asp:TextBox>
                                            New Password
                                            <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" runat="server" ForeColor="red" Enabled="False" Display="Dynamic" ControlToValidate="txtPassword" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-4" style="padding-left: 0;">
                                            <asp:TextBox runat="server" ID="txtConfPassword" PlaceHolder="Confirm Password" CssClass="form-control text"></asp:TextBox>
                                            Confirm Password
                                            <asp:RequiredFieldValidator ID="rfvConfPassword" SetFocusOnError="True" runat="server" Enabled="False" ForeColor="red" Display="Dynamic" ControlToValidate="txtConfPassword" ValidationGroup="StaffMaster">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator runat="server" ID="cvPassword" ControlToValidate="txtConfPassword" Enabled="False" ControlToCompare="txtPassword" Display="Dynamic" ForeColor="red" ValidationGroup="StaffMaster"></asp:CompareValidator>
                                        </div>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding-left: 0;">
                                            &nbsp;
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:CheckBox runat="server" ID="chkEmail" Text="Email this user their username and password" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3">&nbsp;</div>
                                    <div class="col-lg-4">
                                        <asp:LinkButton runat="server" CssClass="aTag" ID="lnkshowAAddress" Style="display: block; text-decoration: underline; cursor: pointer;" OnClick="lnkshowAAddress_Click"><i class="fa fa-plus-circle">&nbsp;</i>Add contact information</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="contactAddress" runat="server" visible="False">
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
                                    <div class="col-lg-5">
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">Bussiness Phone</div>
                                            <div class="col-lg-9">
                                                <asp:TextBox runat="server" ID="txtBussinessPhone" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-lg-3 control-label">Fax</div>
                                            <div class="col-lg-9">
                                                <asp:TextBox runat="server" ID="txtFax" CssClass="form-control text" onkeypress="return isNumber(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

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
                                        <div class="col-lg-3 control-label">Notes</div>
                                        <div class="col-lg-9">
                                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" CssClass="form-control text"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label"></div>
                                        <div class="col-lg-9">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="projectsDiv" runat="server" visible="False">
                            <div class="clearfix" style="border-bottom: 5px solid #eee;"></div>
                            <div class="col-lg-12">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">&nbsp;</div>
                                        <div class="col-lg-9">
                                            <h3>Assigned Projects</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-3">&nbsp;</div>
                                        <div class="col-lg-9">
                                            <asp:CheckBoxList runat="server" ID="chkProjects" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" DataSourceID="sqldsProjects" DataTextField="ProjectName" DataValueField="ProjectID" />
                                            <asp:SqlDataSource runat="server" ID="sqldsProjects" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [ProjectID], [ProjectName] FROM [ProjectMaster] WHERE (([Active] = @Active) AND ([CompanyID] = @CompanyID))">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean"></asp:Parameter>
                                                    <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="col-lg-12" style="text-align: center;">
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Save" OnClick="btnSubmit_Click" ValidationGroup="StaffMaster" />
                        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" Text="Save" OnClick="btnUpdate_Click" ValidationGroup="StaffMaster" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView" Style="color: black">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">
                    <asp:Label runat="server" ID="lblStaffFirstName"></asp:Label>
                    <asp:Label runat="server" ID="lblStaffLastName"></asp:Label>
                </h1>
                <div style="float: right; margin-top: 20px; margin-bottom: 10px;">
                    <asp:Button runat="server" ID="btnEdit" CssClass="btn-primary" Text="Edit Staff" Style="padding: 10px;" OnClick="btnEdit_Click" />
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-9 rounded-container peel-shadows" style="padding-top: 25px;">
                    <div class="form-group col-lg-2" style="padding-left: 0;">
                        <div class="staff-icon-large bg-system-light" style="margin-left: 5px;">
                        </div>
                    </div>

                    <div class="col-lg-9">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblStaffFirstName1" Style="text-transform: capitalize; font-weight: bold; font-family: Arial,Helvetica,sans-serif;"></asp:Label>
                                <asp:Label runat="server" ID="lblStaffLastName1" Style="text-transform: capitalize; font-weight: bold; font-family: Arial,Helvetica,sans-serif;"></asp:Label>
                                (<i class="fa fa-user" style="font-size: 15px; color: gray;"></i>&nbsp;<asp:Label runat="server" ID="lblUsername"></asp:Label>)
                                <br />
                                <div class="col-lg-1">
                                    <i class="fa fa-envelope" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                </div>
                                <div class="col-lg-11">
                                    <asp:Label runat="server" ID="lblStaffEmail"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-6" style="padding-left: 0">
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-phone" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblBussinessPhone"></asp:Label>&nbsp;
                                <span style="color: #888; font-size: 11px; line-height: 16px;">bussiness</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-mobile" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblMobile"></asp:Label>&nbsp;
                                <span style="color: #888; font-size: 11px; line-height: 16px;">mobile</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6" style="padding-right: 0">
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-phone-square" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblHomePhone"></asp:Label>&nbsp;
                                <span style="color: #888; font-size: 11px; line-height: 16px;">home</span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-fax" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblFax"></asp:Label>&nbsp;
                                <span style="color: #888; font-size: 11px; line-height: 16px;">fax</span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group">
                                <div class="col-lg-1">
                                    <i class="fa fa-map-marker" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                </div>
                                <div class="col-lg-11">
                                    <asp:Label runat="server" ID="lblAddress1"></asp:Label>
                                    <asp:Label runat="server" ID="lblAddress2"></asp:Label>
                                    <asp:Label runat="server" ID="lblCity"></asp:Label>
                                    <asp:Label runat="server" ID="lblState" />
                                    <asp:Label runat="server" ID="lblZipCode"></asp:Label>
                                    <asp:Label runat="server" ID="lblCountry" />
                                    <br />
                                </div>
                            </div>
                            <div class="form-group">
                                <span style="font-weight: bold">Billing Rate:
                                </span>
                                <asp:Label runat="server" ID="lblBillingRate" Text="0.00"></asp:Label>/ hour
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-lg-2 form-group control-label">&nbsp;</div>
                    <div class="col-lg-2 form-group control-label" style="padding-left: 0; padding-right: 0;">
                        Notes
                    </div>
                    <div class="col-lg-8 form-group" style="padding-left: 0;">
                        <div class="client-notes">
                            <asp:Label runat="server" ID="lblNotes"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3" style="padding-right: 0;">
                    <div class="col-lg-12 rounded-container peel-shadows" style="padding: 15px;">
                        <h4 style="font-family: Arial,Helvetica,sans-serif;">Reports</h4>
                        <ul style="list-style: none; padding: 0;">
                            <li style="margin: 5px 0;"><a href="#" class="permission">Account Statment</a></li>
                            <li style="margin: 5px 0;"><a href="#" class="permission">Sent Email</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlViewNo" Visible="False">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>View Staff</h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Email
                            </div>
                            <div class="col-lg-6">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Name
                            </div>
                            <div class="col-lg-3">
                                First Name
                            </div>
                            <div class="col-lg-3">
                                Last Name
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Billing Rate
                            </div>
                            <div class="col-lg-4">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="padding-left: 0;">
                                Username
                            </div>
                            <div class="col-lg-4">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label" style="padding-left: 0;">
                                &nbsp;
                            </div>
                            <div class="col-lg-4">
                                <asp:Label runat="server" ID="lblPassword"></asp:Label>
                                New Password
                            </div>
                            <div class="col-lg-4" style="padding-left: 0;">
                                <asp:Label runat="server" ID="lblConfPassword"></asp:Label>
                                Confirm Password
                            </div>
                            <br />
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
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Mobile</div>
                                <div class="col-lg-9">
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Bussiness Phone</div>
                                <div class="col-lg-9">
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">Fax</div>
                                <div class="col-lg-9">
                                </div>
                            </div>
                        </div>

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
                            <div class="col-lg-3 control-label">Notes</div>
                            <div class="col-lg-9">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label"></div>
                            <div class="col-lg-9">
                            </div>
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
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Staff" OnClick="btnAdd_Click" Style="float: right;" Visible="False" />
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" style="float: right;width: 30%;">
                    <i class="fa fa-plus"></i>&nbsp;&nbsp;New Team Member
                </button>
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
                                        Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Email
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtEmailSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
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
                                        Notes
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
                        <asp:Button runat="server" ID="btnEmail" Text="Email" CssClass="btn-danger" OnClick="btnEmail_Click" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvStaff" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-striped table-hover" DataSourceID="objdsStaff" AllowSorting="True" OnSorting="gvStaff_Sorting" 
                        GridLines="None" OnPageIndexChanging="gvStaff_PageIndexChanging" OnRowDataBound="gvStaff_OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("ID") %>' CssClass='<%# Eval("Role") %>' Visible='<%# Eval("Role").ToString()!="Admin" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                                <ItemTemplate>
                                    <%--<asp:Label runat="server" ID="lblName" Text='<%# Eval("Name") %>'></asp:Label>--%>
                                    <asp:LinkButton runat="server" ID="lnkName" Text='<%# Eval("Name") %>' CommandArgument='<%# Eval("ID") %>' ToolTip='<%# Eval("Role") %>' OnClick="lnkName_OnClick"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login" SortExpression="LastLoginDate"></asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                            <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="edit" CommandArgument='<%# Eval("ID") %>' ToolTip='<%# Eval("Role") %>' OnClick="lnkEdit_OnClick"></asp:LinkButton>
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
                        <a id="activeTag" runat="server" href="EmployeeMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="EmployeeMaster.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="EmployeeMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsStaff" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.CompanyUserMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Name" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtEmailSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Email" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtPhoneSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Phone" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>

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
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel" style="font-size: large; font-weight: bold; color: black;">What kind of team member?</h4>
                </div>
                <div class="modal-body">
                    <div class="col-lg-6">
                        <div class="header" style="font-size: large; font-weight: bold; color: black;">
                            Add a Contractor
                        </div>
                        <div class="content">
                            Contractors will <span style="background-color: #ff9">receive their own Bill Transact account</span> and can:
                                <ul>
                                    <li>Track time</li>
                                    <li>Invoice you</li>
                                </ul>
                            <p style="text-align: justify; line-height: normal; margin-bottom: 0;">
                                You can add contractors at no cost to you. Contractors may choose to pay or continue to use Bill Transact for free with you as their only client.
                            </p>
                            <a href="#" target="_blank">Learn about contractors.</a>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="header" style="font-size: large; font-weight: bold; color: black;">
                            Add a Staff
                        </div>
                        <div class="content">
                            Staff <span style="background-color: #ff9">share your Bill Transact's account</span> and can be permitted to:
                                <ul>
                                    <li>Track time</li>
                                    <li>Track expenses</li>
                                    <li>Create and send invoices</li>
                                    <li>Create and send estimates</li>
                                    <li>Manage clients and projects</li>
                                    <li>Manage support tickets</li>
                                    <li>Run reports</li>
                                </ul>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <div class="col-lg-6">
                        <div class="panel-body">
                            <div class="col-lg-12" style="text-align: center">
                                <a href="ContractorMaster.aspx?cmd=add" class="btn-info" style="padding: 8px; text-decoration: none;">Add Contractor</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="panel-body">
                            <div class="col-lg-12" style="text-align: center">
                                <a href="EmployeeMaster.aspx?cmd=add" class="btn-info" style="padding: 8px; text-decoration: none;">Add Staff Member</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

