namespace EshopDb.Contracts.Stores.Products
{
    public class ListProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
