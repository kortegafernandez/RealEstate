using System.Collections.Generic;

namespace RealEstate.Core.Entities
{
    public class Owner: BaseEntity
    {
        public Owner()
        {
            Properties = new HashSet<Property>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
