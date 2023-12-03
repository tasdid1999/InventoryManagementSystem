using FluentValidation;
using IMS.ClientEntity.purchase;

namespace IMS.API.Validator
{
    public class PurchaseValidator : AbstractValidator<PurchaseRequest>
    {
        public PurchaseValidator()
        {
            RuleFor(purchase => purchase.ShopId).NotEmpty().WithMessage("Required Field ")
                                                .NotNull().WithMessage("Required Field")
                                                .GreaterThan(0).WithMessage("Id must Be Greater Than Zero");

            RuleFor(purchase => purchase.PurchaseDate).NotEmpty().WithMessage("required field")
                                                      .NotNull().WithMessage("required Field")
                                                      .LessThanOrEqualTo(DateTime.Now)
                                                      .WithMessage("time must be equal or less then current time");

        

            RuleForEach(purchase => purchase.PurchasedProducts).SetValidator(new PurchasedProductValidator());
        }
    }
}
