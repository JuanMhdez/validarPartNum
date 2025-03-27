using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidarPartNum.Modelo
{
    public class validacion
    {

        public string _numeroParte { get; set; }
        public string _wo { get; set; }
        public string _item { get; set; }


        public validacion(string numeroParte, string wo, string item)
        {

            this._numeroParte = numeroParte;
            this._wo = wo;
            this._item = item;

        }

        public override string ToString()
        {
            return $"Número de parte: {_item}, WO: {_wo}, Número de parte item: {_item}";
        }


    }
}
