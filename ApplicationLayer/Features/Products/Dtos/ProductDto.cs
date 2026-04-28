using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
