using AutoMapper;
using Eshop.Core.Contracts.Handlers.Common;
using Eshop.Core.Contracts.Handlers.Products.V1_1.List;
using EshopDb.Contracts.Stores.Common;
using EshopDb.Contracts.Stores.Products;

namespace Eshop.Core.Logic.Handlers.Products.V1_1
{
    /// <summary>
    /// Register mapping for weatherforcast handlers
    /// </summary>
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // list
            CreateMap<ListProductQuery, FilteredListProductDtoRequest>();
            CreateMap<FilteredListProductDto, ListProductItemModel>();
            CreateMap<PageDto<FilteredListProductDto>, ListProductModel>()
              .ForMember(x => x.Items, x => x.MapFrom(y => y.Items))
              .ForMember(x => x.Metadata, x => x.MapFrom(y => new PaginationMetadata { FilteredCount = y.FilteredCount, TotalCount = y.TotalCount }));
        }
    }
}
