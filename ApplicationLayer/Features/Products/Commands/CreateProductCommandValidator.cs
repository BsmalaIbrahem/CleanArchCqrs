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
               .NotEmpty().WithMessage("Product name is required\"")
               .MinimumLength(3).WithMessage("Product name must be at least 3 characters")
               .MaximumLength(200).WithMessage("Product name cannot exceed 200 characters")
            ;

            RuleFor(x => x.Slug)
               .NotEmpty().WithMessage("Product slug is required\"")
               .MinimumLength(3).WithMessage("Product slug must be at least 3 characters")
               .MaximumLength(200).WithMessage("Product slug cannot exceed 200 characters")
            ;

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description")
                .MinimumLength(4).WithMessage("Description Length")
           ;


            RuleFor(x => x.Price)
                 .NotEmpty().WithMessage("Product price is required\"")
                 .GreaterThan(0).WithMessage("Price must be greater than zero")
              ;

            RuleFor(x => x.StockQuantity)
                 .NotEmpty().WithMessage("quantity is required")
                 .GreaterThanOrEqualTo(0)
            ;

        }
    }
}
