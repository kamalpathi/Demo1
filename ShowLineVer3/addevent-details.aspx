<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent-details.aspx.cs" Inherits="ShowLineVer3.AdminPanel.addevent_details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Event Details</title>
    <link href="css/Adminstyle.css" rel="stylesheet" />
    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->
    <link rel="Stylesheet" href="http://ajax.microsoft.com/ajax/beta/0911/extended/tabs/tabs.css" />
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="http://ajax.microsoft.com/ajax/beta/0911/Start.debug.js" type="text/javascript"></script>
    <script src="http://ajax.microsoft.com/ajax/beta/0911/extended/ExtendedControls.debug.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    
    <link href="css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script src="js/jquery-ui-timepicker-addon.js"></script>


    <link href="../css/msgBoxLight.css" rel="stylesheet" />
    <script src="js/jquery.numeric.js"></script>

   
    <%--<link href="css/jquery.timeentry.css" rel="stylesheet" />
    <script src="../js/jquery.timeentry.js"></script>--%>


    <script type="text/javascript">
        Sys.require(Sys.components.tabContainer, function () {
            var container = Sys.create.tabContainer("#tabcontainer", 0);
            $("#tab1_body").tabPanel(container, "#tab1");
            $("#tab2_body").tabPanel(container, "#tab2");
            $("#tab3_body").tabPanel(container, "#tab3");
            $("#tab4_body").tabPanel(container, "#tab4");
        });
    </script>

    <script type="text/javascript">
        function CheckValidation(msgcontents, msgHeader, target) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                afterShow: function (result) {
                    $('#' + target).css("background-color", "yellow");
                    $('#' + target).focus();
                }
            });
        }

        function ConfirmMsg(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });
        }

        function ErrorMsg(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "error"
            });
        }
        

        $(function () {
            $("#txtEventDate").datepicker({                
                minDate: 0,
                dateFormat: 'dd-M-yy'                
            });
        });

        function MoveTab(num) {
            var container = $find('tabcontainer');           
            container.set_activeTabIndex(num);           
        }

        $('#btnSt1').click(function () {
            alert('1');
            $('#tab1_body_tab').removeClass('ajax__tab_active');
            $('#tab2_body_tab').addClass('ajax__tab_active');
            $('#tab1_body').css('display', 'none');
            $('#tab1_body').css('visibility', 'hidden');

            
            $('#tab2_body').css('visibility', 'visible');

        });

        $(function () {

            $('#txtFromTime').datetimepicker({ dateFormat: 'dd-M-yy' });
            $("#txtTotTime").datetimepicker({ dateFormat: 'dd-M-yy' });

            //$('#txtFromTime').timeEntry({ show24Hours: true, showSeconds: false });
            //$('#txtTotTime').timeEntry({ show24Hours: true, showSeconds: false });
        });
    </script>

    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img_prev')
                    .attr('src', e.target.result)
                    .width(198)
                    .height(295);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

        function EventImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgSmallImg')
                    .attr('src', e.target.result)
                    .width(133)
                    .height(200);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

        function TicketImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#ImgTicketImage')
                    .attr('src', e.target.result)
                    .width(133)
                    .height(200);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <meta charset="utf-8" />
    <!--[if IE]>
