using FluentValidation;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Commands.News.AddNews
{
    internal sealed class AddNewsCommandValidator : AbstractValidator<AddNewsCommand>
    {
        public AddNewsCommandValidator(IValidator<NewsEditDto> newsValidator)
        {
            RuleFor(a => a.Item)
                .NotNull();

            RuleFor(a => a.Item)
                .SetValidator(newsValidator);
        }
    }
}
