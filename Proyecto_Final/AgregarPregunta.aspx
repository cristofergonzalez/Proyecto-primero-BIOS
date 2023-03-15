<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="AgregarPregunta.aspx.cs" Inherits="AgregarPregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            width: 28px;
        }
        .style16
        {
            width: 28px;
            height: 31px;
        }
        .style17
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="style16">
            </td>
        <td align="center" class="sombrita" rowspan="12">
            &nbsp;
            <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="Larger" 
                Text="Agregar pregunta" Font-Bold="True"></asp:Label>
        &nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Codigo:
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="sombritaTxt"></asp:TextBox>
&nbsp;&nbsp; ej:1234r&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtCodigo" ErrorMessage="RegularExpressionValidator" 
                Font-Size="Smaller" ForeColor="Red" 
                ValidationExpression="^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{5}$">* Codigo alfanumerico 5 caracteres</asp:RegularExpressionValidator>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Valor:
            <asp:TextBox ID="txtValor" runat="server" CssClass="sombritaTxt"></asp:TextBox>
&nbsp;&nbsp; ej:1-10&nbsp;&nbsp;
            <br />
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="txtValor" ErrorMessage="RangeValidator" Font-Size="Smaller" 
                ForeColor="Red" MaximumValue="10" MinimumValue="1" Type="Integer">* El valor debe estar entre 1-10</asp:RangeValidator>
            <br />
            Categoria:
              <asp:TextBox ID="txtCategoria" runat="server" CssClass="sombritaTxt"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pregunta:
            <asp:TextBox ID="txtPregunta" runat="server" Width="340px" 
                CssClass="sombritaTxt"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                Text="Seleccione la respuesta correcta!"></asp:Label>
            <br />
            <br />
            Respuestas:<br />
            <asp:RadioButton ID="rbtn1" runat="server" GroupName="Respuestas" Text=".1" />
            <asp:TextBox ID="txtR1" runat="server" Width="340px" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="rbtn2" runat="server" GroupName="Respuestas" Text=".2" />
            <asp:TextBox ID="txtR2" runat="server" Width="340px" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="rbtn3" runat="server" GroupName="Respuestas" Text=".3" />
            <asp:TextBox ID="txtR3" runat="server" Width="340px" CssClass="sombritaTxt"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAgregarP" runat="server" Text="Agregar" 
                CssClass="botonsombra" onclick="btnAgregarP_Click" />
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" Font-Italic="False" ForeColor="#FF0066"></asp:Label>
        </td>
        <td class="style17">
            </td>
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
        <td align="right" class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style15">
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

