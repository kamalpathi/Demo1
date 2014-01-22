<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="ShowLineVer3.settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Settings</title>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>

    <link href="css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->


    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />

    <meta charset="utf-8" />
    <!--[if IE]>
        <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

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
            
            <h2>Change password </h2>

            <div class="w70 margin-auto">
                <br style="clear: both;" />

                <!-- one column div container -->

                <div class="margin-auto">

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Old password </label>
                        </span>
                        <span class="w40 float-left">
                            <label class="p5">
                                <input type="password" class="textfield w80" id="txtoldpwd" runat="server" maxlength="50" />
                                  <br style="clear: both;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtoldpwd" runat="server" ErrorMessage="Enter Old Password" Display="Dynamic"></asp:RequiredFieldValidator>
                            </label>
                        </span>
                    </div>

                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">New password </label>
                        </span>
                        <span class="w40 float-left">
                            <label class="p5">
                                <input type="password" class="textfield w80" id="txtNewpwd" runat="server" maxlength="50" />
                                  <br style="clear: both;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewpwd" runat="server" ErrorMessage="Enter New Password" Display="Dynamic"></asp:RequiredFieldValidator>
                            </label>
                        </span>
                    </div>
                    <div class="form-section">
                        <span class="w30 float-left textname align-right">
                            <label class="p5">Confirm password </label>
                        </span>
                        <span class="w40 float-left">
                            <label class="p5">
                                <input type="password" class="textfield w80" id="txtConfirmPwd" runat="server" maxlength="50"/>
                                 <br style="clear: both;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtConfirmPwd" runat="server" ErrorMessage="Re-Enter New Password" Display="Dynamic"></asp:RequiredFieldValidator>
                                <br style="clear: both;" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New and Confirm password should be same." ControlToValidate="txtNewpwd" ControlToCompare="txtConfirmPwd"></asp:CompareValidator>
                            </label>
                        </span>
                    </div>



                </div>

                <div class="form-section">
                    <span class="w30 float-left">&nbsp;</span>
                    <span class="w70 float-left">
                        <input type="button" value="Change Password" class="form-button" id="cmdPwd" runat="server" onserverclick="cmdPwd_ServerClick"/></span>
                </div>
                <br style="clear: both;" />

                <br style="clear: both;" />
            </div>
        </div>
    </form>
</body>
</html>
