

using ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes.RequestData;

namespace ITD.PerrosPerdidos.Infrastructure.Context
{
    public class PatchAdministradorRequest
    {
        public PatchREAdministrador data { get; set; }

        public class PatchREAdministrador
        {
            public int id { get; set; }
            public string usuario { get; set; }
            public int? celular { get; set; }
            public string contrasena { get; set; }
        }

    }
 
}
