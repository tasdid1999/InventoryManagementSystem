using FluentValidation;
using IMS.ClientEntity.ProductRequest;

namespace IMS.API.Validator
{
    public class ProductBrandValidator : AbstractValidator<ProductBrandRequest>
    {
        public ProductBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("required field")
                                .NotNull().WithMessage("Required Field")
                                .MinimumLength(3).WithMessage("minimum length should be 3")
                                .MaximumLength(100).WithMessage("Maxmimum length should be 100");


        }
    }
}
