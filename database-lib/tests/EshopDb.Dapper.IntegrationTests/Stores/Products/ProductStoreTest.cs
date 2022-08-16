using EshopDb.Common;
using EshopDb.Contracts.Stores.Products;
using EshopDb.Dapper.Stores.Products;

namespace EshopDb.Dapper.IntegrationTests.Stores.Products
{
    public partial class ProductStoreTest
    {
        private readonly IProductStore sut;

        public ProductStoreTest()
        {
            // TODO make it better!
            var dbContext = new DatabaseContextOption
            {
                ConnectionString = "Data Source=.; Initial Catalog=EshopDevDb; Trusted_Connection=No; Integrated Security=True"
            };

            this.sut = new ProductStore(dbContext);
        }
    }
}
