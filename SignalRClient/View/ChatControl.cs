using DataAccessLib.Models;
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
    public partial class ChatControl : UserControl
    {
        /// <summary>
        /// 送出按鈕的click事件
        /// </summary>
        public Action<Topic, ChatText> OnBtnMessageSendClicked;

        private Topic topic;

        /// <summary>
        /// 聊天室Topic
        /// </summary>
        public Topic Topic
        {
            get { return topic; }
            set { lblTopic.Text = value; topic = value; }
        }

        public ChatControl()
        {
            InitializeComponent();
            tbMessageInput.MaxLength = ChatText.MaxLength;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            SendMessageAndClear();
        }

        /// <summary>
        /// 發送訊息並清空tbMessageInput
        /// </summary>
        private void SendMessageAndClear()
        {
            var isValid = ChatText.TryParse(tbMessageInput.Text, out ChatText chatMessage);
            if (isValid)
            {
                OnBtnMessageSendClicked?.Invoke(Topic, chatMessage);
                tbMessageInput.Clear();
            }
        }

        /// <summary>
        /// 將ChatMessage加入對話框
        /// </summary>
        /// <param name="chatMessage"></param>
        public void AppendChatMessage(ChatRoomMessage chatMessage)
        {
            var result = tbChatBox.BeginInvoke((MethodInvoker)delegate
            {
                tbChatBox.AppendText(chatMessage.ToChatString() + Environment.NewLine);
            });
            tbChatBox.EndInvoke(result);
        }

        private void tbMessageInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 檢查是否是鍵盤Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendMessageAndClear();
            }
        }
    }
}
