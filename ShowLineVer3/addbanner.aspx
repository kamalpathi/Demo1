<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addbanner.aspx.cs" Inherits="ShowLineVer3.AdminPanel.addbanner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Event Banner</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    
    <link href="css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->


    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="../js/jquery.msgBox.js"></script>
    <script src="../js/jquery.msgBox.min.js"></script>
    <link href="../css/msgBoxLight.css" rel="stylesheet" />



    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img_prev')
.attr('src', e.target.result)
.width(728)
.height(90);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

        function ConfirmMsg(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });
        }
    </script>
    <meta charset="utf-8" />
    <!--[if IE]>
<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white" style="width:100%;height:450px">


            <h2>Upload Website Banner (Top Banner) </h2>



            <div class="w80 margin-auto">
                <br style="clear: both" />

                <!-- one column div container -->

                <div class="w60 float-left p5">
                    <div class="w100 float-left m-l-100 m-t-30">
                        <br style="clear: both" />
                        <asp:HiddenField ID="hdBanner" runat="server" />
                        <input type='file' onchange="readURL(this);" runat="server" id="filenm" />

                        <%--<input name="" type="file" onchange="readURL(this);"/>--%>
                        <br style="clear: both" />
                        <br style="clear: both" />
                        <input type="button" value="Save" class="form-button" runat="server" id="savebannerimage" onserverclick="savebannerimage_ServerClick" />
                    </div>
                    <br style="clear: both" />
                </div>

                <br style="clear: both" />

                <div class="wBanner float-left p5">
                    <fieldset class="preview-box">
                        <legend>Preview Box</legend>
                        <img id="img_prev" src="#" alt="your image" height="90" width="728" runat="server" />
                        <%--            <img id="img_prev" src="../images/images.jpg" width="728" height="90" />--%>
                    </fieldset>
                </div>
                <br />
            </div>
            <br style="clear: both" />
        </div>
    </form>
</body>
</html>
