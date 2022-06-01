using AutoMapper;
using System;
using VmsInform.Business.Commands.Goods.UpdateGood;
using VmsInform.DAL.Domain;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class BaseGoodRuleResolver : IValueResolver<UpdateGoodCommand, Good, BaseGoodRule>
    {
        private readonly IMapper _mapper;

        public BaseGoodRuleResolver(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public BaseGoodRule Resolve(UpdateGoodCommand source, Good destination, BaseGoodRule destMember, ResolutionContext context)
        {
            if (source.BaseGoodRule == null)
                return null;

            if (destMember != null)
            {
                _mapper.Map(source.BaseGoodRule, destMember);
                return destMember;
            }

            return _mapper.Map<BaseGoodRule>(source.BaseGoodRule);
        }
    }
}
