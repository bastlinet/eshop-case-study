using AutoMapper;
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
            CreateMap<ListProductQuery, ListProductInputModel>();
            CreateMap<ListProductDto, ListProductItemModel>();
        }
    }
}
