<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackList.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script>
    //Track list head
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <form runat="server">
        <asp:GridView ID="GrvListado" runat="server" AllowPaging="True" CssClass="table"
            GridLines="None">

        </asp:GridView>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click"/>
    </form>
</asp:Content>
