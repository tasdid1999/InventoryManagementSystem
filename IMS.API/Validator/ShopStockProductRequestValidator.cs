using FluentValidation;
using IMS.ClientEntity.shopStock;

namespace IMS.API.Validator
{
    public class ShopStockProductRequestValidator : AbstractValidator<ShopStockProductRequest>
    {
        public ShopStockProductRequestValidator()
        {
           
                RuleFor(x => x.ProductId).NotEmpty().NotNull().WithMessage("field required").GreaterThan(0).WithMessage("id must be non negative");
                RuleFor(x => x.RackId).NotEmpty().NotNull().WithMessage("field required").GreaterThan(0).WithMessage("id must be non negative");
                RuleFor(x => x.RowId).NotEmpty().NotNull().WithMessage("field required").GreaterThan(0).WithMessage("id must be non negative");
                RuleFor(x => x.BinId).NotEmpty().NotNull().WithMessage("field required").GreaterThan(0).WithMessage("id must be non negative");
                RuleFor(x => x.Quantity).NotEmpty().NotNull().WithMessage("field required").GreaterThan(0).WithMessage("must greater than 0");


        }
    }
}
