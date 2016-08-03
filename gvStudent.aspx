<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="gvStudent.aspx.cs" Inherits="Gridview.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            initControl();
        });


        function initControl() {

            $("#MainContent_txtRollNo").keydown(function (e) {
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||(e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||(e.keyCode >= 35 && e.keyCode <= 40)) {
                    return;
                }
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
        }

        function ClearControl() {
            $("#MainContent_txtFname").val("");
            $("#MainContent_txtLname").val("");
            $("#MainContent_txtRollNo").val("");
            $("#MainContent_txtEmail").val("");
            $("#MainContent_txtAdress").val("");
            $("#MainContent_spnError").html("");
            $('#MainContent_ddlBranch').find('option:first').attr('selected', 'selected');
            return false;
        }

        function Validate() {
            var filter = /[\w-]+@([\w-]+\.)+[\w-]+/;
            Field = "";

            Fname = $("#MainContent_txtFname").val();
            Lname = $("#MainContent_txtLname").val();
            RollNo = $("#MainContent_txtRollNo").val();
            Email = $("#MainContent_txtEmail").val();
            Addrrss = $("#MainContent_txtAdress").val();
            Branch = $("#<%=ddlBranch.ClientID %>").val();


            if ($("#MainContent_txtFname") != null && (Fname == "" || Fname == null)) {
                Field = Field + "Please Enter FirstName" + "<br/>";
            }
            if ($("#MainContent_txtLname") != null && (Lname == "" || Lname == null)) {
                Field = Field + "Please Enter LastName" + "<br/>";
            }
            if ($("#MainContent_txtRollNo") != null && (RollNo == "" || RollNo == null)) {
                Field = Field + "Please Enter Roll No" + "<br/>";
            }
            if ($("#MainContent_txtEmail") != null && (Email == "" || Email == null)) {
                Field = Field + "Please Enter Email" + "<br/>";
            }
            if (Email != "") {
                
                Field = Field + "Please Enter Valid Email Address" + "<br/>";
            }
            if ($("#MainContent_txtAdress") != null && (Addrrss == "" || Addrrss == null)) {
                Field = Field + "Please Enter Address" + "<br/>";
            }
            if (Branch == "0") {
                Field = Field + "Please select branch" + "<br/>";
            }
            if (Field.length > 0) {
                $("#MainContent_spnError").html(Field);
                return false;
            } else { return true; }
        }

        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tbl_Error" align="center">
        <tr>
            <td>
                <span id="spnError" runat="server" style="text-align: center; color: Red;"></span>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2" align="center">
                <h1>
                    Student Form
                </h1>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                &nbsp;
            </td>
        </tr>
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
                Rollno:
            </td>
            <td>
                <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Branch:
            </td>
            <td>
                <asp:DropDownList ID="ddlBranch" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                EmailId:
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Address:
            </td>
            <td>
                <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hdnStudent" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" OnClientClick="return Validate();" runat="server" Text="Submit"
                    Width="85px" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" OnClientClick="return ClearControl();" runat="server"
                    Text="Clear" Width="85px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
              
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentId"
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" OnRowCommand="gvDepartment_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="StudentId" InsertVisible="False" SortExpression="StudentId">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="RollNo" InsertVisible="False" SortExpression="RollNo">
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Text='<%# Bind("RollNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch" InsertVisible="False" SortExpression="Branch">
                            <ItemTemplate>
                                <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("Branch") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmailId" InsertVisible="False" SortExpression="EmailId">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address" InsertVisible="False" SortExpression="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
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
