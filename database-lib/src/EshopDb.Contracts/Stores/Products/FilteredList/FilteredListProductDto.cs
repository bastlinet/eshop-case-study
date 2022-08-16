namespace EshopDb.Contracts.Stores.Products
{
    /// <summary>
    /// Dto object for returning product from stores
    /// </summary>
    public class FilteredListProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ImgUri { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
