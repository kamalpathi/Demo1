<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventSettings.aspx.cs" Inherits="ShowLineVer3.EventSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowLine :: Event Settings</title>
    <link href="css/Adminstyle.css" rel="stylesheet" />

    <!--[if IE 7]>
		<link rel="stylesheet" type="text/css" href="css/ie7.css" />
	<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div id="body" class="color-white">
            <h2>Event Settings</h2>

            <div class="float-right">
                      Select Page
                        <asp:DropDownList ID="drdpPage" runat="server" Width="110px" AutoPostBack="True"
                            OnSelectedIndexChanged="drdpPage_SelectedIndexChanged">
                        </asp:DropDownList>
                    Search
                    <asp:TextBox ID="txtSearchBy" runat="server"></asp:TextBox>
                    <input type="button" value="Search" class="form-button" runat="server" id="searchEvent" onserverclick="searchEvent_ServerClick" />
                </div>

            <div class="w95 margin-auto">
                <asp:GridView ID="gvEvenSettings" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="98.5%" OnRowCancelingEdit="gvEvenSettings_RowCancelingEdit" OnRowDataBound="gvEvenSettings_RowDataBound" OnRowEditing="gvEvenSettings_RowEditing" OnRowUpdating="gvEvenSettings_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="ImageEvent" runat="server" Height="90px" Width="73px" ImageUrl=<%# Bind("ImagePath") %>/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Event">
                            <EditItemTemplate>
                                <asp:Label ID="lblEvent" runat="server" Text='<%# Bind("EventTitle") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIEvent" runat="server" Text='<%# Bind("EventTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Event Date">
                            <EditItemTemplate>
                                <asp:Label ID="lblEventDate" runat="server" Text='<%# Bind("EventDate") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIEventDate" runat="server" Text='<%# Bind("EventDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Venue">
                            <EditItemTemplate>
                                <asp:Label ID="lblVenue" runat="server" Text='<%# Bind("VenueName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIVenue" runat="server" Text='<%# Bind("VenueName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Set Special Image">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkSpecialImage" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSpecialImage" Enabled="false" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Set Feature Show">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkFeatureShow" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkFeatureShow" Enabled="false" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="EventID">
                            <EditItemTemplate>
                              <asp:Label ID="lblEventID" runat="server" Text='<%# Bind("EventID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIEventID" runat="server" Text='<%# Bind("EventID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FEATURESHOW">                            
                            <ItemTemplate>
                                <asp:Label ID="lblFEATURESHOW" runat="server" Text='<%# Bind("FEATURESHOW") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="SPECIALIMAGE">                            
                            <ItemTemplate>
                                <asp:Label ID="lblSPECIALIMAGE" runat="server" Text='<%# Bind("SPECIALIMAGE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
