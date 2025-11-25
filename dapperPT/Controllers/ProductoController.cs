using dapperPT.Datos;
using Microsoft.AspNetCore.Mvc;

namespace dapperPT.Controllers
{

    [ApiController]
    [Route("api/productos")]
    public class ProductoController
    {
        private readonly TiendaDatos tiendaDatos;
        private readonly ILogger<ProductoController> logger;
        public ProductoController(TiendaDatos tiendaDatos, ILogger<ProductoController> logger)
        {
            this.tiendaDatos = tiendaDatos;
            this.logger = logger;
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var productos = await tiendaDatos.GetAllProducts();
                return new OkObjectResult(productos);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los productos");
                return new StatusCodeResult(500);
            }
        }
    }
}
