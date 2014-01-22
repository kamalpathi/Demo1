<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events-List.aspx.cs" Inherits="ShowLineSite.events_List"  EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1"/>

     <title>ShowsLine - Event Details</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link href="css/EventList.css" rel="stylesheet" />
    <link href="css/SignUpStyle.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/liststyle.css" rel="stylesheet" />    
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="js/amazon_scroller.js"></script>
    <script src="js/desSlideshow.js"></script>
    <script src="js/jquery.msgBox.js"></script>
    <script src="js/jquery.msgBox.min.js"></script>
    <link href="css/msgBoxLight.css" rel="stylesheet" />
    <script src="js/common.js"></script>

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

        function ShowProcessing(id) {
            document.getElementById('Processing-loading').style.visibility = 'hidden';
            document.getElementById('Processing-loading').style.display = 'none';
            alert('Please Login To Book The Ticket.');
            parent.OpenLoginCheckout(id);            
        }

        function ShowLoading() {
            $('#btnCheckOut').attr("disabled", true);
            $('#btnCheckOut').val('Please wait Processing');

            document.getElementById('Processing-loading').style.visibility = 'visible';
            document.getElementById('Processing-loading').style.display = 'block';
            __doPostBack('btnCheckOut', '')
        }

        function StopLoading() {
            $('#btnCheckOut').attr("disabled", false);
            $('#btnCheckOut').val('CHECKOUT');

            document.getElementById('Processing-loading').style.visibility = 'hidden';
            document.getElementById('Processing-loading').style.display = 'none';
        }

        function SubmitChekout() {
            StopLoading();

            alert('You must purchase at least 1 ticket');
        }

        //window.myFunction = function () {
        //    LogingCheckout();
        //}

        function LogingCheckoutCM() {
            alert('1');
        }


    </script>

    <script type="text/javascript">
        function Msg(msgcontents, msgHeader) {
            StopLoading();
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });
        }

        function LMsg(msgcontents, msgHeader) {            
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info",
                buttons: [{ value: "Ok" }]               
            });
        }

        function EMsg(msgcontents, msgHeader) {
            StopLoading();
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info",
                afterShow: function (result) { ShowProcessing(); }
            });
        }

        function ShowSignIn() {
            $("#dSignIn").dialog("open");
        }
    </script>
</head>


