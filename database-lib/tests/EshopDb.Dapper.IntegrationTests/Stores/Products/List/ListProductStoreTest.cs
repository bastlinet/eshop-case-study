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
        public async Task List_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Create<ListProductInputModel>();


            // Act
            var list = await sut.List(inputModel, default);

            // Assert 
            list.Should().NotBeNull();
        }

        [Fact]
        public async Task List_ShouldThrow_ArgumentNullException()
        {
            ListProductInputModel inputModel = null;

            await FluentActions.Invoking(() => sut
                .List(inputModel, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
