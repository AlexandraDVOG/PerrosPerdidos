using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;


namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    public class UsuariosData
    {
        public int idUsuarios { get; set; }
        public List<UsuarioAtributes> attributes { get; set; }
    }
}
