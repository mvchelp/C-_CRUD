﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gvpaging2.aspx.cs" Inherits="Gridview.gvpaging2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvCustomPaging2" runat="server" AllowPaging="True" BackColor="#DEBA84"
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
            PageSize="3">
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
        <asp:DataList CellPadding="5" RepeatDirection="Horizontal" runat="server" 
            ID="dlPagerx" onitemcommand="dlPager_ItemCommand1">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkPageNo" Text='<%#Eval("Text") %>'
                    CommandArgument='<%#Eval("Value") %>' Enabled='<%#Eval("Enabled") %>' CommandName="PageNo"></asp:LinkButton>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
