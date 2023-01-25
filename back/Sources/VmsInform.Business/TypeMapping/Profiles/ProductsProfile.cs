using AutoMapper;
using System.Linq;
using VmsInform.Business.Commands.Products.AddProductGroup;
using VmsInform.DAL.Domain.Products;
using VmsInform.Web.Dto.Products;

namespace VmsInform.Business.TypeMapping.Profiles
{
    internal sealed class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductEntry, ProductEditDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(a => a.Components, opt => opt.MapFrom(src => src.ComponentsRaw.Select(a => new ProductComponentDto { Id = a.GoodId, Name = a.Good.Name, Type = ComponentType.Raw, Percentage = a.Percentage })))
                .ForMember(a => a.Pictures, opt => opt.MapFrom(src => src.Pictures.Select(a => new ProductPictureDto { PictureId = a.PictureId })));

            CreateMap<ProductEditDto, ProductEntry>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(a => a.ComponentsRaw, opt => opt.Ignore())
                .ForMember(a => a.Pictures, opt => opt.Ignore())
                .AfterMap((src, dst) =>
                {
                    var raw = src.Components.Where(a => a.Type == ComponentType.Raw).ToList();
                    var toDelete = dst.ComponentsRaw.Where(a => raw.All(x => x.Id != a.GoodId));

                    foreach(var item in toDelete)
                    {
                        dst.ComponentsRaw.Remove(item);
                    }

                    var toAdd = raw.Where(a => dst.ComponentsRaw.All(x => x.GoodId != a.Id));

                    foreach (var item in toAdd)
                    {
                        dst.ComponentsRaw.Add(new ProductComponentRawEntry { GoodId = item.Id, Percentage = item.Percentage });
                    }

                    var toUpdate = dst.ComponentsRaw.Where(a => raw.Any(x => x.Id == a.GoodId));

                    foreach(var item in toUpdate)
                    {
                        item.Percentage = raw.First(a => a.Id == item.GoodId).Percentage;
                    }

                    dst.Pictures.Clear();
                    
                    foreach(var pic in src.Pictures)
                    {
                        dst.Pictures.Add(new ProductPictureEntry { PictureId = pic.PictureId });
                    }

                });

            CreateMap<AddProductGroupCommand, ProductGroupEntry>()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))    
                .ForMember(a => a.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(a => a.Products, opt => opt.Ignore())
                .ForMember(a => a.Parent, opt => opt.Ignore());

            CreateMap<ProductGroupEntry, ProductGroupDto>()
                .ForMember(a => a.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(a => a.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(src => src.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(src => src.Code, opt => opt.Ignore());
        }
    }
}
