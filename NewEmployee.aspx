<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NewEmployee.aspx.cs" Inherits="Gridview.NewEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.11.3.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            initControl();
        });


        function initControl() {

            $("#MainContent_txtFname").attr('maxlength', '20');
            $("#MainContent_txtLname").attr('maxlength', '20');
            $("#MainContent_Salary").attr('maxlength', '5');

            $('#MainContent_txtFname,#MainContent_txtLname').keydown(function (e) {
                if (e.shiftKey || e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                        e.preventDefault();
                    }
                }
            });

            $("#MainContent_txtSalary").keydown(function (e) {
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 || (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) || (e.keyCode >= 35 && e.keyCode <= 40)) {
                    return;
                }
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });


        }


        function Validate() {
            var Field = "";

            Fname = $("#MainContent_txtFname");
            Lname = $("#MainContent_txtLname");
            Gender = $("#<%=rbGender.ClientID %>");
            Dept = $("#<%=ddlDepartment.ClientID %>");
            Salary = $("#MainContent_txtSalary");

            if (Fname != null && (Fname.val() == "" || Fname.val() == null)) {
                Field = Field + "Please Enter First Name" + "<br/>";
            }
            if (Lname != null && (Lname.val() == "" || Lname.val() == null)) {
                Field = Field + "Please Enter Last Name" + "<br/>";
            }
            if (Gender != null && $("[id$=rbGender] input:checked").length == 0) {
                Field = Field + "Please select Gender" + "<br/>";
            }
            if (Dept != null && (Dept.val() == "0" || Dept.val() == null)) {
                Field = Field + "Please Select Department" + "<br/>";
            }
            if (Salary != null && (Salary.val() == "" || Salary.val() == null)) {
                Field = Field + "Please Enter Salary" + "<br/>";
            }

            if (Field.length > 0) {
                $("#MainContent_spnError").html(Field);
                return false;
            } else { return true; }

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
    <table align="center">
        <tr>
            <td>
                FirstName:
            </td>
            <td>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                LastName:
            </td>
            <td>
                <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender:
            </td>
            <td>
                <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Department:
            </td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Salary:
            </td>
            <td>
                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" OnClientClick="return Validate();" Text="Save"
                    Width="70px" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <asp:GridView ID="gvTable" runat="server" AutoGenerateColumns="false" OnRowCommand="gvTable_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="lblFname" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lastname" SortExpression="Lastname">
                            <ItemTemplate>
                                <asp:Label ID="lblLname" runat="server" Text='<%# Bind("Lastname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DepartmentName" SortExpression="DepartmentName">
                            <ItemTemplate>
                                <asp:Label ID="lblDept" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary" SortExpression="Salary">
                            <ItemTemplate>
                                <asp:Label ID="lblSalary" runat="server" Text='<%# Bind("Salary") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="D"
                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnFinalSave" runat="server" Text="Final Save" Width="101px" OnClick="btnFinalSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
