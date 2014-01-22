<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="ShowLineVer3.WebSite.PaymentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <link href="../css/EventList.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="contentMain">
        <div class="box-container" style="margin:20px">
             <ul class="tab-nav">
                <li class="tab-top-nav-box-active float-l" style="font-size:small">
                    <span style="color:rosybrown">Venue Details</span>
                    </li>                   
                 </ul>
             <br style="clear:both;" />
             <div class="box box-tab credit-card-box" style="width:60%">
                 <div style="float:left">
                    <img src="images/bob-dylan-tickets-75x75.jpg" id="EvtImage" runat="server" style="width:150px;height:150px"/>
                 </div>
                 <div style="float:left">
                       <h3> <asp:Label ID="lblEventName" runat="server" Text="Label" Font-Size="Small" Font-Bold="true" style="color:maroon"></asp:Label></h3>
                        <p><strong>Venue :</strong></p>
                     <p><asp:Label ID="lblVenueName" class="input-22 float-l m-r-2-perc required" runat="server" Text="Label"></asp:Label></p>
                 </div>
            </div>

        </div>
    </div>
    </form>
</body>
</html>
