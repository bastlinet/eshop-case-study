namespace Eshop.Core.Contracts.Handlers.Products.V1.Detail
{
    public class DetailProductModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
