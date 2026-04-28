using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Commands
{
    public record CreateProductCommand(
        string Name,
        string Slug,
        decimal Price,
        string Description,
        int StockQuantity,
        string? SKU
    ) : IRequest<Guid>;
}
