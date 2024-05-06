using CarDealership.Domain.Constants;
using CarDealership.Domain.Models;
using FluentValidation;

namespace CarDealership.Application.Validators
{
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(OrderModelConstants.MAX_NAME_LENGTH)
                .WithMessage($"The length of the name should not exceed {OrderModelConstants.MAX_NAME_LENGTH}");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(OrderModelConstants.MAX_PHONENUMBER_LENGTH)
                .WithMessage($"The length of the phone number should not exceed {OrderModelConstants.MAX_PHONENUMBER_LENGTH}");

            RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(OrderModelConstants.MAX_MESSAGE_LENGTH)
                .WithMessage($"The length of the message should not exceed {OrderModelConstants.MAX_MESSAGE_LENGTH}");

            RuleFor(x => x.Referrer)
                .MaximumLength(OrderModelConstants.MAX_REFERRER_LENGTH)
                .WithMessage($"The length of the referring page should not exceed {OrderModelConstants.MAX_REFERRER_LENGTH}");

            RuleFor(x => x.Checked)
                .NotNull();

            RuleFor(x => x.DateCreated)
                .NotNull();
        }
    }
}
