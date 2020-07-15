<%@ Page Title="" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="DoyinGoSupportTicket.aspx.cs" Inherits="IITS_CloudAccounting.Admin.DoyinGoSupportTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
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
                    <a href="DefaultDoyingo.aspx">Home
                    </a>
                </li>
                <li>
                    <a href="DoyinGoSupportTicket.aspx">Bill Transact Support Ticket</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <asp:Panel runat="server" ID="pnlAdd">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>New Bill Transact Support Ticket</h1>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Support Department <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:DropDownList runat="server" ID="ddlSupportDepartment" CssClass="form-control text" TabIndex="1" DataSourceID="sqldsSupportDepartment" DataTextField="SupportDepartmentName" DataValueField="SupportDepartmentID" />
                            <asp:RequiredFieldValidator runat="server" ID="rfvDepartment" ControlToValidate="ddlSupportDepartment" InitialValue="-1" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SupportTicket">*</asp:RequiredFieldValidator>
                            <asp:SqlDataSource runat="server" ID="sqldsSupportDepartment" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS SupportDepartmentID, '[choose one]' AS SupportDepartmentName UNION SELECT [SupportDepartmentID], [SupportDepartmentName] FROM [SupportDepartmentMaster] WHERE ([SupportDepartmentStatus] = @SupportDepartmentStatus)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="True" Name="SupportDepartmentStatus" Type="Boolean"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Subject <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-8">
                            <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control text" TabIndex="2" MaxLength="150"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvSubject" ControlToValidate="txtSubject" SetFocusOnError="True" ForeColor="Red" ValidationGroup="SupportTicket">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Message <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-8">
                            <asp:TextBox runat="server" ID="txtMessage" CssClass="form-control text" TabIndex="3" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvMessage" ControlToValidate="txtMessage" SetFocusOnError="True" ForeColor="Red" ValidationGroup="SupportTicket">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Support Priority <span style="color: red">*</span>
                        </div>
                        <div class="col-lg-4">
                            <asp:DropDownList runat="server" ID="ddlSupportPriority" CssClass="form-control text" TabIndex="4">
                                <asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
                                <asp:ListItem Value="Emergency">Emergency</asp:ListItem>
                                <asp:ListItem Value="Critical">Critical</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label"></div>
                        <div class="col-lg-8"></div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Attach File(s)
                        </div>
                        <asp:UpdatePanel runat="server" ID="upFile" UpdateMode="Always">
                            <ContentTemplate>
                                <div class="col-lg-4" id="divAttach" runat="server">
                                    <asp:FileUpload runat="server" ID="fuAttach1" TabIndex="5" /><br />
                                    <asp:FileUpload runat="server" ID="fuAttach2" TabIndex="6" /><br />
                                    <asp:FileUpload runat="server" ID="fuAttach3" TabIndex="7" /><br />
                                    <asp:FileUpload runat="server" ID="fuAttach4" TabIndex="8" /><br />
                                    <asp:FileUpload runat="server" ID="fuAttach5" TabIndex="9" /><br />
                                </div>
                                <div class="col-lg-2">&nbsp;</div>
                                <div class="col-lg-2">
                                    <asp:Button runat="server" ID="btnAddFile" Text="Add More" CssClass="btn-primary" Style="padding: 7px;" OnClick="btnAddFile_Click" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddFile" />
                                <asp:PostBackTrigger ControlID="btnSave" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="panel-body" style="text-align: center">
                <div class="col-lg-12">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" TabIndex="10" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" Text="Save" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlView">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">View Bill Transact Support Ticket</h1>
                <div style="float: right; margin-top: 20px; margin-bottom: 10px;">
                    <asp:Button runat="server" ID="btnClose" Text="Close Ticket" CssClass="btn-warning" Style="padding: 7px;" OnClick="btnClose_Click" />
                    <asp:Button runat="server" ID="btnOpen" Text="Re-Open Ticket" CssClass="btn-warning" Style="padding: 7px;" OnClick="btnOpen_Click" />
                </div>
            </div>
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
                            <asp:Label runat="server" ID="lblStatus" Font-Bold="True"></asp:Label>
                            <br />
                        </td>
                        <td style="width: 33.33%; padding: 15px; border-right: 1px solid #1E9FDE;">
                            <span style="text-transform: uppercase; font-weight: normal">Priority</span>
                            <br />
                            <asp:UpdatePanel runat="server" ID="upEditPriority">
                                <ContentTemplate>
                                    <asp:Label runat="server" ID="lblSupportPriority" Font-Bold="True"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlPriority" Visible="False" Style="color: black" AutoPostBack="True" OnSelectedIndexChanged="ddlPriority_OnSelectedIndexChanged">
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
                <div class="form-horizontal">
                    <%--<div class="form-group">
                        <div class="col-lg-4 control-label">
                            Support Department
                        </div>
                        <div class="col-lg-4" style="padding-top: 7px;">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Status
                        </div>
                        <div class="col-lg-8" style="padding-top: 7px;">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Subject
                        </div>
                        <div class="col-lg-8" style="padding-top: 7px;">
                            
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-1 control-label">
                            Question:
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-lg-8" style="padding-top: 7px;">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4 control-label">
                            Support Priority 
                        </div>
                        <div class="col-lg-4" style="padding-top: 7px;">
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
                                    <div style="padding: 0; text-align: center; width: 100%;">
                                        <asp:Label runat="server" ID="lblEmptyAttach" Text="No Attachment Found..!" Visible='<%# dlAttachment.Items.Count==0 %>' Style="padding: 0; text-align: center; width: 100%;"></asp:Label>
                                    </div>
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
                                <asp:Label runat="server" ID="lblSupportDate1" Text="2015-10-02 15:54:00" Style="font-size: 12px; font-style: italic;"></asp:Label>
                                <hr style="margin: 10px 0;" />
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
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
                                        <span style="padding: 0 15px; display: block; width: 100%">
                                            <%# GetCompanyName(Eval("SupportMessageBy").ToString()) %>
                                        </span>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-lg-8" style="background-color: #FFFFFF; padding-left: 0; padding-right: 0; border: 1px solid #e2e2e2;">
                                        <asp:Label Text='<%# "Posted On: " + Eval("SupportMessageDate") %>' runat="server" ID="SupportMessageDateLabel" Style="font-size: 12px; font-style: italic;" />
                                        <hr style="margin: 10px 0;" />
                                        <asp:Label Text='<%# Eval("SupportMessage") %>' runat="server" ID="SupportMessageLabel" />
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
                        <div class="col-lg-1 control-label">&nbsp;</div>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtDiscussion" TextMode="MultiLine" CssClass="form-control text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12" style="text-align: center;">
                            <asp:Button runat="server" ID="btnSaveDiscussion" Text="Submit" CssClass="btn btn-success" OnClick="btnSaveDiscussion_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">View All Bill Transact Support Ticket
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Support Ticket" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <asp:GridView runat="server" ID="gvSupportTicket" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-striped table-hover" DataKeyNames="DoyinGoSupportTicketID" GridLines="None"
                        OnSelectedIndexChanged="gvSupportTicket_SelectedIndexChanged" OnRowDataBound="gvSupportTicket_RowDataBound"
                        OnPageIndexChanging="gvSupportTicket_PageIndexChanging" DataSourceID="objdsSupportTicket">
                        <Columns>
                            <asp:BoundField DataField="DoyinGoSupportTicketID" HeaderText="ID" ReadOnly="True" SortExpression="DoyinGoSupportTicketID"></asp:BoundField>
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
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Support Ticket Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#0DB9B7" Font-Names="Verdana" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="objdsSupportTicket" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.DoyinGoSupportTicketTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfSupportTicketID" />
</asp:Content>
