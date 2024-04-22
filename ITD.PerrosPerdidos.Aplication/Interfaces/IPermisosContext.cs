using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.Requests.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Aplication.Interfaces
{
    public interface IPermisosContext
    {
        ErrorData _errorData { get; set; }
        public Task<EntityResultContext> Post(RequestPermisos post);
    }
}
