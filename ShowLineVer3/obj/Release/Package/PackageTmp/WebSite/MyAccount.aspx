<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="ShowLineVer3.WebSite.MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <link href="../css/styleInner.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contentMain" style="width: 100%">
            <div class="contentWraper">
                <div class="columnLeft">

                    <div class="homeWidgets">
                        <div class="contentContainer">
                            <h2>My Account</h2>
                            <div class="contentWidgets">
                                <div class="contentInnerWrap">
                                    <h3>Personal Information</h3>
                                    <p><strong>Name:</strong> Christoph Waltz</p>
                                    <p><strong>Email:</strong> ChristophWaltz@hotmail.com</p>
                                    <p><strong>Mobile:</strong> +1-541-754-3010</p>
                                </div>
                            </div>
                            <div class="contentWidgets">
                                <div class="contentInnerWrap">
                                    <h3>My Bookings</h3>
                                    <p><strong>UFC 160 Tickets</strong> <span class="date">25 May,2013 - 10:53PM</span></p>
                                    <p><strong>NASCAR Tickets</strong> <span class="date">28 May,2013 - 10:53PM</span></p>
                                    <p><strong>UFC 160 Tickets</strong> <span class="date">25 May,2013 - 10:53PM</span></p>
                                    <p><strong>NASCAR Tickets</strong> <span class="date">28 May,2013 - 10:53PM</span></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="homeWidgets">
                        <div id="tab-box">
                            <div id="nav">
                                <ul id="main-nav">
                                    <li><a href="#tab-1">Concert</a></li>
                                    <li><a href="#tab-2">Sports</a></li>
                                    <li><a href="#tab-3">Theater</a></li>
                                    <li><a href="#tab-4">Food & Drink</a></li>
                                </ul>
                                <span><a href="#">View all &raquo;</a></span>
                            </div>
                            <!-- end #nav -->

                            <div id="content">
                                <div class="tab-content" id="tab-1">
                                    <asp:Repeater ID="rcontent" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 100px">
                                                <h3><a title='<%# Eval("EventTitle")%>' href='events-List.aspx?ID="<%# Eval("EventID")%>"&EN="<%# Eval("EventTitle")%>"'><%# Eval("EventTitle")%></a><span style='color: red;'>&nbsp;&nbsp;&nbsp;<%# Eval("EventDate")%></span></h3>
                                                <p>
                                                    <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                        <img src="<%# Eval("ImagePath")%>" width='75' height='75' alt='tag' />
                                                    </a>
                                                    <%--<%# Eval("EventDesc")%>--%>
                                                    <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>300)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,300) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                    <br />
                                                </p>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <%-- <h3>Lorem ipsum dolor sit amet</h3>
                                        <p>
                                            <img src="images/bob-dylan-tickets-75x75.jpg" />"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                        </p>
                                        <p>"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>--%>
                                </div>

                                <div class="tab-content" id="tab-2">
                                    <h3>Lorem ipsum dolor sit amet</h3>
                                    <p>
                                        <img src="images/black-sabbath-tickets-75x75.jpg" />Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </p>
                                </div>

                                <div class="tab-content" id="tab-3">
                                    <h3>Lorem ipsum dolor sit amet</h3>
                                    <p>
                                        <img src="images/american-idol-live-tickets-75x75.jpg" />Nullam sit amet nulla et massa tempor porttitor at et orci. Aliquam a eros eu erat facilisis sodales. Donec a massa nisl, eu egestas nisi. Nullam magna lacus, pulvinar in placerat eget, viverra sed dui.
                                    </p>
                                </div>

                                <div class="tab-content" id="tab-4">
                                    <h3>Lorem ipsum dolor sit amet</h3>
                                    <p>
                                        <img src="images/bob-dylan-tickets-75x75.jpg" />Nullam sit amet nulla et massa tempor porttitor at et orci. Aliquam a eros eu erat facilisis sodales. Donec a massa nisl, eu egestas nisi. Nullam magna lacus, pulvinar in placerat eget, viverra sed dui.
                                    </p>
                                    <p>Nullam sit amet nulla et massa tempor porttitor at et orci. Aliquam a eros eu erat facilisis sodales. Donec a massa nisl, eu egestas nisi. Nullam magna lacus, pulvinar in placerat eget, viverra sed dui.</p>
                                </div>

                            </div>
                        </div>
                        <!-- end #tab-box -->

                    </div>
                </div>
                <div class="columnRight">
                    <div class="asideWraper" style="height: 315px">
                        <div class="aside">
                            <h3>Quick Booking</h3>
                            <div class="asideData">
                                <ul>
                                    <li>Dance & Electronic Music
                 
                                            <ul>
                                                <asp:Repeater ID="rQuickBook" runat="server">
                                                    <ItemTemplate>
                                                        <li><a href="events-List.aspx?ID=<%# Eval("EventID") %>&EN= <%# Eval("EventTitle") %> "><%# Eval("EventTitle")%></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <%--<li><a href="#">Popular Tours</a></li>
                                                <li><a href="#">Country Music</a></li>--%>
                                            </ul>
                                    </li>
                                    <%--<li>Sports
                 
                                            <ul>
                                                <li><a href="#">MLB Baseball</a></li>
                                                <li><a href="#">NBA Basketball</a></li>
                                                <li><a href="#">NHL Hockey</a></li>
                                            </ul>
                                        </li>
                                        <li>Theater
                 
                                            <ul>
                                                <li><a href="#">Musicals</a></li>
                                                <li><a href="#">Family Shows</a></li>
                                            </ul>
                                        </li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <!-- Aside 1 end-->

                    <div class="asideWraper">
                        <div class="aside">
                            <h3>Featured Shows</h3>
                            <div class="asideData" style="height: 310px">
                                <ul>
                                    <asp:Repeater ID="rFeatured" runat="server">
                                        <ItemTemplate>
                                            <li><a href="#"><%# Eval("EventTitle")%></a>
                                                <ul>
                                                    <li>
                                                        <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>150)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,150) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <%--<li><a href="#">UFC 160 Tickets</a>
                                            <ul>
                                                <li>Velasquez vs. Silva in Las Vegas - Catch the battle in the octagon!!</li>
                                            </ul>
                                        </li>
                                        <li><a href="#">NASCAR Tickets</a>
                                            <ul>
                                                <li>The 2013 NASCAR Sprint Cup Race for the Cup will be here soon!</li>
                                            </ul>
                                        </li>
                                        <li><a href="#">Tennis Tickets</a>
                                            <ul>
                                                <li>Watch all the action on the court! Wimbledon, BNP Paribas Open... </li>
                                            </ul>
                                        </li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="asideWraper">
                        <div class="aside">
                            <div class="asideData" style="text-align: center">
                                <img src="~\images/video-thumb.gif" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
