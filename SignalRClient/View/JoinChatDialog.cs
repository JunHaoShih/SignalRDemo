using DataAccessLib.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SignalRClient.View
{
    public partial class JoinChatDialog : Form
    {
        private Topic topic = null;

        public Topic Topic
        {
            get { return topic; }
        }

        public JoinChatDialog()
        {
            InitializeComponent();
            ActiveControl = tbTopic;
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (!Topic.TryParseWithMessage(tbTopic.Text, out topic, out string errorMsg))
            {
                MessageBox.Show(errorMsg, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbTopic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnJoin.PerformClick();
            }
        }
    }
}
