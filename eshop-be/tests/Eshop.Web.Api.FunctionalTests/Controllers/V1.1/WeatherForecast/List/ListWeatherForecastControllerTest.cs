using AutoFixture;
using Eshop.Web.Api.Controllers.V1_1.WeatherForecast;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.WeatherForecast;

public partial class WeatherForecastControllerTest
{
    [Fact]
    public async Task List_ShouldReturn_Weatherforecast()
    {
        // arrange
        var fixture = new Fixture();
        var request = fixture.Create<ListWeatherForecastRequest>();

        var json = JsonSerializer.Serialize(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await client.PostAsync("/api/v1/weatherforecast", data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonSerializer.Deserialize<ListWeatherForecastsResponse>(content, jsonOptions);
        response.Should().NotBeNull();
        response.Items.Should().NotBeNull();
    }
}