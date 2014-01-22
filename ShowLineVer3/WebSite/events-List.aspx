<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events-List.aspx.cs" Inherits="ShowLineVer3.WebSite.events_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <link href="../css/styleInner.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
    <link href="../css/style.css" rel="stylesheet" />

  <%--  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />    
  <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css" />--%>

    <%--<script type="text/javascript">
        $(function () {
            $("#txtEventDate").datepicker({
                minDate: 0,
                dateFormat: 'dd-M-yy'
            });
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contentMain">
    <div class="contentWraper" style="padding-right:10px">     
        <div class="contentContainer" style="margin-right:10px">
          <h2>Select Seat and Checkout Ticket</h2>
          <div class="contentWidgets">
            <div class="contentInnerWrap" style="width:95%">
              <h3>
                  <asp:Label ID="lblEventName" runat="server" Text="EventName" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" style="color:#ad2120" Font-Size="13px"></asp:Label><br />
                    <span class="date">
                    <asp:Label ID="lblEvtDate" runat="server" Text="Event-Time" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px"></asp:Label>
                    </span>
              </h3>
              <p><img  id="imgEvent" runat="server"  src="#" height="212" width="202" />
                  <asp:Label ID="lblEventDetails" runat="server" Text="Event-Time" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px"></asp:Label>
              </p>
              <p><strong>Venue &amp; Location: </strong><asp:Label ID="lblLocationName" runat="server" Text="Event-Time" Font-Names="MuseoSans500,Helvetica, Arial, sans-serif" Font-Size="13px"></asp:Label></p>
              <div class="selectTicket">
               <%-- <p>
                  <label>Event Date</label>  
                    <input type="text" class="textfield w80" runat="server" id="txtEventDate" autocomplete="off" readonly="true" style="width:190px"/>
                 </p>--%>
                  <p>
                  <label>Select Ticket Type</label>
                  <asp:DropDownList ID="ddTicketType" runat="server">
                      <asp:ListItem Text="Ticket Type" Value="Ticket Type">
                          
                      </asp:ListItem>
                  </asp:DropDownList>
                  
                </p>
                <p>
                  <label>Quantity</label>
                   <asp:DropDownList ID="ddQty" runat="server" OnSelectedIndexChanged="ddQty_SelectedIndexChanged" AutoPostBack="True">
                       <asp:ListItem Text="Select Qty" Value="0" Selected="True"></asp:ListItem>
                       <asp:ListItem Text="1" Value="1" ></asp:ListItem>
                       <asp:ListItem Text="2" Value="2" ></asp:ListItem>
                       <asp:ListItem Text="3" Value="3" ></asp:ListItem>
                       <asp:ListItem Text="4" Value="4" ></asp:ListItem>
                       <asp:ListItem Text="5" Value="5" ></asp:ListItem>
                       <asp:ListItem Text="6" Value="6" ></asp:ListItem>
                       <asp:ListItem Text="7" Value="7" ></asp:ListItem>
                       <asp:ListItem Text="8" Value="8" ></asp:ListItem>
                       <asp:ListItem Text="9" Value="9" ></asp:ListItem>
                       <asp:ListItem Text="10" Value="10"></asp:ListItem>
                   </asp:DropDownList>                 
                    
                </p>
                <p>
                  <label>Price</label>
                  <input type="text" disabled="disabled" style="width:150px" id="USDPrice" runat="server"/>
                  &nbsp;USD </p>
                <p style="text-align:center; padding-top:15px;">
                  <button type="button" runat="server" id="Checkout" onserverclick="Checkout_ServerClick">Checkout</button>
                </p>
              </div>
            </div>
          </div>
          <div class="contentWidgets">
            <div class="contentInnerWrap" style="text-align:center">
              <p><img id="ImgVenue" runat="server" src="images/men-arena.gif" alt="Venue"/></p>
            </div>
          </div>
        </div>
    </div>
        </div>
    </form>
</body>
</html>
