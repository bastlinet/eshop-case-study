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
        // arrange
        //var fixture = new Fixture();
        //var request = fixture.Create<ListProductRequest>();

        //var json = JsonConvert.SerializeObject(request);
        //var data = new StringContent(json, Encoding.UTF8, "application/json");

        // TODO RUN SEEDS!

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
    public async Task Detail_ShouldReturn_204()
    {
        // arrange

        // act
        var httpResponse = await _client.GetAsync("/api/v1/product/-1");

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}