<body style="height:auto" onload=" window.scrollTo(0, 0);">
    <form id="form1" runat="server">
        <div id="Processing-loading" style="display: none; visibility: hidden; position: absolute;">
            <img src="images/ajax-loader.gif" class="ajax-spinner" alt="" height="31" width="31" />
            Processing...
        </div>

        <div class="contentMain" style="z-index: 100;">
            <br />
            <div class="right-main col8" style="padding-right:17px">  <!-- kk 17px-->
                <div class="box-container">
                    <div class="ticketing-types-bottom-box">
                        <div class="tab-top float-l">
                            <h4>BUY TICKETS</h4>
                        </div>
                        <div class="clear-l"></div>
                        <div class="box box-tab buy-tickets-box-types">
                            <div class="info-box important-info">
                                <div class="icons important-icon float-l"></div>
                                <p>
                                     Maximum 10 tickets can be booked in a transaction. Delivery Type: Print-at-home.  <!-- kk -->
                                </p>
                            </div>
                            <div class="grouping-dropdown">
                                <div class="add-to-order-regular">
                                    <div class="grouping-list">
                                        <asp:Repeater ID="rptTicketDetails" runat="server">
                                            <HeaderTemplate>
                                                <div class="table-head">
                                                    <div class="ticket-type column float-l">TICKET TYPE</div>

                                                    <div class="price column float-l" style="margin-right: 5px">PRICE</div>
                                                    
                                                    <div class="price column float-l" style="margin-right: 5px">SEATS LEFT</div>

                                                    <div class="quantity column float-r">QTY</div>

                                                    <div class="clear-b"></div>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="odd">
                                                    <div class="ticket-type column float-l blue-strong" style="font-size: small">
                                                        <asp:Label ID="lblEventDetails" runat="server" Text='<%# Eval("EVENTPRICEDETAILS")%>'></asp:Label>
                                                    </div>

                                                    <div class="price column float-l" style="font-family:Trebuchet MS; font-size: small; margin-right: 15px">
                                                        $                                                        
                                                         <asp:Label ID="lblEventPrice" runat="server" Text='<%# Eval("EVENTPRICE")%>'></asp:Label>
                                                    </div>

                                                    <div class="price column float-l" style="font-family:Trebuchet MS; font-size: small; margin-right: 15px">                                                                                                                
                                                         <asp:Label ID="lblSeatLeft" runat="server" Text='<%# Eval("SEATLEFT")%>'></asp:Label>
                                                    </div>

                                                    <div class="quantcheck quantity column float-r">
                                                        <asp:DropDownList ID="dd" runat="server" class="changeMe qty">
                                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<select name="tt" id="tt" class="changeMe qty" runat="server">
                                                            <option></option>
                                                            <option value="1">01</option>
                                                            <option value="2">02</option>
                                                            <option value="3">03</option>
                                                            <option value="4">04</option>
                                                            <option value="5">05</option>
                                                            <option value="6">06</option>
                                                            <option value="7">07</option>
                                                            <option value="8">08</option>
                                                            <option value="9">09</option>
                                                            <option value="10">10</option>
                                                        </select>--%>
                                                    </div>
                                                    <div class="clear-b"></div>
                                                    <div class="clear"></div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                        <%--  <ul class="ticket-list">
                                                <asp:PlaceHolder ID="phTicketprice" runat="server">

                                                </asp:PlaceHolder>

                                                

                                            </ul>

                                            <ul class="ticket-list">
                                                <li class="odd"></li>
                                            </ul>--%>
                                    </div>
                                </div>
                            </div>
                            <!--<div class="info-box important-info" style="z-index: 999998"> -kk -->
                                <div class="button-off lrg-btn float-r" id="checkoutbuttondisabled" style="display: block; z-index: auto ">
                                    <asp:Button ID="btnCheckOut" runat="server" Text="CHECKOUT" OnClientClick="javascript:ShowLoading();" UseSubmitBehavior="false" OnClick="btnCheckOut_Click" EnableViewState="False" ViewStateMode="Disabled" />

                                    <%--<a href="#" id="CheckOut1" runat="server"  onserverclick="CheckOut_ServerClick">CHECKOUT</a>--%>
                                <!--</div>-->
                            </div>
                            <div class="box-container event-page-details">
                                <div class="tab-top-divider"> <!--kk-->
                                    <h4><span style="color: black;">EVENT DETAILS</span></h4>
                                </div>
                                <div class="clear-l"></div>
                                <div class="divider-show m-b-10 event-details-box"></div>
                                <div class="event-details">
                                    <p>
                                        <br /><br />
                                        <span style="color: #ad2120; margin-left: 10px;">Event</span><br /> <!--kk-->
                                        <asp:Label ID="lblEventName" runat="server" style="margin-left: 10px;" Text="Event Name" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px" ></asp:Label> <!--kk-->
                                    </p>
                                    <p>
                                        <span style="color: #ad2120; margin-left: 10px;">Date & Time</span><br /> <!--kk-->
                                         <asp:Label ID="lblEvtDate" runat="server" style="margin-left: 10px;" Text="Event-Time" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px"></asp:Label>
                                        <%--<div class="item_date" style="width:200px;">
                                            <span style="font-size:18px;">
                                               
                                            </span> 
                                        </div>                 
                                                                                
                                        <br style="clear:both" />--%>
                                    </p>
                                    <p>
                                        <span style="color: #ad2120; margin-left: 10px;">Venue and Address</span><br /> <!--kk-->
                                        <asp:Label ID="lblVenueName" runat="server" style="margin-left: 10px;" Text="Label" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px" ></asp:Label> <!--kk-->
                                    </p>

                                    <p>
                                        <span style="color: #ad2120; margin-left: 10px;">Description</span><br /> <!--kk-->     
                                        
                                        <textarea id="lblEventDetails"  runat="server" wrap="soft" rows="7"  readonly="readonly" style="border-style:none;border-width:0;margin-left:10px; width:95%;background-color:rgb(246, 246, 246)"></textarea>
                                        <%--<asp:Label ID="lblEventDetails" runat="server" style="margin-left: 10px; vertical-align:middle;" Text="Event-Time" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px"></asp:Label>                                            --%>
                                        
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="left-main col-m-r col4">
                <div class="event-images-box">
                    <div class="main-image m-b-5">
                        <img id="imgEvent" runat="server" src="~/ShowlineImages/May17.png" height="350"/> <!--kk-->
                    </div>
                </div>
                <!--<div class="box-container event-page-location"> -kk -->
                    <div class="event-images-box">
                    <!--<div class="tab-top-divider float-l">-->
                        <div class="main-image m-b-5">
                        <h3><strong>Venue Layout</strong></h3>
                        <br style="clear: both" />
                        <img id="imgVenue" runat="server" src="~/BannerImages/G0506130747415.png" />
                    </div>
                </div>
            </div>


            <!-- Sign In -->
           
            <!-- Sign In -->
        </div>
        
         <div id="dSignIn" class="divLoad" style="visibility:hidden;display:none;">
                <div class="Login-create">
                   <%-- <span style="font-size: medium;display:table-cell; vertical-align: middle;width:100%">SIGN IN OR CREATE AN ACCOUNT</span>--%>
                    <center><asp:Label ID="Label1" runat="server" Text="SIGN IN OR CREATE AN ACCOUNT"  style="vertical-align:middle;width:100%"></asp:Label></center>
                    <br style="clear: both;" />
                    <div id="slickbox1" style="display: block;">
                        <ul class="personal-info-list list-no-border">
                            <li>
                                <div class="form-boxes">
                                    <input type="radio" name="loginsignup" id="loginsignup_SingIn" value="signin" checked="checked" class="float-l" onclick="$('#FormSubmit').html('Sign In'); $('#divconfirmpassword').css('display', 'none'); $('input[id=hdType]').val('SignIn');" />

                                    <p class="user-radio-btn m-r-20">Sign In</p>
                                    <input type="radio" name="loginsignup" id="loginsignup_Register" value="signup" class="float-l" onclick="$('#FormSubmit').html('Register'); $('#divconfirmpassword').css('display', 'block'); $('input[id=hdType]').val('Register');" />
                                                                        <p class="user-radio-btn">Register</p>
                                </div>
                                <div class="clear-b"></div>
                            </li>
                            <li style="margin-top:10px">
                                <label for="email" style="font-size: small;width:150px">Email Address</label>

                                <div class="form-boxes">
                                    <input type="email" name="txtEmail" id="txtEmail" class="input-full float-l" value="" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" runat="server" ErrorMessage="Enter Email Address" Style="font-size: small;color:red"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                           
                            <li style="margin-top:10px">
                                <div id="divFullName">
                                    <label for="email" style="font-size: small">Full Name</label>
                                    <div class="form-boxes">
                                        <input type="text" name="txtFullName" id="txtFullName" class="input-full float-l" value="" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="font-size: small;color:red" ErrorMessage="Enter Full Name" ControlToValidate="txtFullName" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>      
                                </div>                          
                                 <br style="clear: both;" />
                            </li>
                            <li style="margin-top:10px">
                                <div id="divSignInPassword">
                                    <label for="password" style="font-size: small">Password</label>
                                    <div class="form-boxes">
                                        <input type="password" name="txtPassword" id="txtPassword" class="input-full float-l" value="" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Style="font-size: small;color:red" ErrorMessage="Enter password" ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <br class="clear-b" />
                                    </div>
                                </div>
                                <br style="clear: both;" />
                            </li>
                            <li style="margin-top:10px">
                                <div id="divconfirmpassword" style="display: none;">
                                    <label for="password" style="font-size: small">Confirm Password</label>
                                    <div class="form-boxes">
                                        <input type="password" name="txtConfirmPassword" id="txtConfirmPassword" class="input-full float-l" value="" runat="server" />                                        
                                    </div>                                   
                                </div>
                            </li>
                            <li style="margin-top:10px">
                                <label></label>
                                <div class="form-boxes">

                                    <p class="float-l m-t-8 forget-password">
                                        <a href="#" style="font-size: small" onclick="$('#FormSubmit').html('Send Password'); $('#divconfirmpassword').css('display', 'none'); $('#divFullName').css('display', 'none');$('#divSignInPassword').css('display', 'none');$('input[id=hdType]').val('SendPassword');">Forget your password?</a>
                                    </p>
                                </div>
                            </li>
                        </ul>
                        <div class="clear-b"></div>
                        <div class="info-box important-info m-t-15">
                            <div class="float-r">
                                <div class="button lrg-btn float-l m-r-15">
                                    <asp:HiddenField ID="hdType" runat="server" Value="SignIn" />
                                    <a href="#" id="FormSubmit" runat="server" onserverclick="FormSubmit_ServerClick">Sign In</a>
                                </div>
                            </div>                          
                        </div>                       
                    </div>
                </div>
            </div>

    </form>
</body>
</html>
