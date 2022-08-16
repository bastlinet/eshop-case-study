using AutoMapper;
using Core.ApiPipeline.Responses.V1;
using Eshop.Core.Contracts.Handlers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1_1.List;

namespace Eshop.Web.Api.Controllers.V1_1.Product;

/// <summary>
/// Automapper product API profile for custom mapping of  Products's objects (v1.1) 
/// </summary>
public class ProductApiProfile : Profile
{
    public ProductApiProfile()
    {
        // list
        CreateMap<ListProductRequest, ListProductQuery>();
        CreateMap<ListProductModel, ListProductsResponse>();
        CreateMap<ListProductItemModel, ListProductResponse>();
        CreateMap<PaginationMetadata, PaginationResponse>();

        CreateMap<ListProductModel, ListProductsResponse>()
               .ForMember(x => x.Items, x => x.MapFrom(y => y.Items))
               .ForMember(x => x.Metadata, x => x.MapFrom(y => y.Metadata));
    }
}
