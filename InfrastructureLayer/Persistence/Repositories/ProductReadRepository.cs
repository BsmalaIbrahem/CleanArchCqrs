using ApplicationLayer.Features.Products.Dtos;
using ApplicationLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Persistence.Repositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly AppDbContext _context;

        public ProductReadRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Products
             .Where(p => p.IsActive)
             .Select(p => new ProductDto
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price.Amount,
                 Description = p.Description,
                 SKU = p.SKU,
                 IsActive = p.IsActive,
                 CreatedAt = p.CreatedAt
             })
             .ToListAsync(ct);
        }
    }
}
