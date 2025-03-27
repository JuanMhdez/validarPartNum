using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidarPartNum.DB;
using ValidarPartNum.Runcard03;

namespace ValidarPartNum.Modelo
{
    public class obtenerWO
    {

        runcard_wsdlPortTypeClient cliente = new runcard_wsdlPortTypeClient("runcard_wsdlPort");
        

        public List<string> obtenerWORuncard(string partNum)
        {
            List<string> lista = new List<string>();
            lista.Clear();

            string msg = string.Empty;
            int error;

            var wo = cliente.getAvailableWorkOrders(partNum,"",out error,out msg);

            

            if(error == 0)
            {
                
                foreach(var item in wo)
                {
                    lista.Add(item.workorder);
                }

                return lista;

            }
            else
            {
                return lista;
            }
        }

    }
}
