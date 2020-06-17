<%@ Page Title="Bill Transact - Features" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="IITS_CloudAccounting.Features" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- about-banner -->
    <section class="about-banner features-bg">
        <div class="container">
            <div class="banner-text">
                <h1>Our Features</h1>
            </div>
        </div>
    </section>
    <!-- /about-banner -->
    <div class="section-three">
        <div class="container">
            <div class="section-inner">
              
                <asp:Repeater runat="server" ID="rpFeature" DataSourceID="sqldsFeature">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FeatureID") %>' runat="server" ID="FeatureIDLabel" Visible="False" />
                        <div class="row">
                            <div class="col-sm-4 pull-right">                                
                                <div class="graphic features-img">
                                    <img alt='<%# Eval("FeatureName") %>' src='<%# "Handler/FeatureHandler.ashx?id=" + Eval("FeatureID") %>' />
                                </div>
                            </div>
                            <div class="col-sm-8 pull-left">
                                <div class="steps pad-rht first-step features-hding">
                                    <h2 class="main-heading features"><%# Eval("FeatureName") %></h2>
                                    <p><%# Eval("FeatureDesc") %></p>
                                    <a href="CompanySignUp.aspx" class="try-btn">Try it Free</a>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <asp:Label Text='<%# Eval("FeatureID") %>' runat="server" ID="FeatureIDLabel" Visible="False" />
                        <div class="row">
                            <div class="col-sm-4">
                                <div class="graphic features-img">
                                    <img alt='<%# Eval("FeatureName") %>' src='<%# "Handler/FeatureHandler.ashx?id=" + Eval("FeatureID") %>' />
                                </div>
                            </div>
                            <div class="col-sm-8 ">
                                <div class="steps pad-lft features-hding">
                                    <h2 class="main-heading features"><%# Eval("FeatureName") %></h2>
                                    <p><%# Eval("FeatureDesc") %></p>
                                      <a href="CompanySignUp.aspx" class="try-btn">Try it Free</a>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource runat="server" ID="sqldsFeature" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [FeatureMaster] WHERE ([FeatureStatus] = @FeatureStatus)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="FeatureStatus" Type="Boolean"></asp:Parameter>
                    </SelectParameters>
                </asp:SqlDataSource>
             
            </div>
        </div>
    </div>

</asp:Content>
