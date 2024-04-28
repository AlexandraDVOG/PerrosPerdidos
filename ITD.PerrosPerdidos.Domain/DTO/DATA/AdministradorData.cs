using ITD.PerrosPerdidos.Domain.DTO.DATA.Atributes;


namespace ITD.PerrosPerdidos.Domain.DTO.DATA
{
    public class AdministradorData
    {
        public int type { get; set; }
        public List<AdministradorAtributes> attributes { get; set; }
    }
  
}
