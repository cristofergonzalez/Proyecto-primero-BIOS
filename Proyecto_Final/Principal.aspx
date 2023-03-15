<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .gradiente
        {
            background: linear-gradient(90deg, white, #212121);
        }

        .sombrita
        {
          -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3); 
          padding: 20px;
        }
        .sombritaTxt
        {
            -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
            }
        .botonsombra
        {
           -webkit-box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.3);
           padding: 5px;
        }
        .style3
        {
            height: 226px;
        }
        .style5
        {
            width: 1834px;
        }
        .style
        {   }
        .style12
        {
            width: 1834px;
            height: 226px;
        }
        .style14
        {
            width: 1834px;
            height: 14px;
        }
        #form1
        {
            height: 796px;
            width: 1533px;
        }
    </style>
</head>
<body style="height: 802px; width: 1527px" class="gradiente">
    <form id="form1" runat="server">
    <div align="center" style="height: 789px; width: 1508px;">
    
        <table style="width: 53%; height: 563px; margin-right: 0px; margin-top: 0px;" 
            bgcolor="White" class="sombrita">
            <tr>
                <td class="style5" rowspan="3" align="center" bgcolor="White">
                    <asp:Label ID="Label1" runat="server" Font-Italic="False" Font-Size="X-Large" 
                        Font-Underline="True" Text="Preguntas y respuestas" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="imglogo" runat="server" Height="313px" 
                        ImageUrl="~/Plantiilas de diseño/Finallogo.png" Width="265px" />
                </td>
                <td class="sombrita" align="center" bgcolor="White">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                        Text="Prueba una partida"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnJugar" runat="server" Font-Italic="False" Height="59px" 
                        Text="Jugar" Width="172px" 
                        CssClass="botonsombra" onclick="btnJugar_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="White">
                </td>
            </tr>
            <tr>
                <td class="sombrita" align="center" bgcolor="White">
                    <asp:Label ID="lblAcceder" runat="server" Font-Bold="True" Font-Italic="False" 
                        Font-Size="26px" Text="Acceder"></asp:Label>
                    <br />
                    Usa tu cuenta admin 
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    Usuario:<asp:TextBox ID="txtUsuario" runat="server" CssClass="sombritaTxt" 
                        Height="18px" Width="128px"></asp:TextBox>
                    <br />
                    <br />
                    Contraseña:<asp:TextBox 
                        ID="txtContraseña" runat="server" CssClass="style" Height="18px" 
                        ontextchanged="TextBox2_TextChanged" Width="128px" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnInicioSesion" runat="server" Font-Italic="False" 
                        Height="28px" Text="Iniciar sesión" Width="100px" CssClass="botonsombra" 
                        onclick="btnInicioSesion_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="#FF0066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style14" align="center" bgcolor="White">
                </td>
                <td align="right" class="style3" bgcolor="White" rowspan="2">
                    </td>
            </tr>
            <tr>
                <td class="style12" align="center" bgcolor="White">
                    <div class="sombrita">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                            Text="Partidas jugadas anteriormente:"></asp:Label>
                        <br />
                        <br />
                    <asp:GridView ID="gvJugadasPrincipal" runat="server" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" Width="560px" 
                            onrowdatabound="gvJugadasPrincipal_RowDataBound">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    </div>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
