<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="AgregarJuego.aspx.cs" Inherits="AgregarJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style13
    {
        width: 3px;
    }
    .style15
    {
        height: 3px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td align="center" class="sombrita" rowspan="8">
            <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="Larger" 
                Text="Agregar juego" Font-Bold="True"></asp:Label>
            <br />
            <br />
            Dificultad:
            <asp:DropDownList ID="ddlDificultad" runat="server" Height="20px" 
                style="margin-left: 0px" Width="113px">
                <asp:ListItem>Dificil</asp:ListItem>
                <asp:ListItem>Medio</asp:ListItem>
                <asp:ListItem>Facil</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Admin:
            <asp:Label ID="lblNombreAdmin" runat="server" ForeColor="#0099CC" 
                Text="Nombre de admin"></asp:Label>
            <br />
            <br />
            Codigo:(Autogenerado)<br />
            <br />
            Fecha:(Autogenerado)<br />
            <br />
            <asp:Button ID="btnCrear" runat="server" Text="Crear juego" 
                CssClass="botonsombra" onclick="btnCrear_Click" />
            <br />
            <br />
            <asp:Label ID="lblInfo" runat="server" ForeColor="#009933"></asp:Label>
            <br />
            <br />
            Nota: *las preguntas se pueden asignar en el apartado &quot;Manejo de preguntas&quot;*</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
&nbsp;<br />
            <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
            <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
            <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
            <br />
            <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

