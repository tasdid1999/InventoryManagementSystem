using FluentValidation;
using IMS.ClientEntity.ProductRequest;
using IMS.Entity.Domain;

namespace IMS.API.Validator
{
    public class ProductCatagoryValidator :AbstractValidator<ProductCatagoryRequest>
    {
        public ProductCatagoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("required field")
                               .NotNull().WithMessage("Required Field")
                               .MinimumLength(3).WithMessage("minimum length should be 3")
                               .MaximumLength(100).WithMessage("Maxmimum length should be 100");
        }
    }
}
