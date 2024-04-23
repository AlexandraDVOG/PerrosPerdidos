using ITD.PerrosPerdidos.Aplication.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Interfaces
{
    public interface IAdministradorRepositoryContext
    {
        public  IMascotasPerdidasContext MascotasPerdidasContext { get; }
    }
}
