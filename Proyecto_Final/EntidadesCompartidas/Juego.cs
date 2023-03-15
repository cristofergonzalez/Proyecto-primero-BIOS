using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Juego
    {
        //Atributos
        private int codigo;
        private DateTime fecha;
        private string dificultad;

        Admin admin;

        //Propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Dificultad
        {
            get{return dificultad;}
            set
            {
                if (value != "")
                    dificultad = value;
                else
                    throw new Exception("Dificultad no puede ser vacía");
            }
        }

        public Admin Admin
        {
            get { return admin; }
            set {
                if (value == null)
                    throw new Exception("No se encontró un Admin con ese Nombre de Usuario");
                else
                    admin = value;
            }
        }

        //Constructor
        public Juego(int pcodigo, string pdificultad, DateTime pfecha, Admin padmin)
        {
            Dificultad = pdificultad;
            Admin = padmin;
            Fecha = pfecha;
            Codigo = pcodigo;

        }

        public Juego(string pDificultad, Admin pAdmin)
        {
            Dificultad = pDificultad;
            Admin = pAdmin;
        }
    }
}
