using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    public class Persistencia_Pregunta
    {
        public static List<Pregunta> Listar_pregunta(int pjuego)
        {
            List<Pregunta> lista = new List<Pregunta>();

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListarPreguntasJuego " + pjuego, _Conexion);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {

                        Pregunta P = new Pregunta(_Reader["codigo"].ToString(), _Reader["texto"].ToString(), _Reader["respuesta1"].ToString(), _Reader["respuesta2"].ToString(), _Reader["respuesta3"].ToString(), Convert.ToInt32(_Reader["correcta"].ToString()), Convert.ToInt32(_Reader["valor"].ToString()),Persistencia.Persistencia_juego.Buscar(Convert.ToInt32(_Reader["juego"].ToString())),Persistencia.Persistencia_Categorias.Buscar(_Reader["categoria"].ToString()));

                        lista.Add(P);
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

        public static void AgregarPregunta(EntidadesCompartidas.Pregunta unaP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("AgregarPregunta", _Conexion);

            //Le decimos que es un StoreProcedure
            _Comando.CommandType = CommandType.StoredProcedure;

            //Creamos los parametros
            _Comando.Parameters.AddWithValue("@Codigo", unaP.Codigo);
            _Comando.Parameters.AddWithValue("@texto", unaP.Texto);
            _Comando.Parameters.AddWithValue("@valor", unaP.Valor);
            _Comando.Parameters.AddWithValue("@correcta", unaP.Correcta);
            _Comando.Parameters.AddWithValue("@respuesta1", unaP.Respuesta1);
            _Comando.Parameters.AddWithValue("@respuesta2", unaP.Respuesta2);
            _Comando.Parameters.AddWithValue("@respuesta3", unaP.Respuesta3);
            _Comando.Parameters.AddWithValue("@categoria", unaP.CategoriaA.Codigo);

            //
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();// es solo almacenar en la base de datos, no trae nada

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe una Pregunta con ese codigo");
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

        public static EntidadesCompartidas.Pregunta Buscar(string pcodigo)
        {
            Pregunta P = null;

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("BuscarPreguntaPorCodigo", _Conexion);
            
            //Le decimos que es un StoreProcedure
            _Comando.CommandType = CommandType.StoredProcedure;

            //Creamos los parametros
            _Comando.Parameters.AddWithValue("@Codigo", pcodigo);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                {
                    P = new Pregunta(_Reader["codigo"].ToString(), _Reader["texto"].ToString(), _Reader["respuesta1"].ToString(), _Reader["respuesta2"].ToString(), _Reader["respuesta3"].ToString(), Convert.ToInt32(_Reader["correcta"].ToString()), Convert.ToInt32(_Reader["valor"].ToString()),Persistencia.Persistencia_juego.Buscar(Convert.ToInt32(_Reader["juego"].ToString())),Persistencia.Persistencia_Categorias.Buscar(_Reader["categoria"].ToString()));
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

            return P;
        }

        public static void EliminarPreguntaJuego(Juego unJ, Pregunta unP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("EliminarPreguntaJuego", _Conexion);

            //Le decimos que es un StoreProcedure
            _Comando.CommandType = CommandType.StoredProcedure;

            //Creamos los parametros
            _Comando.Parameters.AddWithValue("@Codigo", unP.Codigo);
            _Comando.Parameters.AddWithValue("@juego", unJ.Codigo);

            ////
            //SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            //_Retorno.Direction = ParameterDirection.ReturnValue;
            //_Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();// es solo borrar en la base de datos, no trae nada

                //int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                //if (oAfectados == -1)
                //    throw new Exception("Ya existe una Pregunta con ese codigo");
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

        public static List<Pregunta> ListarPreguntasNoAsociadas(int pJuego)
        {
            List<Pregunta> lista = new List<Pregunta>();

            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListarPreguntasNoAsociadas " + pJuego, _Conexion);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {

                        Pregunta P = new Pregunta(_Reader["codigo"].ToString(), _Reader["texto"].ToString(), _Reader["respuesta1"].ToString(), _Reader["respuesta2"].ToString(), _Reader["respuesta3"].ToString(), Convert.ToInt32(_Reader["correcta"].ToString()), Convert.ToInt32(_Reader["valor"].ToString()),Persistencia.Persistencia_Categorias.Buscar(_Reader["categoria"].ToString()));

                        lista.Add(P);
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

        public static void AgregarPreguntaJuego(Juego unJ,Pregunta unaP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("AgregarPreguntaJuego", _Conexion);

            //Le decimos que es un StoreProcedure
            _Comando.CommandType = CommandType.StoredProcedure;

            //Creamos los parametros
            _Comando.Parameters.AddWithValue("@codigoNuevo", unaP.Codigo);
            _Comando.Parameters.AddWithValue("@texto", unaP.Texto);
            _Comando.Parameters.AddWithValue("@valor", unaP.Valor);
            _Comando.Parameters.AddWithValue("@correcta", unaP.Correcta);
            _Comando.Parameters.AddWithValue("@respuesta1", unaP.Respuesta1);
            _Comando.Parameters.AddWithValue("@respuesta2", unaP.Respuesta2);
            _Comando.Parameters.AddWithValue("@respuesta3", unaP.Respuesta3);
            _Comando.Parameters.AddWithValue("@categoria", unaP.CategoriaA.Codigo);
            _Comando.Parameters.AddWithValue("@juego", unJ.Codigo);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();// es solo almacenar en la base de datos, no trae nada
            }
            catch
            {
                throw new Exception("Ya existe una pregunta con ese codigo!!");
            }
            finally
            {
                _Conexion.Close();
            }
        }
        
    }
}
