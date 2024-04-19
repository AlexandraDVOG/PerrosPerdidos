using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITD.PerrosPerdidos.API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  [Consumes("application/json")]
  
  [ProducesResponseType(typeof(PermisosResponse),(int)StatusHttp.badRequest)]
  
  public class PermisosController : ControllerBase
  {
    private readonly IPermisosPresenter _permisosPresenter;
    public class PermisosController(IPermisosPresenter permisosPresenter)
    {  
      _permisosPresenter = permisosPresenter; 
    }
    [HttpPost]
    [ProducesResponseType(typeof(PermisosResponse),(int)StatusHttp.created)]

    public async Task<IActionResult>Post(RequestPermisos post)
    {
       var result = await _permisosPresenter.Post(post);
       if (result == null)
         return BadRequest(_permisosPresenter._errorResponse);
    }
  }
}
