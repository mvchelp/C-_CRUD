<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gvpaging4.aspx.cs" Inherits="Gridview.gvpaging4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Arial">
        <table>
            <tr>
                <td>
                    <strong>EmpId</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>FirstName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>LastName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>GenderName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>CountryName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>StateName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>CityName</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>Language</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtLanguge" runat="server"></asp:TextBox>
                </td>
                <td>
                    <strong>Email</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="106px" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <table>
            <%--<tr>
                <td colspan="4">
                    <strong>Search By:</strong>
                    <asp:DropDownList ID="ddlSearchBy" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlSearchBy_SelectedIndexChanged">
                        <asp:ListItem Text="All"></asp:ListItem>
                        <asp:ListItem Text="EmpId"></asp:ListItem>
                        <asp:ListItem Text="FirstName"></asp:ListItem>
                        <asp:ListItem Text="LastName"></asp:ListItem>
                        <asp:ListItem Text="GenderName"></asp:ListItem>
                        <asp:ListItem Text="CountryName"></asp:ListItem>
                        <asp:ListItem Text="StateName"></asp:ListItem>
                        <asp:ListItem Text="CityName"></asp:ListItem>
                        <asp:ListItem Text="Language"></asp:ListItem>
                        <asp:ListItem Text="Email"></asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        onclick="btnSearch_Click" />
                </td>
            </tr>--%>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvEmployee4" runat="server" AllowPaging="True" PageSize="3" BackColor="#DEBA84"
                        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                        AllowSorting="True" CurrentSortField="EmployeeId" CurrentSortDirection="ASC"
                        OnSorting="gvEmployee4_Sorting">
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
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="color: #A55129">
                    <strong>Page Size:</strong>
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                    </asp:DropDownList>
                    <strong>&nbsp;&nbsp;&nbsp; Page Number: </strong>
                    <asp:DropDownList ID="ddlPageNumbers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageNumbers_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="color: #A55129">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPageCount" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
