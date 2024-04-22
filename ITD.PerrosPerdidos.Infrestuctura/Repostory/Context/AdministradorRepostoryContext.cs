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

        private static List<AdministradorAtributes> GetAdministradores()
        {
            // Crear una lista para almacenar los administradores
            List<AdministradorAtributes> administradores = new List<AdministradorAtributes>();

            // Crear y agregar un nuevo administrador a la lista
            administradores.Add(new AdministradorAtributes
            {
                usuario = "admin",
                contraseña = "password",
                telefono = 6181738095,
            });

            return administradores;
        }
    }
}
