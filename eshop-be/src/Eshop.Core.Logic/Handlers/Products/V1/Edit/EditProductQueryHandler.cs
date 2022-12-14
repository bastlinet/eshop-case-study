using AutoMapper;
using Eshop.Core.Contracts.Handlers.Products.V1.Edit;
using EshopDb.Contracts.Stores.Products;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Core.Logic.Handlers.Products.V1.Edit
{
    public class EditProductQueryHandler : IRequestHandler<EditProductQuery, EditProductModel>
    {
        private readonly IProductStore productStore;
        private readonly IMapper mapper;

        public EditProductQueryHandler(IProductStore productStore, IMapper mapper)
        {
            this.productStore = productStore;
            this.mapper = mapper;
        }

        public async Task<EditProductModel> Handle(EditProductQuery request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var product = await productStore.Edit(mapper.Map<EditProductDtoRequest>(request), cancellationToken);
            var result = mapper.Map<EditProductModel>(product);

            return await Task.FromResult(result);
        }
    }
}
