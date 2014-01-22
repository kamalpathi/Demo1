<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events-Details.aspx.cs" Inherits="ShowLineVer3.events_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
           <title>ShowsLine - Event List</title>
        <link href="css/style.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.min.js"></script>
    <script src="js/amazon_scroller.js"></script>
    <script src="js/desSlideshow.js"></script>
    <script src="js/jquery.msgBox.js"></script>
    <link href="css/msgBoxLight.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#desSlideshow2").desSlideshow({
                autoplay: 'enable',//option:enable,disable
                slideshow_width: '616',//slideshow window width
                slideshow_height: '315',//slideshow window height
                thumbnail_width: '220',//thumbnail width
                time_Interval: '4000',//Milliseconds
                directory: 'images/'// flash-on.gif and flashtext-bg.jpg directory
            });

            $("#amazon_scroller1").amazon_scroller({
                scroller_title_show: 'disable',
                scroller_time_interval: '8000',
                scroller_window_background_color: "#dfdddd",
                scroller_window_padding: '10',
                scroller_border_size: '0',
                scroller_border_color: '#000',
                scroller_images_width: '124',
                scroller_images_height: '100',
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
        function CheckValidation(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents
            });
            OpenLoginPanel();
        }

        function OpenLoginPanel() {
            $("div#panel").slideToggle("slow");
            $("#toggle").toggleClass("open");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="contentMain" style="width: 100%">
            <div class="contentWraper">
                <div class="columnLeft">
<!-- -kk
                    <div class="homeWidgets">
                        <asp:Repeater ID="EventDetails" runat="server">
                            <HeaderTemplate>
                                <table style="border: 1px solid #df5015; width: 600px; height: 100px;" cellpadding="0">
                                    <tr style="background-color: #df5015; color: White">
                                        <td colspan="2">
                                            <b>All Events</b>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="background-color: #EBEFF0">
                                    <td style="vertical-align: top;">
                                        <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px; height: 100px;">
                                            <tr>
                                                <td style="width:100px">
                                                    <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                        <image src="<%# Eval("ImagePath") %>" width="73" height="75" style="margin-right: 8px; border-top-color: #ccc; border-right-color: #ccc; border-bottom-color: #ccc; border-left-color: #ccc; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; float: left;"></image>
                                                    </a>
                                                </td>                                               
                                                <td style="vertical-align: top;">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%> ">
                                                                    <asp:Label ID="lblEventTitle" runat="server" Text='<%#Eval("EventTitle") %>' Font-Bold="true" Font-Size="Small" />
                                                                    -
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EventDate")%>' Font-Bold="true" Font-Size="10px" />
                                                                     
                                                                </a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblVenueName" runat="server" Text='<%#Eval("VenueName") %>' Font-Bold="true" Font-Size="Small" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEventDesc" runat="server" Text='<%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>125)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,125) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>' Font-Size="Smaller" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
    -->
                    <div class="homeWidgets">
                        <div id="tab-box">
                            <div id="nav">
                                <ul id="main-nav">

                                    <!-- +kk -->
                                    <div class="bannerLeader" style="width: 655px; height: 90px; float: left; overflow: hidden;">
                                        <div style="float: left;">
                                            <img id="bannerImg" runat="server" style="width: 655px; height: 90px;" src='images/events1.jpg' alt='' title='' /></a>
                                        </div>
                                    </div>
                                    
                                    
                                    <table style="border: 5px solid #1b1b1b; width: 655px; height: 25px;" cellpadding="0">
                                        <tr style="background-color: #1b1b1b; color: White">
                                            <td colspan="1">
                                                <b>&nbsp;&nbsp;&nbsp;CHOOSE AN EVENT</b>
                                            </td>
                                        </tr>
                                        </table>
                                    

<!--                                    <li><a href="#tab-1">All Events - Choose your favorite event and book your ticket &nbsp; &nbsp; &nbsp; &nbsp;</a></li>-->
                                    <!--<li><a href="#tab-2">Sports</a></li>
                                    <li><a href="#tab-3">Theater</a></li>
                                    <li><a href="#tab-4">Food & Drink</a></li>--> <!-- -kk -->
                                </ul>
                                <!--<span><a href="#">View all &raquo;</a></span>--> <!-- -kk -->
                            </div>
                            <!-- end #nav -->

                            <div id="content">
                                <div class="tab-content" id="tab-1">
                                    <asp:Repeater ID="rcontent" runat="server">
                                        <ItemTemplate>
                                            <div style="height: 100px">
                                                <h3><a title='<%# Eval("EventTitle")%>' href='events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>'><%# Eval("EventTitle")%></a><span style='color: red;'>&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "EventDate", "{0:dddd d MMMM}") %> &nbsp&nbsp</span><span style='color: rgb(60,133,186);'><%# Eval("VenueName")%></span> </h3>
                                                <p>
                                                    <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                        <%--<img src="<%# Eval("SmallImagePath")%>" width='75' height='75' alt='tag' />--%>
                                                        <img src="<%#(((string)DataBinder.Eval(Container.DataItem, "SmallImagePath")).Length>0)?DataBinder.Eval(Container.DataItem, "SmallImagePath"):DataBinder.Eval(Container.DataItem, "ImagePath")%>" width='75' height='75' alt='tag' />
                                                    </a>
                                                    <%--<%# Eval("EventDesc")%>--%>
                                                    <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>300)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,300) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                    <br />
                                                </p>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:Repeater>                                    
                                </div>
                                
                            </div>
                        </div>
                        <!-- end #tab-box -->

                    </div>
                </div>
                <div class="columnRight_wo_padding"> <!-- -kk -->
                    <div class="asideWraper"> <!-- -kk style="height: 315px"> -->
                        <div class="aside">
                            <h3>Upcoming Events</h3>
                            <div class="asideData">
                                <ul>
                                    <li>Dance & Electronic Music
                 
                                            <ul>
                                                <asp:Repeater ID="rQuickBook" runat="server">
                                                    <ItemTemplate>
                                                        <li><a href="events-List.aspx?ID=<%# Eval("EventID") %>&EN= <%# Eval("EventTitle") %> "><%# Eval("EventTitle")%>  -  <%# Eval("EventDate")%></a></li>
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
                            <div class="asideData"> <!-- -kk  style="height: 310px"> -->
                                <ul>
                                    <asp:Repeater ID="rFeatured" runat="server">
                                        <ItemTemplate>
                                            <li><a href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%> -  <%# Eval("EventDate")%></a>
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
                                <!--<img src="images/video-thumb.gif" />-->
                                    <iframe width="292" height="300"
                                    src="http://www.youtube.com/embed/mpmkdJL54x8">
                                    </iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
