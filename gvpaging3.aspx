<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gvpaging3.aspx.cs" Inherits="Gridview.gvpaging3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvEmployee3" BorderColor="#DEBA84" BorderStyle="None" CellSpacing="2"
            CellPadding="3" BackColor="#DEBA84" BorderWidth="1px" AutoGenerateColumns="False"
            runat="server" DataKeyNames="EmpId" Width="1218px">
            <Columns>
                <asp:BoundField DataField="EmpId" HeaderText="EmpId">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="LastName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="GenderName" HeaderText="GenderName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CountryName" HeaderText="CountryName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="StateName" HeaderText="StateName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CityName" HeaderText="CityName">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Language" HeaderText="Language">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email">
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="btnFirst" CommandName="Page" runat="server" Text="First" CommandArgument="First"
                        OnCommand="PageChangeEventHandler" />
                </td>
                <td>
                    <asp:LinkButton ID="btnPrevious" CommandName="Page" runat="server" Text="Previous" CommandArgument="Prev"
                        OnCommand="PageChangeEventHandler" />
                </td>
                <td>
                    <asp:LinkButton ID="btnNext" CommandName="Page" runat="server" Text="Next" CommandArgument="Next"
                        OnCommand="PageChangeEventHandler" />
                </td>
                <td>
                    <asp:LinkButton ID="btnLast" CommandName="Page" runat="server" Text="Last" CommandArgument="Last"
                        OnCommand="PageChangeEventHandler" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblPageCount" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
