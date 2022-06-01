using FluentValidation;
using VmsInform.Web.Dto.News;

namespace VmsInform.Business.Validators
{
    internal class NewsEditDtoValidator : AbstractValidator<NewsEditDto>
    {
        public NewsEditDtoValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty();
        }
    }
}
