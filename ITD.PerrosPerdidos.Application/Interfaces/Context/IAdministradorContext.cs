﻿
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;

namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IAdministradorContext
    {
        Task<IEnumerable<Administrador>> Get(string usuario);
        Task<EntityResultContext> Post(Administrador_POST request);
    }
    
}
