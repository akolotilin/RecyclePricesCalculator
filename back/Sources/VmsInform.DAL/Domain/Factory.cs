using System.Collections.Generic;

namespace VmsInform.DAL.Domain
{
    public class Factory : NamedObject
    {
        public string Address { get; set; }
        public decimal MinGarbage { get; set; }
        public decimal MaxGarbage { get; set; }
        public decimal Distance { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public virtual ICollection<PartnerFactory> Partners { get; set; }
    }
}
