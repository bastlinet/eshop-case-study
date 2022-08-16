using EshopDb.Contracts.Stores.Common;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Contracts.Stores.Products
{
    public partial interface IProductStore
    {
        /// <summary>
        /// Return full filtered list of product
        /// </summary>
        /// <param name="input">request model</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>readonly list of products</returns>
        Task<PageDto<FilteredListProductDto>> FilteredList(FilteredListProductDtoRequest input, CancellationToken cancellationToken);
    }
}
