<%@ Page Title="Bill Transact - FAQ's" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="FAQs.aspx.cs" Inherits="IITS_CloudAccounting.FAQs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script>
        window.onload = removeSlider();
    </script>--%>
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">FAQ's</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">FAQ's</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section class="section mainSection scrollAnchor lightSection " id="section-0">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">

                <div class="vc_col-sm-8 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <asp:Panel runat="server" ID="pnlView">
                            <asp:DataList runat="server" ID="dlFAQMaster" Width="100%" RepeatColumns="1" DataSourceID="sqldsFAQMaster">
                                <ItemTemplate>
                                    <div class="accordionRow toggleRow triggerRow">
                                        <a href="#" class="accordion-toggle3 WhoAreWetrigger">
                                            <asp:Label Text='<%# Eval("Question") %>' runat="server" ID="QuestionLabel" />
                                        </a>
                                        <div class="accordion-content triggerMenu" style="display: none;">
                                            <asp:Label Text='<%# Eval("Answer") %>' runat="server" ID="AnswerLabel" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlViewAll">
                            <p></p>
                            <h3>Please Select FAQ Category</h3>
                        </asp:Panel>
                    </div>
                </div>
                <div class="vc_col-sm-1 wpb_column vc_column_container">
                    &nbsp;
                </div>
                <div class="vc_col-sm-3 wpb_column vc_column_container">
                    <div class="wpb_wrapper">
                        <div class="vc_col-sm-12 wpb_column vc_column_container">
                            <div class="wpb_wrapper">
                                <div class="vc_wp_text wpb_content_element">
                                    <div class="widget widget_text">
                                        <h2 class="widgettitle">FAQ's Category</h2>
                                        <div class="textwidget">
                                            <p></p>
                                            <asp:DataList runat="server" ID="ddlFAQCategory" Width="100%" RepeatColumns="1" DataKeyField="FAQCategoryID"
                                                DataSourceID="sqldsFAQCategory" OnItemDataBound="ddlFAQCategory_ItemDataBound">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("FAQCategoryID") %>' runat="server" ID="FAQCategoryIDLabel" Visible="False" />
                                                    <a href='<%# "FAQs.aspx?fId=" + Eval("FAQCategoryID") %>'>
                                                        <h6 style="margin-bottom: 0;">
                                                            <asp:Label Text='<%# Eval("FAQCategoryName") %>' runat="server" ID="FAQCategoryNameLabel" />
                                                        </h6>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:SqlDataSource runat="server" ID="sqldsFAQMaster" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [Question], [Answer] FROM [FAQMaster] WHERE (([Status] = @Status) AND ([FAQCategoryID] = @FAQCategoryID))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
            <asp:Parameter DefaultValue="0" Name="FAQCategoryID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsFAQCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [FAQCategoryID], [FAQCategoryName] FROM [FAQCategoryMaster] WHERE ([FAQCategoryStatus] = @FAQCategoryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="FAQCategoryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfFAQ" />
</asp:Content>
