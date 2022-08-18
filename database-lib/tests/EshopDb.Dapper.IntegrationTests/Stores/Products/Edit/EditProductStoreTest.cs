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
        public async Task Edit_ShouldBe_Success(int productId)
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Build<EditProductDtoRequest>()
                .With(x => x.Id, productId)
                .Create();
            

            // Act
            var result = await sut.Edit(inputModel, default);

            // Assert 
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task Edit_Should_HasZeroCount(int productId)
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Build<EditProductDtoRequest>()
                .With(x => x.Id, productId)
                .Create();


            // Act
            var result = await sut.Edit(inputModel, default);

            // Assert 
            result.Should().NotBeNull();
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task Edit_ShouldThrow_ArgumentNullException()
        {
            EditProductDtoRequest inputModel = null;

            await FluentActions.Invoking(() => sut
                .Edit(inputModel, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
