using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Origen
    {
        public string NombreHistoria { get; set; }
        public string Lugar { get; set; }
        public string Historia { get; set; }


        public override string ToString()
        {
            return NombreHistoria;
        }
    }
}
