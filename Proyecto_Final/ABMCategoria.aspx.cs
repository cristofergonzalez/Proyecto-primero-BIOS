using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class ABMCategoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }

    //Funciones agregadas(Activar/desactivar botones)
    private void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;

        txtNombre.Enabled = true;
        txtCodigo.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;

        txtCodigo.Enabled = false;
        txtNombre.Enabled = true;
    }

    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;

        btnBuscar.Enabled = true;

        txtCodigo.Enabled = true;
        txtNombre.Enabled = false;

        txtCodigo.Text = "";
        txtNombre.Text = "";
        lblError.Text = "";
    }

    private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        //Boton Agregar
        if (txtCodigo.Text != "" && txtNombre.Text != "")
        {
            string Codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;

            //construye la entidad compartida Usuario con el constructor completo de la clase.
            Categoria C = new Categoria(Codigo,nombre);
            try
            {
                LogicaCategoria.Agregar(C);

                lblError.ForeColor = System.Drawing.Color.Green;
                LimpioFormulario();
                lblError.Text = "Se agregó correctamente";
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = ex.Message;
            }
        }
        else
            lblError.Text = "Al menos un campo está vacío";
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        //Boton Modificar

        string Codigo = txtCodigo.Text;
        string Nombre = txtNombre.Text;


        Categoria C = (Categoria)Session["Categoria"];

        C.Codigo = Codigo;
        C.Nom_Categoria = Nombre;

        try
        {
            LogicaCategoria.Modificar(C);

            lblError.ForeColor = System.Drawing.Color.Green;
            LimpioFormulario();
            lblError.Text = "Se modificó correctamente";

            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Categoria C = (Categoria)Session["Categoria"];

            LogicaCategoria.Eliminar(C);

            this.LimpioFormulario();
            lblError.Text = "Se eliminó correctamente";
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txtCodigo.Text != "")
        {
            try
            {//llama a ejecutar operaciones de la capa Lógica

                Categoria C = LogicaCategoria.Buscar(txtCodigo.Text);

                if (C != null)
                {
                    txtCodigo.Text = C.Codigo;
                    txtNombre.Text = C.Nom_Categoria;
                    Session["Categoria"] = C;

                    ActivoBotonesBM();
                }
                else
                {
                    lblError.Text = "La Categoria no existe en el sistema!";
                    ActivoBotonesA();
                }
            }
            catch (Exception x)
            {
                lblError.Text = x.Message;
            }
        }
        else
        {
            lblError.Text = "Debe ingresar un Codigo!";
        }
    }
}