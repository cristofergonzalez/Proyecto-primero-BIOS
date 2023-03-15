using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pregunta
    {
        //Atributos
        private string codigo;
        private string texto;
        private string respuesta1;
        private string respuesta2;
        private string respuesta3;
        private int correcta;
        private int valor;

        Juego juego;

        Categoria categoria;

        //Propiedades
        public string Codigo
        {
            set
            {
                if (value != "" || value.Length == 5)
                    codigo = value;
                else
                    throw new Exception("No puede ser vacío y tiene que tener 5 caracteres de largo");
            }
            get { return codigo; }
        }


        public string Texto
        {
            set { if (value != "" && value.Length <= 200)
                    texto = value;
                else
                    throw new Exception("El texto ingresado no puede ser vacío y no puede tener mas de 200 caracteres");
            }
            get { return texto; }
        }


        public string Respuesta1
        {
            set { if (value != "" && value.Length <= 200)
                    respuesta1 = value;
                else
                    throw new Exception("La respuesta 1 no puede ser vacía y tiene que tener menos de 200 caracteres");
            }
            get { return respuesta1; }
        }

        public string Respuesta2
        {
            set { if (value != "" && value.Length <= 200)
                    respuesta2 = value;
                else
                    throw new Exception("La respuesta 2 no puede ser vacía y tiene que tener menos de 200 caracteres");
            }
            get { return respuesta2; }
        }

        public string Respuesta3
        {
            set { if (value != "" && value.Length <= 200)
                    respuesta3 = value;
                else
                    throw new Exception("La respuesta 3 no puede ser vacía y tiene que tener menos de 200 caracteres");
            }
            get { return respuesta3; }
        }


        public int Correcta
        {
            set { if (value == 1 || value == 2 || value == 3)
                    correcta = value;
                else
                    throw new Exception("La respuesta correcta tiene que ser 1, 2 o 3");
            }
            get { return correcta; }
        }

        public int Valor
        {
            set { if (value >= 1 && value <= 10)
                    valor = value;
                else
                    throw new Exception("El valor de la pregunta tiene que estar entre 1 y 10 puntos");
            }
            get { return valor; }
        }


        public Juego JuegoA
        {
            get { return juego; }
            set {
                if (value == null)
                    throw new Exception("No se encontró un Juego con ese Nombre");
                else
                    juego = value;
            }
        }

        public Categoria CategoriaA
        {
            get { return categoria; }
            set
            {
                if (value == null)
                    throw new Exception("No se encontró una Categoria con ese Nombre");
                else
                    categoria = value;
            }
        }

        //Constructor
        public Pregunta(string pcodigo, string ptexto, string prepuesta1, string prepuesta2, string prepuesta3, int pcorrecta, int pvalor, Juego pjuego, Categoria pcategoria)
        {
            Codigo = pcodigo;
            CategoriaA = pcategoria;
            Texto = ptexto;
            Respuesta1 = prepuesta1;
            Respuesta2 = prepuesta2;
            Respuesta3 = prepuesta3;
            Correcta = pcorrecta;
            Valor = pvalor;
            JuegoA = pjuego;
        }
        public Pregunta(string pcodigo, string ptexto, string prepuesta1, string prepuesta2, string prepuesta3, int pcorrecta, int pvalor, Categoria pcategoria)
        {
            Codigo = pcodigo;
            CategoriaA = pcategoria;
            Texto = ptexto;
            Respuesta1 = prepuesta1;
            Respuesta2 = prepuesta2;
            Respuesta3 = prepuesta3;
            Correcta = pcorrecta;
            Valor = pvalor;
        }
    }
}
