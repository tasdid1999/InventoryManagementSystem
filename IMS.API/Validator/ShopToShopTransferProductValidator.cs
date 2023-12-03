using FluentValidation;
using IMS.ClientEntity.shopToshopTransfer;

namespace IMS.API.Validator
{
    public class ShopToShopTransferProductValidator :AbstractValidator<ShopToShopProductRequest>
    {
        public ShopToShopTransferProductValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Required field").GreaterThan(0).WithMessage("id greater than 0");

            RuleFor(x => x.Quantity).NotEmpty().NotNull().WithMessage("Required Property");
        }
    }
}
