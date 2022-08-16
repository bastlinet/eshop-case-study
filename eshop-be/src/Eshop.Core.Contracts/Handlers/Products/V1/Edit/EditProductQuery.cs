using MediatR;

namespace Eshop.Core.Contracts.Handlers.Products.V1.Edit
{
    public class EditProductQuery : IRequest<EditProductModel>
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}
