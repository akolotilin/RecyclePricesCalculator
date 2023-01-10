using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.Common.Exceptions;
using VmsInform.DAL;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.Queries.Products.GetProductById
{
    class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductEditDto>
    {
        private readonly IRepositoryQuery<ProductEntry> _productsRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IRepositoryQuery<ProductEntry> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<ProductEditDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            => await _mapper.ProjectTo<ProductEditDto>(_productsRepository.Query().Where(a => a.Id == request.Id)).FirstOrDefaultAsync(cancellationToken) 
            ?? throw new NotFoundException("Product not found");
        
    }
}
