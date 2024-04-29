using ITD.PerrosPerdidos.Application.Interfaces.Context;


namespace ITD.PerrosPerdidos.Application.Interfaces
{
    public interface IAdministradorRepositoryContext
    {
        public IMascotasPerdidasContext MascotasPerdidasContext { get; }
        public IAdministradorContext administradorContext { get; }
    }
}
