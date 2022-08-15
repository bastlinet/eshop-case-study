using System.Collections.Generic;

namespace Eshop.Core.Contracts.Handlers.Products.V1.List
{
    public class ListProductModel
    {
        public IEnumerable<ListProductItemModel> Items { get; set; }
    }
}
