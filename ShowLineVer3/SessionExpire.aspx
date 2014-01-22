<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionExpire.aspx.cs" Inherits="ShowLineVer3.SessionExpire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <br style="clear:both" />
            <br style="clear:both" />
        <span class="reason" style="font-size:xx-large">SESSION EXPIRED</span>
        <br style="clear:both" />

        <br style="clear:both" />
        <span class="reason-title">- Your Session is expired.To login please click on link. -</span>
         <a href="Admin.aspx" title=""  target="_top" class="btn btn-success span6">Back to the website</a>
        </center>
    </div>
    </form>
</body>
</html>
