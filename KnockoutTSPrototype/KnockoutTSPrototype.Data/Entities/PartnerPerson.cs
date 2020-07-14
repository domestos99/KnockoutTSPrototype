using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutTSPrototype.Data.Entities
{
    public class PartnerPerson : BaseEntity
    {
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
    }
}
