using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                Session["ListaJugada"] = Logica.LogicaJugada.ListarTodo();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

        Session["Admin"] = null;
        gvJugadasPrincipal.DataSource = (List<EntidadesCompartidas.Jugada>)Session["ListaJugada"];
        gvJugadasPrincipal.DataBind();

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnInicioSesion_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico usuario
            Admin unAdmin = Logica.LogicaAdmin.Logueo(txtUsuario.Text.Trim().ToLower(),txtContraseña.Text.Trim().ToLower());
            if (unAdmin != null)
            {
                //si llego aca es porque es válido
                Session["Admin"] = unAdmin;
                Response.Redirect("Bienvenida.aspx");
            }
            else
                lblError.Text = "El Usuario o contraseña es incorrecto";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnJugar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Jugar.aspx");
    }

    protected void gvJugadasPrincipal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    //     try
    //        {
    //            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
    //            {
    //                    e.Row.Cells[].Visible = true;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            lblError.Text = ex.Message;
    //        }
    }

    protected void gvJugadasPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}