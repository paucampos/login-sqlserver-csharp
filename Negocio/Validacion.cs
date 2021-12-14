using System;
using Datos;
using System.Text;
using System.Data.SqlClient;

namespace Negocio
{
    public class Validacion
    {
        private Conexion objBD;
        public bool validaUsuario(string rut, string clave)
        {
           
            Datos_Usuarios dataUser = new Datos_Usuarios();
            string Sql = "SELECT * FROM usuario WHERE rut = '" + rut + "'";
            SqlCommand comando = conectar(Sql);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                dataUser.UserId = registro["rut"].ToString();
                dataUser.Password = registro["clave"].ToString();
                dataUser.IntentosErroneos = Convert.ToInt32(registro["intentos"].ToString());
                if (dataUser.IntentosErroneos > 4)
                {
                    throw new Exception("Usuario bloqueado");
                }
                else
                {
                    // Si la clave ingresada por usuario es igual a la de bd
                    if (clave == dataUser.Password)
                    {
                        objBD.CerrarCon();
                        return true;
                    }
                    else
                    {
                        objBD.CerrarCon();
                        dataUser.IntentosErroneos++;
                        Sql = "update usuario set intentos = '" + dataUser.IntentosErroneos + "' WHERE rut = '" + rut + "'";
                        SqlCommand cmd = new SqlCommand(Sql, objBD.AbrirCon());
                        cmd.ExecuteNonQuery();
                        objBD.CerrarCon();


                        if (dataUser.IntentosErroneos <= 4)
                        {
                            throw new Exception("Credenciales inválidas" + " (0" + dataUser.IntentosErroneos + ").");
                        }
                        else
                        {
                            // Bloqueo al usuario
                            throw new Exception("Usuario bloqueado");


                        }
                    }
                }

            }
            else
            {
                throw new Exception("No existe usuario!");
            }
        }
        public void Reinicio()
        {
            Conexion objBD = new Conexion();
            string cero = "update usuario set intentos = 0";
            SqlCommand comando = new SqlCommand(cero, objBD.AbrirCon());
            comando.ExecuteNonQuery();
            objBD.CerrarCon();

        }

        private SqlCommand conectar(string sql) {
            objBD = new Conexion();
            StringBuilder errorMessages = new StringBuilder();
            try
            {
                return new SqlCommand(sql, objBD.AbrirCon());
         
            }
            catch (SqlException err)
            {
                for (int i = 0; i<err.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + err.Errors[i].Message + "\n" +
                        "LineNumber: " + err.Errors[i].LineNumber + "\n" +
                        "Source: " + err.Errors[i].Source + "\n" +
                        "Procedure: " + err.Errors[i].Procedure + "\n"
                    );
                }
                throw new Exception(Convert.ToString(errorMessages));
            }
        }

    }
}