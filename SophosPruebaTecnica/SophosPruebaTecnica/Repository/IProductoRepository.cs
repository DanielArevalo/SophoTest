using SophosPruebaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ProductoModel>> GetAsync();

        Task<int> CreateAsync(ProductoModel model);

        Task<int> DeleteAsync(int id);

        Task<int> UpdateAsync(ProductoModel model);
    }
}
