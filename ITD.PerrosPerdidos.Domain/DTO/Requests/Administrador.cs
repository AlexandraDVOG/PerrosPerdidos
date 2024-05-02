using ITD.PerrosPerdidos.Domain.DTO.DATA;
namespace ITD.PerrosPerdidos.Domain.DTO.Requests
{
    public class Administrador
    {
        public AdministradorData data { get; set; }
        public int code { get; set; }
        public string usuario { get; set; }
        public int celular { get; set; }
        public string contraseña { get; set; }

    }
}
