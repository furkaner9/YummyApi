using FluentValidation;
using Ymmy.WebApi.Entities;

namespace Ymmy.WebApi.ValidationRules
{
    public class ProductValidator :AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=> x.ProductName).NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(50).WithMessage("Product name cannot exceed 50 characters.");
        }
    }
}
