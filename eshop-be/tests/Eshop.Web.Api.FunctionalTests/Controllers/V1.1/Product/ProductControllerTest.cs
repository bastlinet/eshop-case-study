using Eshop.Web.Api.FunctionalTests.Controllers.Common;
using HashidsNet;
using Xunit.Abstractions;

namespace Eshop.Web.Api.FunctionalTests.Controllers.V1_1.Product;

public partial class ProductControllerTest : BaseControllerTest
{
    private readonly IHashids hashids;

    public ProductControllerTest(CustomWebApplicationFactory<WebApiMarker> factory, ITestOutputHelper testOutputHelper)
        : base(factory, testOutputHelper)
    {
        this.hashids = factory.Services.GetService(typeof(IHashids)) as IHashids;
    }
}
