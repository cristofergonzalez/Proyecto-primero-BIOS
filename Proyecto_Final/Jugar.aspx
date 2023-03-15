<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jugar.aspx.cs" Inherits="Jugar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .gradiente
        {
            background: linear-gradient(90deg, white, #212121);
        }
        .sombrita {
              -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
              padding: 20px;
              background-color:White;
              -webkit-border-radius:5%;
            margin-left: 9px;
        }
        .botonsombra
        {
           -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
           padding: 5px;
           -webkit-border-radius:10%; 
        }
        .sombritaTxt
        {
            -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
            }
        .style1
        {
            width: 180px;
        }
        .style2
        {
            width: 180px;
            height: 142px;
        }
        .style3
        {
            height: 142px;
        }
        .style4
        {
            width: 180px;
            height: 23px;
        }
        .style8
        {
            -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
            padding: 20px;
            background-color: White;
            -webkit-border-radius: 5%;
            margin-left: 9px;
            width: 586px;
        }
        .style9
        {
            width: 275px;
        }
        .style10
        {
            width: 275px;
            height: 142px;
        }
        .style11
        {
            -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
            padding: 20px;
            background-color: White;
            -webkit-border-radius: 5%;
            margin-left: 9px;
            width: 116px;
        }
        </style>
</head>
<body style="height: 794px; width: 1475px" class="gradiente">
    <form id="form1" runat="server">
    <div align="center" style="height: 773px">
    
        <table style="width: 77%; height: 475px;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Image ID="Image1" runat="server" Height="169px" 
                        ImageUrl="~/Plantiilas de diseño/Finallogo.png" Width="127px" />
                </td>
                <td class="style10" align="center">
                    &nbsp;</td>
                <td class="style3" align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="X-Large" 
                        ForeColor="Black" 
                        Text="¡Selecciona un juego, dale a Comenzar y gánate un lugar en la tabla!" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style3">
                    <div align="center" class="sombrita" style="width: 71px; height: 18px">
                        <asp:HyperLink ID="hlkInicio" runat="server" ForeColor="Black" 
                            NavigateUrl="~/Principal.aspx">Ir a inicio</asp:HyperLink>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" class="style3">
                    &nbsp;</td>
                <td align="center" class="sombrita" colspan="2">
                    <div class="sombrita" style="width: 590px" align="center">
                    <asp:GridView ID="gvElegirJuego" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" Width="533px" 
                            onselectedindexchanged="gvElegirJuego_SelectedIndexChanged" 
                            AutoGenerateSelectButton="True" onrowdatabound="gvElegirJuego_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#C488FF" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    </div>
                </td>
                <td>
                    <div class="sombrita" align="center">
                        <asp:Button ID="btnComenzar" runat="server" CssClass="botonsombra" 
                            onclick="btnComenzar_Click" Text="Comenzar" Width="80px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" class="style3" rowspan="9">
                    &nbsp;</td>
                <td align="center" class="style8" rowspan="9">
                    ¿<asp:Label ID="lblPregunta" runat="server"></asp:Label>
                    ?<br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Text="Posibles respuestas:"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:RadioButton ID="rbnR1" runat="server" 
                        oncheckedchanged="rbnR1_CheckedChanged" Text=".1" GroupName="RespuestaJ" />
                    <br />
                    <br />
                    <asp:RadioButton ID="rbnR2" runat="server" Text=".2" GroupName="RespuestaJ" />
                    <br />
                    <br />
                    <asp:RadioButton ID="rbnR3" runat="server" Text=".3" GroupName="RespuestaJ" />
                    <br />
                    <br />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" 
                        CssClass="botonsombra" onclick="btnSiguiente_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
                    <br />
                </td>
                <td align="center" class="style11" rowspan="9" id="ventana">
                    <asp:Label ID="lblAgregarU" runat="server" Font-Bold="True" 
                        Text="Ingresa un nombre para guardar: "></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="txtNombreU" runat="server" Width="94px" CssClass="sombritaTxt"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNombreU" ErrorMessage="RequiredFieldValidator" 
                        Font-Size="Smaller" ForeColor="Red">* Ingrese un nombre</asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="botonsombra" 
                        onclick="btnGuardar_Click" Text="Guardar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td rowspan="6" class="style3">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
