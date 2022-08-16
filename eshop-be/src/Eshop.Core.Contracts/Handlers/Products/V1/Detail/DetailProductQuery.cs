using MediatR;

namespace Eshop.Core.Contracts.Handlers.Products.V1.Detail
{
    public class DetailProductQuery : IRequest<DetailProductModel>
    {
        public long Id { get; set; }
    }
}
