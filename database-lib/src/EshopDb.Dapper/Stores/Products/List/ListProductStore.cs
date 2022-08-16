using Database.Common.Attributes;
using EshopDb.Contracts.Stores.Products;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Dapper.Stores.Products
{
    public partial class ProductStore : IProductStore
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [StoredProcedure("sp_GetProducts")]
        public async Task<IReadOnlyList<ListProductDto>> List(ListProductInputModel input, CancellationToken cancellationToken)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));
            var result = await GetReadOnlyList<ListProductDto, ListProductInputModel>(this.ProcedureName(), input, cancellationToken);
            return result;
        }
    }
}