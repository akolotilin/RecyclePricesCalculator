using MediatR;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Commands.Factories.UpdateFactory
{
    public class UpdateFactoryCommand : IRequest
    {
        public FactoryDto Item { get; set; }
    }
}
