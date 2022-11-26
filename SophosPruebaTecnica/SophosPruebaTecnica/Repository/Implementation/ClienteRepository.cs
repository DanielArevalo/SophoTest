using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SophosPruebaTecnica.Model;

namespace SophosPruebaTecnica.Repository.Implementation
{
    public class ClienteRepository : IClientesRepository
    {

        #region [ Properties ]

        public DapperContext Context { get; }

        #endregion

        #region [ Constructor ]

        public ClienteRepository(DapperContext context)
        {
            Context = context;
        }

        #endregion

        #region [ Methods ]


        public async Task<IEnumerable<ClienteModel>> GetAsync()
        {
            var query =
                $"select  [Id],[Numero_Documento],[Nombre], [Apellido], [Telefono] from [Cliente]";

            using (var connection = Context.CreateConnection())
            {
                var cliente = await connection.QueryAsync<ClienteModel>(query);
                return cliente.ToList();
            }
        }


        public async Task<int> CreateAsync(ClienteModel model)
        {
            var query = "INSERT INTO [dbo].[Cliente] ([Numero_Documento],[Nombre], [Apellido], [Telefono]) " +
                "VALUES(@Numero_Documento,@Nombre,@Apellido,@Telefono)";

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
                var sqlStatement = "DELETE [Cliente] WHERE [Id] = @Id";
                var result = await connection.ExecuteAsync(sqlStatement, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(ClienteModel model)
        {
            var query = "UPDATE [dbo].[Cliente] SET  [Numero_Documento] = @Numero_Documento,[Nombre] = @Nombre, [Apellido] = @Apellido, [Telefono] = @Telefono " +
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
