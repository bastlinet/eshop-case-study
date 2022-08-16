using Database.Common.Attributes;
using EshopDb.Contracts.Stores.Common;
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
        [StoredProcedure("sp_GetFilteredProducts")]
        public async Task<PageDto<FilteredListProductDto>> FilteredList(FilteredListProductDtoRequest input, CancellationToken cancellationToken)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));

            var result = await QueryMultiple<FilteredListProductDto, FilteredListProductDtoRequest>(this.ProcedureName(), input, cancellationToken);
            return result;
        }
    }
}