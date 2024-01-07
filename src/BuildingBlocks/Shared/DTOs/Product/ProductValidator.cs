using FluentValidation;

namespace Shared.DTOs.Product
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name")
                .MaximumLength(250).WithMessage("Maximum length for Product Name is 250 characters");
            RuleFor(x => x.Summary).MaximumLength(255).WithMessage("Maximum length for Product Summary is 255 characters.");
            RuleFor(x => x.No).NotEmpty().WithMessage("Please specify a No");
        }
    }
}
