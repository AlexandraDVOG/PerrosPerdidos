using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.POCOS.Context
{
    public class UsuarioContext
    {
        public string usuario { get; set; }
        public int? numero_celular { get; set; }
        public string contraseña { get; set; }
    }
}
