using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Goods.DeleteGood
{
    internal sealed class DeleteGoodCommandHandler : IRequestHandler<DeleteGoodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Good> _goodsRepository;

        public DeleteGoodCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Good> goodsRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
        }

        public async Task<Unit> Handle(DeleteGoodCommand request, CancellationToken cancellationToken)
        {
            _goodsRepository.Delete(request.GoodId);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
