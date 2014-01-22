<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="ShowLineVer3.AdminReport.CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
     <link href="../css/Adminstyle.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="body" class="color-white">
            <h2>View All Event Listing </h2>
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
                <asp:Repeater ID="EventList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" class="listing">
                            <tr>
                                <th>Nos</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Address1</th>
                                <th>Address2</th>
                                <th>City</th>
                                <th>State</th>
                                <th>Zip</th>
                                <th>Phone</th>
                                <th>UserID</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>    
                                   
                            <td><asp:Label ID="lblRowNo" runat="server" Text='<%#Eval("RowNumber") %>'/> </td>                                             
                            <td><asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'/> </td>
                            <td><asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'/></td>
                            <td><asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address1") %>'/></td>
                            <td><asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address2") %>'/></td>
                            <td><asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'/></td>
                            <td><asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'/></td>
                            <td><asp:Label ID="lblZip" runat="server" Text='<%#Eval("Zip") %>'/></td>
                            <td><asp:Label ID="lblPhone" runat="server" Text='<%#Eval("mobileno") %>'/></td>
                            <td><asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'/></td>
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
