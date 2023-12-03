using FluentValidation;
using IMS.ClientEntity.shopToshopTransfer;

namespace IMS.API.Validator
{
    public class ShopToShopTransferValidator :AbstractValidator<ShopToShopTransferRequest>
    {
        public ShopToShopTransferValidator()
        {
            RuleFor(x => x.FromShopId).NotEmpty().NotNull().WithMessage("Required Property").GreaterThan(0).WithMessage("id should be greater than 0");
            RuleFor(x => x.ToShopId).NotEmpty().NotNull().WithMessage("Required Property").GreaterThan(0).WithMessage("id should be greater than 0").NotEqual(x=>x.FromShopId).WithMessage("From and To shop must be different");
            RuleForEach(x => x.Products).SetValidator(new ShopToShopTransferProductValidator());
        }
    }
}
