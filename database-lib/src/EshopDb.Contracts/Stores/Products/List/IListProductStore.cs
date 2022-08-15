using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Contracts.Stores.Products
{
    public partial interface IProductStore
    {
        Task<IReadOnlyList<ListProductDto>> List(ListProductInputModel input, CancellationToken cancellationToken);
    }
}
