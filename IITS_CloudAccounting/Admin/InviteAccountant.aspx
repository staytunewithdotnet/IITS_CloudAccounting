<%@ Page Title="Invite Accountant" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" Async="true"
    CodeBehind="InviteAccountant.aspx.cs" Inherits="IITS_CloudAccounting.Admin.InviteAccountant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <style type="text/css">
        .ajax__tab_xp .ajax__tab_body {
            padding: 0 0 0 0;
        }

        .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
            font-family: Verdana;
            font-size: 13px;
            height: 40px;
            margin: 0;
            padding: 4px;
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

        .outty_title {
            color: #0d83dd;
        }

        h1, h2 {
            color: #000;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 24px;
            line-height: normal;
            margin: 0 0 7px 0;
            padding: 0;
        }

        .outty_description {
            color: black;
            clear: none;
            margin-right: 10px;
            overflow: hidden;
            font-size: 12px;
            font-family: Verdana,sans-serif;
        }

        .outty_content p {
            clear: both;
            margin: 0 30px 20px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("peopleDiv");
            p.style.display = 'block';
        });
    </script>

    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-users"></i>
                    <a href="#">People
                    </a>
                </li>
                <li>
                    <a href="InviteAccountant.aspx">Invite Accountant</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1 style="display: inline-block; margin: 10px 0 15px;">Accountant</h1>
            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="Add Accountant" Style="float: right;" />
            <asp:Button runat="server" ID="btnRemove" CssClass="btn btn-success" Text="Remove Accountant" Style="float: right;" OnClick="BtnRemoveClick" />
        </div>
        <div class="panel-body" style="padding-left: 0; padding-right: 0;">
            <div class="col-lg-8 rounded-container peel-shadows" style="color: black">
                <asp:DataList runat="server" ID="dlClientByYou" Width="100%" DataKeyField="AccountantClientDetailID" DataSourceID="sqldsClientByYou" Style="margin-bottom: 0;">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AccountantClientDetailID") %>' runat="server" ID="AccountantClientDetailIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("AccountantID") %>' runat="server" ID="AccountantIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("CompanyID") %>' runat="server" ID="CompanyIDLabel" Visible="False" /><br />
                        <div class="form-group col-lg-2" style="padding-left: 0;">
                            <div class="advisor-icon-large bg-system-light" style="margin-left: 5px;"></div>
                        </div>

                        <div class="col-lg-9">
                            <div class="col-lg-12 form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <h3 style="margin: 0;">
                                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" />
                                        </h3>
                                    </div>
                                    <div class="col-lg-12">
                                        <h5 style="margin: 0;">
                                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" />
                                        </h5>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-envelope" style="font-size: 15px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <a href='<%# "mailto:"+ Eval("AccountantEmail") %>' class="permission">
                                            <asp:Label Text='<%# Eval("AccountantEmail") %>' runat="server" ID="AccountantEmailLabel" />
                                        </a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-1">
                                        <i class="fa fa-phone" style="font-size: 15px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label Text='<%# Eval("AccountantPhone") %>' runat="server" ID="AccountantPhoneLabel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <hr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblClientEmpty" Text="No Accountant Found" Visible='<%# bool.Parse((dlClientByYou.Items.Count==0).ToString()) %>'></asp:Label>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="sqldsClientByYou" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.AccountantClientDetailID,b.AccountantID,a.CompanyID,b.AccountantPhone,b.AccountantFirstName+' '+ b.AccountantLastName AS Name,b.CompanyName,b.AccountantEmail FROM AccountantClientDetail a inner join AccountantMaster b on a.AccountantID = b.AccountantID WHERE a.CompanyID = @CompanyID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div class="col-lg-1" style="width: 1.3333%; padding: 0;">&nbsp;</div>
            <div class="col-lg-4 rounded-container peel-shadows" style="width: 32%; padding-right: 0; color: black;">
                <h4>What Can My Accountant See?</h4>
                <p style="font-family: Verdana,sans-serif; font-size: 12px; line-height: 18px; margin-bottom: 20px;">
                    Your Accountant has access to your Bill Transact Reports and Journal Entries so they can advise you better. <%--<a href="#" target="_blank" class="permission">Learn More.</a>--%>
                </p>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />

    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInviteAcc1" PopupControlID="pnlInviteAcc1" TargetControlID="btnAdd" CancelControlID="lnkCloseFirst" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInviteAcc2" PopupControlID="pnlInviteAcc2" TargetControlID="lnkSecondOpen" CancelControlID="lnkSecondClose" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlInviteAcc1" runat="server" Height="300px" Width="520px" align="center" Style="background-color: white; border: 5px solid rgb(211, 211, 211); border-radius: 15px; display: none; padding: 22px 30px 25px; position: fixed; z-index: 100001;">
        <div class="panel-body" style="border-color: #e9edf2; padding-top: 0; padding-left: 0;">
            <div class="col-lg-12" style="padding: 0;">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                        </div>
                        <div class="col-lg-8" style="text-align: left; padding: 0;">
                            <div>
                                <h2 class="outty_title">Share your financials with your Accountant
                                </h2>
                                <p class="outty_description">
                                    If you work with an accountant, bookkeeper, or small business
                                    consultant, add them as your Bill Transact Accountant to give them read-only access to
                                    your business reports and journal entries.
         
                                </p>
                                <p class="outty_description">
                                    <asp:LinkButton ID="lnkSecondOpen" runat="server" Text="Invite Your Accountant" CssClass="btn btn-success" Style="width: 100%"></asp:LinkButton>
                                </p>
                                <p class="outty_description">
                                    Don't have an accountant?
                                    <a href="#" target="_blank" class="permission">Find one near you</a>
                                </p>
                                <p></p>
                                <div class="clearb"></div>
                            </div>
                        </div>
                        <div class="col-lg-4" style="padding: 0;">
                            <img src="../App_Themes/Doyingo/images/advisors.gif" alt="advisors" />
                            <br />
                            <br />
                            <br />
                            <asp:LinkButton runat="server" ID="lnkCloseFirst" CssClass="permission" Text="cancel"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlInviteAcc2" runat="server" Height="485px" Width="600px" align="left" Style="background-color: white; border: 5px solid rgb(211, 211, 211); border-radius: 15px; display: none; position: fixed; z-index: 100001;">
        <div class="panel-body" style="border-color: #e9edf2; background-color: #F1F1F1; color: black; border-radius: 9px 9px 0 0;">
            <%--<div class="x_button" role="button"></div>--%>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <h3 style="margin-left: 0;">Compose Your Invitation</h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Accountant's Email <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control text" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmailAddress" Display="Dynamic" ForeColor="Red" ValidationGroup="Invitation" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" SetFocusOnError="True" ValidationGroup="Invitation" ControlToValidate="txtEmailAddress" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Subject
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                            <asp:Label runat="server" ID="lblSubject"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="background-color: #FFF; color: lightgray; text-align: center">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center">
                            <h3 style="margin: 0">
                                <asp:Label runat="server" ID="lblCompanyPerson" Style="font-weight: bold; color: black;" Text="Person Name"></asp:Label>
                                from
                                <asp:Label runat="server" ID="lblCompanyName" Style="font-weight: bold; color: black;" Text="Company Name"></asp:Label>
                                has invited you to view their Bill Transact Reports and Journal Entries. Get access by creating your very own Accountant Center. 
                            </h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-1">&nbsp;</div>
                        <div class="col-lg-10" style="text-align: center">
                            <asp:TextBox runat="server" ID="txtDesc" Text="I'd like to give you access to my financial reports." TextMode="MultiLine" Style="font-size: large; font-weight: bold;"></asp:TextBox>
                        </div>
                        <div class="col-lg-1">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body" style="background-color: #F1F1F1; color: black; text-align: center; border-radius: 0 0 9px 9px;">
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Button runat="server" ID="btnSend" CssClass="btn btn-success" Text="Send" ValidationGroup="Invitation" OnClick="BtnSendClick" />
                            or
                            <asp:LinkButton runat="server" ID="lnkSecondClose" Text="cancel" CssClass="permission"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" ID="hfEmail" />
</asp:Content>
