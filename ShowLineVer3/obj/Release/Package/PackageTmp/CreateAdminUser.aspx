<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAdminUser.aspx.cs" Inherits="ShowLineVer3.AdminPanel.CreateAdminUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>ShowLine :: Create Sub Admin </title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <link href="css/Adminstyle.css" rel="stylesheet" />
    <!--[if IE 7]>
        <link href="css/ie7.css" rel="stylesheet" />
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

        function CheckNumeric(e) {

            if (window.event) // IE 
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white">
            <h2>Sub Admin User Creation</h2>
            <div class="w70 margin-auto">
                <br clear="all" />

                <!-- one column div container -->
                    
                <div class="margin-auto">

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            User Type
                        </span>
                        <span class="w70 float-left">
                            <label class="p5">
                                <asp:DropDownList ID="ddUserType" runat="server" CssClass="textfield w30">
                                    <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                 </asp:DropDownList>
                            </label>
                        </span>
                    </div>

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Full Name </label>
                        </span>
                        <span class="w70 float-left">
                            <label class="p5">
                                <asp:HiddenField runat="server" ID="hdAdminID" />
                                <input type="text" class="textfield w80" id="txtFullName" runat="server" maxlength="100"/>
                            </label>
                        </span>
                    </div>

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Mobile number</label>
                        </span>
                        <span class="w30 float-left">
                            <label class="p5">
                                <input type="text" class="textfield w80" id="txtMobileNo" runat="server" maxlength="20" onkeypress="CheckNumeric(event);" />
                            </label>
                        </span>
                    </div>

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Venue</label>
                        </span>
                        <span class="w30 float-left">
                            <label class="p5">                               
                                <asp:DropDownList ID="ddVenueDetails" runat="server" CssClass="textfield w100" readonly="true">
                                    <asp:ListItem Text="Select Venue Details" Value="Select"></asp:ListItem>
                                 </asp:DropDownList>
                            </label>
                        </span>
                    </div>
                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">User name</label>
                        </span>
                        <span class="w50 float-left">
                            <label class="p5">
                                <input type="text" class="textfield w80" id="txtUserName" runat="server" maxlength="50"/>
                            </label>
                        </span>
                    </div>
                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Email ID</label>
                        </span>
                        <span class="w50 float-left">
                            <label class="p5">
                                <input type="text" class="textfield w80" id="txtEmailID" runat="server" maxlength="100"/>
                            </label>
                        </span>
                    </div>



                    <div class="form-section">
                        <span class="w30 float-left">&nbsp;</span>
                        <span class="w70 float-left">
                            <input type="button" value="Save" class="form-button" runat="server" id="btnSave" onserverclick="btnSave_ServerClick"/>
                            <input type="button" value="Update" class="form-button" runat="server" id="btnUpdate" onserverclick="btnUpdate_ServerClick" visible="false"/>

                          <%--  <input type="button" value="Reset" class="form-button m-l-5"/>--%>
                        </span>
                    </div>
                    <br style="clear:both"/>
                </div>
                <br style="clear:both"/>
            </div>
        </div>
    </form>
</body>
</html>
