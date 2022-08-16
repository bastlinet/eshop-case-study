using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using Eshop.Core.Contracts.Handlers.Products.V1.List;
using EshopDb.Contracts.Stores.Products;

namespace Eshop.Core.Logic.Handlers.Product
{
    /// <summary>
    /// Register mapping for weatherforcast handlers
    /// </summary>
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // list
            CreateMap<ListProductQuery, ListProductDtoRequest>();
            CreateMap<ListProductDto, ListProductItemModel>();

            // detail
            CreateMap<DetailProductQuery, DetailProductDtoRequest>();
            CreateMap<DetailProductDto, DetailProductModel>();
        }
    }
}
