using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory.Context
{
    public class AdministradorRepostoryContext
    {
        public AdministradorRepostoryContext()
        {

        }
        public List<AdministradorAtributes> GetAdministrador()
        {
            List<AdministradorContext> Administrador new();
            Administrador.Add(new AdministradorContext)
            {

                usuario = "admin",
                contraseña = "password",
                telefono = 6181738095


            });
            return administrador;
        }
    }
}
