using AutoFixture;
using Eshop.Web.Api.Controllers.V1.Product;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1.Product;

public partial class ProductControllerTest
{
    [Theory]
    [InlineData(1)]
    public async Task Edit_ShouldReturn_Accepted(int productId)
    {
        // TODO RUN SEEDS!
        // arrange
        var fixture = new Fixture();
        var request = fixture.Build<EditProductRequest>()
            .With(x => x.Id, productId)
            .Create();

        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await _client.PutAsync("/api/v1/product", data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.Accepted);
    }

    [Theory]
    [InlineData(-1)]
    public async Task Edit_ShouldReturn_NoContent(int productId)
    {
        // TODO RUN SEEDS!
        // arrange
        var fixture = new Fixture();
        var request = fixture.Build<EditProductRequest>()
            .With(x => x.Id, productId)
            .Create();

        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // act
        var httpResponse = await _client.PutAsync("/api/v1/product", data);

        // assert
        httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}