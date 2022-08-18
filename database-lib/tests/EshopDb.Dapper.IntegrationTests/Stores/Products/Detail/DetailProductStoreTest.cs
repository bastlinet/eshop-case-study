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
        [Theory]
        [InlineData(1)]
        public async Task Detail_ShouldBe_Success(int productId)
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Build<DetailProductDtoRequest>()
                .With(x => x.Id, productId)
                .Create();
            

            // Act
            var result = await sut.Detail(inputModel, default);

            // Assert 
            result.Should().NotBeNull();
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
