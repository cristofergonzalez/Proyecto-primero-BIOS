using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;

namespace Logica
{
    public class LogicaPregunta
    {
        public static void Agregar(EntidadesCompartidas.Pregunta pPregunta)
        {
            Persistencia.Persistencia_Pregunta.AgregarPregunta(pPregunta);
        }

        public static List<Pregunta> ListarPregunta(int pJuego)
        {
            //Inicializamos la lista
            List<Pregunta> _lista = new List<Pregunta>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_Pregunta.Listar_pregunta(pJuego));
            //Retornamos la list
            return (_lista);

        }

        public static EntidadesCompartidas.Pregunta Buscar(string pcodigo)
        {
            return (Persistencia.Persistencia_Pregunta.Buscar(pcodigo));
        }

        public static void Eliminar(EntidadesCompartidas.Juego unJ, EntidadesCompartidas.Pregunta unP)
        {
            Persistencia.Persistencia_Pregunta.EliminarPreguntaJuego(unJ,unP);
        }

        public static List<Pregunta> ListarPreguntasNoAsociadas(int pJuego)
        {
            //Inicializamos la lista
            List<Pregunta> _lista = new List<Pregunta>();
            //Añadimos a la lista la lista de Jugadas
            _lista.AddRange(Persistencia.Persistencia_Pregunta.ListarPreguntasNoAsociadas(pJuego));
            //Retornamos la list
            return (_lista);
        }

        public static void AgregarPreguntaJuego(EntidadesCompartidas.Juego unJ,EntidadesCompartidas.Pregunta unaP)
        {
            Persistencia.Persistencia_Pregunta.AgregarPreguntaJuego(unJ,unaP);
        }
    }
}
