using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VmsInform.Business.Commands.Shipments.AddShipment;
using VmsInform.DAL;
using VmsInform.DAL.Domain;
using VmsInform.Web.Dto.Shipments;

namespace VmsInform.Business.TypeMapping.Profiles.Resolvers
{
    internal sealed class ShipmentPicturesResolver : IValueResolver<EditShipmentDto, Shipment, ICollection<Picture>>, IValueResolver<AddShipmentCommand, Shipment, ICollection<Picture>>
    {
        private readonly IVmsInformRepository<Picture> _picturesRepository;

        public ShipmentPicturesResolver(IVmsInformRepository<Picture> picturesRepository)
        {
            _picturesRepository = picturesRepository ?? throw new ArgumentNullException(nameof(picturesRepository));
        }

        public ICollection<Picture> Resolve(EditShipmentDto source, Shipment destination, ICollection<Picture> destMember, ResolutionContext context)
        {
            return source.Pictures.Select(a => _picturesRepository.Get(a))
                .ToList();
        }

        public ICollection<Picture> Resolve(AddShipmentCommand source, Shipment destination, ICollection<Picture> destMember, ResolutionContext context)
        {
            return source.Pictures.Select(a => _picturesRepository.Get(a))
                .ToList();
        }
    }
}
