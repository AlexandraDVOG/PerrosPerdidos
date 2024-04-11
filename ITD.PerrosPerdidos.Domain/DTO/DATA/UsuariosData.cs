using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    public class UsuariosData
    {
        public int idUsuarios { get; set; }
        public List<UsuarioAtributes> atributes { get; set; }
    }
}
