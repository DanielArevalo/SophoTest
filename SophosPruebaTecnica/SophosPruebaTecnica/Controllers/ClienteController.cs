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
    public class ClienteController : ControllerBase
    {

        #region [ Properties ]

        public IClientesRepository ClientesRepository { get; }

        #endregion

        #region [ Constructor ]

        public ClienteController(IClientesRepository clientesRepository)
        {
            ClientesRepository = clientesRepository;
        }

        #endregion

        #region [ Methods ]

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var clientes = await ClientesRepository.GetAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ClienteModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(await ClientesRepository.CreateAsync(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return Ok(await ClientesRepository.DeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            return Ok(await ClientesRepository.UpdateAsync(model));
        }

        #endregion


    }


}
