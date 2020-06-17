<%@ Page Title="Bill Transact - Support" Language="C#" MasterPageFile="~/CloudAccounting.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="IITS_CloudAccounting.Support" %>

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
                    <h2 class="pageTitle">Sopport</h2>
                </div>
                <div class="col-md-6">
                    <ul class="breadcrumb">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="delimiter">/</li>
                        <li class="active">Support</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <section id="page" class="page section mainSection scrollAnchor lightSection">
        <div class="sectionWrapper" style="padding: 20px 0 0 10px;">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 ">
                        <div class="row">
                            <div id="bridge">
                                <div style="margin: 0 0 10px 0; padding: 10px 35px; background-color: #ffffd2; color: #555; font-size: 16px; text-align: center;"><strong>Dev License:</strong> This installation of WHMCS is running under a Development License and is not authorized to be used for production use. Please report any cases of abuse to abuse@whmcs.com</div>
                                <p>You must login to access this page. These login details differ from your websites control panel username and password.</p>
                                <div id="frmlogin">
                                    <input type="hidden" value="e1b834eccc231fbf087b0217ea08cd2d135b32ff" name="token">
                                    <table cellspacing="0" cellpadding="0" border="0" align="center" class="frame table" style="margin: 0 auto;">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <table cellspacing="0" cellpadding="10" border="0" align="center" class="table">
                                                        <tbody>
                                                            <tr>
                                                                <td width="150" align="right" class="fieldarea">Email Address:</td>
                                                                <td>
                                                                    <input type="text" value="" size="40" name="username"></td>
                                                            </tr>
                                                            <tr>
                                                                <td width="150" align="right" class="fieldarea">Password:</td>
                                                                <td>
                                                                    <input type="password" value="" size="25" name="password"></td>
                                                            </tr>
                                                            <tr>
                                                                <td width="150" align="right" class="fieldarea"></td>
                                                                <td>
                                                                    <input type="checkbox" name="rememberme" style="display: block;">Remember Me</td>
                                                            </tr>
                                                            <tr>
                                                                <td width="150" align="right" class="fieldarea">&nbsp;</td>
                                                                <td>
                                                                    <input type="submit" value="Login"></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                </div>
                                <p align="center"><strong>Forgotten Your Password?</strong> <a href="#">Request a Password Reset</a></p>
                                <script type="text/javascript">
                                    document.frmlogin.username.focus();
                                </script>
                                <br />
                                <p style="text-align: center;">Powered by <a target="_blank" href="http://www.whmcs.com/">WHMCompleteSolution</a></p>

                                <div align="right">
                                    <div id="languagefrm" name="languagefrm">
                                        <strong>Language:</strong>
                                        <select name="language">
                                            <option>Arabic</option>
                                            <option>Azerbaijani</option>
                                            <option>Catalan</option>
                                            <option>Croatian</option>
                                            <option>Czech</option>
                                            <option>Danish</option>
                                            <option>Dutch</option>
                                            <option selected="selected">English</option>
                                            <option>Farsi</option>
                                            <option>French</option>
                                            <option>German</option>
                                            <option>Hungarian</option>
                                            <option>Italian</option>
                                            <option>Norwegian</option>
                                            <option>Portuguese-br</option>
                                            <option>Portuguese-pt</option>
                                            <option>Russian</option>
                                            <option>Spanish</option>
                                            <option>Swedish</option>
                                            <option>Turkish</option>
                                            <option>Ukranian</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </section>



</asp:Content>
