using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Infrestuctura.Repostory
{
    public class AdministradorRepostoryContext
    {
        public AdministradorRepostoryContext()
        {

        }
        public list<AdministradorAtributes> GetAdministrador()
        {
            list<AdministradorContext> administrador new();
            administrador.Add(new AdministradorContext {
             
                usuario="admin",
                contraseña = "password",
                telefono= 6181738095


            }) ;
            return administrador;
        }
    }
}
