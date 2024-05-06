using CarDealership.Domain.Constants;
using CarDealership.Domain.Models;
using FluentValidation;

namespace CarDealership.Application.Validators
{
    public class CarModelValidator : AbstractValidator<CarModel>
    {
        public CarModelValidator()
        {
            RuleFor(car => car.Name)
                .NotEmpty()
                .WithMessage("The machine name should not be empty")
                .MaximumLength(CarModelConstants.MAX_NAME_LENGTH)
                .WithMessage($"The machine name must not exceed {CarModelConstants.MAX_NAME_LENGTH}");

            RuleFor(car => car.Description)
                .MaximumLength(CarModelConstants.MAX_DESCRIPTION_LENGTH)
                .WithMessage($"The description of the machine must not exceed {CarModelConstants.MAX_DESCRIPTION_LENGTH}");

            RuleFor(car => car.Year)
                .GreaterThanOrEqualTo(CarModelConstants.MIN_YEAR)
                .WithMessage($"The year of manufacture of the car must be greater than or equal to {CarModelConstants.MIN_YEAR}")
                .LessThanOrEqualTo(CarModelConstants.MAX_YEAR)
                .WithMessage($"The year of manufacture of the car must be less than or equal to {CarModelConstants.MAX_YEAR}");

            RuleFor(car => car.Power)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The power of the machine must be greater than or equal to 0")
                .LessThanOrEqualTo(CarModelConstants.MAX_POWER)
                .WithMessage($"The power of the machine must not exceed {CarModelConstants.MAX_POWER}");

            RuleFor(car => car.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The price of the car must be greater than or equal to 0")
                .LessThanOrEqualTo(CarModelConstants.MAX_PRICE)
                .WithMessage($"The price of the car should not exceed {CarModelConstants.MAX_PRICE}");
        }
    }
}
