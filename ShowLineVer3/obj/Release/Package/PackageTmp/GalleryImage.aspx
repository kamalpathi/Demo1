<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GalleryImage.aspx.cs" Inherits="ShowLineVer3.GalleryImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowsLine - Venue Promotions and Ticketing</title>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="js/smart-gallery.js"></script>
    <script src="js/scripts.js"></script>
    <link href="css/styleInner.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#smart-gallery').gallery({ stickthumbnails: true, random: true });
        });

    </script>

    <style type="text/css">
        .preview img
        {
            height:100%;
            width:100%;
        }
    </style>

</head>
<body style="height:400px">
    <form id="form1" runat="server">
        <div class="contentMain" style="width: 100%">
            <div class="contentWraper">
                <div class="columnLeft">
                    <div class="homeWidgets">
                        <div class="contentContainer">
                        <!--<h2>Gallery</h2>--> <!-- -kk-->
                                    <table style="border: 5px solid #1b1b1b; width: 655px; height: 25px;" cellpadding="0">
                                        <tr style="background-color: #1b1b1b; color: White">
                                            <td colspan="1">
                                                <b>&nbsp;&nbsp;&nbsp;EVENTS GALLERY</b>
                                            </td>
                                        </tr>
                                        </table>

                        <div class="contentWidgets">
                            <div id="smart-gallery">
                                <asp:Repeater ID="rptImageScroll" runat="server">
                                    <ItemTemplate>
                                        <a href="http://www.showsline.com<%# Eval("GalleryImagePath")%>" title="Events at Spin NightClub" style="height:600px;width:100%;">
                                            <img src="http://www.showsline.com<%# Eval("GalleryImagePath")%>"/></a>
                                    </ItemTemplate>
                                </asp:Repeater>                                
                            </div>
                        </div>
                    </div>
                     </div>
                </div>
                <div class="columnRight_wo_padding">
                        <div class="asideWraper"> <!-- -kk style="height:315px;overflow:auto;"> -->
                            <div class="aside">
                                <h3>Upcoming Events</h3>
                                <div class="asideData" >
                                    <ul>
                                        <li>Dance & Electronic Music
                 
                                            <ul>
                                                <asp:Repeater ID="rQuickBook" runat="server">
                                                    <ItemTemplate>
                                                        <li><a href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%>  -  <%# Eval("EventDate")%></a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                
                                            </ul>
                                        </li>                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- Aside 1 end-->

                        <div class="asideWraper">
                            <div class="aside">
                                <h3>Featured Shows</h3>
                                <div class="asideData" > <!-- -kk style="height:310px">-->
                                    <ul>
                                        <asp:Repeater ID="rFeatured" runat="server">
                                            <ItemTemplate>
                                                <li><a href="events-List.aspx?ID=<%# Eval("EventID")%>&EN=<%# Eval("EventTitle")%>"><%# Eval("EventTitle")%> -  <%# Eval("EventDate")%></a>
                                                    <ul>
                                                        <li>
                                                            <%#(((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Length>150)?((string)DataBinder.Eval(Container.DataItem, "EventDesc")).Substring(0,150) + "...":DataBinder.Eval(Container.DataItem, "EventDesc")%>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="asideWraper">
                            <div class="aside">
                                <div class="asideData" style="text-align: center">
                                    <!--<a href="#" target="_blank">
                                        <%--<img src="images/SpinNightClub.png" style="width:279px;height:207px;"/>--%>
                                        <img src="images/video-thumb.gif"/>
                                    </a>-->
                                    <!--kk-->
                                    <iframe width="292" height="300"
                                    src="http://www.youtube.com/embed/mpmkdJL54x8">
                                    </iframe>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
