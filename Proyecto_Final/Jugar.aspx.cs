using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jugar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ListarJuegoJugar"] = Logica.LogicaJuego.ListarJuegosJugar();
            gvElegirJuego.DataSource = (List<EntidadesCompartidas.Juego>)Session["ListarJuegoJugar"];
            gvElegirJuego.DataBind();

            //Arranca en 0
            Session["NumeroPregunta"] = 0;

            //La lista arranca vacía
            Session["PreguntasJugar"] = new List<EntidadesCompartidas.Pregunta> { };

            //Puntaje arranca en 0
            Session["Puntaje"] = 0;

            btnComenzar.Enabled = false;
            btnSiguiente.Enabled = false;

            rbnR1.Checked = true;

            txtNombreU.Visible = false;
            lblAgregarU.Visible = false;
            btnGuardar.Visible = false;
            RequiredFieldValidator1.Visible = false;
        }
        
    }
    //Funciones agregadas
    public void DesactivoTodo()
    {
        //Desactivo todo
        btnSiguiente.Enabled = false;
        hlkInicio.Enabled = false;
        rbnR1.Enabled = false;
        rbnR2.Enabled = false;
        rbnR3.Enabled = false;

        //Activo el agregar nombre
        txtNombreU.Visible = true;
        lblAgregarU.Visible = true;
        btnGuardar.Visible = true;
        RequiredFieldValidator1.Visible = true;
    }

    public void ComenzarJuego(int numeroDePregunta)
    {
        //Solo muestra la Pregunta
        try
        {
            List<EntidadesCompartidas.Pregunta> listaP = (List<EntidadesCompartidas.Pregunta>)Session["PreguntasJugar"];

            if (listaP.Count != 0)
            {
                if (numeroDePregunta < listaP.Count)
                {
                    lblPregunta.Text = listaP[numeroDePregunta].Texto;

                    rbnR1.Text = "1. " + listaP[numeroDePregunta].Respuesta1;
                    rbnR2.Text = "2. " + listaP[numeroDePregunta].Respuesta2;
                    rbnR3.Text = "3. " + listaP[numeroDePregunta].Respuesta3;
                }
                else if (numeroDePregunta == listaP.Count)
                {
                    DesactivoTodo();
                }
            }
        }
        catch (Exception x)
        {
            lblError.Text = x.Message;
        }
    }

    public void ValidaCorrecta(int numeroDePregunta)
    {
        List<EntidadesCompartidas.Pregunta> listaP = (List<EntidadesCompartidas.Pregunta>)Session["PreguntasJugar"];

        int puntaje = (int)Session["Puntaje"];
        int correcta = 0;

        if (rbnR1.Checked)
            correcta = 1;
        else if (rbnR2.Checked)
            correcta = 2;
        else
            correcta = 3;
        try
        {
            if (numeroDePregunta < listaP.Count)
            {
                if (listaP[numeroDePregunta].Correcta == correcta)
                {
                    puntaje = puntaje + listaP[numeroDePregunta].Valor;
                    Session["Puntaje"] = puntaje;
                    
                }

                ComenzarJuego(numeroDePregunta + 1);
            }
            

        }
        catch (Exception x)
        {
            lblError.Text = x.Message;
        }

    }

    public void GuardarJugada(int puntaje)
    {
        try
        {
            EntidadesCompartidas.Juego unJ = Logica.LogicaJuego.Buscar(Convert.ToInt32(gvElegirJuego.SelectedRow.Cells[1].Text));

            EntidadesCompartidas.Jugada unaJ = new EntidadesCompartidas.Jugada(puntaje, txtNombreU.Text,unJ);

            Logica.LogicaJugada.Guardar(unaJ);

            lblError.ForeColor = System.Drawing.Color.Green;
            lblError.Text = "La Jugada se guardó correctamente";
           
        }
        catch (Exception x)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = x.Message;
        }
    }

    protected void rbnR1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        int n = (int)Session["NumeroPregunta"];
        ValidaCorrecta(n);

        Session["NumeroPregunta"]=n + 1;

    }

    protected void gvElegirJuego_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnComenzar.Enabled = true;
        try
        {
            //Subimos a la Session las pregntas de dicho juego
            int codigo = Convert.ToInt32(gvElegirJuego.SelectedRow.Cells[1].Text);
            Session["PreguntasJugar"] = Logica.LogicaPregunta.ListarPregunta(codigo); // Cada lista tiene indices [0][1][2][3]
            
        }
        catch (Exception x)
        {
            lblError.Text = x.Message;
        }


    }

    protected void gvElegirJuego_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Esto se ejecuta una vez
    protected void btnComenzar_Click(object sender, EventArgs e)
    {
        try
        {
            ComenzarJuego((int)Session["NumeroPregunta"]);
        }
        catch (Exception x)
        {
            lblError.Text = x.Message;
        }
        gvElegirJuego.Enabled = false;
        btnComenzar.Enabled = false;
        btnSiguiente.Enabled = true;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        GuardarJugada((int)Session["Puntaje"]);
        btnGuardar.Enabled = false;
        hlkInicio.Enabled = true;
        txtNombreU.Enabled = false;
    }
}
