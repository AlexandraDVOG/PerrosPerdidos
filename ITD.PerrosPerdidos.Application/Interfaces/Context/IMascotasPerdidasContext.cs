

namespace ITD.PerrosPerdidos.Application.Interfaces.Context
{
    public interface IMascotasPerdidasContext
    {
        Task<string> ModificarCaracteristicasPerroPerdido(int idMascota, string nuevasCaracteristicas);
        Task<string> ReportarPerroPerdido(int idUsuario, int celular, string raza, string color, string tamano, char sexo, string caracteristicas, DateTime fechaVisto, string lugarVisto, byte[] imagen);
       
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
