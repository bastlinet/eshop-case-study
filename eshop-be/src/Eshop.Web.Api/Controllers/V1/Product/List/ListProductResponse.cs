using System;

namespace Eshop.Web.Api.Controllers.V1.Product;

public class ListProductResponse
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string ImgUri { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }
}