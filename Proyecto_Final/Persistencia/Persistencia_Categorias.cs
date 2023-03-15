using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
     public class Persistencia_Categorias
    {
        public static Categoria Buscar(string codigoCat)
        {
            //Inicializo las variables
            string nombre, codigo;

            Categoria C = null;
            SqlDataReader oReader;//necesitamos un contenedor de datos
            SqlConnection oConexion = new SqlConnection(Conexion.cnn);
            SqlCommand oComando = new SqlCommand("Exec BuscarCategoria " + codigoCat, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                //construye el contenedor de datos
                if (oReader.Read())
                {
                    codigo = (string)oReader["codigo"];
                    nombre = (string)oReader["nombre"];
                    C = new Categoria(codigo,nombre);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return C;//devuelve el objeto buscado o null
        }

        public static void Agregar(Categoria unC)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.cnn);
            SqlCommand oComando = new SqlCommand("AgregarCategoria", oConexion);

            oComando.CommandType = CommandType.StoredProcedure;

            //construimos los parámetros del procedimiento
            oComando.Parameters.AddWithValue("@Codigo", unC.Codigo);
            oComando.Parameters.AddWithValue("@NombreCategoria", unC.Nom_Categoria);


            //defino el parámetro ReturnValue
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                //Usamos ExecuteNonQuery porque no vamos a traer nada a la web
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("Ya existe la Categoria");
            }
            catch (Exception ex)
            {
                throw ex;//para que lo capture algún catch
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Categoria unC)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.cnn);
            SqlCommand oComando = new SqlCommand("ModificarCategoria", oConexion);

            oComando.CommandType = CommandType.StoredProcedure;

            //construimos los parámetros del procedimiento
            oComando.Parameters.AddWithValue("@Codigo", unC.Codigo);
            oComando.Parameters.AddWithValue("@NombreCodigo", unC.Nom_Categoria);


            //defino el parámetro ReturnValue
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);
            try
            {
                //trabajando en forma Conectada 
                oConexion.Open();
                oComando.ExecuteNonQuery();

                //Variable del return
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("La Categoria no existe");
            }
            catch (Exception ex)
            {
                throw ex;//para que lo capture algún catch
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static void Eliminar(Categoria unC)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.cnn);
            SqlCommand oComando = new SqlCommand("EliminarCategoria", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            //construimos los parámetros del StoredProcedure
            oComando.Parameters.AddWithValue("@Codigo", unC.Codigo);

            //defino el parámetro ReturnValue
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No existe la Categoria en el sistema");
                else if (oAfectados == -2)
                    throw new Exception("Tiene Preguntas asociadas");
            }
            catch (Exception ex)
            {
                throw ex;//para que lo capture algún catch
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
