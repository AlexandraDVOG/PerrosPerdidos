using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes.RequestData
{
    public class RequestAdministradorData
    {
        public int code { get; set; }
        public string? result { get; set; }
        public string usuario { get; set; }
        public int? celular { get; set; }
        public string contraseña { get; set; }
    }
}
