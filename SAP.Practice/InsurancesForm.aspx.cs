using SAP.BLL;
using SAP.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAP.Practice
{
    public partial class InsurancesForm : System.Web.UI.Page
    {
        private IEnumerable<Client> clients;

        private const string TYPE_CAR = "CAR";
        private const string TYPE_BOAT = "BOAT";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadClients();
                this.RefreshItems();
            }
        }

        private void LoadClients()
        {
            var business = new ClientBLL();
            this.clients = business.Get();

            this.ddlClient.DataSource = this.clients;
            this.ddlClient.DataValueField = "DocumentId";
            this.ddlClient.DataTextField = "FullDescription";

            this.ddlClient.DataBind();
        }

        private void RefreshItems()
        {
            var business = new InsuranceBLL();
            var items = business.Get();

            this.grdItems.DataSource = items;
            this.grdItems.DataBind();
        }

        private void ClearControls()
        {
            this.txtInsuranceId.Text = String.Empty;
            this.txtValue.Text = String.Empty;
            this.ddlClient.SelectedIndex = -1;
            this.ddlStatus.SelectedIndex = -1;
            this.ddlType.SelectedIndex = -1;
        }

        private void LoadControls(GridViewRow row)
        {
            this.txtInsuranceId.Text = row.Cells[1].Text;
            this.ddlStatus.SelectedValue = row.Cells[2].Text;
            this.txtValue.Text = row.Cells[4].Text;
            this.ddlType.SelectedIndex = 1;
            
        }

        private Client GetSelectedClient()
        {
            var client = this.clients.FirstOrDefault(x => x.DocumentId == this.ddlClient.SelectedValue);
            return client;
        }

        private Insurance CreateModelFromUI()
        {
            var model = this.ddlType.SelectedValue == TYPE_CAR ? (Insurance)new CarInsurance() : new BoatInsurance();

            model.InsuranceId = Convert.ToInt32(this.txtInsuranceId.Text);
            model.Status = this.ddlStatus.SelectedValue;
            model.Value = Convert.ToDouble(this.txtValue.Text);
            model.Client = this.GetSelectedClient();

            return model;
        }

        private void CallBusinessAction(Action<InsuranceBLL, Insurance> action)
        {
            var model = this.CreateModelFromUI();

            var business = new InsuranceBLL();
            action(business, model);

            this.ClearControls();
            this.RefreshItems();
        }

        protected void btnCreate_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Create(model));

        protected void btnUpdate_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Update(model));

        protected void btnDelete_Click(object sender, EventArgs e) => this.CallBusinessAction((business, model) => business.Delete(model));

        protected void grdItems_SelectedIndexChanged(object sender, EventArgs e) => this.LoadControls(this.grdItems.SelectedRow);
    }
}