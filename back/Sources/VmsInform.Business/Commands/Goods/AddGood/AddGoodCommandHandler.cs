using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.Commands.Goods.AddGood
{
    internal sealed class AddGoodCommandHandler : IRequestHandler<AddGoodCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IMapper _mapper;

        public AddGoodCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<Good> goodsRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<long> Handle(AddGoodCommand request, CancellationToken cancellationToken)
        {
            var good = _mapper.Map<Good>(request);
            await _goodsRepository.AddAsync(good, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return good.Id;
        }
    }
}
