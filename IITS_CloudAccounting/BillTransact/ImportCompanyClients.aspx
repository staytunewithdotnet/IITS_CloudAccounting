<%@ Page Title="Import Company Clients" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="ImportCompanyClients.aspx.cs" Inherits="IITS_CloudAccounting.Admin.ImportCompanyClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var d = document.getElementById("accountDiv");
            d.style.display = 'block';
        });
    </script>
    <style>
        .gridTableNew.table > tbody > tr > th {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: middle;
        }

        .gridTableNew.table > tbody > tr :first-child > td > table.gridTableNew.table {
            margin: 0;
        }

        .gridTableNew.table > tbody > tr :first-child > td {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: middle;
        }

            .gridTableNew.table > tbody > tr:first-child > td:first-child {
                border: 0;
                padding: 0 !important;
            }

        .gridTableNew.table > tbody > tr > td {
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
                    <a href="#">My Account
                    </a>
                </li>
                <li>
                    <a href="ImportCompanyClients.aspx">Import Clients</a>
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
            </ul>
        </div>
        <div class="col-lg-2">&nbsp;</div>
        <div class="clearfix"></div>
        <asp:Panel runat="server" ID="pnlCsv">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>Import Clients from CSV</h1>
                <h6>Have a lot of clients? Don't enter them all manually, import them.</h6>
            </div>
            <div class="panel-body" style="padding: 0;">
                <asp:MultiView runat="server" ID="mvCsv">
                    <asp:View runat="server" ID="csvFile">
                        <div class="col-lg-9" style="padding-left: 0; padding-right: 0;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <h3>Step 1: Upload your CSV file</h3>
                                        <p>
                                            To import your clients into your Bill Transact account, you must first export a Bill Transact or Outlook-compatible CSV file. Then select your exported file with the button below, and click "Upload". 
                                            <asp:LinkButton runat="server" Text=" See a sample " CssClass="permission" ID="lnkDownload" OnClick="lnkDownload_OnClick"></asp:LinkButton>
                                             of how to format your file for importing.
                                        </p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center">
                                        <b>Import file: </b>
                                        <asp:FileUpload ID="fuCsv" runat="server" Style="display: inline-block;" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center">
                                        <asp:Button runat="server" ID="btnUploadCsv" CssClass="btn btn-success" Text="Upload" OnClick="btnUploadCsv_OnClick" />
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
                                        <h3>Step 2: Review and select your clients
                                        </h3>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="gvCsvClient" runat="server" GridLines="None" AutoGenerateColumns="False" 
                                            CssClass="gridTableNew table table-striped table-responsive" OnRowDataBound="gvCsvClient_OnRowDataBound">
                                            <EmptyDataTemplate>
                                                <div class="panel-danger" style="text-align: center; width: 100%;">
                                                    No Clients Found
                                                </div>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chk" Checked="True" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Organization" DataField="Organization" />
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblFirstName" ></asp:Label>
                                                        <asp:Label runat="server" ID="lblLastName" ></asp:Label>
                                                        <asp:HiddenField runat="server" ID="hfStreet"/>
                                                        <asp:HiddenField runat="server" ID="hfStreet2"/>
                                                        <asp:HiddenField runat="server" ID="hfSecStreet"/>
                                                        <asp:HiddenField runat="server" ID="hfSecStreet2"/>
                                                        <asp:HiddenField runat="server" ID="hfBusPhone"/>
                                                        <asp:HiddenField runat="server" ID="hfHomePhone"/>
                                                        <asp:HiddenField runat="server" ID="hfMobPhone"/>
                                                        <asp:HiddenField runat="server" ID="hfFax"/>
                                                        <asp:HiddenField runat="server" ID="hfNotes"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center;">
                                        <asp:Button runat="server" ID="btnUploadCsvClient" Text="Import Clients" CssClass="btn btn-success" OnClick="btnUploadCsvClient_OnClick" />
                                        <asp:Button runat="server" ID="btnCancelCsv" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancelCsv_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlvCard">
            <div class="page-header" style="border-bottom: 5px solid #eee;">
                <h1>Import Clients from vCard</h1>
                <h6>Have a lot of clients? Don't enter them all manually, import them.</h6>
            </div>

            <div class="panel-body" style="padding: 0;">
                <asp:MultiView runat="server" ID="mvvCard">
                    <asp:View runat="server" ID="vCardFile">
                        <div class="col-lg-9" style="padding-left: 0; padding-right: 0;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <h3>Step 1: Upload your vCard file</h3>
                                        <p>
                                            To import your clients from your address book into your Bill Transact account, you need to export them as a vCard file. Select your exported file with the button below, and click "Upload".
                                        </p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center">
                                        <b>Import file: </b>
                                        <asp:FileUpload ID="fuvCard" runat="server" Style="display: inline-block;" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="text-align: center">
                                        <asp:Button runat="server" ID="btnUploadvCard" CssClass="btn btn-success" Text="Upload" OnClick="btnUploadvCard_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="vCardGrid">
                        <div class="col-lg-12" style="padding-left: 0; padding-right: 0;">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <h3>Step 2: Review and select your clients
                                        </h3>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding: 0;">
                                            Organization: 
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:Label runat="server" ID="lblOrganization"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding: 0;">
                                            Name: 
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:Label runat="server" ID="lblName"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding: 0;">
                                            Email: 
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-3 control-label" style="padding: 0;">
                                            Want To Import?
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:CheckBox runat="server" ID="chkImport" Checked="True" />
                                            <asp:HiddenField runat="server" ID="hfMobile" />
                                            <asp:HiddenField runat="server" ID="hfHome" />
                                            <asp:HiddenField runat="server" ID="hfWork" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12" style="text-align: center">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <asp:Button runat="server" ID="btnUploadvCardClient" Text="Import Clients" CssClass="btn btn-success" OnClick="btnUploadvCardClient_OnClick" />
                                        <asp:Button runat="server" ID="btnCancelvCard" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancelvCard_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </asp:Panel>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <asp:HiddenField runat="server" ID="hfCompanyID" />
    <asp:HiddenField runat="server" ID="hfCompanyName" />
    <asp:HiddenField runat="server" ID="hfStaffID" />
</asp:Content>
