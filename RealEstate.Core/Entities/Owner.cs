using System.Collections.Generic;

namespace RealEstate.Core.Entities
{
    public class Owner: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
