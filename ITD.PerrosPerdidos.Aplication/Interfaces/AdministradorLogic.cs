using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.POCOS;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.PerrosPerdidos.Infrestuctura.Repostory.Context;

namespace ITD.PerrosPerdidos.Aplication.Interfaces
{
    public class AdministradorLogic : IAdministradorPresenter
    {
        public List<string> _error { get; set; }
        private readonly AdministradorRepostoryContext _administradorRepository;

        public AdministradorLogic(AdministradorRepostoryContext administradorRepository)
        {
            _error = new List<string>();
            _administradorRepository = administradorRepository;
        }

        public async Task<AdministradorData> Administrador_GETAsync(string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                return null;
            }
            if (usuario.Length < 5)
            {
                _error.Add("El usuario debe tener al menos 5 caracteres");
                return null;
            }
            List<AdministradorAtributes> administradorAttributes = new();
            var result = await _administradorRepository.AdministradorContext.Get(usuario);

            List<Administrador> administradores = result.ToList();
            if (administradores.Count > 0 && administradores[0].code == 200)
            {
                foreach (var admin in administradores)
                {
                    administradorAttributes.Add(new AdministradorAtributes
                    {
                        usuario = admin.usuario,
                        telefono = admin.telefono,
                        contraseña = admin.contraseña
                    });
                }
            }
            return new AdministradorData
            {
                type = "admin",
                attributes = administradorAttributes
            };
        }

        public async Task<EntityResultContext> PostAdministrador(Administrador_POST request)
        {
            var result = await _administradorRepository.AdministradorContext.Post(request);
            if (result.code == 201) { return result; }
            else
            {
                _error.Add(result.result);
                return null;
            }
        }
    }
}



