using FluentValidation;
using IMS.ClientEntity.purchase;

namespace IMS.API.Validator
{
    public class PurchasedProductValidator : AbstractValidator<PurchasedProductRequest>
    {
        public PurchasedProductValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Required Field")
                                     .NotNull().WithMessage("Required Field")
                                     .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Required Field")
                                     .NotNull().WithMessage("Required Field")
                                     .GreaterThan(0).WithMessage("price must be greater than 0");

            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Required Field")
                                     .NotNull().WithMessage("Required Field")
                                     .GreaterThan(0).WithMessage("Quantity must be greater than 0");
           
        }
    }
}
