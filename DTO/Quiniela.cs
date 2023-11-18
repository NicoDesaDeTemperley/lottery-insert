using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loterry_console.Dto
{
    public class Quiniela
    {
        public string nombre_quiniela { get; set; }
        public string previa { get; set; }
        public string primera { get; set; }
        public string matutina { get; set; }
        public string vespertina { get; set; }
        public string tarde { get; set; }
        public string nocturna { get; set; }
        public string fecha_dia_publicacion { get; set; }
    }
}
