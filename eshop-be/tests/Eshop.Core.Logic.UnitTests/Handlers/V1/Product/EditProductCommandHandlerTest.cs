using AutoFixture;
using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Edit;
using Eshop.Core.Logic.Handlers.Products.V1;
using Eshop.Core.Logic.Handlers.Products.V1.Edit;
using EshopDb.Contracts.Stores.Products;
using FluentAssertions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Handlers.V1.Product.Edit
{
    public class EditProductCommandHandlerTest
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;
        private readonly EditProductCommandHandler sut;

        public EditProductCommandHandlerTest()
        {
            productStore = Substitute.For<IProductStore>();

            var configuration = new MapperConfiguration(config =>
                config.AddProfile<ProductProfile>());

            mapper = configuration.CreateMapper();

            sut = new EditProductCommandHandler(productStore, mapper);
        }

        [Fact]
        public async Task Handle_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            EditProductDto product = fixture.Create<EditProductDto>();

            productStore.Edit(Arg.Any<EditProductDtoRequest>(), default).Returns(Task.FromResult(product));

            // Act
            var result = await sut.Handle(new EditProductCommand(), default);

            // Assert 
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(product);
        }

        [Fact]
        public async Task Handle_ShouldThrow_ArgumentNullException()
        {
            EditProductCommand query = null;

            await FluentActions.Invoking(() => sut
                .Handle(query, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
