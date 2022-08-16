using MediatR;

namespace Eshop.Core.Contracts.Handlers.Products.V1_1.List
{
    public class ListProductQuery : IRequest<ListProductModel>
    {
        public int Limit { get; set; }

        public int Offset { get; set; }
    }
}
