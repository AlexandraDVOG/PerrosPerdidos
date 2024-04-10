using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITD.PerrosPerdidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasPerdidasControllers : ControllerBase
    {
        private readonly List<string> _comentarios;

        public MascotasPerdidasControllers()
        {
            // Inicializamos una lista de comentarios como ejemplo
            _comentarios = new List<string>
            {
                "Comentario 1",
                "Comentario 2",
                "Comentario 3"
            };
        }

        // GET: api/Comentarios
        [HttpGet]
        public ActionResult<IMascotasPerdidasPresenter<string>> Get()
        {
            return Ok(_mascotasPerdidas);
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= _mascotasPerdidas.Count)
            {
                return NotFound();
            }

            return Ok(_mascotasPerdidas[id]);
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _mascotasPerdidas.Count)
            {
                return NotFound();
            }

            _mascotasPerdidas.RemoveAt(id);
            return NoContent();
        }
    }
}

