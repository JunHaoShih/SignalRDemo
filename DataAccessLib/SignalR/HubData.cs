using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.SignalR
{
    public class HubData
    {
        /// <summary>
        /// 客戶端接收訊息的method名稱
        /// </summary>
        public const string ReceiveMessage = "ReceiveMessage";

        /// <summary>
        /// 客戶端接收登入結果的method名稱
        /// </summary>
        public const string LoginResult = "LoginResult";

        /// <summary>
        /// 客戶端接收訂閱結果的method名稱
        /// </summary>
        public const string SubscribeResult = "SubscribeResult";

        /// <summary>
        /// 客戶端發送topic訊息結果的method名稱
        /// </summary>
        public const string SendTopicMessageResult = "SendTopicMessageResult";

        /// <summary>
        /// 客戶端接收Topic訊息的method名稱
        /// </summary>
        public const string ReceiveTopicMessage = "ReceiveTopicMessage";

        public const string Login = "Login";

        public const string ClientOnErrorMethod = "OnError";

        public const string ClientOnDisconnectMethod = "OnDisconnect";

        public const string Subscribe = "Subscribe";

        public const string SendTopicMessage = "SendTopicMessage";
    }
}
