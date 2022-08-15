using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.WeatherForecast;

public partial class WeatherForecastControllerTest : IClassFixture<CustomWebApplicationFactory<WebApiMarker>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public WeatherForecastControllerTest(CustomWebApplicationFactory<WebApiMarker> factory, ITestOutputHelper testOutputHelper)
    {
        _client = factory.CreateClient();
        _output = testOutputHelper;
    }
}
