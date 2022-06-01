using System;
using System.Collections.Generic;

namespace VmsInform.DAL.Domain
{
    public class GoodGroup : NamedObject
    {
        public long? ParentId { get; set; }
        public virtual GoodGroup Parent { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; }
    }
}
