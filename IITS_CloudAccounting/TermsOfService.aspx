<%@ Page Title="Bill Transact - Terms of Service" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="TermsOfService.aspx.cs" Inherits="IITS_CloudAccounting.TermsOfService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Terms of Service</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Terms of Service</li>
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
                                        <h2 class="sectionHeader">Terms of Service Of Bill Transact<span class="generalBorder"></span></h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sectionWrapper" style="padding-top: 0;">
            <div class="container">
                <div class="vc_col-sm-12 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="wpb_row row vc_row-fluid">
                            <asp:Label runat="server" ID="lblTerms"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
