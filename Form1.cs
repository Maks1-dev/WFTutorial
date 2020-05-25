using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            if (FormAuthorization.users.type == "agent") buttonOpenAgents.Enabled = false;
            LabelHello.Text = "Приветствую тебя, " + FormAuthorization.users.login;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            Form formClient = new FormClient();
            formClient.Show();
        }

        private void buttonOpenRealEstates_Click(object sender, EventArgs e)
        {
            Form formrealestate = new FormRealEstate();
            formrealestate.Show();
        }
        

        private void buttonOpenAgents_Click(object sender, EventArgs e)
        {
            Form formagent = new FormAgent();
            formagent.Show();
        }

        private void buttonOpenDemands_Click(object sender, EventArgs e)
        {
            Form formsupply = new FormSupply();
            formsupply.Show();
        }

        private void buttonOpenDeals_Click(object sender, EventArgs e)
        {
            Form formDeal = new FormDeal();
            formDeal.Show();
        }

        private void buttonOpenSupplies_Click(object sender, EventArgs e)
        {
            Form formNeeds = new FormNeeds();
            formNeeds.Show();
        }
    }
}
