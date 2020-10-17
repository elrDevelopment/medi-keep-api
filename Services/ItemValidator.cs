
using FluentValidation;
using Models;

namespace Services
{
    public class ItemValidator : AbstractValidator<ItemDTO>
    {
        public ItemValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty()
                .NotNull().WithMessage("Item Name can not be empty");
            RuleFor(x => x.Cost).GreaterThanOrEqualTo(0)
                .WithMessage("Cost must be greater than $0.00");
        }
    }
}