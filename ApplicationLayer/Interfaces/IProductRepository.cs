using ApplicationLayer.Features.Products.Dtos;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product, CancellationToken ct = default);

        Task<bool> IsNameUniqueAsync(string name, CancellationToken ct = default);
    }
}
