using ITD.PerrosPerdidos.Domain.DTO.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.PerrosPerdidos.Domain.DTO.DATA.Attributes
{
    public class ErrorResponse
    {
        public ErrorResponse _errorResponse { get; set; }
        public ErrorResponse _errors { get; set; }

        public List<ErrorData> errors;
    }
}
