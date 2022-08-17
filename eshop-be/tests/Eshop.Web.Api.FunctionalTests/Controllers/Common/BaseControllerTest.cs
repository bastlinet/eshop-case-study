using System.Net.Http;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;

namespace Eshop.Web.Api.FunctionalTests.Controllers.Common;

public abstract class BaseControllerTest : IClassFixture<CustomWebApplicationFactory<WebApiMarker>>
{
    protected readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    protected readonly HttpClient client;
    protected readonly ITestOutputHelper output;

    public BaseControllerTest(CustomWebApplicationFactory<WebApiMarker> factory, ITestOutputHelper testOutputHelper)
    {
        client = factory.CreateClient();
        output = testOutputHelper;
    }
}