<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="AgregarUsuario.aspx.cs" Inherits="AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style15
    {}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 92%; height: 263px;">
    <tr>
        <td class="style15">
        </td>
        <td align="center" class="sombrita" rowspan="9">
            <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="Larger" 
                Text="Agregar administrador" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Usuario:
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
            Nombre completo:
            <asp:TextBox ID="txtNomCom" runat="server" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contraseña:
            <asp:TextBox ID="txtcontraseña" runat="server" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAgregar" runat="server" CssClass="botonsombra" 
                Text="Agregar" onclick="btnAgregar_Click1" />
            <br />
        </td>
        <td class="style15">
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

