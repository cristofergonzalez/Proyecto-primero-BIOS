using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class Persistencia_admin
    {
        public static EntidadesCompartidas.Admin Logueo(string pAdmin, string pPass)
        {
            //variables
            SqlConnection _cnn = new SqlConnection(Conexion.cnn);
            SqlCommand _comando = new SqlCommand("Logueo", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Admin unAdmin = null;


            //parametros
            _comando.Parameters.AddWithValue("@Usuario", pAdmin);
            _comando.Parameters.AddWithValue("@Contraseña", pPass);

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _Usu = (string)_lector["usuario"];
                    string _NomCom = (string)_lector["nom_completo"];
                    string _Contra = (string)_lector["contraseña"];

                    unAdmin = new EntidadesCompartidas.Admin(_Contra,_Usu,_NomCom);
                    
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            return unAdmin;
        }

        public static void Agregar(EntidadesCompartidas.Admin unAdmin)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("AltaUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Usuario", unAdmin.Usuario);
            _Comando.Parameters.AddWithValue("@Contraseña", unAdmin.Contraseña);
            _Comando.Parameters.AddWithValue("@Nom_Completo", unAdmin.NomCom);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();// es solo almacenar en la base de datos, no trae nada

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe el usuario");
                else if (oAfectados == -2)
                    throw new Exception("Algo salió mal");
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

        public static Admin Buscar(string pUsu)
        {
            Admin A = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion.cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarAdmin " + pUsu, _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    A = new Admin(_Reader["contraseña"].ToString(), _Reader["usuario"].ToString(), _Reader["nom_completo"].ToString());

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

            return A;
        }
    }
}
