using System;
using System.Collections.Generic;
using VmsInform.DAL.Domain.Common;
using VmsInform.DAL.MyBoxRepositories;

namespace VmsInform.DAL.Domain
{
    public class Shipment : VmsInformEntity, IEditorInfo
    {
        public long LastEditorId { get; set; }
        public virtual User LastEditor { get; set; }
        public DateTime LastEdit { get; set; }
        public long CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public DateTime Created { get; set; }

        public DateTime ShipmentDate { get; set; }
        public string Comment { get; set; }

        public long PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        public long? FactoryId { get; set; }
        public virtual Factory Factory { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
