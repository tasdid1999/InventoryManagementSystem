using FluentValidation;
using IMS.ClientEntity.Requsition;

namespace IMS.API.Validator
{
    public class RequisitionValidator : AbstractValidator<RequsitionRequest>
    {
        public RequisitionValidator()
        {
            RuleForEach(x => x.RequsitionDetails).SetValidator(new RequisitionDetailsValidator());
        }
    }
}
