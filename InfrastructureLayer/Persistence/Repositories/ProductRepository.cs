using ApplicationLayer.Features.Products.Dtos;
using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product, CancellationToken ct = default)
        {
            await _context.Products.AddAsync(product, ct);
        }

        

        public async Task<bool> IsNameUniqueAsync(string name, CancellationToken ct = default)
        {
            return !await _context.Products
                .AnyAsync<Product>(p => p.Name.ToLower() == name.ToLower(), ct);
        }
    }
}
