<%@ Page Title="Check Client" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="CheckClient.aspx.cs" Inherits="IITS_CloudAccounting.CheckClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hfUsername"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hfPassword"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hfRequestID"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hfPageName"></asp:HiddenField>
    <style>
        .wpb_wrapper p {
            text-align: justify;
        }

        .table {
            margin-bottom: 0;
        }
    </style>
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <%--<h2 class="pageTitle">About Us</h2>--%>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <%--<li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">About Us</li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="intro" class="section mainSection scrollAnchor lightSection  intro">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div class="vc_col-sm-12 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row vc_row-fluid">
                            <div class="vc_col-sm-12 wpb_column vc_column_container">
                                <div class="wpb_wrapper">
                                    <div class="col-md-12 sectionTitle">
                                        <asp:Label runat="server" ID="errorLabel" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
