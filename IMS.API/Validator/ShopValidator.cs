using FluentValidation;
using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.shop;

namespace IMS.API.Validator
{
    public class ShopValidator : AbstractValidator<ShopRequest>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.Name).NotEmpty().WithMessage("Name should not Empty")
                                            .NotNull().WithMessage("Name Should not Null")
                                            .MaximumLength(100).WithMessage("Name must be less then 100 character")
                                            .MinimumLength(3).WithMessage("Minimum length should be 3");

           RuleFor(shop => shop.Address).NotEmpty().WithMessage("Name should not Empty")
                                            .NotNull().WithMessage("Name Should not Null")
                                            .MaximumLength(100).WithMessage("Name must be less then 100 character")
                                            .MinimumLength(3).WithMessage("Minimum length should be 3");

        }
    }
}
