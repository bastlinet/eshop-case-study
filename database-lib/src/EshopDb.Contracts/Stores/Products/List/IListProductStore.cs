using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Contracts.Stores.Products
{
    public partial interface IProductStore
    {
        /// <summary>
        /// Return full list of product
        /// </summary>
        /// <param name="input">request model</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>readonly list of products</returns>
        Task<IReadOnlyList<ListProductDto>> List(ListProductDtoRequest input, CancellationToken cancellationToken);
    }
}
