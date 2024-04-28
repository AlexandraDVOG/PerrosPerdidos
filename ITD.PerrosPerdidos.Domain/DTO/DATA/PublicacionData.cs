using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;


namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    public class PublicacionData
    {
        public int idPublicacion { get; set; }
        public List<PublicacionAtributes> attributes { get; set; }
    }
}
