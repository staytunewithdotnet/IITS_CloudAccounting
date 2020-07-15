<%@ Page Title="Task Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="TaskMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.TaskMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var tt = document.getElementById("timeTrackingDiv");
            tt.style.display = 'block';
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#billDiv').show();
            $('#<%=chkBill.ClientID%>').prop('checked', true);
            $('#<%=chkBill.ClientID%>').change(function () {
                if ($(this).is(":checked")) {
                    $('#billDiv').show();
                } else {
                    $('#billDiv').hide();
                }
            });
        });

    </script>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file-excel-o"></i>
                    <a href="#">Time Tracking
                    </a>
                </li>
                <li>
                    <a href="TaskMaster.aspx">Task Master</a>
                </li>
            </ol>
        </div>
    </div>
    
    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your task has been created.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your task has been updated.</h3>
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
                <h1>New Task </h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Task Name<span style="color: red">*</span>
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtTaskName" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvTask" ControlToValidate="txtTaskName" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationGroup="TaskMaster">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Description
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:TextBox runat="server" ID="txtTaskDesc" TextMode="MultiLine" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Bill to client
                            </div>
                            <div class="col-lg-1" style="margin-top: 7px;">
                                <asp:CheckBox runat="server" ID="chkBill" Checked="True" />
                            </div>
                            <div class="col-lg-5" id="billDiv" style="display: block;">
                                Rate per hour
                                <asp:TextBox runat="server" ID="txtBillClient" Text="0.00" CssClass="form-control text" TabIndex="4" Style="width: 50% !important;"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Save" ValidationGroup="TaskMaster" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" Text="Save" ValidationGroup="TaskMaster" OnClick="btnUpdate_Click" />
                    <asp:Button runat="server" ID="btnSaveAdd" CssClass="btn btn-red" Text="Save and Add Another" ValidationGroup="TaskMaster" Style="width: 30%" OnClick="btnSaveAdd_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>New Task </h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Task Name
                            </div>
                            <div class="col-lg-6">
                                <asp:Label runat="server" ID="lblTaskName" CssClass="form-control text" TabIndex="1"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Description
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:Label runat="server" ID="lblTaskDesc" TextMode="MultiLine" CssClass="form-control text" TabIndex="2"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Bill to client
                            </div>
                            <div class="col-lg-1" style="margin-top: 7px;">
                                <asp:Label runat="server" ID="lblBill" />
                            </div>
                            <div class="col-lg-5" id="billDivEdit" style="display: block;">
                                Rate per hour
                                <asp:Label runat="server" ID="lblBillClient" Text="0.00"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label> 
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Task" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body" style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                    <div style="background-color: lightgray; padding: 10px;">
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" />
                    </div>
                    <asp:GridView runat="server" ID="gvTask" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-hover" DataSourceID="objdsTask" DataKeyNames="TaskID"
                        AllowSorting="True" OnSorting="gvTask_Sorting" GridLines="None" OnPageIndexChanging="gvTask_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("TaskID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TaskName" HeaderText="Task Name" SortExpression="TaskName"></asp:BoundField>
                            <asp:TemplateField HeaderText="Description" SortExpression="TaskDesc">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDescription" Text='<%# SetDescriptionLimit(Eval("TaskDesc").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Billable?" SortExpression="BillToClient">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBillToClient" Text='<%# bool.Parse(Eval("BillToClient").ToString())?"Yes":"No" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RatePerHours" HeaderText="Rate (N.)" SortExpression="RatePerHours" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="edit" Visible='<%# !bool.Parse(Eval("Deleted").ToString()) %>' CommandArgument='<%# Eval("TaskID") %>' OnClick="lnkEdit_OnClick"></asp:LinkButton>
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
                        <a id="activeTag" runat="server" href="TaskMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="TaskMaster.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="TaskMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsTask" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.TaskMasterTableAdapter">
                         <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
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
    <asp:HiddenField runat="server" ID="hfTaskID" />
</asp:Content>
