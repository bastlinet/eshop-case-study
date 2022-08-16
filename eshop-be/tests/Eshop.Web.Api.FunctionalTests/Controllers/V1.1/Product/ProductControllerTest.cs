using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.Product;

public partial class ProductControllerTest : IClassFixture<CustomWebApplicationFactory<WebApiMarker>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public ProductControllerTest(CustomWebApplicationFactory<WebApiMarker> factory, ITestOutputHelper testOutputHelper)
    {
        _client = factory.CreateClient();
        _output = testOutputHelper;
    }
}
