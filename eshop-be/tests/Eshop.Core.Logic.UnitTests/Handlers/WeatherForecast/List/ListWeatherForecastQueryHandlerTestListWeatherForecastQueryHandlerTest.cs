using AutoFixture;
using AutoMapper;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;
using Eshop.Core.Contracts.Providers.WeatherForecast;
using Eshop.Core.Logic.Handlers.WeatherForecast;
using Eshop.Core.Logic.Handlers.WeatherForecast.List;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Handlers.WeatherForecast.List
{
    public class ListWeatherForecastQueryHandlerTest
    {
        private readonly IWeatherForecastProvider weatherForecastProvider;
        private readonly IMapper mapper;
        private readonly ListWeatherForecastQueryHandler sut;

        public ListWeatherForecastQueryHandlerTest()
        {
            weatherForecastProvider = Substitute.For<IWeatherForecastProvider>();

            var configuration = new MapperConfiguration(config =>
                config.AddProfile<WeatherForecastProfile>());

            mapper = configuration.CreateMapper();

            sut = new ListWeatherForecastQueryHandler(weatherForecastProvider, mapper);
        }

        [Fact]
        public async Task Handle_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            IEnumerable<ListWeatherForecastOutputModel> weatherList = fixture.CreateMany<ListWeatherForecastOutputModel>(20);

            weatherForecastProvider.List(Arg.Any<ListWeatherForecastInputModel>()).Returns(Task.FromResult(weatherList));

            // Act
            var list = await sut.Handle(new ListWeatherForecastQuery(), default);

            // Assert 
            list.Should().NotBeNull();
            list.Items.Should().NotBeNull();
            list.Items.Count().Should().Be(weatherList.Count());
            list.Items.Should().BeEquivalentTo(weatherList);
        }

        [Fact]
        public async Task Handle_ShouldThrow_ArgumentNullException()
        {
            ListWeatherForecastQuery query = null;

            await FluentActions.Invoking(() => sut
                .Handle(query, default))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
