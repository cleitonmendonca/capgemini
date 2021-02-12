using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateImportationCommandValidator : AbstractValidator<CreateImportationCommand>
    {
        public CreateImportationCommandValidator()
        {
            RuleFor(im => im.LessDeliveredDate).NotNull()
                .WithMessage("A menor data de entrega do produto dever ser informada!");
        }
    }
}