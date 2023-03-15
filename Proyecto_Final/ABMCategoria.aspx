<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="ABMCategoria.aspx.cs" Inherits="ABMCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .sombrita {
      -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
      padding: 20px;
                }
    .style14
    {
        width: 201px;
    }
    .style17
    {
        width: 201px;
        height: 26px;
    }
        .style19
        {
            width: 201px;
            height: 34px;
        }
    .style20
    {
        height: 34px;
        width: 185px;
    }
    .style21
    {
        height: 26px;
        width: 185px;
    }
    .style22
    {
        width: 185px;
    }
    .style23
    {
        width: 195px;
    }
    .style24
    {
        width: 195px;
        height: 34px;
    }
    .style25
    {
        width: 195px;
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:82%; height: 257px;" class="sombrita">
    <tr>
        <td align="right" class="style24">
        </td>
        <td align="center" class="style19">
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="ABM Categoria" 
                Font-Bold="True"></asp:Label>
            <br />
        </td>
        <td class="style20">
        </td>
    </tr>
    <tr>
        <td align="right" class="style24">
            </td>
        <td align="center" class="style19">
            </td>
        <td class="style20">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style25">
            <asp:Label ID="lblCodigo" runat="server" Text="Codigo: "></asp:Label>
            <br />
        </td>
        <td align="left" class="style17">
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="sombritaTxt"></asp:TextBox>
            Ej: math<br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtCodigo" ErrorMessage="RegularExpressionValidator" 
                Font-Size="Smaller" ForeColor="#CC0000" ValidationExpression="^.{4}$"> * Debe tener 4 caracteress</asp:RegularExpressionValidator>
        </td>
        <td class="style21" align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style23">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
        </td>
        <td align="left" class="style14">
            <asp:TextBox ID="txtNombre" runat="server" ontextchanged="TextBox3_TextChanged" 
                CssClass="sombritaTxt"></asp:TextBox>
        </td>
        <td align="left" class="style22">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                CssClass="botonsombra" onclick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style23">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                onclick="btnAgregar_Click" CssClass="botonsombra" />
        </td>
        <td align="center" class="style14">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                CssClass="botonsombra" onclick="btnModificar_Click" />
        </td>
        <td align="left" class="style22">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                CssClass="botonsombra" onclick="btnEliminar_Click" />
        </td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14" align="center">
            <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
        </td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style23">
            &nbsp;</td>
        <td class="style14">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

