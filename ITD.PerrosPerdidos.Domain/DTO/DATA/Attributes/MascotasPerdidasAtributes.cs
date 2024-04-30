using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes
{
    public class MascotasPerdidasAtributes
    {
        public string raza { get; set; }
        public string color { get; set; }
        public string tamaño { get; set; }
        public char sexo { get; set; }
        public  long? celular { get; set; }
        public byte[]? Imagen { get; set; }
    }
}
