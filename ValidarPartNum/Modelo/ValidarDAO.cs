using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidarPartNum.DB;

namespace ValidarPartNum.Modelo
{
    public class ValidarDAO
    {

        public List<string> validarDB(validacion val)
        {
            List<string> lista = new List<string>();

            MySqlConnection conexion = Conexion.getConexion();

            conexion.Open();

            try
            {

                MySqlDataReader reader;

                string sql = "SELECT * FROM runcard.bom_component where bom_id = (select bom_id from runcard.wo_master_config as wm inner join runcard.bom_master_config as bm on wm.partnum=bm.bom_number and wm.bom_revision=bm.bom_revision  where workorder = '" + val._wo + "')";

                MySqlCommand comando = new MySqlCommand(sql, conexion);

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(reader.GetString(4));
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
