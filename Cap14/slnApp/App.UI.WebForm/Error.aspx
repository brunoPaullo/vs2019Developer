<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="App.UI.WebForm.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <b>
        Se ha generado un <span class="badge bg-red">error</span> inesperado en el sistema.<br />
        Consultar con el administrador con el sistema.
    </b>
</asp:Content>
