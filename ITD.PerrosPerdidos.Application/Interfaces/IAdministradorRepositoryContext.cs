using ITD.PerrosPerdidos.Application.Interfaces.Context;
using ITD.PerrosPerdidos.Application.Interfaces.Mapping;


namespace ITD.PerrosPerdidos.Application.Interfaces
{
    public interface IAdministradorRepositoryContext
    {
        //public IMascotasPerdidasContext MascotasPerdidasContext { get; }
        //public IAdministradorPresenter AdministradorLogic{ get; }

        public IAdministradorContext AdministradorPresenter { get; }
    }
}
