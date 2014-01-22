<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ShowLineVer3.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="css/rptss.css" rel="stylesheet" />--%>
    <link href="css/rptcss.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <%--<script src="js/reportjs.js"></script>--%>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            $("#printMe").click(function () {

                window.print();
                return false;
            });
            // print();
        });
        function printTicket() {
            window.print();
            return false;
        }
    </script>
</head>
<body onload="printTicket();">
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>                
            </HeaderTemplate>
            <ItemTemplate>
                <div class="horizontal" id="ticket">

                    <ul class="body" style="z-index:100;">
                        <li>
                            <%# Eval("VenueName")%>, <%# Eval("city")%>
                        </li>
                        
                        
                        <li  style="font-size:x-large;color:#5A1515">
                            <%# Eval("EventTitle")%>
                        </li>                        
                        <li style="font-size:large;color:#5A1515">
                            <div> <%# Eval("TicketType")%> </div>
                        </li>

                       
                        <li>
                            <ul>
                                <li>
                                    ADMIT ONE(1)
                                    <div style="float:right;position:relative;top:-8px;">$  <%# Eval("TicketPrice")%></div>  
                                </li>
                            </ul>                             
                        </li>

                     
                        <li>
                             Date & Time : <%# Eval("EventDate")%> , <%# Eval("EventFromTime")%> <!---  <%# Eval("EventToTime")%>-->
                        </li>

                      
                        <li>
                             Address : <%# Eval("StreetAddress")%>, <%# Eval("city")%>, <%# Eval("StateProvision")%>, <%# Eval("ZipCode")%>
                        </li>

                       
                        <li>
                              Booking Info : <%# Eval("custfirstname")%>  , Booked on  <%# Eval("TicketCheckoutDate")%>
                        </li>

                      
                        <li>
                               <span font-size: small;>  For assistance call (888) 312-8886 or www.showsline.com</span> <br />
                               <span font-size: small; style="color:red">  Note: Please carry a copy of printed ticket at the venue.</span> 
                        </li>
                        <li>
                              <span style="font-size:11px;float:right;"> Ticket ID <%# Eval("BarCodeGen")%> </span>
                        </li>
                    </ul>

                    <ul class="stub"  style="z-index:100;">
                        <li> <img src="http://www.showsline.com/Barcode/<%# Eval("BarCodeGen")%>.png" /></li>
                        <li></li>                                           
                    </ul>
                   
                    <!--      <div class="proof"  style="z-index:3;">
                        <img  style="z-index:3;width:60%;height:320px" src="http://www.showsline.com/<%# Eval("EventLayout")%>">
                    </div>-->

                    <div class="proof" style="display:block;background:url('/images/Spin1.png"');">
                        <img src=""/>
                    </div>    
                </div>
              
            </ItemTemplate>
            <FooterTemplate>
                 
            </FooterTemplate>
        </asp:Repeater>

        <%--<asp:Repeater ID="rpt" runat="server">
            <HeaderTemplate>
                <table style="width:60%" border="1">
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>                        
                        <td>
                            <table style="width:60%" border="1">
                                <tr>
                                    <td class="textcenter" colspan="2"><%# Eval("VenueName")%>,<%# Eval("city")%> </td>                                    
                                    <td  rowspan="2" style="width:20px">
                                        <div>
                                            <img src="Barcode/DES2906G0000001.png" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2" style="font-size:x-large;color:#5A1515">
                                        <%# Eval("EventTitle")%>
                                    </td>         
                                    
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2" style="font-size:x-large">
                                        <%# Eval("TicketType")%>
                                    </td>                   
                                    
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2">
                                        <div style="width:60%;text-align:center"> Admits 1</div>
                                        <div style="float:right"> $  <%# Eval("TicketPrice")%></div>                                        
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2">
                                        Date & Time : <%# Eval("EventDate")%> , <%# Eval("EventFromTime")%> -  <%# Eval("EventToTime")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2">
                                        Address : <%# Eval("StreetAddress")%> , <%# Eval("StateProvision")%> ,  <%# Eval("city")%> ,  <%# Eval("ZipCode")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2">
                                        Booking Info : <%# Eval("custfirstname")%>  , Booked on  <%# Eval("TicketCheckoutDate")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textcenter" colspan="2">
                                        Note: Please carry a copy of printed ticket at the venue.
                                    </td>
                                </tr>
                            </table>
                        </td>                       
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>--%>
    </div>
    </form>
</body>
</html>
