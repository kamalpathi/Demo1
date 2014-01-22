<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addvenue.aspx.cs" Inherits="ShowLineVer3.AdminPanel.addvenue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>ShowLine :: Add/Update Venue Details</title>
    <link href="css/Adminstyle.css" rel="stylesheet" />
    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
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

        function CheckValidation(msgcontents, msgHeader, target) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                afterClose: function (result) {
                    if (target == 'txtVenueName') {
                        $('#txtVenueName').css("background-color", "yellow");
                        $('#txtVenueName').focus();
                    }
                },
                afterShow: function (result) {
                    $(target).css("background-color", "yellow");
                    $(target).focus();
                }
            });
        }
    </script>


    
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img_prev')
                        .attr('src', e.target.result)
                        .width(198)
                        .height(295);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</head>

<body>
    <form id="form1" runat="server">
<div id="body" class="color-white" style="width:98%;height:512px;">
		


			<h2 ><asp:label id="lblID" runat="server" Text="Add Venue Details"></asp:label></h2>
            


                            <div class="w90 margin-auto">
                            <br style="clear:both"/>
                            
                            <!-- one column div container -->
                            
                            
            				<div class="w30 float-left p5">
                            	<fieldset class="preview-boxEvent"><legend>Preview Box</legend>
                                	<img id="img_prev" src="~/images/images.jpg" runat="server" style="height:295px;width:198px"/>
                             	</fieldset>       
                             </div>                                                                                                                                                                        
                            <div class="w60 float-left p5">


                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">Venue Name</label>
                                </span>
                                <span  class="w70 float-left">
                                <label class="p5">
                                        <asp:HiddenField ID="hdVenueID" runat="server" />
										<input type="text" class="textfield w80" id="txtVenueName" runat="server" maxlength="50"/>
    							</label>
                                </span>
                            </div>
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">Street Address</label>
                                </span>
                                <span  class="w60 float-left">
                                <label class="p5">
										<input type="text" class="textfield w80" runat="server" id="txtStreetAddress" maxlength="200"/>
                                        
                                </label>
                                </span>
                            </div>
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">City</label>
                                </span>
                                <span  class="w50 float-left">
                                <label class="p5">
										<input type="text" class="textfield w80" runat="server" id="txtCity" maxlength="100"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCity" ValidationExpression="[a-zA-Z][a-zA-Z ]+" ErrorMessage="Enter valid city name." Display="Dynamic"></asp:RegularExpressionValidator>
                                </label>
                                </span>
                            </div>
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">State/Provision</label>
                                </span>
                                <span  class="w50 float-left">
                                <label class="p5">
										<input type="text" class="textfield w80" runat="server" id="txtStateProvision" maxlength="100"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStateProvision" ValidationExpression="[a-zA-Z][a-zA-Z ]+" ErrorMessage="Enter valid state name." Display="Dynamic"></asp:RegularExpressionValidator>
                                </label>
                                </span>
                            </div>                               
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">Zip  Code</label>
                                </span>
                                <span  class="w50 float-left">
                                <label class="p5">
										<input type="text" class="textfield w80" runat="server" id="txtZipCode" maxlength="20"/>
                                        <br style="clear:both" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtZipCode" ValidationExpression="^[0-9]{1,20}$" ErrorMessage="Enter valid Zip code." Display="Dynamic"></asp:RegularExpressionValidator>
                                    
                                </label>
                                </span>
                            </div>
                            
                           
                            
                            
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">Upload Seat Layout</label>
                                </span>
                                <span  class="w50 float-left">
                                <label class="p5">		
                                    <asp:HiddenField ID="VenueImagePath" runat="server" />								
                                    <input type='file' onchange="readURL(this);" class="textfield w80" runat="server" id="filenm" />
                                </label>
                                </span>
                            </div>
                            
                           <%-- <div class="form-section">
                                <span  class="w30 float-left textname align-right">
                                <label class="p5">Upload Ticket Background Image</label>
                                </span>
                                <span  class="w50 float-left">
                                <label class="p5">
										<input type="file" class="textfield w80">
                                </label>
                                </span>
                            </div> --%>
                            
                            <div class="form-section">
                                <span  class="w30 float-left textname align-right">&nbsp;</span>
                                <span class="w50 float-left">
                                    <input type="button" value="Save" class="form-button" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" />
                                    <input type="button" value="Update" class="form-button" id="btnUpdate" runat="server" onserverclick="btnUpdate_ServerClick" />
                                </span>
                            </div>                        
                            <br style="clear:both">                                                       
                            
                                                                                    
                            </div>                             
                                                                                   

                            
                            </div><br style="clear:both">

		</div>    </form>
</body>
</html>
