<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="gvpaging1.aspx.cs" Inherits="Gridview.gvpaging1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:GridView ID="gvEmployee1" AutoGenerateColumns="true" runat="server" AllowPaging="true"
                     PageSize="3" OnPageIndexChanging="gvEmployee1_PageIndexChanging">
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" LastPageText="Last"
                        NextPageText="Next" PreviousPageText="Previous" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
