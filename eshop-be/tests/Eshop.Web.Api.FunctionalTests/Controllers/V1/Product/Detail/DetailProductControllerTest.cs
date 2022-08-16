using Eshop.Web.Api.Controllers.V1.Product;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.Product;

public partial class ProductControllerTest
{
    [Fact]
    public async Task Detail_ShouldReturn_Product()
    {
        // TODO RUN SEEDS!
        // arrange
        // act
        var httpResponse = await _client.GetAsync("/api/v1/product/1");

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        _output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonConvert.DeserializeObject<DetailProductResponse>(content);
        response.Should().NotBeNull();
    }

    [Fact]
    public async Task Detail_ShouldReturn_NoContent()
    {
        // arrange

        // act
        var httpResponse = await _client.GetAsync("/api/v1/product/-1");

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}