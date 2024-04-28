using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.Enums
{
    public enum StatusHttp
    {
        Success = 200,
        Created = 201,
        badRequest = 400,
        Error = 500
    }
}
