using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    internal class MascotasPerdidasData
    {
        public int idmascota { get; set; }
        public List<MascotasPerdidasAtributes> atributes { get; set; }
    }
}
