using Dapper;
using SophosPruebaTecnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SophosPruebaTecnica.Repository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        #region [ Properties ]

        public DapperContext Context { get; }

        #endregion

        #region [ Constructor ]

        public ProductoRepository(DapperContext context)
        {
            Context = context;
        }

        #endregion

        #region [ Methods ]


        public async Task<IEnumerable<ProductoModel>> GetAsync()
        {
            var query =
                $"select  [Id],[Nombre],[Valor_Unitario] from [Producto]";

            using (var connection = Context.CreateConnection())
            {
                var cliente = await connection.QueryAsync<ProductoModel>(query);
                return cliente.ToList();
            }
        }


        public async Task<int> CreateAsync(ProductoModel model)
        {
            var query = "INSERT INTO [dbo].[Producto] ([Nombre],[Valor_Unitario]) " +
                "VALUES(@Nombre,@Valor_Unitario)";

            using (var connection = Context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, model);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = Context.CreateConnection())
            {
                var sqlStatement = "DELETE [Producto] WHERE [Id] = @Id";
                var result = await connection.ExecuteAsync(sqlStatement, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(ProductoModel model)
        {
            var query = "UPDATE [dbo].[Producto] SET [Nombre] = @Nombre,[Valor_Unitario] = @Valor_Unitario" +
                "WHERE [Id] = @Id";

            using (var connection = Context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, model);
                return result;
            }
        }

        #endregion

    }
}
