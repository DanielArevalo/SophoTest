using SophosPruebaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Repository
{
    public interface IClientesRepository
    {
        Task<IEnumerable<ClienteModel>> GetAsync();

        Task<int> CreateAsync(ClienteModel model);

        Task<int> DeleteAsync(int id);

        Task<int> UpdateAsync(ClienteModel model);
    }
}
