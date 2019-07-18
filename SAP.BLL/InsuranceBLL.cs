using SAP.BE;
using SAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BLL
{
    public class InsuranceBLL : BaseBLL<Insurance, int>
    {
        public InsuranceBLL() : base(InsuranceDAL.Instance)
        {
        }
    }
}
