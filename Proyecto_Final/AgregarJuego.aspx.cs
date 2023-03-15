using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class AgregarJuego : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Admin A = (Admin)Session["Admin"];
        lblNombreAdmin.Text = A.Usuario.ToUpper();
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        string dif="";
        Admin unA;

        if (ddlDificultad.SelectedIndex == 0)
            dif = "dificil";
        else if (ddlDificultad.SelectedIndex == 1)
            dif = "medio";
        else if (ddlDificultad.SelectedIndex == 2)
            dif = "fácil";

        try
        {
            //Crea un administrador con los datos necesarios
            unA = (Admin)Session["Admin"];

            //Intenta crear un juego
            Juego J = new Juego(dif, unA);

            //Lo intentamos agregar
            Logica.LogicaJuego.Agregar(J);

            //Si llega acá es porque no hubo problema
            lblInfo.Text = "Se creó correctamente";
            
        }
        catch(Exception x)
        {
            lblInfo.Text = x.Message;
        }
    }
}