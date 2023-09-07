using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaProyecto2PRESTAMO
{
    class prestamo
    {
        public string Persona { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public libro LibroPrestado { get; set; }
        public prestamo Siguiente { get; set; }
    }
}
