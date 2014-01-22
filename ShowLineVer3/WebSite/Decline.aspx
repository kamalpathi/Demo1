
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Decline.aspx.cs" Inherits="ShowLineVer3.WebSite.Decline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>ShowsLine - Venue Promotions and Ticketing</title>
    <!--<link href="../css/styleInner.css" rel="stylesheet" />--> <!--k-->
    <link href="css/styleInner.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
</head>
<body>
    <form id="form2" runat="server">
    
  <div class="contentMain">
    <div class="contentWraper">
      <div class="columnLeft">
        <div class="contentContainer">
        
          <div class="contentWidgets" style="margin-top:0px;">
           <span class="status">Transaction Declined !</span>
           <span class="order">&nbsp;Some Thing Went Wrong, Please Try Again.
           </span>
          </div>

		  <br style="clear:both"/><br style="clear:both"/>
		  <span class="single-row"><input type="button" value="Back" id="printTicket1" class="form-button" runat="server" onserverclick="decline_ServerClick"/></span> 
          <br style="clear:both"/>
            <br style="clear:both"/>
            <br style="clear:both"/>
          

            </div>
      </div>
    </div>
  </div>
    </form>
</body>
</html>
