using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        // CON AUTENTICACIÓN DE WINDOWS
        SqlConnection cnn = new SqlConnection(@"Data Source=ZENBOOK-PAU\MSSQLSERVER01; Initial Catalog=CRMCLI; Integrated Security=True");
        // CON AUTENTICACIÓN DE SQL SERVER
        // "Data Source=ZENBOOK-PAU\MSSQLSERVER01; Initial Catalog=CRMCLI; User ID=test; Password=1q2w3e"

        public SqlConnection AbrirCon()
        {
            cnn.Open();
            return cnn;
        }

        public SqlConnection CerrarCon()
        {
            cnn.Close();
            return cnn;
        }
    }
}
