using AutoFixture;
using Eshop.Web.Api.Controllers.V1.Product;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.Product;

public partial class ProductControllerTest
{
    [Theory]
    [InlineData(1)]
    public async Task Edit_ShouldReturn_Accepted(int productId)
    {
        // arrange
        var productHash = hashids.EncodeLong(productId);
        var url = $"/api/v1/product";
        var fixture = new Fixture();
        var request = fixture.Build<EditProductRequestHashed>()
            .With(x => x.Id, productHash)
            .Create();

        var json = JsonSerializer.Serialize(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await client.PutAsync(url, data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Accepted);
    }

    [Theory]
    [InlineData(0)]
    public async Task Edit_ShouldReturn_NoContent(int productId)
    {
        // arrange
        var productHash = hashids.EncodeLong(productId);
        var url = $"/api/v1/product";
        var fixture = new Fixture();
        var request = fixture.Build<EditProductRequestHashed>()
            .With(x => x.Id, productHash)
            .Create();

        var json = JsonSerializer.Serialize(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await client.PutAsync(url, data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    public class EditProductRequestHashed : EditProductRequest
    {
        public new string Id { get; set; }
    }
}