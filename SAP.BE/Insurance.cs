using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BE
{
    public abstract class Insurance
    {
        public int InsuranceId { get; set; }
        public string Status { get; set; }
        public abstract double Rate { get; }
        public double Value { get; set; }
        public double Total { get { return this.Rate * this.Value; } }
        public Client Client { get; set; }

        public string ClientName => this.Client?.FullDescription ?? "Sin cliente asignado";

        public string ClientId => this.Client?.DocumentId ?? String.Empty;
    }
}
