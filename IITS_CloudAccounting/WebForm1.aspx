<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IITS_CloudAccounting.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testing Page</title>
    <link href="App_Themes/Doyingo/css/invoicing.css" rel="stylesheet" />
    <style>
        .gridTableNew.table > tbody > tr > th {
            background-color: #0D83DE;
            border: none;
            color: #ffffff;
            font-weight: normal;
            line-height: 18px;
            padding: 5px 5px !important;
            text-align: center;
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
            text-align: center;
            vertical-align: middle;
        }

            .gridTableNew.table > tbody > tr:first-child > td:first-child {
                border: 0;
                padding: 0 !important;
            }

        /*.gridTableNew.table > tbody > tr > td:first-child {
            border-left: 1px solid #e5e5e5;
        }*/

        .gridTableNew.table > tbody > tr > td {
            /*border-bottom: 1px solid #e5e5e5;
            border-right: 1px solid #e5e5e5;*/
            font-weight: normal;
            line-height: 15px;
            padding: 5px 5px !important;
            text-align: left;
            vertical-align: top;
        }

        .linkbutton {
            background-color: lightgray;
            border-radius: 5px;
            color: black;
            padding: 3px;
            text-decoration: none;
        }

            .linkbutton:hover {
                background-color: lightgray !important;
                color: black !important;
                text-decoration: none !important;
            }

        .myGridTable.table > tbody > tr > td {
            background-color: white;
            border: none;
        }

        .myGridTable.table > tbody > tr > th {
            background-color: #0D83DE;
            color: #ffffff;
            font-weight: normal;
            padding: 5px 5px !important;
            line-height: 18px;
            border: none;
        }

        .myGridTable.table > tbody > tr:hover td {
            background-color: #e4f4fe!important;
        }

        .myGridTable.table > tbody > tr > td:nth-last-child(2), .myGridTable.table > tbody > tr > th:nth-last-child(2) {
            text-align: right;
        }

        .myGridTable.table > tbody > tr > td:last-child, .myGridTable.table > tbody > tr > th:last-child {
            text-align: center;
        }

        .myGridTable.table > tbody > tr > td {
            text-align: left;
            font-weight: normal;
            padding: 5px 5px !important;
            font-family: Verdana,sans-serif;
            font-size: 12px;
            line-height: 18px;
            color: #000;
            border-top: 1px solid #e2e2e2;
            word-wrap: break-word;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtValue" Text="000009"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btnValue" Text="Click" OnClick="BtnValueClick" />
        </div>
        <div>
            <asp:Label runat="server" ID="lblNextValue"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td>Select File</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label runat="server" ID="lblMessage"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="gridTableNew table table-striped table-responsive">
            <EmptyDataTemplate>
                <div class="panel-danger" style="text-align: center; width: 100%;">
                    No Records Found
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chk" Checked="True" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        dynamic add rows in gridview
        <div id="divSP" style="display: none">
            <p>
                CREATE PROCEDURE [dbo].[PR_FreePackageSettings_Insert]<br />
                @FreePackageSettingID                        int	OUTPUT,<br />
                @FreePackageDays                             int<br />
                <br />
                AS<br />
                <br />
                SET NOCOUNT ON<br />
                <br />
                INSERT [dbo].[FreePackageSettings]<br />
                (<br />
                [FreePackageDays]<br />
                )<br />
                VALUES<br />
                (<br />
                @FreePackageDays<br />
                )<br />
                <br />
                SELECT @FreePackageSettingID=SCOPE_IDENTITY()<br />
            </p>
        </div>
        <br />
        <div id="divBLL" style="display: none">
            <p>
                public class CountryMasterBLL<br />
                {<br />
                private CountryMasterTableAdapter _CountryMasterAdapter = null;<br />
                protected CountryMasterTableAdapter Adapter<br />
                {<br />
                get<br />
                {<br />
                if (_CountryMasterAdapter == null)<br />
                {<br />
                return new CountryMasterTableAdapter();<br />
                }<br />
                return _CountryMasterAdapter;<br />
                }<br />
                }<br />
                <br />
                // select Methods ... 
                <br />
                [System.ComponentModel.DataObjectMethodAttribute<br />
                (System.ComponentModel.DataObjectMethodType.Select, true)]<br />
                public CloudAccountDA.CountryMasterDataTable GetAllDetail()<br />
                {<br />
                return Adapter.GetData();<br />
                }<br />
                <br />
                [System.ComponentModel.DataObjectMethodAttribute<br />
                (System.ComponentModel.DataObjectMethodType.Select, false)]<br />
                public CloudAccountDA.CountryMasterDataTable GetDataByCountryID(int iCountryID)<br />
                {<br />
                return Adapter.GetDataByCountryID(iCountryID);<br />
                }<br />
                <br />
                // Insert Methods
                <br />
                [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]<br />
                public int AddCountry(string sCountryCode, string sCountryName, string sCountryDesc, bool bCountryStatus)<br />
                {<br />
                int? iCountryID = 0;<br />
                Adapter.Insert(ref iCountryID, sCountryCode, sCountryName, sCountryDesc, bCountryStatus);<br />
                return (int)iCountryID;<br />
                }<br />
                <br />
                //Update Methods
                <br />
                [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]<br />
                public bool UpdateCountry(int iCountryID, string sCountryCode, string sCountryName, string sCountryDesc, bool bCountryStatus)<br />
                {<br />
                try<br />
                {<br />
                Adapter.Update(iCountryID, sCountryCode, sCountryName, sCountryDesc, bCountryStatus);<br />
                return true;<br />
                }<br />
                catch (Exception)<br />
                {<br />
                return false;<br />
                }<br />
                }<br />
                <br />
                // delete Methods ...
                <br />
                [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]<br />
                public bool DeleteCountry(int iCountryID)<br />
                {<br />
                try<br />
                {<br />
                Adapter.Delete(iCountryID);<br />
                return true;<br />
                }<br />
                catch (Exception)<br />
                {<br />
                return false;<br />
                }<br />
                }<br />

                }<br />
            </p>
        </div>
    </form>
</body>
</html>
