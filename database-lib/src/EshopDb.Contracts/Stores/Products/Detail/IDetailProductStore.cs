using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Contracts.Stores.Products
{
    public partial interface IProductStore
    {
        /// <summary>
        /// Return one product
        /// </summary>
        /// <param name="input">request model</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>readonly list of products</returns>
        Task<DetailProductDto> Detail(DetailProductDtoRequest input, CancellationToken cancellationToken);
    }
}
