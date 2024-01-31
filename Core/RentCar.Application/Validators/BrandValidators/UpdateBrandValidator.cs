using FluentValidation;
using RentCar.Application.Features.CQRS.Commands.BrandCommands;

namespace RentCar.Application.Validators.BrandValidators
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Lütfen en az iki bırakmayınız");
        }
    }
}
