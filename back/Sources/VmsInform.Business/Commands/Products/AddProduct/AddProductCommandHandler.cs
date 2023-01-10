using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Commands.Products.AddProduct
{
    internal sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductEditDto>
    {
        private readonly IVmsInformRepository<ProductEntry> _productsRepository;
        private readonly IVmsInformRepository<Good> _goodsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IVmsInformRepository<ProductEntry> productsRepository, IVmsInformRepository<Good> goodsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _goodsRepository = goodsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private Task<Good> GetGoodById(long goodId, CancellationToken cancellationToken)
        {
            return _goodsRepository.Query().FirstOrDefaultAsync(a=>a.Id == goodId, cancellationToken);
        }

        public async Task<ProductEditDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var item = request.Item;
            var product = new ProductEntry
            {
                Name = item.Name,
                Description = item.Description,
                ComponentsRaw = item.Components.Where(a => a.Type == ComponentType.Raw).Select(async a => new ProductComponentRawEntry { Good = await GetGoodById(a.Id, cancellationToken) })
                .Select(a => a.Result).ToList()
            };

            await _productsRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new ProductEditDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Components = product.ComponentsRaw.Select(a => new ProductComponentDto { Id = a.Good.Id, Name = a.Good.Name, Percentage = 10, Type = ComponentType.Raw })
            };
        }
    }
}
