<%@ Page Title="" Language="C#" MasterPageFile="~/Accountant/AccountantMaster.Master" AutoEventWireup="true" CodeBehind="AccountantClients.aspx.cs" Inherits="IITS_CloudAccounting.Accountant.AccountantClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-home"></i>
                    <a href="#">Dashboard
                    </a>
                </li>
            </ol>
            <div class="page-header">
                <h1>Dashboard</h1>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">

        <div class="clearfix"></div>
        <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
            <h2 style="color: #000; font-size: 30px; font-weight: normal; line-height: 30px; margin: 0; text-align: left; display: inline-block">Your Bill Transact Clients</h2>
            <asp:Button runat="server" ID="btnClient" Text="Invite Client" CssClass="btn btn-success" Style="float: right;" />
        </div>

        <div class="clearfix"></div>

        <div class="panel-body">
            <%--<div class="col-lg-1" style="width: 2%; margin-top: 10px;"></div>--%>
            <div class="col-lg-5 rounded-container peel-shadows" style="padding-bottom: 0; padding-top: 15px;">
                <strong>Invited Client by You</strong>
                <asp:DataList runat="server" ID="dlClientByYou" Width="100%" DataKeyField="AccountantClientDetailID" DataSourceID="sqldsClientByYou" Style="margin-bottom: 0;">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AccountantClientDetailID") %>' runat="server" ID="AccountantClientDetailIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("AccountantID") %>' runat="server" ID="AccountantIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("CompanyID") %>' runat="server" ID="CompanyIDLabel" Visible="False" />
                        <h3 style="margin: 0;">
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" /></h3>
                        <h5 style="margin: 0;">
                            <asp:Label Text='<%# Eval("CompanyContactPerson") %>' runat="server" ID="CompanyContactPersonLabel" />
                        </h5>
                        <i class="fa fa-envelope" style="font-size: 15px;"></i>
                        <a href='<%# "mailto:"+ Eval("CompanyEmail") %>' class="permission">
                            <asp:Label Text='<%# Eval("CompanyEmail") %>' runat="server" ID="CompanyEmailLabel" />
                        </a>
                        <br />
                        <div class="btn-group" role="group">
                            <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #888; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                Access Account<span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu">
                                <li>
                                    <a href="#">Export Journal Entries</a>
                                </li>
                                <li>
                                    <a href="#">View Reports</a>
                                </li>
                            </ul>
                        </div>
                        <br />
                        <asp:LinkButton runat="server" ID="lnkRemoveFromClient" Text="Remove client" CssClass="permission" OnClick="lnkRemoveFromClient_OnClick"
                            ToolTip='<%# Eval("AccountantClientDetailID") %>'></asp:LinkButton>
                        <br />
                        <br />
                        <hr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblClientEmpty" Text="No Company Invited By You" Visible='<%# bool.Parse((dlClientByYou.Items.Count==0).ToString()) %>'></asp:Label>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="sqldsClientByYou" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT AccountantClientDetailID,AccountantID,a.CompanyID,b.CompanyContactPerson,b.CompanyName,b.CompanyEmail FROM AccountantClientDetail a inner join CompanyMaster b on a.CompanyID = b.CompanyID WHERE RequestToClient = 1 AND AccountantID = @AccountantID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfAccountantID" PropertyName="Value" DefaultValue="0" Name="AccountantID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
            <div class="col-lg-2" style="">&nbsp;</div>
            <div class="col-lg-5 rounded-container peel-shadows" style="padding-bottom: 0; padding-top: 15px;">
                <strong>You Invited by Client </strong>
                <asp:DataList runat="server" ID="dlYouByClient" Width="100%" DataKeyField="AccountantClientDetailID" DataSourceID="sqldsYouByClient" Style="margin-bottom: 0;">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("AccountantClientDetailID") %>' runat="server" ID="AccountantClientDetailIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("AccountantID") %>' runat="server" ID="AccountantIDLabel" Visible="False" />
                        <asp:Label Text='<%# Eval("CompanyID") %>' runat="server" ID="CompanyIDLabel" Visible="False" />
                        <h3 style="margin: 0">
                            <asp:Label Text='<%# Eval("CompanyContactPerson") %>' runat="server" ID="CompanyContactPersonLabel" />
                        </h3>
                        <h5 style="margin: 0">
                            <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" />
                        </h5>
                        <i class="fa fa-envelope" style="font-size: 15px;"></i>
                        <a href='<%# "mailto:"+ Eval("CompanyEmail") %>' class="permission">
                            <asp:Label Text='<%# Eval("CompanyEmail") %>' runat="server" ID="CompanyEmailLabel" />
                        </a>
                        <br />
                        <div class="btn-group" role="group">
                            <button type="button" class="btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false" style="background-color: #888; border: 1px solid #666; color: #fff!important; padding: 0 10px; font: bold 14px/28px Arial,Helvetica,sans-serif;">
                                Access Account<span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu">
                                <li>
                                    <a href="#">Export Journal Entries</a>
                                </li>
                                <li>
                                    <a href="#">View Reports</a>
                                </li>
                            </ul>
                        </div>
                        <br />
                        <asp:LinkButton runat="server" ID="lnkRemoveByClient" Text="Remove client" CssClass="permission" OnClick="lnkRemoveByClient_OnClick"
                            ToolTip='<%# Eval("AccountantClientDetailID") %>'></asp:LinkButton>
                        <%-- OnClientClick='<%# Eval("return confirm('Are you sure you want to disconnect this client from your Accountant Center?')") %>' --%>
                        <br />
                        <br />
                        <hr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label runat="server" ID="lblYouEmpty" Text="No Company Invited You As Accountant" Visible='<%# bool.Parse((dlYouByClient.Items.Count==0).ToString()) %>'></asp:Label>
                    </FooterTemplate>
                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="sqldsYouByClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT AccountantClientDetailID,AccountantID,a.CompanyID,b.CompanyContactPerson,b.CompanyName,b.CompanyEmail FROM AccountantClientDetail a inner join CompanyMaster b on a.CompanyID = b.CompanyID WHERE RequestFromClient = 1 AND AccountantID = @AccountantID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hfAccountantID" PropertyName="Value" DefaultValue="0" Name="AccountantID"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
            <%--<div class="col-lg-1" style="width: 2%"></div>--%>
        </div>

        <div class="clearfix"></div>

    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfAccountantID" />
    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpInviteAcc2" PopupControlID="pnlInviteAcc2" TargetControlID="btnClient" CancelControlID="lnkSecondClose" BackgroundCssClass="modelBackground">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlInviteAcc2" runat="server" Height="580px" Width="600px" align="left" Style="background-color: white; border: 5px solid rgb(211, 211, 211); border-radius: 15px; display: none; position: fixed; z-index: 100001;">
        <div class="panel-body" style="border-color: #e9edf2; background-color: #F1F1F1; color: black; border-radius: 9px 9px 0 0;">
            <div class="x_button" role="button"></div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <h3 style="margin-left: 0;">Compose Your Invitation</h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Client's Email <span style="color: red">*</span>
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
                            <h3 style="margin: 0; font-weight: normal; color: #888888; font-size: 18px">
                                <asp:Label runat="server" ID="lblAccountant" Style="font-weight: bold; color: black;" Text="Person Name"></asp:Label>
                                from
                                <asp:Label runat="server" ID="lblAccountantCompany" Style="font-weight: bold; color: black;" Text="Company Name"></asp:Label>
                                has invited you to connect using Bill Transact to painlessly send invoices, track time, and capture expenses. Accept this invitation to make collaborating with your Accountant easy by giving them access to your Bill Transact Reports. 
                            </h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-1">&nbsp;</div>
                        <div class="col-lg-10" style="text-align: center">
                            <asp:TextBox runat="server" ID="txtDesc" Text="Bill Transact allows you to easily capture your business transactions and provides me with the information I need, reducing the stress of tax time." TextMode="MultiLine" Style="font-size: large; font-weight: bold;"></asp:TextBox>
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
    <asp:HiddenField runat="server" ID="hfEmail"/>
</asp:Content>
