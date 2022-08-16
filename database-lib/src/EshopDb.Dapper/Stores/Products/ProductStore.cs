using EshopDb.Common;
using EshopDb.Contracts.Stores.Products;
using EshopDb.Dapper.Stores.Common;

namespace EshopDb.Dapper.Stores.Products
{
    /// <summary>
    /// Provides methods for storing and returning products
    /// </summary>
    public partial class ProductStore : DapperStore, IProductStore
    {
        public ProductStore(DatabaseContextOption databaseContext)
            : base(databaseContext)
        { }
    }
}