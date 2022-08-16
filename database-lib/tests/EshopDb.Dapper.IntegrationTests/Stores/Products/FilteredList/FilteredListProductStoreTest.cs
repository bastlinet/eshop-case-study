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
        public async Task FilteredList_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Build<FilteredListProductDtoRequest>()
                .With(x => x.Limit, 10)
                .With(x => x.Offset, 0)
                .Create();

            // Act
            var result = await sut.FilteredList(inputModel, default);

            // Assert 
            result.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.TotalCount.Should().BeGreaterThan(0);
            result.FilteredCount.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task FilteredList_ShouldThrow_ArgumentNullException()
        {
            FilteredListProductDtoRequest inputModel = null;

            await FluentActions.Invoking(() => sut
                .FilteredList(inputModel, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
