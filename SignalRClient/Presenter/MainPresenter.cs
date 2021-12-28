using DataAccessLib.Models;
using DataAccessLib.Models.DataTypes;
using SignalRClient.Enumerations;
using SignalRClient.SignalR;
using SignalRClient.View;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRClient.Presenter
{
    public class MainPresenter
    {
        private ISignalRClientHandler handler;

        private readonly MainForm view;

        public MainPresenter(MainForm form)
        {
            view = form;
            SetEventLinks();
        }

        /// <summary>
        /// 與MainForm的事件做連結
        /// </summary>
        private void SetEventLinks()
        {
            // 將MainForm的連線按鈕click事件與ConnectToSignalRServer連結
            view.OnConnectionClicked += ConnectToSignalRServer;
            // 將MainForm的登出按鈕click事件與DisconnectFromSignalRerver連結
            view.OnDisconnectClicked += DisconnectFromSignalRServer;
            // 將MainForm的加入聊天室按鈕click事件與OpenJoinChatDialog連結
            view.OnJoinChatClicked += OpenJoinChatDialog;
        }

        private void ConnectToSignalRServer(SignalRProtocol protocol, string path, string ip, int port, string user, string password)
        {
            _ = ConnectAsync(protocol, path, ip, port, user, password);
        }

        private void DisconnectFromSignalRServer(object sender, EventArgs e)
        {
            if (handler != null)
            {
                _ = handler.StopAsync();
            }
        }

        private void OpenJoinChatDialog(object sender, EventArgs e)
        {
            using (var joinChatDialog = new JoinChatDialog())
            {
                // 開啟對話框並取得DialogResult
                var dialogResult = joinChatDialog.ShowDialog();
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    // 訂閱對話框輸入的Topic
                    _ = handler.SubscribeAsync(joinChatDialog.Topic);
                }
            }
        }

        private async Task ConnectAsync(SignalRProtocol protocol, string path, string ip, int port, string user, string password)
        {
            if (handler == null)
            {
                var isUserNameValid = UserName.TryParseWithMessage(user, out UserName userNameObj, out string errorMsg);
                if (!isUserNameValid)
                {
                    MessageBox.Show(errorMsg, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var isPasswordValid = Password.TryParseWithMessage(password, out Password passwordObj, out errorMsg);
                if (!isPasswordValid)
                {
                    MessageBox.Show(errorMsg, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string url = $"{protocol}://{ip}:{port}/{path}";
                SignalRClientHandlerBuilder builder = new SignalRClientHandlerBuilder();
                handler = builder
                    .WithUrl(url)
                    .WithUserIdentity(userNameObj, passwordObj)
                    .WithOnDisconnectDelegate(OnClientDisconnected)
                    .WithOnLoginDelegate(OnLogin)
                    .WithOnSubscribeDelegate(OnSubscribe)
                    .WithOnPublishDelegate(OnPublish)
                    .WithReceiveTopicMessageDelegate(OnReceiveTopicMessage)
                    .WithOnErrorDelegate(OnError)
                    .WithAllowHttp(true)
                    .Build();
                await handler.StartAsync();
            }
        }

        private void OnReceiveTopicMessage(string user, string topic, string message)
        {
            var isValid = UserName.TryParse(user, out UserName userName);
            isValid = Topic.TryParse(topic, out Topic topicObj);
            isValid = ChatText.TryParse(message, out ChatText chatText);
            ChatRoomMessage chatRoomMessage = new ChatRoomMessage() { UserName = userName, Topic = topicObj, ChatMessage = chatText };
            view.TryAddChatTabPage(topicObj, out ChatControl chatControl);
            view.AppendTopicMessage(topicObj, chatRoomMessage);
        }

        private void OnPublish(HttpStatusCode statusCode, string message)
        {
            MessageBox.Show($"發生錯誤{Environment.NewLine}{message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //throw new NotImplementedException();
        }

        private void OnSubscribe(HttpStatusCode statusCode, string message)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                // 嘗試為該Topic新增TabPage
                var IsAdded = view.TryAddChatTabPage(new Topic(message), out ChatControl chatControl);
                // 若有新增，則把回傳的ChatControl的發送按鈕click事件與ChatControlPublish連結
                if (IsAdded)
                {
                    chatControl.OnBtnMessageSendClicked += ChatControlPublish;
                }
            }
            else
            {
                MessageBox.Show($"發生錯誤{Environment.NewLine}{message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChatControlPublish(Topic topic, ChatText chatText)
        {
            _ = handler.PublishAsync(topic, chatText);
        }

        /// <summary>
        /// 處理客戶端離線時要處理的事情，主要的事情有<br/>
        /// 1. enable連線UI、disable聊天UI<br/>
        /// 2. 處理中斷狀態與server的exception
        /// </summary>
        /// <param name="e"></param>
        private Task OnClientDisconnected(Exception e)
        {
            // 將連線的UI給enable
            view.EnableConnectionUI(true);
            // 將聊天的UI給disable
            view.EnablePanelCenter(false);
            // 清除聊天的tabpage與dictionary
            view.ClearAllTopics();
            
            handler = null;

            return null;
        }

        /// <summary>
        /// 處理未知錯誤
        /// </summary>
        /// <param name="message"></param>
        private void OnError(string message)
        {
            MessageBox.Show($"發生錯誤{Environment.NewLine}{message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            handler = null;
        }

        private void OnLogin(HttpStatusCode statusCode, string message)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                // 將連線的UI給disable
                view.EnableConnectionUI(false);
                // 將聊天的UI給enable
                view.EnablePanelCenter(true);
            }
            else
            {
                OnError(message);
            }
        }
    }
}
