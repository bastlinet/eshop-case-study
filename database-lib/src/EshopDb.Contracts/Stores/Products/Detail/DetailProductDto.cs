namespace EshopDb.Contracts.Stores.Products
{
    /// <summary>
    /// Dto object for returning one product from stores
    /// </summary>
    public class DetailProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
