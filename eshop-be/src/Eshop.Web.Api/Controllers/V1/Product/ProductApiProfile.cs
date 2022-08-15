using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.List;

namespace Eshop.Web.Api.Controllers.V1.Product;

public class ProductApiProfile : Profile
{
    public ProductApiProfile()
    {
        CreateMap<ListProductRequest, ListProductQuery>();
        CreateMap<ListProductModel, ListProductsResponse>();
        CreateMap<ListProductItemModel, ListProductResponse>();
    }
}
