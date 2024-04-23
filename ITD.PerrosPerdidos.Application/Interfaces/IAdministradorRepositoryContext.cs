using ITD.PerrosPerdidos.Aplication.Interfaces.Context;


namespace ITD.PerrosPerdidos.Aplication.Interfaces
{
    public interface IAdministradorRepositoryContext
    {
        public  IMascotasPerdidasContext MascotasPerdidasContext { get; }
    }
}
