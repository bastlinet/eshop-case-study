namespace EshopDb.Contracts.Stores.Products
{
    /// <summary>
    /// Request model for editing product
    /// </summary>
    public class EditProductDtoRequest
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}
