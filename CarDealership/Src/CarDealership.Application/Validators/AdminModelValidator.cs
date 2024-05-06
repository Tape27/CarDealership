using CarDealership.Domain.Constants;
using CarDealership.Domain.Models;
using FluentValidation;

namespace CarDealership.Application.Validators
{
    public class AdminModelValidator : AbstractValidator<AdminModel>
    {
        public AdminModelValidator()
        {
            RuleFor(admin => admin.Login)
                .NotEmpty()
                .MaximumLength(AdminModelConstants.MAX_LOGIN_LENGTH);

            RuleFor(admin => admin.Password)
                .NotEmpty()
                .MaximumLength(AdminModelConstants.MAX_PASSWORD_LENGTH)
                .MinimumLength(AdminModelConstants.MIN_PASSWORD_LENGTH);

            RuleFor(admin => admin.FullName)
                .NotEmpty()
                .MaximumLength(AdminModelConstants.MAX_FULLNAME_LENGTH);

            RuleFor(admin => admin.Role)
                .NotEmpty()
                .MaximumLength(AdminModelConstants.MAX_ROLE_LENGTH);

            RuleFor(admin => admin.ImageUrl)
                .MaximumLength(AdminModelConstants.MAX_IMAGEURL_LENGTH);

            RuleFor(admin => admin.CountClosedOrders)
                .GreaterThanOrEqualTo(0);
        }
    }
}