<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        
        <div id="body" class="color-white">
            <br style="clear: both;" />
            <div id="tabcontainer" class="ajax__tab_xp" style="width: auto;height:800px;" runat="server">
                <div id="tabcontainer_header">
                    <div id="tab1">Details</div>
                    <div id="tab2">Price</div>
                    <div id="tab3">Special Image</div>
                    <div id="tab4">Event & Ticket Images</div>
                </div>
                <div id="tabcontainer_body">
                    <div id="tab1_body" style="height: 570px;">
                        <h2>Add Details to the new event</h2>
                        <div class="w70 margin-auto">
                            <br style="clear: both;" />
                            <!-- one column div container -->
                            <asp:HiddenField ID="hdEventID" runat="server" />
                              <asp:HiddenField ID="EventTimeID" runat="server" />
                            <asp:HiddenField ID="hdImagePath" runat="server" />
                            <asp:HiddenField ID="hdEventImagePath" runat="server" />
                            <asp:HiddenField ID="hdTicketImagePath" runat="server" />

                            <div class="margin-auto">
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Event Title</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <input type="text" name="txtEventTitle" class="textfield w80" id="txtEventTitle" runat="server" maxlength="50" />
                                        </label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Event Type</label>
                                    </span>
                                    <span class="w30 float-left">
                                        <label class="p5">
                                            <asp:DropDownList ID="ddEventType" runat="server" CssClass="textfield w80" OnSelectedIndexChanged="ddEventType_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Text="Choose" Value="Choose"></asp:ListItem>
                                            </asp:DropDownList>

                                            <%--<select name="select" id="cmd1EventType" class="textfield w80" runat="server" onserverchange="cmdEventType_ServerChange" >
                                                <option value="1">Choose</option>
                                                <option value="2">Concert</option>
                                                <option value="3">Theater</option>
                                                <option value="4">Sports</option>
                                                <option value="5">Movie</option>
                                                <option value="6">Family</option>
                                                <option value="7">Others</option>
                                            </select>--%>
                                        </label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Event Sub Type</label>
                                    </span>
                                    <span class="w30 float-left">
                                        <label class="p5">
                                             <asp:DropDownList ID="ddEvebtSubType" runat="server" CssClass="textfield w80" OnSelectedIndexChanged="ddEventType_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Text="Choose" Value="Choose"></asp:ListItem>
                                            </asp:DropDownList>                                            
                                        </label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Event Description</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <textarea type="text" class="textfield w80" rows="10" cols="30" id="txtEventDesc" runat="server" maxlength="2000"></textarea></label> <!-- lkk ength chaged from 500 to 200-->
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Artist</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <input type="text" class="textfield w80" runat="server" id="txtArtist" maxlength="100" />
                                        </label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Genre</label>
                                    </span>
                                    <span class="w40 float-left">
                                        <label class="p5">
                                            <input type="text" class="textfield w80" runat="server" id="txtGenre" maxlength="50"/>
                                        </label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Event Date</label>
                                    </span>
                                    <span class="w40 float-left">
                                        <label class="p5">
                                            <input type="text" class="textfield w80" runat="server" id="txtEventDate" autocomplete="off" readonly="true"/>
                                            <a id="datepickerImage" href="#" onclick="$('#txtEventDate').datepicker('show');"><img  src="images/calendar.png" /></a>

                                        </label>
                                    </span>
                                </div>

                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">From Time</label>
                                    </span>
                                    <span class="w40 float-left">
                                        <label class="p5">
                                            <input type="text" name="event_frmTime" id="txtFromTime" runat="server" maxlength="5" class="textfield w80" style="margin-top: auto; height: 21px; font-size: small; margin-top: 5px; margin-bottom: 5px" placeholder="24 hr." />
                                        </label>
                                        
                                    </span>
                                </div>

                               <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">To Time</label>
                                    </span>
                                   <span class="w40 float-left">
                                       <input type="text" name="event_toTime" id="txtTotTime" runat="server" maxlength="5" class="textfield w80" style="margin-top: auto; height: 21px; font-size: small; margin-top: 5px; margin-bottom: 5px" placeholder="24 hr." />
                                   </span>
                               </div>

                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Venue Name</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <%--<input type="text" class="textfield w80" />--%>                                         
                                            <asp:DropDownList ID="ddVenueDetails" runat="server" CssClass="textfield w80" placeholder="Select Venue Details">
                                                <%--<asp:ListItem Text="Select Venue Details" Value="Select"></asp:ListItem>--%>
                                            </asp:DropDownList>

                                        </label>
                                    </span>
                                </div> 
                                <div class="float-right" style="margin-right:80px" >
                                    <div >
                                            <input type="button" value="Next >> " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="btnSt1" onclick="MoveTab(1)" />
                                    </div>
                                </div>   
                            </div>
                        </div>
                    </div>

                    <div id="tab2_body" style="display: none;height:800px;">
                        <h2>Add Price Details to the new event</h2>
                        <div class="w70 margin-auto">
                            <br style="clear: both;" />

                            <!-- one column div container -->

                            <div class="margin-auto">


                                <div class="form-section">


                                    <div class="w100 float-left ">
                                        <div class="w100 float-left">
                                            <span class="w5 float-left">No.
                                            </span>
                                            <span class="w30 float-left p5">Ticket Type 
                                            </span>
                                            <span class="w30 float-left p5">Total seats
                                            </span>
                                            <span class="w30 float-left p5">Ticket Price (USD)
                                            </span>
                                        </div>
                                        <br style="clear:both;"/>
                                         <%--1--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">1
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID1" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType1" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat1" maxlength="5"/></label>    
                                                    
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice1" maxlength="8"/></label>                                                
                                                
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/add.png" /></a>--%></span>
                                        </div>

                                        <br style="clear:both;"/>
                                         <%--2--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">2
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID2" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType2" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat2" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice2" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>

                                        <br style="clear:both;"/>
                                         <%--3--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">3
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID3" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType3" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat3" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice3" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="images/delete.png" /></a>--%></span>
                                        </div>

                                        <br style="clear:both;"/>
                                         <%--4--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">4
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID4" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType4" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat4" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice4" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>


                                        <br style="clear:both;"/>
                                        <%--5--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">5
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID5" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType5" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat5" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice5" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>

                                        <%--6--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">6
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID6" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType6" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat6" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice6" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--7--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">7
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID7" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType7" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat7" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice7" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--8--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">8
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID8" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType8" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat8" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice8" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--9--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">9
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID9" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType9" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat9" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice9" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--10--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">10
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID10" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType10" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat10" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice10" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--11--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">11
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID11" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType11" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat11" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice11" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--12--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">12
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID12" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType12" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat12" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice12" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--13--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">13
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID13" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType13" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat13" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice13" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--14--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">14
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID14" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType14" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat14" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice14" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>
                                        <%--15--%>
                                        <div class="w100 float-left tab-section">
                                            <span class="w5 float-left">15
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <asp:HiddenField ID="EPID15" runat="server" />
                                                    <input type="text" class="textfield w80" runat="server" id="txtTicketType15" maxlength="50"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive-integer" runat="server" id="txtTotalSeat15" maxlength="5"/></label>
                                            </span>
                                            <span class="w30 float-left p5">
                                                <label>
                                                    <input type="text" class="textfield w80 positive" runat="server" id="txtTicketPrice15" maxlength="8"/></label>
                                            </span>
                                            <span class="float-left m-t-5"><%--<a href="#" class="">
                                                <img src="../images/delete.png" /></a>--%></span>
                                        </div>

                                        <br style="clear:both;"/>
                                        <br style="clear:both;"/>

                                        <div class="float-right" style="margin-right:80px" >
                                            <div >
                                                <input type="button" value="Back << " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="Button2" onclick="MoveTab(0)" />
                                                <input type="button" value="Next >> " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="Button1" onclick="MoveTab(2)" />
                                            </div>
                                        </div>    
                                    </div>


                                </div>
                                <br style="clear:both;"/>
                            </div>
                            <br style="clear:both;"/>
                        </div>
                    </div>

                    <div id="tab3_body" style="display: none;">
                        <h2>Upload Special Image </h2>
                        <div class="w80 margin-auto">
                            <br style="clear:both;" />

                            <!-- one column div container -->


                            <div class="w30 float-left p5">
                                <fieldset class="preview-boxEvent">
                                    <legend>Preview Box</legend>
                                    <img  id="img_prev" src="../images/images.jpg" height="295" width="198" runat="server"/>
                                </fieldset>
                            </div>
                            <div class="w60 float-left p5">
                                <div class="w100 float-left m-l-100 m-t-30">
                                    Upload Special Image (Min size 750x315)<br style="clear:both;"/>
                                      <input type='file' onchange="readURL(this);" runat="server" id="filenm" />
                                    <br style="clear:both;"/>
                                    <br style="clear:both;"/>
                                </div>
                                <br style="clear:both;"/>
                            </div>



                        </div>
                        <br style="clear:both;"/>
                        <div class="float-right" style="margin-right:80px" >
                            <div >
                                <input type="button" value="Back << " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="Button3" onclick="MoveTab(1)" />                               
                                <input type="button" value="Next >> " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="Button5" onclick="MoveTab(3)" />
                            </div>
                        </div>    
                        <br style="clear:both;"/>
                        <br style="clear:both;"/>
                    </div>

                    <div id="tab4_body" style="display: none;">
                        <h2>Upload Event & Ticket Image </h2>
                        <div class="w80 margin-auto">
                            <br style="clear:both;" />

                            <!-- one column div container -->

                            <div class="w40 float-left p5">
                                <fieldset class="preview-boxEvent">
                                    <legend>Preview Box</legend>
                                    <img  id="imgSmallImg" src="../images/images.jpg" height="200" width="133" runat="server"/>
                                </fieldset>
                                <div class="w100 float-left m-t-30">
                                    Upload Event Image (Min size 250X250)<br style="clear:both;"/>
                                      <input type='file' onchange="EventImage(this);" runat="server" id="filesmallimage" />
                                    <br style="clear:both;"/>
                                    <br style="clear:both;"/>
                                </div>
                            </div>

                            <div class="w40 float-right p5" style="margin-left:15px;">
                                <fieldset class="preview-boxEvent">
                                    <legend>Preview Box</legend>
                                    <img  id="ImgTicketImage" src="../images/images.jpg" height="200" width="133" runat="server"/>
                                </fieldset>
                                 <div class="w100 float-left m-t-30">
                                    Upload Ticket Background Image <br style="clear:both;"/>
                                      <input type='file' onchange="TicketImage(this);" runat="server" id="filebackgroundimage" />
                                    <br style="clear:both;"/>
                                    <br style="clear:both;"/>
                                </div>
                                <br style="clear:both;"/>
                            </div>
                        </div>
                        <br style="clear:both;"/>
                        <div class="float-right" style="margin-right:80px" >
                            <div >
                                <input type="button" value="Back << " class="form-button" style="width: 75px; float: left; vertical-align: middle; text-align: center;"  id="Button4" onclick="MoveTab(2)" />                               
                            </div>
                        </div>    
                        <br style="clear:both;"/>
                        <br style="clear:both;"/>
                    </div>

                </div>
            </div>
            <br style="clear: both" />
            <div class="form-section">
                <input type="button" value="Save" class="form-button" style="width: 150px; float: left; vertical-align: middle; text-align: center;" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                <input type="button" value="Update" class="form-button" style="width: 150px; float: left; vertical-align: middle; text-align: center;" runat="server" id="btnUpdate" onserverclick="btnUpdate_ServerClick" />
            </div>
            <br style="clear: both" />
            <br style="clear: both" />
        </div>
    </form>
    <script type="text/javascript">
        $(".numeric").numeric();
        $(".integer").numeric(false, function () { alert("Integers only"); this.value = ""; this.focus(); });
        $(".positive").numeric({ negative: false }, function () { alert("No negative values"); this.value = ""; this.focus(); });
        $(".positive-integer").numeric({ decimal: false, negative: false }, function () { alert("Positive integers only"); this.value = ""; this.focus(); });
        $("#remove").click(
            function (e) {
                e.preventDefault();
                $(".numeric,.integer,.positive").removeNumeric();
            }
        );
	</script>
</body>
</html>
