using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class LogEntry
    {
        public SecurityThreat Before { get; set; }
        public SecurityThreat After { get; set; }
        public StatusData Status 
        { get
            {
                if (Before == null)
                    return StatusData.Added;
                else if (After == null)
                    return StatusData.Deleted;
                else
                    return StatusData.Updated;
                       

            }
            set { } }
    }
}
