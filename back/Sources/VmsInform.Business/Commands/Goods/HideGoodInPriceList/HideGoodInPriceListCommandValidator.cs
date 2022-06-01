using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VmsInform.Business.Commands.Goods.HideGoodInPriceList
{
    internal sealed class HideGoodInPriceListCommandValidator : AbstractValidator<HideGoodInPriceListCommand>
    {
        public HideGoodInPriceListCommandValidator()
        {
        }
    }
}
