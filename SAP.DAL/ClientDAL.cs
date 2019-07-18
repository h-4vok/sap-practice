using SAP.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.DAL
{
    public class ClientDAL : BaseDAL<Client, string>
    {
        #region Multi thread safe singleton

        private ClientDAL()
        {
            this.InitDefaultData();
        }
        static ClientDAL() { }

        public static ClientDAL Instance { get; } = new ClientDAL();

        #endregion

        private void InitDefaultData()
        {
            this.Create(new Client { DocumentId = "33074907", FirstName = "Christian", LastName = "Guzman" });
            this.Create(new Client { DocumentId = "31752006", FirstName = "Priscila", LastName = "Lavallen" });
            this.Create(new Client { DocumentId = "9938493C", FirstName = "Estranieri", LastName = "Italiani MaFangulo" });
        }

        protected override Func<Client, string> GetIdClosure => x => x.DocumentId;

    }
}
