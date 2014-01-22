<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustAccountDetails.aspx.cs" Inherits="ShowLineVer3.WebSite.CustAccountDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <%--<link href="../css/styleInner.css" rel="stylesheet" />--%>
    <%--<link href="../css/style.css" rel="stylesheet" />--%>
    <link href="../css/styleInner.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />
    <script src="../js/common.js"></script>

    <!--[if IE 7]>
    <style type="text/css">
        #vtab > ul > li.selected{
            border-right: 1px solid #fff !important;
        }
        #vtab > ul > li {
            border-right: 1px solid #ddd !important;
        }
        #vtab > div { 
            z-index: -1 !important;
            left:1px;
        }
    </style>
    <![endif]-->

    <style type="text/css">
        .tfont
        {
            /*background: #fff;*/
            font-family: Arial,sans-serif,Helvetica;
            /*padding-top: 50px;*/
            font-size: 12px;
        }
               

        input
        {
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            border: solid 1px black;
            padding: 5px;
            width: 250px;
            font-size: 12px;
            border-top-color: #c6c6c6;
            border-left-color: #c6c6c6;
            border-right-color: #c6c6c6;
            border-bottom-color: #c6c6c6;
        }

        #vtab
        {
            margin: auto;
            width: 100%;
            /*width: 800px;*/
            /*height: 300px;*/
        }

            #vtab > ul > li
            {
                width: 110px;
                height: 40px;
                background-color: #fff !important;
                list-style-type: none;
                display: block;
                text-align: center;
                margin: auto;
                padding-bottom: 10px;
                border: 1px solid #fff;
                position: relative;
                border-right: none;
                opacity: .3;
                -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=30)";
                filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=30);
                padding-top: 20px;
            }

                #vtab > ul > li.home
                {
                    background: url('home.png') no-repeat center center;
                }

                #vtab > ul > li.login
                {
                    background: url('login.png') no-repeat center center;
                }

                #vtab > ul > li.support
                {
                    background: url('support.png') no-repeat center center;
                }

                #vtab > ul > li.selected
                {
                    opacity: 1;
                    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
                    filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=100);
                    border: 1px solid #ddd;
                    border-right: none;
                    z-index: 10;
                    background-color: #fafafa !important;
                    position: relative;
                }

            #vtab > ul
            {
                float: left;
                width: 110px;
                text-align: left;
                display: block;
                margin: auto 0;
                padding: 0;
                position: relative;
                top: 0px;  /*kk*/
            }

            #vtab > div
            {
                background-color: #fafafa;
                margin-left: 110px;
                border: 1px solid #ddd;
                min-height: 500px;
                padding: 12px;
                position: relative;
                z-index: 9;
                -moz-border-radius: 20px;
            }

                #vtab > div > h4
                {
                    color: #800;
                    font-size: 1.2em;
                    border-bottom: 1px dotted #800;
                    padding-top: 5px;
                    margin-top: 0;
                }

        #loginForm label
        {
            float: left;
            width: 100px;
            text-align: right;
            clear: left;
            margin-right: 15px;
            border: thin;
        }

        #loginForm fieldset
        {
            border: none;
        }

            #loginForm fieldset > div
            {
                padding-top: 3px;
                padding-bottom: 3px;
            }

        #loginForm #login
        {
            margin-left: 115px;
        }


        .button:active
        {
            top: 1px;
            position: relative;
            box-shadow: inset 0px 1px 1px rgba(0,0,0,0.3);
            text-shadow: none;
        }

        .button
        {
            padding: 4px 11px;
            border-radius: 3px;
            border: 1px solid rgb(205, 73, 2);
            transition: background 0.2s;
            color: rgb(254, 244, 233) !important;
            font-size: 13px;
            font-weight: bold;
            text-decoration: none;
            display: inline-block;
            box-shadow: inset 1px 1px 0px rgba(255,255,255,0.3);
            -moz-transition: background .2s ease 0s;
            -webkit-transition: background .2s ease 0s;
            border-image: initial;
        }

        .orange.button:hover
        {
            background: -ms-linear-gradient(rgb(202, 68, 30) 0px, rgb(222, 107, 52) 100%);
            background: -webkit-linear-gradient(rgb(202, 68, 30) 0px, rgb(222, 107, 52) 100%);
            background: -moz-linear-gradient(rgb(202, 68, 30) 0px, rgb(222, 107, 52) 100%);
            text-shadow: 0px 2px 0px #cd4902;
        }

        .orange.button
        {
            background: -ms-linear-gradient(rgb(222, 107, 52) 0px, rgb(202, 68, 30) 100%);
            background: -webkit-linear-gradient(rgb(222, 107, 52) 0px, rgb(202, 68, 30) 100%);
            background: -moz-linear-gradient(rgb(222, 107, 52) 0px, rgb(202, 68, 30) 100%);
            color: rgb(254, 244, 233) !important;
            text-shadow: 0px 2px 0px #cd4902;
        }

        .yellow.button a:hover
        {
            text-decoration: none;
        }

        .yellow.button a:visited
        {
            text-decoration: none;
            opacity: 0.8;
        }

        .GridviewDiv {font-size: 62.5%; font-family: 'Lucida Grande','Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif; color: #303933;}
        Table.Gridview{border:solid 1px #df5015;}
        .GridviewTable{border:none}
        .GridviewTable td{margin-top:0;padding: 0; vertical-align:middle }
        .GridviewTable tr{color: White; background-color: #df5015; height: 30px; text-align:center}
        .Gridview th{color:#FFFFFF;border-right-color:#abb079;border-bottom-color:#abb079;padding:0.5em 0.5em 0.5em 0.5em;text-align:center}
        .Gridview td{border-bottom-color:#f0f2da;border-right-color:#f0f2da;padding:0.5em 0.5em 0.5em 0.5em;text-align:center}
        .Gridview tr{color: Black; background-color: White; text-align:left}
        :link,:visited { color: #DF4F13; text-decoration:none }

    </style>

    <script type="text/javascript">
        $(function () {
            var $items = $('#vtab>ul>li');
            $items.mouseover(function () {
                $items.removeClass('selected');
                $(this).addClass('selected');

                var index = $items.index($(this));
                $('#vtab>div').hide().eq(index).show();
            }).eq(1).mouseover();
        });
    </script>

    <script type="text/javascript">
        //$(document).ready(function () {
        function CheckValidation(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });
        }

        function onRespose(id,tt) {            
            window.open("http://www.showsline.com/Report.aspx?TID=" + id + "&TT=" + tt);  // kk print 
            return false;
        }

        function ShowProcessing(id) {

            $.msgBox({
                title: "Login",
                content: "Session Expired,Login Again",
                type: "info",
                buttons: [{ value: "Ok" }],
                afterShow: function (result) { OpenLogin(id); }
            });   
        }
        
            function OpenLogin(id)
            {
                parent.OpenLoginCheckout(id);     
            }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="contentMain" style="width: 100%">
            <div class="contentWraper">
                <div class="columnLeft">
                    <div class="homeWidgets">
                        <div class="contentContainer">
                            <div id="vtab" class="tfont">
                                <ul>
                                    <li class="home selected">Booking History</li>
                                    <li class="login">Account Details</li>
                                    <li class="support">Change Password</li>
                                </ul>

                                <div style="overflow:auto;"><!--kk-->
                                    <!--<h4>Transaction Details</h4>-->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 775px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;Your Bookings</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>
                                    </br>


                                    <asp:GridView ID="grdTransaction" runat="server" AutoGenerateColumns="false" Width="99.5%" GridLines="Both" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdTransaction_RowDataBound" CssClass="Gridview">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Booking ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltid" Width="5px" runat="server" Text='<%# Bind("TransactionID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="0px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Event" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbledet" Width="150px" runat="server" Text='<%# Bind("EventDetails") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbled" Width="100px" runat="server" Text='<%# Bind("EventDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Venue" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvenu" Width="100px" runat="server" Text='<%# Bind("Venue") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Ticket Type" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltt" Width="100px" runat="server" Text='<%# Bind("TicketType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Qty" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQty" Width="100px" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Booking Date" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbd" Width="100px" runat="server" Text='<%# Bind("BookingDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="60px" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="">
                                                <ItemTemplate>                                       
                                                    <asp:LinkButton ID="lblp" runat="server" Text='Print'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            

                                        </Columns>
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" Font-Names="Arial"/>
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
                                    </asp:GridView>
                                </div>

                                <div id="daccountdetails">
                                    <!--<h4>Account Details</h4>--> <!--kk-->

                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 775px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;Account Details</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>


                                    <table style="margin-left: 25px; margin-top: 25px">
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>First Name
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="firstname" id="firstname" runat="server"  maxlength="15"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Last Name
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="lastname" id="lastname" runat="server" maxlength="20"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Address
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="address1" id="address1" runat="server" maxlength="50"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>&nbsp;
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="address2" id="address2" runat="server" maxlength="50"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>City
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="city" id="city" runat="server" maxlength="50"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>State
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="state" id="state" runat="server" maxlength="50"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Zip
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="Zip" id="zip" runat="server" maxlength="15"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Mobile No.
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="text" name="mobileno" id="mobileno" runat="server" maxlength="15"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <div style="float: right">
                                                    <a class="button orange" runat="server" id="accountdetails" onserverclick="accountdetails_ServerClick">Submit                                
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div id="changepassword">
                                    <!--<h4>Change Password</h4>--> <!--kk-->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 775px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;Change Password</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>


                                    <table style="margin-left: 25px; margin-top: 25px">
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Current Password
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="password" name="password" id="currentpassword" runat="server" maxlength="20"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>New Password
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="password" name="password" id="newpassword" runat="server" maxlength="20"/>
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 10px; padding-top: 10px; height: 40px">
                                            <td>Confirm Password
                                            </td>
                                            <td style="margin-left: 25px; padding-left: 25px">
                                                <input type="password" name="password" id="confirmpassword" runat="server" maxlength="20"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <div style="float: right">
                                                    <a class="button orange" id="bchangepassword" runat="server" onserverclick="bchangepassword_ServerClick">Submit
                                
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>
                    <br style="clear: both" />
                    <!-- -kk -->
                    <!--<div class="homeWidgets">
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
                                </div>
                            </div>
                        </div>
                    -->
                        <!-- end #tab-box -->

                    </div>
                </div>
                <%--<div class="columnRight">
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
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="asideWraper">
                        <div class="aside">
                            <div class="asideData" style="text-align: center">
                                <img src="../images/video-thumb.gif" />
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
