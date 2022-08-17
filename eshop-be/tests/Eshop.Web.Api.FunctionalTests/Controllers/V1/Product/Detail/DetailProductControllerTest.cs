using Eshop.Web.Api.Controllers.V1.Product;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.Product;

public partial class ProductControllerTest
{
    [Theory]
    [InlineData(1)]
    public async Task Detail_ShouldReturn_Product(long productId)
    {
        // TODO RUN SEEDS!
        // arrange
        var productHash = hashids.EncodeLong(productId);
        var url = $"/api/v1/product/{productHash}";

        // act
        var httpResponse = await client.GetAsync(url);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await httpResponse.Content.ReadAsStringAsync();

        output.WriteLine($"Content: {content}");
        content.Should().NotBeNull();

        var response = JsonSerializer.Deserialize<DetailProductResponseHashed>(content, jsonOptions);
        response.Should().NotBeNull();
        response.Id.Should().Be(productHash);
    }

    [Theory]
    [InlineData(0)]
    public async Task Detail_ShouldReturn_NoContent(long productId)
    {
        // arrange
        var productHash = hashids.EncodeLong(productId);
        var url = $"/api/v1/product/{productHash}";

        // act
        var httpResponse = await client.GetAsync(url);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    public class DetailProductResponseHashed : DetailProductResponse
    {
        public new string Id { get; set; }
    }
}