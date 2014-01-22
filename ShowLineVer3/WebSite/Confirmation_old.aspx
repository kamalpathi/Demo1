<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="ShowLineVer3.WebSite.Confirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Shows Live - Venue Promotions and Ticketing</title>
    <!--<link href="../css/styleInner.css" rel="stylesheet" />--> <!--k-->
    <link href="css/styleInner.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
  <div class="contentMain">
    <div class="contentWraper">
      <div class="columnLeft">
        <div class="contentContainer">
        
          <div class="contentWidgets" style="margin-top:0px;">
           <span class="status">Congratulations ! Your ticket has been booked.</span>
           <span class="order">Order # <asp:Label ID="transactionID" runat="server" Text="1345"></asp:Label>- Please carry a copy of your printed ticket at the venue.
           </span>
          </div>

		  <br style="clear:both"/><br style="clear:both"/>
		  <span class="single-row"><input type="button" value="Print Ticket" id="printTicket" class="form-button" runat="server" onclick="window.open('http://www.showsline.com/Report.aspx?TID=' + $('#hTID').val() + '&TT=ALL');"/></span>  <!--kk print-->
          <br style="clear:both"/>
            <br style="clear:both"/>
          
          <!--<h2>Booking Details</h2>--> <!-- kk -->
                                    
                    <table style="border: 5px solid #1b1b1b; width: 912px; height: 25px;" cellpadding="0">
                        <tr style="background-color: #1b1b1b; color: White">
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

                                  <p>
                                      <asp:Repeater ID="rptTicketDetails" runat="server">
                                          <HeaderTemplate>
                                              <table cellspacing="5px" cellpadding="25px">
                                                  <tr style="color: maroon">
                                                      <td style="font-size:medium;"><strong>&nbsp;&nbsp;&nbsp;Ticket Type</strong></td>
                                                      <td style="font-size:medium;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No. of Persons</strong></td>
                                                  </tr>
                                          </HeaderTemplate>
                                          <ItemTemplate>
                                                <tr>
                                                    <td style="font-size:medium;"><strong>&nbsp;&nbsp;&nbsp;<%# Eval("TICKETTYPE")%></strong></td>
                                                    <td style="font-size:medium;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("entry")%></strong></td>
                                                </tr>
                                  
                                          </ItemTemplate>
                                          <FooterTemplate>
                                              </table>
                                          </FooterTemplate>
                                      </asp:Repeater>
                                  </p> 

                                <br/>
                                <h3> Name :  &nbsp;<asp:Label ID="customerName" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                <br/>
                                <!--<p><strong>Venue :</strong></p>-->
                                <h3> Venue :  &nbsp;<asp:Label ID="VenueDetails" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                <br/>
                                <h3>Date & Time : &nbsp;<asp:Label ID="eventDate" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3> <!-- kk-->
                                <br/>
                                <h3>Location : &nbsp;<asp:Label ID="lblStreetAddress" runat="server" Text="Label" Font-Bold="true"></asp:Label></h3>
                                <h3>
                                    <asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true" style="margin-left:72px;"></asp:Label>
                                    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true"></asp:Label>--%>
                                </h3>
                                <h3>
                                    <asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true" style="margin-left:72px;"></asp:Label>
                                    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true"></asp:Label>--%>
                                </h3>
                                <h3>
                                    <asp:Label ID="lblZip" runat="server" Text="Label" Font-Bold="true" style="margin-left:72px;"></asp:Label>
                                </h3>
                                <br/>
                                <p> Note: Print-at-home tickets can be printed any time before event date from "My Account>> Booking History"</p>
                            </div>
                        </div>




<!--
			<div class="contentWidgets">
                <div class="contentInnerWrap">
				<p> <br /> </p>
                  <p><strong>Name :</strong> <strong></strong></p>






			  <p> <br/> </p>
                </div>
          </div> 
-->
		   <br clear="all"/><br clear="all"/>
			<span class="single-row"><input type="button" value="Book Another Ticket" class="form-button" runat="server" id="btnBookAnotherTicket" onserverclick="btnBookAnotherTicket_ServerClick"></span>                   
            <asp:HiddenField ID="hTID" runat="server"/>
        </div>

      </div>

<!--
      <div class="columnRight"> 
        
       
        <div class="asideWraper">
          <div class="aside">
            <h3>Featured Shows</h3>
            <div class="asideData">
              <ul>
                <li><a href="#">UFC 160 Tickets</a>
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
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="asideWraper">
          <div class="aside">
            <div class="asideData" style="text-align:center"> <img src="images/video-thumb.gif" /> </div>
          </div>
        </div>
      </div>
	  -->
    </div>
  </div>
    </form>
</body>
</html>
