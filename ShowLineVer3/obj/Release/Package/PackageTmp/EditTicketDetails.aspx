<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTicketDetails.aspx.cs" Inherits="ShowLineVer3.EditTicketDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Adminstyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />
    <style type="text/css">
        .btn-danger
        {
            color: #ffffff;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
            background: #c05343;
            background: -moz-linear-gradient(top, #d65f4d, #cb4131);
            background: -webkit-gradient(linear, 0 0, 0 100%, from(#d65f4d), to(#c05343));
            background: -webkit-linear-gradient(top, #d65f4d, #c05343);
            background: -o-linear-gradient(top, #d65f4d, #c05343);
            background: linear-gradient(to bottom, #d65f4d, #c05343);
            border-color: #c05343;
        }

            .btn-danger:active, .btn-danger.active, .btn-danger.disabled, .btn-danger[disabled]
            {
                background: #cc5949;
                color: #fff;
            }
    </style>

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
        <div id="body" class="color-white">
            <h2>Edit Ticket</h2>
            <div class="w95 margin-auto">
                <div class="w90">
                    <h4>Event Name &nbsp;&nbsp;
                    <span class="btn-danger">
                        <asp:Label ID="lblEventName" runat="server" Text="   Event Name "></asp:Label></span>&nbsp;&nbsp; Event Time &nbsp;&nbsp;
                    <span class="btn-danger">
                         
                        <asp:Label ID="lblEventTime" runat="server" Text="   Event Name "></asp:Label></span>
                    </h4>
                </div>

            </div>
            <div class="w95 margin-auto">
                <asp:HiddenField ID="hdEventID" runat="server" ClientIDMode="Static"/>
                Ticket Type <asp:TextBox ID="txtTicketType" runat="server"></asp:TextBox> 
                Total Seat <asp:TextBox ID="txtTotalSeats" runat="server"></asp:TextBox> 
                Ticket Price($)<asp:TextBox ID="txtTicketPrice" runat="server"></asp:TextBox> 
                <input type="button" value="Save" class="form-button" style="width: 100px; margin-left:15px; vertical-align: middle; text-align: center;" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
                <input type="button" value="Update" class="form-button" style="width: 100px; margin-left:15px; vertical-align: middle; text-align: center;" runat="server" id="btnUpdate" visible="false" onserverclick="btnUpdate_ServerClick" />
                <input type="button" value="Reset" class="form-button" style="width: 100px; margin-left:15px; vertical-align: middle; text-align: center;" runat="server" id="btnReset"  onserverclick="btnReset_ServerClick" />
            </div>
           <asp:GridView ID="gvTicketDetails" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="Both" AutoGenerateColumns="False" 
                        Width="100%" ShowHeaderWhenEmpty="True"                        
                        DataKeyNames="EventPriceID" OnRowDataBound="gvTicketDetails_RowDataBound" OnRowDeleted="gvTicketDetails_RowDeleted" 
               OnSelectedIndexChanging="gvTicketDetails_SelectedIndexChanging" OnRowDeleting="gvTicketDetails_RowDeleting" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>                           
                        <asp:BoundField HeaderText= "Sr No" DataField="SrNo"/>
                        <asp:BoundField HeaderText= "TicketID" DataField="EventPriceID"/>
                        <asp:BoundField HeaderText= "Ticket Type" DataField="EventPriceDetails"/>
                        <asp:BoundField HeaderText= "Total seats" DataField="EventTotalSeat"/>
                        <asp:BoundField HeaderText= "Ticket Price" DataField="EventPrice"/>
                        
                        <asp:CommandField SelectText="Edit" ShowSelectButton="true" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150px"
                                ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" OnClientClick="return DeleteConfirm();"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
                            </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            <asp:HiddenField ID="hdEventSPID" runat="server" ClientIDMode="Static"/>
        </div>
    </form>
</body>
</html>
