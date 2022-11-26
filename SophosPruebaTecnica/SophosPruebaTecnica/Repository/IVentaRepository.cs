using SophosPruebaTecnica.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Repository
{
    public interface IVentaRepository
    {
        Task<int> CreateAsync(VentaModel model);

        Task<IEnumerable<VentasQueryModel>> GetAsync();

    }
}
