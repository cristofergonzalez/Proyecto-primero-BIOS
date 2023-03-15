using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class ManejoDePregunta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Desactivo();
        if (!IsPostBack)
        {
            ddlJuego.DataSource = (Logica.LogicaJuego.Listar_TodosJuegos());
            ddlJuego.DataBind();

        }
    }

    //Funciones Agregadas
    public void Desactivo()
    {
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;
        txtCodigoNuevo.Enabled = false;
    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        if (ddlJuego.SelectedValue != "")
        {
            int unJuego;//Se le asigna a la variable el valor del DropDownList
            unJuego = Convert.ToInt32(ddlJuego.SelectedValue);

            //Subimos la lista a la Session
            Session["ListaPreguntasJuego"] = Logica.LogicaPregunta.ListarPregunta(unJuego);
            Session["ListaNoAsociada"] = Logica.LogicaPregunta.ListarPreguntasNoAsociadas(unJuego);

            //Le cargamos los datos de la Session a la grilla
            GvEliminar.DataSource = (List<EntidadesCompartidas.Pregunta>)Session["ListaPreguntasJuego"];
            GvEliminar.DataBind();

            GvAgregar.DataSource = (List<EntidadesCompartidas.Pregunta>)Session["ListaNoAsociada"];
            GvAgregar.DataBind();
        }
        else
        {
            lblError.Text = "Debe seleccionar un juego!";
        }

    }

    protected void GvJuegos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[1].Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        string codigo = Convert.ToString(GvEliminar.SelectedRow.Cells[1].Text);

        try
        {
            Pregunta unaP = Persistencia.Persistencia_Pregunta.Buscar(codigo);

            Juego unJuego = Persistencia.Persistencia_juego.Buscar(Convert.ToInt32(ddlJuego.SelectedValue));

            Logica.LogicaPregunta.Eliminar(unJuego, unaP);


            lblError.Text = "Se eliminó correctamente";



            int unJue;//Se le asigna a la variable el valor del DropDownList
            unJue = Convert.ToInt32(ddlJuego.SelectedValue);

            //Subimos la lista otra vez a la Session, pero esta vez actualizada
            Session["ListaPreguntasJuego"] = Logica.LogicaPregunta.ListarPregunta(unJue);

            //Volvemos a rellenar la lista actualizada
            GvEliminar.DataSource = (List<EntidadesCompartidas.Pregunta>)Session["ListaPreguntasJuego"];
            GvEliminar.DataBind();
        }
        catch (Exception x)
        {
            lblError.Text = x.Message;
        }
    }

    protected void GvJuegos_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEliminar.Enabled = true;
    }

    protected void GvAgregar_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAgregar.Enabled = true;
        txtCodigoNuevo.Enabled = true;
        lblError.Text = "Escribe un codigo (alfanúmerico) para agregar la pregunta";
        txtCodigoNuevo.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string codigo = GvAgregar.SelectedRow.Cells[1].Text;

        try
        {
            Pregunta unaP = Persistencia.Persistencia_Pregunta.Buscar(codigo);

            string codigoNuevo = txtCodigoNuevo.Text.ToString();
            string texto = unaP.Texto;
            string respuesta1 = unaP.Respuesta1;
            string respuesta2 = unaP.Respuesta2;
            string respuesta3 = unaP.Respuesta3;
            int correcta = unaP.Correcta;
            int valor = unaP.Valor;
            string cat = unaP.CategoriaA.Codigo;

            Pregunta NuevaPregunta = new Pregunta(codigoNuevo,texto,respuesta1,respuesta2,respuesta3,correcta,valor,Persistencia.Persistencia_Categorias.Buscar(cat));

            Juego unJuego = Persistencia.Persistencia_juego.Buscar(Convert.ToInt32(ddlJuego.SelectedValue));

            Logica.LogicaPregunta.AgregarPreguntaJuego(unJuego, NuevaPregunta);


            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "Se agregó correctamente";

            txtCodigoNuevo.Text = "";


            Session["ListaPreguntasJuego"] = Logica.LogicaPregunta.ListarPregunta(Convert.ToInt32(ddlJuego.SelectedValue));
            GvEliminar.DataSource = (List<EntidadesCompartidas.Pregunta>)Session["ListaPreguntasJuego"];
            GvEliminar.DataBind();
            
        }
        catch (Exception x)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = x.Message;
        }
    }

}