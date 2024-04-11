using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    public class AdministradorData
    {
        public int type { get; set; }
        public List<AdministradorAtributes> attributes { get; set; }
    }
  
}
