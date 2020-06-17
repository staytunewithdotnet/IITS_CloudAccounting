<%@ Page Title="Import Expenses" Language="C#" MasterPageFile="~/Admin/Doyingo.Master" AutoEventWireup="true" CodeBehind="ImportExpense.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ImportExpense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("expensesDiv");
            d.style.display = 'block';
        });
    </script>
    <style>
        .gridTableNew.tablex > tbody > tr > th {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: middle;
        }

        .gridTableNew.tablex > tbody > tr :first-child > td > table.gridTableNew.tablex {
            margin: 0;
        }

        .gridTableNew.tablex > tbody > tr :first-child > td {
            /*background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;*/
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: middle;
        }

            .gridTableNew.tablex > tbody > tr:first-child > td:first-child {
                border: 0;
                padding: 0 !important;
            }

        .gridTableNew.tablex > tbody > tr > td {
            font-weight: normal;
            line-height: 15px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: middle;
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
                    <a href="ImportExpense.aspx">Import Expenses</a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="col-lg-2">&nbsp;</div>
        <div class="col-lg-8 notification-page notification-error" runat="server" id="divError" visible="False">
            <h3>Please correct the following:</h3>
            <p class="hide"></p>
            <ul>
                <li>
                    <asp:Label runat="server" ID="lblError"></asp:Label>
                </li>
                <li>Are your expenses formatted like
                    <asp:LinkButton runat="server" ID="lnkDownloadFile" CssClass="permission" OnClick="lnkDownload_OnClick">this file?</asp:LinkButton></li>
                <li>Did you choose the correct "Amount Format" option?</li>
            </ul>
        </div>
        <div class="col-lg-2">&nbsp;</div>
        <div class="clearfix"></div>
        <div class="page-header">
            <h1>Import Expenses from a File</h1>
            <p style="text-align: justify">
                You can import your expenses from a comma separated text (.CSV) file which are provided by most financial institutions.
            </p>
            <p>
                The text file should contain columns for date, vendor, category, notes and amount. The text file should not be more than 500 rows.
                <asp:LinkButton runat="server" ID="lnkDownload" CssClass="permission" OnClick="lnkDownload_OnClick">See a sample</asp:LinkButton>
                of how to format your file for importing.
            </p>
        </div>
        <div class="panel-body" style="padding: 0;">
            <asp:MultiView runat="server" ID="mvCsv">
                <asp:View runat="server" ID="csvFile">
                    <div class="col-lg-9" style="padding-left: 0; padding-right: 0;">
                        <div class="form-horizontal">
                            <div class="form-group">
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center">
                                    <b style="width: 30%; display: inline-block; text-align: right;">Select Your File: <span style="color: red">*</span> </b>
                                    <span style="width: 5%">&nbsp;</span>
                                    <asp:FileUpload ID="fuCsv" runat="server" Style="width: 50% !important; display: inline-block;" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center">
                                    <b style="width: 30%; display: inline-block; text-align: right;">File Type </b>
                                    <span style="width: 5%">&nbsp;</span>
                                    <select name="file_type" class="form-control text" style="width: 50% !important; display: inline-block;">
                                        <option value="csv">CSV (Comma separated file)</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center">
                                    <b style="width: 30%; display: inline-block; text-align: right;">Date Format </b>
                                    <span style="width: 5%">&nbsp;</span>
                                    <asp:DropDownList runat="server" ID="ddlDateFormat" CssClass="form-control text" Style="width: 50% !important; display: inline-block;">
                                        <asp:ListItem Value="0">mm/dd/yy</asp:ListItem>
                                        <asp:ListItem Value="1">mm/dd/yyyy</asp:ListItem>
                                        <asp:ListItem Value="2">dd/mm/yy</asp:ListItem>
                                        <asp:ListItem Value="3">dd/mm/yyyy</asp:ListItem>
                                        <asp:ListItem Value="4">yy-mm-dd</asp:ListItem>
                                        <asp:ListItem Value="5">yyyy-mm-dd</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center">
                                    <b style="width: 30%; display: inline-block; text-align: right;">Amount Format </b>
                                    <span style="width: 5%">&nbsp;</span>
                                    <asp:DropDownList runat="server" ID="ddlAmountFormat" CssClass="form-control text" Style="width: 50% !important; display: inline-block;">
                                        <asp:ListItem Value="-">Negative</asp:ListItem>
                                        <asp:ListItem Value="+">Positive</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center">
                                    <asp:Button runat="server" ID="btnUploadCsv" CssClass="btn btn-success" Text="Upload File" OnClick="btnUploadCsv_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="csvGrid">
                    <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <asp:GridView ID="gvCsvExpence" runat="server" GridLines="None" AutoGenerateColumns="False"
                                        CssClass="gridTableNew tablex table-striped table-responsive" OnRowDataBound="gvCsvExpence_OnRowDataBound">
                                        <EmptyDataTemplate>
                                            <div class="panel-danger" style="text-align: center; width: 100%;">
                                                No Expenses Found
                                            </div>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chk" Checked="True" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control text" onkeypress="return decimalValue(this,event);"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control text"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender runat="server" ID="ceDate" TargetControlID="txtDate" Format="MM/dd/yyyy" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vendor">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtVendor" CssClass="form-control text"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control text" DataSourceID="sqldsCategory" DataTextField="SubCategoryName" DataValueField="SubCategoryID" />
                                                    <asp:SqlDataSource runat="server" ID="sqldsCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '[choose one]' AS SubCategoryName,-2 AS SubCategoryID UNION SELECT CategoryName + ' > ' + SubCategoryName,SubCategoryID FROM SubCategoryMaster a INNER JOIN CategoryMaster b ON a.CategoryID = b.CategoryID"></asp:SqlDataSource>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Notes">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control text"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="text-align: center;">
                                    <asp:Button runat="server" ID="btnUploadCsvExpence" Text="Import Expenses" CssClass="btn btn-success" OnClick="btnUploadCsvExpence_OnClick" />
                                    <asp:Button runat="server" ID="btnCancelCsv" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancelCsv_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyName" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
</asp:Content>
