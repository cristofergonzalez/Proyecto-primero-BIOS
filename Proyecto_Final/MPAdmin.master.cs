using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MPAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //verifico q el usuario tenga permiso de ingreso
            if (!(Session["Admin"] is EntidadesCompartidas.Admin))
                Response.Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
        catch
        {
            Response.Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        EntidadesCompartidas.Admin unA = (EntidadesCompartidas.Admin)Session["Admin"];
        lblUsuario.Text = unA.Usuario.ToUpper();
    }
}
