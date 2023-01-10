using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Commands.Products.AddProductGroup
{
    internal sealed class AddProductGroupCommandHandler : IRequestHandler<AddProductGroupCommand, ProductGroupDto>
    {
        private readonly IVmsInformRepository<ProductGroupEntry> _productGroupsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProductGroupCommandHandler(IVmsInformRepository<ProductGroupEntry> productGroupsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productGroupsRepository = productGroupsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductGroupDto> Handle(AddProductGroupCommand request, CancellationToken cancellationToken)
        {
            var newGroup = _mapper.Map<ProductGroupEntry>(request);
            await _productGroupsRepository.AddAsync(newGroup, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return _mapper.Map<ProductGroupDto>(newGroup);
        }
    }
}
