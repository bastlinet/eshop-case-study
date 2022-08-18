using EshopDb.Common;
using EshopDb.Contracts.Stores.Products;
using EshopDb.Dapper.IntegrationTests.Fixtures;
using EshopDb.Dapper.Stores.Products;

namespace EshopDb.Dapper.IntegrationTests.Stores.Products
{
    public partial class ProductStoreTest : EshopDbFixture
    {
        private readonly IProductStore sut;

        public ProductStoreTest()
        {
            //// TODO make it better!
            //var dbContext = new DatabaseContextOption
            //{
            //    ConnectionString = "Data Source=.; Initial Catalog=EshopDevDb; Trusted_Connection=No; Integrated Security=True"
            //};

            this.sut = new ProductStore(this.DbContext);
        }
    }
}
