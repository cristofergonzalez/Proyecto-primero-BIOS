using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaJugada
    {
        public static List<EntidadesCompartidas.Jugada> ListarTodo()
        {
            //Inicializamos la lista
            List<EntidadesCompartidas.Jugada> _lista = new List<EntidadesCompartidas.Jugada>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_Jugada.ListarJugada());
            //Retornamos la lista
            return (_lista);
        }

        public static List<EntidadesCompartidas.Jugada> ListarJugadasPorJuego(int pJuego)
        {
            //Inicializamos la lista
            List<EntidadesCompartidas.Jugada> _lista = new List<EntidadesCompartidas.Jugada>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_Jugada.ListarJugadaPorJuego(pJuego));
            //Retornamos la lista
            return (_lista);
        }

        public static void Guardar(EntidadesCompartidas.Jugada unaJ)
        {
            Persistencia.Persistencia_Jugada.Guardar(unaJ);
        }
    }
}
