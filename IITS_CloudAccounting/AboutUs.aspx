<%@ Page Title="Bill Transact - About Us" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="IITS_CloudAccounting.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- about-banner -->
    <section class="about-banner">
        <div class="container">
            <div class="banner-text">
                <h5>Our Mission</h5>
                <p>To empower businesses with a world-class cloud-based invoicing & billing software solution.</p>
            </div>
        </div>
    </section>
    

        <div class="section-three">
            <div class="container">
                <div class="section-inner">
                  <asp:DataList runat="server" ID="dlAboutContent" Width="100%" RepeatColumns="1" DataSourceID="sqldsAboutMaster" DataKeyField="AboutContentID">
                            <ItemTemplate>
                                <div class="row">
                                    <asp:Label Text='<%# Eval("AboutContentID") %>' runat="server" ID="AboutContentIDLabel" Visible="False" />

                                    <div class="col-sm-4 pull-right">
                                        <div class="graphic">
                                            <img src='<%# "Handler/AboutContentHandler.ashx?id=" + Eval("AboutContentID") %>' class=" vc_box_border_grey attachment-full" alt="1" width="100%" />
                                        </div>
                                    </div>

                                    <div class="col-sm-8 pull-left">
                                        <div class="steps pad-rht first-step">
                                            <h2 class="main-heading"><%# Eval("AboutCategoryName") %></h2>
                                            <p>
                                                <%# Eval("AboutContent") %>
                                            </p>
                                            <br></br>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                            </ItemTemplate>  
                      <AlternatingItemTemplate>
                          <div class="row">
                                    <asp:Label Text='<%# Eval("AboutContentID") %>' runat="server" ID="AboutContentIDLabel" Visible="False" />

                                    <div class="col-sm-4">
                                        <div class="graphic">
                                            <img src='<%# "Handler/AboutContentHandler.ashx?id=" + Eval("AboutContentID") %>' class=" vc_box_border_grey attachment-full" alt="1" width="100%" />
                                        </div>
                                    </div>

                                    <div class="col-sm-8">
                                        <div class="steps pad-lft">
                                            <h2 class="main-heading"><%# Eval("AboutCategoryName") %></h2>
                                            <p>
                                                <%# Eval("AboutContent") %>
                                            </p>
                                            <br></br>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                      </AlternatingItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
    <%--</section>--%>
    <asp:SqlDataSource runat="server" ID="sqldsAboutMaster" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT a.AboutContentID, a.AboutCategoryID, b.AboutCategoryName,a.AboutContent, a.AboutContentImage, a.AboutContentStatus FROM AboutContentMaster a inner join AboutCategoryMaster b on a.AboutCategoryID = b.AboutCategoryID WHERE (a.AboutContentStatus = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="sqldsAboutCategory" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT [AboutCategoryID], [AboutCategoryName] FROM [AboutCategoryMaster] WHERE ([AboutCategoryStatus] = @AboutCategoryStatus)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="AboutCategoryStatus" Type="Boolean"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField runat="server" ID="hfAbout" />
</asp:Content>
