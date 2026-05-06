using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required")
                .Length(3, 200).WithMessage("Name must be between 3 and 200 characters");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Product slug is required")
                .Matches(@"^[a-z0-9-]+$").WithMessage("Slug format is invalid");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MinimumLength(4).WithMessage("Description must be at least 4 characters");

            RuleFor(x => x.Price)
              .Cascade(CascadeMode.Stop) // توقف عند أول خطأ في هذا الحقل
              .NotEmpty().WithMessage("Price is required")
              .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative");
        }
    }
}
