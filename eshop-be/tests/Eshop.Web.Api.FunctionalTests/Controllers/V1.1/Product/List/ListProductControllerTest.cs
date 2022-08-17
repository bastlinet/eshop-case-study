using Eshop.Web.Api.Controllers.V1_1.Product;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.Product;

public partial class ProductControllerTest
{
    [Theory]
    [InlineData(10, 0)]
    [InlineData(10, 10)]
    [InlineData(100, 0)]
    public async Task List_ShouldReturn_Products(int limit, int offset)
    {
        // arrange
        var url = $"/api/v1.1/product?limit={limit}&offset={offset}";

        // act
        var httpResponse = await client.GetAsync(url);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonSerializer.Deserialize<ListProductsResponseHashed>(content, jsonOptions);
        response.Should().NotBeNull();
        response.Items.Should().NotBeNull();

        response.Items.Count().Should().Be(limit);
    }

    public class ListProductsResponseHashed : ListProductsResponse
    {
        public new IEnumerable<ListProductResponseHashed> Items { get; set; }
    }

    public class ListProductResponseHashed : ListProductResponse
    {
        public new string Id { get; set; }
    }
}