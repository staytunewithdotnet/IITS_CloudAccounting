<%@ Page Title="Need Help" Language="C#" MasterPageFile="~/BillTransact/Doyingo.Master" AutoEventWireup="true" CodeBehind="NeedHelp.aspx.cs" Inherits="IITS_CloudAccounting.Admin.NeedHelp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="../App_Themes/Doyingo/time-sheet.js"></script>
    <div>
        <table id="bigCal"></table>
    </div>--%>

    <div class="row" style="margin-top: -40px;">
        <div class="col-sm-12">
            <ol class="breadcrumb" style="margin-bottom: 0;">
                <li>
                    <a href="#">Help
                    </a>
                </li>
            </ol>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
        <div class="page-header" style="border-bottom: 5px solid #eee;">
            <h1>Have a question?</h1>
            <h6>You can also get answers using one of the methods below:</h6>
        </div>

        <div class="panel-body">
            <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                <div class="clearfix" style="border-bottom: 1px solid #ccc">
                    <div class="col-lg-1" style="padding: 15px;">
                        <a href="#" class="no-hover">
                            <img src="../App_Themes/Doyingo/images/envelope.png" width="50" height="50" alt="" /></a>
                    </div>
                    <div class="col-lg-1">&nbsp;</div>
                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        <h4>
                            <img src="../App_Themes/Doyingo/images/star-blue.png" width="16" height="16" alt="star" />
                            <a href="#">Email Support</a>
                        </h4>
                        <p>Send an email directly to our support team for those more sensitive issues.</p>
                    </div>
                </div>
                <div class="clearfix" style="border-bottom: 1px solid #ccc">
                    <div class="col-lg-1" style="padding: 15px;">
                        <a href="#" target="_blank" class="no-hover">
                            <img src="../App_Themes/Doyingo/images/question-mark.png" width="50" height="50" alt="" /></a>
                    </div>
                    <div class="col-lg-1">&nbsp;</div>
                    <div class="col-lg-8" style="color: black; font-family: Verdana,sans-serif;">
                        <h4><a href="#" target="_blank">Frequently Asked Questions</a></h4>
                        <p>Visit our FAQs for answers to some of our most commonly asked questions.</p>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="panel-blue" style="padding: 15px; border-radius: 7px;">
                    <a href="#" target="_blank" style="color: white; text-decoration: none;">
                        <strong class="box-ls">Sign up for a free Webinar</strong><br />
                        Master the Bill Transact fundamentals in 45 minutes.
                    </a>
                </div>
                <div class="panel-box" style="padding: 10px; border-radius: 7px; border: 1px solid #ccc; margin-top: 15px;">
                    <div class="content">
                        <h3>Phone Support</h3>
                        <p>
                            Call us Monday–Friday, 5:30pm–5:30am IST
				at one of the numbers listed below:
                        </p>
                        <div style="margin-bottom: 5px">
                            <strong style="color: black;">Toll-free in North America</strong>
                            <br />
                            229-21339622
                        </div>
                        <div style="margin-bottom: 5px">
                            <strong style="color: black;">Toll-free in UK</strong>
                            <br />
                            0808-101-3408
                        </div>
                        <div style="margin-bottom: 5px">
                            <strong style="color: black;">Toll-free in Ireland</strong>
                            <br />
                            1-800-949-046
                        </div>
                        <div style="margin-bottom: 5px">
                            <strong style="color: black;">Worldwide</strong>
                            <br />
                            +1-416-481-6946
                        </div>
                        <div class="divider" style="border-bottom: 1px solid #ccc; margin: 15px 0;">
                        </div>
                        <p class="" style="text-align: justify;">
                            We're proud to offer toll-free phone support during our regular business hours. It's one of those things that sets Bill Transact apart from the competition.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-2">&nbsp;</div>
    <%--<link href="../App_Themes/Doyingo/css/select2.min.css" rel="stylesheet" />
    <div id="main-wrapper">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-white">
                    <div class="panel-body">
                        <h4 class="no-m m-b-sm">Basic</h4>
                        <asp:DropDownList runat="server" ID="ddlClient" Style="display: none; width: 100%" CssClass="js-states form-control text dropdownFirst" TabIndex="1" DataSourceID="sqldsClient" DataTextField="Name" DataValueField="ID"></asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="sqldsClient" ConnectionString='<%$ ConnectionStrings:IITS_CloudAccountConnectionString %>' SelectCommand="SELECT '-1' AS ID,'[new client]' AS Name UNION SELECT CompanyClientID,(OrganizationName +'('+ LastName +','+ FirstName +')')AS Name FROM CompanyClientMaster WHERE CompanyID = @CompanyID">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCompany" PropertyName="Value" DefaultValue="1" Name="CompanyID"></asp:ControlParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:HiddenField runat="server" ID="hfCompany" />
                        <br />
                        <asp:DropDownList runat="server" ID="ddlsome" CssClass="form-control">
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <select class="js-states form-control" tabindex="-1" style="display: none; width: 100%">
                            <optgroup label="Alaskan/Hawaiian Time Zone">
                                <option value="AK">Alaska</option>
                                <option value="HI">Hawaii</option>
                            </optgroup>
                            <optgroup label="Pacific Time Zone">
                                <option value="CA">California</option>
                                <option value="NV">Nevada</option>
                                <option value="OR">Oregon</option>
                                <option value="WA">Washington</option>
                            </optgroup>
                            <optgroup label="Mountain Time Zone">
                                <option value="AZ">Arizona</option>
                                <option value="CO">Colorado</option>
                                <option value="ID">Idaho</option>
                                <option value="MT">Montana</option>
                                <option value="NE">Nebraska</option>
                                <option value="NM">New Mexico</option>
                                <option value="ND">North Dakota</option>
                                <option value="UT">Utah</option>
                                <option value="WY">Wyoming</option>
                            </optgroup>
                            <optgroup label="Central Time Zone">
                                <option value="AL">Alabama</option>
                                <option value="AR">Arkansas</option>
                                <option value="IL">Illinois</option>
                                <option value="IA">Iowa</option>
                                <option value="KS">Kansas</option>
                                <option value="KY">Kentucky</option>
                                <option value="LA">Louisiana</option>
                                <option value="MN">Minnesota</option>
                                <option value="MS">Mississippi</option>
                                <option value="MO">Missouri</option>
                                <option value="OK">Oklahoma</option>
                                <option value="SD">South Dakota</option>
                                <option value="TX">Texas</option>
                                <option value="TN">Tennessee</option>
                                <option value="WI">Wisconsin</option>
                            </optgroup>
                            <optgroup label="Eastern Time Zone">
                                <option value="CT">Connecticut</option>
                                <option value="DE">Delaware</option>
                                <option value="FL">Florida</option>
                                <option value="GA">Georgia</option>
                                <option value="IN">Indiana</option>
                                <option value="ME">Maine</option>
                                <option value="MD">Maryland</option>
                                <option value="MA">Massachusetts</option>
                                <option value="MI">Michigan</option>
                                <option value="NH">New Hampshire</option>
                                <option value="NJ">New Jersey</option>
                                <option value="NY">New York</option>
                                <option value="NC">North Carolina</option>
                                <option value="OH">Ohio</option>
                                <option value="PA">Pennsylvania</option>
                                <option value="RI">Rhode Island</option>
                                <option value="SC">South Carolina</option>
                                <option value="VT">Vermont</option>
                                <option value="VA">Virginia</option>
                                <option value="WV">West Virginia</option>
                            </optgroup>
                        </select>

                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
