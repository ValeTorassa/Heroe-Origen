using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Heroe
    {
        public string Nombre { get; set; }
        public string Clase { get; set; }
        public int Nivel { get; set; }
        public Origen Origen { get; set; }
    }
}
