using SAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BLL
{
    public class BaseBLL<T, Y>
    {
        protected BaseDAL<T, Y> Dal;

        public BaseBLL(BaseDAL<T, Y> dal)
        {
            this.Dal = dal;
        }

        public void Create(T model) => this.Dal.Create(model);
        public void Update(T model) => this.Dal.Update(model);
        public void Delete(T model) => this.Dal.Delete(model);
        public IList<T> Get() => this.Dal.Get();
    }
}
