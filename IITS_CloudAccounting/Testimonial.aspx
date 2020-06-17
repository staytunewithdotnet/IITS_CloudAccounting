<%@ Page Title="Bill Transact - Testimonial" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="Testimonial.aspx.cs" Inherits="IITS_CloudAccounting.Testimonial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="tsm" />
    <%--<script>
        window.onload = removeSlider();
    </script>--%>
    <div class="pageInfo" style="background-image: url(App_Themes/Blue/images/page-info-bg.png);">
        <div class="cover"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="pageTitle">Testimonial</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Testimonial</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="testmonials-1" class="section mainSection scrollAnchor lightSection  testmonials-1">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div>
                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="wpb_row row vc_row-fluid">
                                <div class="vc_col-sm-9 wpb_column vc_column_container">
                                    <div class="wpb_wrapper">
                                        <div class="col-md-12 sectionTitle">
                                            <h2 class="sectionHeader">What Our Customers Say About Us :)<span class="generalBorder"></span></h2>
                                            <%--<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lorem quam, adipiscing condimentum tristique vel, eleifend sed turpis. Pellentesque cursus arcu id magna euismod in elementum purus molestie.</p>--%>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Repeater runat="server" ID="rpTestimonial">
                                                <ItemTemplate>
                                                    <div class="col-md-12 col-sm-12 item">
                                                        <div class="singleTestmonial">
                                                            <div class="testmonialsTopContents clearfix">
                                                                <blockquote>
                                                                    <p>
                                                                        <asp:Label Text='<%# Eval("TestimonialComment") %>' runat="server" ID="TestimonialCommentLabel" />
                                                                    </p>
                                                                </blockquote>
                                                                <img alt="testmonials tip" class="tip" src="App_Themes/Blue/images/tip.png" />
                                                            </div>
                                                            <div class="testmonialsBottomContents">
                                                                <p>
                                                                    <a class="userName" href="#" title='<%# Eval("TestimonialName") %>'>
                                                                        <asp:Label Text='<%# Eval("TestimonialName") %>' runat="server" ID="TestimonialNameLabel" />
                                                                        (<asp:Label Text='<%# Eval("TestimonialCompanyName") %>' runat="server" ID="TestimonialCompanyNameLabel" />)
                                                                    </a>
                                                                </p>
                                                                <p>
                                                                    <a class="userWebsite" href="#" title='<%# Eval("TestimonialLocation") %>'>
                                                                        <asp:Label Text='<%# Eval("TestimonialLocation") %>' runat="server" ID="TestimonialLocationLabel" />
                                                                        (On :
                                                                        <asp:Label Text='<%# DateTime.Parse(Eval("TestimonialDate").ToString()).ToString("dd-MMM-yyyy") %>' runat="server" ID="TestimonialDateLabel" />)
                                                                    </a>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Label Text='<%# Eval("TestimonialID") %>' runat="server" ID="TestimonialIDLabel" Visible="False" />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div class="col-md-6">&nbsp;</div>
                                            <div class="col-md-6">
                                                <table style="text-align: center; width: 100%; border: 1px dashed #d6d6d6; border-radius: 2px 2px 2px 2px;">
                                                    <tr style="vertical-align: middle; line-height: 0">
                                                        <td style="text-align: center">
                                                            <div class="pagination ">
                                                                <span>
                                                                    <asp:LinkButton ID="lnkbtnPrevious" runat="server" Font-Size="14px" OnClick="LnkbtnPreviousClick">Previous</asp:LinkButton>
                                                                </span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:DataList ID="dlPaging" runat="server" OnItemCommand="DlPagingItemCommand" OnItemDataBound="DlPagingItemDataBound"
                                                                RepeatDirection="Horizontal">
                                                                <ItemTemplate>
                                                                    <div class="pagination " style="margin: 0;">
                                                                        <span style="margin-right: 10px; margin-left: 10px">
                                                                            <asp:LinkButton ID="lnkbtnPaging" ForeColor="black" Font-Size="14px" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                                                                CommandName="lnkbtnPaging" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                                                        </span>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <div class="pagination">
                                                                <span>
                                                                    <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Size="14px" OnClick="LnkbtnNextClick">Next</asp:LinkButton>
                                                                </span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:SqlDataSource runat="server" ID="sqldsTestimonial" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT * FROM [TestimonialMaster] WHERE ([TestimonialStatus] = @TestimonialStatus)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="True" Name="TestimonialStatus" Type="Boolean"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </div>
                                <div class="vc_col-sm-3 wpb_column vc_column_container">
                                    <div class="wpb_wrapper">
                                        <div class="col-md-12 sectionTitle">
                                            <h2 class="sectionHeader">Add Testimonial<span class="generalBorder"></span></h2>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="form-horizontal">
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox runat="server" ID="txtName" PlaceHolder="Name" CssClass="form-control text" TabIndex="1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Testimonials Name Reqiured" ControlToValidate="txtName" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox runat="server" ID="txtCompanyName" PlaceHolder="Company Name" CssClass="form-control text" TabIndex="2"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Company Name Reqiured" ControlToValidate="txtCompanyName" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox runat="server" ID="txtLocation" PlaceHolder="Location" CssClass="form-control text" TabIndex="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="Testimonial Location Reqiured" ControlToValidate="txtLocation" ValidationGroup="TestimonialsMaster">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox runat="server" ID="txtComment" PlaceHolder="Comment" TextMode="MultiLine" CssClass="form-control text" TabIndex="4" />
                                                    </div>
                                                </div>
                                                <asp:UpdatePanel runat="server" ID="upCaptcha">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <div class="col-lg-7">
                                                                <asp:Image ID="imgCaptcha" runat="server" Style="margin-bottom: 0; margin-right: 5px;" />
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="BtnRefreshClick" CssClass="btn btn-primary" Style="padding: 8px; font-size: 15px; font-weight: 500;" />
                                                            </div>
                                                            <div class="col-lg-3">&nbsp;</div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <div class="form-group">
                                                    <div class="col-lg-12">
                                                        <asp:TextBox ID="txtCaptcha" runat="server" PlaceHolder="Captcha" CssClass="form-control text" TabIndex="9"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvCaptcha" ControlToValidate="txtCaptcha" SetFocusOnError="True" ValidationGroup="TestimonialsMaster" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div style="color: white; text-align: center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Add Testimonial" TabIndex="5" CssClass="btn btn-primary" ValidationGroup="TestimonialsMaster" OnClick="BtnSubmitClick" />
                                                </div>
                                            </div>
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
</asp:Content>
