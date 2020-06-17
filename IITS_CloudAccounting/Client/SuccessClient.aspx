<%@ Page Title="Success" Language="C#" MasterPageFile="~/Client/ClientManagement.Master" AutoEventWireup="true" CodeBehind="SuccessClient.aspx.cs" Inherits="IITS_CloudAccounting.Client.SuccessClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12" style="color: black; font-family: Verdana,sans-serif; min-height: 110px; margin-top: -65px;">
        <div class="page-header">
            <h1 style="display: inline-block">Success</h1>
        </div>
        <div class="panel-body" style="margin-bottom: 20px; text-align: center;">
            <span style="font-size: larger">Express Checkout For Invoice - Success !</span>
            <br />
            <br />
            <span style="color: green; font-size: smaller">Your invoice payment has been successfully done.</span>
        </div>
    </div>
</asp:Content>
