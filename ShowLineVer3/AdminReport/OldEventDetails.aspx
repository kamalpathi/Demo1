<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldEventDetails.aspx.cs" Inherits="ShowLineVer3.AdminReport.OldEventDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: History Events</title>
    <link href="../css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
        <link href="../css/ie7.css" rel="stylesheet" />
    <![endif]-->

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>


    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white">
            <h2>Past Events </h2>
            <div class="w95 margin-auto">
                <div class="float-right">
                    Select Page
                        <asp:DropDownList ID="drdpPage" runat="server" Width="110px" AutoPostBack="True"
                            OnSelectedIndexChanged="drdpPage_SelectedIndexChanged">
                        </asp:DropDownList>
                    Search
                    <asp:TextBox ID="txtSearchBy" runat="server"></asp:TextBox>
                    <input type="button" value="Search" class="form-button" runat="server" id="searchEvent" onserverclick="searchEvent_ServerClick" />
                </div>
                <asp:Repeater ID="EventList" runat="server" OnItemCommand="EventList_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="listing">
                            <tr>
                                <th>Event Image</th>
                                <th>Event Title </th>
                                <th>Event Date&Time</th>
                                <th>Venue</th>
                                <th></th>
                                <th></th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <img src="<%#Eval("ImagePath") %>" width="73" height="90" alt="Loading..."></img>
                            </td>
                            <td>
                                <asp:Label ID="lblEventTitle" runat="server" Text='<%#Eval("EventTitle") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblEventDate" runat="server" Text='<%#Eval("EventDate") %>' /></td>
                            <td>
                                <asp:Label ID="lblVenue" runat="server" Text='<%#Eval("VenueName") %>' /></td>                            
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("EventID") %>' CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'><img src="../images/delete.png" /></a>Delete</asp:LinkButton>
                            </td>
                        </tr>                        
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <br style="clear: both" />
            <br style="clear: both" />
        </div>
    </form>
</body>
</html>
