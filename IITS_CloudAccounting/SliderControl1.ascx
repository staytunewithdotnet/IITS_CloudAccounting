<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SliderControl1.ascx.cs" Inherits="IITS_CloudAccounting.SliderControl1" %>
 <section class="hero-banner">
<!-- Carousel
    ================================================== -->
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
          <!-- Indicators -->
          <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            
          </ol>
          <div class="carousel-inner"  role="listbox">

              <asp:Repeater runat="server" ID="DataList1"  DataSourceID="sqldsSlider">
                  <ItemTemplate>
                      <div class="item active" <%# string.Format(" style='background: url(Handler/HomeSliderHandler1.ashx?id={0}); background-repeat: no-repeat; background-size: cover;min-height:470px;'", Eval("HomePageSliderID"))%>>
                          <div class="container">
                              <div class="carousel-caption-text">
                                  <h2><%# Eval("SliderContent1") %></h2>
                                  <p></p>
                                  <a href="CompanySignUp.aspx" class="cta-btn">Get Started For Free</a>

                                  <h6></h6>
                              </div>
                          </div>
                      </div>
                  </ItemTemplate>
              </asp:Repeater>


           <asp:Repeater runat="server" ID="Repeater1"  DataSourceID="sqldsSlider">
                  <ItemTemplate>
                      <div class="item" <%# string.Format(" style='background: url(Handler/HomeSliderHandler2.ashx?id={0}); background-repeat: no-repeat; background-size: cover;min-height:470px;'", Eval("HomePageSliderID"))%>>
                          <div class="container">
                              <div class="carousel-caption-text">
                                  <h2><%# Eval("SliderContent2") %></h2>
                                  <p></p>
                                  <a href="CompanySignUp.aspx" class="cta-btn">Get Started For Free</a>

                                  <h6></h6>
                              </div>
                          </div>
                      </div>
                  </ItemTemplate>
              </asp:Repeater>
          </div>
        </div><!-- /.carousel -->
        
        <div class="clouds"><img src="App_Themes/sky/uploads/clouds.png"/></div>
    </section>
 <asp:SqlDataSource runat="server" ID="sqldsSlider" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT TOP (1) HomePageSliderID, Slider1, SliderContent1, Slider2, SliderContent2 FROM HomePageSlider"></asp:SqlDataSource>