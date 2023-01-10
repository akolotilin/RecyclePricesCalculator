using FluentValidation;

namespace VmsInform.Business.Commands.Products.AddProduct
{
    internal sealed class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
        }
    }
}
