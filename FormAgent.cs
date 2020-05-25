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
    public partial class FormAgent : Form
    {
        void ShowClient()
        {
            listViewAgent.Items.Clear();
            foreach (AgentsSet agentsSet in Program.wftDb.AgentsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                        agentsSet.id.ToString(), agentsSet.FirstName, agentsSet.MiddleName,
                        agentsSet.LastName, agentsSet.DealShare
                });
                item.Tag = agentsSet;
                listViewAgent.Items.Add(item);
            }
            listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public FormAgent()
        {
            InitializeComponent();
            ShowClient();
        }

        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentsSet agentsSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                textFirstName.Text = agentsSet.FirstName;
                textMiddleName.Text = agentsSet.MiddleName;
                textLastName.Text = agentsSet.LastName;
                textDealShare.Text = agentsSet.DealShare;

            }
            else
            {
                textFirstName.Text = "";
                textMiddleName.Text = "";
                textLastName.Text = "";
                textDealShare.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgentsSet agentSet = new AgentsSet();
            agentSet.FirstName = textFirstName.Text;
            agentSet.MiddleName = textMiddleName.Text;
            agentSet.LastName = textLastName.Text;
            agentSet.DealShare = textDealShare.Text;
            Program.wftDb.AgentsSet.Add(agentSet);
            Program.wftDb.SaveChanges();
            ShowClient();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentsSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                agentSet.FirstName = textFirstName.Text;
                agentSet.MiddleName = textMiddleName.Text;
                agentSet.LastName = textLastName.Text;
                agentSet.DealShare = textDealShare.Text;
                Program.wftDb.SaveChanges();
                ShowClient();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    AgentsSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentsSet;
                    Program.wftDb.AgentsSet.Remove(agentSet);
                    Program.wftDb.SaveChanges();
                    ShowClient();
                }
                textFirstName.Text = "";
                textMiddleName.Text = "";
                textLastName.Text = "";
                textDealShare.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
