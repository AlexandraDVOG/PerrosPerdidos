using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Infrestructura.Presenters
{
    public class AdministradorLogic: IAdministradorpresenters
    {
        public List<string> _error { get; set; }
        private readonly IAdminsitradorPresenters _Administrador;

    }
}


