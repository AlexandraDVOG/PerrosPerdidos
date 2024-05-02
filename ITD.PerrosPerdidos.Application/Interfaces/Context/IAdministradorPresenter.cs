using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes;


namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IAdministradorPresenter
    {
    }
    public interface IAdministradorService
    {
        Task<Administrador_POST> PostAdministrador(Administrador_POST administrador);

    }
}
