<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Gridview.GvEmployee.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function Validate() {
            Field = "";

            Fname = $("#MainContent_txt_Fname").val();
            Lname = $("#MainContent_txt_Lname").val();
            DeptName = $("#MainContent_txt_DeptName").val();
            City = $("#MainContent_txt_City").val();
            Salary = $("#MainContent_txt_Salary").val();
            Gender = $("#ManiContent_rb_Gender");


            if ($("#MainContent_txt_Fname") != null && (Fname == "" || Fname == null)) {
                Field = Field + "Please Enter FirstName" + "<br/>";
            }
            if ($("#MainContent_txt_Lname") != null && (Lname == "" || Lname == null)) {
                Field = Field + "Please Enter LastName" + "<br/>";
            }
            if ($("#MainContent_txt_DeptName") != null && (DeptName == "" || DeptName == null)) {
                Field = Field + "Please Enter Department Name" + "<br/>";
            }
            if ($("#MainContent_txt_City") != null && (City == "" || City == null)) {
                Field = Field + "Please Enter City Name" + "<br/>";
            }
            if (isNaN(Salary)) {
                Field = Field + "Please Enter only Number Value in Salary"
            }
            if ($("#MainContent_txt_Salary") != null && (Salary == "" || Salary == null)) {
                Field = Field + "Please Enter Salary" + "<br/>";
            }
            if ($("#ManiContent_rb_Gender") != null && (Fname == "" || Fname == null)) {
                Field = Field + "Please select Gender" + "<br/>";
            }
            if (Field.length > 0) {
                $("#MainContent_spnError").html(Field);
                return false;
            } else { return true; }
        }

        function ClearControl() {
            $("#MainContent_txt_Fname,#MainContent_txt_Lname,#MainContent_txt_DeptName,#MainContent_txt_City,#MainContent_txt_Salary").val("");
            var elementRef = $('#<%= rb_Gender.ClientID %>');
            var spnError = $('#<%= spnError.ClientID %>');
            var inputElementArray = $(elementRef).find('input');
            spnError.html("");
            for (var i = 0; i < inputElementArray.length; i++) {
                var inputElement = inputElementArray[i];
                inputElement.checked = false;
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 235px;
        }
        .style2
        {
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table id="tbl_Error" align="center">
        <tr>
            <td>
                <span id="spnError" runat="server" style="text-align: center; color: Red;"></span>
            </td>
        </tr>
    </table>
    <table id="tbl_Content" align="center">
        <tr>
            <td colspan="2">
                <h1 style="text-align: center;">
                    Employee Detail Form
                </h1>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Firstname:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_Fname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Lastname:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_Lname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender:
            </td>
            <td class="style1">
                <asp:RadioButtonList ID="rb_Gender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_City" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                DepartmentName:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_DeptName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Salary:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_Salary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField runat="server" ID="hdnEmployee"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" Width="117px" 
                    OnClientClick="return Validate();" onclick="btn_Submit_Click" />
                <asp:Button ID="btn_Cancel" runat="server" OnClientClick="return ClearControl();"
                    Text="Cancel" Width="117px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style2">
                <asp:GridView ID="gvEmployeeData" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4"> <%--onrowcommand="gvEmployeeData_RowCommand"--%>
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
                                    CommandArgument='<%# Eval("EmployeeId") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="D"
                                    CommandArgument='<%# Eval("EmployeeId") %>' Text="Delete"></asp:LinkButton>
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
