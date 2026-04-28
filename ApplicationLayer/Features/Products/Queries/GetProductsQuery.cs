using ApplicationLayer.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Queries
{
    public record GetProductsQuery : IRequest<List<ProductDto>>;
}
