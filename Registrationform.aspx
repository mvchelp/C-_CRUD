<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrationform.aspx.cs" Inherits="Gridview.Registrationform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
    td { padding: 5px; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
    <tr>
        <td>
            <span runat="server" id="spnError"></span>
        </td>
    </tr>
    </table>
    <table align="center">
        <tr>
            <td colspan= "2">
                <h1 align="center">
                    Registration Form
                </h1>
            </td>
        </tr>
        <tr>
            <td colspan= "2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Firstname:
            </td>
            <td>
                <asp:TextBox ID="txtFname" runat="server" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                lastName:
            </td>
            <td>
                <asp:TextBox ID="txtLname" runat="server" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender:
            </td>
            <td>
                <asp:RadioButtonList ID="rbGender" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Text="Male" Value="0"></asp:ListItem>
                 <asp:ListItem Text="FEMale" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Country:
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                State:
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Language:
            </td>
            <td>
                <asp:CheckBoxList ID="chkLanguage" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100px" />
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <asp:GridView ID="gvStudentReg" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentId"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4">
                    <Columns>
                        <asp:TemplateField HeaderText="StudentId" InsertVisible="False" SortExpression="StudentId">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName" InsertVisible="False" SortExpression="FisrtName">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LastName" InsertVisible="False" SortExpression="LastName">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender" InsertVisible="False" SortExpression="Gender">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Language" InsertVisible="False" SortExpression="Language">
                            <ItemTemplate>
                                <asp:Label ID="lblLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmailId" InsertVisible="False" SortExpression="EmailId">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="E"
                                    CommandArgument='<%# Eval("StudentId") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="D"
                                    CommandArgument='<%# Eval("StudentId") %>' Text="Delete"></asp:LinkButton>
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
