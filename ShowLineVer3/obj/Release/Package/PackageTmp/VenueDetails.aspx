<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenueDetails.aspx.cs" Inherits="ShowLineVer3.AdminPanel.VenueDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>ShowLine :: View Event</title>
    <link href="css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />

    <script type="text/javascript">
        function ConfirmMsg(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white" style="width: 98%;">
            <h2>Venue Details </h2>
            <br />

            <div class="form-section">
                <span class="w30 float-left textname align-left">&nbsp;</span>
                <span class="w50 float-left">
                    <input type="button" value="Add New Venue" class="form-button" runat="server" id="AddVenue" onserverclick="AddVenue_ServerClick" />
                </span>
            </div>

            <div class="form-section">
                <asp:Repeater ID="gvVenueDetailsList" runat="server" OnItemCommand="gvVenueDetailsList_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="listing">
                            <tr>
                                <th>Venue Image</th>
                                <th>Venue Name </th>
                                <th>City</th>
                                <th>State/Provision</th>
                                <th></th>
                                <th></th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <img src="<%#Eval("VenueImage") %>" width="73" height="90"></img>
                            </td>
                            <td>
                                <asp:Label ID="lblVenueName" runat="server" Text='<%#Eval("VenueName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>' /></td>
                            <td>
                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("StateProvision") %>' /></td>
                            <td>
                                <asp:LinkButton ID="LinkEdit" runat="server" CommandArgument='<%#Eval("VenueID") %>' CommandName="edit"><img src="images/edit.png" /></a>Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("VenueID") %>' CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'><img src="images/delete.png" /></a>Delete</asp:LinkButton>
                            </td>

                        </tr>
                        <%--<tr>
                            <td>
                                <img src="images/004.jpg.png" width="73" height="45"></img>
                            </td>
                            <td>Event name</td>
                            <td>18 June 2013 , 18.00</td>
                            <td>Spin nightclub</td>
                            <td><a href="#">
                                <img src="Images/edit.png" /></a>edit</td>
                            <td><a href="#">
                                <img src="images/delete.png" /></a>Delete</td>
                        </tr>--%>
                        <%--<tr>
                            <td>
                                <img src="images/004.jpg.png" width="73" height="45"></img>
                            </td>
                            <td>Event name</td>
                            <td>18 June 2013 , 18.00</td>
                            <td>Spin nightclub</td>
                            <td><a href="#">
                                <img src="Images/edit.png" /></a>edit</td>
                            <td><a href="#">
                                <img src="Images/delete.png" /></a>Delete</td>
                        </tr>--%>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>


            </div>
        </div>

    </form>
</body>
</html>
