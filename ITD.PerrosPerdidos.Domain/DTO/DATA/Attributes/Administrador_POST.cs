using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes
{
    public class Administrador_POST
    {
        public string usuario { get; set; }
        public string celular { get; set; }
        public long? contrasena { get; set; }
    }
}
