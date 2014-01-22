<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="ShowLineVer3.WebSite.Confirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <!--<link href="../css/styleInner.css" rel="stylesheet" />-->
    <!--k-->
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/styleInner.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <div class="banner">
                    <a href="http://www.showsline.com/default.aspx?action=logout">
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

                <div class="contentMain">
                    <div class="contentWraper">
                        <div class="columnLeft">
                            <div class="contentContainer">

                                <div class="contentWidgets" style="margin-top: 0px;">
                                    <span class="status">Congratulations ! Your ticket has been booked.</span>
                                    <span class="order">Order #
                                    <asp:Label ID="transactionID" runat="server" Text="1345"></asp:Label>- Please carry a copy of your printed ticket at the venue.
                                    </span>
                                </div>

                                <br style="clear: both" />
                                <br style="clear: both" />
                                <span class="single-row">
                                    <input type="button" value="Print Ticket" id="printTicket" class="form-button" runat="server" onclick="window.open('http://showsline.com/Report.aspx?TID=' + $('#hTID').val() + '&TT=ALL');" /></span>
                                <br style="clear: both" />
                                <br style="clear: both" />

                                <!--<h2>Booking Details</h2>-->
                                <!-- kk -->

                                <table style="border: 5px solid #353535; width: 912px; height: 25px;" cellpadding="0">
                                    <tr style="background-color: #353535; color: White">
                                        <td colspan="1">
                                            <b>&nbsp;&nbsp;&nbsp;Booking Details</b>
                                        </td>
                                    </tr>
                                </table>


                                <div class="contentWidgets">
                                    <!--<p>
                                <img src="images/bob-dylan-tickets-75x75.jpg" id="EvtImage" runat="server" style="width: 150px; height: 150px" />
                            </p>-->
                                    <div class="eventDetails">
                                        <h4>
                                            <asp:Label ID="eventName" runat="server" Text="Label" Font-Size="Medium" Font-Bold="true" Style="color: red"></asp:Label></h4>

                                        <!--<p><strong>Venue :</strong></p>-->
                                        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Venue :  &nbsp;<asp:Label ID="VenueDetails" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                        <br />
                                        <h3>Date & Time : &nbsp;<asp:Label ID="eventDate" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                        <!-- kk-->
                                        <br />
                                        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location : &nbsp;<asp:Label ID="lblStreetAddress" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                        <h3>&nbsp;<asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true" Style="margin-left: 95px;"></asp:Label>
                                            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true"></asp:Label>--%>
                                        </h3>
                                        <h3>&nbsp;<asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true" Style="margin-left: 95px;"></asp:Label>
                                            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true"></asp:Label>--%>
                                        </h3>
                                        <h3>&nbsp;<asp:Label ID="lblZip" runat="server" Text="Label" Font-Bold="true" Style="margin-left: 95px;"></asp:Label>
                                        </h3>

                                        <br />
                                        <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name :  &nbsp;<asp:Label ID="customerName" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>



                                        <br />
                                        <p>
                                            <asp:Repeater ID="rptTicketDetails" runat="server">
                                                <HeaderTemplate>
                                                    <!--<table cellspacing="5px" cellpadding="25px">-->
                                                    <table style="border: 1px solid #c80202; height: auto; font-size: 14px" cellspacing="5px" cellpadding="25px">
                                                        <tr style="color: maroon">
                                                            <td style="font-size: medium;"><strong>&nbsp;&nbsp;&nbsp;Ticket Type</strong></td>
                                                            <td style="font-size: medium;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No. of Tickets</strong></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="font-size: small;"><strong>&nbsp;&nbsp;&nbsp;<%# Eval("TICKETTYPE")%></strong></td>
                                                        <td style="font-size: small;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("entry")%></strong></td>
                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </p>

                                        <p>
                                            <br style="clear: both" />
                                            <span>For assistance call (888) 312-8886 or email info@showsline.com</span>
                                        </p>

                                        <p>
                                            <span style="color: maroon">Note: Print-at-home tickets can be printed any time before event date from "My Account>> Booking History"</span>
                                        </p>

                                    </div>
                                </div>
                                <br clear="all" />
                                <br clear="all" />
                                <span class="single-row">
                                    <input type="button" value="Back To Home" class="form-button" runat="server" id="btnBookAnotherTicket" onserverclick="btnBookAnotherTicket_ServerClick"></span>
                                <asp:HiddenField ID="hTID" runat="server" />
                            </div>

                        </div>


                    </div>
                </div>
            </nav>

            <!--kk footer-->
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
