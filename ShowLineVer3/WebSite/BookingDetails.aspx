<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingDetails.aspx.cs" Inherits="ShowLineVer3.WebSite.BookingDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <link href="../css/styleInner.css" rel="stylesheet" />
    <link href="../css/bookingdetails.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>

    <script type="text/javascript">
        function fnSwp(aid, divid) {
            try {                
                $("#accDtls a").removeClass('selected');
                $("#" + aid.toLowerCase()).addClass('selected');
                $("#accDtls div.spc").hide();
                $("#" + divid).show();

            } catch (e) {

            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="box_940">
            <div class="mypagenav">
                <div class="fl_100">
                    <a href='/./myprofile/booking-history'>
                        <div class="leftnav">Booking History</div>
                    </a>                   
                    <div class="pgnavbd"></div>
                    <a href='/./myprofile/edit'>
                        <div class="leftnavsel">Account Details</div>
                    </a>

                </div>

            </div>
            <div class="box_757 whitesec">
                <div id="accDtls" class="yellowsec fl_100">
                    <div class="bordertab">
                        <div class="fleft accDtls nav">
                            <a id="edtprofdtl" href="javascript:;" onclick="fnSwp('EDTPROFDTL','editcont');" class="selected">Edit Profile</a>
                            <a id="chngpwd" href="javascript:;" onclick="fnSwp('CHNGPWD','cpass');">Change Password</a>
                        </div>
                    </div>
                    <div class="clear"></div>


                    <div id="editcont" class="spc fleft" style="padding-top: 20px;">
                        <div id="acntDtls" class="accdetails">
                            <div class="fl_100">
                                <label>First Name.</label>
                                <input type="text" id="FName" />
                            </div>
                            <div class="fl_100">
                                <label>Last Name.</label>
                                <input type="text" id="LName" />
                            </div>
                            <div class="fl_100">
                                <label>Mobile No.</label>
                                <input type="text" id="mobile" />
                            </div>

                            <div class="fright">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                            </div>
                            <div class="clear"></div>                           
                        </div>
                    </div>

                    <div id="cpass" class="spc fleft" style="padding-top: 20px; display: none;">
                        <div id="pwd" class="accdetails">
                            <div class="fl_100">
                                <label>Current Password</label>
                                <input type="password" id="cpwd" />
                            </div>
                            <div class="fl_100">
                                <label>New Password</label>
                                <input type="password" id="npwd1" />
                            </div>
                            <div class="fl_100">
                                <label>Confirm Password</label>
                                <input type="password" id="npwd2" />

                            </div>
                            <div class="fright" style="width: 210px;">
                                <a href="javascript:;" class="button yellow" onclick="fnChkPwd();">Submit</a>
                            </div>
                            <div class="clear"></div>

                            <div id="errDiv" class="error mypagerr" style="display: none;">
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>
</html>
