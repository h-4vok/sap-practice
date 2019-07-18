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
    public partial class ClientsForm : System.Web.UI.Page
    {
        private IList<Client> items;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) this.RefreshItems();
        }

        private void RefreshItems()
        {
            var business = new ClientBLL();
            this.items = business.Get();

            this.grdItems.DataSource = this.items;
            this.grdItems.DataBind();
        }

        private void ClearControls()
        {
            Action<TextBox> clear = x => x.Text = string.Empty;

            clear(this.txtDocumentId);
            clear(this.txtFirstName);
            clear(this.txtLastName);
        }

        private void LoadControls(GridViewRow row)
        {
            var controls = new[] { this.txtDocumentId, this.txtFirstName, this.txtLastName };

            for(var i = 1; i <= 3; i++)
            {
                controls[i - 1].Text = row.Cells[i].Text;
            }
        }

        private Client CreateModelFromUI()
        {
            var item = new Client
            {
                DocumentId = this.txtDocumentId.Text,
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
            };

            return item;
        }

        private void CallBusinessAction(Action<ClientBLL, Client> action)
        {
            var model = this.CreateModelFromUI();

            var business = new ClientBLL();
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