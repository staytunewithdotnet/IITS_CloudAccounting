<%@ Page Title="Contractor Master" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ContractorMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ContractorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <script type="text/javascript">
        $(document).ready(function () {
            var p = document.getElementById("peopleDiv");
            p.style.display = 'block';
        });
    </script>
    <style>
        .dropdownLast > option:last-child {
            background-color: #ff9;
        }

        .taskLink {
            color: #00f;
            text-decoration: underline;
        }

            .taskLink:hover {
                background-color: #00f;
                color: #fff;
                text-decoration: none;
            }
    </style>
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-users"></i>
                    <a href="#">People
                    </a>
                </li>
                <li>
                    <a href="EmployeeMaster.aspx">Contractor Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your contractor has been created.</h3>
                <ul style="color: black; font-size: 13px; font-family: Verdana;">
                    <li>
                        <a href="ContractorMaster.aspx?cmd=add" class="permission">Create another contractor</a>
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
                <h3>Your contractor has been updated.</h3>
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
                <h1>New Contractor</h1>
            </div>
            <asp:UpdatePanel runat="server" ID="upContractor">
                <ContentTemplate>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">
                                        <h3 style="margin: 0">Contractor Information</h3>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Email<span style="color: red;">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtContractorEmail" CssClass="form-control text" TabIndex="1" MaxLength="50" AutoPostBack="True" OnTextChanged="txtEmail_OnTextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvContractorEmail" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtContractorEmail" ValidationGroup="ContractorMaster">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email ID" ValidationGroup="ContractorMaster" ControlToValidate="txtContractorEmail" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">
                                        Name
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox runat="server" ID="txtContractorName" CssClass="form-control text" TabIndex="2" MaxLength="50" Style="text-transform: capitalize"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvContractorName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtContractorName" ValidationGroup="ContractorMaster">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel runat="server" ID="upTask">
                                    <ContentTemplate>
                                        <div class="form-group" style="margin-bottom: 0;">
                                            <div class="col-lg-3 control-label">
                                                Task<span style="color: red;">*</span>
                                            </div>
                                            <div class="col-lg-4" style="padding-right: 0;" id="taskDropdown" runat="server">
                                                <asp:DropDownList runat="server" ID="ddlTask" CssClass="form-control text dropdownLast" TabIndex="3" DataSourceID="sqldsTask" DataTextField="TaskName" DataValueField="TaskID" AutoPostBack="True" OnSelectedIndexChanged="ddlTask_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvTaskDrop" InitialValue="-1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="ddlTask" ValidationGroup="ContractorMaster">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div id="taskTextbox" runat="server" visible="False">
                                                <div class="col-lg-4" style="padding-right: 0;">
                                                    <asp:TextBox runat="server" ID="txtTask" CssClass="form-control text"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTaskText" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtTask" ValidationGroup="ContractorMaster">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-lg-1" style="padding-left: 0; padding-right: 0; width: 3%; margin-top: 7px;">
                                                    or
                                                </div>
                                                <div class="col-lg-4" style="padding-left: 0; margin-top: 7px;">
                                                    <asp:LinkButton runat="server" ID="lnkPick" CssClass="taskLink" Text="pick an existing task" OnClick="lnkPick_OnClick"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">Contractor hours are filed under a single task, e.g. "Contracting" or "Web Design"</div>
                                </div>
                                <div class="form-group" style="margin-bottom: 0;">
                                    <div class="col-lg-3 control-label">
                                        Rebill Rate:
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" ID="txtRebillRate" Text="0.00" CssClass="form-control text" onkeypress="return decimalValue(this,event);" Style="width: 50% !important" TabIndex="4"></asp:TextBox>&nbsp;N. per hour
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-3 control-label">&nbsp;</div>
                                    <div class="col-lg-9">The rate your client will be charged for this person's time.</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

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
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center;">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Save" ValidationGroup="ContractorMaster" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" Text="Save" ValidationGroup="ContractorMaster" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView" Style="color: black">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1 style="display: inline-block">
                    <asp:Label runat="server" ID="lblContractorName" Style="text-transform: capitalize"></asp:Label>
                </h1>
                <div style="float: right; margin-top: 20px; margin-bottom: 10px;">
                    <asp:Button runat="server" ID="btnEdit" CssClass="btn-primary" Text="Edit Contractor" Style="padding: 10px;" OnClick="btnEdit_Click" />
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                    <div class="col-lg-12 rounded-container peel-shadows" style="padding-top: 25px;">
                        <div class="form-group col-lg-2" style="padding-left: 0;">
                            <div class="contractor-icon-large bg-system-light" style="margin-left: 5px;">
                            </div>
                        </div>

                        <div class="col-lg-9">
                            <div class="col-lg-12 form-horizontal">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblContractorName1" Style="text-transform: capitalize; font-weight: bold; font-family: Arial,Helvetica,sans-serif;"></asp:Label>
                                    <br />
                                    <div class="col-lg-1">
                                        <i class="fa fa-envelope" style="font-size: 15px; color: gray; margin: 0 10px 0 3px;"></i>
                                    </div>
                                    <div class="col-lg-10">
                                        <asp:Label runat="server" ID="lblContractorEmail"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <span style="font-weight: bold">Billing Rate:
                                    </span>
                                    <asp:Label runat="server" ID="lblRebillRate" Text="0.00"></asp:Label>/ hour
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="col-lg-12 rounded-container peel-shadows bg_systemcolor1" style="padding: 0;">
                        <asp:DataList runat="server" ID="dlProjectsView" DataKeyField="ProjectID" DataSourceID="sqldsProjectView" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%">
                            <ItemTemplate>
                                <div class="col-lg-12" style="border-bottom: 1px solid #ffffff; border-bottom: 1px solid rgba(255,255,255,0.25); padding: 15px;">
                                    <asp:Label Text='<%# Eval("ProjectID") %>' runat="server" ID="ProjectIDLabel" Visible="False" /><br />
                                    <asp:Label Text='<%# Eval("ProjectName") %>' runat="server" ID="ProjectNameLabel" Style="font-family: Arial,Helvetica,sans-serif; font-size: 16px; font-weight: bold;" /><br />
                                    <br />
                                    <div class="col-lg-6">
                                        <h2 style="margin-top: 10px; margin-bottom: 0; font-size: 44px; font-weight: bold; font-family: Arial,sans-serif;">0.0 hrs</h2>
                                        <span>unbilled</span>
                                    </div>
                                    <div class="col-lg-3" style="padding-left: 0; padding-right: 2.5px; top: 10px;">
                                        <h4 style="margin-top: 10px; margin-bottom: 0; font-size: 30px; font-family: Arial,sans-serif;">0.0 hrs</h4>
                                        <span>billed</span>
                                    </div>
                                    <div class="col-lg-3" style="padding-right: 0; padding-left: 2.5px; top: 10px;">
                                        <h4 style="margin-top: 10px; margin-bottom: 0; font-size: 30px; font-family: Arial,sans-serif;">0.0 hrs</h4>
                                        <span>total</span>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <SeparatorTemplate>
                            </SeparatorTemplate>
                            <FooterTemplate>
                                <div style="padding: 15px 10px;">
                                    <asp:Label Visible='<%#bool.Parse((dlProjectsView.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No Project(s) assigned to this contractor" Style="font-size: large; font-weight: bold; padding: 15px;"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource runat="server" ID="sqldsProjectView" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT ProjectMaster.ProjectID, ProjectMaster.ProjectName FROM ProjectMaster INNER JOIN ContractorProjectDetail ON ProjectMaster.ProjectID = ContractorProjectDetail.ProjectID WHERE (ProjectMaster.CompanyID = @CompanyID) AND (ContractorProjectDetail.ContractorID = @ContractorID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="hfContractorID" PropertyName="Value" DefaultValue="0" Name="ContractorID"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>

                <div class="col-lg-4" style="padding-right: 0;">
                    <div class="col-lg-12 rounded-container" style="padding: 15px; margin-bottom: 0;">
                        <h5 style="font-family: Arial,Helvetica,sans-serif; font-weight: bold;">Contractor’s Task</h5>
                        <br />
                        <asp:Label runat="server" ID="lblTask" Style="background-color: #ff9" Text="task"></asp:Label>
                        (<asp:LinkButton runat="server" CssClass="permission" Text="change" OnClick="btnEdit_Click"></asp:LinkButton>)
                    <br />
                        <br />
                        <span style="color: #888; font-size: 11px; line-height: 16px;">All hours logged by this contractor will be represented by this task.
                        </span>
                    </div>
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
                <h1>New Contractor</h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">&nbsp;</div>
                            <div class="col-lg-9">
                                <h3 style="margin: 0">Contractor Information</h3>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Contractor Name:
                            </div>
                            <div class="col-lg-6">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Contractor Email:
                            </div>
                            <div class="col-lg-4">
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Task:
                            </div>
                            <div class="col-lg-6">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Rebill Rate:
                            </div>
                            <div class="col-lg-3">
                                N. per hour
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-header" style="border-bottom: 5px solid #eee; margin-top: 0;"></div>

            <div class="col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3 control-label">&nbsp;</div>
                        <div class="col-lg-9">
                            <h3 style="margin: 0">Assign to Projects</h3>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>


        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">Contractors </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Contractor" OnClick="btnAdd_Click" Style="float: right;" />
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <asp:GridView runat="server" ID="gvContractor" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="50" CssClass="table table-bordered table-hover" DataSourceID="objdsContractor" DataKeyNames="ContractorID"
                        AllowSorting="True" OnSorting="gvContractor_Sorting" OnSelectedIndexChanged="gvContractor_SelectedIndexChanged"
                        OnPageIndexChanging="gvContractor_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ContractorID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ContractorID"></asp:BoundField>
                            <asp:BoundField DataField="ContractorName" HeaderText="Contractor Name" SortExpression="ContractorName"></asp:BoundField>
                            <asp:BoundField DataField="RebillRate" HeaderText="Rate (N.)" SortExpression="RebillRate" DataFormatString="{0:0.00}"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center; width: 100%;">
                                No Records Found
                            </div>
                        </EmptyDataTemplate>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#DCDCDC" Font-Names="Verdana" Font-Size="15px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#DCDCDC" ForeColor="White" />
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="objdsContractor" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyID" TypeName="DABL.DAL.CloudAccountDATableAdapters.ContractorMasterTableAdapter">
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
    <asp:HiddenField runat="server" ID="hfContractorID" />
    <asp:SqlDataSource runat="server" ID="sqldsTask" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaskID, '-select a task-' AS TaskName UNION SELECT [TaskID], [TaskName] FROM [TaskMaster] WHERE (([CompanyID] = @CompanyID) AND ([Active] = @Active)) UNION SELECT 99999999 AS TaskID, '[new task]' AS TaskName">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
            <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
