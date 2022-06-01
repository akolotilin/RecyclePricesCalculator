using FluentValidation;

namespace VmsInform.Common.Queries.Users
{
    internal sealed class CheckPasswordChangeRequestQueryValidator : AbstractValidator<CheckPasswordChangeRequestQuery>
    {
        public CheckPasswordChangeRequestQueryValidator()
        {
            RuleFor(a => a.Key)
                .NotEmpty();
        }
    }
}
