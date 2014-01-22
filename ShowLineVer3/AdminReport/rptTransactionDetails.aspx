<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptTransactionDetails.aspx.cs" Inherits="ShowLineVer3.AdminReport.rptTransactionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Adminstyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

      <script type="text/javascript">

          $(function () {
              $('#txtEventDate').datepicker({ dateFormat: 'dd-M-yy' });
              $('#txtToDate').datepicker({ dateFormat: 'dd-M-yy' });
          });

          function GetEvent() {
               //alert('1');
               var parameter = $('#txtEventDate').val();
               //alert(parameter);
              __doPostBack('GetEvents', parameter)
          }
    </script>


</head>
<body>
    <form id="form1" runat="server">
         <h2>Online Booking Transaction Details</h2>
    <div>
        <label>Event date</label>
        <input type="text" class="textfield w10" runat="server" id="txtEventDate" autocomplete="off" readonly="true"  onchange="GetEvent();"/>
        <!--<img src="../images/calendar.png" />--> <!-- -kk-->
        <a id="datepickerImage" href="#" onclick="$('#txtEventDate').datepicker('show');"><img  src="../images/calendar.png" /></a> <!-- +kk -->
        <asp:DropDownList ID="ddEventList" runat="server" Width="200px" Style="margin-left: 10px; vertical-align: middle"></asp:DropDownList>
        <input type="button" value="Display" class="form-button" style="width: 100px; vertical-align: middle; text-align: center;" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" />
    </div>
    <br style="clear: both" />
    <asp:GridView ID="gvTransactionDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" AutoGenerateColumns="false" EmptyDataText="No Record Found">
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
             <asp:BoundField HeaderText="Ticket Nos" DataField="SeatNo" />
             <asp:BoundField HeaderText="Ticket Type" DataField="TicketType" />
            <asp:BoundField HeaderText="Customer Name" DataField="CustFirstName" />
            <asp:BoundField HeaderText="UserID" DataField="USERID" />
            <asp:BoundField HeaderText="Ticket Status" DataField="TicketStatus" />
            <asp:BoundField HeaderText="TransactionID" DataField="TransactionID" />
            <asp:BoundField HeaderText="Ticket ID" DataField="BARCODEGEN" />  
            <asp:BoundField HeaderText="Tran Details" DataField="TRANSACTIONDETAILS" />
            <asp:BoundField HeaderText="Tran. Message" DataField="EXact_Message" />
            <asp:BoundField HeaderText="Bank Resp Code" DataField="Bank_Resp_Code" />
            </Columns>
         </asp:GridView>
    </form>
</body>
</html>
