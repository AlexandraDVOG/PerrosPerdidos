using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class AdministradorContext :IAdministradorContext
    {
        private readonly BdContext _bdContext;
        public AdministradorContext(BdContext bdContext) { _bdContext = bdContext; }
    }
}
