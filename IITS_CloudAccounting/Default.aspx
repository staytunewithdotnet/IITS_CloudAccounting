<%@ Page Title="" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IITS_CloudAccounting.Default" %>

<%@ Register Src="~/SliderControl1.ascx" TagPrefix="uc1" TagName="SliderControl11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SliderControl11 runat="server" id="SliderControl1" />
    <section class="benfits-sec padd-60">
          <div class="container">
              <div class="main-heading">
                  <asp:DataList runat="server" ID="dlHome" Width="100%" RepeatColumns="1" DataKeyField="HomeID" DataSourceID="sqldsHome">
                      <ItemTemplate>
                  <h2>Our Benefits</h2>
                  <p><%# Eval("HomeDesc") %></p>
                      </ItemTemplate>
                  </asp:DataList>
                  <asp:SqlDataSource runat="server" ID="sqldsHome" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [HomeMaster] WHERE ([HomeStatus] = @HomeStatus)">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="True" Name="HomeStatus" Type="Boolean"></asp:Parameter>
                      </SelectParameters>
                  </asp:SqlDataSource>
              </div>
              <div class="row">
                  <%--<asp:Repeater runat="server" ID="rpFeature" DataSourceID="sqldsFeature">
                      <ItemTemplate>
                          <asp:Label Text='<%# Eval("FeatureID") %>' runat="server" ID="FeatureIDLabel" Visible="False" />
                          <div class="col-md-3 col-xs-6">
                              <div class="benfits-thumb">
                                  <div class="icon-div">
                                      <span class="icon-bg"></span>
                                      <span class="icon-circle">
                                          <img alt='<%# Eval("FeatureName") %>' src='<%# "Handler/FeatureHandler.ashx?id=" + Eval("FeatureID") %>' /></span>
                                  </div>
                                  <h3><%# Eval("FeatureName") %></h3>
                                  <p><%# Eval("FeatureDesc") %></p>
                              </div>
                          </div>

                      </ItemTemplate>
                  </asp:Repeater>--%>
                  <div class="row">
                  <div class="col-md-3 col-xs-6">
                      <div class="benfits-thumb">
                          <div class="icon-div">
                              <span class="icon-bg"></span>
                              <span class="icon-circle"><img src="App_Themes/sky/uploads/benfit-icon-1.png" alt=""/></span>
                          </div>
                          <h3>Save Time</h3>
                          <p></p>
                      </div>
                  </div>
                  <div class="col-md-3 col-xs-6">
                      <div class="benfits-thumb">
                          <div class="icon-div">
                              <span class="icon-bg"></span>                              
                              <span class="icon-circle"><img src="App_Themes/sky/uploads/benfit-icon-2.png" alt=""/></span>
                          </div>
                          <h3>Save Money</h3>
                          <p></p>
                      </div>
                  </div>
                  <div class="col-md-3 col-xs-6">
                      <div class="benfits-thumb">
                          <div class="icon-div">
                              <span class="icon-bg"></span>
                              <span class="icon-circle"><img src="App_Themes/sky/uploads/benfit-icon-3.png" alt=""/></span>
                          </div>
                          <h3>Access Anywhere</h3>
                          <p></p>
                      </div>
                  </div>
                  <div class="col-md-3 col-xs-6">
                      <div class="benfits-thumb">
                          <div class="icon-div">
                              <span class="icon-bg"></span>
                              <span class="icon-circle"><img src="App_Themes/sky/uploads/benfit-icon-4.png" alt=""/></span>
                          </div>
                          <h3>Invoices</h3>
                          <p> </p>
                      </div>
                  </div>
              </div>

                  <asp:SqlDataSource runat="server" ID="sqldsFeature" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [FeatureMaster] WHERE ([ShowOnHomePage] = @ShowOnHomePage)">
                      <SelectParameters>
                          <asp:Parameter DefaultValue="True" Name="ShowOnHomePage" Type="Boolean"></asp:Parameter>
                      </SelectParameters>
                  </asp:SqlDataSource>
              </div>
          </div>
    </section>

    <section class="feature-sec padd-60">
          <div class="container">
              <div class="main-heading">
                  <h2>Features</h2>
                  <p>Get everything you'll ever need to manage your paperwork.</p>
              </div>
              <div class="regular slider">
                <div class="slide">
                    <div class="feat-thumbs">
                        <span><img src="App_Themes/sky/uploads/fet-1.jpg" alt="feat-1"></span>
                        <div class="feat-thumb-cont">
                            <span><img src="App_Themes/sky/uploads/fet-icon-1.png" alt="icon"></span>
                            <h4>Quick Invoicing</h4>
                            <p>Create and send professional invoices in minutes and impress your customers.</p>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="feat-thumbs">
                        <span><img src="App_Themes/sky/uploads/fet-2.jpg" alt="feat-1"></span>
                        <div class="feat-thumb-cont">
                            <span><img src="App_Themes/sky/uploads/fet-icon-2.png" alt="icon"></span>
                            <h4>Effortless Expense Management</h4>
                            <p>Record all business expenses and know how much you're spending.</p>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="feat-thumbs">
                        <span><img src="App_Themes/sky/uploads/fet-3.jpg" alt="feat-1"></span>
                        <div class="feat-thumb-cont">
                            <span><img src="App_Themes/sky/uploads/fet-icon-3.png" alt="icon"></span>
                            <h4>Easy time tracking</h4>
                            <p>Effortlessly track time for projects and invoice your customers accordingly.</p>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <div class="feat-thumbs">
                        <span><img src="App_Themes/sky/uploads/fet-4.jpg" alt="feat-1"></span>
                        <div class="feat-thumb-cont">
                            <span><img src="App_Themes/sky/uploads/fet-icon-4.png" alt="icon"></span>
                            <h4>Online Payments</h4>
                            <p>Get paid faster and on time with online payment gateways</p>
                        </div>
                    </div>
                </div>
              
              </div>
          </div>
      </section>
      <section class="ideal-indi-sec padd-60">
          <div class="container">
              <div class="main-heading">
                  <h2>Ideal for business across industries</h2>
              </div>
              <div class="row">
                  <div class="col-sm-4">
                      <div class="industries-list">
                          <ul>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-1.png" alt="icon">Web Design</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-2.png" alt="icon">Marketing</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-3.png" alt="icon">Photography</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-4.png" alt="icon">Construction</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-5.png" alt="icon">Legal</a></li>
                          </ul>
                      </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="industries-list">
                          <ul>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-6.png" alt="icon">E Commerce</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-7.png" alt="icon">Consulting</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-8.png" alt="icon">Education &amp; Training</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-9.png" alt="icon">Real Estate</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-10.png" alt="icon">Healthcare</a></li>
                          </ul>
                      </div>
                  </div>
                  <div class="col-sm-4">
                      <div class="industries-list">
                          <ul>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-11.png" alt="icon">Retail</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-12.png" alt="icon">Web Development</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-13.png" alt="icon">Cleaning Services</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-14.png" alt="icon">Food Services</a></li>
                              <li><a href="#"><img src="App_Themes/sky/i/ideal-icon-15.png" alt="icon">Accounting</a></li>
                          </ul>
                      </div>
                  </div>
              </div>
          </div>
      </section>
      
</asp:Content>
