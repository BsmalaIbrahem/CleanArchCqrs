using DomainLayer.Common;
using DomainLayer.Exceptions;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Entities
{
    public class Product : BaseEntity<Guid>, IAuditable
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string Slug { get; private set; } = null!;
        public bool IsActive { get; private set; } = true;
        public Money Price { get; private set; }
        public int StockQuantity { get; private set; }
        public string? SKU { get; private set; }


        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get ; set ; }
        public string? UpdatedBy { get ; set ; }

        public Product(string name, string slug, Money price, string description)
        {
            ValidateName(name);
            ValidatePrice(price);
            ValidateDescription(description);

            Name = name.Trim();
            Slug = slug.Trim();
            StockQuantity = 0;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = "System";
            Price = price;
            Description = description;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Product name cannot be empty.");
        }

        private void ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Product description cannot be empty.");
        }

                private void ValidatePrice(Money price)
        {
            if (price.Amount <= 0)
                throw new DomainException("Product price must be greater than zero.");
        }

        public void SetStockQuantity(int quantity)
        {
            if (quantity < 0)
                throw new DomainException("Stock quantity cannot be negative.");

            StockQuantity = quantity;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = "System";
        }

        
        public void SetSKU(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
                throw new DomainException("SKU cannot be empty.");

            SKU = sku.Trim().ToUpper();
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = "System";
        }

    }
}
