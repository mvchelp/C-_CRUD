<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartmentEntery.aspx.cs" Inherits="Gridview.DepartmentEntery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Validate() {
            Field = "";

            if ($("#MainContent_txtDepartment") != null && ($("#MainContent_txtDepartment").val() == "" || $("#MainContent_txtDepartment").val() == null)) {
                Field = "Please Enter Department Name";
            }
            if (Field.length > 0) {
                $("#MainContent_spnError").html(Field);
                return false;
            } else { return true; }
        }

        function clearControl() {
            $("#MainContent_txtDepartment").val("");
            $("#MainContent_spnError").html("");
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
        <tr>
            <td>
                <span id="spnError" runat="server"></span>
            </td>
        </tr>
    </table>
    <table id="tbl" align="center">
        <tr>
            <td>
                Department:*
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDepartment"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField runat="server" ID="hdnDepartID"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClientClick="return Validate();"
                    OnClick="btnSubmit_Click" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnCancel" OnClientClick="return clearControl();"
                    Text="Cancel" />
            </td>
        </tr>
    </table>
    <table align="center">
        <tr style="height: 100px;">
            <td>
                <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" DataKeyNames="DepID"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnRowCommand="gvDepartment_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="DepID" InsertVisible="False" SortExpression="DepID">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartID" runat="server" Text='<%# Bind("DepID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DepartmentName" SortExpression="DepartmentName">
                            <ItemTemplate>
                                <asp:Label ID="lblDepatName" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="E"
                                    CommandArgument='<%# Eval("DepID") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="D"
                                    CommandArgument='<%# Eval("DepID") %>' Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
