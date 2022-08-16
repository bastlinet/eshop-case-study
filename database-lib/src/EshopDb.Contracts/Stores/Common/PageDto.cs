using System.Collections.Generic;

namespace EshopDb.Contracts.Stores.Common
{
    public class PageDto<T> : PaginationDtoRequest
    {
        public IReadOnlyList<T> Items { get; set; }

        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }
    }
}
