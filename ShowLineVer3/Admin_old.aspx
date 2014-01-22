<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ShowLineVer3.AdminPanel.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>ShowLine :: Login</title>
    
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="page">
            <div id="header">
                <div style="float:left">
                    <a href="index.html" style="width:220px">
                        <img src="images/logo.png" alt="Logo" />
                    </a>
                     
                </div>
               <div style="float:left; width:60%">
                   <center>                       
                            <img src="images/AdminTool%20.png" />
                   </center>
                    
                </div>
            </div>
            <br clear="all" />
            <br clear="all" />
            <div id="body">
                <span class="title">
                    <label>Admin Login</label></span><br style="clear:both;" />
                <ul>
                    <li>

                        <span class="login-img">
                            <img src="images/book-your-post.png" /></span>

                    </li>
                    <li>


                        <div class="w100 margin-auto">
                            <br clear="all" />
                            <br clear="all" />

                            <!-- one column div container -->

                            <div class="margin-auto login-box">

                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Username</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <input type="text" class="textfield w80 inputUserName" id="UserNm" runat="server"/></label>                                           
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left textname align-right">
                                        <label class="p5">Password</label>
                                    </span>
                                    <span class="w70 float-left">
                                        <label class="p5">
                                            <input type="password" class="textfield w80 inputpwd" runat="server" id="tpassword"/></label>
                                    </span>
                                </div>
                                <div class="form-section">
                                    <span class="w30 float-left">&nbsp;</span>
                                    <span class="w70 float-left">
                                        <a href="#">

                                        <input id="btnSubmit" type="button" value="Submit" class="form-button" runat="server" onserverclick="btnSubmit_ServerClick" />

                                        </a>

                                    </span>
                                </div>
                                <br clear="all" />

                            </div>
                            <br clear="all" />
                        </div>

                    </li>

                </ul>
            </div>
            <div id="footers" style="background-color: #2d1c12;"">

                <div style="position:absolute;bottom:0;width:100%">
                    <span class="title">
                    <center> <p class="footnote" style="margin:0 auto;">Copyright &copy; Showsline. All right reserved.</p>  </center>                  
                        </span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
