<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackList.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script>
    //Track list head
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <%--<div class="box box-default">
            <div class=" box-body">
                <div class="form-inline">
                    <div class="form-group">
                        <label for="exampleInputName2">Búsqueda</label>
                        <input type="text" class="form-control" id="exampleInputName2" placeholder="Buscar">
                    </div>
                    <button type="submit" class="btn btn-default">Buscar</button>
                </div>
            </div>
        </div>
        <br />--%>
    <div class="box box-primary">
        <div class="box-header">
            <div class="form-inline pull-right">
                <div class="form-group">
                    <label>Nombre de la canción</label>
                    <asp:TextBox ID="TxtFiltroPorNombre" CssClass="form-control" placeholder="Buscar" runat="server">
                    </asp:TextBox>
                </div>
                <asp:Button ID="BtnFiltrar" runat="server" CssClass="btn btn-default" Text="Buscar" OnClick="BtnBuscar_Click" />
                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-info" Text="nuevo" PostBackUrl="~/Pages/Mantenimientos/Track/TrackEdit.aspx" />
            </div>
        </div>
        <div class="box-body">
            <asp:GridView ID="GrvListado" runat="server" CssClass="table"
                GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:HyperLinkField HeaderText="Nombre Track"
                        DataTextField="TrackName"
                        DataNavigateUrlFormatString="~/Pages/Mantenimientos/Track/TrackEdit.aspx?cod={0}"
                        DataNavigateUrlFields="TrackId" />
                    <asp:BoundField HeaderText="Album"
                        DataField="AlbumTitle" />
                    <asp:BoundField HeaderText="Media"
                        DataField="MediaTypeName" />
                    <asp:BoundField HeaderText="Género"
                        DataField="GenreName" />
                    <asp:BoundField HeaderText="Compositor"
                        DataField="Composer" />
                </Columns>
            </asp:GridView>
            <%--<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />--%>
        </div>
    </div>
</asp:Content>
