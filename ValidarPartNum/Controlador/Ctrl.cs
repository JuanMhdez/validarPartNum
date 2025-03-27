using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidarPartNum.Modelo;

namespace ValidarPartNum.Controlador
{
    public class Ctrl
    {


        public string validarNumeroPart(string numeroParte)
        {
            string resultado = string.Empty;

            ObtenerNumParte validar = new ObtenerNumParte();

            resultado = validar.validarNumeroDeparte(numeroParte);

            if(resultado == "Good")
            {
                return resultado;
            }
            else
            {
                return "";
            }

        }
        


        public List<string> obtenerPartNum()
        {
            ObtenerNumParte obtenerNumeroDeParte = new ObtenerNumParte();

            List<string> lista = new List<string>();

           if(obtenerNumeroDeParte.ObtenerNumParteDB().Count != 0)
            {
                lista = obtenerNumeroDeParte.ObtenerNumParteDB();
                return lista;
            }

            else
            {
                return lista;
            }

        }

        public List<string> obtenerWO(string numParte)
        {
            obtenerWO obtenerWo = new obtenerWO();

            List<string> lista = new List<string>();

            if(obtenerWo.obtenerWORuncard(numParte).Count != 0)
            {
                lista = obtenerWo.obtenerWORuncard(numParte);

                return lista;
            }

            else
            {
                return lista;
            }
        }


        public List<string> validarItem(validacion val)
        {
            List<string> lista = new List<string>();

            ValidarDAO validarDAO = new ValidarDAO();

            if(validarDAO.validarDB(val).Count != 0)
            {
                lista = validarDAO.validarDB(val);
                return lista;
            }
            else
            {
                return lista;
            }

        }



    }
}
