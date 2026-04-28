using ApplicationLayer.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Interfaces
{
    public interface IProductReadRepository
    {
        Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default);
    }
}
