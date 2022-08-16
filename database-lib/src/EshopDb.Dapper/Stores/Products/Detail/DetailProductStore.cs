using Database.Common.Attributes;
using EshopDb.Contracts.Stores.Products;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Dapper.Stores.Products
{
    public partial class ProductStore : IProductStore
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [StoredProcedure("sp_GetProduct")]
        public async Task<DetailProductDto> Detail(DetailProductDtoRequest input, CancellationToken cancellationToken)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));
            var result = await GetRecord<DetailProductDto, DetailProductDtoRequest>(this.ProcedureName(), input, cancellationToken);
            return result;
        }
    }
}