using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidarPartNum.Runcard03;
using ValidarPartNum.DB;
using MySqlConnector;
using System.Windows.Forms;

namespace ValidarPartNum.Modelo
{
    public class ObtenerNumParte
    {


        public string validarNumeroDeparte(string numeroParte)
        {

            string partnum = string.Empty;

            MySqlConnection conexion = Conexion.getConexion();

            conexion.Open();

            try
            {

                MySqlDataReader reader;

                string qry = "SELECT partnum FROM runcard.wo_master_config where status = 'ISSUED' and partnum = '" + numeroParte + "';";

                MySqlCommand comando = new MySqlCommand(qry,conexion);


                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    partnum = reader.GetString(0);
                }

                conexion.Close();

                if (partnum == numeroParte)
                {

                    return "Good";
                }
                else
                {
                    return "";
                }

                

            }
            catch (MySqlException)
            {

                MessageBox.Show("Error al consultar la base de datos");
                
            }

            return partnum;

        }


        public List<string> ObtenerNumParteDB() {

            List<string> lista = new List<string>();

            MySqlConnection conexion = Conexion.getConexion();

            conexion.Open();

            try
            {

                MySqlDataReader reader;

                string sql = "SELECT distinct partnum FROM runcard.wo_master_config where status = 'ISSUED';";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(reader.GetString(0));
                }

                conexion.Close();

            }

            catch (MySqlException ex)
            {

                MessageBox.Show("Error al conectar la base de datos" + ex);
            }

            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
            return lista;
        }
    }
}
