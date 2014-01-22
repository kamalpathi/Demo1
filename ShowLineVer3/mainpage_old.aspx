<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainpage.aspx.cs" Inherits="ShowLineVer3.AdminPanel.mainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>ShowLine :: Event Banner</title>
    
    <link href="css/Adminstyle.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->

    <script language="javascript" type="text/javascript">
        function resizeIframe(obj) {
            obj.style.height = (obj.contentWindow.document.body.scrollHeight) + 'px';
            obj.style.width = obj.contentWindow.document.body.scrollWidth + 'px';
        }

        function LoadPage(target,values) {
            $('#frmid').attr('src', target);
            $("a.current").removeClass("current");
            $(values).addClass("current");
        }

        function UserAccess(UserCode) {
            $(document).ready(function () {
                if (UserCode != "0") {                    
                    $("#VenueDetails").css("display", "none");
                    $("#VenueDetails").css("visibility", "collapse");

                    $("#BookingDetails").css("display", "none");
                    $("#BookingDetails").css("visibility", "collapse");

                    $("#UserCreation").css("display", "none");
                    $("#UserCreation").css("visibility", "collapse");

                    $("#AddBanner").css("display", "none");
                    $("#AddBanner").css("visibility", "collapse");

                    $("#Gallery").css("display", "none");
                    $("#Gallery").css("visibility", "collapse");
                }               
            });
        }

        //$(lout).click(function () {
        //    window.location = '~/AdminPanel/Default.aspx';
        //});

    </script>   


</head>
<body>
    <form id="form1" runat="server">
        <div id="page">
            <div id="header">
                <div>
                    <div>                        
                        <a href="mainpage.aspx">
                        <img src="images/logo.png" alt="Logo" /></a>                                                
                    </div>                     
               </div>
               
                <div id="tab-container">
                    
                    <div id="tab-nav">
                        <ul>
                            <li><a id="AddEvent" href="#" onclick="LoadPage('addevent-details.aspx',this)" class="current"><span>Add Event</span></a></li>
                            <li><a id="ViewEvent" href="#" onclick="LoadPage('viewevent.aspx',this)"><span>View Events</span></a></li>
                            <li><a id="EventSetting" href="#" onclick="LoadPage('EventSettings.aspx',this)"><span>Event Settings</span></a></li>
                            <li><a id="VenueDetails" href="#" onclick="javascript:LoadPage('VenueDetails.aspx',this)"><span>Venue Details</span></a></li>
                            <li><a id="BookingDetails" target="frmid" href="booking-details.html" style="visibility:collapse;display:none;"><span>Booking Details</span></a></li>
                            <li><a id="UserCreation" href="#" onclick="javascript:LoadPage('AdminList.aspx',this)"><span>User creation</span></a></li>
                            <li><a id="AddBanner" href="#" onclick="javascript:LoadPage('addbanner.aspx',this)"><span>Add Banner</span></a></li>
                            <li><a id="Gallery" href="#" onclick="javascript:LoadPage('Gallery.aspx',this);"><span>Gallery</span></a></li>
                            <li><a id="Report" href="#" onclick="alert('Under construction.')"><span>Reports</span></a></li>
                            <li><a id="CustomerInfo" href="#" onclick="alert('Under construction.')"><span>Customer Info</span></a></li>
                            <li><a id="Settings" href="#"  onclick="javascript:LoadPage('settings.aspx',this);"><span>Settings</span></a></li>                            
                            <li><a id="Logout" href="#" onclick="window.location = 'Admin.aspx';"><span>Logout</span></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="body" class="color-white">
                <iframe id='frmid' name="PageViewframe" scrolling="no" frameborder="0" onload='javascript:resizeIframe(this);' src="addevent-details.aspx"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
