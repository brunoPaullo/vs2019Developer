<%@ Page Title="Administración" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackEdit.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
    <script>
    //Track list head
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <form runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"/>
        <table style="width: 100%;">
            <tr>
                <td style="height: 26px; width: 289px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="311px"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="El campo es requerido" ControlToValidate="TxtNombre">
                    </asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo es requerido"
                        ControlToValidate="TxtCompositor">
                    </asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td style="width: 289px">
                    <asp:Label ID="Label6" runat="server" Text="Duración:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDuracion" runat="server" Width="130px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo es requerido"
                        ControlToValidate="TxtDuracion" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Rango entre 1 y 10"
                        ControlToValidate="TxtDuracion" MinimumValue="1" MaximumValue="10" Type="Integer" Display="Dynamic">
                    </asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 289px">
                    <asp:Label ID="Label7" runat="server" Text="Peso:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPeso" runat="server" Width="129px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="El campo es requerido" Display="Dynamic"
                        ControlToValidate="TxtPeso">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Rango entre 1Mb y 10MB"
                        ControlToValidate="TxtPeso" MinimumValue="1" MaximumValue="10" Type="Integer" Display="Dynamic">
                    </asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 289px">
                    <asp:Label ID="Label8" runat="server" Text="Precio:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPrecio" runat="server" Width="129px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo es requerido"
                        ControlToValidate="TxtPrecio">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 289px">&nbsp;</td>
                <td>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click"
                        CausesValidation="true" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
