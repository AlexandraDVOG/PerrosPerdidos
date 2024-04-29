﻿using ITD.PerrosPerdidos.Application.Interfaces.Presenters;
using ITD.PerrosPerdidos.Domain.DTO.DATA;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;


namespace ITD.PerrosPerdidos.Application.Interfaces
{
    public class AdministradorLogic : IAdministradorPresenter
    {
        public List<string> _error { get; set; }
        private readonly IAdministradorRepositoryContext _administradorRepository;

        public AdministradorLogic(IAdministradorRepositoryContext administradorRepository)
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
            var result = await _administradorRepository.administradorContext.Get(usuario);

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


