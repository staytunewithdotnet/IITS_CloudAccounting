<%@ Page Title="Company User Permissions" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="CompanyUserPermissions.aspx.cs" Inherits="IITS_CloudAccounting.Admin.CompanyUserPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("settingDiv");
            d.style.display = 'block';
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('ul.permissions li input').click(function () {
                var container = $(this).closest('li');

                if (container.attr('class') == 'enabled') {
                    container.removeAttr('class');
                } else {
                    container.attr('class', 'enabled');
                }
            });
        });
    </script>
    <style>
        ul.permissions {
            list-style: none;
            padding: 0;
            margin: 0;
            color: #fff;
            font-weight: bold;
            font-size: 11px;
        }

            ul.permissions li.enabled {
                background-color: #0D83DD;
                color: #ffffff;
            }

            ul.permissions li {
                float: left;
                background-color: #919191;
                padding: 1px;
                margin-right: 3px;
                margin-bottom: 3px;
            }

                ul.permissions li div.mydiv {
                    border: solid 1px #c3c3c3;
                    padding: 0 3px;
                    min-width: 135px;
                }

                    ul.permissions li div.mydiv div.checker {
                        border: none;
                        min-width: 20px;
                    }

            ul.permissions label {
                min-width: 80px;
                line-height: 22px;
                font-size: 11px;
                font-weight: bold;
            }

            ul.permissions div.mydiv label {
                cursor: pointer;
            }

        input[type="checkbox"] {
            vertical-align: middle;
            margin: 0 2px 2px 0;
            padding: 0;
            cursor: pointer;
        }
    </style>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <a href="#">Setting
                    </a>
                </li>
                <li>
                    <a href="CompanyUserPermissions.aspx">Company User Permissions</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your preferences have been updated.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>

    <div class="clearfix"></div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0;">
            <h1>Tabs & Permissions</h1>
            Add or remove features, and limit what your staff and clients have access to.
        </div>

        <div class="panel-body" style="border-bottom: 5px solid #eee;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-2 control-label">
                            Admin Tabs
                        </div>
                        <div class="col-lg-10">
                            <ul class="permissions">
                                <li runat="server" id="liAdminEstimate">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkAdminEstimate" Text="Estimate" />
                                    </div>
                                </li>
                                <li runat="server" id="liAdminExpense">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkAdminExpense" Text="Expenses" />
                                    </div>
                                </li>
                                <li runat="server" id="liAdminTimesheet">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkAdminTimesheet" Text="Time Tracking" />
                                    </div>
                                </li>
                                <li runat="server" id="liAdminSupport">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkAdminSupport" Text="Support" />
                                    </div>
                                </li>
                                <li runat="server" id="liAdminDocument">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkAdminDocument" Text="Documents" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">
                            Staff Tabs
                        </div>
                        <div class="col-lg-10">
                            <ul class="permissions">
                                <li runat="server" id="liStaffPeople">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffPeople" Text="People" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffInvoice">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffInvoice" Text="Invoices" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffEstimate">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffEstimate" Text="Estimate" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffExpense">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffExpense" Text="Expenses" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffTimesheet">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffTimesheet" Text="Time Tracking" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffSupport">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffSupport" Text="Support" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffDocument">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffDocument" Text="Documents" />
                                    </div>
                                </li>
                                <li runat="server" id="liStaffReport">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkStaffReport" Text="Reports" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkStaffProjectAccess" Text="Project Access" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">Staff are permitted to create and manage projects as well as view all project reports.
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkStaffSendInv" Text="Send Invoices, Estimates and Credits" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">Staff are permitted to send invoices, estimates and credits to clients through email and snail mail.</span>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkStaffClientManagement" Text="Client Management" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">Newly created clients are visible to all staff, and newly created staff can view all clients. You can manage individual staff/client permissions at any time using the Assign Clients page.
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkStaffTicketAdmin" Text="Ticket Administration" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">All staff can view and update all support tickets for clients they are assigned to regardless of the department they are assigned to.
                            </span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">
                            Client Tabs
                        </div>
                        <div class="col-lg-10">
                            <ul class="permissions">
                                <li runat="server" id="liClientInvoice">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkClientInvoice" Text="Invoices" />
                                    </div>
                                </li>
                                <li runat="server" id="liClientEstimate">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkClientEstimate" Text="Estimate" />
                                    </div>
                                </li>
                                <li runat="server" id="liClientProject">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkClientProject" Text="Projects" />
                                    </div>
                                </li>
                                <li runat="server" id="liClientSupport">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkClientSupport" Text="Support" />
                                    </div>
                                </li>
                                <li runat="server" id="liClientDocument">
                                    <div class="mydiv">
                                        <asp:CheckBox runat="server" ID="chkClientDocument" Text="Documents" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkClientDisputeInvoices" Text="Dispute Invoices" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">Clients are allowed to dispute invoices.</span>
                        </div>
                    </div>
                    <div class="form-group" style="margin-bottom: 0;">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:CheckBox runat="server" ID="chkClientDocumentAdmin" Text="Document Administration" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <span style="color: grey; font-size: 10px">Clients are permitted to create new folders.</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12" style="text-align: center;">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfAdminPerID" />
    <asp:HiddenField runat="server" ID="hfStaffPerID" />
    <asp:HiddenField runat="server" ID="hfClientPerID" />
</asp:Content>
