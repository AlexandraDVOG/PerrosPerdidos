using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;


namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    internal class MascotasPerdidasData
    {
        public int type { get; set; }
        public List<MascotasPerdidasAtributes> attributes { get; set; }
    }
}
