using Eshop.Web.Api.Controllers.V1_1.Product;
using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.Product;

public partial class ProductControllerTest
{
    [Fact]
    public async Task List_ShouldReturn_Products()
    {
        // arrange
        //var fixture = new Fixture();
        //var request = fixture.Create<ListProductRequest>();

        //var json = JsonConvert.SerializeObject(request);
        //var data = new StringContent(json, Encoding.UTF8, "application/json");

        var limit = 1;

        // act
        var httpResponse = await _client.GetAsync($"/api/v1.1/product?limit={limit}");

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        _output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonConvert.DeserializeObject<ListProductsResponse>(content);
        response.Should().NotBeNull();
        response.Items.Should().NotBeNull();

        response.Items.Count().Should().Be(limit);
    }
}