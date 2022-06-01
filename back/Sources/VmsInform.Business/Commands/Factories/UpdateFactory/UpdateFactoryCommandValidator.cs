using FluentValidation;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Commands.Factories.UpdateFactory
{
    internal sealed class UpdateFactoryCommandValidator : AbstractValidator<UpdateFactoryCommand>
    {
        public UpdateFactoryCommandValidator(IValidator<FactoryDto> factoryValidator)
        {
            RuleFor(a => a.Item)
                .NotNull();

            RuleFor(a => a.Item)
                .SetValidator(factoryValidator);
        }
    }
}
