using Application.Commands;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(pr => pr.DeliveredOn).NotNull()
                .WithMessage("A data de entrega é obrigatória!");
            RuleFor(pr => pr.Value).NotNull().GreaterThan(0)
                .WithMessage("A valor do produto deve ser maior que 0!"); ;
            RuleFor(pr => pr.Quantity).NotNull().GreaterThan(0)
                .WithMessage("A quantidade do produto deve ser maior que 0!");
            RuleFor(pr => pr.Name).NotEmpty().MinimumLength(3).MaximumLength(50)
                .WithMessage("A descrição do produto deve ter no máximo 50 caracter!");
        }
        
    }
}