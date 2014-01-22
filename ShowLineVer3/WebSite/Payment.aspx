<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ShowLineVer3.WebSite.Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <!--<link href="../css/styleInner.css" rel="stylesheet" />-kk -->
    <link href="css/styleInner.css" rel="stylesheet" /> <!-- +kk -->

    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="../js/scripts.js"></script>
    <%--<link href="../css/EventList.css" rel="stylesheet" />--%>
    <script src="../js/jquery.timer.js"></script>
    <%--<script src="../js/jquery.min.js"></script>--%>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />
    <script src="js/showsline.js"></script>
    <style type="text/css">
        #time-left
        {
            position: fixed;
            right: 0;
            top: 50%;
            width: 8em;
            margin-top: -2.5em;
        }
    </style>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            var timer = new (function () {
                var $countdown,
                    $form, // Form used to change the countdown time
                    incrementTime = 70,
                    currentTime = 60000,
                    //currentTime = 1000,

                    updateTimer = function () {
                        $('.countdown').html(formatTime(currentTime));
                        if (currentTime == 0) {
                            timer.Timer.stop();
                            timerComplete();
                            //Example2.resetCountdown();
                            return;
                        }
                        currentTime -= incrementTime / 10;
                        if (currentTime < 0) currentTime = 0;
                    },
                    timerComplete = function () {
                        Msg('Time completed. Ticket alloted will be sent back to process.', 'Timeout');
                    },
                    init = function () {
                        $countdown = $('.countdown');
                        timer.Timer = $.timer(updateTimer, incrementTime, true);
                    };
                this.resetCountdown = function () {
                    var newTime = parseInt($form.find('input[type=text]').val()) * 100;
                    if (newTime > 0) { currentTime = newTime; }
                    this.Timer.stop().once();
                };
                $(init);
            });

            function formatTime(time) {
                var min = parseInt(time / 6000),
                    sec = parseInt(time / 100) - (min * 60),
                    hundredths = pad(time - (sec * 100) - (min * 6000), 2);
                return (min > 0 ? pad(min, 2) : "00") + ":" + pad(sec, 2) + ":" + hundredths;
            }

            function pad(number, length) {
                var str = '' + number;
                while (str.length < length) { str = '0' + str; }
                return str;
            }

            function Msg(msgcontents, msgHeader) {
                $.msgBox({
                    title: msgHeader,
                    content: msgcontents,
                    type: "info"
                });
            }

            function ShowLoading() {
                alert('1');

                document.getElementById('Processing-loading').style.visibility = 'visible';
                document.getElementById('Processing-loading').style.display = 'block';
                __doPostBack('btnSubmit', '')
            }

            function StopLoading() {
                document.getElementById('Processing-loading').style.visibility = 'hidden';
                document.getElementById('Processing-loading').style.display = 'none';
            }
        });
    </script>

    <script type="text/javascript">
        window.onload = function () { Clear(); }
        function Clear() {
            var Backlen = history.length;
            if (Backlen > 0) history.go(-Backlen);
        }

        if (window.history.forward(1) != null)
            window.history.forward(1);
    </script>
