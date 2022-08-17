using Eshop.Web.Api.Controllers.V1.Product;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.Product;

public partial class ProductControllerTest
{
    [Fact]
    public async Task List_ShouldReturn_Products()
    {
        // TODO RUN SEEDS!
        // arrange
        var url = $"/api/v1/product";

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
    }

    public class ListProductsResponseHashed: ListProductsResponse
    {
        public new IEnumerable<ListProductResponseHashed> Items { get; set; }
    }

    public class ListProductResponseHashed : ListProductResponse
    {
        public new string Id { get; set; }
    }
}