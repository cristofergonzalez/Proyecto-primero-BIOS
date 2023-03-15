using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class Persistencia_Jugada
    {
        public static List<Jugada> ListarJugada()
        {
            List<Jugada> lista = new List<Jugada>(); ;

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("GrillaInicial", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Jugada J = new Jugada(Convert.ToInt32(_Reader["Puntaje"]), _Reader["nombre_jugador"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia_juego.Buscar(Convert.ToInt32(_Reader["juego"])));
                        lista.Add(J);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return lista;
        }

        public static List<Jugada> ListarJugadaPorJuego(int pJuego)
        {
            List<Jugada> lista = new List<Jugada>(); ;

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListarJugadasJuego "+pJuego, _Conexion);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        
                        Jugada J = new Jugada(Convert.ToInt32(_Reader["Puntaje"]), _Reader["nombre_jugador"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia_juego.Buscar(Convert.ToInt32(_Reader["juego"])));
                        
                        lista.Add(J);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return lista;
        }

        public static void Guardar(EntidadesCompartidas.Jugada unaJ)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("AlmacenarJugadas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Juego", unaJ.JuegoA.Codigo);
            _Comando.Parameters.AddWithValue("@Usuario", unaJ.Nom_jugador);
            _Comando.Parameters.AddWithValue("@Puntaje", unaJ.Puntaje);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();// es solo almacenar en la base de datos, no trae nada
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }
    }
}
