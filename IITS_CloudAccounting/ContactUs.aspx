<%@ Page Title="Bill Transact - ContactUs" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="IITS_CloudAccounting.ContactUs" %>

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
                    <h2 class="pageTitle">Contact Us</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Contact Us</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="section-0" class="section mainSection scrollAnchor lightSection ">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div>
                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="col-md-12 sectionTitle">
                                <h2 class="sectionHeader">Contact Us<span class="generalBorder"></span></h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="section-1" class="section mainSection scrollAnchor lightSection ">
        <div class="sectionWrapper" style="padding: 0;">
            <div class="container">
                <div>
                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="wpb_gmaps_widget wpb_content_element">
                                <div class="wpb_wrapper">
                                    <div class="wpb_map_wraper">
                                        <asp:DataList runat="server" ID="DataList1" Width="100%" BorderStyle="None" BorderWidth="0" RepeatColumns="1" DataKeyField="ContactID" DataSourceID="sqldsContact">
                                            <ItemTemplate>
                                                <%--<iframe width="600" height="480" frameborder="0" style="border: 0" src="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=I-Infotechsys,+Ahmedabad,+Gujarat,+India&amp;aq=0&amp;oq=I-Infotechsys&amp;sll=37.0625,-95.677068&amp;sspn=36.368578,86.572266&amp;ie=UTF8&amp;hq=I-Infotechsys,&amp;hnear=Ahmedabad,+Gujarat,+India&amp;t=m&amp;ll=23.075468,72.516804&amp;spn=0.055274,0.072956&amp;z=13&amp;output=embed"></iframe>--%>
                                                <iframe width="600" height="480" frameborder="0" style="border: 0" src='<%# Eval("GoogleMapCode") %>'></iframe>
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
    </section>
    <section id="section-2" class="section mainSection scrollAnchor lightSection ">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div>
                    <div class="vc_col-sm-7 wpb_column vc_column_container">
                        <div class="wpb_wrapper">

                            <div class="wpb_text_column wpb_content_element ">
                                <div class="wpb_wrapper sectionTitle">
                                    <h2>Get In Touch<span class="generalBorder"></span></h2>
                                </div>
                            </div>
                            <div class="sendMessage add-send clearfix">
                                <div id="message"></div>
                                <div class="sendMessageForm clearfix contact-form">
                                    <ul class="row clearfix">
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtName" placeholder="Your name" CssClass="name text"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" ValidationGroup="ContactUs" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </li>
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" CssClass="email"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="ContactUs" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </li>
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtPhone" placeholder="Phone"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvPhone" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" ValidationGroup="ContactUs" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </li>
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtSubject" placeholder="Subject"></asp:TextBox>
                                        </li>
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtLocation" placeholder="Location"></asp:TextBox>
                                        </li>
                                        <li class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtWebsite" placeholder="Website"></asp:TextBox>
                                        </li>
                                        <li class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtComments" placeholder="Your Comments" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvComment" ControlToValidate="txtComments" Display="Dynamic" ForeColor="Red" ValidationGroup="ContactUs" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                        </li>
                                    </ul>
                                    <asp:Button runat="server" ID="btnSubmit" Text="   Send   " ValidationGroup="ContactUs" OnClick="BtnSubmitClick" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="vc_col-sm-5 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="vc_wp_text wpb_content_element">
                                <div class="widget widget_text">
                                    <h2 class="widgettitle">Company Information</h2>
                                    <div class="textwidget">
                                        <p></p>
                                        <asp:DataList runat="server" ID="dlContact" Width="100%" RepeatColumns="1" DataKeyField="ContactID" DataSourceID="sqldsContact">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("ContactID") %>' runat="server" ID="ContactIDLabel" Visible="False" />
                                                <h5>
                                                    <asp:Label Text='<%# Eval("CompanyName") %>' runat="server" ID="CompanyNameLabel" />
                                                </h5>
                                                <h6>
                                                    <asp:Label Text='<%# Eval("ContactPerson") %>' runat="server" ID="ContactPersonLabel" /></h6>
                                                Address : 
                                                <asp:Label Text='<%# Eval("Address1") %>' runat="server" ID="Address1Label" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Address2") %>' runat="server" ID="Address2Label" />&nbsp;&nbsp;&nbsp;
                                                <br />
                                                <asp:Label Text='<%# Eval("Address3") %>' runat="server" ID="Address3Label" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Address4") %>' runat="server" ID="Address4Label" /><br />
                                                <asp:Label Text='<%# Eval("City") %>' runat="server" ID="CityLabel" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("ZipCode") %>' runat="server" ID="ZipCodeLabel" /><br />
                                                <asp:Label Text='<%# Eval("State") %>' runat="server" ID="StateLabel" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="CountryLabel" /><br />
                                                Phone:
                                                <asp:Label Text='<%# Eval("Phone1") %>' runat="server" ID="Phone1Label" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Phone2") %>' runat="server" ID="Phone2Label" /><br />
                                                Fax:
                                                <asp:Label Text='<%# Eval("Fax1") %>' runat="server" ID="Fax1Label" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Fax2") %>' runat="server" ID="Fax2Label" /><br />
                                                Mobile:
                                                <asp:Label Text='<%# Eval("Mobile1") %>' runat="server" ID="Mobile1Label" />&nbsp;&nbsp;&nbsp;
                                                <asp:Label Text='<%# Eval("Mobile2") %>' runat="server" ID="Mobile2Label" /><br />
                                                Email:
                                                <a href='<%# "mailto:" + Eval("Email1") %>'>
                                                    <asp:Label Text='<%# Eval("Email1") %>' runat="server" ID="Email1Label" /></a>&nbsp;&nbsp;&nbsp;
                                                <a href='<%# "mailto:" + Eval("Email2") %>'>
                                                    <asp:Label Text='<%# Eval("Email2") %>' runat="server" ID="Email2Label" /></a><br />
                                                Website: <a href='<%# Eval("Website") %>' target="_blank">
                                                    <asp:Label Text='<%# Eval("Website") %>' runat="server" ID="WebsiteLabel" /></a><br />
                                                <%--GoogleMapCode:
                                                <asp:Label Text='<%# Eval("GoogleMapCode") %>' runat="server" ID="GoogleMapCodeLabel" /><br />
                                                Status:
                                                <asp:Label Text='<%# Eval("Status") %>' runat="server" ID="StatusLabel" /><br />--%>
                                                <br />
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:SqlDataSource runat="server" ID="sqldsContact" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [ContactMaster] WHERE ([Status] = @Status)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="True" Name="Status" Type="Boolean"></asp:Parameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <%--<p>
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lorem quam, adipiscing condimentum tristique vel, eleifend sed turpis.<br>
                                            Email Account : <a href="mailto:info@DoyinGo.com">info@DoyinGo.com</a>
                                        </p>
                                        <h6>Phone Numbers :</h6>
                                        <p>
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lorem quam, adipiscing condimentum tristique vel, eleifend sed turpis.<br>
                                            Telephone No : <a href="tele:1234567890">1234567890</a>
                                        </p>--%>
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
