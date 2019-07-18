using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BE
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }

        public string FullDescription => String.Format("{0} - {1}, {2}", this.DocumentId, this.LastName, this.FirstName);
    }
}
