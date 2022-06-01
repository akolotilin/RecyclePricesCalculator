using FluentValidation;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.UpdateNews
{
    internal sealed class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
    {
        public UpdateNewsCommandValidator(IValidator<NewsEditDto> validator)
        {
            RuleFor(a => a.Item)
                .NotNull();

            RuleFor(a => a.Item)
                .SetValidator(validator);
        }
    }
}
