<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jquerydatepic.aspx.cs" Inherits="Gridview.jquerydatepic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.11.3.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        Datepicker()
    });

    function Datepicker()
    {
        $("#MainContent_datepic").datepicker({
            appendText: "dd/mm/yyyy",
            showOn:"focus",
            dateFormate: 'dd/mm/yyyy'
        });
    }
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
Birthdate :&nbsp; <asp:TextBox ID="datepic" runat="server"></asp:TextBox>
</asp:Content>
