<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShowLineVer3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="Keywords" content="Spin, Club, San, Diego, DJ, Events, nightclub , Showsline" />
    <meta name="Description" content="Reggae Dance Festival. Presented by Showsline & Spin Nightclub bringing the city of San Diego to enjoy a once in rare occasion artist! ." />
 
    <title>ShowsLine - Venue Promotions and Ticketing</title>

    <link href="css/style.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.min.js"></script>--%>

    <script src="js/amazon_scroller.js"></script>
    <script src="js/desSlideshow.js"></script>
    <script src="js/jquery.msgBox.js"></script>
    <link href="css/msgBoxLight.css" rel="stylesheet" />
    <script src="js/common.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#desSlideshow2").desSlideshow({
                autoplay: 'enable',//option:enable,disable
                slideshow_width: '965',//+kk '616',//slideshow window width
                slideshow_height: '310',//+kk '315',//slideshow window height
                thumbnail_width: '220',//thumbnail width
                time_Interval: '4000',//Milliseconds
                directory: 'images/'// flash-on.gif and flashtext-bg.jpg directory
            });

            $("#amazon_scroller1").amazon_scroller({
                scroller_title_show: 'enable',//+kk 'disable',
                scroller_time_interval: '8000',
                scroller_window_background_color: "#dfdddd",
                scroller_window_padding: '10',
                scroller_border_size: '0',
                scroller_border_color: '#000',
                scroller_images_width: '133',//+kk '124',
                scroller_images_height: '200',//+kk '100',
                scroller_title_size: '12',
                scroller_title_color: 'black',
                scroller_show_count: '4',
                directory: 'images'
            });


            $("#nav").show();
            $(".tab-content").hide();
            $("ul#main-nav li:first").addClass("active").show();
            $(".tab-content:first").show();

            $("ul#main-nav li").click(function () {
                $("ul#main-nav li").removeClass("active");
                $(this).addClass("active");
                $(".tab-content").hide();
                var activeTab = $(this).find("a").attr("href");
                $(activeTab).fadeIn();
                return false;
            });
            
            $("#openPanel").click(function () {              
                $("div#panel").slideToggle("slow");
                $("#toggle").toggleClass("open");
            });
           
        });
    </script>

    <script type="text/javascript">       
        function CheckValidation(msgcontents,msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents
            });
            OpenLoginPanel();            
        }

        function OpenLogin() {
            $.msgBox({
                title: "Login",
                content: "Please Login To See Your Account Details.",
                buttons: [{ value: "Ok" }],
                afterShow: function (result) { OpenLoginPanel(); }
            });
        }

        function OpenLoginPanel() {           
            $("div#panel").slideToggle("slow");
            $("#toggle").toggleClass("open");
        }

        function CloseLoginPanel() {
            $("div#panel").slideToggle("slow");
            $("#toggle").toggleClass("close");
        }

        function OpenLoginCheckout(id) {
            window.scrollTo(0, 0);
            $('#acc').val(id);
            $("div#panel").slideToggle("slow");
            $("#toggle").toggleClass("open");
        }        

        function Checkout() {
            //var iframe = document.getElementById("frmid");
            //iframe.contentWindow.myFunction();
            //var el = document.getElementById('frmid');

            //window.frames["frmid"].contentWindow.LogingCheckout();

            //CrossBrowser();

            //window.frames["frmid"].window.LogingCheckout();
            window.parent.LogingCheckoutCM();

            //val el = window.frames(0).contentWindow.LogingCheckout();;

            //if (el.contentWindow) {
            //    el.contentWindow.LogingCheckout();                
            //}
            //else if (el.contentDocument) {
            //    el.contentDocument.LogingCheckout();
            //}

            //document.getElementById('frmid').contentWindow.LogingCheckout();
        }

        function resizeIframe(obj) {
            obj.style.height = "";
            obj.style.height = (obj.contentWindow.document.body.scrollHeight) + 'px';
            //alert(parent.frames['frmid'].document.title);
            //document.title = parent.frames['frmid'].document.title ;
            //obj.style.width = obj.contentWindow.document.body.scrollWidth + 'px';
        }

        function LoadPage(target, values) {
            $('#frmid').attr('src', target);
            $("a.current").removeClass("current");
            $(values).addClass("current");
        }        
       
        function ForgotPwd() {            
            $('#trforgotpwd').css('display', 'block');
            $('#btnLogin').css('display', 'none');
            $('#btnForgotPwd').css('display', 'block');

            $('#Forgotpwd').css('display', 'none');
            $('#logincancl').css('display', 'block');
        }

        function CancelForgotPwd() {
            $('#trforgotpwd').css('display', 'none');
            $('#btnLogin').css('display', 'block');
            $('#btnForgotPwd').css('display', 'none');

            $('#Forgotpwd').css('display', 'block');
            $('#logincancl').css('display', 'none');
        }

        $('#frmid').ready(function () {
            $('#loadingMessage').css('display', 'none');
        });
        $('#frmid').load(function () {
            $('#loadingMessage').css('display', 'none');
        });
    </script>

