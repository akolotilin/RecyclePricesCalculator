using MediatR;
using VmsInform.Web.Dto.Factories;

namespace VmsInform.Business.Commands.Factories.AddFactory
{
    public class AddFactoryCommand : IRequest<FactoryDto>
    {
        public FactoryDto Item { get; set; }
    }
}
