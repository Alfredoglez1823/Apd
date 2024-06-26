using ApdAPI.Models;
using ApdAPI.Repository;
using ApdAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApdAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepresionTestController : ControllerBase
    {
        private readonly IGenericService<DepresionTest, ApdDbContext> _productoService;

        public DepresionTestController(IGenericService<DepresionTest, ApdDbContext> productoService,
            IGenericRepository<DepresionTest, ApdDbContext> repository)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepresionTest>>> GetProductos()
        {
            var productos = await _productoService.GetAllAsync();
            if (productos != null)
                return Ok(productos);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepresionTest>> GetProducto(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<DepresionTest>> GetProductoByUser(int userId)
        {
            var producto = await _productoService.GetLatestByUserIdAsync(userId);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }


        [HttpPost]
        public async Task<ActionResult<DepresionTest>> PostProducto(DepresionTest producto)
        {
            producto.Fecha = DateTime.UtcNow;
            var createdProducto = await _productoService.CreateAsync(producto);
            return CreatedAtAction("GetProducto", new { id = createdProducto.Id }, createdProducto);
        }

        [HttpOptions]
        public IActionResult Options()
        {
            // Utiliza la política CORS definida en tu program.cs
            Response.Headers.Add("Access-Control-Allow-Origin", "_myAllowSpecificOrigins");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            // Devuelve una respuesta 200 OK para indicar que la solicitud OPTIONS fue exitosa
            return Ok();
        }
    }
}
