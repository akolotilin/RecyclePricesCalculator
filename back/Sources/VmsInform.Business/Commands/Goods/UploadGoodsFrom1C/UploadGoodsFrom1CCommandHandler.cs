using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Goods._1C;

namespace VmsInform.Business.Commands.Goods.UploadGoodsFrom1C
{
    internal sealed class UploadGoodsFrom1CCommandHandler : IRequestHandler<UploadGoodsFrom1CCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVmsInformRepository<GoodGroup> _goodGroupRepository;
        private readonly IVmsInformRepository<Good> _goodsRepository;

        public UploadGoodsFrom1CCommandHandler(IUnitOfWork unitOfWork, IVmsInformRepository<GoodGroup> goodGroupRepository, IVmsInformRepository<Good> goodsRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _goodGroupRepository = goodGroupRepository ?? throw new ArgumentNullException(nameof(goodGroupRepository));
            _goodsRepository = goodsRepository ?? throw new ArgumentNullException(nameof(goodsRepository));
        }

        public async Task<Unit> Handle(UploadGoodsFrom1CCommand request, CancellationToken cancellationToken)
        {
            await ImportGroups(request.Groups, null, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return Unit.Value;
        }

        private async Task ImportGroups(IEnumerable<Group1CDto> groups, GoodGroup parent, CancellationToken cancellationToken)
        {
            foreach (var group in groups)
            {
                await ImportGroup(group, parent, cancellationToken);
            }
        }

        private bool CheckGoodExists(Guid guid)
        {
            return _goodsRepository.Query().Any(a => a.Guid == guid);
        }

        private void ImportGoods(IEnumerable<Good1CDto> goods, GoodGroup parent, CancellationToken cancellationToken)
        {
            var newGoods = goods
                .Where(a => a.SubItems == null || !a.SubItems.Any())
                .Where(a => !CheckGoodExists(Guid.Parse(a.Guid)))
                .Select(a => new Good { Guid = Guid.Parse(a.Guid), Name = a.Name, Code = a.Code, Comment = a.Comment })
                .Union(goods
                .Where(a => a.SubItems != null)
                .SelectMany(a => a.SubItems.Select(s => new Good1CSubItem { Guid = s.Guid, Name = $"{a.Name} {s.Name}", Code = s.Code }))
                .Where(a => !CheckGoodExists(Guid.Parse(a.Guid)))
                .Select(a => new Good { Guid = Guid.Parse(a.Guid), Name = a.Name, Comment = "Импортировано из 1С" }));

            if (parent.Goods == null)
            {
                parent.Goods = new List<Good>();
            }

            foreach (var good in newGoods)
            {
                parent.Goods.Add(good);
            }
        }

        private async Task<GoodGroup> GetOrCreateGroup(Group1CDto groupDto, GoodGroup parent, CancellationToken cancellationToken)
        {
            var groupGuid = Guid.Parse(groupDto.Guid);

            var result = await _goodGroupRepository.Query()
                .FirstOrDefaultAsync(a => a.Guid == groupGuid, cancellationToken);

            if (result == null)
            {
                result = new GoodGroup
                {
                    Name = groupDto.Name,
                    Guid = groupGuid,
                    Parent = parent
                };

                await _goodGroupRepository.AddAsync(result, cancellationToken);
            }
            return result;
        }


        private async Task ImportGroup(Group1CDto groupDto, GoodGroup parent, CancellationToken cancellationToken)
        {
            var goodGroup = await GetOrCreateGroup(groupDto, parent, cancellationToken);

            if (groupDto.SubGroups?.Any() ?? false)
            {
                await ImportGroups(groupDto.SubGroups, goodGroup, cancellationToken);
            }

            if (groupDto.Goods?.Any() ?? false)
            {
                ImportGoods(groupDto.Goods, goodGroup, cancellationToken);
            }
        }
    }
}
