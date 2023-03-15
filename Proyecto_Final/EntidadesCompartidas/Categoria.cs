using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Categoria
    {
        //Atributos
        private string codigo;
        private string nom_categoria;



        //Propiedades
        public string Codigo
        {
            set
            {
                if (value != "")
                    codigo = value;
                else
                    throw new Exception("El Codigo no puede ser vacío");
            }
            get { return codigo; }
        }


        public string Nom_Categoria
        {
            set { if (value != "")
                    nom_categoria = value;
                else
                    throw new Exception("El Nombre de la categoría no puede ser vacía");
            }
            get { return nom_categoria; }
        }

        //Constructor
        public Categoria(string pcodigo, string pNomCat)
        {
            Codigo = pcodigo;
            nom_categoria = pNomCat;
        }
    }
}
