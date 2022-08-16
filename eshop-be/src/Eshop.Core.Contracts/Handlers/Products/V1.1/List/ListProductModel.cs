using Eshop.Core.Contracts.Handlers.Common;
using System.Collections.Generic;

namespace Eshop.Core.Contracts.Handlers.Products.V1_1.List
{
    public class ListProductModel
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<ListProductItemModel> Items { get; set; }
    }
}
