using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCategoria
    {
        public static Categoria Buscar(string pcodigo)
        {
            Categoria t = null;
            t = (Categoria)Persistencia_Categorias.Buscar(pcodigo);
            if (t != null)
                return t;
            else
                return null;
        }


        public static void Agregar(Categoria unC)
        {
            Persistencia_Categorias.Agregar(unC);
        }


        public static void Modificar(Categoria unC)
        {
            Persistencia_Categorias.Modificar(unC);
        }


        public static void Eliminar(Categoria unC)
        {
            Persistencia_Categorias.Eliminar(unC);
        }
    }
}
