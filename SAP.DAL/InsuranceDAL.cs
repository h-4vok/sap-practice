using SAP.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.DAL
{
    public class InsuranceDAL : BaseDAL<Insurance, int>
    {
        #region Multi thread safe singleton

        private InsuranceDAL() { this.InitDefaultData(); }

        static InsuranceDAL() { }

        public static InsuranceDAL Instance { get; } = new InsuranceDAL();

        #endregion

        protected override Func<Insurance, int> GetIdClosure => x => x.InsuranceId;

        private void InitDefaultData()
        {
            this.Create(new CarInsurance { InsuranceId = 1, Status = "A", Value = 1000, Client = ClientDAL.Instance.Get("33074907") });
        }
    }
}
