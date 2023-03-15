using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaJuego
    {
        public static void Agregar(EntidadesCompartidas.Juego pJuego)
        {
            Persistencia.Persistencia_juego.Agregar(pJuego);
        }

        public static List<int> ListarJuego()
        {
            //Inicializamos la lista
            List<int> _lista = new List<int>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_juego.Listar_Juegos());
            //Retornamos la list
            return (_lista);

        }

        public static List<int> Listar_TodosJuegos()
        {
            //Inicializamos la lista
            List<int> _lista = new List<int>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_juego.Listar_TodosJuegos());
            //Retornamos la list
            return (_lista);

        }

        public static List<EntidadesCompartidas.Juego> ListarJuegosJugar()
        {
            //Inicializamos la lista
            List<EntidadesCompartidas.Juego> _lista = new List<EntidadesCompartidas.Juego>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_juego.ListarJuegosJugar());
            //Retornamos la list
            return (_lista);

        }

        public static EntidadesCompartidas.Juego Buscar(int pcod)
        {
            return (Persistencia.Persistencia_juego.Buscar(pcod));
        }
    }
}
