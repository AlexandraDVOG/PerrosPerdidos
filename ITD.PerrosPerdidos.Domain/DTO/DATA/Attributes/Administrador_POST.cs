using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes
{
    public class Administrador_POST
    {
        public string Usuario { get; set; }
        public string Telefono { get; set; }
        public long? Contrasena { get; set; }
    }
}
