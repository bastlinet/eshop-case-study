using EshopDb.Contracts.Stores.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EshopDb.Dapper.Stores.Products
{
    public partial class ProductStore : IProductStore
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Task<IReadOnlyList<ListProductDto>> List(ListProductInputModel input, CancellationToken cancellationToken)
        {
            var list = new List<ListProductDto>
            {
                new ListProductDto
                {
                    Id = 1,
                    Name = "Test",
                    ImgUri = "https://seznam.cz/img/1.jpg",
                    Price = 42.54m
                },
                new ListProductDto
                {
                    Id = 2,
                    Name = "Test",
                    ImgUri = "https://seznam.cz/img/2.jpg",
                    Price = 42.54m
                }
            };

            return Task.FromResult(list as IReadOnlyList<ListProductDto>);
        }
    }
}