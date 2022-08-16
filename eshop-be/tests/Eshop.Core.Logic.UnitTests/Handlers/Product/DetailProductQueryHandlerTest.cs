using AutoFixture;
using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using Eshop.Core.Logic.Handlers.Product;
using Eshop.Core.Logic.Handlers.Products.V1.Detail;
using EshopDb.Contracts.Stores.Products;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Handlers.Product.Detail
{
    public class DetailProductQueryHandlerTest
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;
        private readonly DetailProductQueryHandler sut;

        public DetailProductQueryHandlerTest()
        {
            productStore = Substitute.For<IProductStore>();

            var configuration = new MapperConfiguration(config =>
                config.AddProfile<ProductProfile>());

            mapper = configuration.CreateMapper();

            sut = new DetailProductQueryHandler(productStore, mapper);
        }

        [Fact]
        public async Task Handle_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            DetailProductDto product = fixture.Create<DetailProductDto>();

            productStore.Detail(Arg.Any<DetailProductDtoRequest>(), default).Returns(Task.FromResult(product));

            // Act
            var result = await sut.Handle(new DetailProductQuery(), default);

            // Assert 
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async Task Handle_ShouldThrow_ArgumentNullException()
        {
            DetailProductQuery query = null;

            await FluentActions.Invoking(() => sut
                .Handle(query, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
