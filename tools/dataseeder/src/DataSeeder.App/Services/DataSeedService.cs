using Bogus;
using Dapper.Bulk;
using DataSeeder.App.Models;
using EshopDb.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace DataSeeder.App.Services
{
    public class DataSeedService : IHostedService
    {
        private readonly ILogger<DataSeedService> logger;
        private readonly DatabaseContextOption dbContext;

        public DataSeedService(ILogger<DataSeedService> logger, DatabaseContextOption dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting seeder!");

            try
            {

                var products = FakeProducts(1000);
                await ProductBulkInsert(products);

                logger.LogInformation("Seeding finished!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Seeding failed!");
                throw;
            }

            await Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping seeder!");
            return Task.CompletedTask;
        }

        private IEnumerable<Product> FakeProducts(int count)
        {
            var productId = 1;
            var productFaker = new Faker<Product>("cz")
                .RuleFor(o => o.Id, f => productId++)
                .RuleFor(u => u.Name, f => f.Commerce.ProductName())
                .RuleFor(u => u.Description, f => f.Commerce.ProductDescription())
                .RuleFor(u => u.ImgUri, f => f.Image.PicsumUrl())
                .RuleFor(u => u.Price, f => decimal.Parse(f.Commerce.Price()));

            return productFaker.Generate(count);
        }

        private async Task ProductBulkInsert(IEnumerable<Product> products)
        {
            using (var conn = new SqlConnection(dbContext.ConnectionString))
            {
                await conn.OpenAsync();
                await conn.BulkInsertAsync(products);
            }
        }
    }
}
