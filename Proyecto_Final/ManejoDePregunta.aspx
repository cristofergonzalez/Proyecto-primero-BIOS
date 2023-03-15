<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="ManejoDePregunta.aspx.cs" Inherits="ManejoDePregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    
    .style15
    {
        width: 81px;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;" class="sombrita">
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="Larger" 
                    Text="Manejo de preguntas" Font-Bold="True"></asp:Label>
                <br />
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style15">
                &nbsp;</td>
            <td align="center">
                Selector de juegos:&nbsp;&nbsp;
                <asp:DropDownList ID="ddlJuego" runat="server" Height="23px" Width="127px">
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnMostrar" runat="server" CssClass="botonsombra" 
                    onclick="btnMostrar_Click" Text="Mostrar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td align="center" class="sombrita">
                <asp:GridView ID="GvEliminar" runat="server" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    ForeColor="Black" GridLines="Vertical" Width="369px" 
                    AutoGenerateSelectButton="True" onrowdatabound="GvJuegos_RowDataBound" 
                    onselectedindexchanged="GvJuegos_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FF5555" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    CssClass="botonsombra" onclick="btnEliminar_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" class="style15">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Smaller" 
                    Text="Codigo nuevo:"></asp:Label>
                <asp:TextBox ID="txtCodigoNuevo" runat="server" CssClass="sombritaTxt" 
                    Width="103px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtCodigoNuevo" ErrorMessage="RegularExpressionValidator" 
                    Font-Size="Smaller" ForeColor="Red" 
                    ValidationExpression="^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{5}$">* Codigo alfanumerico de 5 caracteres</asp:RegularExpressionValidator>
            </td>
            <td align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="Seleccione una pregunta para Eliminar/Agregar al juego"></asp:Label>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style15">
                &nbsp;</td>
            <td class="sombrita" align="center">
                <asp:GridView ID="GvAgregar" runat="server" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    ForeColor="Black" GridLines="Vertical" Width="369px" 
                    AutoGenerateSelectButton="True" 
                    onselectedindexchanged="GvAgregar_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#00B359" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                    CssClass="botonsombra" onclick="btnAgregar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td align="center">
                <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
                <br />
                *Nota: Para crear más preguntas, ve a el apartado &quot;Agregar Pregunta&quot;*</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

