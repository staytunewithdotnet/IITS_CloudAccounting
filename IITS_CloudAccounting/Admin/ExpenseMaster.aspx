<%@ Page Title="Expense Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ExpenseMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ExpenseMaster" %>

<%-- sir 3 project ma je main or error hoy e karavi do atyare reports to query mari ne DB mathi data lavanu 6e eto koi be kari dese.. --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../App_Themes/Doyingo/css/invoicing.css" />
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var es = document.getElementById("expensesDiv");
            es.style.display = 'block';
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=chkAttachImage.ClientID%>").change(function () {
                var chk = document.getElementById("<%= chkAttachImage.ClientID %>");
                var d = document.getElementById("<%= divAttachImg.ClientID %>");
                if (chk.checked) {
                    d.style.display = 'block';
                } else {
                    d.style.display = 'none';
                }
            });
        });
    </script>

    <style>
        input[type=text] {
            width: 100% !important;
        }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-list-alt"></i>
                    <a href="#">Expenses
                    </a>
                </li>
                <li>
                    <a href="ExpenseMaster.aspx">Expense Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divImport" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3 style="color: #4c8700;">Woohoo! You've imported expenses.</h3>
                <ul style="color: black; font-family: Verdana; font-size: 13px;">
                    <li>Need to <a href="ImportExpense.aspx" class="permission">import more</a>?
                    </li>
                </ul>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Expense has been created.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your Expense has been updated.</h3>
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
                <h1>Expenses</h1>
            </div>
            <asp:UpdatePanel runat="server" ID="upExpensesMain" ChildrenAsTriggers="True">
                <ContentTemplate>
                    <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                        <div class="col-lg-3" style="padding-left: 0; padding-right: 0;">
                            <div class="form-group">
                                <div class="col-lg-6" style="padding: 0 2.5px 0 0;">
                                    Amount<span style="color: red;">*</span>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ExpenseMaster" ForeColor="red">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtAmount" OnTextChanged="txtAmount_OnTextChanged" AutoPostBack="True" CssClass="form-control text" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                </div>
                                <div class="col-lg-6" style="padding: 0 0 0 2.5px;">
                                    Date<span style="color: red;">*</span>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvDate" ControlToValidate="txtDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ExpenseMaster" ForeColor="red">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control text" Style="padding-left: 8px !important; padding-right: 0 !important;"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDate" Format="MM/dd/yyyy" TargetControlID="txtDate" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding: 0;">
                                    Vendor<br />
                                    <asp:TextBox runat="server" ID="txtVendor" CssClass="form-control text"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding: 0;">
                                    Category<span style="color: red;">*</span>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvCategory" ControlToValidate="ddlCategory" InitialValue="-2" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ExpenseMaster" ForeColor="red">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control text" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_OnSelectedIndexChanged" DataSourceID="sqldsCategory" DataTextField="SubCategoryName" DataValueField="SubCategoryID" />
                                    <asp:SqlDataSource runat="server" ID="sqldsCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '[choose one]' AS SubCategoryName,-2 AS SubCategoryID,-2 AS CategoryID UNION SELECT '  › ' + SubCategoryMaster.SubCategoryName AS SubCategoryName,SubCategoryMaster.SubCategoryID,SubCategoryMaster.CategoryID FROM SubCategoryMaster UNION SELECT CategoryMaster.CategoryName,-1,CategoryMaster.CategoryID FROM CategoryMaster ORDER BY CategoryID,SubCategoryID"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding: 0;">
                                    Notes<br />
                                    <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control text"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <asp:UpdatePanel runat="server" ID="upExpensesCheck" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <asp:CheckBox runat="server" ID="chkTaxes" Text="Taxes" AutoPostBack="True" OnCheckedChanged="chkTaxes_OnCheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <asp:CheckBox runat="server" ID="chkRecurring" Text="Recurring" AutoPostBack="True" OnCheckedChanged="chkRecurring_OnCheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <asp:CheckBox runat="server" ID="chkAssignToClient" Text="Assign To Client" AutoPostBack="True" OnCheckedChanged="chkAssignToClient_OnCheckedChanged" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-lg-3" style="padding-left: 12px; padding-right: 0;">
                    <div class="form-group">
                        <div class="col-lg-12" style="padding: 0;">
                            <asp:CheckBox runat="server" ID="chkAttachImage" Text="Attach Image of Receipt" /><%--AutoPostBack="True" OnCheckedChanged="chkAttachImage_OnCheckedChanged"--%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <asp:UpdatePanel runat="server" ID="upExpensesExtra" ChildrenAsTriggers="True">
                    <ContentTemplate>
                        <div class="col-lg-3" style="padding-left: 0; padding-right: 12px;">
                            &nbsp;
                            <div runat="server" class="form-group" id="divTaxes" visible="False">
                                <div class="col-lg-12">Tax 1</div>
                                <div class="col-lg-6" style="padding-right: 0;">
                                    <asp:DropDownList runat="server" ID="ddlTax1" AutoPostBack="True" OnSelectedIndexChanged="ddlTax1_OnSelectedIndexChanged" CssClass="form-control text" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" />
                                </div>
                                <div class="col-lg-6" style="padding-left: 0; padding-right: 0;">
                                    <asp:TextBox runat="server" ID="txtTax1" CssClass="form-control text" Enabled="False" />
                                </div>
                                <div class="col-lg-12">
                                    Tax 2
                                </div>
                                <div class="col-lg-6" style="padding-right: 0;">
                                    <asp:DropDownList runat="server" ID="ddlTax2" CssClass="form-control text" AutoPostBack="True" OnSelectedIndexChanged="ddlTax1_OnSelectedIndexChanged" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID" />
                                </div>
                                <div class="col-lg-6" style="padding-left: 0; padding-right: 0;">
                                    <asp:TextBox runat="server" ID="txtTax2" CssClass="form-control text" Enabled="False" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            &nbsp;
                            <div class="form-group" id="divRecurring" runat="server" visible="False">
                                <div class="col-lg-12">
                                    Frequency<span style="color: red">*</span>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvFrequency" Enabled="False" ControlToValidate="ddlFrequency" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ExpenseMaster" ForeColor="red">*</asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList runat="server" ID="ddlFrequency" CssClass="form-control text" DataSourceID="sqldsFrequency" DataTextField="FrequencyName" DataValueField="FrequencyID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="sqldsFrequency" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS FrequencyID, ' ' AS FrequencyName UNION SELECT [FrequencyID], [FrequencyName] FROM [FrequencyMaster]"></asp:SqlDataSource>
                                    <br />
                                    Until<br />
                                    <asp:DropDownList runat="server" ID="ddlUntil" CssClass="form-control text" AutoPostBack="True" OnSelectedIndexChanged="ddlUntil_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Forever" Value="Forever"></asp:ListItem>
                                        <asp:ListItem Text="End Date" Value="End Date"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <div id="divUntilDate" runat="server" visible="False">
                                        End Date<br />
                                        <asp:TextBox runat="server" ID="txtUntilDate" CssClass="form-control text"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceuntilDate" TargetControlID="txtUntilDate" Format="MM/dd/yyyy" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            &nbsp;
                            <div class="form-group" id="divAssignClient" runat="server" visible="False">
                                <div class="col-lg-12">
                                    <asp:DropDownList runat="server" ID="ddlClient" CssClass="form-control text" DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-lg-3">
                    &nbsp;
                    <div class="form-group" id="divAttachImg" runat="server" style="display: none;">
                        <div class="col-lg-12" style="padding: 0; text-align: center;">
                            <asp:FileUpload runat="server" ID="fuAttachRecipt" CssClass="form-control fileupload" AllowMultiple="False" />
                            <asp:Image runat="server" ID="imgAttach" Style="height: 100px; width: 100px;" Visible="False" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel-body" style="text-align: center;">
                <asp:Button runat="server" ID="btnCheck" CssClass="btn-danger" Text="Check" OnClick="btnCheck_Click" Visible="False" />
                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" Text="Save" OnClick="btnUpdate_Click" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView" Style="color: black;">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>View Expenses
                    <h5>(<asp:Label runat="server" ID="lblDate"></asp:Label>)</h5>
                </h1>
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-6">
                    <div class="form-group">
                        <span style="font-weight: bold">Amount:</span>
                        <asp:Label runat="server" ID="lblAmount"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <span style="font-weight: bold">Vendor:</span>
                        <asp:Label runat="server" ID="lblVendor"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <div class="col-lg-12" style="padding: 0;">
                            <span style="font-weight: bold">Category:</span>
                            <asp:Label runat="server" ID="lblCategory" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <div class="col-lg-12" style="padding: 0;">
                            <span style="font-weight: bold">Notes:</span>
                            <asp:Label runat="server" ID="lblNotes"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-3" style="padding-left: 0; padding-right: 12px;">
                    &nbsp;
                    <div runat="server" class="form-group" id="divTaxesView" visible="False">
                        <div class="col-lg-12">
                            <h5>Taxes</h5>
                            Tax 1
                        </div>
                        <div class="col-lg-6" style="padding-right: 0;">
                            <asp:Label runat="server" ID="lblTax1" />:
                        </div>
                        <div class="col-lg-6" style="padding-left: 0; padding-right: 0;">
                            <asp:Label runat="server" ID="lblTaxAmount1" Text="0.00" />
                        </div>
                        <div class="col-lg-12">
                            Tax 2
                        </div>
                        <div class="col-lg-6" style="padding-right: 0;">
                            <asp:Label runat="server" ID="lblTax2" />:
                        </div>
                        <div class="col-lg-6" style="padding-left: 0; padding-right: 0;">
                            <asp:Label runat="server" ID="lblTaxAmount2" Text="0.00" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    &nbsp;
                    <div class="form-group" id="divRecurringView" runat="server" visible="False">
                        <div class="col-lg-12">
                            <h5>Frequency</h5>
                            <span style="font-weight: bold">Frequency:</span>
                            <asp:Label runat="server" ID="lblFrequency"></asp:Label>
                            <br />
                            <span style="font-weight: bold">Until:</span>
                            <asp:Label runat="server" ID="lblUntil"></asp:Label>
                            <br />
                            <div id="divUntilDateView" runat="server" visible="False">
                                <span style="font-weight: bold">End Date:</span>
                                <asp:Label runat="server" ID="lblUntilDate"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    &nbsp;
                    <div class="form-group" id="divAssignClientView" runat="server" visible="False">
                        <div class="col-lg-12">
                            <h5>Client</h5>
                            <asp:Label runat="server" ID="lblClient"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    &nbsp;
                    <div class="form-group" id="divAttachImgView" runat="server" visible="False">
                        <div class="col-lg-12" style="padding: 0; text-align: center;">
                            <h5>Attach Image</h5>
                            <asp:Image runat="server" ID="imgAttachView" Style="height: 100px; width: 100px;" Visible="False" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="text-align: center;">
                <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit" OnClick="btnEdit_Click" />
                <asp:Button runat="server" ID="btnDeleteView" CssClass="btn btn-danger" Text="Delete" OnClick="btnDeleteView_Click" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; display: inline-block; margin: 0; padding: 2%; width: 100%;">
                <h1 style="display: inline-block; margin: 0; width: 25%;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <div style="float: right; width: 75%; text-align: right;">
                    <ul id="footerPackageDiv" style="display: inline-block; padding: 0;">
                        <li class="open" style="list-style: none;">Want to <a href="ImportExpense.aspx" class="permission">import expenses?</a></li>
                    </ul>
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Expense" OnClick="btnAdd_Click" />
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
                                        Expense Category
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtExpenseCategorySearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Client Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtClientNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Vendor
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtVendorSearch" CssClass="searchText"></asp:TextBox>
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
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Status
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlStatusSearch" CssClass="searchText">
                                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="unassigned">unassigned</asp:ListItem>
                                            <asp:ListItem Value="unbilled">unbilled</asp:ListItem>
                                            <asp:ListItem Value="invoiced">invoiced</asp:ListItem>
                                            <asp:ListItem Value="recouped">recouped</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Date Range
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtDateFrom" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateFrom" TargetControlID="txtDateFrom" />
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtDateTo" CssClass="searchText"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" ID="ceDateTo" TargetControlID="txtDateTo" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Amount
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtAmountFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtAmountTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Has Receipt
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlReceiptSearch" CssClass="searchText">
                                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                            <asp:ListItem Value="false">No</asp:ListItem>
                                        </asp:DropDownList>
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
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvExpense" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-striped table-hover" DataSourceID="objdsExpense" DataKeyNames="ExpenseID"
                        AllowSorting="True" OnSorting="gvExpense_Sorting" OnSelectedIndexChanged="gvExpense_SelectedIndexChanged"
                        OnPageIndexChanging="gvExpense_PageIndexChanging" GridLines="None" OnRowDataBound="gvExpense_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("ExpenseID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ExpenseDate" HeaderText="Date" SortExpression="ExpenseDate" DataFormatString="{0:MMM dd, yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="SubCategoryID" HeaderText="Category" SortExpression="SubCategoryID"></asp:BoundField>
                            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"></asp:BoundField>
                            <asp:BoundField DataField="ExpenseAmount" HeaderText="Amount" SortExpression="ExpenseAmount" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField HeaderImageUrl="../App_Themes/Doyingo/images/paperclip.png" HeaderStyle-BackColor="aliceblue">
                                <ItemTemplate>
                                    <asp:Image runat="server" Visible='<%# Eval("AttachImage") %>' ImageUrl="../App_Themes/Doyingo/images/paperclip.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='<%# "ExpenseMaster.aspx?cmd=view&ID=" + Eval("ExpenseID") %>'>view</a>
                                    &nbsp;
                                    <a href='<%# "ExpenseMaster.aspx?cmd=add&ID=" + Eval("ExpenseID") %>'>edit</a>
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
                        <a id="activeTag" runat="server" href="ExpenseMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="ExpenseMaster.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="ExpenseMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>

                    <div class="totals ta_right">
                        <strong>Expense Totals:&nbsp;</strong>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <span class="">&nbsp;NGN</span><br />
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsExpense" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByExpenseSearch" TypeName="DABL.DAL.CloudAccountDATableAdapters.ExpenseMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtClientNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ClientName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtNotesSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Notes" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtExpenseCategorySearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ExpenseCategory" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtVendorSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="Vendor" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlStatusSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Status" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="FromDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtDateTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ToDate" Type="DateTime"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtAmountTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="AmountTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlReceiptSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="HasReceipt" Type="Boolean"></asp:ControlParameter>
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
    <asp:SqlDataSource runat="server" ID="sqldsTax" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaxID, '' AS TaxName UNION SELECT TaxID, TaxName FROM TaxMaster WHERE (CompanyID = @CompanyID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-1' AS ID,'- select a client -' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsClientStaff" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-1' AS ID,'- select a client -' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID AND [CompanyClientID] IN (SELECT ClientID FROM StaffClientAssignDetails WHERE StaffID = @StaffID AND IsAssign = 1)">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
            <asp:ControlParameter ControlID="hfStaffID" PropertyName="Value" DefaultValue="0" Name="StaffID"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
    <asp:HiddenField runat="server" ID="hfExpenseID" />
</asp:Content>
