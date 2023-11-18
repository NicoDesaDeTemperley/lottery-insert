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
        public int previa { get; set; }
        public int primera { get; set; }
        public int matutina { get; set; }
        public int vespertina { get; set; }
        public int tarde { get; set; }
        public int nocturna { get; set; }
        public string fecha_dia_publicacion { get; set; }
    }
}
