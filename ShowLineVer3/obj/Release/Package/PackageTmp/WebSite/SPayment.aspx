<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPayment.aspx.cs" Inherits="ShowLineVer3.WebSite.SPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1"/>

    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <link href="css/style.css" rel="stylesheet" />

    <link href="css/styleInner.css" rel="stylesheet" />
    <!-- +kk -->
    <script src="js/jquery-1.9.1.min.js"></script>
    <script src="js/scripts.js"></script>
    <script src="js/jquery.timer.js"></script>
    <script src="js/jquery.msgBox.min.js"></script>
    <link href="css/msgBoxLight.css" rel="stylesheet" />
    <script src="js/showsline.js"></script>

    <style type="text/css">
        #time-left
        {
            position: fixed;
            right: 0;
            top: 50%;
            width: 8em;
            margin-top: -2.5em;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            var timer = new (function () {
                var $countdown,
                    $form, // Form used to change the countdown time
                    incrementTime = 70,
                    currentTime = 60000,

                    updateTimer = function () {
                        $('.countdown').html(formatTime(currentTime));
                        if (currentTime == 0) {
                            timer.Timer.stop();
                            timerComplete();
                            return;
                        }
                        currentTime -= incrementTime / 10;
                        if (currentTime < 0) currentTime = 0;
                    },
                    timerComplete = function () {
                        Msg('Time completed. Ticket alloted will be sent back to process.', 'Timeout');
                    },
                    init = function () {
                        $countdown = $('.countdown');
                        timer.Timer = $.timer(updateTimer, incrementTime, true);
                    };
                this.resetCountdown = function () {
                    var newTime = parseInt($form.find('input[type=text]').val()) * 100;
                    if (newTime > 0) { currentTime = newTime; }
                    this.Timer.stop().once();
                };
                $(init);
            });

            function formatTime(time) {
                var min = parseInt(time / 6000),
                    sec = parseInt(time / 100) - (min * 60),
                    hundredths = pad(time - (sec * 100) - (min * 6000), 2);
                return (min > 0 ? pad(min, 2) : "00") + ":" + pad(sec, 2) + ":" + hundredths;
            }

            function pad(number, length) {
                var str = '' + number;
                while (str.length < length) { str = '0' + str; }
                return str;
            }

            function Msg(msgcontents, msgHeader) {
                $.msgBox({
                    title: msgHeader,
                    content: msgcontents,
                    type: "info"
                });
            }          

        });

        function ShowLoading() {
            $('#btnSubmit').attr("disabled", true);
            $('#btnSubmit').val('Please wait Processing');

            document.getElementById('Processing-loading').style.visibility = 'visible';
            document.getElementById('Processing-loading').style.display = 'block';
            ////__doPostBack('btnCheckOut', '')
            //alert('1');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div id="Processing-loading" style="display: none; visibility: hidden; position: absolute;">
            <img src="images/ajax-loader.gif" class="ajax-spinner" alt="" height="31" width="31" />
            Processing...
        </div>--%>

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="container">
            <header>
                <div class="banner">
                    <a href="http://www.showsline.com/default.aspx?action=logout">
                        <!--<img src="images/showsLive-logo.png" class="logo" alt="ShowsLive" style="width: 200px" /> kk-->
                        <img src="images/showsLive-logo.png" class="logo" alt="ShowsLive" />
                    </a>
                    <!--kk logo-->

                    <div class="bannerLeader" style="width: 700px; height: 95px; float: left; overflow: hidden;">
                        <div style="float: left;">
                            <a href='#'>
                                <img id="bannerImg" runat="server" style="width: 700px; height: 95px;" src='http://nohunting.wildwalks.com/sites/default/files/No_Hunting_Banner728x90.png' alt='' title='' /></a>
                        </div>
                    </div>
                    <!--<img src="images/icon-beta.gif" style="height: 20px" />-->
                </div>
            </header>
            <nav class="mainNav">
                <div class="contentMain" style="width: 100%">
                    <div id="Processing-loading" style="display: none; visibility: hidden; position: absolute;">
                        <img src="images/ajax-loader.gif" class="ajax-spinner" alt="" height="31" width="31" />
                        Please Don't Click Refresh or Back Button. Connecting to server ..... 
                    </div>

                    <div class="container" style="width: 100%">
                        <!-- Content area -->
                        <div class="time-left">
                            <span>Time left to complete page</span>
                            <span class='countdown' style="float: right; clear: none"></span>
                            <%--<label>4:50</label>--%>
                        </div>
                        <!-- -kk <br style="clear: both;" />
            <p></p>-->
                        <center>
            <div class="contentMain">
                <div class="contentWraper">
                     <div class="columnLeft">  
                    <div class="contentContainer">
                        <!--<h2>REVIEW</h2>-->  <!-- kk -->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 900px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;REVIEW</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>

                        <div class="contentWidgets">
                            <p>
                                <img src="http://www.showsline.com/images/bob-dylan-tickets-75x75.jpg" id="EvtImage" runat="server" style="width: 150px; height: 150px" />
                            </p>
                            <div class="eventDetails">
                                <h4>
                                    <asp:Label ID="lblEventName" runat="server" Text="Label" Font-Size="Medium" Font-Bold="true" Style="color: maroon"></asp:Label></h4>
                                <!--<p><strong>Venue :</strong></p>-->
                                <h3> Venue : </h3>
                                <p>
                                    <asp:Label ID="lblVenueName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <br />
                                <h3>Date & Time :</h3> <!-- kk-->
                                <p>
                                   <asp:Label ID="lblDateTime" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <br/>
                                <!--<p>
                                    <strong>Location :</strong>
                                </p>-->
                                <h3>Location :</h3>
                                <p>
                                    <asp:Label ID="lblStreetAddress" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblZip" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                            </div>                           
            

                            <div class="kkbox">
                                <div>
                                    <asp:Repeater ID="rptPayment" runat="server" OnItemDataBound="rptPayment_ItemDataBound">
                                        <HeaderTemplate>
                                            <table style="border: 1px solid #c80202; width: 95%; height: auto; font-size: 14px" cellpadding="0">
                                                <tr style="background-color: #c80202; color: White">
                                                    <td style="width: 100px">Ticket type</td>
                                                    <td style="width: 50px">Qty</td>
                                                    <td style="width: 50px">Amt</td>
                                                    <td style="width: 50px">Total</td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="margin-top: 5px; padding-top: 5px"><%# Eval("TicketType")%></td>
                                                <td><%# Eval("Qty")%></td>
                                                <td><%# Eval("TicketPrice")%></td>
                                                <td><%# Eval("AMT")%></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <td colspan="4">
                                                    <hr />
                                                </td>
                                              
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left">
                                                    <span class="SummaryFont">Sub Total</span>
                                                </td>
                                                <td style="text-align: center"><span class="SummaryFont">$ <%#SubtotalP()%></span></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <hr />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left"><span class="SummaryFont">Processing Fee</span></td>
                                                <td style="text-align: center"><span class="SummaryFont">$ 0.0</span></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <hr />
                                                </td>

                                            </tr>
                                            
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left; margin-bottom: 15px; padding-bottom: 15px; color:red;"><span class="SummaryFont">Total Amt</span></td>
                                                <td style="text-align: center; margin-bottom: 15px; padding-bottom: 15px; color:red;"><span class="SummaryFont">$ <%#SubtotalP()%></span></td> <!--kk-->
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </div>

                               
                            </div>
                        </div>

                        <br style="clear: both" />
                        <br style="clear: both" />

                        <!--<h2>PAYMENT</h2>-->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 912px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;PAYMENT</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>



                        <div class="contentWidgets">
                            <div class="contentInnerWrap">
                                <p>
                                    <table width="100%" border="0" cellpadding="10" cellspacing="1">
                                        <tr>
                                            <td width="35%">
                                                <p><strong>Select Payment Method</strong></p>
                                            </td>
                                            <td colspan="2">
                                                <p><strong>Payment Details</strong></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p>
                                                    <input type="radio" checked="checked" />Credit Card
                                                </p>
                                               
                                                <p>
                                                    <img src="../images/visa-master.jpg" class="card" />
                                                </p>
                                            </td>
                                             <td>
                                                <p>
                                                    Card Holder Name
                                                    <asp:TextBox ID="txtCard" runat="server" autocomplete="off" EnableViewState="false" ViewStateMode="Disabled" onKeyPress="return ValidateName(this,event)"></asp:TextBox>
                                                </p>
                                            </td>
                                            

                                            <td>
                                                <p>
                                                    Credit Card Number							                       
                                                    <asp:TextBox id="txtCardNumber" runat="server" MaxLength="20" autocomplete="off" EnableViewState="false" ViewStateMode="Disabled" onKeyPress="return ValidateNum(this,event)"></asp:TextBox>
                                                </p>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td></td>
                                            <td>
                                                <p>Expiry Date</p>
                                            </td>
                                            <td>
                                                <p>Security Code</p>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td>
                                                <p>

                                                    <asp:DropDownList ID="ccMonth" runat="server">
                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>

                                                    <select name="ccYear" runat="server" id="ccYear">
                                                        <option value="13">2013</option>
                                                        <option value="14">2014</option>
                                                        <option value="15">2015</option>
                                                        <option value="16">2016</option>
                                                        <option value="17">2017</option>
                                                        <option value="18">2018</option>
                                                        <option value="19">2019</option>
                                                        <option value="20">2020</option>
                                                        <option value="21">2021</option>
                                                        <option value="22">2022</option>
                                                        <option value="23">2023</option>
                                                        <option value="24">2024</option>
                                                        <option value="25">2025</option>
                                                        <option value="26">2026</option>
                                                        <option value="27">2027</option>
                                                        <option value="28">2028</option>
                                                        <option value="29">2029</option>
                                                        <option value="30">2030</option>
                                                    </select>
                                                </p>
                                            </td>
                                            <td>
                                                <p>
                                                    <asp:TextBox runat="server" size="5" MaxLength="5" ID="txtCVV" autocomplete="off" EnableViewState="false" ViewStateMode="Disabled" onKeyPress="return ValidateNum(this,event)"></asp:TextBox>                                                   

                                                    <a title="For MasterCard, Visa or Discover, it's the last three digits in the signature area on the back of your card. For American Express, it's the four digits on the front of the card." href="#"">Whats this</a>
                                                </p>
                                            </td>

                                        </tr>

                                    </table>

                                </p>
                            </div>
                        </div>



                        <div class="contentWidgets">
                            <div class="contentInnerWrap">
                                <!--       <p><input type="button" class="form-button" value="Submit Order"> <a href="#">Cancel Order</a></p>-->
                                <p class="single-row">                                    
                                    <input type="button" value="Submit Order" class="form-button" runat="server" id="btnSubmit" onclick="javascript:ShowLoading();" onserverclick="btnSubmit_ServerClick"/>
                                    <!--<a href="../ContentMain.aspx"><strong>Cancel Order</strong></a> --kk-->
                                    <a href="http://www.showsline.com/default.aspx?action=logout"><strong>Cancel Order</strong></a> <!--kk-->
                                </p>
                                <p style="text-align: left">By clicking the Submit Order button you are agreeing to the Purchase Policy and Privacy Policy of Showsline. Tickets are non-refundable. All orders are subjected to <br /> the credit card approval. Thank You.</p>
                            </div>
                        </div>


                    </div>

                    </div>

                   
                </div>
            </div>
            </center>
                        <asp:HiddenField ID="totval" runat="server" />
                        <!--kk-->
                    </div>
                </div>
            </nav>
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
                                <li><a href="#">Become an Affiliate</a></li>-->
                                <!--kk-->
                            </ul>
                        </li>
                    </ul>

                    <!--kk auth.net seal-->
                    <ul>
                    <!-- (c) 2005, 2013. Authorize.Net is a registered trademark of CyberSource Corporation --> 
                    <div class="AuthorizeNetSeal"> <script type="text/javascript" language="javascript">var ANS_customer_id = "1fb54ae8-f7ee-42eb-804b-60dc726dff54";</script> <script type="text/javascript" language="javascript" src="//verify.authorize.net/anetseal/seal.js" ></script> <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Payment Processing</a> </div>
                    </ul>

                    <!--<div class="socialNetwork">
                        <p id="socialTitle">STAY CONNECTED</p>
                        <ul id="socialConnect">
                            <li><a href="https://twitter.com/SpinNightclub" target="_blank" id="twnt" title="twitter"></a></li>
                            <li><a href="https://www.facebook.com/pages/Spin-Nightclub-SD/125925097473327?fref=ts" target="_blank" id="fb" title="facebook"></a></li>
                            <li><a href="#" id="dig"></a></li>
                            <li><a href="#" id="vmo"></a></li>
                            <li><a target="_blank" href="http://www.youtube.com/results?search_query=spin+nightclub+san+diego&oq=spin+nigh&gs_l=youtube.1.1.0l4.2482.13509.0.17410.15.11.3.1.1.0.842.2686.5j2j0j1j2j0j1.11.0...0.0...1ac.1.11.youtube.tAow0epiqNk" id="utub" title="youtube"></a></li>
                            <li><a href="#" id="skpe"></a></li>
                        </ul>
                    </div>-->
                </div>
                <p class="copy">Copyright &copy; 2013-2014 Showsline. All Rights Reserved.</p>
            </footer>
        </div>
    </form>
</body>
</html>
