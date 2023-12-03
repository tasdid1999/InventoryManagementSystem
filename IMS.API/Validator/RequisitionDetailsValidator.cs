using FluentValidation;
using IMS.ClientEntity.Requsition;

namespace IMS.API.Validator
{
    public class RequisitionDetailsValidator : AbstractValidator<RequsitionDetailsRequest>
    {
        public RequisitionDetailsValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("field Required")
                                     .NotNull().WithMessage("filed Required")
                                     .GreaterThan(0).WithMessage("id must be greater than 0");

            RuleFor(x => x.Price).NotEmpty().WithMessage("field Required")
                                    .NotNull().WithMessage("filed Required")
                                    .GreaterThan(0).WithMessage("price must be greater than 0");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("field Required")
                                    .NotNull().WithMessage("filed Required")
                                    .GreaterThan(0).WithMessage("quantity must be greater than 0");


        }
    }
}
