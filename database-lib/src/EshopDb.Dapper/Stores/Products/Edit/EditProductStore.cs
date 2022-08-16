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
        [StoredProcedure("sp_UpdateProduct")]
        public async Task<EditProductDto> Edit(EditProductDtoRequest input, CancellationToken cancellationToken)
        {
            input = input ?? throw new ArgumentNullException(nameof(input));
            var result = await Update<EditProductDto, EditProductDtoRequest>(this.ProcedureName(), input, cancellationToken);
            return result;
        }
    }
}