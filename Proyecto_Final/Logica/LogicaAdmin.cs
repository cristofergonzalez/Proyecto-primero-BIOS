using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;

namespace Logica
{
    public class LogicaAdmin
    {
        public static EntidadesCompartidas.Admin Logueo(string pUsu, string pPass)
        {
            return (Persistencia.Persistencia_admin.Logueo(pUsu, pPass));
        }

        public static void Agregar(EntidadesCompartidas.Admin unAdmin)
        {
            Persistencia_admin.Agregar(unAdmin);
        }
    }
}