</head>
<body onload=" window.scrollTo(0, 0);">

    <form id="form1" runat="server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
         <div id="Processing-loading" style="display: none; visibility: hidden; position: absolute;">
            <img src="images/ajax-loader.gif" class="ajax-spinner" alt="" height="31" width="31" />
             Please Don't Click Refresh or Back Button. Connecting to server ..... 
        </div>

        <div class="container" style="width: 100%">
            <!-- Content area -->
            <div class="time-left">
                <span>Time left to complete page</span>
                <span class='countdown' style="float: right; clear: none"></span>
                <%--<label>4:50</label>--%>
            </div>
            <!-- -kk <br style="clear: both;" />
            <p></p>-->
            <div class="contentMain">
                <div class="contentWraper">
                     <div class="columnLeft">  
                    <div class="contentContainer">
                        <!--<h2>REVIEW</h2>-->  <!-- kk -->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 900px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;REVIEW</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>

                        <div class="contentWidgets">
                            <p>
                                <img src="images/bob-dylan-tickets-75x75.jpg" id="EvtImage" runat="server" style="width: 150px; height: 150px" />
                            </p>
                            <div class="eventDetails">
                                <h4>
                                    <asp:Label ID="lblEventName" runat="server" Text="Label" Font-Size="Medium" Font-Bold="true" Style="color: maroon"></asp:Label></h4>
                                <!--<p><strong>Venue :</strong></p>-->
                                <h3> Venue : </h3>
                                <p>
                                    <asp:Label ID="lblVenueName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                </br>
                                <h3>Date & Time :</h3> <!-- kk-->
                                <p>
                                   <asp:Label ID="lblDateTime" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                </br>
                                <!--<p>
                                    <strong>Location :</strong>
                                </p>-->
                                <h3>Location :</h3>
                                <p>
                                    <asp:Label ID="lblStreetAddress" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblCity" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblState" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblZip" runat="server" Text="Label" Font-Bold="true"></asp:Label>
                                </p>
                            </div>
                            <!--            <div class="ticket">
            	<div>
                    <p>Ticket Type:</p>
                    <p><strong> VIP</strong></p>
                    <p> Ticket Price:</p>
                    <p> <strong>100 USD</strong></p>
                    <p>Quantity:</p>
                    <p><strong>1</strong></p>
                </div>
            	<div>
                    <p>Sub Total:</p>
                    <p><strong> 100 USD</strong></p>
                    <p> Tax:</p>
                    <p> <strong>2 USD</strong></p>
                    <p>Processing Fee:</p>
                    <p><strong>5 USD</strong></p>
                </div> 
                <span>Total Charges : 107 USD </span>
               
            </div> -->

                            <div class="kkbox">
                                <div>
                                    <%-- <label>Ticket Type: </label>--%>
                                    <%--<asp:Label ID="lblTicketType" runat="server" Text="Ticket Type" style="text-align:left;"></asp:Label>
                                    <hr />--%>
                                    <%--<br style="clear:both;" />
                                    <label>Ticket Price: </label>
                                    <asp:Label ID="lblPrice" runat="server" Text="Ticket Price" style="text-align:left;"></asp:Label>
                                    <br style="clear:both;" />
                                    <label>Quantity: </label>
                                     <asp:Label ID="lblQty" runat="server" Text="Ticket Qty" style="text-align:left;"></asp:Label>
                                    <br style="clear:both;" />
                                    <p>
                                        <br />
                                    </p>
                                    <label>Sub Total: </label>
                                     <asp:Label ID="lblSubTotal" runat="server" Text="SubTotal" style="text-align:left;"></asp:Label>
                                     <br style="clear:both;" />

                                    <label>Tax: </label>
                                    <asp:Label ID="lblTax" runat="server" Text="SubTotal" style="text-align:left;"></asp:Label>
                                     <br style="clear:both;" />
                                    <label>Processing Fee: </label>
                                    <asp:Label ID="lblProcessingFees" runat="server" Text="Processing Fees" style="text-align:left;"></asp:Label>--%>

                                    <asp:Repeater ID="rptPayment" runat="server" OnItemDataBound="rptPayment_ItemDataBound">
                                        <HeaderTemplate>
                                            <table style="border: 1px solid #c80202; width: 95%; height: auto; font-size: 14px" cellpadding="0">
                                                <tr style="background-color: #c80202; color: White">
                                                    <td style="width: 100px">Ticket type</td>
                                                    <td style="width: 50px">Qty</td>
                                                    <td style="width: 50px">Amt</td>
                                                    <td style="width: 50px">Total</td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="margin-top: 5px; padding-top: 5px"><%# Eval("TicketType")%></td>
                                                <td><%# Eval("Qty")%></td>
                                                <td><%# Eval("TicketPrice")%></td>
                                                <td><%# Eval("AMT")%></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <td colspan="4">
                                                    <hr />
                                                </td>
                                                <%--<td><img src="../images/dots.png" style="width:50px;height:2px"/></td>
                                                <td><img src="../images/dots.png" style="width:50px;height:2px"/></td>
                                                <td><img src="../images/dots.png" style="width:50px;height:2px"/></td>--%>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left">
                                                    <span class="SummaryFont">Sub Total</span>
                                                </td>
                                                <td style="text-align: center"><span class="SummaryFont">$ <%#SubtotalP()%></span></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <hr />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left"><span class="SummaryFont">Processing Fee</span></td>
                                                <td style="text-align: center"><span class="SummaryFont">$ 0.0</span></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <hr />
                                                </td>

                                            </tr>
                                            <!--<tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left"><span class="SummaryFont">Tax</span></td>
                                                <td style="text-align: center"><span class="SummaryFont">$ 0.0</span></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2">
                                                    <hr />
                                                </td>

                                            </tr>-kk -->
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td style="text-align: left; margin-bottom: 15px; padding-bottom: 15px; color:red;"><span class="SummaryFont">Total Amt</span></td>
                                                <td style="text-align: center; margin-bottom: 15px; padding-bottom: 15px; color:red;"><span class="SummaryFont">$ <%#SubtotalP()%></span></td> <!--kk-->
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </div>

                                <%--<p>
                                    <br/>
                                </p>
                                <strong>
                                    <label>Total Charges: </label>
                                     <asp:Label ID="lblTotalCharges" runat="server" Text="Charge" style="text-align:left;"></asp:Label>
                                </strong>--%>
                            </div>
                        </div>

                        <br style="clear: both" />
                        <br style="clear: both" />

                        <!--<h2>PAYMENT</h2>-->
                                    <HeaderTemplate>
                                        <table style="border: 5px solid #353535; width: 912px; height: 25px;" cellpadding="0">
                                            <tr style="background-color: #353535; color: White">
                                                <td colspan="1">
                                                    <b>&nbsp;&nbsp;&nbsp;PAYMENT</b>
                                                </td>
                                            </tr>
                                            </table>
                                    </HeaderTemplate>



                        <div class="contentWidgets">
                            <div class="contentInnerWrap">
                                <p>
                                    <table width="100%" border="0" cellpadding="10" cellspacing="1">
                                        <tr>
                                            <td width="35%">
                                                <p><strong>Select Payment Method</strong></p>
                                            </td>
                                            <td colspan="2">
                                                <p><strong>Payment Details</strong></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p>
                                                    <input type="radio" />Credit Card
                                                </p>
                                                <!--<p><img src="images/credit-card-1.png" class="card"/><img src="images/credit-card-1.png" class="card"/><img src="images/credit-card-1.png" class="card"/></p>-->
                                                <p>
                                                    <img src="../images/visa-master.jpg" class="card" />
                                                </p>
                                            </td>
                                             <td>
                                                <p>
                                                    Card Holder Name
                                                    <%--<input id="Text1" type="text" style="width:200px" maxlength="50" />--%>
                                                    <asp:TextBox ID="txtCard" runat="server" autocomplete="off"></asp:TextBox>

                                                </p>
                                            </td>
                                            <!--<td>
                                                <p>
                                                    <%--Select Credit Card
                                                    <select name="credit card"> 
                                                        <option value="1">Visa</option>
                                                        <option value="2">Mastercard</option>
                                                        <option value="3">Discover</option>
                                                        <option value="4">American Express</option>
                                                    </select>--%>
                                                </p>
                                            </td>-->

                                            <td>
                                                <p>
                                                    Credit Card Number
							                        <%--<input type="text" id="txtCardNumber1" runat="server" maxlength="20"/>--%>
                                                    <asp:TextBox id="txtCardNumber" runat="server" MaxLength="20" autocomplete="off"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCardNumber" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </p>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td></td>
                                            <td>
                                                <p>Expiry Date</p>
                                            </td>
                                            <td>
                                                <p>Security Code</p>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td>
                                                <p>

                                                    <asp:DropDownList ID="ccMonth" runat="server">
                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>

                                                    <select name="ccYear" runat="server" id="ccYear">
                                                        <option value="13">2013</option>
                                                        <option value="14">2014</option>
                                                        <option value="15">2015</option>
                                                        <option value="16">2016</option>
                                                        <option value="17">2017</option>
                                                        <option value="18">2018</option>
                                                        <option value="19">2019</option>
                                                        <option value="20">2020</option>
                                                        <option value="21">2021</option>
                                                        <option value="22">2022</option>
                                                        <option value="23">2023</option>
                                                        <option value="24">2024</option>
                                                        <option value="25">2025</option>
                                                        <option value="26">2026</option>
                                                        <option value="27">2027</option>
                                                        <option value="28">2028</option>
                                                        <option value="29">2029</option>
                                                        <option value="30">2030</option>
                                                    </select>


                                                    <!--<select name="credit card"> 
                                                        <option value="1">01</option>
                                                        <option value="2">02</option>
                                                        <option value="3">03</option>
                                                        <option value="4">04</option>
                                                        <option value="5">05</option>
                                                        <option value="6">06</option>
                                                        <option value="7">07</option>
                                                        <option value="8">08</option>
                                                        <option value="9">09</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                    </select>
                                                    <select name="credit card">
                                                        <option value="1">2013</option>
                                                        <option value="2">2014</option>
                                                        <option value="3">2015</option>
                                                        <option value="4">2016</option>
                                                        <option value="5">2017</option>
                                                        <option value="6">2018</option>
                                                        <option value="7">2019</option>
                                                        <option value="8">2020</option>
                                                        <option value="9">2021</option>
                                                        <option value="10">2022</option>
                                                        <option value="11">2023</option>
                                                        <option value="12">2024</option>
                                                        <option value="13">2025</option>
                                                    </select>-->
                                                </p>
                                            </td>
                                            <td>
                                                <p>
                                                    <%--<input type="text" size="5" id="txtCVV1" runat="server" maxlength="5"/><br />--%>
                                                    <asp:TextBox runat="server" size="5" MaxLength="5" ID="txtCVV" autocomplete="off"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCVV"
                                                        FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                    <!--<a title="Three digits at the back side of the Credit Card" href===========================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================-#">Whats this</a>-->
                                                    <!--<a title="Three digits at the back side of the Credit Card" href="#"">Whats this</a>-->
                                                    <a title="For MasterCard, Visa or Discover, it's the last three digits in the signature area on the back of your card. For American Express, it's the four digits on the front of the card." href="#"">Whats this</a>
                                                </p>
                                            </td>

                                        </tr>

                                    </table>

                                </p>
                            </div>
                        </div>

                        <!--          <div class="contentWidgets">
          	<div class="contentInnerWrap">
                <p>
                	<table width="100%" border="0" cellpadding="10" cellspacing="1">
                      <tr>
                        <td width="52%"><p>Expiry Date</p></td>
                        <td><p>Security Code</p></td>
                      </tr>
                      <tr>
                        <td>
                        	<p>
                            <select name="credit card">
                            	<option value="1">Please select month</option>
                                <option value="2">January</option>
                            </select>  
                            <select name="credit card">
                            	<option value="1">Please select year</option>
                                <option value="2">2013</option>
                            </select>                                                      
                            </p>
                        </td>
                        <td>
                        	<p>
							<input type="text"/><br/><a href="#">Whats this</a>
                            </p>
                         </td>
                        
                      </tr>
                    </table>

                </p>
            </div>
          </div>
    -->


                        <div class="contentWidgets">
                            <div class="contentInnerWrap">
                                <!--       <p><input type="button" class="form-button" value="Submit Order"> <a href="#">Cancel Order</a></p>-->
                                <p class="single-row">                                    
                                    <input type="button" value="Submit Order" class="form-button" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick"/>
                                    <a href="../ContentMain.aspx"><strong>Cancel Order</strong></a> <!--kk-->
                                </p>
                                <p>By clicking the Submit Order button you are agreeing to the Purchase Policy and Privacy Policy of Showsline. All orders are subjected to the credit card <br/>approval. Thank You.</p>
                            </div>
                        </div>


                    </div>

                    </div>

                    <!--   <div class="columnRight"> 
        

        
        <div class="asideWraper">
          <div class="aside">
            <h3>Featured Shows</h3>
            <div class="asideData">
              <ul>
                <li><a href="#">UFC 160 Tickets</a>
                  <ul>
                    <li>Velasquez vs. Silva in Las Vegas - Catch the battle in the octagon!!</li>
                  </ul>
                </li>
                <li><a href="#">NASCAR Tickets</a>
                  <ul>
                    <li>The 2013 NASCAR Sprint Cup Race for the Cup will be here soon!</li>
                  </ul>
                </li>
                <li><a href="#">Tennis Tickets</a>
                  <ul>
                    <li>Watch all the action on the court! Wimbledon, BNP Paribas Open... </li>
                  </ul>
                </li>
              </ul>
            </div>
          </div>
        </div>

        <div class="asideWraper">
          <div class="aside">
            <div class="asideData" style="text-align:center"> <img src="images/video-thumb.gif" /> </div>
          </div>
        </div>
		
      </div>-->
                </div>
            </div>
           <asp:HiddenField ID="totval" runat="server" /><!--kk-->
        </div>
    </form>
</body>
</html>
