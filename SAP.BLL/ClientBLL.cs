using SAP.BE;
using SAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BLL
{
    public class ClientBLL : BaseBLL<Client, string>
    {
        public ClientBLL() : base(ClientDAL.Instance) { }
    }
}
