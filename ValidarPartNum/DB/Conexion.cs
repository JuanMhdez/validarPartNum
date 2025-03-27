using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace ValidarPartNum.DB
{
    public class Conexion
    {


        public static MySqlConnection getConexion()
        {

            string servidor = "MLXGUMVLRCDB02.molex.com";
            string puerto = "3306";
            string usuario = "Jhernandez01";
            string password = "Jhernandez01123";
            string db = "runcard";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + db;
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            return conexion;


        }

    }
}