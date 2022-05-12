using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using SignalRClient.Enumerations;
using SignalRClient.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SignalRClient.View
{
    public partial class MainForm : Form
    {
        public ISignalRService SignalRService { get; set; }

        /// <summary>
        /// 紀錄topic與其對應之ChatControl
        /// </summary>
        private Dictionary<string, ChatControl> topicControls;

        public MainForm()
        {
            InitializeComponent();
            topicControls = new Dictionary<string, ChatControl>();
            cbProtocol.DataSource = Enum.GetValues(typeof(SignalRProtocol));
            tbUserName.MaxLength = UserName.MaxLength;
            tbPassword.MaxLength = Password.MaxLength;
        }

        /// <summary>
        /// 設定連線UI是否可以使用
        /// </summary>
        /// <param name="enable"></param>
        public void EnableConnectionUI(bool enable)
        {
            var result = tlpConnection.BeginInvoke((MethodInvoker)delegate
            {
                tlpConnection.Enabled = enable;
                btnConnect.Enabled = enable;
            });
            tlpConnection.EndInvoke(result);
        }

        /// <summary>
        /// 設定panelCenter是否可以使用
        /// </summary>
        /// <param name="enable"></param>
        public void EnablePanelCenter(bool enable)
        {
            var result = panelCenter.BeginInvoke((MethodInvoker)delegate
            {
                panelCenter.Enabled = enable;
            });
            panelCenter.EndInvoke(result);
        }

        /// <summary>
        /// 嘗試為topic新增一個tabpage，若該topic不存在，則新增tabpage、並用chatControl回傳<br/>
        /// 反之method回傳false
        /// </summary>
        /// <param name="topic">特定topic</param>
        /// <param name="chatControl">若新增成功，則回傳該ChatControl</param>
        /// <returns>如果新增成功，則回傳true，反之則為</returns>
        public bool TryAddChatTabPage(Topic topic, out ChatControl chatControl)
        {
            chatControl = null;
            if (!topicControls.ContainsKey(topic))
            {
                chatControl = new ChatControl() { Topic = topic, Dock = DockStyle.Fill };
                topicControls.Add(topic, chatControl);

                TabPage tabPage = new TabPage(topic);
                tabPage.Controls.Add(chatControl);
                //tabControlChat.TabPages.Add(tabPage);
                AddTabPage(tabPage);
                return true;
            }
            return false;
        }

        private void AddTabPage(TabPage tabPage)
        {
            var result = tabControlChat.BeginInvoke((MethodInvoker)delegate
            {
                tabControlChat.TabPages.Add(tabPage);
            });
            tabControlChat.EndInvoke(result);
        }

        /// <summary>
        /// 將特定Topic的訊息加到到對應的聊天頁面
        /// </summary>
        /// <param name="topic">topic</param>
        /// <param name="chatMessage">topic的聊天訊息</param>
        public void AppendTopicMessage(string topic, ChatRoomMessage chatMessage)
        {
            topicControls[topic].AppendChatMessage(chatMessage);
        }

        /// <summary>
        /// 清除聊天的tabpage與dictionary
        /// </summary>
        public void ClearAllTopics()
        {
            var result = tabControlChat.BeginInvoke((MethodInvoker)delegate
            {
                tabControlChat.TabPages.Clear();
                topicControls.Clear();
            });
            tabControlChat.EndInvoke(result);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SignalRProtocol protocol = (SignalRProtocol)cbProtocol.SelectedItem;
            //OnConnectionClicked.Invoke(protocol, tbPath.Text, tbIp.Text, ((int)nudPort.Value), tbUserName.Text, tbPassword.Text);
            SignalRService.ConnectToSignalRServer(protocol, tbPath.Text, tbIp.Text, ((int)nudPort.Value), tbUserName.Text, tbPassword.Text);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //OnDisconnectClicked.Invoke(sender, e);
            SignalRService.DisconnectFromSignalRServer();
        }

        private void btnJoinChat_Click(object sender, EventArgs e)
        {
            using (var joinChatDialog = new JoinChatDialog())
            {
                // 開啟對話框並取得DialogResult
                var dialogResult = joinChatDialog.ShowDialog();
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    // 訂閱對話框輸入的Topic
                    SignalRService.JoinChat(joinChatDialog.Topic);
                }
            }
        }

        private void tbIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConnect.PerformClick();
            }
        }

        private void tbIp_TextChanged(object sender, EventArgs e)
        {
            HandleUrlDisplay();
        }

        private void cbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleUrlDisplay();
        }

        private void HandleUrlDisplay()
        {
            var protocol = (SignalRProtocol)cbProtocol.SelectedItem;
            lblUrlDisplay.Text = $"{protocol}://{tbIp.Text}:{nudPort.Value}/{tbPath.Text}";
        }
    }
}
