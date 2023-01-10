using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain.Products;

namespace VmsInform.Business.Commands.Products.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IVmsInformRepository<ProductEntry> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IMapper mapper, IVmsInformRepository<ProductEntry> productRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var item = request.Item;
            var product = await _productRepository.GetAsync(item.Id, cancellationToken);

            _mapper.Map(item, product);

            _productRepository.Update(product);

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
