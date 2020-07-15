<%@ Page Title="" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true"  Async="true"
    CodeBehind="DefaultDoyingo.aspx.cs" Inherits="IITS_CloudAccounting.Admin.DefaultDoyingo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <style type="text/css">
        .ajax__tab_xp .ajax__tab_body {
            padding: 0 0 0 0;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            height: 40px;
            padding: 4px;
            margin: 0;
            font-size: 13px;
            font-family: Verdana;
        }

        .ajax__tab_header {
            height: 40px;
        }

        .ajax__tab_tab {
            height: 40px;
        }

        .ajax__tab_xp .ajax__tab_header {
            font-size: 12px;
            height: 30px;
        }

        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-color: black;
            border-style: solid;
            border-width: 3px;
            height: 370px;
            padding-left: 10px;
            padding-top: 10px;
            width: 575px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("homeDiv");
            d.style.display = 'block';
        });

    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Dashboard
                    </a>
                </li>
            </ol>
            <div class="page-header" id="dashboard" runat="server">
                <h1>My Company Dashboard
                    <asp:Label runat="server" Visible="false" ID="lblRole"></asp:Label>
                </h1>
            </div>
        </div>
    </div>
    
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-tasks fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="AccountsAgingReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Accounts Aging</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-money fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="ExpensesReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Expense Report</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-list-alt fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="InvoiceDetailsReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Invoice Details</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-line-chart fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Profit and Loss</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-suitcase fa-5x"></i>
                        </div>
                    </div>
                </div>
                <a href="TaxSummaryReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Tax Summary</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-purple">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-clock-o fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="TimesheetDetailsReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Timesheet Details</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-danger">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-edit fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Balance Sheet</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-blue">
                <div class="panel-heading" style="min-height: 110px;">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-send-o fa-5x"></i>
                        </div>

                    </div>
                </div>
                <a href="RevenueByClientReport.aspx">
                    <div class="panel-footer">
                        <span class="pull-left"><b>Revenue by Client</b></span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif; min-height: 110px">
        <asp:Panel runat="server" ID="pnlMasterAdmin"></asp:Panel>
        <asp:Panel runat="server" ID="pnlCompanyAdmin">
            <div class="row" style="margin-top: 25px;" id="packageInfo" runat="server" visible="False">
                <div class="col-sm-3">&nbsp;</div>
                <div class="col-sm-6">
                    <div class="panel panel-default" style="height: 270px">
                        <div class="panel-heading">
                            <i class="fa fa-warning"></i>
                            Package Information
                        </div>
                        <div class="panel-body panel-scroll ps-container" style="height: 250px">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="alert alert-danger fade in">
                                            <p style="font-size: 20px; text-align: center; margin: 20px auto;">
                                                Your Package Is Expired..! Please Upgrade Package To Work In Your Cloud Invoicing Portal.!!
                                            </p>
                                            <div style="color: white; text-align: center">
                                                <asp:Button ID="btnUpgrade" runat="server" Text="Upgrade" CssClass="btn btn-bricky" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">&nbsp;</div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlEmployee">
            <div class="col-lg-3">&nbsp;</div>
            <div class="col-lg-6 notification-page notification-info" runat="server" id="welcomeDiv" style="min-height: 100px">
                <asp:Label runat="server" ID="lblStaffWelcomeMsg"></asp:Label>
            </div>
            <div class="col-lg-3">&nbsp;</div>
            <div class="clearfix"></div>
        </asp:Panel>
        <asp:Panel runat="server" ID="my"></asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpUserData" PopupControlID="pnlUserData" TargetControlID="my" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpUserDataStep2" PopupControlID="pnlUserDataStep2" TargetControlID="my" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlUserData" runat="server" Height="585px" Width="535px" align="center" Style="display: none; background-color: white; padding: 22px 30px 25px; border: 5px solid lightgrey; border-radius: 15px;">
        <table style="width: 100%; height: 100px;">
            <tr style="background: #0D83DC url('../App_Themes/Doyingo/images/step1.png') right no-repeat; border: none;">
                <td style="height: 12%; color: White; font-weight: bold; font-size: 25px; text-align: left; width: 60%; font-family: FranklinMedium,Arial,sans-serif; padding: 0 10px;">Get Started in<br />
                    2 Quick Steps</td>
            </tr>
        </table>
        <div class="panel-body" style="border-color: #e9edf2; padding-bottom: 0;">
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                Name*:
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtFirstName" TabIndex="1" onkeypress="return isLetter(event)" CssClass="form-group text" PlaceHolder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtFirstName" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtLastName" TabIndex="2" onkeypress="return isLetter(event)" CssClass="form-group text" PlaceHolder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtLastName" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                Username*:
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtUsername" Enabled="False" TabIndex="3" CssClass="form-group text" PlaceHolder="User Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUsername" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtUsername" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                Password*:
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtPassword" TabIndex="4" CssClass="form-group text" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtPassword" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" ID="txtConfPassword" TabIndex="5" CssClass="form-group text" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfPassword" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtConfPassword" ValidationGroup="UserDataMaster">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvPassword" ControlToValidate="txtConfPassword" ControlToCompare="txtPassword" Display="Dynamic" ForeColor="red" ValidationGroup="UserDataMaster"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                I heard about Bill Transact from...
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:TextBox runat="server" Visible="false" ID="txtAboutDoyingo" TabIndex="6" CssClass="form-group text"  ></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddlAboutDoyingo" >
                                <asp:ListItem>Email</asp:ListItem>
                                <asp:ListItem>Word-of-mouth</asp:ListItem>
                                <asp:ListItem>Linkedin</asp:ListItem>
                                                                <asp:ListItem>Search Engine</asp:ListItem>
                                                                <asp:ListItem>Social Media</asp:ListItem>
                                                                <asp:ListItem>Friends</asp:ListItem>
                                                                <asp:ListItem>TV Ads</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="border-color: #e9edf2; padding-top: 0;">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: #e9edf2; text-align: center">
                        <asp:Button ID="btnSubmitUserData" runat="server" Text="Continue to Final Step" TabIndex="7" CssClass="btn-primary"
                            ValidationGroup="UserDataMaster" OnClick="BtnSubmitUserDataClick" Style="width: 100%; padding: 10px; font-size: 20px; font-family: Verdana;" />
                        <div class="example" style="color: black; margin-top: 10px;">
                            By clicking the button above, you agree to the<br />
                            <a href="#" target="_blank">terms of service</a> &amp;
				<a href="#" target="_blank">privacy policy</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <table style="border: none; width: 100%;">
            <tr style="background-color: #34425A; height: 45px">
                <td style="color: #34425A; text-align: center"></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlUserDataStep2" runat="server" Height="545px" Width="535px" align="center" Style="display: none; padding: 22px 30px 25px; border: 5px solid rgb(211, 211, 211); border-radius: 15px; position: fixed; z-index: 100001; background-color: white;">
        <table style="width: 100%; height: 100px;">
            <tr style="border: none; background: #0d83dd url('../App_Themes/Doyingo/images/step2.png') right no-repeat;">
                <td colspan="2" style="height: 12%; color: White; font-weight: bold; font-size: 27px; line-height: 32px; padding: 0 15px; font-family: FranklinMedium,Arial,sans-serif;">Hi
                    <asp:Label runat="server" ID="lblCompany"></asp:Label>,<br />
                    Help Us Get To Know You</td>
            </tr>
        </table>
        <div class="panel-body" style="border-color: #e9edf2;">
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                My industry is...
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:DropDownList runat="server" ID="ddlIndustry" TabIndex="1" CssClass="form-control text" DataSourceID="sqldsIndustry" DataTextField="IndustryName" DataValueField="IndustryID">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                My business is a...
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:DropDownList runat="server" ID="ddlBussiness" TabIndex="2" CssClass="form-control text" DataSourceID="sqldsBussiness" DataTextField="BussinessName" DataValueField="BussinessID">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                It's been up and running for...
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:DropDownList runat="server" ID="ddlRunningFor" TabIndex="3" CssClass="form-control text" DataSourceID="sqldsRunningFrom" DataTextField="RunningFrom" DataValueField="RunningFromID">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="control-label" style="text-align: left; padding-left: 20px; padding-right: 15px; color: black; font-size: 14px;">
                I currently do my accounting using...
            </div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:DropDownList runat="server" ID="ddlCurrentAccount" TabIndex="4" CssClass="form-control text" DataSourceID="sqldsCurrentAccount" DataTextField="CurrentAccountName" DataValueField="CurrentAccountID">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="padding-top: 0; border-color: #e9edf2;">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: #e9edf2; text-align: center">
                        <asp:Button ID="btnUserDataStep2" runat="server" Text="Show Me My Account" TabIndex="5" CssClass="btn-primary"
                            OnClick="btnUserDataStep2_Click" Style="width: 100%; padding: 10px; font-size: 20px; font-family: Verdana;" />
                        <br />
                        <br />
                        <span style="font-family: 'Open Sans', sans-serif; font-size: 13px; color: #4E5E6A;">Or</span>
                        <asp:LinkButton runat="server" ID="lnkClick" Text="skip this" OnClick="btnUserDataStep2_Click" Style="text-decoration: underline"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <table style="border: none; width: 100%;">
            <tr style="background-color: #34425A; height: 45px">
                <td style="color: #34425A; text-align: center"></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:SqlDataSource runat="server" ID="sqldsBussiness" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS BussinessID, '[choose one]' AS BussinessName UNION SELECT [BussinessID], [BussinessName] FROM [BussinessMaster] WHERE ([BussinessStatus] = @BussinessStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="BussinessStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsRunningFrom" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS RunningFromID, '[choose one]' AS RunningFrom UNION SELECT [RunningFromID], [RunningFrom] FROM [RunningFromMaster] WHERE ([RunningFromStatus] = @RunningFromStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="RunningFromStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsIndustry" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT - 1 AS IndustryID, '[choose one]' AS IndustryName UNION SELECT IndustryID, IndustryName FROM IndustryMaster WHERE (IndustryStatus = @IndustryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="IndustryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsCurrentAccount" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS CurrentAccountID, '[choose one]' AS CurrentAccountName UNION SELECT [CurrentAccountID], [CurrentAccountName] FROM [CurrentAccountMaster] WHERE ([CurrentAccountStatus] = @CurrentAccountStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CurrentAccountStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
