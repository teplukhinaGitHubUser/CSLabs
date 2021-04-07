using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class SecurityThreat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool Сonfidentiality { get; set; }
        public bool Integrity { get; set; }
        public bool Availability { get; set; }

        public bool Equals(SecurityThreat securityThreat)
        {
            if (securityThreat == null)
                return false;
            return (Id == securityThreat.Id && Name == securityThreat.Name && Description == securityThreat.Description && Source == securityThreat.Source && Target == securityThreat.Target && Сonfidentiality == securityThreat.Сonfidentiality && Integrity == securityThreat.Integrity && Availability == securityThreat.Availability);
       
        }

    }

   

}
