using DomainLayer.Entities;
using DomainLayer.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Slug)
                .IsRequired()
                ;

            builder.HasIndex(p => p.Slug)      // بنحدد العمود اللي عايزينه Unique
               .IsUnique();

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.Price)
                   .HasConversion(
                       p => p.Amount,                    // من Value Object للـ DB
                       amount => new Money(amount))      // من الـ DB للـ Value Object
                   .HasPrecision(18, 2);                 // مهم للـ Money

            builder.Property(p => p.IsActive)
                   .IsRequired();

            // Audit Fields
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(p => p.UpdatedAt);
            builder.Property(p => p.UpdatedBy).HasMaxLength(100);

            // Unique Index على الاسم (مهم جدًا للـ Uniqueness)
            builder.HasIndex(p => p.Name)
                   .IsUnique();

            // Global Query Filter (اختياري - عشان يجيب الـ Active فقط)
            // builder.HasQueryFilter(p => p.IsActive);
        }
    }
}
