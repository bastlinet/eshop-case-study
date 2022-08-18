using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using Eshop.Core.Contracts.Handlers.Products.V1.Edit;
using Eshop.Core.Contracts.Handlers.Products.V1.List;
using EshopDb.Contracts.Stores.Products;
using System.Collections.Generic;

namespace Eshop.Core.Logic.Handlers.Products.V1
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
            CreateMap<IReadOnlyList<ListProductDto>, ListProductModel>()
                .ForMember(x => x.Items, x => x.MapFrom(y => y));

            // detail
            CreateMap<DetailProductQuery, DetailProductDtoRequest>();
            CreateMap<DetailProductDto, DetailProductModel>();

            // edit
            CreateMap<EditProductCommand, EditProductDtoRequest>();
            CreateMap<EditProductDto, EditProductModel>();
        }
    }
}
