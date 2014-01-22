<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentMain.aspx.cs" Inherits="ShowLineVer3.ContentMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>ShowsLine - Venue Promotions and Ticketing</title>
        <link href="css/style.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.5.1.min.js"></script>
     <!--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.min.js"></script>--> <!-- -kk -->
    <script src="js/amazon_scroller.js"></script>
    <script src="js/desSlideshow.js"></script>
    <script src="js/jquery.msgBox.js"></script>
    <link href="css/msgBoxLight.css" rel="stylesheet" />

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
                scroller_title_show: 'enable',//+kk'disable',
                scroller_time_interval: '8000',
                scroller_window_background_color: "#dfdddd",
                scroller_window_padding: '10',
                scroller_border_size: '',
                scroller_border_color: '#bcbcbc',
                scroller_images_width: '133',//+kk'124',
                scroller_images_height: '200',//+kk '100',
                scroller_title_size: '12',
                scroller_title_color: 'blue',//+kk 'black',
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

        function LogingCheckout() {           
            __doPostBack('chklogin', '')
        }

        function ShowProcessing(id) {
            parent.OpenLoginCheckout(id);
        }

    </script>

</head>
<body onload=" window.scrollTo(0, 0);">
    <form id="form1" runat="server">
    <div class="contentMain" style="width:100%">
                <div class="contentWraper">
                    <div class="columnLeft">
                        <div class="sliderContainer">
                            <div id="desSlideshow2" class="desSlideshow">

                                <div class="switchBigPic">
                                    <asp:Repeater ID="rswitchBigPic" runat="server">
                                        <ItemTemplate>
                                            <div>
                                                <%--//CHECK--%>  <!-- +kk EventTitle added-->
                                              
                                                <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                    <img class="pic" src="<%# Eval("ImagePath")%>" height="315" width="745"/>  <!-- +kk 616 -->
                                                </a>
                                                 <!--<p>
                                                      <strong><%# Eval("EventTitle")%></strong><br />
                                                      <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>150)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,150) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                 </p>-kk -->
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>

                                <ul class="nav">
                                    <asp:Repeater ID="rnav" runat="server">
                                        <ItemTemplate>
                                            <li><a onclick="" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%><br />
                                                <%# Eval("EventDate")%></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>                                    
                                </ul>

                            </div>
                        </div>
                        <div class="homeWidgets">
                            <div id="amazon_scroller1" class="amazon_scroller">
                                <div class="amazon_scroller_mask">
                                    <ul>
                                        <asp:Repeater ID="ramazon_scroller_mask" runat="server">
                                            <ItemTemplate> <!-- +kk EventTitle added--> 
                                                <li><a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                  
                                                    <img src="<%# Eval("SmallImagePath")%>" width="130" height="180" alt="tag" /></a></li>
                                                    
                                            </ItemTemplate>
                                        </asp:Repeater>                                        
                                    </ul>
                                </div>
                                <ul class="amazon_scroller_nav">
                                    <li></li>
                                    <li></li>
                                </ul>
                                <div style="clear: both"></div>
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
                                    <span><a href="events-Details.aspx">View all &raquo;</a></span>
                                </div>
                                <!-- end #nav -->

                                <div id="content">
                                    <div class="tab-content" id="tab-1">
                                        <asp:Repeater ID="rcontent" runat="server">
                                            <ItemTemplate>
                                                <div style="height:100px">                                                    
                                                    <h3><a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%></a><span style='color:red;'>&nbsp;&nbsp;&nbsp;<%# Eval("EventDate")%></span></h3>                                                
                                                    <p>
                                                        <a title="<%# Eval("EventTitle")%>" href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>">
                                                            <img src="<%# Eval("SmallImagePath")%>"  width='75' height='75' alt='tag'/>
                                                        </a>
                                                        
                                                        <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>300)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,300) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                        <br />                                                       
                                                    </p>
                                                </div>
                                                 <hr />
                                                </ItemTemplate>
                                        </asp:Repeater>

                                        <span><a style='color:red;' href="events-Details.aspx">View all &raquo;</a></span> <!-- +kk added-->
                                    </div>

                                    <!-- kk modified-->
                                    <div class="tab-content" id="tab-2">
                                        <h3>No Sports Events.</h3>                                        
                                    </div>

                                    <div class="tab-content" id="tab-3">
                                        <h3>No Theater Events.</h3>                                        
                                    </div>

                                    <div class="tab-content" id="tab-4">
                                        <h3>No New Events. </h3>                                        
                                    </div>

                                </div>
                            </div>
                            <!-- end #tab-box -->

                        </div>
                    </div>
                    <div class="columnRight">
                        <div class="asideWraper"> <!-- -kk style="height:315px;overflow:auto;"> -->
                            <div class="aside">
                                <h3>Upcoming Events</h3>
                                <div class="asideData" >
                                    <ul>
                                        <li>Dance & Electronic Music
                 
                                            <ul>
                                                <asp:Repeater ID="rQuickBook" runat="server">
                                                    <ItemTemplate>
                                                        <li><a href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%>  -  <%# Eval("EventDate")%></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                            </ul>
                                        </li>                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- Aside 1 end-->

                        <div class="asideWraper">
                            <div class="aside">
                                <h3>Featured Shows</h3>
                                <div class="asideData" > <!-- -kk style="height:310px">-->
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
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="asideWraper">
                            <div class="aside">
                                <div class="asideData" style="text-align: center">                                    
                                    <!--kk-->
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
