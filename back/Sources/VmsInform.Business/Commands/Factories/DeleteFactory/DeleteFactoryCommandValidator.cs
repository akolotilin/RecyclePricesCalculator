using FluentValidation;

namespace VmsInform.Business.Commands.Factories.DeleteFactory
{
    internal sealed class DeleteFactoryCommandValidator : AbstractValidator<DeleteFactoryCommand>
    {
        public DeleteFactoryCommandValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0);
        }
    }
}
