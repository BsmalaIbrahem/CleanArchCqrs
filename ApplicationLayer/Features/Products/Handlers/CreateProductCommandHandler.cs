using ApplicationLayer.Features.Products.Commands;
using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.Exceptions;
using DomainLayer.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // 1. التحقق من أن الاسم غير مكرر (Business Rule)
            if (!await _productRepository.IsNameUniqueAsync(request.Name, cancellationToken))
            {
                throw new DomainException($"A product with the name '{request.Name}' already exists.");
            }

            // 2. إنشاء الـ Product Entity (Rich Domain Model)
            var product = new Product(
                name : request.Name,
                price : new Money(request.Price),
                slug: request.Slug,
                description : request.Description
            );

            if(request.SKU != null || request.SKU != "")
                product.SetSKU(request.SKU ?? "") ;

            product.SetStockQuantity(request.StockQuantity);

            // 3. حفظ في الداتابيز
            await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }

    }
}
