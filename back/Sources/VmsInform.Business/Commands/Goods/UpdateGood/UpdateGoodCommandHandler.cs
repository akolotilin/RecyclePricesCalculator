using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Goods.UpdateGood
{
    internal sealed class UpdateGoodCommandHandler : IRequestHandler<UpdateGoodCommand>
    {
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IMapper _mapper;
        IUnitOfWork _unitOfWork;

        public UpdateGoodCommandHandler(IVmsInformRepository<Good> goodsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateGoodCommand request, CancellationToken cancellationToken)
        {
            var good = await _goodsRepository.GetAsync(request.GoodId, cancellationToken);
            _mapper.Map(request, good);
            _goodsRepository.Update(good);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
