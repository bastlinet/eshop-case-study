using Dapper;
using EshopDb.Common;
using EshopDb.Contracts.Stores.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Dapper.Stores.Common
{
    /// <summary>
    /// Standard dapper store class with common methods
    /// </summary>
    public abstract class DapperStore
    {
        public DatabaseContextOption DbContext { get; private set; }

        public DapperStore(DatabaseContextOption dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<OEntity> GetRecord<OEntity, IEntity>(string proc, IEntity input, CancellationToken cancellationToken)
            where OEntity : class
            where IEntity : class
        {
            var result = await QueryCollection<OEntity, IEntity>(proc, input, cancellationToken);
            return result.FirstOrDefault();
        }

        public virtual async Task<IReadOnlyList<OEntity>> GetReadOnlyList<OEntity, IEntity>(string proc, IEntity input, CancellationToken cancellationToken)
            where OEntity : class
            where IEntity : class
        {
            var result = await QueryCollection<OEntity, IEntity>(proc, input, cancellationToken);
            return result.ToList();
        }

        protected virtual async Task<IEnumerable<OEntity>> QueryCollection<OEntity, IEntity>(string proc, IEntity input, CancellationToken cancellationToken)
            where OEntity : class
            where IEntity : class
        {
            IEnumerable<OEntity> result = null;
            using (var conn = new SqlConnection(DbContext.ConnectionString))
            {
                var param = new DynamicParameters(input);
                result = await conn.QueryAsync<OEntity>(proc, param: param, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        protected virtual async Task<PageDto<OEntity>> QueryMultiple<OEntity, IEntity>(string proc, IEntity input, CancellationToken cancellationToken)
            where OEntity : class
            where IEntity : class
        {
            PageDto<OEntity> result = new PageDto<OEntity>();
            using (var conn = new SqlConnection(DbContext.ConnectionString))
            {
                var param = new DynamicParameters(input);
                using (var q = conn.QueryMultiple(proc, param: param, commandType: System.Data.CommandType.StoredProcedure))
                {
                    result.Items = q.Read<OEntity>().ToList();
                    result.FilteredCount = q.Read<int>().FirstOrDefault();
                    result.TotalCount = q.Read<int>().FirstOrDefault();
                }
            }

            return result;
        }
    }
}
