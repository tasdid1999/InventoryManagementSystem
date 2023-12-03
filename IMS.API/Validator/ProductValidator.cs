using FluentValidation;
using IMS.ClientEntity.ProductRequest;

namespace IMS.API.Validator
{
    public class ProductValidator :AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name should not Empty")
                                            .NotNull().WithMessage("Name Should not Null")
                                            .MaximumLength(100).WithMessage("Name must be less then 100 character")
                                            .MinimumLength(3).WithMessage("Minimum length should be 3");
            RuleFor(product => product.BrandId).GreaterThan(0).WithMessage("Brand id must be positive");
            RuleFor(product => product.CatagoryId).GreaterThan(0).WithMessage("catagory id must be positive");

            

        }
    }
}
