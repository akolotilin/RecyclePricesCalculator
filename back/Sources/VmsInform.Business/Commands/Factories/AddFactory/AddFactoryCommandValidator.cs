using FluentValidation;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Commands.Factories.AddFactory
{
    internal sealed class AddFactoryCommandValidator : AbstractValidator<AddFactoryCommand>
    {
        public AddFactoryCommandValidator(IValidator<FactoryDto> factoryValidator)
        {
            RuleFor(a => a.Item)
                .NotNull();

            RuleFor(a => a.Item)
                .SetValidator(factoryValidator);
        }
    }
}
