<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="EmployeeEntry.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="padding:20px; height: 172px;">
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                    DataSourceID="SqlDataSource1" 
                    OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Height="253px" 
                    Width="631px">
                    <Columns>
                        <asp:TemplateField HeaderText="EmployeeId" InsertVisible="False" SortExpression="EmployeeId">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lastname" SortExpression="Lastname">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Lastname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City" SortExpression="City">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DepartmentName" SortExpression="DepartmentName">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary" SortExpression="Salary">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Salary") %>'></asp:Label>
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
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
