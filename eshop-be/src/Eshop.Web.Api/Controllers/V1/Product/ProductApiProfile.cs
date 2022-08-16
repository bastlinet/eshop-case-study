using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using Eshop.Core.Contracts.Handlers.Products.V1.List;

namespace Eshop.Web.Api.Controllers.V1.Product;

/// <summary>
/// Automapper product API profile for custom mapping of  Products's objects (v1) 
/// </summary>
public class ProductApiProfile : Profile
{
    public ProductApiProfile()
    {
        // list
        CreateMap<ListProductRequest, ListProductQuery>();
        CreateMap<ListProductModel, ListProductsResponse>();
        CreateMap<ListProductItemModel, ListProductResponse>();

        // detail
        CreateMap<DetailProductRequest, DetailProductQuery>();
        CreateMap<DetailProductModel, DetailProductResponse>();
    }
}
