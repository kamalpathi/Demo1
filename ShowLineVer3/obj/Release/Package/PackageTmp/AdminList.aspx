<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="ShowLineVer3.AdminPanel.AdminList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Admin</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>

    <link href="css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->


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
            <h2>Create User </h2>
            <br />

            <div class="form-section">                
                <span class="float-left">
                    <input type="button" value="Add User" class="form-button" runat="server" id="AddUser" style="margin-left:25px;" onserverclick="AddUser_ServerClick"/>
                </span>
            </div>

            <div class="form-section">
                <asp:Repeater ID="gvAdminList" runat="server" OnItemCommand="gvAdminList_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="listing">
                            <tr>
                                <th>User Name</th>
                                <th>User Id</th>
                                <th>Venue Name</th>
                                <th>Email ID</th>
                                <th>UserType</th>                                
                                <th></th>
                                <th></th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("AdminFullName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblVenueName" runat="server" Text='<%#Eval("AdminUserName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblVenue" runat="server" Text='<%#Eval("VenueName") %>' /></td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("AdminEmailID") %>' /></td>
                            <td>
                                <asp:Label ID="lblUserType" runat="server" Text='<%#Eval("UserType") %>' /></td>
                            <td>
                                <asp:LinkButton ID="LinkEdit" runat="server" CommandArgument='<%#Eval("AdminUserID") %>' CommandName="edit"><img src="images/edit.png" /></a>Edit</asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("AdminUserID") %>' CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'><img src="images/delete.png" /></a>Delete</asp:LinkButton>
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
