using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.List;
using EshopDb.Contracts.Stores.Products;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Core.Logic.Handlers.Products.V1.List
{
    public class ListProductQueryHandler : IRequestHandler<ListProductQuery, ListProductModel>
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;

        public ListProductQueryHandler(IProductStore productStore, IMapper mapper)
        {
            this.productStore = productStore;
            this.mapper = mapper;
        }

        public async Task<ListProductModel> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var result = new ListProductModel();

            var items = await productStore.List(mapper.Map<ListProductDtoRequest>(request), cancellationToken);
            result.Items = items.Select(x => mapper.Map<ListProductItemModel>(x));

            return await Task.FromResult(result);
        }
    }
}
