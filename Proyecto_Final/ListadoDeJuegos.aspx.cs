using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListadoDeJuegos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlJuegos.DataSource = (Logica.LogicaJuego.ListarJuego());
            ddlJuegos.DataBind();
        }
    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        if (ddlJuegos.SelectedValue != "")
        {
            int unJuego;
            unJuego = Convert.ToInt32(ddlJuegos.SelectedValue);

            //Subimos a la Session las listas para mostrar despues
            Session["ListarJugadaJuego"] = Logica.LogicaJugada.ListarJugadasPorJuego(unJuego);
            Session["ListaPreguntasJuego"] = Logica.LogicaPregunta.ListarPregunta(unJuego);

            GvJugadasFNP.DataSource = (List<EntidadesCompartidas.Jugada>)Session["ListarJugadaJuego"];
            GvJugadasFNP.DataBind();


            GvTextoPuntaje.DataSource = (List<EntidadesCompartidas.Pregunta>)Session["ListaPreguntasJuego"];
            GvTextoPuntaje.DataBind();
        }
        else
        {
            lblError.Text = "Debe elegir un juego";
        }

    }

    protected void ddlJuegos_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}