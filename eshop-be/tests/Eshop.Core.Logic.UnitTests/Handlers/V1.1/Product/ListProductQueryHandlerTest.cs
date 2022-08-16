using AutoFixture;
using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1_1.List;
using Eshop.Core.Logic.Handlers.Products.V1_1;
using Eshop.Core.Logic.Handlers.Products.V1_1.List;
using EshopDb.Contracts.Stores.Common;
using EshopDb.Contracts.Stores.Products;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Handlers.V1_1.Product.List
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
            var filteredList = fixture.Create<PageDto<FilteredListProductDto>>();
            productStore.FilteredList(Arg.Any<FilteredListProductDtoRequest>(), default).Returns(Task.FromResult(filteredList));

            // Act
            var list = await sut.Handle(new ListProductQuery(), default);

            // Assert 
            list.Should().NotBeNull();
            list.Items.Should().NotBeNull();
            list.Items.Count().Should().Be(filteredList.Items.Count());
            list.Items.Should().BeEquivalentTo(filteredList.Items);
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
