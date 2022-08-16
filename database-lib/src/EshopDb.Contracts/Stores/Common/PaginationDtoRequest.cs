namespace EshopDb.Contracts.Stores.Common
{
    /// <summary>
    /// Standard dto request with pagination
    /// </summary>
    public class PaginationDtoRequest
    {
        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 10;
    }
}
