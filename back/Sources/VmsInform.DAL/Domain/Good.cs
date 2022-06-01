using System;
using System.Collections.Generic;

namespace VmsInform.DAL.Domain
{
    public class Good : NamedObject
    {
        public long GoodGroupId { get; set; }

        public virtual GoodGroup GoodGroup { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<GoodSurcharge> GoodSurcharges { get; set; }

        public virtual BaseGoodPrice BasePrice { get; set; }

        public bool InputPriceManual { get; set; }

        public virtual BaseGoodRule BaseGoodRule { get; set; }

        public long? BaseGoodRuleId { get; set; }

        public Guid Guid { get; set; }

        public string Code { get; set; }
    }
}
