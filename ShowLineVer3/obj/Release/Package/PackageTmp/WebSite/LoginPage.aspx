<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ShowLineVer3.WebSite.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <link href="../css/EventList.css" rel="stylesheet" />
    <style type="text/css">
        ul, li
        {
            list-style-type: none;
            margin-top: 20px;
        }
    </style>
</head>
<body style="background-color: white">
    <form id="form1" runat="server">
        <div id="Login-in" class="col7">
            <div class="Login-create">
                <h2><span>SIGN IN OR CREATE AN ACCOUNT</span></h2>
                <hr />
                <div id="slickbox1" style="display: block;">
                    <ul class="personal-info-list list-no-border">
                        <li>
                            <label for="email" style="margin-left:50px"></label>
                            <div class="form-boxes">
                                <input type="radio" name="loginsignup_pageV3_R1_LoginType" id="loginsignup_pageV3_R1_LoginType" value="signin" checked="checked" class="float-l" onclick="$('#FormSubmit').html('Sign In'); $('#divconfirmpassword').css('display', 'none');" />
                                <p class="user-radio-btn m-r-20">Yes, I have an account</p>
                                <input type="radio" name="loginsignup_pageV3_R1_LoginType" id="Radio1" value="signup" class="float-l" onclick="$('#FormSubmit').html('Register'); $('#divconfirmpassword').css('display', 'block');" />
                                <p class="user-radio-btn">No, please create one</p>
                            </div>
                            <div class="clear-b"></div>
                        </li>
                        <li>
                            <label for="email">Email Address</label>
                            <div class="form-boxes">
                                <input type="email" name="loginsignup_pageV3_R1_Email" id="loginsignup_pageV3_R1_Email" class="input-full float-l account-info-email email required" value="" />
                            </div>
                            <div class="clear-b"></div>
                        </li>
                        <li>
                            <label for="email">Full Name</label>
                            <div class="form-boxes">
                                <input type="text" name="loginsignup_FullName" id="FullName" class="input-full float-l account-info-email email required" value="" runat="server" />
                            </div>
                            <div class="clear-b"></div>
                        </li>
                        <li>
                            <label for="password">Password</label>
                            <div class="form-boxes">
                                <input type="password" name="loginsignup_Password" id="loginsignup_Password" class="input-full float-l account-info-password" value="" runat="server" />
                                <br class="clear-b" />
                            </div>
                            <div class="clear-b"></div>
                        </li>
                        <li>
                            <div id="divconfirmpassword" style="display: none;">
                                <label for="password">Confirm Password</label>
                                <div class="form-boxes">
                                    <input type="password" name="loginsignup_Confirm_Password" id="loginsignup_ConfirmPassword" class="input-full float-l account-info-password" value="" runat="server" />
                                    <br class="clear-b" />                                   
                                </div>
                                <div class="clear-b"></div>
                            </div>
                        </li>
                        <li>
                            <label></label>
                            <div class="form-boxes">                                
                                 <p class="float-l m-t-8 forget-password">
                                        <a href="#">Forget your password?</a>
                                    </p>   
                            </div>
                        </li>
                    </ul>
                    <div class="clear-b"></div>
                    <div class="info-box important-info m-t-15">
                        <div class="float-r sign-in-group">
                            <div class="button lrg-btn float-l m-r-15">
                                <a href="#" id="FormSubmit" onclick="if ($('#loginsignup_pageV3').valid()) {&#xA;                        {$('.warning-bar').hide(); document.forms['loginsignup_pageV3'].action='wafform.aspx?AJAX=1&amp;_act=Save'; $.post(document.forms['loginsignup_pageV3'].action, $(&quot;#loginsignup_pageV3&quot;).serialize(),function(data) {$('#hiddenjsdiv').html(data);}); }&#xA;                        } return false;">Sign In</a>
                            </div>
                            <div class="float-l">
                                <input type="checkbox" name="rememberme" id="rememberme" class="float-l m-r-5" value="1" />
                                <p class="float-l m-t-7">Remember me on this computer</p>
                            </div>
                        </div>
                        <div class="clear-b"></div>
                    </div>
                    <div class="clear-b"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
