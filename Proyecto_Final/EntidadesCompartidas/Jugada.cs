using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Jugada
    {
        //Atributos
        private int puntaje;
        private DateTime fecha;
        private string nom_jugador;

        Juego juego;

        //Propiedades
        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Nom_jugador
        {
            get{return nom_jugador;}
            set
            {
                if (value != "")
                    nom_jugador = value;
                else
                    throw new Exception("Nombre de jugador no puede ser vacío");
            }
        }

        public Juego JuegoA
        {
            get { return juego; }
            set {
                if (value == null)
                    throw new Exception("No se encontró un Juego con ese Codigo");
                else
                    juego = value;
            }
        }

        //Constructor
        public Jugada(int ppuntaje, string pnom_jugador, DateTime pfecha, Juego pjuego)
        {
            Nom_jugador = pnom_jugador;
            JuegoA = pjuego;
            Fecha = pfecha;
            Puntaje = ppuntaje;


        }

        public Jugada(int ppuntaje, string pnom_jugador,Juego pjuego)
        {
            Nom_jugador = pnom_jugador;
            JuegoA = pjuego;
            Puntaje = ppuntaje;
        }
    }
}
