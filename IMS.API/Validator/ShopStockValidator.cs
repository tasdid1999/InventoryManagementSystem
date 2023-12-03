using FluentValidation;
using IMS.ClientEntity.shopStock;

namespace IMS.API.Validator
{
    public class ShopStockValidator : AbstractValidator<ShopStockRequest>
    {
        public ShopStockValidator()
        {
            RuleFor(x => x.ShopId).NotEmpty().WithMessage("required field")
                                  .NotNull().WithMessage("filed Required")
                                  .GreaterThan(0).WithMessage("id must be non negative");
            RuleForEach(x => x.Products).SetValidator(new ShopStockProductRequestValidator());
                
        }
    }
}
