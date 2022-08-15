using AutoFixture;
using Eshop.Core.Contracts.Providers.WeatherForecast;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Core.Logic.UnitTests.Providers.WeatherForecast
{
    public partial class WeatherForecastProviderTest
    {
        [Fact]
        public async Task List_ShouldBe_Success()
        {
            // Arrange
            var fixture = new Fixture();
            var inputModel = fixture.Create<ListWeatherForecastInputModel>();


            // Act
            var list = await sut.List(inputModel);

            // Assert 
            list.Should().NotBeNull();
            list.Count().Should().Be(5);
        }

        [Fact]
        public async Task List_ShouldThrow_ArgumentNullException()
        {
            ListWeatherForecastInputModel inputModel = null;

            await FluentActions.Invoking(() => sut
                .List(inputModel))
                .Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
