using Dapper;
using SophosPruebaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Repository.Implementation
{
    public class VentaRepository : IVentaRepository
    {
        #region [ Properties ]

        public DapperContext Context { get; }

        #endregion

        #region [ Constructor ]

        public VentaRepository(DapperContext context)
        {
            Context = context;
        }

        #endregion

        #region [ Methods ]


        public async Task<int> CreateAsync(VentaModel model)
        {
            using (var connection = Context.CreateConnection())
            {
                var procedure = "[RealizarVenta]";
                var values = new { model.IdCliente, model.IdProducto, model.Cantidad };
                var results = await connection.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
                return results.Count();
            }
        }

        public async Task<IEnumerable<VentasQueryModel>> GetAsync()
        {
            var query =
                $"SELECT v.[Id], c.[nombre] as nombre_Cliente, p.[nombre] as nombre_Producto, v.[valor_Unitario],v.[Valor_Total] FROM [ventas] V INNER JOIN[Cliente] C ON C.Id = V.IdCliente INNER JOIN Producto P ON P.Id = V.IdProducto";

            using (var connection = Context.CreateConnection())
            {
                var cliente = await connection.QueryAsync<VentasQueryModel>(query);
                return cliente.ToList();
            }
        }


        #endregion
    }
}
