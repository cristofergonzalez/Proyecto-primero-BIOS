using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Admin
    {
        //Atributos
        private string contraseña;
        private string usuario;
        private string nomcom;

        //Propiedades
        public string Contraseña
        {
            set
            {
                if (value != "")
                    contraseña = value;
                else
                    throw new Exception("La contraseña no puede ser vacía");
            }
            get { return contraseña; }
        }


        public string Usuario
        {
            set
            {
                if (value != "")
                    usuario = value;
                else
                    throw new Exception("El Usuario no puede ser vacío");
            }
            get { return usuario; }
        }


        public string NomCom
        {
            set
            {
                if (value != "")
                    nomcom = value;
                else
                    throw new Exception("El Nombre no puede ser vacío");
            }
            get { return nomcom; }
        }


        //Constructor
        public Admin(string pContraseña, string pUsuario, string pNomCom)
        {
            Contraseña = pContraseña;
            Usuario = pUsuario;
            NomCom = pNomCom;
        }

    }
}
