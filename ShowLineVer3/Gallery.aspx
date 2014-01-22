<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="ShowLineVer3.AdminPanel.Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Gallery</title>
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
                    .width(198)
                    .height(120);
                };

                reader.readAsDataURL(input.files[0]);
               
                if ($('#hdval').val() < 20) {
                    $('.form-button').prop('disabled', false); //TO ENABLE
                }
                else {
                    ConfirmMsg("Maximum Limit of uploading Image Exeeded.","Event Gallery Validation");
                }
            }
        }

        function ConfirmMsg(msgcontents, msgHeader) {
            $.msgBox({
                title: msgHeader,
                content: msgcontents,
                type: "info"
            });           
        }

        function EnabelBtn() {
            $('.form-button').prop('disabled', true); //TO DISABLED
        }

        //$('input:button').click(function () {
        //    //$('p').text("Form submiting.....").addClass('submit');
        //    $('input:button').attr("disabled", true);
        //});      
    </script>
    <meta charset="utf-8" />
    <!--[if IE]>
<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white">
            <h2>Gallery</h2>
            <div class="w95 margin-auto">

                <!-- one column div container -->
                <div class="w100 float-left tab-section">
                    <div class="float-left w30">
                        <fieldset class="preview-boxEvent">
                            <legend>Preview Box</legend>
                            <span class="float-left">
                                <img id="img_prev" src="~/images/images.jpg" runat="server" style="height: 120px; width: 198px" />
                            </span>
                        </fieldset>
                    </div>
                    <div class="float-left w50" style="margin-top:50px">
                        <span class="float-left w50">
                            <span  class="w70 float-left textname align-right">
                                <label class="p5">Upload Gallery Image</label>
                                </span>
                            <asp:HiddenField ID="hdval" runat="server" />
                            <input type='file' onchange="readURL(this);" class="textfield w80" runat="server" id="filenm" />
                            <br style="clear:both" />
                            <br style="clear:both" />
                            <input type="button" value="Save" class="form-button" id="btnSave" runat="server" onserverclick="btnSave_ServerClick" disabled="disabled" onclick="EnabelBtn();" />
                        </span>
                    </div>
                </div>
                <br style="clear:both" />
                <br style="clear:both" />
                <asp:DataList ID="dlImages" runat="server" RepeatColumns="4" CellPadding="5" Width="100%" OnItemCommand="dlImages_ItemCommand">
                    <ItemTemplate>
                       <%--<a id="imageLink" href='<%# Eval("GalleryImagePath","{0}") %>' title='<%#Eval("Description") %>' rel="lightbox[Brussels]" runat="server" >--%>
                            <asp:HiddenField ID="EventID" runat="server" Value='<%#Eval("GalleryID") %>'/>
                            <asp:Image ID="Image1" ImageUrl='<%# Bind("GalleryImagePath", "{0}") %>' runat="server" Width="198" Height="120" />
                        
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("GalleryID") + ";" + Eval("GalleryImagePath") %>' CommandName="delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'><img src="images/delete.png" /></a>Delete</asp:LinkButton>

                           
                        <%--</a> --%>
                    </ItemTemplate>
                </asp:DataList>

                
            </div>
            <br style="clear:both" />
            <br style="clear:both" />
        </div>
    </form>
</body>
</html>
