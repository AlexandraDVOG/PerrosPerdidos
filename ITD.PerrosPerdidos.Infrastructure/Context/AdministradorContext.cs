﻿using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;
using ITD.PerrosPerdidos.Domain.DTO.Requests;
using ITD.PerrosPerdidos.Domain.POCOS.Context;
using ITD.PerrosPerdidos.Infrestructura.Services;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class AdministradorContext : IAdministradorPresenter//*: IAdministradorContext
    {
        private readonly BdContext _bdContext;
        public AdministradorContext(BdContext bdContext) { _bdContext = bdContext; }

    }
}
