using Microsoft.AspNetCore.Mvc;
using SophosPruebaTecnica.Model;
using SophosPruebaTecnica.Repository;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        #region [ Properties ]

        public IVentaRepository VentaRepository { get; }

        #endregion

        #region [ Constructor ]

        public VentaController(IVentaRepository ventaRepository)
        {
            VentaRepository = ventaRepository;
        }

        #endregion

        #region [ Methods ]

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VentaModel model)
        {
            return Ok(await VentaRepository.CreateAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var clientes = await VentaRepository.GetAsync();
            return Ok(clientes);
        }

        #endregion


    }
}
