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
    [Theory]
    [InlineData(10, 10)]
    public async Task List_ShouldReturn_Products(int limit, int offset)
    {
        // arrange
        var url = $"/api/v1.1/product?limit={limit}&offset={offset}";

        // act
        var httpResponse = await _client.GetAsync(url);

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