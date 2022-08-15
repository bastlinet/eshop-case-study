using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Core.Contracts.Handlers.Products.V1.List
{
    public class ListProductItemModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
