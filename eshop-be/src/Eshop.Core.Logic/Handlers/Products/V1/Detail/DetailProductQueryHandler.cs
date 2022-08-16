using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Detail;
using EshopDb.Contracts.Stores.Products;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Core.Logic.Handlers.Products.V1.Detail
{
    public class DetailProductQueryHandler : IRequestHandler<DetailProductQuery, DetailProductModel>
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;

        public DetailProductQueryHandler(IProductStore productStore, IMapper mapper)
        {
            this.productStore = productStore;
            this.mapper = mapper;
        }

        public async Task<DetailProductModel> Handle(DetailProductQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            DetailProductModel result = null;

            var product = await productStore.Detail(mapper.Map<DetailProductDtoRequest>(request), cancellationToken);
            result = mapper.Map<DetailProductModel>(product);

            return await Task.FromResult(result);
        }
    }
}
