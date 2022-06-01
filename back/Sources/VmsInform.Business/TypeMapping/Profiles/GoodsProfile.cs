using AutoMapper;
using VmsInform.Business.Commands.Goods.AddGood;
using VmsInform.Business.Commands.Goods.UpdateGood;
using VmsInform.Business.TypeMapping.Profiles.Resolvers;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Common;
using VmsInform.Web.Dto.Goods;
using VmsInform.Web.Dto.Goods.Hierarchy;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            CreateMap<GoodEditDto, AddGoodCommand>();
            CreateMap<GoodEditDto, UpdateGoodCommand>();

            CreateMap<AddGoodCommand, Good>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.GoodGroupId, opt => opt.MapFrom(src => src.GroupId));

            CreateMap<Good, GoodEditDto>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.GroupId, opt => opt.MapFrom(src => src.GoodGroupId));

            CreateMap<UpdateGoodCommand, Good>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(a => a.GoodGroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(a => a.BaseGoodRule, opt => opt.MapFrom<BaseGoodRuleResolver>());

            CreateMap<Good, NamedObjectDto>()
                .IncludeBase<NamedObject, NamedObjectDto>();

            CreateMap<Good, GoodsTreeNodeItemDto>();

            CreateMap<BaseGoodRule, BaseGoodRuleDto>()
                .ForMember(a => a.GoodId, opt => opt.MapFrom(src => src.BaseGoodId))
                .ForMember(a => a.GoodName, opt => opt.MapFrom(src => src.BaseGood.Name))
                .ForMember(a => a.Multiplier, opt => opt.MapFrom(src => src.Multiplier))
                .ForMember(a => a.Add, opt => opt.MapFrom(src => src.Add));

            CreateMap<BaseGoodRuleDto, BaseGoodRule>()
                .ForMember(a => a.BaseGoodId, opt => opt.MapFrom(src => src.GoodId))
                .ForMember(a => a.Add, opt => opt.MapFrom(src => src.Add))
                .ForMember(a => a.Multiplier, opt => opt.MapFrom(src => src.Multiplier))
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private long? NamedObjectDtoToId(NamedObjectDto item)
        {
            return item?.Id;
        }
    }
}
