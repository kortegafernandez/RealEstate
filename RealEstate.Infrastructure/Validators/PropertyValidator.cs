using FluentValidation;
using RealEstate.Core.DTOs;

namespace RealEstate.Infrastructure.Validators
{
    public class PropertyValidator : AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.Price)
                .NotEmpty();

            RuleFor(p => p.Area)
                .NotEmpty();

            RuleFor(p => p.OwnerId)
                .NotEmpty();

            RuleFor(p => p.CategoryId)
                .NotEmpty();

            RuleFor(p => p.CityId)
                .NotEmpty();

            RuleFor(p => p.Address1)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.Address2)                
                .MaximumLength(100)
                .When(p => !string.IsNullOrEmpty(p.Address2));

            RuleFor(p => p.PostalCode)
                .MaximumLength(15)
                .When(p => !string.IsNullOrEmpty(p.Address2));
        }
    }
}
