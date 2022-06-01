using MediatR;

namespace VmsInform.Business.Commands.Factories.DeleteFactory
{
    public class DeleteFactoryCommand : IRequest
    {
        public long Id { get; set; }
    }
}
