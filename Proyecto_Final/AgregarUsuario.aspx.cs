using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpioFormulario();

        }
    }
    //Funciones agregadas
    private void LimpioFormulario()
    {
        txtUsuario.Text = "";
        txtcontraseña.Text = "";
        txtNomCom.Text = "";
        lblError.Text = "";

    }

    protected void txtUsuario_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click1(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Admin unA = new EntidadesCompartidas.Admin(txtcontraseña.Text, txtUsuario.Text, txtNomCom.Text.Trim());

            Logica.LogicaAdmin.Agregar(unA);
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
}