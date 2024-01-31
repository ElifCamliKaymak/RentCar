using FluentValidation;
using RentCar.Application.Features.CQRS.Commands.BrandCommands;

namespace RentCar.Application.Validators.BrandValidators
{
    public class CreateBrandValidator :AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Lütfen en az iki karakter giriniz.");
        }
    }
}
