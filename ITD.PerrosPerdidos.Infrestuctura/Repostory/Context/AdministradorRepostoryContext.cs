using ITD.PerrosPerdidos.Aplication.Interfaces;
using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{
    public class AdministradorRepostoryContext :IAdministradorRepositoryContext
    {
        private readonly BdContext _bd;
        public AdministradorRepostoryContext(IConfiguration configuration)
        {
            _bd = new BdContext(configuration);
        }

        public IMascotasPerdidasContext MascotasPerdidasContext => new MascotasPerdidasContext(_bd);
    }
}
