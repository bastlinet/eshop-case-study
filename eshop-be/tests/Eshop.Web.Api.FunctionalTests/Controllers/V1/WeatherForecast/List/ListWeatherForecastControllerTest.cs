using AutoFixture;
using Eshop.Web.Api.Controllers.V1.WeatherForecast;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.WeatherForecast;

public partial class WeatherForecastControllerTest
{
    [Fact]
    public async Task List_Should_ReturnValues()
    {
        // arrange
        var fixture = new Fixture();
        var request = fixture.Create<ListWeatherForecastRequest>();

        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await _client.PostAsync("/api/v1/weatherforcast", data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        _output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonConvert.DeserializeObject<ListWeatherForecastsResponse>(content);
        response.Should().NotBeNull();
        response.Items.Should().NotBeNull();
    }
}