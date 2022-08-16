using AutoFixture;
using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.List;
using Eshop.Core.Logic.Handlers.Product;
using Eshop.Core.Logic.Handlers.Products.V1.List;
using EshopDb.Contracts.Stores.Products;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Handlers.Product.List
{
    public class ListProductQueryHandlerTest
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;
        private readonly ListProductQueryHandler sut;

        public ListProductQueryHandlerTest()
        {
            productStore = Substitute.For<IProductStore>();

            var configuration = new MapperConfiguration(config =>
                config.AddProfile<ProductProfile>());

            mapper = configuration.CreateMapper();

            sut = new ListProductQueryHandler(productStore, mapper);
        }

        [Fact]
        public async Task Handle_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            IReadOnlyList<ListProductDto> productList = fixture.CreateMany<ListProductDto>(20).ToList();

            productStore.List(Arg.Any<ListProductInputModel>(), default).Returns(Task.FromResult(productList));

            // Act
            var list = await sut.Handle(new ListProductQuery(), default);

            // Assert 
            list.Should().NotBeNull();
            list.Items.Should().NotBeNull();
            list.Items.Count().Should().Be(productList.Count());
            list.Items.Should().BeEquivalentTo(productList);
        }

        [Fact]
        public async Task Handle_ShouldThrow_ArgumentNullException()
        {
            ListProductQuery query = null;

            await FluentActions.Invoking(() => sut
                .Handle(query, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
