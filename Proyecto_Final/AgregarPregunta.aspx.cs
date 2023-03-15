using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarPregunta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LimpioFormulario();
        }
    }

    private void LimpioFormulario()
    {
        txtCodigo.Text = "";
        txtValor.Text = "";
        txtCategoria.Text = "";
        txtPregunta.Text = "";
        txtCategoria.Text = "";
        txtR1.Text = "";
        txtR2.Text = "";
        txtR3.Text = "";
        lblError.Text = "";
        

    }


    protected void btnAgregarP_Click(object sender, EventArgs e)
    {
        //Chequeo que no falte codigo, valor, texto, respuesta1, respuesta2, respuesta3
        if (txtCodigo.Text.Trim() != "" || txtValor.Text.Trim() != "" || txtPregunta.Text.Trim() != "" || txtR1.Text.Trim() != "" || txtR2.Text.Trim() != "" || txtR3.Text.Trim() != "")
        {
            //Chequeo que la categoria no sea vacía
            if (txtCategoria.Text.Trim() != "")
            {
                //Chequeo que alguno de los botones esté seleccionado
                if (rbtn1.Checked || rbtn2.Checked || rbtn3.Checked)
                {
                    try
                    {
                        //Declaramos la variables
                        EntidadesCompartidas.Pregunta unP;
                        int correcta;

                        if (rbtn1.Checked)
                            correcta = 1;
                        else if (rbtn2.Checked)
                            correcta = 2;
                        else
                            correcta = 3;

                        unP = new EntidadesCompartidas.Pregunta(txtCodigo.Text.ToString(), txtPregunta.Text.ToString(), txtR1.Text.ToString(), txtR2.Text.ToString(), txtR3.Text.ToString(), correcta, Convert.ToInt32(txtValor.Text), Persistencia.Persistencia_Categorias.Buscar(txtCategoria.Text.ToString()));

                        Persistencia.Persistencia_Pregunta.AgregarPregunta(unP);

                        lblError.ForeColor = System.Drawing.Color.Green;
                        LimpioFormulario();
                        lblError.Text = "Se agregó correctamente";
                    }
                    catch (Exception x)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = x.Message;
                    }
                }
                else
                    lblError.Text = "Seleccione una respuesta";
            }
            else
                lblError.Text = "Ingrese una Categoria";
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Al menos un campo está vacío";
        }
    }



}