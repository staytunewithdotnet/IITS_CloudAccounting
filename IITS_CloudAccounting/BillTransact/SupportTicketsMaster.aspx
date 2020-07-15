<%@ Page Title="Support Tickets Master" Language="C#" MasterPageFile="~/BillTransact/Admin.Master" AutoEventWireup="true" CodeBehind="SupportTicketsMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.SupportTicketsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm"></ajaxToolkit:ToolkitScriptManager>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="clip-stack"></i>
                    <a href="#">Support Tickets
                    </a>
                </li>
                <li>
                    <a href="SupportTicketsMaster.aspx">Bill Transact Support Tickets</a>
                </li>
            </ol>
            <div class="page-header">
                <h1>View/Edit Bill Transact Support Tickets</h1>
            </div>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnlAdd">
        <div class="panel-body">
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="panel-body">
            <table style="width: 100%; border: 1px solid #0394DA;">
                <tr>
                    <td colspan="3" style="padding: 15px;">
                        <asp:Label runat="server" ID="lblSubject" Style="font-size: large;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 15px;">Created:
                            <asp:Label runat="server" ID="lblSupportDate" Text="2015-10-02 15:54:00"></asp:Label>
                    </td>
                </tr>
                <tr style="color: white; background-color: #0394DA;">
                    <td style="width: 33.33%; padding: 15px; border-right: 1px solid #1E9FDE;">
                        <span style="text-transform: uppercase; font-weight: normal">Department</span>
                        <br />
                        <asp:Label runat="server" ID="lblSupportDepartment" Font-Bold="True"></asp:Label>
                        <br />
                    </td>
                    <td style="width: 33.33%; padding: 15px; border-right: 1px solid #1E9FDE;">
                        <span style="text-transform: uppercase; font-weight: normal">Status</span>
                        <br />
                        <asp:UpdatePanel runat="server" ID="upEditStatus">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="lblStatus" Font-Bold="True"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlStatus" Visible="False" Style="color: black" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged">
                                    <asp:ListItem Value="Open">Open</asp:ListItem>
                                    <asp:ListItem Value="On Hold">On Hold</asp:ListItem>
                                    <asp:ListItem Value="Awaiting Client Reply">Awaiting Client Reply</asp:ListItem>
                                    <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                </asp:DropDownList>
                                (<asp:LinkButton runat="server" ID="lnkEditStatus" Text="edit" Style="color: white" OnClick="lnkEditStatus_Click"></asp:LinkButton>)
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width: 33.33%; padding: 15px; border-right: 1px solid #1E9FDE;">
                        <span style="text-transform: uppercase; font-weight: normal">Priority</span>
                        <br />
                        <asp:UpdatePanel runat="server" ID="upEditPriority">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="lblSupportPriority" Font-Bold="True"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlSupportPriority" Visible="False" Style="color: black" AutoPostBack="True" OnSelectedIndexChanged="ddlPriority_OnSelectedIndexChanged">
                                    <asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
                                    <asp:ListItem Value="Emergency">Emergency</asp:ListItem>
                                    <asp:ListItem Value="Critical">Critical</asp:ListItem>
                                </asp:DropDownList>
                                (<asp:LinkButton runat="server" ID="lnkEditPriority" Text="edit" Style="color: white" OnClick="lnkEditPriority_Click"></asp:LinkButton>)
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <div class="clearfix"></div>
            <div class="col-lg-12">
                <div class="form-horizontal">
                    <%--<div class="form-group">
                        <div class="col-lg-1 control-label">
                            Question:
                        </div>
                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif; padding-top: 0;">
                            
                        </div>
                    </div>--%>
                    <div class="form-group" style="margin-bottom: 0">
                        <div class="col-lg-12 page-header">
                            <h3>Attachments</h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:DataList runat="server" ID="dlAttachment" Width="100%" BorderWidth="0px" DataKeyField="DoyinGoTicketAttachmentID" RepeatColumns="2" RepeatDirection="Horizontal" DataSourceID="sqldsAttachment">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("AttachFileName") %>' runat="server" ID="AttachFileNameLabel" />
                                    <asp:Button runat="server" ID="btnDownload" ToolTip='<%# Eval("DoyinGoTicketAttachmentID") %>' Text="Download" OnClick="btnDownload_Click" />
                                    <asp:Label Text='<%# Eval("DoyinGoTicketAttachmentID") %>' runat="server" ID="DoyinGoTicketAttachmentIDLabel" Visible="False" />
                                    <asp:Label Text='<%# Eval("DoyinGoSupportTicketID") %>' runat="server" ID="DoyinGoSupportTicketIDLabel" Visible="False" />
                                    <br />
                                    <br />
                                    <div class="clearfix" style="margin-bottom: 10px;"></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label runat="server" ID="lblEmptyAttach" Text="No Attachment Found..!" Visible='<%# dlAttachment.Items.Count==0 %>' Style="padding: 0; text-align: center; width: 100%;"></asp:Label>
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource runat="server" ID="sqldsAttachment" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [AttachFileName], [DoyinGoTicketAttachmentID], [DoyinGoSupportTicketID] FROM [DoyinGoTicketAttachment] WHERE ([DoyinGoSupportTicketID] = @DoyinGoSupportTicketID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfSupportTicketID" PropertyName="Value" DefaultValue="0" Name="DoyinGoSupportTicketID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 page-header">
                            <h3>Messages</h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <div class="col-lg-4" style="background-color: #EDEDEF; padding-left: 0; padding-right: 0; border-right: 2px solid #DDDDDD; border-bottom: 1px solid #e2e2e2; border-top: 1px solid #e2e2e2; border-left: 1px solid #e2e2e2;">
                                <h3 style="padding: 0 15px">
                                    <asp:Label runat="server" ID="lblCompanyPersonName"></asp:Label>
                                </h3>
                                <span style="padding: 0 15px; display: block; width: 100%">
                                    <asp:Label runat="server" ID="lblCompanyName"></asp:Label>
                                </span>
                                <br />
                                <br />
                            </div>
                            <div class="col-lg-8" style="background-color: #FFFFFF; padding-left: 0; padding-right: 0; border: 1px solid #e2e2e2;">
                                <asp:Label runat="server" ID="lblSupportDate1" Text="2015-10-02 15:54:00" Style="padding-left: 15px; font-size: 12px; font-style: italic;"></asp:Label>
                                <br />
                                <hr style="margin: 10px 0;" />
                                <asp:Label runat="server" ID="lblMessage" Style="padding-left: 15px;"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <br />
                            <br />
                            <div class="clearfix" style="margin-bottom: 15px;"></div>
                            <asp:DataList runat="server" ID="dlDiscussion" Width="100%" CssClass="table-responsive" BorderWidth="0" DataKeyField="DoyinGoSupportDiscussionID" DataSourceID="sqldsDiscussion">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("DoyinGoSupportDiscussionID") %>' runat="server" ID="DoyinGoSupportDiscussionIDLabel" Visible="False" />
                                    <asp:Label Text='<%# Eval("DoyinGoSupportTicketID") %>' runat="server" ID="DoyinGoSupportTicketIDLabel" Visible="False" />
                                    <div class="col-lg-4" style="background-color: #EDEDEF; padding-left: 0; padding-right: 0; border-right: 2px solid #DDDDDD; border-bottom: 1px solid #e2e2e2; border-top: 1px solid #e2e2e2; border-left: 1px solid #e2e2e2;">
                                        <h3 style="padding: 0 15px">
                                            <asp:Label Text='<%# SetName(Eval("SupportMessageBy").ToString()) %>' runat="server" ID="SupportMessageByLabel" />
                                        </h3>
                                        <br />
                                        <span style="padding: 0 15px; display: block; width: 100%">
                                            <%# GetCompanyName(Eval("SupportMessageBy").ToString()) %>
                                        </span>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-lg-8" id="mydiv8" style="background-color: #FFFFFF; padding-left: 0; padding-right: 0; border: 1px solid #e2e2e2;">
                                        <asp:Label Text='<%# "Posted On: "+Eval("SupportMessageDate") %>' runat="server" ID="SupportMessageDateLabel" Style="padding-left: 15px; font-size: 12px; font-style: italic;" />
                                        <br />
                                        <hr />
                                        <asp:Label Text='<%# Eval("SupportMessage") %>' runat="server" ID="SupportMessageLabel" Style="padding-left: 15px;" />
                                        <br />
                                        <br />
                                    </div>
                                    <br />
                                    <br />
                                    <div class="clearfix" style="margin-bottom: 15px;"></div>
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource runat="server" ID="sqldsDiscussion" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [DoyinGoSupportDiscussion] WHERE ([DoyinGoSupportTicketID] = @DoyinGoSupportTicketID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfSupportTicketID" PropertyName="Value" DefaultValue="0" Name="DoyinGoSupportTicketID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 page-header">
                            <h3>Post Reply</h3>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-1 control-label">
                            Message:
                        </div>
                        <div class="col-lg-11">
                            <asp:TextBox runat="server" ID="txtDiscussion" TextMode="MultiLine" CssClass="form-control text" Style="width: 100% !important;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnSaveDiscussion" Text="Submit" CssClass="btn btn-success" OnClick="btnSaveDiscussion_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                        <asp:Button runat="server" ID="btnListAll" Text="List All" CssClass="btn btn-info" OnClick="btnListAll_Click" />
                        <asp:Button runat="server" ID="btnClose" Text="Close Ticket" CssClass="btn btn-warning" OnClick="btnClose_Click" Style="display: none;" />
                        <asp:Button runat="server" ID="btnOpen" Text="Re-Open Ticket" CssClass="btn btn-warning" OnClick="btnOpen_Click" Style="display: none;" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlViewAll">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvSupportTicket" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-bordered table-hover" DataKeyNames="DoyinGoSupportTicketID" GridLines="None"
                        OnSelectedIndexChanged="gvSupportTicket_SelectedIndexChanged" OnRowDataBound="gvSupportTicket_RowDataBound"
                        OnPageIndexChanging="gvSupportTicket_PageIndexChanging" DataSourceID="objdsSupportTicket">
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Support Ticket Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="DoyinGoSupportTicketID" HeaderText="ID" ReadOnly="True" SortExpression="DoyinGoSupportTicketID"></asp:BoundField>
                            <asp:BoundField DataField="CompanyID" HeaderText="Company" SortExpression="CompanyID"></asp:BoundField>
                            <asp:BoundField DataField="SupportDepartmentID" HeaderText="Support Department" SortExpression="SupportDepartmentID"></asp:BoundField>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject"></asp:BoundField>
                            <asp:BoundField DataField="SupportPriority" HeaderText="Support Priority" SortExpression="SupportPriority"></asp:BoundField>
                            <asp:BoundField DataField="SupportDate" HeaderText="Support Date" SortExpression="SupportDate" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                            <%--<asp:BoundField DataField="SupportStatus" HeaderText="Support Status" SortExpression="SupportStatus"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <%# SetStatus(Eval("SupportStatus").ToString()) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="objdsSupportTicket" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DABL.DAL.CloudAccountDATableAdapters.DoyinGoSupportTicketTableAdapter"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <div style="color: white; text-align: center">
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:HiddenField runat="server" ID="hfSupportTicketID" />
    <asp:HiddenField runat="server" ID="hfMasterAdminID" />
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyLoginID" />
</asp:Content>


