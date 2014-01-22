<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="ShowLineVer3.WebSite.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    
    <link href="../css/camera.css" rel="stylesheet" />
      <script src="../js/scroll/jquery.min.js"></script>
    <script src="../js/scroll/jquery.mobile.customized.min.js"></script>
    <style>
		body {
			margin: 0;
			padding: 0;
		}
		a {
			color: #09f;
		}
		a:hover {
			text-decoration: none;
		}
		#back_to_camera {
			clear: both;
			display: block;
			height: 80px;
			line-height: 40px;
			padding: 20px;
		}
		.fluid_container {
			margin: 0 auto;
			max-width: 1000px;
            /*max-height:300px;*/
			width: 90%;
		}

        ul li img
        {
            width:100px;
            height:75px;
        }

        .camera_fakehover img
        {
            width:180px;
            height:100px;
        }
	</style>
    
  

      <script type="text/javascript">
          jQuery(function () {

              //jQuery('#camera_wrap_1').camera({
              //    thumbnails: true
              //});

              jQuery('#camera_wrap_2').camera({
                  height: '400px',
                  loader: 'bar',
                  pagination: false,
                  thumbnails: true
              });
          });
	</script>

</head>

<body>
    <form id="form1" runat="server">
         <%--<img src="../images/slides/thumbs/bridge.jpg" --%>
        <br style="clear:both" />
        <br style="clear:both" />
        <div class="fluid_container">
          <div class="camera_wrap camera_magenta_skin" id="camera_wrap_2">
              <asp:Repeater ID="rptImageScroll" runat="server">
                  <ItemTemplate>
                      <div data-thumb="http://showsline.com/mywebsite<%# Eval("GalleryImagePath")%>" data-src="http://showsline.com/mywebsite<%# Eval("GalleryImagePath")%>" style="height:200px;width:600px;">
                          <div class="camera_caption fadeFromBottom">
                                 Camera is a responsive/adaptive slideshow. <em>Try to resize the browser window</em>
                          </div>
                      </div>
                  </ItemTemplate>
              </asp:Repeater>
          </div>  
        </div>
       
        <%--<div class="fluid_container">
        <p>Thumbnails with fixed height</p>
        <div class="camera_wrap camera_magenta_skin" id="camera_wrap_2">
            <div data-thumb="../images/slides/thumbs/bridge.jpg" data-src="../../images/slides/bridge.jpg">
                <div class="camera_caption fadeFromBottom">
                    Camera is a responsive/adaptive slideshow. <em>Try to resize the browser window</em>
                </div>
            </div>
            <div data-thumb="../../images/slides/thumbs/leaf.jpg" data-src="../../images/slides/leaf.jpg">
                <div class="camera_caption fadeFromBottom">
                    It uses a light version of jQuery mobile, <em>navigate the slides by swiping with your fingers</em>
                </div>
            </div>
            
            <div data-thumb="../../images/slides/thumbs/sea.jpg" data-src="../../images/slides/sea.jpg">
                <div class="camera_caption fadeFromBottom">
                    Camera slideshow provides many options <em>to customize your project</em> as more as possible
                </div>
            </div>
            
            <div data-thumb="../../images/slides/thumbs/tree.jpg" data-src="../../images/slides/tree.jpg">
                <div class="camera_caption fadeFromBottom">
                    Different color skins and layouts available, <em>fullscreen ready too</em>
                </div>
            </div>
        </div><!-- #camera_wrap_2 -->
    </div>--%>
        <!-- .fluid_container -->
    </form>
</body>
  
    
    <script src="../js/scroll/jquery.easing.1.3.js"></script>
    <script src="../js/scroll/camera.min.js"></script>

</html>
