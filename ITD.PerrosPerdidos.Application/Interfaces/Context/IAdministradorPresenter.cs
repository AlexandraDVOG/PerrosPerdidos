using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Application.Interfaces.Presenters
{
    public interface IAdministradorPresenter
    {
        public Task<AdministradorData> Administrador_GETAsync(string usuario);

        public List<Administrador> GetAdministrador()
        {
            List<Administrador> administrador = new List<Administrador>();

            // Aquí deberías llenar la lista mascotasPerdidas con datos de alguna fuente, como una base de datos o un servicio.

            return administrador;
        }


    }
}
