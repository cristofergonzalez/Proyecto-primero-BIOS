using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class Persistencia_juego
    {
        public static EntidadesCompartidas.Juego Buscar(int pcod)
        {
            EntidadesCompartidas.Juego J = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("exec BuscarJuego " + pcod, _Conexion);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    J = new EntidadesCompartidas.Juego(Convert.ToInt32(_Reader["codigo"]), _Reader["dificultad"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia_admin.Buscar(_Reader["creador"].ToString()));

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

            return J;
        }

        public static void Agregar(EntidadesCompartidas.Juego unJuego)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("AgregarJuego", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@dificultad", unJuego.Dificultad);
            _Comando.Parameters.AddWithValue("@UsuCreador", unJuego.Admin.Usuario);
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

        public static List<int> Listar_Juegos()
        {
            List<int> lista = new List<int>(); 

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("JuegosConPreguntas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Juego J = new Juego(Convert.ToInt32(_Reader["codigo"]), _Reader["dificultad"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia.Persistencia_admin.Buscar(_Reader["creador"].ToString()));
                        
                        //Lo agregamos a la lista
                        lista.Add(J.Codigo);
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

        public static List<int> Listar_TodosJuegos()
        {
            List<int> lista = new List<int>();

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("ListarTodosLosJuegos", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Juego J = new Juego(Convert.ToInt32(_Reader["codigo"]), _Reader["dificultad"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia.Persistencia_admin.Buscar(_Reader["creador"].ToString()));

                        //Lo agregamos a la lista
                        lista.Add(J.Codigo);
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

        public static List<Juego> ListarJuegosJugar()
        {
            List<Juego> lista = new List<Juego>();

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("JuegosConPreguntas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Juego J = new Juego(Convert.ToInt32(_Reader["codigo"]), _Reader["dificultad"].ToString(), Convert.ToDateTime(_Reader["fecha"]), Persistencia.Persistencia_admin.Buscar(_Reader["creador"].ToString()));

                        //Lo agregamos a la lista
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

    }
}
