using FluentValidation;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Commands.Goods.UploadGoodsFrom1C
{
    internal sealed class UploadGoodsFrom1CCommandValidator : AbstractValidator<UploadGoodsFrom1CCommand>
    {
        public UploadGoodsFrom1CCommandValidator(IValidator<Group1CDto> groupValidator)
        {
            RuleFor(a => a.Groups)
                .NotEmpty();

            RuleForEach(a => a.Groups)
                .SetValidator(groupValidator);
        }
    }
}
