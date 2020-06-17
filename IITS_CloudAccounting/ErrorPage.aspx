<%@ Page Title="Error Page" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="IITS_CloudAccounting.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Error Page</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Error Page</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>--%>
    <div style="text-align: center;">
        <br />
        <br />
        <p style="font-size: 16pt; font-weight: bold;">
            We're sorry, an internal error occurred.
        </p>
        <p style="font-size: 14pt;">
            Our supporting staff has been notified of this error and will address the issue shortly.<br />
            <br />
            We  apologize for the inconvenience.<br />
            <br />
            Please try clicking your browsers 'back' button or try reloading the home page.
            <br />
            <br />
            If you continue to receive this message, please try again in a little while.
            <br />
            <br />
            Thank you for your patience.
            <br />
            <br />
            <br />
            <br />
        </p>

    </div>
</asp:Content>
