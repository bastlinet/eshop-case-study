using MediatR;

namespace Eshop.Core.Contracts.Handlers.Products.V1.Edit
{
    public class EditProductCommand : IRequest<EditProductModel>
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}
