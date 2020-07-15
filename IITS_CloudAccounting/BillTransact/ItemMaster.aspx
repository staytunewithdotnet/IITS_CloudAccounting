<%@ Page Title="Item Master" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="ItemMaster.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ItemMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../App_Themes/Doyingo/css/modern.min.css" rel="stylesheet" />--%>
    <script src="../App_Themes/Doyingo/js/searchBox.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var i = document.getElementById("invoiceDiv");
            i.style.display = 'block';
        });
    </script>
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <div class="row">
        <div class="col-sm-12">
            <ol class="breadcrumb">
                <li>
                    <i class="fa fa-file"></i>
                    <a href="#">Invoices
                    </a>
                </li>
                <li>
                    <a href="ItemMaster.aspx">Item Master</a>
                </li>
            </ol>
        </div>
    </div>

    <div id="divSave" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Your item has been created.</h3>
                <p class="hide"></p>
            </div>
        </div>
        <div class="col-lg-3">&nbsp;</div>
    </div>
    <div id="divUpdate" runat="server" visible="False">
        <div class="col-lg-3">&nbsp;</div>
        <div class="col-lg-6">
            <div class="notification-page notification-success">
                <h3>Nice work - your item has been updated.</h3>
                <ul style="color: black; font-size: 13px; font-family: Verdana;">
                    <li>Click here to <a href="InvoiceMasterNew.aspx" class="permission">create a new invoice</a>.
                    </li>
                    <li>Click here to <a href="EstimateMaster.aspx" class="permission">create a new estimate</a>.
                    </li>
                </ul>
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
                <h1>New Item </h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Item Name<span style="color: red">*</span>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox runat="server" ID="txtItemName" CssClass="form-control text" TabIndex="1" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvItemName" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ControlToValidate="txtItemName" ValidationGroup="ItemMaster">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Description
                            </div>
                            <div class="col-lg-6">
                                <asp:TextBox runat="server" ID="txtItemDesc" TextMode="MultiLine" CssClass="form-control text" TabIndex="2" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Unit Cost
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox runat="server" ID="txtUnitCost" CssClass="form-control text" TabIndex="3" MaxLength="50" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Quantity
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox runat="server" ID="txtQuantity" Text="1" CssClass="form-control text" TabIndex="4" MaxLength="50" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Tax
                            </div>
                            <div class="col-lg-2" style="padding-right: 1px;">
                                <asp:DropDownList runat="server" ID="ddlTax" CssClass="form-control text" TabIndex="5" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID">
                                </asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="sqldsTax" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT -1 AS TaxID, '---' AS TaxName UNION SELECT [TaxID], [TaxName] FROM [TaxMaster] WHERE ([CompanyID] = @CompanyID)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div class="col-lg-2" style="padding-left: 1px;">
                                <asp:DropDownList runat="server" ID="ddlTax2" CssClass="form-control text" TabIndex="6" DataSourceID="sqldsTax" DataTextField="TaxName" DataValueField="TaxID">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Track Inventory
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:UpdatePanel runat="server" ID="upChk">
                                    <ContentTemplate>
                                        <asp:CheckBox runat="server" ID="chkInventory" TabIndex="7" OnCheckedChanged="chkInventory_CheckedChanged" AutoPostBack="True" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <asp:UpdatePanel runat="server" ID="upInventory">
                    <ContentTemplate>
                        <div id="stock" runat="server" visible="False">
                            <div class="page-header" style="border-bottom: 5px solid #eee; margin-top: 0;"></div>

                            <div class="col-lg-12">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">&nbsp;</div>
                                        <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                            <h3 style="margin: 0">Tracking your Inventory</h3>
                                            <span>Add the quantity of items you currently have in stock. This number will decrease every time the product is added to an invoice. When you receive more inventory, simply add it to your current inventory here.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label">
                                            Current Stock:
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:TextBox runat="server" ID="txtCurrentStock" TabIndex="8" CssClass="form-control" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" TabIndex="9" Text="Save" ValidationGroup="ItemMaster" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-primary" TabIndex="10" Text="Save" ValidationGroup="ItemMaster" OnClick="btnUpdate_Click" />
                    <asp:Button runat="server" ID="btnSaveAdd" CssClass="btn btn-red" TabIndex="11" Text="Save and Add Another" ValidationGroup="ItemMaster" Style="width: 30%" OnClick="btnSaveAdd_Click" />
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlView">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>New Item </h1>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Item Name<span style="color: red">*</span>
                            </div>
                            <div class="col-lg-6">
                                <asp:Label runat="server" ID="lblItemName"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Description
                            </div>
                            <div class="col-lg-7">
                                <asp:Label runat="server" ID="lblItemDesc"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Unit Cost:
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblUnitCost"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Quantity:
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblQuantity" Text="1"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Tax:
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblTax">
                                </asp:Label>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label runat="server" ID="lblTax2">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-3 control-label">
                                Track Inventory:
                            </div>
                            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                <asp:Label runat="server" ID="lblInventory" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div id="stockEdit" runat="server">
                    <div class="page-header" style="border-bottom: 5px solid #eee; margin-top: 0;"></div>
                    <div class="col-lg-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-3 control-label">&nbsp;</div>
                                <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                                    <h3 style="margin: 0">Tracking your Inventory</h3>
                                    <span>Add the quantity of items you currently have in stock. This number will decrease every time the product is added to an invoice. When you receive more inventory, simply add it to your current inventory here.
                                    </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-3 control-label">
                                    Current Stock:
                                </div>
                                <div class="col-lg-2">
                                    <asp:Label runat="server" ID="lblCurrentStock"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-12" style="text-align: center">
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlViewAll">
            <div class="page-header" style="border-bottom: 5px solid #eee; margin: 0; display: inline-block; width: 100%; padding: 2%;">
                <h1 style="display: inline-block; margin: 0;">
                    <asp:Label runat="server" ID="lblHeader"></asp:Label>
                </h1>
                <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-success" Text="New Item" OnClick="btnAdd_Click" Style="float: right;" />
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
                                        Item Name
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtItemNameSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Item Desc
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:TextBox runat="server" ID="txtItemDescSearch" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Tax
                                    </div>
                                    <div class="col-lg-7">
                                        <asp:DropDownList runat="server" ID="ddlTaxSearch" CssClass="searchText" DataSourceID="sqldsTaxSearch" DataTextField="TaxName" DataValueField="TaxName" />
                                        <asp:SqlDataSource runat="server" ID="sqldsTaxSearch" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '' AS TaxName UNION SELECT TaxName from TaxMaster WHERE [CompanyID] = @CompanyID">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Unit Cost
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtUnitCostFrom" CssClass="searchText"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtUnitCostTo" CssClass="searchText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Inventory
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtInventoryFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtInventoryTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-5" style="text-align: right">
                                        Quantity
                                    </div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtQuantityFrom" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-1" style="padding: 0">to</div>
                                    <div class="col-lg-3" style="padding: 0">
                                        <asp:TextBox runat="server" ID="txtQuantityTo" CssClass="searchText" onkeypress="return decimalValue(this,event);"></asp:TextBox>
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
                        <asp:Button runat="server" ID="btnUnDelete" CssClass="btn-danger" Text="Un-delete" OnClick="btnUnDelete_Click" Style="padding: 5px;" />
                        <asp:Button runat="server" ID="btnArchived" CssClass="btn-info" Text="Archived" OnClick="btnArchived_Click" Style="padding: 5px;" />
                        <asp:Button runat="server" ID="btnUnArchived" CssClass="btn-info" Text="Un-archived" OnClick="btnUnArchived_Click" Style="padding: 5px;" />
                        <asp:Button runat="server" ID="btnDelete" CssClass="btn-danger" Text="Delete" OnClick="btnDelete_Click" Style="padding: 5px;" />
                        <a id="aSearch" class="btn-info" style="display: block; padding: 5px; cursor: pointer; text-decoration: none; float: right;"><i class="fa fa-search" style="padding: 5px 10px 5px 0;"></i>Search</a>
                    </div>
                    <asp:GridView runat="server" ID="gvItem" Width="100%" Font-Size="Small" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-hover" DataSourceID="objdsItem" DataKeyNames="ItemID"
                        AllowSorting="True" OnSorting="gvItem_Sorting" GridLines="None" OnPageIndexChanging="gvItem_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkID" ToolTip='<%#Eval("ItemID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName"></asp:BoundField>
                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDescription" Text='<%# SetDescriptionLimit(Eval("Description").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inventory" SortExpression="CurrentStock">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblBillToClient" Text='<%# bool.Parse(Eval("TrackInventory").ToString()) ?Eval("CurrentStock"):"---" %>' Style='<%# "color:" + GetColor(Eval("CurrentStock").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost (N.)" SortExpression="UnitCost" DataFormatString="{0:0.00}"></asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Qty" SortExpression="Quantity"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkEdit" Text="edit" Visible='<%# !bool.Parse(Eval("Deleted").ToString()) %>' CommandArgument='<%# Eval("ItemID") %>' OnClick="lnkEdit_OnClick"></asp:LinkButton>
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
                        <a id="activeTag" runat="server" href="ItemMaster.aspx">active</a>
                        &nbsp; | &nbsp;
                        <a id="archivedTag" runat="server" href="ItemMaster.aspx?ar=true&ac=false">archived</a>
                        &nbsp; | &nbsp;
                        <a id="deletedTag" runat="server" href="ItemMaster.aspx?de=true&ac=false">deleted</a>
                        <div>&nbsp;</div>
                    </div>
                    <asp:ObjectDataSource runat="server" ID="objdsItem" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCompanyIDAndStatus" TypeName="DABL.DAL.CloudAccountDATableAdapters.ItemMasterTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfCompanyID" PropertyName="Value" DefaultValue="0" Name="CompanyID" Type="Int32"></asp:ControlParameter>
                            <asp:QueryStringParameter QueryStringField="ac" DefaultValue="true" Type="Boolean" Name="Active" />
                            <asp:QueryStringParameter QueryStringField="ar" DefaultValue="false" Type="Boolean" Name="Archived" />
                            <asp:QueryStringParameter QueryStringField="de" DefaultValue="false" Type="Boolean" Name="Deleted" />
                            <asp:ControlParameter ControlID="txtItemNameSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemName" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtItemDescSearch" PropertyName="Text" ConvertEmptyStringToNull="True" Name="ItemDesc" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="ddlTaxSearch" PropertyName="SelectedValue" ConvertEmptyStringToNull="True" Name="Tax" Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtUnitCostFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="UnitCostFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtUnitCostTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="UnitCostTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtInventoryFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InvetoryFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtInventoryTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="InvetoryTo" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtQuantityFrom" PropertyName="Text" ConvertEmptyStringToNull="True" Name="QuantityFrom" Type="Decimal"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="txtQuantityTo" PropertyName="Text" ConvertEmptyStringToNull="True" Name="QuantityTo" Type="Decimal"></asp:ControlParameter>
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
    <asp:HiddenField runat="server" ID="hfItemID" />

</asp:Content>
