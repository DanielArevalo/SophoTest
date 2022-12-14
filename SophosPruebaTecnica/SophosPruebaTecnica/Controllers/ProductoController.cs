using Microsoft.AspNetCore.Mvc;
using SophosPruebaTecnica.Model;
using SophosPruebaTecnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        #region [ Properties ]

        public IProductoRepository ProductoRepository { get; }

        #endregion

        #region [ Constructor ]

        public ProductoController(IProductoRepository productoRepository)
        {
            ProductoRepository = productoRepository;
        }

        #endregion

        #region [ Methods ]

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var clientes = await ProductoRepository.GetAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductoModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(await ProductoRepository.CreateAsync(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return Ok(await ProductoRepository.DeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            return Ok(await ProductoRepository.UpdateAsync(model));
        }

        #endregion


    }
}
