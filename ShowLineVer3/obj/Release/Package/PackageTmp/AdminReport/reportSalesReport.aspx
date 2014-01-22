<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportSalesReport.aspx.cs" Inherits="ShowLineVer3.AdminReport.reportSalesReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Event Sales Report</title>
    <link href="../css/Adminstyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script type="text/javascript">

        $(function () {
            $('#txtEventDate').datepicker({ dateFormat: 'dd-M-yy' });
        });

        function GetEvent() {
            //alert('1');
            //var parameter = $('#txtEventDate').val();
            var parameter = $('#ddVenue').val();
            //alert(parameter);
            __doPostBack('GetEvents', parameter)
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <h2>Event Sales Report</h2>
        <div>
            <label>Event date</label>
            <input type="text" class="textfield w10" runat="server" id="txtEventDate" autocomplete="off" readonly="true" />
            <!--<img src="../images/calendar.png" />-->
            <!-- -kk-->
            <a id="datepickerImage" href="#" onclick="$('#txtEventDate').datepicker('show');">
                <img src="../images/calendar.png" /></a>
            <!-- +kk -->
            <label>Select Venue</label>
            <asp:DropDownList ID="ddVenue" runat="server" Width="150px" Style="margin-left: 10px; margin-right:10px; vertical-align: middle" ClientIDMode="Static" onchange="GetEvent();"></asp:DropDownList>

            <label>Select Event</label>
            <asp:DropDownList ID="ddEventList" runat="server" Width="200px" Style="margin-left: 10px; vertical-align: middle"></asp:DropDownList>
            <input type="button" value="Display" class="form-button" style="width: 100px; vertical-align: middle; text-align: center;" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />

            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/images/icon-download-xls.gif" onclick="btnExcel_Click" />
        </div>
        <br style="clear: both" />
        <asp:GridView ID="gvTransactionDetails" runat="server" CellPadding="4" ForeColor="#333333"  GridLines="Both" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Found">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:BoundField HeaderText="Event Name" DataField="EventTitle" />
                <asp:BoundField HeaderText="Event Date" DataField="EventDate" />
                <asp:BoundField HeaderText="Ticket Type" DataField="TicketType" />
                <asp:BoundField HeaderText="Ticket Price" DataField="TPrice" />
                <asp:BoundField HeaderText="Ticket Sold" DataField="TicketSold" />                
                <asp:BoundField HeaderText="Amount" DataField="TicketPrice" />
                <asp:BoundField HeaderText="UserID" DataField="EventSPID"  Visible="false"/>
                <asp:BoundField HeaderText="Booking Type" DataField="BOOKINGTYPE" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
