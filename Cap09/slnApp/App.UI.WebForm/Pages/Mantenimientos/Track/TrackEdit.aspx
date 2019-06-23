<%@ Page Title="Administración" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackEdit.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="height: 26px; width: 289px">
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:TextBox ID="TxtNombre" runat="server" Width="311px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label2" runat="server" Text="Album:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DdlAlbum" runat="server" Height="20px" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label3" runat="server" Text="Medio:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DdlMedio" runat="server" Height="20px" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 289px; height: 26px">
            <asp:Label ID="Label4" runat="server" Text="Genero:"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:DropDownList ID="DdlGenero" runat="server" Height="20px" Width="317px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label5" runat="server" Text="Compositor:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCompositor" runat="server" Width="311px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label6" runat="server" Text="Duración:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtDuracion" runat="server" Width="130px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label7" runat="server" Text="Peso:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtPeso" runat="server" Width="129px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">
            <asp:Label ID="Label8" runat="server" Text="Precio:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtPrecio" runat="server" Width="129px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 289px">&nbsp;</td>
        <td>
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
        </td>
    </tr>
</table>
</asp:Content>
