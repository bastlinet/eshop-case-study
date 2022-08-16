using AutoFixture;
using EshopDb.Contracts.Stores.Products;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EshopDb.Dapper.IntegrationTests.Stores.Products
{
    public partial class ProductStoreTest
    {
        [Fact]
        public async Task Detail_ShouldBe_Success()
        {
            // TODO SEED DATA!
            int productId = 1;
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Build<DetailProductDtoRequest>()
                .With(x => x.Id, productId)
                .Create();
            

            // Act
            var list = await sut.Detail(inputModel, default);

            // Assert 
            list.Should().NotBeNull();
        }

        [Fact]
        public async Task Detail_ShouldThrow_ArgumentNullException()
        {
            DetailProductDtoRequest inputModel = null;

            await FluentActions.Invoking(() => sut
                .Detail(inputModel, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
