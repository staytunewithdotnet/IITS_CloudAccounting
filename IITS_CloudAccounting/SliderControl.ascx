<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SliderControl.ascx.cs" Inherits="IITS_CloudAccounting.SliderControl" %>

<section class="slider section mainSection scrollAnchor darkSection" id="slider" data-height="800" data-cover="rgba(33, 36, 46, 0.85)">
    <div id="mainSlider" class="mainSlider homeSlider_1  owl-carousel sliderStyle1">
        <div id="slide1" class="item slide">
            <div class="cover"></div>
            <asp:DataList runat="server" ID="dlSliderItem1" Width="100%" DataKeyField="HomePageSliderID" DataSourceID="sqldsSlider">
                <ItemTemplate>
                    <img src='<%# "Handler/HomeSliderHandler1.ashx?id=" + Eval("HomePageSliderID") %>' alt="Slider1" style="height: 800px;" />
                    <div class="captions">
                        <asp:Label Text='<%# Eval("SliderContent1") %>' runat="server" ID="SliderContent1Label" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div id="slide2" class="item slide">
            <div class="cover"></div>
            <asp:DataList runat="server" ID="dlSliderItem2" Width="100%" DataKeyField="HomePageSliderID" DataSourceID="sqldsSlider">
                <ItemTemplate>
                    <img src='<%# "Handler/HomeSliderHandler2.ashx?id=" + Eval("HomePageSliderID") %>' alt="Slider2" style="height: 800px;" />
                    <div class="captions">
                        <asp:Label Text='<%# Eval("SliderContent2") %>' runat="server" ID="SliderContent1Label" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <asp:SqlDataSource runat="server" ID="sqldsSlider" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT TOP (1) HomePageSliderID, Slider1, SliderContent1, Slider2, SliderContent2 FROM HomePageSlider"></asp:SqlDataSource>
    </div>

    <%--<div id="mainSlider" class="mainSlider homeSlider_1  owl-carousel sliderStyle1">
                    <div id="slide1" class="item slide">
                        <div class="cover"></div>
                        <img src="App_Themes/Blue/images/CloudImage-1.jpg" alt="Title" />
                        <div class="captions">
                            <h2 class="animated">Welcome To Bill Transact ,<br />
                                Cloud Invoicing Service Provider</h2>
                        </div>
                    </div>
                    <div id="slide2" class="item slide">
                        <div class="cover"></div>
                        <img src="App_Themes/Blue/images/CloudImage-2.jpg" alt="Title" />
                        <div class="captions">
                            <h2 class="animated">Welcome To Bill Transact ,<br />
                                Cloud Invoicing Service Provider</h2>
                        </div>
                    </div>
                </div>--%>
</section>