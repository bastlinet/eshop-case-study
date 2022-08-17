using Eshop.Web.Api.FunctionalTests.Controllers.Common;
using Xunit.Abstractions;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.WeatherForecast;

public partial class WeatherForecastControllerTest : BaseControllerTest
{
    public WeatherForecastControllerTest(CustomWebApplicationFactory<WebApiMarker> factory, ITestOutputHelper testOutputHelper)
      : base(factory, testOutputHelper)
    {
    }
}