<link rel="shortcut icon" href="images/showsline-favicon.ico" /><!--kk-->    
</head>
<body onload=" window.scrollTo(0, 0);">
    <form id="form1" runat="server">
        <asp:HiddenField ID="acc" runat="server" />
        <div class="container">
            <header>
                <div id="topPanel">
                    <div id="panel">
                        <div class="content clearfix">
                            <div class="slideLeft">
                                <!--<span style="color: #c80202;">Not Registered ? Register here for free.</span>-->
                                 <span style="color: #c80202; font-size: small;">Not Registered ? Register here for free.</span> <!--kk login-->
                                <table id="tblRegister">
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: small">First Name</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" runat="server"  Font-Size="Small" Width="250px" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registration_Grp" SetFocusOnError="true" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>                                
                                       
                                    <tr>
                                        <td>
                                            <span style="font-size: small">Last Name</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server"  Font-Size="Small" Width="250px" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registration_Grp" SetFocusOnError="true" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: small">Email ID</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtREmailID" runat="server" Font-Size="Small" Width="250px" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RegisterUserValidate" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registration_Grp" SetFocusOnError="true" ControlToValidate="txtREmailID"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtREmailID" ErrorMessage="*" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <span style="font-size: small">Mobile No.</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Phone" Font-Size="Small" Width="250px" MaxLength="20"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registration_Grp" SetFocusOnError="true" ControlToValidate="txtMobileNo"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CausesValidation="true" ValidationGroup="Registration_Grp"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="slideRight">
                                <!--<span style="color: #c80202">Login</span>-->
                                <span style="color: #c80202; font-size: small;">Sign in</span> <!--kk login-->
                                <table id="tblSignIn">
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: small">Email ID</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" Font-Size="Small" EnableViewState="true" Width="300px" ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameValidate" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Login_Grp" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-size: small">Password</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Font-Size="Small" EnableViewState="true" Width="300px" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="passwordValidate" runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Login_Grp" ControlToValidate="txtPwd"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnLogin" runat="server" Text="Sign In" ClientIDMode="Static" OnClick="btnLogin_Click" CausesValidation="true" ValidationGroup="Login_Grp" />
                                            <asp:Button ID="btnForgotPwd" runat="server" Text="Forgot Password" ClientIDMode="Static" OnClick="btnForgotPwd_Click"  Style="display:none;"/>

                                            <%--<button runat="server" id="btnSignIn" style="height:24px;" title="Sign Into" >Sign In</button>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Literal ID="validateuser" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <a id="Forgotpwd" href="#" onclick="ForgotPwd();">Can't access your account?</a>
                                            <a id="logincancl" href="#" onclick="CancelForgotPwd();" style="display:none;">Cancel</a>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div id="trforgotpwd" style="display:none;">
                                                <span style="color:red"> Please enter your email id above. Then click 'Forgot Password'</span>
                                            </div>
                                        </td>
                                        <td>                                            
                                        </td>
                                    </tr>                                    
                                </table>
                            </div>

                            <a href="#" onclick="CloseLoginPanel();">
                                <img alt="" src="images/error.png" style="height:15px;width:auto;float:left" title="Login Later." />
                            </a>
                        </div>
                    </div>
                    <div class="tab">
                        <div class="login">
                            <div id="toggle" class="dispa" runat="server"><a id="openPanel">San Diego, California | <span>Register/Login</span></a></div> <!-- +kk-->
                            <div id="toggleLogin" class="displayNone" runat="server">San Diego, California | 
                                <label id="lblusername" runat="server" ></label>

                                <%--<asp:Label ID="lblUsrNm" runat="server" Text="" ClientIDMode="Static" EnableViewState="true" ></asp:Label>                                --%>
                                <a href="http://showsline.com/Default.aspx?action=logout" ><span style="color:#F2827C;text-decoration:none;" >Logout</span> </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="banner">
                    <a href="http://showsline.com/Default.aspx?action=logout">
                        <img src="images/showsLive-logo.png" class="logo" alt="ShowsLive" /> </a>
                    <!--kk logo-->
                    <!--<div class="bannerLeader" style="width: 760px; height: 95px; float: left; overflow: hidden;">-->
                    <div class="bannerLeader" style="width: 700px; height: 95px; float: left; overflow: hidden;">
                        <div style="float: left;">
                            <a href='#'>
                                <img id="bannerImg" runat="server" style="width: 700px; height: 95px;" src='http://nohunting.wildwalks.com/sites/default/files/No_Hunting_Banner728x90.png' alt='' title='' /></a>
                        </div>
                    </div>
                    <!--<img src="images/icon-beta.gif" style="height:20px"/>-->
                </div>
                <nav class="mainNav">
                    <ul>
                        <li><a href="http://showsline.com/Default.aspx?action=logout">Home</a></li>
                        <li>|</li>
                        <li><a href="#" onclick="javascript:LoadPage('events-Details.aspx',this)">Event &amp; Venue</a></li>
                        <li>|</li>
                        <li><a href="#" onclick="javascript:LoadPage('GalleryImage.aspx',this)">Gallery</a></li>
                        <%--<li><a href="#">Gallery</a></li>--%>
                        <li>|</li>

                      <%--  <li><a href="#">Service</a></li>
                        <li>|</li>--%>
                        <%--<li><a href="#" onclick="javascript:LoadPage('WebSite/MyAccount.aspx',this)">My Account</a></li>--%>
                        <li><a href="#" runat="server" id="myaccount" onserverclick="myaccount_ServerClick">My Account</a></li>
                       <%-- <li>|</li>
                        <li><a href="#">About Us</a></li>--%>
                    </ul>
                   
                    <div class="search">                        
                             
                            <input type="text" placeholder="Search for (e.g. Events, Venues...)" name="search" class="round" runat="server" id="searchBy"/>                         
                           
                          
                           <input type="submit" class="corner" value=" " runat="server" id="searchfor" onserverclick="searchfor_ServerClick" />

                            <%--<input type="submit" class="corner"  runat="server" id="searchfor" onserverclick="search_ServerClick" />--%>                       
                           
                    </div>
                    <div class="search" style="float:right" >
                       
                    </div>

                </nav>
                <nav class="subNav">
                    <ul>
                        <li><a href="#" onclick="javascript:LoadPage('events-Details.aspx',this);">Concert</a></li>
                        <li>|</li>
                        <li><a>Sports</a></li>
                        <li>|</li>
                        <li><a>Theater</a></li>
                        <li>|</li>
                        <li><a>Business</a></li>
                        <li>|</li>
                        <li><a>Conventions</a></li>
                        <li>|</li>
                        <li><a>Festivals</a></li>
                        <li>|</li>
                        <li><a>Food &amp; Drink</a></li>
                        <li>|</li>
                        <li><a>Movies/Film</a></li>
                    </ul>
                </nav>
            </header>
            <section>
                <div class="flashInfo">
                    <!-- -kk<p>Spin NightClub - To the events of your dreams</p>-->
                </div>
            </section>

            <!-- Content area -->
             <div class="contentMain" style="width:100%">
                <iframe id='frmid' name="PageViewframe" scrolling="no" frameborder="0" width="100%" onload='javascript:resizeIframe(this);' src="ContentMain.aspx">                    
                </iframe>
                 <div id="loadingMessage">Loading...</div>
                <%-- <script type="text/javascript">
                     //if the parent should set the title, here it is
                     document.title = document.getElementById('frmid').contentWindow.document.title;
                 </script>--%>
             </div>
            <footer>
                <div class="footerNavigation">
                    <ul>
                        <li><a href="#">Find Tickets</a>
                            <ul>
                                <li><a href="#" onclick="javascript:LoadPage('events-Details.aspx',this);">Concert</a></li>
                                <li><a href="#">Sports</a></li>
                                <li><a href="#">Conferences</a></li>
                                <li><a href="#">Business</a></li>
                                <li><a href="#">Conventions</a></li>
                                <li><a href="#">Festivals</a></li>
                                <li><a href="#">Food & Drink</a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul>
                        <li><a href="#">Our Company</a>
                            <ul>
                                <li><a href="#" onclick="javascript:LoadPage('/Website/AboutUs.aspx',this)">About Us</a></li>
                                <li><a href="#" onclick="javascript:LoadPage('/Website/ContactUs.aspx',this)">Contact Us</a></li>
                                <!--<li><a href="#">Customer Feedback</a></li>
                                <li><a href="#">Become an Affiliate</a></li>--><!--kk-->
                            </ul>
                        </li>
                    </ul>
                    <div class="socialNetwork">
                        <p id="socialTitle">STAY CONNECTED</p>
                        <ul id="socialConnect">
                            <li><a href="https://twitter.com/SpinNightclub" target="_blank" id="twnt" title="twitter"></a></li>
                            <li><a href="https://www.facebook.com/pages/Spin-Nightclub-SD/125925097473327?fref=ts" target="_blank" id="fb" title="facebook"></a></li>
                            <li><a href="#" id="dig"></a></li>
                            <li><a href="#" id="vmo"></a></li>
                            <li><a target="_blank" href="http://www.youtube.com/results?search_query=spin+nightclub+san+diego&oq=spin+nigh&gs_l=youtube.1.1.0l4.2482.13509.0.17410.15.11.3.1.1.0.842.2686.5j2j0j1j2j0j1.11.0...0.0...1ac.1.11.youtube.tAow0epiqNk" id="utub" title="youtube"></a></li>
                            <li><a href="#" id="skpe"></a></li>
                        </ul>
                    </div>
                </div>
                <p class="copy">Copyright &copy; 2013-2014 Showsline. All Rights Reserved.</p>
            </footer>
        </div>
    </form>
</body>
</html>
