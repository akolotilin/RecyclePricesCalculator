using FluentValidation;

namespace VmsInform.Business.Commands.News.DeleteNews
{
    internal sealed class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
    {
        public DeleteNewsCommandValidator()
        {
        }
    }
}
